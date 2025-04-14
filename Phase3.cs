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
    public partial class Phase3 : Form
    {
        public Phase3()
        {
            InitializeComponent();

            if (GlobalData.IfLoad == false) //jeżeli nie wczytano gry to flagi przycisków muszą być w domyślnym ustawieniu
            {
                GlobalData.Funds = 50000; //na początek gry trzeba zaktualizować fundusze
                for (int i = 0; i < GlobalData.Buttons.GetLength(0); i++)
                {
                    GlobalData.Buttons[i] = true;
                }
                PrologueText Prologue = new PrologueText();
            }
            else if (GlobalData.IfLoad == true) //jeżeli wczytano grę to należy przyciski dostosować do stanu zapisu
            {
                GlobalData.IfLoad = false; //zmiana na false żeby w przyszłych etapach wykonać warunek
                for (int i = 0; i < GlobalData.Buttons.GetLength(0); i++)
                {
                    switch (GlobalData.Buttons[i])
                    {
                        case false:
                            if (i == 0)
                                this.button1.Enabled = false;
                            else if (i == 1)
                                this.button2.Enabled = false;
                            else if (i == 2)
                                this.button3.Enabled = false;
                            break;

                        case true:
                            break;
                    }
                }
            }

            this.label2.Text = GlobalData.Funds.ToString(); //wpisanie funduszy do etykiety
        }

        private void button1_Click(object sender, EventArgs e) //las 13
        {
            //Po pierwszym wybraniu zadania trzeba zablokować możliwość wybrania tego samego zadania ponownie
            this.button1.Enabled = false;
            GlobalData.Buttons[0] = false;
            this.Enabled = false;
            //Otwarcie okna opisującego wybór
            GlobalData.QuestNumber = 13;
            Choice Choice = new Choice();
            Choice.label1.Text = Files.QuestData();
            Choice.ControlEnabled += ControlEnabled;
            Choice.Show();
        }

        private void button2_Click(object sender, EventArgs e) //jezioro 23
        {
            //Po pierwszym wybraniu zadania trzeba zablokować możliwość wybrania tego samego zadania ponownie
            this.button2.Enabled = false;
            GlobalData.Buttons[1] = false;
            this.Enabled = false;
            //Otwarcie okna opisującego wybór
            GlobalData.QuestNumber = 23;
            Choice Choice = new Choice();
            Choice.label1.Text = Files.QuestData();
            //Subskrycja zdarzenia do aktualizacji etykiety
            Choice.FundUpdate += UpdateLabel2;
            Choice.ControlEnabled += ControlEnabled;
            Choice.Show();
        }

        private void button3_Click(object sender, EventArgs e) //ruina 33
        {
            //Po pierwszym wybraniu zadania trzeba zablokować możliwość wybrania tego samego zadania ponownie
            this.button3.Enabled = false;
            GlobalData.Buttons[2] = false;
            this.Enabled = false;
            //Otwarcie okna opisującego wybór
            GlobalData.QuestNumber = 33;
            Choice Choice = new Choice();
            Choice.label1.Text = Files.QuestData();
            //Subskrycja zdarzenia do aktualizacji etykiety
            Choice.FundUpdate += UpdateLabel2;
            Choice.ControlEnabled += ControlEnabled;
            Choice.Show();
        }

        private void button7_Click(object sender, EventArgs e) //następny etap
        {
            Recap Recap = new Recap();
            Recap.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e) //menu główne
        {
            //Zamykamy instancje tego okna i otwieramy okno Menu 
            Main_menu Main_menu = new Main_menu();
            Main_menu.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e) //zapis
        {
            Files.SaveToFile();
            MessageBox.Show($"Zapisano grę");
        }

        public void UpdateLabel2(int value)
        {
            this.label2.Text = value.ToString();
        }

        public void ControlEnabled(int value)
        {
            this.Enabled = true;
        }
    }
}
