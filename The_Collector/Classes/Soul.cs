using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Collector.Classes {

    class Soul {

        //Atributos de la clase. 
        private int identificator;
        private int coordX;
        private int coordY;
        private bool obtained;

        public Soul() { }

        //Getters
        public int Getidentificator() {
            return this.identificator;
        }

        public int GetcoordX() {
            return this.coordX;
        }

        public int GetCoordY() {
            return this.coordY;
        }

        public bool GetObteained() {
            return this.obtained;
        }

        //Setters
        public void SetIdentificator(int identificator) {
            this.identificator = identificator;
        }

        public void SetCoordX(int coordX) {
            this.coordX = coordX;
        }

        public void SetCoordY(int coordY) {
            this.coordY = coordY;
        }

        public void SetObtained(bool obtained){
            this.obtained = obtained;
        }
    }
}
