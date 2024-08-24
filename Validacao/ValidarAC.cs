using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validacao
{
    internal class ValidarAC
    {
        private int[] peso = new int[11] { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int[] peso2 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private string codigo;
        private int soma = 0;
        private int resto = 0;
        private string digitoFinal = "";
        public ValidarAC(string codigo)
        {
            this.codigo = codigo;
        }

        public bool Validar()
        {
            string tamanhoCodigo = this.codigo.Substring(0, 11);
            for (int i = 0; i < 11; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            resto = soma % 11;
            resto = 11 - resto;
            if (resto == 10 || resto == 11)
                resto = 0;

            tamanhoCodigo = tamanhoCodigo + resto.ToString();
            digitoFinal = resto.ToString();
            soma = 0;
            resto = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
            }
            resto = soma % 11;
            resto = 11 - resto;
            if (resto == 10 || resto == 11)
                resto = 0;

            digitoFinal = digitoFinal + resto.ToString();
            return codigo.EndsWith(digitoFinal);
        }
    }
}
