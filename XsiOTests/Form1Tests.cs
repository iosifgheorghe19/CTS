using NUnit.Framework;
using XsiO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace XsiO.Tests
{
    [TestFixture()]  // test case pt clasa Tabla
    public class Form1Tests
    {
        private Tabla t1 = null;

       [SetUp]
        public void RunBeforeAnyTests()
        {
            t1 = Tabla.getInstance();
        }
        

        [TearDown]
        public void RunAfterAnyTests()
        {
            // Clear up code here.
        }


        [Test()]
        public void test_clickPeCasutaInainteDeNewGame()
        {
            try
            {
                t1.button1_Click(t1.b11, new EventArgs());
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void test_clickPeCasutaDupaNewGame()
        {
            t1.newGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
            try
            {
                t1.button1_Click(t1.b11, new EventArgs());
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void test_clickPeCasutaDupaNewMultiplayerGame()
        {
            t1.newMultiplayerGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
            try
            {
                t1.button1_Click(t1.b11, new EventArgs());
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void test_clickToateCasuteleDupaNewMultiplayerGame()
        {
            t1.newMultiplayerGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
            try
            {
                foreach (var casuta in t1.listaCasute)
                {
                    t1.button1_Click(casuta, new EventArgs());
                }
              
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void test_SinglePlayer_clickPeCasutaB11SiVerificareText()
        {
            try
            {
                t1.newGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
                t1.button1_Click(t1.b11, new EventArgs());
                Assert.IsEmpty(t1.b11.Text.ToString(), "Butonul nu a primit tag-ul jucatorului.");
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test()]
        public void test_SinglePlayer_VictorieSchimbareCuloare()
        {
            
            t1.newGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
            t1.setCastigator(new JucatorUman());
            Assert.AreEqual(t1.b11.BackColor, Color.Aquamarine, "nu a fost schimbata bine culoarea la victorie");
           
        }

        [Test()]
        public void test_Multiplayer_functievictoriePePrimaLinieAvemCa()
        {
            t1.newMultiplayerGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
           
              
                
            t1.button1_Click(t1.b11, new EventArgs());
            t1.button1_Click(t1.b21, new EventArgs());

            t1.button1_Click(t1.b12, new EventArgs());
            t1.button1_Click(t1.b22, new EventArgs());

            t1.button1_Click(t1.b13, new EventArgs());
         
            Assert.IsTrue(t1.avemCastigator(), "Metoda care verifica daca avem castigator nu a functionat" +
                                               "in cazul victoriei pe linie");
        }

        [Test()]
        public void test_Multiplayer_castigatorUpdatatvictoriePePrimaLinie()
        {
            t1.newMultiplayerGameToolStripMenuItem_Click(t1.newGameToolStripMenuItem, new EventArgs());
            t1.button1_Click(t1.b11, new EventArgs());
            t1.button1_Click(t1.b21, new EventArgs());
            t1.button1_Click(t1.b12, new EventArgs());
            t1.button1_Click(t1.b22, new EventArgs());
            t1.button1_Click(t1.b13, new EventArgs());

            Assert.IsNotNull(t1.castigator, "Dupa Victoria unui jucator, castigatorul nu a fost updatat corespunzator.");
        }
    }




    public class TestSuiteul
    {
        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(new Form1Tests());  // integrare totala
                //suite.Add(new RemoveAll());
                return suite;
            }
        }
    }
}