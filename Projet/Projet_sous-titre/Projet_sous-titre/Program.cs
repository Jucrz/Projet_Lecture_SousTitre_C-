using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Projet_sous_titre
{
    class Program
    {
        public static Encoding UTF8 { get; }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Srt lecture = new Srt();
            Task t = lecture.LectureSrt("One_Piece.srt"); // Placez votre fichier Srt sur votre bureau et indiquez le ici
            await t;
        }
    }
}
