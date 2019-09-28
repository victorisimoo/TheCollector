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

    public partial class QuestionForm : Form{

        Question question = new Question();
        public bool answer;
        
        public QuestionForm(Question question){
            InitializeComponent();
            this.question = question;
            lblQuestion.Text = question.GetQuestion();
            lblOptionOne.Text = question.GetCorrectAnswer();
            lblOptionTwo.Text = question.GetAnswerTwo();
            lblOptionThree.Text = question.GetAnswerThree();
            lblOptionFour.Text = question.GetAnswerFour();
        }

        private void QuestionForm_Load(object sender, EventArgs e){}

        private void lblOptionOne_Click(object sender, EventArgs e){
            this.Hide();
            answer = true;
        }

        private void lblOptionThree_Click(object sender, EventArgs e){
            EvaluateIncorrect();
        }

        private void lblOptionTwo_Click(object sender, EventArgs e){
            EvaluateIncorrect();
        }

        private void lblOptionFour_Click(object sender, EventArgs e){
            EvaluateIncorrect();
        }

        public void EvaluateIncorrect(){
            this.Hide();
            answer = false;
        }

        public bool GetAnswer(){
            return this.answer;
        }
    }
}
