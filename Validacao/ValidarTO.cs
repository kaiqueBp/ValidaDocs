using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarTO
    {
        private string codigo;
        private int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        private string digitos = "";
        public ValidarTO(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            digitos = codigo.Substring(2, 2);
            if(digitos == "01" || digitos == "02" || digitos == "03" || digitos == "99")
            {
                string tamanhoCodigo = codigo.Substring(0, 2) + codigo.Substring(4,7);
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

            }else return false;
           
        }
    }
}
