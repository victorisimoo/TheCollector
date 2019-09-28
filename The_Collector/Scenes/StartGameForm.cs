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

    public partial class StartGameForm : Form {

        Player player = new Player();
        List<Question> question = new List<Question>();


        public StartGameForm(){
            InitializeComponent();
            AddQuestion();
        }

        //Método que agrega las preguntas al arreglo de preguntas.
        public void AddQuestion(){
            Question question1 = new Question("¿Cual es el lugar mas frio de la tierra?","Antartida","Xela","Alasca","Everest");
            question.Add(question1);
            Question question2 = new Question("¿Como se llama la capital de mongolia?", "Ulan Bator", "Kabúl", "Andorra", "Angola");
            question.Add(question2);
            Question question3 = new Question("¿Cual es el rio mas largo del mundo?", "Amazonas", "Nilo", "Paz", "Ganges");
            question.Add(question3);
            Question question4 = new Question("¿Donde se originaron los juegos olimpicos?", "Grecia", "China", "Japón", "Roma");
            question.Add(question4);
            Question question5 = new Question("¿Que tipo de animal es la ballena?", "Mamifero", "Viviparo", "Reptíl", "Hervivoro");
            question.Add(question5);
            Question question6 = new Question("¿Que cantida de huesos tiene el cuerpo?", "206", "150", "300", "208");
            question.Add(question6);
            Question question7 = new Question("¿Quien es el autor de El Quijote?", "Miguel Cervantes", "Miguel Angel Asturias", "Sancho Panza", "Gabriel Garcia Marquez");
            question.Add(question7);
            Question question8 = new Question("¿Quien pinto la ultima cena?", "Leonardo Da Vinci", "Miguel Angel", "Picasso", "Frida Kalho");
            question.Add(question8);
            Question question9 = new Question("¿En que pais se encuentra la Torre de Pisa?", "Italia", "Grecia", "Francia", "Barcelona");
            question.Add(question9);
            Question question10 = new Question("¿Como se denomina el resultado de la multiplicacion?", "Producto", "Reciduo", "Cociente", "Resultado");
            question.Add(question10);
            Question question11 = new Question("¿Cual es el producto mas vendido en Guatemala?", "Cafe", "Banano", "Frijol", "Mango");
            question.Add(question11);
            Question question12 = new Question("¿Cual es el pais mas grande del mundo?", "Rusia", "China", "Corea", "Estados Unidos");
            question.Add(question12);
            Question question13 = new Question("¿Cual es el 3 planeta del sistema solar?", "Tierra", "Mercurio", "Venus", "Marte");
            question.Add(question13);
            Question question14 = new Question("¿Cual es el animal mas rapido del mundo?", "Guepardo", "Tigre", "Correcaminos", "Puma");
            question.Add(question14);
            Question question15 = new Question("¿Cual es el primer metal usuado por el ser humano?", "Cobre", "Hierro", "Aluminio", "Oro");
            question.Add(question15);
            Question question16 = new Question("¿Cual es el libro sagrado del Islam?", "Coran", "Biblia", "Libro Judio", "Antiguo testamento");
            question.Add(question16);
            Question question17 = new Question("¿Quien gano el mundial de 2014?", "Alemania", "Francia", "Italia", "Marruecos");
            question.Add(question17);
            Question question18 = new Question("¿Quien-escribio-Hamblet?", "Shakespeare", "Turing", "Leonardo", "Aylinne");
            question.Add(question18);
            Question question19 = new Question("¿Cual es el metal mas caro del mundo?", "Rodio", "Oro", "Cobre", "Plata");
            question.Add(question19);
            Question question20 = new Question("¿Quien mata a Thanos en el comic de Infinity War?", "Gamora", "Thor", "Drax", "Ironman");
            question.Add(question20);
        }

        private void StartGameForm_Load(object sender, EventArgs e){

        }

        //Método para la selección del sexo de niña.
        private void lblGirl_Click(object sender, EventArgs e) {
            lblGirl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblBoy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            player.SetSexPlayer(false);
        }

        //Método para la selección del sexo de niño.
        private void lblBoy_Click(object sender, EventArgs e){
            lblBoy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblGirl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            player.SetSexPlayer(true);
        }

        //Método que elige a Frog como avatar. 
        private void ptbFrog_Click(object sender, EventArgs e){
            ptbFrog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ptbSkeleton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            player.SetUserPlayer(false);
        }

        //Método que elige a Esqueleton como avatar. 
        private void ptbSkeleton_Click(object sender, EventArgs e){
            ptbSkeleton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ptbFrog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            player.SetUserPlayer(true);
        }

        //Método que se lanza al seleccionar comenzar el juego.
        private void lblStart_Click(object sender, EventArgs e){
            player.SetNamePlayer(txtNameUser.Text);
            LevelOneForm levelOne = new LevelOneForm(player, question);
            this.Hide();
            levelOne.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e){
            this.Hide();
            HomeForm home = new HomeForm();
            home.ShowDialog();
        }
    }
}
