using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shield_MDM
{
    public partial class GrapfikForm : Form
    {
        public GrapfikForm()
        {
            InitializeComponent();
            new Chart { Parent = this, Dock = DockStyle.Fill };
        }

        private void GrapfikForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Chart : Control
    {
        /// <summary>
        /// Отступы
        /// </summary>
        [DefaultValue(20)]
        public int Indent { get; set; }

        [DefaultValue(5)]
        public float MaxX { get; set; }

        [DefaultValue(-5)]
        public float MinX { get; set; }

        [DefaultValue(5)]
        public float MaxY { get; set; }

        [DefaultValue(-5)]
        public float MinY { get; set; }

        /// <summary>
        /// Шаг сетки
        /// </summary>
        [DefaultValue(1)]
        public float GridStep { get; set; }

        /// <summary>
        /// Отображаемая функция
        /// </summary>
        public Func<double, double> Function;

        public Chart()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Indent = 30;
            MinX = 0;
            MaxX = ArrayMdm.X;
            MinY = 0;
            MaxY = ArrayMdm.Y;
            GridStep = 1;
            Function = (x) => 4 * Math.Sin(x);
        }

        /// <summary>
        /// Область внутри которой будет рисоваться график
        /// </summary>
        private Rectangle ChartArea
        {
            get
            {
                var rect = ClientRectangle;
                rect.Inflate(-Indent, -Indent);
                return rect;
            }

        }

        /// <summary>
        /// Преобразует виртуальные координаты в пикселы
        /// </summary>
        float YToPixels(float y)
        {
            return ChartArea.Height * (y - MinY) / (MaxY - MinY);
        }

        /// <summary>
        /// Преобразует виртуальные координаты в пикселы
        /// </summary>
        float XToPixels(float x)
        {
            return ChartArea.Width * (x - MinX) / (MaxX - MinX);
        }

        /// <summary>
        /// Отрисовка
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var rect = ChartArea;
            var gr = e.Graphics;

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            var center = new PointF(rect.Left + XToPixels(0), rect.Bottom - YToPixels(0));

            //рисуем сетку
            using (var font = new Font(Font.FontFamily, 8f))
            using (var pen = new Pen(Color.FromArgb(50, Color.Navy), 1))
            {
                for (var x = MinX; x <= MaxX; x += GridStep)
                {
                    var absX = rect.Left + XToPixels(x);
                    gr.DrawLine(pen, absX, rect.Bottom, absX, rect.Top);
                    gr.DrawString(x.ToString("0.0"), font, Brushes.Navy, absX - 7, center.Y + 5);
                }

                for (var y = MinY; y <= MaxY; y += GridStep)
                {
                    var absY = rect.Bottom - YToPixels(y);
                    gr.DrawLine(pen, rect.Left, absY, rect.Right + 5, absY);
                    gr.DrawString(y.ToString("0.0"), font, Brushes.Navy, center.X - 25, absY - 5);
                }
            }

            //рисуем оси
            using (var pen = new Pen(Color.Navy, 1))
            {
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                gr.DrawLine(pen, center.X, rect.Bottom, center.X, rect.Top - 30);
                gr.DrawLine(pen, rect.Left, center.Y, rect.Right + 7, center.Y);
            }

            //рисуем функцию
            if (Function != null)
                using (var pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, 30,188,500,500);
                            var step = GridStep / 10;
                            for (var x = MinX; x < MaxX; x += step)
                            {
                                var y1 = (float)Function(x);
                                var y2 = (float)Function(x + step);
                                //e.Graphics.DrawLine(pen, rect.Left + XToPixels(x), rect.Bottom - YToPixels(y1), rect.Left + XToPixels(x + step), rect.Bottom - YToPixels(y2));
                            }
                }

        }
    }
}

