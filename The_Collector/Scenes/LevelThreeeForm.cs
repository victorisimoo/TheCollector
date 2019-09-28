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

namespace The_Collector.Scenes{

    public partial class LevelThreeeForm : Form {
        //Atributos de la clase. 
        Player player = new Player();
        Random randomGenerate = new Random();
        List<Question> questions = new List<Question>();
        Soul soulOne = new Soul();
        Soul soulTwo = new Soul();
        Soul soulThree = new Soul();
        Soul soulFour = new Soul();
        Soul soulFive = new Soul();
        Soul soulSix = new Soul();
        Soul portal = new Soul();
        Soul badFour = new Soul();
        Soul badOne = new Soul();
        Soul badTwo = new Soul();
        Soul badThree = new Soul();
        private bool left;
        private bool right;
        private bool above;
        private bool down;
        private int coord_x = 37;
        private int coord_y = 85;
        private int seg, min = 0;
        private int countSoul = 0;
        private int pointsUser;
        private int lives = 3;
        public bool answerUser = true;

        //Constructor de la forma.
        public LevelThreeeForm(Player playerRecord, List<Question> questions){
            this.player = playerRecord;
            this.questions = questions;
            InitializeComponent();
            SelecterUser();
            objectSoulGenerate();
            pointsUser = player.GetPointsPlayer();
            lblPoints.Text = Convert.ToString(player.GetPointsPlayer());
            lblLives.Text = Convert.ToString(player.GetLives());

        }

        //Generador de objetos de tipo Soul;
        public void objectSoulGenerate() {
            //Random del usuario.
            player.SetCoordX(xGenerateCoordinate());
            player.SetCoordY(yGenerateCoordinate());
            ptbPlayer.Location = new Point(player.GetCoordX(), player.GetCoordY());

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

            //Denomino número cuatro.
            badFour.SetCoordX(xGenerateCoordinate());
            badFour.SetCoordY(yGenerateCoordinate());
            ptbBadFour.Location = new Point(badFour.GetcoordX(), badFour.GetCoordY());

            //Denomino número uno.
            badOne.SetCoordX(xGenerateCoordinate());
            badOne.SetCoordY(yGenerateCoordinate());
            ptbBadOne.Location = new Point(badFour.GetcoordX(), badFour.GetCoordY());

            //Denomino número dos.
            badTwo.SetCoordX(xGenerateCoordinate());
            badTwo.SetCoordY(yGenerateCoordinate());
            ptbBadTwo.Location = new Point(badTwo.GetcoordX(), badTwo.GetCoordY());

            //Denomino número tres.
            badThree.SetCoordX(xGenerateCoordinate());
            badThree.SetCoordY(yGenerateCoordinate());
            ptbBadThree.Location = new Point(badThree.GetcoordX(), badThree.GetCoordY());

            //Portal 
            portal.SetCoordX(xGenerateCoordinate());
            portal.SetCoordY(yGenerateCoordinate());
            ptbPortal.Location = new Point(portal.GetcoordX(), portal.GetCoordY());
        }

        //Método para determinar la selección del avatar de usuario.
        public void SelecterUser(){
            if (player.GetUserPlayer() == false){
                ptbPlayer.Image = The_Collector.Properties.Resources.frog;
            }else{
                ptbPlayer.Image = The_Collector.Properties.Resources.skeleton;
            }
        }
        
        //Método encargado de obtener el evento de presión de botón.
        private void moveStart(object sender, KeyEventArgs e){
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

        //Método encargado de obtener el evento de despresión de botón.
        private void moveStop(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.A){
                left = false;
            }else if (e.KeyCode == Keys.D){
                right = false;
            }else if (e.KeyCode == Keys.W){
                above = false;
            }else if (e.KeyCode == Keys.S){
                down = false;
            }
        }

        //Método que generará coordenadas para el eje X de las almas y el portal.
        public int xGenerateCoordinate(){
            return randomGenerate.Next(100, 300);
        }

        //Método que generará coordenadas para el eje Y de las almas y el portal.
        public int yGenerateCoordinate(){
            return randomGenerate.Next(100, 391);
        }

        //Método para retornar una pregunta aleatoria.
        public Question GetQuestion(){
            int indx = randomGenerate.Next(0, 14);
            return questions[indx];
        }

        //Método para evaluar si ya fueron obtenidas todas las almas.
        public bool EvaluateRecolection(){
            if (countSoul == 6){
                return true;
            }
            return false;
        }

        //Método para llevar el tiempo de la partida del usuario.
        private void Time_Tick(object sender, EventArgs e){
            if (seg == 61){
                seg = 0;
                min = min + 1;
            }
            seg = seg + 1;
            lblTime.Text = min.ToString() + ":" + seg.ToString();
        }

        //Método creado para llevar el control de la recolleción y los puntos.
        public void CounterForPoints(){
            countSoul = countSoul + 1;
            lblSoul.Text = Convert.ToString(countSoul);
            pointsUser = pointsUser + 15;
            lblPoints.Text = Convert.ToString(pointsUser);
        }

        //Método para cerrar la aplicación.
        private void label9_Click_1(object sender, EventArgs e){
            Application.Exit();
        }

        //Método encargado de capturar el movimiento del usuario.
        private void moveUser_Tick_1(object sender, EventArgs e){
            if (left == true){
                if ((ptbPlayer.Left > 37)){
                    ptbPlayer.Left = ptbPlayer.Left - 1;
                    coord_x = ptbPlayer.Left;
                    player.SetCoordX(coord_x);
                }
            }else if (right == true){
                if ((ptbPlayer.Left < 313)){
                    ptbPlayer.Left = ptbPlayer.Left + 1;
                    coord_x = ptbPlayer.Left;
                    player.SetCoordX(coord_x);
                }
            }else if (above == true){
                if ((ptbPlayer.Location.Y > 85)){
                    ptbPlayer.Location = new Point(ptbPlayer.Location.X, ptbPlayer.Location.Y - 1);
                    coord_y = ptbPlayer.Location.Y;
                    player.SetCoordY(coord_y);
                }
            }else if (down == true){
                if ((ptbPlayer.Location.Y < 391)){
                    ptbPlayer.Location = new Point(ptbPlayer.Location.X, ptbPlayer.Location.Y + 1);
                    coord_y = ptbPlayer.Location.Y;
                    player.SetCoordY(coord_y);
                }
            }
        }

        //Método que controla el movimiento del usuario.
        private void InteractionDetection_Tick_1(object sender, EventArgs e){
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
                if (EvaluateRecolection() == true){
                    player.SetPointsPlayer(pointsUser + 50);
                    moveUser.Enabled = false;
                    moveUser.Stop();
                    InteractionDetection.Enabled = false;
                    InteractionDetection.Stop();
                    this.Hide();
                    LevelFourForm levelFour = new LevelFourForm(this.player, this.questions);
                    levelFour.ShowDialog();
                }else{
                    pointsUser = pointsUser - 5;
                    lblPoints.Text = Convert.ToString(pointsUser);
                    MessageBox.Show("¡Error!", "¡Aún no ha recolectado todas las almas!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbBadFour.Left + ptbBadFour.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (badFour.GetCoordY() + ptbBadFour.Height))){
                ptbBadFour.Visible = false;
                Reaction();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbBadOne.Left + ptbBadOne.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (badOne.GetCoordY() + ptbBadOne.Height))){
                ptbBadOne.Visible = false;
                Reaction();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbBadTwo.Left + ptbBadTwo.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (badTwo.GetCoordY() + ptbBadTwo.Height))){
                ptbBadTwo.Visible = false;
                Reaction();
            }else if (((ptbPlayer.Left + ptbPlayer.Width) == (ptbBadThree.Left + ptbBadThree.Width)) && ((player.GetCoordY() + ptbPlayer.Height) == (badThree.GetCoordY() + ptbBadThree.Height))){
                ptbBadThree.Visible = false;
                Reaction();
            }


        }

        //Métodoo encargado de realizar las preguntas
        public void Reaction(){
            ptbBadFour.Visible = false;
            QuestionForm questionForm = new QuestionForm(GetQuestion());
            questionForm.ShowDialog();
            answerUser = questionForm.GetAnswer();
            if (answerUser == true){
                pointsUser += 10;
                player.SetPointsPlayer(pointsUser);
                lblPoints.Text = Convert.ToString(pointsUser);
                MessageBox.Show("¡Correcto!", "¡Respuesta correcta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else{
                if (player.GetLives() == 0){
                    this.Hide();
                    EndGameForm gameOver = new EndGameForm(this.player);
                    moveUser.Enabled = false;
                    moveUser.Stop();
                    InteractionDetection.Enabled = false;
                    InteractionDetection.Stop();
                    gameOver.ShowDialog();
                }
                pointsUser = pointsUser - 20;
                player.SetPointsPlayer(pointsUser);
                lives = lives - 1;
                player.SetLives(lives);
                moveUser.Enabled = false;
                moveUser.Stop();
                InteractionDetection.Enabled = false;
                InteractionDetection.Stop();
                this.Hide();
                LevelTwoForm levelTwo = new LevelTwoForm(this.player, questions);
                levelTwo.ShowDialog();
            }
        }

        //Método que controla el tiempo del usuario.
        private void Time_Tick_1(object sender, EventArgs e){
            if (seg == 61){
                seg = 0;
                min = min + 1;
            }
            seg = seg + 1;
            lblTime.Text = min.ToString() + ":" + seg.ToString();
        }

        private void LevelThreeeForm_Load(object sender, EventArgs e){

        }
    }
}
