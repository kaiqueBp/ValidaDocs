using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarAP
    {
        private string codigo;
        private int[] peso = new int[8] { 9, 8, 7, 6, 5, 4, 3, 2 };
        private int verifica = 0;
        private int p = 0;
        private int d = 0;
        private int soma = 0;
        private int resto = 0;
        public ValidarAP(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if(!codigo.StartsWith("03"))
                return false;
            string tamanhoCodigo = codigo.Substring(0,8);
            verifica = int.Parse(tamanhoCodigo);
            if (verifica >= 03000001 && verifica <= 03017000)
                p = 5;
            else if (verifica >= 03017000 && verifica <= 03019022)
                p = 9; 
            else if (verifica >= 03019023)
                p = 0;
           
            soma = p;
            for (int i = 0; i < 8; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }
            resto = soma % 11;
            resto = 11 - resto; 
            if(resto == 10)
                resto = 0;
            else if (resto == 11)
                resto = 1;
            return codigo.EndsWith(resto.ToString());
        }
    }
}
