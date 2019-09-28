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
    public partial class LevelOneForm : Form {

        //Atributos públicos de la clase.
        Player player;
        Soul soulOne = new Soul();
        Soul soulTwo = new Soul();
        Soul soulThree = new Soul();
        Soul soulFour = new Soul();
        Soul soulFive = new Soul();
        Soul soulSix = new Soul();
        Soul portal = new Soul();
        Random randomGenerate = new Random();
        List<Question> questions = new List<Question>();
        private bool left;
        private bool right;
        private bool above;
        private bool down;
        private int[,] levelOne = new int[3, 3];
        private int coord_x = 37;
        private int coord_y = 85;
        private int seg, min = 0;
        private int countSoul = 0;
        private int pointsUser;


        //Constructor de la forma, se recibe el objeto usuario creado.
        public LevelOneForm(Player playerUser, List<Question> questions){
            InitializeComponent();
            this.questions = questions;
            this.player = playerUser;
            SelecterUser();
            lblLives.Text = Convert.ToString(player.GetLives());
            lblPoints.Text = Convert.ToString(player.GetPointsPlayer());
            objectSoulGenerate();
        }

        //Generador de objetos de tipo Soul;
        public void objectSoulGenerate() {
            //Alma número uno.
            soulOne.SetCoordX(xGenerateCoordinate());
            soulOne.SetCoordY(yGenerateCoordinate());
            ptbSoulOne.Location = new Point(soulOne.GetcoordX(), soulOne.GetCoordY());

            //Alma número dos.
            soulTwo.SetCoordX(xGenerateCoordinate());
            soulTwo.SetCoordY(yGenerateCoordinate());
            pbtSoulTwo.Location = new Point(soulTwo.GetcoordX(), soulTwo.GetCoordY());

            //Alma número tres.
            soulThree.SetCoordX(xGenerateCoordinate());
            soulThree.SetCoordY(yGenerateCoordinate());
            pbtSoulThree.Location = new Point(soulThree.GetcoordX(), soulThree.GetCoordY());

            //Alma número cuatro.
            soulFour.SetCoordX(xGenerateCoordinate());
            soulFour.SetCoordY(yGenerateCoordinate());
            pbtSoulFour.Location = new Point(soulFour.GetcoordX(), soulFour.GetCoordY());

            //Alma número cinco.
            soulFive.SetCoordX(xGenerateCoordinate());
            soulFive.SetCoordY(yGenerateCoordinate());
            pbtSoulFive.Location = new Point(soulFive.GetcoordX(), soulFive.GetCoordY());

            //Alma número seis.
            soulSix.SetCoordX(xGenerateCoordinate());
            soulSix.SetCoordY(yGenerateCoordinate());
            pbtSoulSix.Location = new Point(soulSix.GetcoordX(), soulSix.GetCoordY());

            //Portal 
            portal.SetCoordX(xGenerateCoordinate());
            portal.SetCoordY(yGenerateCoordinate());
            ptbPortal.Location = new Point(portal.GetcoordX(), portal.GetCoordY());
        }

        //Método para determinar la selección del usuario.
        public void SelecterUser(){
            if(player.GetUserPlayer() == false){
                ptbPlayer.Image = The_Collector.Properties.Resources.frog;
            } else {
                ptbPlayer.Image = The_Collector.Properties.Resources.skeleton;
            }
        }

        //Método encargado del movimiento del usario con un timer.
        private void moveUser_Tick(object sender, EventArgs e) {
            int actualX = evaluateCoordinateX();
            int actualY = evaluateCoordinateY();

            if(left == true){
                if ((ptbPlayer.Left > 37)){
                    ptbPlayer.Left = ptbPlayer.Left - 1;
                    coord_x = ptbPlayer.Left;
                    player.SetCoordX(coord_x);
                }
            } else if(right == true){
                if ((ptbPlayer.Left < 313)){
                    ptbPlayer.Left = ptbPlayer.Left + 1;
                    coord_x = ptbPlayer.Left;
                    player.SetCoordX(coord_x);
                }
            }else if(above == true){
                if ((ptbPlayer.Location.Y > 85)) {
                    ptbPlayer.Location = new Point(ptbPlayer.Location.X, ptbPlayer.Location.Y - 1);
                    coord_y = ptbPlayer.Location.Y;
                    player.SetCoordY(coord_y);
                }
            } else if(down == true){
                if ((ptbPlayer.Location.Y < 391)){
                    ptbPlayer.Location = new Point(ptbPlayer.Location.X, ptbPlayer.Location.Y + 1);
                    coord_y = ptbPlayer.Location.Y;
                    player.SetCoordY(coord_y);
                }
            }
        }

        //Método que administra la presión de botones para el movimiento. 
        private void createMove(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.A){
                left = true;
            }else if (e.KeyCode == Keys.D){
                right = true;
            }else if (e.KeyCode == Keys.W){
                above = true;
            }else if (e.KeyCode == Keys.S){
                down = true;
            }
        }

        //Método que administra la despresión de los botones que generan el movimiento. 
        private void stopMove(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.A) {
                left = false;
            }else if (e.KeyCode == Keys.D){
                right = false;
            }else if (e.KeyCode == Keys.W){
                above = false;
            }else if (e.KeyCode == Keys.S){
                down = false;
            }
        }

        //Método para evaluar la coordenada x de la matriz en la que se encuentra. 
        public int evaluateCoordinateX(){
            int coordinateX = 0;
            if (coord_x >= 37 && coord_x <= 129){
                coordinateX = 0;
            }else if (coord_x >= 130 && coord_x <= 221){
                coordinateX = 1;
            }else if(coord_x >= 222 && coord_x <= 313){
                coordinateX = 2;
            }
            return coordinateX;
        }

        //Método para evaluar la coordenada y de la matriz en la que se encuentra.
        public int evaluateCoordinateY(){
            int coordinateY = 0;
            if (coord_y >= 85 && coord_y <= 187){
                coordinateY = 0;
            }else if (coord_y >= 188 && coord_y <= 289){
                coordinateY = 1;
            }else if (coord_y >= 230 && coord_y <= 391){
                coordinateY = 2;
            }
            return coordinateY;
        }

        //Método que detiene la ejecución de la aplicación.
        private void label9_Click(object sender, EventArgs e){
            Application.Exit();
        }

        //Método que generará coordenadas para el eje X de las almas y el portal.
        public int xGenerateCoordinate(){
            return randomGenerate.Next(100, 300);
        } 

        //Método que generará coordenadas para el eje Y de las almas y el portal.
        public int yGenerateCoordinate(){
            return randomGenerate.Next(100, 391);
        }

        //Método encargado del timer del juego.
        private void Time_Tick(object sender, EventArgs e){
            if(seg == 61){
                seg = 0;
                min = min + 1;
            }
            seg = seg + 1;
            lblTime.Text = min.ToString() + ":" + seg.ToString();
        }

        //Método para verificar la interacción del jugador y las almas.
        private void InteraccionDetection_Tick(object sender, EventArgs e) {
            if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbSoulOne.Left + ptbSoulOne.Width)) && ((ptbPlayer.Location.Y + ptbPlayer.Height + 4) == (ptbSoulOne.Location.Y + ptbSoulOne.Height)) && ptbSoulOne.Visible != false){
                ptbSoulOne.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (pbtSoulTwo.Left + pbtSoulTwo.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (soulTwo.GetCoordY() + pbtSoulTwo.Height)) && pbtSoulTwo.Visible != false){
                pbtSoulTwo.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (pbtSoulThree.Left + pbtSoulThree.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (soulThree.GetCoordY() + pbtSoulThree.Height)) && pbtSoulThree.Visible != false){
                pbtSoulThree.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (pbtSoulFour.Left + pbtSoulFour.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (soulFour.GetCoordY() + pbtSoulFour.Height)) && pbtSoulFour.Visible != false){
                pbtSoulFour.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (pbtSoulFive.Left + pbtSoulFive.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (soulFive.GetCoordY() + pbtSoulFive.Height)) && pbtSoulFive.Visible != false){
                pbtSoulFive.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (pbtSoulSix.Left + pbtSoulSix.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (soulSix.GetCoordY() + pbtSoulSix.Height)) && pbtSoulSix.Visible != false){
                pbtSoulSix.Visible = false;
                CounterForPoints();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbPortal.Left + ptbPortal.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (portal.GetCoordY() + ptbPortal.Height))){
                Console.WriteLine("Evaluando posición al portal.");
                if (EvaluateRecolection() == true){
                    player.SetPointsPlayer(pointsUser + 50);
                    player.SetLives(3);
                    moveUser.Enabled = false;
                    moveUser.Stop();
                    InteraccionDetection.Enabled = false;
                    InteraccionDetection.Stop();
                    this.Hide();
                    LevelTwoForm levelTwo = new LevelTwoForm(this.player, questions);
                    levelTwo.ShowDialog();
                }
                else{
                    pointsUser = pointsUser - 5;
                    lblPoints.Text = Convert.ToString(pointsUser);
                    MessageBox.Show("¡Error!", "¡Aún no ha recolectado todas las almas!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        //Método creado para llevar el control de la recolleción y los puntos.
        public void CounterForPoints(){
            countSoul = countSoul + 1;
            lblSoul.Text = Convert.ToString(countSoul);
            pointsUser = pointsUser + 15;
            lblPoints.Text = Convert.ToString(pointsUser);
        }

        //Método para evaluar si ya fueron obtenidas todas las almas.
        public bool EvaluateRecolection(){
            if (countSoul == 6){
                return true;
            }
            return false;
        }

        private void LevelOneForm_Load(object sender, EventArgs e){

        }
    }
}