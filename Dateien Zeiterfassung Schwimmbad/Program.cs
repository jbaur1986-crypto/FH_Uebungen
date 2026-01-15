namespace Dateien_Zeiterfassung_Schwimmbad;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    decimal KundenUmsatz(string kundenid, out int dauer)
    {
        string verzeichnis = "C:/DevProjects/csharp/Dateien Zeiterfassung Schwimmbad/Zeiterfassung.txt";
        
        using (StreamReader sr = new StreamReader(verzeichnis))
        {
            while (!sr.EndOfStream)
            {
                string zeile = sr.ReadLine();
                string[] teile = zeile.Split('\t');
                string zeiterfassungkundenid = teile[0];

                dauer = 0;
                if (zeiterfassungkundenid == kundenid && teile[3] != null)
                {
                    string beginn = teile[2];
                    string ende = teile[3];
                    string[] beginnstundenminuten = beginn.Split(':');
                    string[] endestundenminuten = ende.Split(':');
                    int[] beginnzeit = { int.Parse(beginnstundenminuten[0]), int.Parse(beginnstundenminuten[1]) };
                    int[] endezeit = { int.Parse(endestundenminuten[0]), int.Parse(endestundenminuten[1]) };
                    //hier wird noch die Dauer berechnet:
                }
            }
        }
        //hier wird aus der Dauer die Kosten berechnet:
        return //Kosten;
    }
}
