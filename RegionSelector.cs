namespace 自动喝药;

public class RegionSelector : Form
{
    public Point TopLeft { get; private set; }
    public Point BottomRight { get; private set; }
    public Rectangle Rectangle { get; private set; }
    private Point startPoint;
    private Point endPoint;
    private bool isSelecting = false;

    public RegionSelector()
    {
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.Black;
        Opacity = 0.5;
        Cursor = Cursors.Cross;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isSelecting = true;
            startPoint = e.Location;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (isSelecting)
        {
            endPoint = e.Location;
            Invalidate(); // 触发重绘
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (isSelecting && e.Button == MouseButtons.Left)
        {
            isSelecting = false;
            var x = Math.Min(startPoint.X, endPoint.X);
            var y = Math.Min(startPoint.Y, endPoint.Y);
            var width = Math.Abs(startPoint.X - endPoint.X);
            var height = Math.Abs(startPoint.Y - endPoint.Y);
            TopLeft = new Point(x, y);
            BottomRight = new Point(x + width, y + height);
            Rectangle = new Rectangle(x, y, width, height);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (isSelecting)
        {
            var x = Math.Min(startPoint.X, endPoint.X);
            var y = Math.Min(startPoint.Y, endPoint.Y);
            var width = Math.Abs(startPoint.X - endPoint.X);
            var height = Math.Abs(startPoint.Y - endPoint.Y);
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(x, y, width, height));
        }
    }
}
