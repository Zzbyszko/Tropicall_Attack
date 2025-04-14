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
    public partial class Main_menu : Form
    {
        public Main_menu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //przycisk nowa gra
        {
            // Tworzymy instancję nowego okna
            New_game New_game = new New_game();

            // Pokazujemy nowe okno
            New_game.Show();

            // Opcjonalnie zamykamy aktualne okno
            this.Hide(); // Ukrywa MainForm, ale go nie zamyka
            //this.Close(); // Jesli chcesz zamknąć MainForm
        }

        private void Main_menu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //przycisk zakoncz gre
        {
            Application.Exit(); // Kończy działanie aplikacji
        }

        private void button2_Click(object sender, EventArgs e) //przycisk wczytaj gre
        {
            GlobalData.IfLoad = true;
            Files.LoadFromFile();
            switch (GlobalData.Difficulty)
            {
                case "easy":
                    switch (GlobalData.Phase)
                    {
                        case 1:
                            Phase1 Phase1 = new Phase1();
                            Phase1.Show();
                            this.Hide();
                            break;

                        case 2:
                            Phase2 Phase2 = new Phase2();
                            Phase2.Show();
                            this.Hide();
                            break;

                        case 3:
                            Phase3 Phase3 = new Phase3();
                            Phase3.Show();
                            this.Hide();
                            break;

                        case 4:
                            Phase4_easy Phase4 = new Phase4_easy();
                            Phase4.Show();
                            this.Hide();
                            break;

                        default:
                            MessageBox.Show("Wystąpił błąd w pliku zapisu");
                            break;
                    }
                    break;

                case "hard":
                    switch (GlobalData.Phase)
                    {
                        case 1:
                            Phase1 Phase1 = new Phase1();
                            Phase1.Show();
                            this.Hide();
                            break;

                        case 2:
                            Phase2 Phase2 = new Phase2();
                            Phase2.Show();
                            this.Hide();
                            break;

                        case 3:
                            Phase3 Phase3 = new Phase3();
                            Phase3.Show();
                            this.Hide();
                            break;

                        case 4:
                            break;

                        default:
                            MessageBox.Show("Wystąpił błąd w pliku zapisu");
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
