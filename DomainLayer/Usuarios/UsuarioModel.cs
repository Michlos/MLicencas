using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Usuarios
{
    public class UsuarioModel : IUsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public bool Ativo { get; set; }
        public int GrupoId { get; set; }


    }
}
