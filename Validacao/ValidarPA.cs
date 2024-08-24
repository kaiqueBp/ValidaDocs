using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarPA
    {
        private string codigo;
        private int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        public ValidarPA(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if (codigo.StartsWith("15") || codigo.StartsWith("75") || codigo.StartsWith("76") || codigo.StartsWith("77") || codigo.StartsWith("78") || codigo.StartsWith("79"))
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
                {
                    resto = 11 - resto;
                    if (resto > 9)
                        resto = 0;
                }
                return codigo.EndsWith(resto.ToString());

            }
            else return false;
        }
    }
}
