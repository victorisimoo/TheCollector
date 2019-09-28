using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Collector.Scenes
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e) { 
            System.Diagnostics.Process.Start("http://www.linkedin.com/in/victooorisimo"); 
        }

        private void label1_Click(object sender, EventArgs e){
            System.Diagnostics.Process.Start("https://twitter.com/victooorisimo");
        }

        private void label5_Click(object sender, EventArgs e){
            System.Diagnostics.Process.Start("https://github.com/victooorisimo");
        }

        private void label14_Click(object sender, EventArgs e){
            this.Hide();
            HomeForm home = new HomeForm();
            home.ShowDialog();
        }
    }
}
