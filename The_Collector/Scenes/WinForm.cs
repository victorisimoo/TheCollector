using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Collector.Classes;

namespace The_Collector.Scenes {
    public partial class WinForm : Form {

        public WinForm(Player player){
            InitializeComponent();
            lblName.Text = player.GetNamePlayer();
            lblPoints.Text = Convert.ToString(player.GetPointsPlayer());
        }

        private void lblStart_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void WinForm_Load(object sender, EventArgs e){

        }
    }
}
