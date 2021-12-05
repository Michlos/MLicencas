using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Usuarios
{
    public class PermissaoModel : IPermissaoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int GrupId { get; set; }
        public int ModuloId { get; set; }
    }
}
