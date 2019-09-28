using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Collector.Classes {

    public class Player {
        
        private String _namePlayer;
        private bool _sexPlayer;
        private int _pointsPlayer;
        private bool _userPlayer;
        private int coordX;
        private int coordY;
        private int lives = 3;

        public Player() { }

        //Getters
        public String GetNamePlayer(){
            return this._namePlayer;
        }

        public bool GetSexPlayer(){
            return this._sexPlayer;
        }

        public int GetPointsPlayer() {
            return this._pointsPlayer;
        }

        public bool GetUserPlayer(){
            return this._userPlayer;
        }

        public int GetCoordX(){
            return this.coordX;
        }

        public int GetCoordY(){
            return this.coordY;
        }

        public int GetLives(){
            return this.lives;
        }

        //Setters
        public void SetNamePlayer(String namePlayer){
            this._namePlayer = namePlayer;
        }

        public void SetSexPlayer(bool sexPlayer){
            this._sexPlayer = sexPlayer;
        }

        public void SetPointsPlayer(int pointsPlayer){
            this._pointsPlayer = pointsPlayer;
        }

        public void SetUserPlayer(bool userPlayer){
            this._userPlayer = userPlayer;
        }

        public void SetCoordX(int coordX){
            this.coordX = coordX;
        }

        public void SetCoordY(int coordY){
            this.coordY = coordY;
        }

        public void SetLives(int lives){
            this.lives = lives;
        }
    }
}
