using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Validacao
{
    internal class ValidarSP
    {
        private string codigo;
        private int[] peso1 = new int[8] { 1,  3,  4,  5,  6,  7,  8, 10 };
        private int[] peso2 = new int[11] { 3,  2, 10,  9,  8,  7,  6,  5,  4,  3,  2 };
        private int[] peso3 = new int[8] { 1,  3,  4,  5,  6,  7,  8, 10 };
        private int soma = 0;
        private int resto = 0;
        private string ultimoDigito = "";

        public ValidarSP(string codigo)
        {
            this.codigo = codigo;
        }

        public bool Validar()
        {
            if(codigo.Length == 12)
            {
                string tamanhoCodigo = codigo.Substring(0, 8);
                for (int i = 0; i < 8; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso1[i]; 
                }
                resto = soma % 11;
                if (resto == 10 || resto == 11)
                    resto = resto - 10;
                
                tamanhoCodigo = tamanhoCodigo + resto.ToString() + codigo.Substring(9,2);
                soma = 0;
                resto = 0;
                for (int i = 0; i < 11; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
                }
                resto = soma % 11;
                if (resto == 10 || resto == 11)
                    resto = resto - 10;
                tamanhoCodigo += resto.ToString();
                return codigo.Equals(tamanhoCodigo);
            }else if(codigo.Length == 13)
            {
                if(codigo.StartsWith("P") || codigo.StartsWith("p"))
                {
                    string tamanhoCodigo = codigo.Substring(1, 8);
                    ultimoDigito = codigo.Substring(9, 1);
                    for (int i = 0; i < 8; i++)
                    {
                        soma += int.Parse(tamanhoCodigo[i].ToString()) * peso3[i];
                    }
                    resto = soma % 11;
                    if (resto == 10 || resto == 11)
                        resto = resto - 10;
                    return ultimoDigito.Equals(resto.ToString());
                }else return false;
            }else return false;

        }
    }
}
