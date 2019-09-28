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

namespace The_Collector.Scenes
{
    public partial class EndGameForm : Form {

        Player player = new Player();

        //Constructor de la forma.
        public EndGameForm(Player playerRecord){
            this.player = playerRecord;
            lblPoints.Text = Convert.ToString(player.GetPointsPlayer());
            InitializeComponent();
        }

        private void EndGameForm_Load(object sender, EventArgs e){

        }

        //Método que cerrará la aplicación.
        private void label1_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void lblStart_Click(object sender, EventArgs e){
            Application.Restart();
        }
    }
}
