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
    public partial class New_game : Form
    {
        public New_game()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) //przycisk powrotu do menu
        {
            // Tworzymy instancje pierwszego okna
            Main_menu Main_menu = new Main_menu();

            // Pokazujemy pierwsze okno
            Main_menu.Show();

            // Zamykamy biezace okno 
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //przycisk Łatwy poziom trudności
        {
            //zapis informacji o poziomie trudności i etapie
            GlobalData.Difficulty = "easy";
            GlobalData.Phase = 1;
            //Instancja 3 okna 
            PrologueText Prologue = new PrologueText();
            Prologue.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e) //przycisk Trudny poziom trudności
        {
            //zapis informacji o poziomie trudności i etapie
            GlobalData.Difficulty = "hard";
            GlobalData.Phase = 1;
            //Instancja 3 okna 
            PrologueText Prologue = new PrologueText();
            Prologue.Show();
            this.Close();
        }

    }
}
