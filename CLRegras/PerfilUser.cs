using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class PerfilUser
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool view { get; set; }
        public bool edit { get; set; }
        public bool create { get; set; }
        public bool delete { get; set; }
    }
}
