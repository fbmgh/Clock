using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Clock
{
    public partial class Code:Form
    {
        TextBox TB;
        public Code()
        {
            InitializeComponent();
            this.Text = "Clock";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Size = new Size(800, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.PeachPuff;
            TB = new TextBox();
            TB.Enabled = false;
            TB.Font = new Font("Bahnschrift", 14, FontStyle.Bold);
            TB.TextAlign = HorizontalAlignment.Center;
            TB.Size = new Size(200, 100);
            TB.Location = new Point(295, 600);
            TB.BackColor = Color.White;
            Controls.Add(TB);
            Timer Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += TimerTick;
            Timer.Start();
            this.Paint += new PaintEventHandler(Circle);
            this.Paint += new PaintEventHandler(Flags);
            this.Paint += new PaintEventHandler(SecArrow);
            this.Paint += new PaintEventHandler(MinArrow);
            this.Paint += new PaintEventHandler(HourArrow);
            this.Paint += new PaintEventHandler(Point);
        }
        public void TimerTick(object Sender, EventArgs EA)
        {
            DateTime DT = DateTime.Now;
            string Text = DateTime.Now.ToString("yyyy-MM-dd | HH:mm:ss");
            TB.Text = Text;
            double SecAngle = (DT.Second * 360.0 / 60.0) - 90;
            double MinAngle = (DT.Minute * 360.0 / 60.0) - 90;
            double HourAngle = (DT.Hour * 360.0 / 12.0 + (DT.Minute / 60.0) * (360.0 / 12.0)) - 90;
            Invalidate();
        }
        public void Circle(object Sender, PaintEventArgs PEA)
        {
            Pen Pen = new Pen(Color.Black, 8);
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2;
            PEA.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            PEA.Graphics.DrawEllipse(Pen, CenterX, CenterY, CircleSize, CircleSize);
            Pen.Dispose();
        }
        public void Flags(object Sender, PaintEventArgs PEA)
        {
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2;
            for (int i = 0; i < 12; i++)
            {
                double Angle = i * 30;
                double Radians = Math.PI * Angle / 180.0;
                int StartX = CenterX + (int)(Math.Cos(Radians) * (CircleSize / 2 - 20)) + (CircleSize / 2);
                int StartY = CenterY + (int)(Math.Sin(Radians) * (CircleSize / 2 - 20)) + (CircleSize / 2);
                int EndX = CenterX + (int)(Math.Cos(Radians) * (CircleSize / 2 - 10)) + (CircleSize / 2);
                int EndY = CenterY + (int)(Math.Sin(Radians) * (CircleSize / 2 - 10)) + (CircleSize / 2);
                PEA.Graphics.DrawLine(Pens.Black, StartX, StartY, EndX, EndY);
            }
        }
        public void SecArrow(object Sender, PaintEventArgs PEA)
        {
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2 + CircleSize / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2 + CircleSize / 2;
            Pen Pen = new Pen(Color.Red, 2);
            DateTime DT = DateTime.Now;
            double SecAngle = (DT.Second * 360.0 / 60.0) - 90;
            double SecRadians = Math.PI * SecAngle / 180.0;
            int SecEndX = CenterX + (int)(Math.Cos(SecRadians) * (CircleSize / 2 - 40));
            int SecEndY = CenterY + (int)(Math.Sin(SecRadians) * (CircleSize / 2 - 40));
            PEA.Graphics.DrawLine(Pen, CenterX, CenterY, SecEndX, SecEndY);
            Pen.Dispose();
        }
        public void MinArrow(object Sender, PaintEventArgs PEA)
        {
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2 + CircleSize / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2 + CircleSize / 2;
            DateTime DT = DateTime.Now;
            Pen Pen = new Pen(Color.Blue, 4);
            double MinAngle = (DT.Minute * 360.0 / 60.0) - 90;
            double MinRadians = Math.PI * MinAngle / 180.0;
            int MinEndX = CenterX + (int)(Math.Cos(MinRadians) * (CircleSize / 2 - 60));
            int MinEndY = CenterY + (int)(Math.Sin(MinRadians) * (CircleSize / 2 - 60));
            PEA.Graphics.DrawLine(Pen, CenterX, CenterY, MinEndX, MinEndY);
            Pen.Dispose();
        }
        public void HourArrow(object Sender, PaintEventArgs PEA)
        {
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2 + CircleSize / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2 + CircleSize / 2;
            DateTime DT = DateTime.Now;
            Pen Pen = new Pen(Color.Black, 8);
            double HourAngle = (DT.Hour * 360.0 / 12.0 + (DT.Minute / 60.0) * (360.0 / 12.0)) - 90;
            double HourRadians = Math.PI * HourAngle / 180.0;
            int HourEndX = CenterX + (int)(Math.Cos(HourRadians) * (CircleSize / 2 - 80));
            int HourEndY = CenterY + (int)(Math.Sin(HourRadians) * (CircleSize / 2 - 80));
            PEA.Graphics.DrawLine(Pen, CenterX, CenterY, HourEndX, HourEndY);
            Pen.Dispose();
        }
        public void Point(object Sender, PaintEventArgs PEA)
        {
            int CircleSize = 400;
            int CenterX = (this.ClientSize.Width - CircleSize) / 2;
            int CenterY = (this.ClientSize.Height - CircleSize) / 2;
            int PointSize = 32;
            int PointX = CenterX + CircleSize / 2 - PointSize / 2;
            int PointY = CenterY + CircleSize / 2 - PointSize / 2;
            PEA.Graphics.FillEllipse(Brushes.Black, PointX, PointY, PointSize, PointSize);
        }
    }
}






