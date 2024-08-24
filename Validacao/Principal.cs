using DocsBr;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Validacao
{
    [EnableCors("AllowAll")]
    public class Principal : Controller
    {

        public bool ValidarCPF(string cpf)
        {
            int[] calculo1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] calculo2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tamanhoCpf;
            string digito;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            bool validar = cpf.All(c => c == cpf[0]);
            if (validar)
            {
                return false;
            }

            int soma;
            int resto;

            if (cpf.Length != 11)
                return false;

            tamanhoCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tamanhoCpf[i].ToString()) * calculo1[i];
            }

            resto = soma % 11;
            if (resto < 2 || resto == 10)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tamanhoCpf = tamanhoCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tamanhoCpf[i].ToString()) * calculo2[i];
            }

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public bool ValidarCNPJ(string cnpj)
        {
            int[] calculo1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] calculo2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.All(c => c == cnpj[0]))
            {
                return false;
            }

            int soma = 0;
            string tamanhoCnpj;
            int resto;
            string digitoFinal;
            if (cnpj.Length != 14)
            {
                return false;
            }
            tamanhoCnpj = cnpj.Substring(0, 12);
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tamanhoCnpj[i].ToString()) * calculo1[i];
            }
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digitoFinal = resto.ToString();
            tamanhoCnpj = tamanhoCnpj + resto;
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tamanhoCnpj[i].ToString()) * calculo2[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
           
            digitoFinal = digitoFinal + resto.ToString();
            return cnpj.EndsWith(digitoFinal);
        }

        public bool ValidarIE(string codigo, string uf)
        {
            uf = uf.ToUpper();
            codigo = codigo.Trim();
            codigo = codigo.Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ","");
            switch (uf.ToUpper())
            {
                case "AC":
                    ValidarAC validarAC = new ValidarAC(codigo);
                    return validarAC.Validar();
                    
                case "AL":
                    ValidarAL validarAL = new ValidarAL(codigo);
                    return validarAL.Validar();
                   
                case "AP":
                    ValidarAP validarAP = new ValidarAP(codigo);
                    return validarAP.Validar();

                case "AM":
                    ValidarAM validarAM = new ValidarAM(codigo);
                    return validarAM.Validar();

                case "BA":
                    ValidarBA validarBA = new ValidarBA(codigo);
                    return validarBA.Validar();
                    
                case "CE":
                    ValidarCE validarCE = new ValidarCE(codigo);
                    return validarCE.Validar();
                    
                case "DF":
                    ValidarDF validarDF = new ValidarDF(codigo);
                    return validarDF.Validar();
                    
                case "ES":
                    ValidarES validarES = new ValidarES(codigo);
                    return validarES.Validar();
                    
                case "GO":
                    ValidarGO validarGO = new ValidarGO(codigo);
                    return validarGO.Validar();
                    
                case "MA":
                    ValidarMA validarMA = new ValidarMA(codigo);
                    return validarMA.Validar();
                    
                case "MT":
                    ValidarMT validarMT = new ValidarMT(codigo);
                    return validarMT.Validar();
                    
                case "MS":
                    ValidarMS validarMS = new ValidarMS(codigo);
                    return validarMS.Validar();
                    
                case "MG":
                    ValidarMG validarMG = new ValidarMG(codigo);
                    return validarMG.Validar();
                    
                case "PA":
                    ValidarPA validarPA = new ValidarPA(codigo);
                    return validarPA.Validar();
                    
                case "PB":
                    ValidarPB validarPB = new ValidarPB(codigo);
                    return validarPB.Validar();
                    
                case "PR":
                    ValidarPR validarPR = new ValidarPR(codigo);
                    return validarPR.Validar();
                    
                case "PE":
                    ValidarPE validarPE = new ValidarPE(codigo);
                    return validarPE.Validar();
                    
                case "PI":
                    ValidarPI validarPI = new ValidarPI(codigo);
                    return validarPI.Validar();
                    
                case "RJ":
                    ValidarRJ validarRJ = new ValidarRJ(codigo);
                    return validarRJ.Validar();
                    
                case "RN":
                    ValidarRN validarRN = new ValidarRN(codigo);
                    return validarRN.Validar();
                    
                case "RS":
                    ValidarRS validarRS = new ValidarRS(codigo);
                    return validarRS.Validar();
                    
                case "RO":
                    ValidarRO validarRO = new ValidarRO(codigo);
                    return validarRO.Validar();
                    
                case "RR":
                    ValidarRR validarRR = new ValidarRR(codigo);
                    return validarRR.Validar();
                    
                case "SC":
                    ValidarSC validarSC = new ValidarSC(codigo);
                    return validarSC.Validar();
                    
                case "SP":
                    ValidarSP validarSP = new ValidarSP(codigo);
                    return validarSP.Validar();
                    
                case "SE":
                    ValidarSE validarSE = new ValidarSE(codigo);
                    return validarSE.Validar();
                    
                case "TO":
                    ValidarTO validarTO = new ValidarTO(codigo);
                    return validarTO.Validar();

                default:
                    return false;
            };
        }
    }
}
