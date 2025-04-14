using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_JPWP
{
    internal class Files //zawiera metody do odczytu treści zadań i wyników wyborówo oraz zapisu postępu i jego wczytania
    {
        public static string QuestData() //metoda do wczytywania treści zadań
        {

            string filePath; 
            if (GlobalData.Difficulty == "easy")
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QuestsEasy.txt");
            else
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QuestsHard.txt");

            try
            {
                // Odczytanie całej zawartości pliku
                string fileContent = File.ReadAllText(filePath);

                // Wyrażenie regularne do znalezienia numeru zadania 
                string pattern = "";
                switch (GlobalData.QuestNumber)
                {
                    case 11:
                        pattern = @"11(.*?)!";
                        break;
                    case 21:
                        pattern = @"21(.*?)!";
                        break;
                    case 31:
                        pattern = @"31(.*?)!";
                        break;
                    case 12:
                        pattern = @"12(.*?)!";
                        break;
                    case 22:
                        pattern = @"22(.*?)!";
                        break;
                    case 32:
                        pattern = @"32(.*?)!";
                        break;
                    case 13:
                        pattern = @"13(.*?)!";
                        break;
                    case 23:
                        pattern = @"23(.*?)!";
                        break;
                    case 33:
                        pattern = @"33(.*?)!";
                        break;
                    case 14:
                        pattern = @"14(.*?)!";
                        break;
                    case 24:
                        pattern = @"24(.*?)!";
                        break;
                    case 34:
                        pattern = @"34(.*?)!";
                        break;
                    default:
                        break;
                }

                MatchCollection matches = Regex.Matches(fileContent, pattern, RegexOptions.Singleline);

                // Zbieramy wszystkie dopasowania do zmiennej 'result'
                StringBuilder result = new StringBuilder();
                foreach (Match match in matches)
                {
                    // Zachowujemy tekst wraz ze wszystkimi znakami końca linii
                    result.AppendLine(match.Groups[1].Value.Trim());
                }
                return result.ToString().TrimEnd();

            }
            catch (Exception ex)
            {
                //Zwróć kod błędu w wypadku niepowodzenia
                return ex.Message;
            }
        } //koniec QuestData





        public static void SaveToFile() //metoda służąca do zapisu postępu
        {
            // Ścieżka do pliku, w którym zapisujemy dane
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveData.txt");

            try
            {
                // Tworzymy StreamWriter do zapisu danych do pliku
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Zapisujemy zmienne Difficulty oraz Phase
                    writer.WriteLine($"Difficulty: {GlobalData.Difficulty}");
                    writer.WriteLine($"Phase: {GlobalData.Phase}");
                    writer.WriteLine($"Funds: {GlobalData.Funds}");

                    // Zapisujemy tablicę Save
                    writer.WriteLine("Save Data:");
                    for (int i = 0; i < GlobalData.Save.GetLength(0); i++) // iteracja po wierszach
                    {
                        for (int j = 0; j < GlobalData.Save.GetLength(1); j++) // iteracja po kolumnach
                        {
                            writer.Write(GlobalData.Save[i, j] + " "); // zapisanie wartości z tablicy
                        }
                        writer.WriteLine(); // nowa linia po każdym wierszu
                    }

                    //zapisujemy stan przycisków zadań
                    for (int i = 0; i < GlobalData.Buttons.GetLength(0); i++)
                    {
                        if (GlobalData.Buttons[i] == true)
                            writer.WriteLine($"Stan przycisku {i + 1}: true");
                        else
                            writer.WriteLine($"Stan przycisku {i + 1}: false");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisu: {ex.Message}");
            }
        } //koniec SaveToFile



        public static void LoadFromFile()
        {
            // Ścieżka do pliku, z którego wczytujemy dane
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveData.txt");
            int X = 0;

            try
            {
                // Sprawdź, czy plik istnieje
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Nie posiadasz jeszcze pliku zapisu gry. Spróbuj włączyć nową grę");
                    return;
                }

                // Odczytujemy wszystkie linie z pliku
                string[] lines = File.ReadAllLines(filePath);

                // Parsowanie danych z pliku
                foreach (string line in lines)
                {
                    if (line.StartsWith("Difficulty:"))
                    {
                        // Odczytanie poziomu trudności
                        GlobalData.Difficulty = line.Substring("Difficulty:".Length).Trim();
                    }
                    else if (line.StartsWith("Phase:"))
                    {
                        // Odczytanie etapu
                        if (int.TryParse(line.Substring("Phase:".Length).Trim(), out int phase))
                        {
                            GlobalData.Phase = phase;
                        }
                    }
                    else if(line.StartsWith("Funds:"))
                    {
                        //Odczytanie funduszy
                        if (int.TryParse(line.Substring("Funds:".Length).Trim(), out int funds))
                        {
                            GlobalData.Funds = funds;
                        }
                    }
                    else if (line.StartsWith("Save Data:"))
                    {
                        // Odczytanie danych tablicy Save
                        int row = 0;
                        for (int i = Array.IndexOf(lines, line) + 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int col = 0; col < values.Length; col++)
                            {
                                if (int.TryParse(values[col], out int value))
                                {
                                    GlobalData.Save[row, col] = value;
                                }
                            }
                            row++;
                            if (row >= GlobalData.Save.GetLength(0)) break; // Zapobiega przepełnieniu
                        }
                    }
                    else if (line.StartsWith("Stan przycisku"))
                    {
                        string A = "";
                        A = line.Substring("Stan przycisku X:".Length).Trim();
                        if (A == "false")
                            GlobalData.Buttons[X] = false;
                        else 
                            GlobalData.Buttons[X] = true;
                        X++;

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wczytywania danych: {ex.Message}");
            }
        } //koniec LoadFromFile



        public static string Result1 { get; private set; }
        public static string Result2 { get; private set; }
        public static string Result3 { get; private set; }

        public static void Results() //metoda do wczytywania wyników wyborów z pliku
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results.txt");

            try
            {
                // Odczytanie całej zawartości pliku
                string fileContent = File.ReadAllText(filePath);

                // Wzorce dla każdego ciągu
                string pattern1 = "";
                string pattern2 = "";
                string pattern3 = "";

                //trzeba dobrać wzorzec do podjętej decyzji
                //jako że każdy etap ma 3 zadania to potrzeba 3 wzorców
                switch (GlobalData.Save[GlobalData.Phase - 1,0]) //dla zadania 1
                {
                    case 0: //przypadek gdy nie podjęto decyzji w zadaniu
                        break;
                    case 1: //przypadek gdy wybrano opcję A
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern1 = @"11A(.*?)!";
                                break;
                            case 2:
                                pattern1 = @"12A(.*?)!";
                                break;
                            case 3:
                                pattern1 = @"13A(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern1 = @"Ez14A(.*?)!";
                                else 
                                    pattern1 = @"Hd14A(.*?)!";
                                break;
                        }
                        break;
                    case 2: //przypadek opcji B
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern1 = @"11B(.*?)!";
                                break;
                            case 2:
                                pattern1 = @"12B(.*?)!";
                                break;
                            case 3:
                                pattern1 = @"13B(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern1 = @"Ez14B(.*?)!";
                                else
                                    pattern1 = @"Hd14B(.*?)!";
                                break;
                        }
                        break;
                    default:
                        break;
                }

                switch (GlobalData.Save[GlobalData.Phase - 1, 1]) //dla zadania 2
                {
                    case 0: //przypadek gdy nie podjęto decyzji w zadaniu
                        break;
                    case 1: //przypadek gdy wybrano opcję A
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern2 = @"21A(.*?)!";
                                break;
                            case 2:
                                pattern2 = @"22A(.*?)!";
                                break;
                            case 3:
                                pattern2 = @"23A(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern2 = @"Ez24A(.*?)!";
                                else
                                    pattern2 = @"Hd24A(.*?)!";
                                break;
                        }
                        break;
                    case 2: //przypade opcji B
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern2 = @"21B(.*?)!";
                                break;
                            case 2:
                                pattern2 = @"22B(.*?)!";
                                break;
                            case 3:
                                pattern2 = @"23B(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern2 = @"Ez24B(.*?)!";
                                else
                                    pattern2 = @"Hd24B(.*?)!";
                                break;
                        }
                        break;
                    default:
                        break;
                }

                switch (GlobalData.Save[GlobalData.Phase - 1, 2]) //dla zadania 3
                {
                    case 0: //przypadek gdy nie podjęto decyzji w zadaniu
                        break;
                    case 1: //przypadek gdy wybrano opcję A
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern3 = @"31A(.*?)!";
                                break;
                            case 2:
                                pattern3 = @"32A(.*?)!";
                                break;
                            case 3:
                                pattern3 = @"33A(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern3 = @"Ez34A(.*?)!";
                                else
                                    pattern3 = @"Hd34A(.*?)!";
                                break;
                        }
                        break;
                    case 2: //przypade opcji B
                        switch (GlobalData.Phase) //trzeba dobrać odpowiedni etap
                        {
                            case 1:
                                pattern3 = @"31B(.*?)!";
                                break;
                            case 2:
                                pattern3 = @"32B(.*?)!";
                                break;
                            case 3:
                                pattern3 = @"33B(.*?)!";
                                break;
                            case 4:
                                if (GlobalData.Difficulty == "easy")
                                    pattern3 = @"Ez34B(.*?)!";
                                else
                                    pattern3 = @"Hd34B(.*?)!";
                                break;
                        }
                        break;
                    default:
                        break;
                }


                // Dopasuj zawartość dla każdej zmiennej
                Match match1 = Regex.Match(fileContent, pattern1, RegexOptions.Singleline);
                Match match2 = Regex.Match(fileContent, pattern2, RegexOptions.Singleline);
                Match match3 = Regex.Match(fileContent, pattern3, RegexOptions.Singleline);

                // Przypisz wartości do zmiennych, jeśli znaleziono dopasowanie
                Result1 = match1.Success ? match1.Groups[1].Value.Trim() : string.Empty;
                Result2 = match2.Success ? match2.Groups[1].Value.Trim() : string.Empty;
                Result3 = match3.Success ? match3.Groups[1].Value.Trim() : string.Empty;

            }
            catch (Exception ex)
            {
                //Zwróć kod błędu w wypadku niepowodzenia
                Console.WriteLine($"Wystąpił błąd podczas wczytywania danych: {ex.Message}");
            }
        } //koniec Results

        public static string Prologue() //metoda do wyświetlania wstępu do danego etapu
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Prologue.txt");

            try
            {
                // Odczytanie całej zawartości pliku
                string fileContent = File.ReadAllText(filePath);

                string pattern = "";
                switch (GlobalData.Phase)
                {
                    case 1:
                        pattern = @"1(.*?)!";
                        break;
                    case 2:
                        pattern = @"2(.*?)!";
                        break;
                    case 3:
                        pattern = @"3(.*?)!";
                        break;
                    case 4:
                        if (GlobalData.Difficulty == "easy")
                            pattern = @"E4(.*?)!";
                        else
                            pattern = @"H4(.*?)!";
                        break;
                    default:
                        break;
                }

                MatchCollection matches = Regex.Matches(fileContent, pattern, RegexOptions.Singleline);

                // Zbieramy wszystkie dopasowania do zmiennej 'result'
                StringBuilder result = new StringBuilder();
                foreach (Match match in matches)
                {
                    // Zachowujemy tekst wraz ze wszystkimi znakami końca linii
                    result.AppendLine(match.Groups[1].Value.Trim());
                }
                return result.ToString().TrimEnd();
            }
            catch (Exception ex)
            {
                //Zwróć kod błędu w wypadku niepowodzenia
                return ex.Message;
            }
        } //koniec Prologue
    }
}
