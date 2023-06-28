using System;

class Program
{
    static bool ValidaCnpj(string cnpj)
    {
        cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", ""); // Remove caracteres especiais

        if (cnpj.Length != 14 || !long.TryParse(cnpj, out _))
            return false;

        int[] multiplicadores1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string digitoVerificador = cnpj.Substring(12);

        int soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];

        int resto = soma % 11;
        int primeiroDigito = (resto < 2) ? 0 : 11 - resto;

        if (int.Parse(digitoVerificador[0].ToString()) != primeiroDigito)
            return false;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        int segundoDigito = (resto < 2) ? 0 : 11 - resto;

        if (int.Parse(digitoVerificador[1].ToString()) != segundoDigito)
            return false;

        return true;
    }

    static void Main(string[] args)
    {
        string cnpj;
        bool cnpjValido = false;

        while (!cnpjValido)
        {
            Console.WriteLine("Digite o CNPJ:");
            cnpj = Console.ReadLine();

            if (ValidaCnpj(cnpj))
            {
                Console.WriteLine("CNPJ válido!");
                cnpjValido = true;
            }
            else
            {
                Console.WriteLine("CNPJ inválido! Digite novamente.");
            }
        }

        Console.ReadKey();
    }
}