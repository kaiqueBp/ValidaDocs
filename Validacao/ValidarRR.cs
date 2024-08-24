using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarRR
    {
        private string codigo;
        private int[] peso = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private int soma = 0;
        private int resto = 0;
        public ValidarRR(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if(codigo.Length != 9)
                return false;
            string tamanhoCodigo = codigo.Substring(0, 8);
            for (int i = 0; i < 8; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            resto = soma % 9;

            return codigo.EndsWith(resto.ToString());
        }
    }
}
