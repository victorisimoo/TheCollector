using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Collector.Scenes;

namespace The_Collector {

    public partial class HomeForm : Form {

        private int counterOption = 1;

        public HomeForm(){
            InitializeComponent();
            //SelectionUser.Enabled = true;
            //SelectionUser.Start();
        }

        private void UserPresses(object sender, KeyPressEventArgs e) {

        }

        private void UserReleases(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.W){
                if(counterOption > 4){
                    counterOption = 1;
                } else{
                    counterOption = counterOption + 1;
                }  
            } else if (e.KeyCode == Keys.S) {
                if (counterOption < 1 ){
                    counterOption = 4;
                } else{
                    counterOption = counterOption - 1;
                }
            }
        }

        private void SelectionUser_Tick(object sender, EventArgs e){
            Console.WriteLine(counterOption);
            if (counterOption == 1){
                DisableImage();
                lblSelect1.Visible = true;
            } else if (counterOption == 2){
                DisableImage();
                lblSelect2.Visible = true;
            } else if (counterOption == 3){
                DisableImage();
                lblSelect3.Visible = true;
            } else if (counterOption == 4){
                DisableImage();
                lblSelect4.Visible = true;
            }
        }

        public void DisableImage(){
            lblSelect1.Visible = false;
            lblSelect2.Visible = false;
            lblSelect3.Visible = false;
            lblSelect4.Visible = false;
        }

        private void UserPresses(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.W)
            {
                if (counterOption > 4)
                {
                    counterOption = 1;
                }
                else
                {
                    counterOption = counterOption + 1;
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (counterOption < 1)
                {
                    counterOption = 4;
                }
                else
                {
                    counterOption = counterOption - 1;
                }
            }
        }

        private void lblStartGame_Click(object sender, EventArgs e) {
            this.Hide();
            StartGameForm startGame = new StartGameForm();
            startGame.ShowDialog();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void lblInstructions_Click(object sender, EventArgs e){
            this.Hide();
            InstructionForm instruction = new InstructionForm();
            instruction.ShowDialog();
        }

        private void lblAbout_Click(object sender, EventArgs e) {
            this.Hide();
            AboutUs about = new AboutUs();
            about.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e){
            Application.Exit();
        }
    }
}
