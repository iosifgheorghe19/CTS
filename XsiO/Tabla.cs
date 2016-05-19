using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsiO
{
    public partial class Tabla : Form, ISubiect
    {
        private static Tabla instanta = null;

        public static Tabla getInstance()
        {
            if(instanta == null)
                instanta = new Tabla();
            
            return instanta;
        }



        public List<IObserverBtn> listaCasute = new List<IObserverBtn>();

        public IJucator castigator = null; //starea in cadrul patternului Observer.
        private Color culoare = Color.Azure;//starea2  
        public Color Culoare { get { return culoare; } set { culoare = value; } }  


        IJucator jucator = null;
        public bool turn = true;   // true=randul X-ului,  false = rand O
        public int contor = 0; 
        private Tabla()
        {
            InitializeComponent();

            attach(b11);
            attach(b12);
            attach(b13);
                      
            attach(b21);
            attach(b22);
            attach(b23);
                      
            attach(b31);
            attach(b32);
            attach(b33);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Iosif","Mesaj About");
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (jucator is JucatorUman)
            {
                ((JucatorUman) jucator).Sender = sender;
            }
            jucator.faMutare(this);
        }

        public bool avemCastigator()
        {
            bool aCastigat = false;
            //verificari pe linii
            if((b11.Text == b12.Text && b12.Text == b13.Text && b11.Text!="")
                || (b21.Text == b22.Text && b22.Text == b23.Text && b21.Text != "")
                    || (b31.Text == b32.Text && b32.Text == b33.Text && b31.Text != ""))
            {
                aCastigat = true;
            }

            //verificari pe coloane
            if ((b11.Text == b21.Text && b21.Text == b31.Text && b11.Text != "")
                || (b12.Text == b22.Text && b22.Text == b32.Text && b12.Text != "")
                  || (b13.Text == b23.Text && b23.Text == b33.Text && b13.Text != ""))
            {
                aCastigat = true;
            }

            //verificari pe diagonale
            if ((b11.Text == b22.Text && b22.Text == b33.Text && b11.Text != "")
                || (b13.Text == b22.Text && b22.Text == b31.Text && b13.Text != ""))
            {
                aCastigat = true;
            }

            return aCastigat;
        }

        public void reseteazaJoc()
        {
            foreach (Button b in groupBox1.Controls )
            {
                b.Text = "";
                b.Enabled = true;
                b.BackColor = Color.Azure;
            }
            turn = true;
            label2.Text = "X";
            contor = 0;
        }


        public void setJucator(IJucator jucator)
        {
            this.jucator = jucator;
        }

        public void setCastigator(IJucator castigator)
        {
            this.castigator = castigator;
            notificaObservatorii();
        }

        public void notificaObservatorii()
        {
            foreach (var casuta in listaCasute)
            {
                casuta.update();
            }
        }
    
        public void attach(IObserverBtn o)
        {
            listaCasute.Add(o);
        }
        public void detach(IObserverBtn o)
        {
            listaCasute.Remove(o);
        }
        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setJucator(new JucatorComputer());
            reseteazaJoc();
        }

        public void newMultiplayerGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setJucator(new JucatorUman());
            reseteazaJoc();
        }

        //public void oponentTurn()
        //{
        //    contor++;

        //    Random rnd = new Random();
        //    int nrRandom = rnd.Next(0,9);  // alege un numar intreg in intervalul [0,9)  
        //    Button b = (Button)groupBox1.Controls[nrRandom];
        //    while(b.Enabled==false)
        //    {
        //        nrRandom = rnd.Next(0,9);
        //        b = (Button)groupBox1.Controls[nrRandom];
        //    }

        //    b.Enabled = false;
        //    if (turn == true)
        //    {
        //        b.Text = "X";
        //        label2.Text = "O";
        //    }
        //    else
        //    {
        //        b.Text = "O";
        //        label2.Text = "X";
        //    }         


        //    bool aCastigat = avemCastigator();
        //    if (aCastigat)
        //    {
        //        MessageBox.Show("Felicitari jucatorule " + ((turn) ? "X" : "O") + ", ai castigat!");
        //        reseteazaJoc();
        //    }
        //    else if (contor == 9)
        //    {
        //        MessageBox.Show("Remiza!");
        //        reseteazaJoc();
        //    }
        //    else
        //    {
        //        turn = !turn;
        //    }

        //}

    }
}
