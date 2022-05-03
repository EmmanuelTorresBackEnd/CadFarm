using System;
using System.IO;
using CadFarm;
using System.Threading;


class Program
    {
        static void Main(String[]args)
        {

            List<medicamento> listaMed = new List<medicamento>();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
====================================
|                                  |
|    Seja Bem Vindo ao CadFarm!    |
|                                  |
====================================");
            
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Write($"Aguarde");
            Thread.Sleep(300);
            for (var i = 0; i < 7; i++)
            {
                Console.Write($".");
                Thread.Sleep(300);    
            }
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;

            string? Opcao;
            do
            {
            Console.WriteLine(@$"
=====================================
|         Selecione uma Opção       |
|___________________________________|
|     1 - Cadastrar Medicamento     |
|     2 - Consultar Medicamentos    |
|     3 - Excluir Medicamento       |
|                                   |
|     0 - Sair                      |
=====================================");

            Console.ResetColor();            
            Opcao = (Console.ReadLine());
            
            switch (Opcao)
            {
                case "1":

                medicamento NovoMed = new medicamento();

                Console.WriteLine($"Digite o Nome do Medicamento!");
                NovoMed.NomeMed = Console.ReadLine();

                Console.WriteLine($"Digite o Id do Medicamento!");
                NovoMed.idMed = Console.ReadLine();
                
                Console.WriteLine($"Digite uma Curta Descrição do Medicamento!");
                NovoMed.DescricaoMed = Console.ReadLine();
                
                Console.WriteLine($"Digite o Valor do Medicamento!");
                NovoMed.ValorMed = Console.ReadLine();

                Console.WriteLine($"Cadastrado com Sucesso!");

                listaMed.Add(NovoMed);


                using (StreamWriter sw = new StreamWriter($"{NovoMed.NomeMed}.txt"))
                {
                     sw.Write($"Nome: {NovoMed.NomeMed}, Id: {NovoMed.idMed}, Descrição: {NovoMed.DescricaoMed} , Valor: {NovoMed.ValorMed}");
                }

                using (StreamReader sr = new StreamReader($"{NovoMed.NomeMed}.txt"))
                {
                    break;
                }

                case "2":

                foreach (medicamento CadaItem in listaMed)
                {
                    Console.Write($"Nome: {CadaItem.NomeMed}, Id: {CadaItem.idMed}, Descrição do Medicamento: {CadaItem.DescricaoMed}, Valor do Medicamento: {CadaItem.ValorMed} ");
                }

                    break;

                case "3":

                Console.WriteLine($"Digite o Id do Medicamento que Deseja Remover!");
                var IdProcurado = Console.ReadLine();
                
                var MedicamentoProcurado = listaMed.Find(CadaItem => CadaItem.idMed ==IdProcurado);
                
                     if (MedicamentoProcurado != null)
                    {
                    listaMed.Remove(MedicamentoProcurado);
                    Console.WriteLine($"Medicamento removido!");
                    }
                    else 
                    {
                        Console.WriteLine($"Id não encontrado");
                    }

                    break;

                case "0":

                Console.Clear();
                Console.Write($"Saindo");
                Console.ResetColor();
                Thread.Sleep(300);

            for (var i = 0; i < 7; i++)
            {
                Console.Write($".");
                Thread.Sleep(300);    
            }
                Console.ResetColor();
                    
                    break;

                default:
                Console.WriteLine($"Digite uma Opção Válida!");
                    
                    break;
            
            }
            
            } while (Opcao != "0");

        }
            
    }
    