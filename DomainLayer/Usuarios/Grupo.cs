using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Usuarios
{
    public class Grupo : IGrupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Classe { get; set; }
    }
}
