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
    public partial class SettingsForm : Form
    {
        public void DesignForm()
        {
            this.BackColor = Color.FromArgb(75, 76, 78);
            // Шапка
            label1.BackColor = Color.FromArgb(75, 76, 78);
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            // Условия РРВ
            radioButton1.BackColor = Color.FromArgb(75, 76, 78);
            radioButton1.ForeColor = Color.FromArgb(255, 255, 255);

            radioButton2.BackColor = Color.FromArgb(75, 76, 78);
            radioButton2.ForeColor = Color.FromArgb(255, 255, 255);

            label8.BackColor = Color.FromArgb(75, 76, 78);
            label8.ForeColor = Color.FromArgb(255, 255, 255);

            label9.BackColor = Color.FromArgb(75, 76, 78);
            label9.ForeColor = Color.FromArgb(255, 255, 255);
            // Рабочая зона

            label2.BackColor = Color.FromArgb(75, 76, 78);
            label2.ForeColor = Color.FromArgb(255, 255, 255);

            label3.BackColor = Color.FromArgb(75, 76, 78);
            label3.ForeColor = Color.FromArgb(255, 255, 255);

            label7.BackColor = Color.FromArgb(75, 76, 78);
            label7.ForeColor = Color.FromArgb(255, 255, 255);

            label10.BackColor = Color.FromArgb(75, 76, 78);
            label10.ForeColor = Color.FromArgb(255, 255, 255);
            // зона подавления

            label4.BackColor = Color.FromArgb(75, 76, 78);
            label4.ForeColor = Color.FromArgb(255, 255, 255);

            label5.BackColor = Color.FromArgb(75, 76, 78);
            label5.ForeColor = Color.FromArgb(255, 255, 255);

            label6.BackColor = Color.FromArgb(75, 76, 78);
            label6.ForeColor = Color.FromArgb(255, 255, 255);

            label11.BackColor = Color.FromArgb(75, 76, 78);
            label11.ForeColor = Color.FromArgb(255, 255, 255);

            label12.BackColor = Color.FromArgb(75, 76, 78);
            label12.ForeColor = Color.FromArgb(255, 255, 255);

            label13.BackColor = Color.FromArgb(75, 76, 78);
            label13.ForeColor = Color.FromArgb(255, 255, 255);
            // Расчет
            button1.BackColor = Color.FromArgb(75, 76, 78);
            button1.ForeColor = Color.FromArgb(255, 255, 255);
            // Координаты БС
            label14.BackColor = Color.FromArgb(75, 76, 78);
            label14.ForeColor = Color.FromArgb(255, 255, 255);
            label15.BackColor = Color.FromArgb(75, 76, 78);
            label15.ForeColor = Color.FromArgb(255, 255, 255);
            label16.BackColor = Color.FromArgb(75, 76, 78);
            label16.ForeColor = Color.FromArgb(255, 255, 255);
            label17.BackColor = Color.FromArgb(75, 76, 78);
            label17.ForeColor = Color.FromArgb(255, 255, 255);
            label18.BackColor = Color.FromArgb(75, 76, 78);
            label18.ForeColor = Color.FromArgb(255, 255, 255);
            label19.BackColor = Color.FromArgb(75, 76, 78);
            label19.ForeColor = Color.FromArgb(255, 255, 255);
            label20.BackColor = Color.FromArgb(75, 76, 78);
            label20.ForeColor = Color.FromArgb(255, 255, 255);
            label21.BackColor = Color.FromArgb(75, 76, 78);
            label21.ForeColor = Color.FromArgb(255, 255, 255);
            label22.BackColor = Color.FromArgb(75, 76, 78);
            label22.ForeColor = Color.FromArgb(255, 255, 255);
            label23.BackColor = Color.FromArgb(75, 76, 78);
            label23.ForeColor = Color.FromArgb(255, 255, 255);
            label24.BackColor = Color.FromArgb(75, 76, 78);
            label24.ForeColor = Color.FromArgb(255, 255, 255);

        }
        public SettingsForm()
        {
            InitializeComponent();
            DesignForm();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                MessageBox.Show("Не все поля заполнены");
            else
            {
                if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(textBox1.Text) || Convert.ToInt32(textBox4.Text) > Convert.ToInt32(textBox2.Text) || (Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox5.Text)) > Convert.ToInt32(textBox1.Text) || (Convert.ToInt32(textBox4.Text) + Convert.ToInt32(textBox6.Text)) > Convert.ToInt32(textBox2.Text))
                    MessageBox.Show("Не корректные данные зоны подавления");
                else
                {
                    this.Hide();
                    //MapForm mapForm = new MapForm();
                    ArrayMdm.X = Convert.ToInt32(textBox1.Text) / 100;
                    ArrayMdm.Y = Convert.ToInt32(textBox2.Text) / 100;
                    ArrayMdm.array = new int[ArrayMdm.X, ArrayMdm.Y];
                    GrapficSettings.Height = Convert.ToInt32(Convert.ToDouble(textBox3.Text) / Convert.ToDouble(textBox1.Text) * 1000);
                    GrapficSettings.Width = Convert.ToInt32(Convert.ToDouble(textBox4.Text) / Convert.ToDouble(textBox2.Text) * 1500);
                    GrapficSettings.X = Convert.ToInt32(Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox1.Text) * 1000)+100;
                    GrapficSettings.Y = Convert.ToInt32(Convert.ToDouble(textBox6.Text) / Convert.ToDouble(textBox2.Text) * 1500)+100;
                    //mapForm.Size = new Size(ArrayMdm.X * ButtonSettings.Size + 95, ArrayMdm.Y * ButtonSettings.Size + 100);

                    //mapForm.Show();
                    GrapfikForm grapfikForm = new GrapfikForm();
                    grapfikForm.Show();

                }
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox9.Visible = true;
                textBox10.Visible = true;
                label18.Visible = true;
            }
            else
            {
                textBox9.Visible = false;
                textBox10.Visible = false;
                label18.Visible = false;
            }    
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox11.Visible = true;
                textBox12.Visible = true;
                label20.Visible = true;
            }
            else
            {
                textBox11.Visible = false;
                textBox12.Visible = false;
                label20.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox13.Visible = true;
                textBox14.Visible = true;
                label22.Visible = true;
            }
            else
            {
                textBox13.Visible = false;
                textBox14.Visible = false;
                label22.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox15.Visible = true;
                textBox16.Visible = true;
                label24.Visible = true;
            }
            else
            {
                textBox15.Visible = false;
                textBox16.Visible = false;
                label24.Visible = false;
            }
        }
    }
}
