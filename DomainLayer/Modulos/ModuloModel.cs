using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Modulos
{
    public class ModuloModel : IModuloModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public string Ativo { get; set; }

    }
}
