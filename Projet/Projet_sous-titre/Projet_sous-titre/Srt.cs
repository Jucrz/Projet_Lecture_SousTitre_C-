using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Projet_sous_titre
{
    class Srt
    {
        public async Task LectureSrt(string path)
        {
            StockSrt(path);
            Task t = AffichageST();
            await t;
        }

        // Création d'une liste créée a partir du constructeur de sousTitres
        private List<sousTitres> stockage;

        private void StockSrt(string path)
        {
            // Initialisation de la nouvelle liste
            stockage = new List<sousTitres>();

            // Création d'un string qui prend le chemin jusqu'au bureau
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Utilisation du StreamReader pour lire un fichier au chemin précisé dans les arguments du SreamReader
            using (StreamReader sr = new StreamReader(mydocpath + @"\" + path))
            {
                string[] stockageTempo = new string[5];
                int compteurTempo = 0;
                string l = "";
                int i = 2;
                while ((l = sr.ReadLine()) != null)
                {
                    if (i.ToString() == l)
                    {
                        // Ajout dans la liste stockage un nouvel objet comportant les différentes informations de chaque sous titres stocké dans différentes lignes d'un tableau
                        stockage.Add(new sousTitres(stockageTempo[0], stockageTempo[1], stockageTempo[2] + " " + stockageTempo[3]));
                        compteurTempo = 0;
                        i++;
                    }
                    stockageTempo[compteurTempo] = l;
                    compteurTempo++;
                }
            }
        }

        private async Task AffichageST()
        {
            // Initialisation d'un dateTime a 0 pour le temps d'attente avant l'affichage du premier text
            string test = "00:00:00,000";
            DateTime date2 = DateTime.ParseExact(test , "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

            // Boucle qui permet l'affichage des sous titres au bon moment
            for (int i = 0; i < stockage.Count; i++)
            {
                // On split l'attribut temps pour séparer le temps de début et le temps de fin d'un text
                string[] timeur = stockage[i].Temps.Split("-->");

                // Initialisation d'un DateTime pour le début d'apparition d'un text
                DateTime date1 = DateTime.ParseExact(timeur[0].Replace(" ", ""), "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                TimeSpan t = date1.Subtract(date2);
                Console.Clear();

                // Ajout d'un delai entre la fin de l'apparition d'un texte et le début d'un autre
                await Task.Delay(t);
                
                date2 = DateTime.ParseExact(timeur[1].Replace(" ", ""), "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                t = date2.Subtract(date1);
                Console.WriteLine(stockage[i].Text);

                // Ajout d'un delai entre le début d'apparition d'un text et la fin
                await Task.Delay(t);
            }
        }
    }
}
