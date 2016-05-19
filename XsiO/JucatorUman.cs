using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsiO
{
    public class JucatorUman : IJucator
    {
        private string nume;

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }


        public object Sender = null;

        public void incepeRandul(Tabla f1)
        {
            
        }

        public void faMutare(Tabla f1)
        {
            f1.contor++;
            Button b = (Button)Sender;
            b.Enabled = false;
            if (f1.turn == true)
             {
                b.Text = "X";
                f1.label2.Text = "O";
            }
            else
            {
                b.Text = "O";
                f1.label2.Text = "X";
            }

            bool aCastigat = f1.avemCastigator();
            if (aCastigat)
            {
                f1.setCastigator(this);
                MessageBox.Show("Felicitari jucatorule " + ((f1.turn) ? "X" : "O") + ", ai castigat!");
               // f1.reseteazaJoc();
            }
            else if (f1.contor == 9)
            {
                MessageBox.Show("Remiza!");
                f1.reseteazaJoc();
            }
            else
            {
                f1.turn = !f1.turn;
               // oponentTurn(); // single/multiplayer
            }
        }
    }
}
