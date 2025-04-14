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
    public partial class PrologueText : Form
    {
        public PrologueText()
        {
            InitializeComponent();
            this.label1.Text = Files.Prologue();
        }

        private void button3_Click(object sender, EventArgs e) //Zamknij
        {
            switch (GlobalData.Phase)
            {
                case 1:
                    Phase1 Phase1 = new Phase1();
                    Phase1.Show();
                    this.Close();
                    break;
                case 2: 
                    Phase2 Phase2 = new Phase2();
                    Phase2.Show();
                    this.Close();
                    break;
                case 3:
                    Phase3 Phase3 = new Phase3();
                    Phase3.Show();
                    this.Close();
                    break;
                case 4:
                    if (GlobalData.Difficulty == "easy")
                    {
                        Phase4_easy Phase4 = new Phase4_easy();
                        Phase4.Show();
                        this.Close();
                    }
                    else if (GlobalData.Difficulty == "hard")
                    {
                        Phase4_hard Phase4 = new Phase4_hard();
                        Phase4.Show();
                        this.Close();
                    }
                    break;

                case 5:
                    MessageBox.Show($"To był już ostatni etap, nie ma kolejnego");
                    break;
            }
            this.Close();
        }
    }
}
