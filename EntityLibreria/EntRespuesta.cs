using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibreria
{
    public class EntRespuesta
    {
        public List<EntLibreria> LibrosLista { get; set; }
        public EntLibreria EntLibre { get; set; }
        public List<EntCategoria> ListaCategoria { get; set; }
        public bool Error { get; set; }
        public string Msj { get; set; }
    }
}
