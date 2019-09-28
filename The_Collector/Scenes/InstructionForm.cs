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
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e){
            this.Hide();
            HomeForm home = new HomeForm();
            home.ShowDialog();
        }
    }
}
