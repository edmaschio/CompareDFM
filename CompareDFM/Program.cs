using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDFM
{
    class Program
    {
        static void Main(string[] args)
        {
            var linhasArquivo = File.ReadLines(@"D:\Dev\Source\VSStudio\CompareDFM\CompareDFM\assets\RAP20801[2016-04-08]_Aprovado.sfm");

            bool SecaoEventos = false;

            var ObjetosDFM = new List<ObjetoDfm>();
            ObjetoDfm Objeto = null; 

            int ids = 0;

            foreach (var linha in linhasArquivo)
            {
                if (!linha.Trim().Equals(""))
                {
                    if (!SecaoEventos)
                    {
                        if (linha.StartsWith("["))
                        {
                            if (linha.Substring(1, 7).Equals("Eventos"))
                                SecaoEventos = true;
                            else {
                                ids++;

                                if (Objeto != null)
                                {
                                    Console.WriteLine(Objeto.ToString());
                                }

                                Objeto = new ObjetoDfm(ids);
                                Objeto.NomeComponente = linha.Replace("[", string.Empty).Replace("]", string.Empty);
                            }
                        } 
                    }
                }
            }

            Console.ReadKey();
        }
    }

    class ObjetoDfm
    {
        public int Id { get; set; }
        public string NomeTipoComponente { get; set; }
        public string NomeComponente { get; set; }
        public IDictionary<string, IEnumerable<string>> Propriedades { get; set; }

        public ObjetoDfm(int id)
        {
            this.Id = id;
            this.Propriedades = new Dictionary<string, IEnumerable<string>>();
        }
    }
}
