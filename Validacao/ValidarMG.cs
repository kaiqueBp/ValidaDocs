using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validacao
{
    internal class ValidarMG
    {
        private string codigo;
        private int[] peso = new int[12] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
        private int[] peso2 = new int[12] { 3, 2, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        private int soma2Digitos = 0;
        private int dezena = 0;
        
        public ValidarMG(string codigo)
        {
            this.codigo = codigo;
        }

        public bool Validar()
        {
            string tamanhoCodigo = codigo.Substring(0, 3) + "0" + codigo.Substring(3, 8);
            for (int i = 0; i < 12; i++)
            {
                int digito = int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
                if (digito > 9)
                {
                    soma2Digitos = digito.ToString().Select(c => int.Parse(c.ToString())).Sum();
                    soma += soma2Digitos;
                }
                else soma += digito;
            }
            dezena = soma + 10 - (soma % 10);
            dezena = dezena - soma;
            tamanhoCodigo = codigo.Substring(0,11) + dezena.ToString();
            soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
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
