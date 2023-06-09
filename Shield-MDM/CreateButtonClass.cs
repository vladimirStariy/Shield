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
    class CreateButtonClass: Button
    {
        public void CreateButton(Button btn, Form form, int x, int y, string text)
        {
            btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            //btn.Click += evh;
            btn.Size = new Size(ButtonSettings.Size, ButtonSettings.Size);
            btn.BackColor = Color.FromArgb(75, 76, 78);
            btn.ForeColor = Color.FromArgb(255, 255, 255);
            btn.Font = new Font("Century Gothic", 6, FontStyle.Regular);

            form.Controls.Add(btn);
        }
    }
}
