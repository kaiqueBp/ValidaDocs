using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarAM
    {
        private string codigo;
        private int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        public ValidarAM(string codigo)
        {
            this.codigo = codigo;
        }

        public bool Validar()
        {
            string tamanhoCodigo = codigo.Substring(0,8);
            for (int i = 0; i < 8; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            if(soma<11)
                resto = 11 - soma;
            else
            {
                resto = soma % 11;
                if (resto <= 1)
                    resto = 0;
                else
                    resto = 11 - resto;
            }
            return codigo.EndsWith(resto.ToString());

        }
    }
}
