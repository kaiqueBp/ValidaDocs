using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarRN
    {
        private string codigo;
        private int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int[] peso2 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        public ValidarRN(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if(!codigo.StartsWith("20"))
                return false;

            if(codigo.Length == 9)
            {
                string tamanhoCodigo = codigo.Substring(0, 8);
                for (int i = 0; i < 8; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
                }
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                return codigo.EndsWith(resto.ToString());

            }else if(codigo.Length == 10)
            {
                string tamanhoCodigo = codigo.Substring(0, 9);
                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
                }
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                return codigo.EndsWith(resto.ToString());

            }else return false;

            
        }
    }
}
