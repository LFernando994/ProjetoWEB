using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public int rg { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(int id, string nome, string cpf, int rg)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
        }
    }
}
