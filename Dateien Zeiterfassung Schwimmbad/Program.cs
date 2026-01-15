namespace Dateien_Zeiterfassung_Schwimmbad;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        decimal dummy = KundenUmsatz("K125", out int lang);
        Console.WriteLine($"{dummy}");
    }

    static decimal KundenUmsatz(string kundenid, out int gesamtdauer)
    {
        string verzeichnis = "C:/DevProjects/csharp/Dateien Zeiterfassung Schwimmbad/Zeiterfassung.txt";
        gesamtdauer = 0;
        
        using (StreamReader sr = new StreamReader(verzeichnis))
        {
            while (!sr.EndOfStream)
            {
                string zeile = sr.ReadLine();
                string[] teile = zeile.Split('\t');
                string zeiterfassungkundenid = teile[0];

             
                if (zeiterfassungkundenid == kundenid && teile.Length >=4)
                {
                    int dauer = 0;
                    string beginn = teile[2];
                    string ende = teile[3];
                    string[] beginnstundenminuten = beginn.Split(':');
                    string[] endestundenminuten = ende.Split(':');
                    int[] beginnzeitgeteilt = { int.Parse(beginnstundenminuten[0]), int.Parse(beginnstundenminuten[1]) };
                    int[] endezeitgeteilt = { int.Parse(endestundenminuten[0]), int.Parse(endestundenminuten[1]) };
                    int beginnzeit = beginnzeitgeteilt[0] * 60 + beginnzeitgeteilt[1];
                    int endezeit = endezeitgeteilt[0] * 60 + endezeitgeteilt[1];
                    //hier wird noch die Dauer/Min berechnet:
                    dauer = endezeit - beginnzeit;
                    gesamtdauer += dauer;
                }
            }
        }
        //hier wird aus der Dauer die Kosten berechnet:Noch nicht korrekt! Angefangene Viertelstunde: 0,40€
        double gesamt = 0;
        gesamt = Math.Ceiling((double)gesamtdauer / 15d);
        decimal kosten;
        kosten = (decimal)gesamt * 0.4m;
        return kosten; 
    }
}
