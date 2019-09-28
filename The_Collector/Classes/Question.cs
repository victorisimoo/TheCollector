using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Collector.Classes{
    public class Question {
        //Atributos de la clase.
        private String question;
        private String correctAnswer;
        private String answerTwo;
        private String answerThree;
        private String answerFour;

        public Question() { }

        //Constructor vacío de la clase.
        public Question(String question, String correctAnswer, String answerTwo, String answerThree, String answerFour){
            this.question = question;
            this.correctAnswer = correctAnswer;
            this.answerTwo = answerTwo;
            this.answerThree = answerThree;
            this.answerFour = answerFour;
        }


        //Getters;
        public String GetQuestion(){
            return question;
        }

        public String GetCorrectAnswer(){
            return correctAnswer;
        }

        public String GetAnswerTwo(){
            return answerTwo;
        }

        public String GetAnswerThree(){
            return answerThree;
        }

        public String GetAnswerFour(){
            return answerFour;
        }

    }
}
