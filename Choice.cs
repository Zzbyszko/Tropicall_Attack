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
    public delegate void LabelUpdateHandler(int value); // Deklaracja delegat
    public delegate void ControlEnabledHandler(int value);

    public partial class Choice : Form
    {
        // Deklaracja zdarzenia do aktualizowania funduszy
        public event LabelUpdateHandler FundUpdate;
        public event ControlEnabledHandler ControlEnabled; //deklaracja zdarzenia do włączania kontroli


        public Choice()
        {
            InitializeComponent();

            switch (GlobalData.QuestNumber) //sprawdzamy na start czy gracz ma dostatecznie dużo funduszy na wybór każdej opcji
            {
                case 21:
                    if (GlobalData.Funds < 6)
                        NoFunds();
                    break;

                case 31:
                    if (GlobalData.Funds < 5)
                        NoFunds();
                    break;

                case 12:
                    if (GlobalData.Funds < 1500)
                        NoFunds();
                    break;

                case 22:
                    if (GlobalData.Funds < 9000)
                        NoFunds();
                    break;

                case 24:
                    if (GlobalData.Funds < 200000)
                        NoFunds();
                    break;

                case 34:
                    if (GlobalData.Funds < 200000)
                        NoFunds();
                    break;
            }
        }


        private void button3_Click(object sender, EventArgs e) //Wróć
        {
            GlobalData.Option = 0;
            GlobalData.SaveProgress();
            GlobalData.Done = 1;
            this.Close();

            if (ControlEnabled != null)
            {
                ControlEnabled(GlobalData.Done);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Opcja A
        {
            GlobalData.Option = 1;
            GlobalData.SaveProgress();
            GlobalData.Done = 1;
            this.Close();

            //fundusze zmieniają się przy:
            //Fazie 2, zadaniu 12 LUB Fazie 3, zadaniu 23 i 33
            if ( (GlobalData.Phase == 2 && GlobalData.QuestNumber == 12) ||
                (GlobalData.Phase == 3 && (GlobalData.QuestNumber == 23 || GlobalData.QuestNumber == 33)) )
            {
                switch (GlobalData.QuestNumber)
                {
                    case 12:
                        GlobalData.Funds -= 1000;
                        break;

                    case 23:
                        GlobalData.Funds -= 20000;
                        break;

                    case 33:
                        GlobalData.Funds -= 30000;
                        break;
                }
            }

            // Wywołanie zdarzenia z nową wartością funduszy
            if (FundUpdate != null)
            {
                FundUpdate(GlobalData.Funds);
            }

            if (ControlEnabled != null)
            {
                ControlEnabled(GlobalData.Done);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Opcja B
        {
            GlobalData.Option = 2;
            GlobalData.SaveProgress();
            GlobalData.Done = 1;
            this.Close();

            //fundusze zmieniają się przy:
            //Fazie 1, zadaniu 21 i 31 LUB Fazie 2, zadaniu 12 i 22 LUB Fazie 3, zadaniu 23 i 33 LUB Fazie 4, zadaniu 24 i 34
            if ( (GlobalData.Phase == 1 && (GlobalData.QuestNumber == 21 || GlobalData.QuestNumber == 31)) || 
                (GlobalData.Phase == 2 && (GlobalData.QuestNumber == 12 || GlobalData.QuestNumber == 22)) ||
                (GlobalData.Phase == 3 && (GlobalData.QuestNumber == 23 || GlobalData.QuestNumber == 33)) ||
                (GlobalData.Phase == 4 && (GlobalData.QuestNumber == 24 || GlobalData.QuestNumber == 34)))
            {
                switch (GlobalData.QuestNumber)
                {
                    case 21:
                        GlobalData.Funds -= 6;
                        break;

                    case 31:
                        GlobalData.Funds -= 5;
                        break;

                    case 12:
                        GlobalData.Funds -= 1500;
                        break;

                    case 22:
                        GlobalData.Funds -= 9000;
                        break;

                    case 23:
                        GlobalData.Funds -= 10000;
                        break;

                    case 33:
                        GlobalData.Funds -= 5000;
                        break;

                    case 24:
                        GlobalData.Funds -= 200000;
                        break;

                    case 34:
                        GlobalData.Funds -= 200000;
                        break;

                }
            }

            // Wywołanie zdarzenia z nową wartością funduszy
            if (FundUpdate != null)
            {
                FundUpdate(GlobalData.Funds);
            }
            if (ControlEnabled != null)
            {
                ControlEnabled(GlobalData.Done);
            }
        }


        private void NoFunds() //w przypadku braku funduszy należy zablokować wybór
        {
            this.button2.Enabled = false;
            this.button2.Text = "Za mało funduszy na opcję B";
        }

    }
}
