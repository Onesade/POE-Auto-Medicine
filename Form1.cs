using System.Reflection;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.Text;
using WindowsInput;
using WindowsInput.Native;


namespace 自动喝药;

public partial class Form1 : Form
{
    private DateTime _lastKeyPressTime = DateTime.MinValue; // 上一次按键触发的时间
    private TimeSpan _keyPressCooldown = TimeSpan.FromMilliseconds(500); // 默认冷却时间
    private readonly InputSimulator _inputSimulator = new InputSimulator();
    private int _healthThreshold = 50; // 默认阈值为 50%
    private int _keyCodeToPress = -1;  // 默认无效的 KeyCode
    private RegionProcessor _regionProcessor;
    internal Rectangle _selectedRegion; // 保存用户选择的区域
    private System.Timers.Timer _captureTimer;// 将 _selectedRegion 的访问修饰符改为 internal
    private readonly OCRTesseract _tesseract;
    private void trackBarHealthThreshold_Scroll(object sender, EventArgs e)
    {
        // 获取滑块的当前值
        _healthThreshold = trackBarHealthThreshold.Value;

        // 在界面上显示滑块的值
        autopercentage.Text = $"阈值: {_healthThreshold}%";
    }

    private void StartCaptureLoop()
    {
        if (_captureTimer == null)
        {
            // 初始化定时器，每 30 毫秒触发一次
            _captureTimer = new System.Timers.Timer(30); // 每秒约 33 次
            _captureTimer.Elapsed += (s, e) => _regionProcessor.CaptureAndProcessRegion();
            _captureTimer.AutoReset = true; // 自动重置，确保定时器持续触发
        }

        _captureTimer.Start(); // 启动定时器
    }
    private void StopCaptureLoop()
    {
        _captureTimer?.Stop(); // 停止定时器
    }
    private void btnStopCapture_Click(object sender, EventArgs e)
    {
        StopCaptureLoop();
        MessageBox.Show("已停止监测");
    }

    public Form1()
    {
        var processPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        _tesseract = OCRTesseract.Create(processPath, "eng", "0123456789/");
        InitializeComponent();
        _regionProcessor = new RegionProcessor(this);
    }
    private void TxtKeyInput_TextChanged(object sender, EventArgs e)
    {
        var input = txtKeyInput.Text.Trim();

        if (!string.IsNullOrEmpty(input) && input.Length == 1)
        {
            // 检查输入是否为数字
            if (char.IsDigit(input[0]))
            {
                // 将数字键映射到对应的 KeyCode
                _keyCodeToPress = (int)Keys.D0 + (input[0] - '0'); // Keys.D0 是数字 0 的起始值
                lblKeyCode.Text = $"KeyCode: {_keyCodeToPress}";
            }
            else
            {
                // 将输入的字符转换为 KeyCode
                try
                {
                    _keyCodeToPress = (int)Enum.Parse(typeof(Keys), input.ToUpper(), true);
                    lblKeyCode.Text = $"KeyCode: {_keyCodeToPress}";
                }
                catch
                {
                    lblKeyCode.Text = "Invalid Key";
                    _keyCodeToPress = -1; // 无效的 KeyCode
                }
            }
        }
        else
        {
            lblKeyCode.Text = "KeyCode: None";
            _keyCodeToPress = -1; // 无效的 KeyCode
        }
    }



    private void btnSelectRegion_Click(object sender, EventArgs e)
    {
        using var overlay = new RegionSelector();
        if (overlay.ShowDialog() == DialogResult.OK)
        {
            // 保存用户选择的区域
            _selectedRegion = overlay.Rectangle;

            // 立即执行一次截图和 OCR 处理
            var bitmap = new Bitmap(_selectedRegion.Width, _selectedRegion.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(_selectedRegion.Location, new System.Drawing.Point(0, 0), _selectedRegion.Size);
            }
            var mat = BitmapConverter.ToMat(bitmap);
            Cv2.CvtColor(mat, mat, ColorConversionCodes.BGRA2BGR);
            OCRThenUpdateHealthInfo(mat);

            // 启动定时器，开始循环监测
            StartCaptureLoop();
        }
    }

    public void OCRThenUpdateHealthInfo(Mat imageMat)
    {
        // 使用 Tesseract OCR 识别文本
        _tesseract.Run(imageMat, out var recognizedText, out var box, out var _, out var _);
        recognizedText = recognizedText.Trim();

        // 更新原始识别结果到界面
        lblHealths.Text = recognizedText;

        try
        {
            // 预处理：移除非数字和分隔符的字符
            recognizedText = new string(recognizedText.Where(c => char.IsDigit(c) || c == '/').ToArray());

            // 分割并验证血量信息
            var parts = recognizedText.Split('/');
            if (parts.Length == 2 &&
                float.TryParse(parts[0], out var currentHealth) &&
                float.TryParse(parts[1], out var maxHealth) &&
                maxHealth > 0) // 确保最大血量不为零
            {
                // 计算血量百分比并更新界面
                var healthPercentage = (int)Math.Round((currentHealth / maxHealth) * 100);
                lblHealthPercentage.Text = healthPercentage.ToString() + '%';

                // 检测是否低于滑块的阈值
                if (healthPercentage < _healthThreshold && _keyCodeToPress != -1)
                {
                    // 模拟按下按键
                    SimulateKeyPress(_keyCodeToPress);
                }
            }
            else
            {
                // 如果解析失败，显示错误信息
                lblHealthPercentage.Text = "无法解析血量信息";
            }
        }
        catch (Exception ex)
        {
            // 捕获异常并显示错误信息
            lblHealthPercentage.Text = "解析错误：" + ex.Message;
        }
    }
    private void SimulateKeyPress(int keyCode)
    {
        try
        {
            // 将 keyCode 转换为 VirtualKeyCode
            var virtualKeyCode = (VirtualKeyCode)keyCode;

            // 使用 InputSimulator 模拟按键
            _inputSimulator.Keyboard.KeyPress(virtualKeyCode);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"按键模拟失败: {ex.Message}");
        }
    }
    private void TxtKeyPressInterval_TextChanged(object sender, EventArgs e)
{
    var input = txtKeyPressInterval.Text.Trim();

    // 检查输入是否为有效的数字
    if (int.TryParse(input, out var interval) && interval > 0)
    {
        // 更新冷却时间
        _keyPressCooldown = TimeSpan.FromMilliseconds(interval);
    }
    else
    {
        // 如果输入无效，恢复默认值
        txtKeyPressInterval.Text = "500";
        _keyPressCooldown = TimeSpan.FromMilliseconds(500);
    }
}


}
