using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarDF
    {
        private string codigo;
        private int[] peso1 = new int[11] { 4,3,2,9,8,7,6,5,4,3,2 };
        private int[] peso2 = new int[12] { 5,4,3,2,9,8,7,6,5,4,3,2 };
        private int soma = 0;
        private int resto = 0;
        private string ultimoDigito = "";
        public ValidarDF(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            string tamanhoCodigo = codigo.Substring(0, 11);
            for (int i = 0; i < 11; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso1[i];
            }
            resto = soma % 11;
            resto = 11 - resto;
            if(resto == 10 || resto == 11)
                resto = 0;
            
            ultimoDigito = resto.ToString();
            tamanhoCodigo = tamanhoCodigo + resto.ToString();
            soma = 0;
            resto = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
            }
            resto = soma % 11;
            resto = 11 - resto;
            if(resto == 10 || resto == 11)
                resto = 0;

            ultimoDigito = ultimoDigito + resto.ToString();
            return codigo.EndsWith(ultimoDigito);

        }
    }
}
