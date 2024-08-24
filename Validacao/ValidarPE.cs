using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarPE
    {
        private string codigo;
        private int[] peso1 = new int[7] { 8, 7, 6, 5, 4, 3, 2 };
        private int[] peso2 = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        private string ultimoDigito = "";
        public ValidarPE(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            string tamanhoCodigo = codigo.Substring(0, 7);
            for (int i = 0; i < 7; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso1[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            resto = 11 - resto;

            ultimoDigito = resto.ToString();
            tamanhoCodigo = tamanhoCodigo + resto.ToString();
            soma = 0;
            resto = 0;
            for (int i = 0; i < 8; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            resto = 11 - resto;

            ultimoDigito = ultimoDigito + resto.ToString();
            return codigo.EndsWith(ultimoDigito);
        }
    }
}
