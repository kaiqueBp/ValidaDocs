using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarAL
    {
        private string codigo;
        private int[] peso = new int[8] {9,8,7,6,5,4,3,2};
        private int soma = 0;
        private int resto = 0;
        private string digitoFinal = "";
        public ValidarAL(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if(!codigo.StartsWith("24"))
                return false;
            string tamanhoCodigo = this.codigo.Substring(0,8);
            for (int i = 0; i < 8; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            soma = soma * 10;
            resto = soma % 11;

            if (resto == 10)
                resto = 0;
            
            digitoFinal = resto.ToString();
            return codigo.EndsWith(digitoFinal);
        }
    }
}
