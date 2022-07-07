using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibreria
{
    public class EntLibreria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Categoria { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public string ISBN { get; set; }
        public EntCategoria EntCategoria { get; set; }
    }
}
