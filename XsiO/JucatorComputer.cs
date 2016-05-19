using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsiO
{
    public class JucatorComputer : IJucator
    {

        private string nume = "Computer";

        public string Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public void incepeRandul(Tabla f1)
        {
            // seteaza ceva? 

            //
            faMutare(f1);
        }

        public void faMutare(Tabla f1)
        {
            f1.contor++;

            Random rnd = new Random();
            int nrRandom = rnd.Next(0, 9);  // alege un numar intreg in intervalul [0,9)  
            Button b = (Button)f1.groupBox1.Controls[nrRandom];
            while (b.Enabled == false)
            {
                nrRandom = rnd.Next(0, 9);
                b = (Button)f1.groupBox1.Controls[nrRandom];
            }

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
                f1.notificaObservatorii();
                MessageBox.Show("Felicitari jucatorule " + ((f1.turn) ? "X" : "O") + ", ai castigat!");
                f1.reseteazaJoc();

            }
            else if (f1.contor == 9)
            {
                MessageBox.Show("Remiza!");
                f1.reseteazaJoc();
            }
            else
            {
                f1.turn = !f1.turn;
            }
        }
    }
}
