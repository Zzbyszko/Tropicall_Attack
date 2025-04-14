using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_JPWP
{
    public partial class Recap : Form
    {
        public Recap()
        {
            InitializeComponent();
            Files.Results();
            GlobalData.Passed = false;
            GlobalData.IfPassed();
            if (GlobalData.Passed == false || GlobalData.Phase >= 4)
            {
                this.button2.Enabled = false;
                this.label1.Text = "Etap " + GlobalData.Phase + " można podsumować następująco: " + "\n" + Files.Result1
                + "\n" + Files.Result2 + "\n" + Files.Result3 + "\n" + "Czyli mówiąc w skrócie: "
                + "\n" + GlobalData.Allowed;
            }
            else
            {
                this.label1.Text = "Etap " + GlobalData.Phase + " można podsumować następująco: " + "\n" + Files.Result1
                + "\n" + Files.Result2 + "\n" + Files.Result3 + "\n" + "Czyli mówiąc w skrócie: "
                + "\n" + GlobalData.Allowed;
            }  
            
        }

        private void button1_Click(object sender, EventArgs e) //przycisk powrotu do Menu
        {
            Main_menu Main_menu = new Main_menu();
            Main_menu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //przycisk przejścia dalej
        {
            GlobalData.Phase += 1;
            PrologueText Prologue = new PrologueText();
            Prologue.Show();

            this.Close();
        }
    }
}
