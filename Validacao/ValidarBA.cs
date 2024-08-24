using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacao
{
    internal class ValidarBA
    {
        private string codigo;
        private int[] peso = new int[6] {7,6,5,4,3,2};
        private int[] peso2 = new int[7] {8,7,6,5,4,3,2};
        private int[] peso9Digitos = new int[7] { 8, 7, 6, 5, 4, 3, 2 };
        private int[] peso9Digitos2 = new int[8] { 9, 8, 7, 6 ,5, 4, 3, 2 };
        private int soma = 0;
        private int resto = 0;
        private string ultimoDigito = "";
        public ValidarBA(string codigo)
        {
            this.codigo = codigo;
        }
        public bool Validar()
        {
            if (codigo.Length == 8)
            {
                return ValidarOitoDigitos();
            }else
                return ValidarNoveDigitos(); 

        }
        // Validar a Inscrição com 8 digitos
        private bool ValidarOitoDigitos()
        {
            string tamanhoCodigo = codigo.Substring(0, 6);
            for (int i = 0; i < 6; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso[i];
            }

            if(tamanhoCodigo.StartsWith("6") || tamanhoCodigo.StartsWith("7") || tamanhoCodigo.StartsWith("9"))
            {

                resto = soma % 11;
                if (resto == 0 || resto == 1)
                {
                    resto = 0;
                    ultimoDigito = resto.ToString();
                    tamanhoCodigo = tamanhoCodigo + resto.ToString();
                }
                else
                {
                    resto = 11 - resto;
                    ultimoDigito = resto.ToString();
                    tamanhoCodigo = tamanhoCodigo + resto.ToString();
                }
                soma = 0;
                resto = 0;
                for (int i = 0; i < 7; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
                }
                resto = soma % 11;
                resto = 11 - resto;
            }
            else
            {
                resto = soma % 10;
                if (resto == 0)
                {
                    resto = 0;
                    ultimoDigito = resto.ToString();
                    tamanhoCodigo = tamanhoCodigo + resto.ToString();
                }
                else
                {
                    resto = 10 - resto;
                    ultimoDigito = resto.ToString();
                    tamanhoCodigo = tamanhoCodigo + resto.ToString();
                }
                soma = 0;
                resto = 0;
                for (int i = 0; i < 7; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso2[i];
                }
                resto = soma % 10;
                resto = 10 - resto;
            }
           
            ultimoDigito = resto.ToString() + ultimoDigito;
            return codigo.EndsWith(ultimoDigito);
        }
        // Validar a Inscrição com 9 digitos
        private bool ValidarNoveDigitos()
        {
            string tamanhoCodigo = codigo.Substring(0, 7);
            soma = 0 ;
            for (int i = 0; i < 7; i++)
            {
                soma += int.Parse(tamanhoCodigo[i].ToString()) * peso9Digitos[i];
            }
            if(tamanhoCodigo.Substring(1,1) == "6" || tamanhoCodigo.Substring(1, 1) == "7" || tamanhoCodigo.Substring(1, 1) == "9")
            {
                resto = soma % 11;
                if (resto == 0 || resto == 1)
                    resto = 0;
                else
                    resto = 11 - resto;

                ultimoDigito = resto.ToString();
                tamanhoCodigo += ultimoDigito;

                soma = 0 ;
                resto = 0 ;
                for (int i = 0; i < 8; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso9Digitos2[i];
                }
                resto = soma % 11;
                if (resto == 0 || resto == 1)
                    resto = 0;
                else
                    resto = 11 - resto;
                ultimoDigito = resto.ToString() + ultimoDigito;
                return codigo.EndsWith(ultimoDigito);
            }
            else
            {
                resto = soma % 10;
                if (resto == 0 || resto == 1)
                    resto = 0;
                else
                    resto = 10 - resto;

                ultimoDigito = resto.ToString();
                tamanhoCodigo += ultimoDigito;

                soma = 0;
                resto = 0;
                for (int i = 0; i < 8; i++)
                {
                    soma += int.Parse(tamanhoCodigo[i].ToString()) * peso9Digitos2[i];
                }
                resto = soma % 10;
                if (resto == 0 || resto == 1)
                    resto = 0;
                else
                    resto = 10 - resto;
                ultimoDigito = resto.ToString() + ultimoDigito;
                return codigo.EndsWith(ultimoDigito);
            }
        }

    }
}
