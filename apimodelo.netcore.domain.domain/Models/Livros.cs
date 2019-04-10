using System;
using System.Collections.Generic;
using System.Text;

namespace apimodelo.netcore.domain.domain.Models
{
    public class Livros
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int paginas { get; set; }
        public string categoria { get; set; }
        public int nota { get; set; }
        
    }
}
