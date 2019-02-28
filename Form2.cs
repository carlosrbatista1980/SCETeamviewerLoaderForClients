using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCETeamviewerLoaderForClients
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Interval = 400;
            timer1.Start();
            timer1.Tick += Splash;
        }
        Form1 frm1 = new Form1();
        private void Splash(object sender, EventArgs e)
        {
            
            if (progressBar1.Value < 99)
            {
                progressBar1.Value += 3;
                Application.DoEvents();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                frm1.Show();
                progressBar1.Visible = false;
                Application.DoEvents();
                this.Close();
            }
        }
    }
}
