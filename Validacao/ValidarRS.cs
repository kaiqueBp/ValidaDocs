using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarRS
    {
        private string codigo;
        private int[] peso = new int[9] { 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        public ValidarRS(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if(codigo.Length != 10)
                return false;

            string tamanhoCodigo = codigo.Substring(0, 9);
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return codigo.EndsWith(resto.ToString());
        }
    }
}
