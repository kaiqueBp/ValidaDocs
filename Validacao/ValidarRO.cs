using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarRO
    {
        private string codigo;
        private int[] peso = new int[5] { 6, 5, 4, 3, 2 };
        private int[] peso2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        public ValidarRO(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if (codigo.Length == 9)
            {
                string tamanhoCodigo = codigo.Substring(3,5);
                for (int i = 0; i < 5; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
                }
                resto = soma % 11;
                if (resto == 10 || resto == 11)
                    resto = resto - 10;
                else
                    resto = 11 - resto;

                return codigo.EndsWith(resto.ToString());

            }else if (codigo.Length == 14)
            {
                string tamanhoCodigo = codigo.Substring(0, 13);
                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
                }
                resto = soma % 11;
                if (resto == 10 || resto == 11)
                    resto = resto - 10;
                else
                    resto = 11 - resto;

                return codigo.EndsWith(resto.ToString());
            }
            else return false;
        }
    }
}