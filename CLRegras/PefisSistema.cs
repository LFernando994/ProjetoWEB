using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class PefisSistema
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public bool Inclusao { get; set; }
        public bool Pesquisa { get; set; }
        public bool Exclusao { get; set; }

        public List<TelasSistema> GetTelasSistema { get; set; }
    }
}
