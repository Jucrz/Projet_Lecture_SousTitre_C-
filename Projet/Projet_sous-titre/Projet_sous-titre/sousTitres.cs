using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Projet_sous_titre
{
    class sousTitres
    {
        public string Ligne;
        public string Temps;
        public string Text;
        public sousTitres(string ligne, string temps, string text)
        {
            Ligne = ligne;
            Temps = temps;
            Text = text;
        }
    }
}

