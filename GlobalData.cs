using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Projekt_JPWP
{
    internal static class GlobalData
    {
        public static int QuestNumber = 0; //zmienna służąca do prowadzenia działań na zadaniach w grze
        public static string Difficulty = ""; //zmienna zapisująca informację o poziomie trudności
        public static int Phase = 0; //zmienna do określenia etapu
        public static int Option = 0; //zmienna do określania wyboru w zadaniu
        public static bool IfLoad = false; //zmienna określająca czy nastąpiło wczytanie gry
        public static int Funds = 0; //fundusze

        //tablica przechowująca informacje o wyborach gracza, wiersze to etapy, kolumny to zadania, liczba: 0 - brak czynności, 1 - opcja A, 2 - opcja B
        public static int[,] Save = {{0, 0, 0},{0, 0, 0},{0, 0, 0},{0, 0, 0}};

        //tablica przechowująca stan przycisków zadań
        public static bool[] Buttons = {true, true, true};

        public static bool Passed = false;
        public static string Allowed = ""; //zmienne potrzebne do uzyskiwania podsumowania po etapie
        public static int Done = 0; //zmienna do blokowania kontroli nad przyciskami


        public static void SaveProgress() //metoda do zapisu wyborów
        {
            int Hp = (QuestNumber / 10) - 1; //zmienna pomocnicza do określania kolumny w tablicy Save
            Save[Phase - 1, Hp] = Option;
        }

        public static void IfPassed()
        {
            //wybory w grze dzielą się na dobre, złe i neutralne
            int Good = 0;
            int Bad = 0;
            int Neutral = 0;

            //szereg warunków do zliczania ilości złych, dobrych i neutralnych decyzji
            if (Phase == 1)
            {
                if (Save[Phase - 1, 0] == 0) //11
                    Bad++;
                else if (Save[Phase - 1, 0] == 1)
                    Neutral++;
                else if (Save[Phase - 1, 0] == 2)
                    Good++;

                if (Save[Phase - 1, 1] == 0) //21
                    Good++;
                else if (Save[Phase - 1, 1] == 1)
                    Neutral++;
                else if (Save[Phase - 1, 1] == 2)
                    Bad++;

                if (Save[Phase - 1, 2] == 0) //31
                    Neutral++;
                else if (Save[Phase - 1, 2] == 1)
                    Bad++;
                else if (Save[Phase - 1, 2] == 2)
                    Good++;

            }
            else if (Phase == 2)
            {
                if (Save[Phase - 1, 0] == 0) //12
                    Bad++;
                else if (Save[Phase - 1, 0] == 1)
                    Good++;
                else if (Save[Phase - 1, 0] == 2)
                    Neutral++;

                if (Save[Phase - 1, 1] == 0) //22
                    Bad++;
                else if (Save[Phase - 1, 1] == 1)
                    Neutral++;
                else if (Save[Phase - 1, 1] == 2)
                    Bad++;

                if (Save[Phase - 1, 2] == 0) //32
                    Neutral++;
                else if (Save[Phase - 1, 2] == 1)
                    Bad++;
                else if (Save[Phase - 1, 2] == 2)
                    Good++;
            }
            else if (Phase == 3)
            {
                if (Save[Phase - 1, 0] == 0) //13
                    Good++;
                else if (Save[Phase - 1, 0] == 1)
                    Neutral++;
                else if (Save[Phase - 1, 0] == 2)
                    Bad++;

                if (Save[Phase - 1, 1] == 0) //23
                    Neutral++;
                else if (Save[Phase - 1, 1] == 1)
                    Bad++;
                else if (Save[Phase - 1, 1] == 2)
                    Good++;

                if (Save[Phase - 1, 2] == 0) //33
                    Bad++;
                else if (Save[Phase - 1, 2] == 1)
                    Good++;
                else if (Save[Phase - 1, 2] == 2)
                    Neutral++;
            }
            else if (Phase == 4)
            {
                if (Save[Phase - 1, 0] == 0) //14
                    Bad++;
                else if (Save[Phase - 1, 0] == 1)
                    Neutral++;
                else if (Save[Phase - 1, 0] == 2)
                    Good++;

                if (Save[Phase - 1, 1] == 0) //24
                    Neutral++;
                else if (Save[Phase - 1, 1] == 1)
                    Bad++;
                else if (Save[Phase - 1, 1] == 2)
                    Good++;

                if (Save[Phase - 1, 2] == 0) //34
                    Neutral++;
                else if (Save[Phase - 1, 2] == 1)
                    Bad++;
                else if (Save[Phase - 1, 2] == 2)
                    Neutral++;
            }

            switch (Difficulty)
            {
                case "easy":
                    if (Good >= Bad || Neutral == 3)
                        Passed = true;
                    break;

                case "hard":
                    if (Good > Bad || Neutral != 3)
                        Passed = true;
                    break;
            }

            if (Passed == true && Phase < 4)
                Allowed = "Udało Ci się przejść do nastepnego etapu";
            else if (Passed == true && Phase >= 4)
                Allowed = "Udało Ci się ukończyć ostatni etap";
            else
                Allowed = "Nie udało Ci się pomyślnie ukończyć etapu";

            Console.WriteLine("G: " + Good);
            Console.WriteLine("B: " + Bad);
            Console.WriteLine("N: " + Neutral);
        } //koniec IfPassed

    }
}
