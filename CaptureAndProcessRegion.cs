using System;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace 自动喝药
{
    public class RegionProcessor
    {
        private readonly Form1 _form;

        public RegionProcessor(Form1 form)
        {
            _form = form; // 保存对 Form1 的引用
        }

        public void CaptureAndProcessRegion()
        {
            try
            {
                // 截取指定区域
                using (var bitmap = new Bitmap(_form._selectedRegion.Width, _form._selectedRegion.Height))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(_form._selectedRegion.Location, new System.Drawing.Point(0, 0), _form._selectedRegion.Size);
                    }

                    // 转换为 OpenCV Mat 格式
                    using (var mat = BitmapConverter.ToMat(bitmap))
                    {
                        Cv2.CvtColor(mat, mat, ColorConversionCodes.BGRA2BGR);

                        // 执行 OCR 并更新界面
                        _form.Invoke(new Action(() => _form.OCRThenUpdateHealthInfo(mat)));
                    }
                }
            }
            catch (Exception ex)
            {
                // 捕获异常并显示错误信息
                _form.Invoke(new Action(() => _form.lblHealthPercentage.Text = "捕获或处理错误：" + ex.Message));
            }
        }
    }
}
