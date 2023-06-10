using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Shield_MDM.TestGraphicForm;

namespace Shield_MDM
{
    public partial class Raschet : Form
    {
        private int scale;
        private int wrkX;
        private List<MatrixStates> matrixStates;

        public int ButX { get; set; }
        public int ButY { get; set; }
        public string ButName { get; set; }

        public Raschet(int scale, int wrkX, List<MatrixStates> matrixStates)
        {
            InitializeComponent();
            this.scale = scale;
            this.wrkX = wrkX;
            this.matrixStates = matrixStates;
        }

        private void Raschet_Load(object sender, EventArgs e)
        {
            DrawButtons();
        }

        private void DrawButtons()
        {
            int offset = scale;
            int temp_i = 0;
            //int temp_j = 0;
            for (int j = wrkX; j >= 0; j--)
            {
                for (int i = 1; i <= wrkX; i++)
                {
                    if (matrixStates.Any(x => x.coordinate.X == i && x.coordinate.Y == j))
                    {
                        CreateButton(i * offset, j * offset, /*item.State.ToString()*/ $"{i},{j}", $"btn-{i}-{j}");
                    }
                    //temp_i = 0;
                }
                
            }
        }

        public void CreateButton(int x, int y, string text, string name)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(scale, scale);
            btn.Location = new Point(x, y);
            //btn.Click += evh;
            btn.Name = name;
            btn.BackColor = Color.FromArgb(75, 76, 78);
            btn.ForeColor = Color.FromArgb(255, 255, 255);
            btn.Font = new Font("Century Gothic", 4, FontStyle.Regular);
            btn.Click += new EventHandler(BtnFuncClick);
            this.Controls.Add(btn);
        }

        private void BtnFuncClick(object sender, EventArgs e)
        {
            var str = (sender as Button).Name.Split('-');
            int x = Convert.ToInt32(str[1]);
            int y = Convert.ToInt32(str[2]);
            ButX = x;
            ButY = y;
            ButName = (sender as Button).Name;
            this.Controls.Clear();
            this.DialogResult = DialogResult.OK;
        }
    }
}
