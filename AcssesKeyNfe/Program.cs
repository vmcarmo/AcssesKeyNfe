using System;
using System.Threading;

namespace AcssesKeyNfe
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------MENU--------------------");
            Console.WriteLine("1 - Para modelo da nota fiscal.");
            Console.WriteLine("2 - Para todas as infos da NF-e");
            Console.WriteLine("0 - Para sair.");
            Console.WriteLine("---------------------------------------------");
            var option = int.Parse(Console.ReadLine());

            if (option == 0)
            {
                Console.WriteLine("Saindo...");
                Thread.Sleep(600);
                Console.Clear();
                System.Environment.Exit(0);
            }

            switch (option)
            {
                case 1: Model(); break;
                case 2: Info(); break;
                default: Menu(); break;
            }
        }

        static void Info()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("          Digite a chave de acesso.");
            Console.WriteLine("---------------------------------------------");
            var key = Console.ReadLine();


            #region tests
            var maxLength = key.Length;
            if (maxLength != 44)
            {
                var i = 4;
                while (i > 1)
                {
                    Console.Clear();
                    i--;
                    Console.WriteLine($"Chave de acesso incompleta ou errada!\n Aguarde e digite novamente. {i}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                Info();
            }
            #endregion tests

            var number = key.Substring(25, 9);
            var serie = key.Substring(22, 3);
            var cnpj = key.Substring(6, 14);
            var issue = key.Substring(2, 2);
            var monthIssue = key.Substring(4, 2);
            var state = key.Substring(0, 2);


            var model = key.Substring(20, 2);
            var selection = "Modelo não encontrado.";

            if (model == "55")
                selection = "Modelo 55 | NFe - Nota fiscal de material.";

            if (model == "57")
                selection = "Modelo 57 | CTe - Conhecimento de transporte.";

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Número: {number}-{serie}");
            Console.WriteLine($"Modelo: {selection}");
            Console.WriteLine($"CNPJ do Emissor: {cnpj}");
            Console.WriteLine($"Emissão: {monthIssue}/{issue}");
            Console.WriteLine($"Codigo do Estado do Emissor: {state}");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            Menu();


        }

        static void Model()
        {
            Console.Clear();
            Console.WriteLine("------------MODELO DA NOTA FISCAL------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("          Digite a Chave de Acesso.");
            Console.WriteLine("---------------------------------------------");
            var key = Console.ReadLine();

            #region tests
            var maxLength = key.Length;
            if (maxLength != 44)
            {
                Console.WriteLine("Chave de acesso incompleta ou errada!\n Aguarde e digite novamente.");
                Thread.Sleep(2500);
                Model();
            }
            #endregion tests

            var type = key.Substring(20, 2);
            var selection = 3;

            if (type == "55")
                selection = 1;

            if (type == "57")
                selection = 2;

            switch (selection)
            {
                case 1: NFe(key); break;
                case 2: CTe(); break;
                default: Console.WriteLine("Chave de acesso incorreta!\n Aguarde e digite novamente."); Thread.Sleep(3000); Model(); break;
            }
        }

        static void NFe(string key)
        {
            Console.WriteLine("Modelo 55 NFe- Nota fiscal de material.");
            Thread.Sleep(2500);

            Console.WriteLine("Voltando para o menu.");
            Thread.Sleep(2500);
            Menu();

        }

        static void CTe()
        {
            Console.WriteLine("Modelo 57 CTe - Conhecimento de transporte.");
            Thread.Sleep(2500);

            Console.WriteLine("Voltando para o menu.");
            Thread.Sleep(2500);
            Menu();
        }

    }
}
