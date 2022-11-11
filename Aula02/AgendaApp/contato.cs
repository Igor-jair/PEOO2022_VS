using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp
{
    class contato
    {
        private string nome, email, fone;
        public contato(string n, string e, string f)
        {
            nome = n;
            email = e;
            fone = f;
        }
        public override string ToString()
        {
            return $"{nome} - {email} - {fone}";
        }
    }
}
