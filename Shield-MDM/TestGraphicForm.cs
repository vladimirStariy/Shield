using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Shield_MDM
{
    public partial class TestGraphicForm : Form
    {
        public TestGraphicForm()
        {
            InitializeComponent();
        }

        // Зона защиты и ее параметры
        ZoneRectangle ZoneRectangle = new ZoneRectangle();

        // Массив ячеек рабочей зоны
        List<MapGridCell> Cells = new List<MapGridCell>();

        DefZone defZone;

        // Отрисовка конкретной ячейки
        private void DrawSingleSquare(Graphics g, int squareScale, PointF startPoint)
        {
            //if(zoneRectangle.StartPoint.X > startPoint.X || zoneRectangle.StartPoint.Y > startPoint.Y)
            //{
            //    MessageBox.Show("БС за пределами зоны защиты");
            //}
            Rectangle rect = new Rectangle((int)startPoint.X * squareScale, (int)startPoint.Y * squareScale, squareScale, squareScale);
            var rectPen = new Pen(Color.Red);
            var rectBrush = new SolidBrush(Color.Aqua);
            g.FillRectangle(rectBrush, rect);
            g.DrawRectangle(rectPen, rect);
        }

        // Отрисовка заливки для конкретной ячейки
        private void DrawSingleZoneFill(Graphics g, int squareScale, PointF startPoint)
        {
            Rectangle rect = new Rectangle((int)startPoint.X * squareScale, (int)startPoint.Y * squareScale, squareScale, squareScale);
            var rectPen = new Pen(Color.Aqua);
            var rectBrush = new SolidBrush(Color.Red);
            g.FillRectangle(rectBrush, rect);
            g.DrawRectangle(rectPen, rect);
        }

        // Отрисовка зоны защиты
        private void DrawZoneRect(Graphics g, int scale, PointF startPoint, int zoneSizeX, int zoneSizeY)
        {
            defZone = new DefZone();
            defZone.startPoint = startPoint;
            defZone.sizeX = zoneSizeX;
            defZone.sizeY = zoneSizeY;
            defZone.DefCells = new List<MapGridCell>();

            for (int x = (int)startPoint.X; x <= defZone.sizeX; x++)
            {
                for (int y = (int)startPoint.Y; y <= defZone.sizeY; y++)
                {
                    defZone.DefCells.Add(new MapGridCell(x,y));
                }
            }

            int sizeX = zoneSizeX * scale;
            int sizeY = zoneSizeY * scale;
            var rectBrush = new SolidBrush(Color.Blue);
            var rectPen = new Pen(Color.Red);
            Rectangle rect = new Rectangle((int)startPoint.X * scale, (int)startPoint.Y * scale, sizeX, sizeY);
            g.FillRectangle(rectBrush, rect);
            g.DrawRectangle(rectPen, rect);
        }

        private void DrawAngle(Graphics g, int scale, PointF startPoint, int sizeX, int sizeY)
        {
            //int sizX = (int)startPoint.X * scale;
            //int sizY = (int)startPoint.Y * scale;

            //PointF[] tempPointX = new PointF[sizX];
            //PointF[] tempPointY = new PointF[sizY];

            //var rectPen = new Pen(Color.Red);
            //var bissPen = new Pen(Color.Blue);

            //startPoint.X *= scale;
            //startPoint.Y *= scale;



            //for(int i = 0; i < 6; i++)
            //{
            //    g.DrawLine(rectPen, startPoint, new PointF(startPoint.X - i * scale, 0));
            //    g.DrawLine(rectPen, startPoint, new PointF(0, i * scale));
            //    Thread.Sleep(3000);
            //}

            //for(int i = 110; i > 0; i--)
            //{
            //    var x = Math.Abs(i - 400);
            //    tempPointX[x].X = i;
            //    tempPointX[x].Y = 400;
            //    g.DrawLines(rectPen, tempPointX);
            //}

            //for (int i = 110; i > 0; i--)
            //{
            //    var x = Math.Abs(i - 110);
            //    tempPointY[x].X = i * scale;
            //    tempPointY[x].Y = sizeY;
            //    g.DrawLines(rectPen, tempPointY);
            //}
        }

        // Отрисовка рабочей зоны
        private void DrawWorkSpace(Graphics g, int scale, int sizeX, int sizeY)
        {
            PointF[] tempPointX = new PointF[sizeX*scale];
            PointF[] tempPointY = new PointF[sizeY*scale];

            var rectBrush = new SolidBrush(Color.Black);

            Cells.Clear();
            for(int x = 0; x < sizeX; x++)
            {
                for(int y = 0; y < sizeY; y++)
                {
                    Cells.Add(new MapGridCell(x, y));
                }
            }

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeX * scale; y++)
                {
                    tempPointX[y].X = y;
                    tempPointX[y].Y = x * scale;
                }
                g.DrawLines(Pens.Gray, tempPointX);
            }

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeY * scale; x++)
                {
                    tempPointY[x].X = y * scale;
                    tempPointY[x].Y = x;
                }
                g.DrawLines(Pens.Gray, tempPointY);
            }
        }

        public void CreateButton(int x, int y, string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(Convert.ToInt32(ScaleBox.Text), Convert.ToInt32(ScaleBox.Text));
            btn.Location = new Point(x, y);
            //btn.Click += evh;
            btn.BackColor = Color.FromArgb(75, 76, 78);
            btn.ForeColor = Color.FromArgb(255, 255, 255);
            btn.Font = new Font("Century Gothic", 6, FontStyle.Regular);

            this.Controls.Add(btn);
        }

        private void DrawSingleGl(Graphics g, int squareScale, PointF startPoint)
        {
            Rectangle rect = new Rectangle((int)startPoint.X * squareScale, (int)startPoint.Y * squareScale, squareScale, squareScale);
            var rectPen = new Pen(Color.Red);
            var rectBrush = new SolidBrush(Color.Green);
            g.FillRectangle(rectBrush, rect);
            g.DrawRectangle(rectPen, rect);
        }

        private void DrawAxis(Graphics g)
        {
            PointF[] pointAxeX = new PointF[GraphicZone.Width];
            PointF[] pointAxeY = new PointF[GraphicZone.Height];

            var AxisPen = new Pen(Color.Green);
            //
            for (int i = 0; i < GraphicZone.Width; i++)
            {
                pointAxeX[i].X = i;
                pointAxeX[i].Y = 1;
            }
            g.DrawLines(AxisPen, pointAxeX);

            for (int i = 0; i < GraphicZone.Height; i++)
            {
                pointAxeY[i].X = 0;
                pointAxeY[i].Y = i;
            }
            g.DrawLines(AxisPen, pointAxeY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int scale = Convert.ToInt32(ScaleBox.Text);

            int size_x = Convert.ToInt32(WrkXBox.Text);
            int size_y = Convert.ToInt32(WrkYBox.Text);

            PointF zonePoint = new PointF(Convert.ToInt32(DefStartPtX.Text), Convert.ToInt32(DefStartPtY.Text));

            Graphics g = GraphicZone.CreateGraphics();
            g.ScaleTransform(1.0f, -1.0f);
            g.TranslateTransform(0.0f, -1.0f * GraphicZone.Height);

            g.Clear(GraphicZone.BackColor);

            
            //CreateButton(0, 25, "asd");
            //for(int i = 0; i < Convert.ToInt32(WrkXBox.Text); i++)
            //{
            //    CreateButton(i+25, i+25, "asd");
            //}

            DrawWorkSpace(g, scale, size_x, size_y);

            DrawZoneRect(g, scale, zonePoint, Convert.ToInt32(DefXBox.Text), Convert.ToInt32(DefYBox.Text));

            DrawSingleSquare(g, scale, new PointF(Convert.ToInt32(BsX.Text), Convert.ToInt32(BsY.Text)));

            DrawSingleGl(g, scale, new PointF(Convert.ToInt32(GlPosBoxX.Text), Convert.ToInt32(GlPosBoxY.Text)));

            DrawAxis(g);

            DrawAngle(g, scale, new PointF(6, 6), 2, 2);

            raschet(Convert.ToInt32(ScaleBox.Text), g);

            
            g.Dispose();
            
            GraphicZone.Visible = false;

            int offset = Convert.ToInt32(ScaleBox.Text);
            for (int i = Convert.ToInt32(WrkXBox.Text); i > 0; i--)
            {
                for (int j = Convert.ToInt32(WrkXBox.Text); j > 0; j--)
                {
                    foreach(var item in matrixStates)
                    {
                        if(item.coordinate.X == i && item.coordinate.Y == j)
                        {
                            CreateButton(GraphicZone.Location.X + i * offset, GraphicZone.Location.Y + j * offset, item.State.ToString());
                        }
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScaleBox.Text = 10.ToString();
            WrkXBox.Text = 10.ToString();
            WrkYBox.Text = 10.ToString();
            DefXBox.Text = 4.ToString();
            DefYBox.Text = 3.ToString();
            DefStartPtX.Text = 3.ToString();
            DefStartPtY.Text = 3.ToString();
            BsX.Text = 2.ToString();
            BsY.Text = 1.ToString();
            GlPosBoxX.Text = 6.ToString();
            GlPosBoxY.Text = 6.ToString();
        }

        public class MatrixStates
        {
            public int State;
            public PointF coordinate;
        }

        public List<MatrixStates> matrixStates = new List<MatrixStates>();
        


        private void raschet(int scale, Graphics g)
        {
            int count = 0;
            for (int i = 0; i < defZone.DefCells.Count; i++)
            {
                // базовая станция
                PointF bs = new PointF(Convert.ToInt32(BsX.Text), Convert.ToInt32(BsY.Text));
                // глушилка
                PointF gl = new PointF(Convert.ToInt32(GlPosBoxX.Text), Convert.ToInt32(GlPosBoxY.Text));

                double rangeKbS = Math.Sqrt(Math.Pow((defZone.DefCells[i].Coordinates.X) - bs.X, 2) + Math.Pow(defZone.DefCells[i].Coordinates.Y - bs.Y, 2));
                double rangeKgL = Math.Sqrt(Math.Pow((defZone.DefCells[i].Coordinates.X) - gl.X, 2) + Math.Pow(defZone.DefCells[i].Coordinates.Y - gl.Y, 2));
                
                if(rangeKbS <= rangeKgL * 0.55d) 
                {
                    DrawSingleZoneFill(g, Convert.ToInt32(ScaleBox.Text), defZone.DefCells[i].Coordinates);
                    count++;
                }
            }
            MatrixStates MS = new MatrixStates()
            {
                State = count,
                coordinate = new PointF(Convert.ToInt32(GlPosBoxX.Text), Convert.ToInt32(GlPosBoxY.Text))
            };
            matrixStates.Add(MS);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
