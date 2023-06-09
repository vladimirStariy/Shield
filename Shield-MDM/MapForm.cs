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
    public partial class MapForm : Form
    {
        CreateButtonClass createButton = new CreateButtonClass();
        Button btn;
        public MapForm()
        {
            
            InitializeComponent();
            DesignForm();
            //InitializeMyScrollBar();
        }

        public void InitializeMyScrollBar()
        {
            // Create and initialize a VScrollBar.
            VScrollBar vScrollBar1 = new VScrollBar();

            // Dock the scroll bar to the right side of the form.
            vScrollBar1.Dock = DockStyle.Bottom;

            // Add the scroll bar to the form.
            Controls.Add(vScrollBar1);
        }

        public void DesignForm()
        {
            this.BackColor = Color.FromArgb(75, 76, 78);
            // Шапка
            label1.BackColor = Color.FromArgb(75, 76, 78);
            label1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ArrayMdm.X; i++)
            {
                for (int j = 0; j < ArrayMdm.Y; j++)
                {
                    ArrayMdm.array[i, j] = i + j;
                    createButton.CreateButton(btn, this, i*ButtonSettings.Size+45, j*ButtonSettings.Size+40, ArrayMdm.array[i,j].ToString());
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
