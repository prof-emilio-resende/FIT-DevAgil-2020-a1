using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using FIT.Projeto.Aula1.AsyncAwait;
using FIT.Projeto.Aula1.OO;
using FIT.Projeto.Aula1.Printers;
using Microsoft.CSharp.RuntimeBinder;

namespace FIT.Projeto.Aula1
{
    class Program
    {

        static void Variaveis() 
        {
            string nome = "Emilio Murta Resende";
            int idade = 32;
            decimal altura = 1.77M;
            decimal peso = 88;
            int? age = null;

            if(idade % 2 != 0) age = 0;

            if(!age.HasValue) age = idade;

            Console.WriteLine("{0} {1} {2} {3}, {4}", nome, idade, altura, peso, age);
        }

        static void CondicoesLacosEColecoes() 
        {
            const string name = "Nome";
            string aName = "Nome";
            switch (aName)
            {
                case name:
                    Console.WriteLine("Name encontrado");
                    break;
                case "AnotherName":
                    Console.WriteLine("AnotherName encontrado");
                    break;
                default:
                    Console.WriteLine("valor não encontrado!");
                    break;
            }

            string[] nomes = { "nome1", "nome2" };
            Dictionary<string, string> registro = new Dictionary<string, string>() 
            {
                ["nome"] = "emilio",
                ["idade"] = "31"
            };
            List<Dictionary<string, string>> registros = new List<Dictionary<string, string>>() {
                new Dictionary<string, string>(){
                    ["nome"] = "Emilio"
                },
                new Dictionary<string, string>()
                {
                    ["nome"] = "Outra Pessoa"
                }
            };
            string[] novosNomes = new string[3];
            for(int i = 0; i < nomes.Length; i++) {
                novosNomes[i] = nomes[i];
            }
            novosNomes[2] = "novo Nome";
            registros.Add(registro);
            Console.WriteLine(registro);
            Console.WriteLine(registros);
            Console.WriteLine(nomes);
            Console.WriteLine(novosNomes);

            foreach(string nome in novosNomes){
                Console.WriteLine(nome);
            }
            foreach(Dictionary<string, string> dic in registros)
            {
                foreach(string key in dic.Keys)
                {
                    Console.WriteLine(key);
                    Console.WriteLine(dic[key]);
                }
                foreach(string val in dic.Values)
                {
                    Console.WriteLine(val);
                }
                foreach(KeyValuePair<string, string> entry in dic)
                {
                    Console.WriteLine(entry.Key);
                    Console.WriteLine(entry.Value);
                }
            }
        }

        static void Dynamics()
        {
            var strNome = "Nome";
            var numero = 10;
            var numeroDouble = 10.0;
            var numeroDecimal = 10.0M;
            var lista = new List<string>() { "dynaList" };
            var dicionario = new Dictionary<string, string>()
            {
                ["nome"] = "Emilio"
            };

            dynamic expando = new ExpandoObject();
            expando.Name = "Um Nome";
            expando.Telefone = "9899898898";
            var listaExp = new List<ExpandoObject>();
            listaExp.Add(expando);

            Console.WriteLine("Números dinâmicos: {0}, {1}, {2}, {3}", strNome, numero, numeroDouble, numeroDecimal);
            foreach(var el in lista)
            {
                Console.WriteLine("Lista!");
                Console.WriteLine(el);
            }
            foreach(KeyValuePair<string, string> kp in dicionario)
            {
                Console.WriteLine(kp.Key);
                Console.WriteLine(kp.Value);
            }
            Console.WriteLine("Testing expando!");
            Console.WriteLine(expando.Name);
            Console.WriteLine(expando.Telefone);
            try
            {

                Console.WriteLine(expando.NotFound);
            }
            catch(RuntimeBinderException rbe)
            {
                Console.WriteLine(rbe);
                Console.WriteLine("Propriedade não existente no expObj");
            }

            foreach(var eo in listaExp)
            {
                Console.WriteLine("Expando!");
                Console.WriteLine(eo);
            }
        }

        static void HerancaEPolimorfismo()
        {
            var pf = new PessoaFisica("Emilio", "123");
            var pj = new PessoaJuridica("FIT", "123");
            Console.WriteLine("pf: {0}, {1}, {2}", pf.Name, pf.Cpf, pf.Falar());
            Console.WriteLine("pj: {0}, {1}", pj.Name, pj.Cnpj);

            var falantes = new List<IFala>() { pf, pj };
            foreach(var f in falantes)
            {
                Console.WriteLine(f.Falar());
            }
        }

        static void Funcional()
        {
            var now = DateTime.UtcNow;
            var prefix = $"[{now.ToShortDateString()} {now.ToLongTimeString()}]";
            
            var ooPrinter = new OOPrinter(prefix);
            var funcPrinter = FuncPrinter.Logger(prefix, separator: "||");
            FuncPrinter.Logger(prefix, separator: "||")("tranquilo, tranquilo...");
            var message = "a single message...";
            ooPrinter.DoPrint(message);
            funcPrinter(message);
        }

        static async Task AsyncAwaitFct()
        {
            var now = DateTime.UtcNow;

            Console.WriteLine("Regular async await...");
            Console.WriteLine($"[{now.ToShortDateString()} {now.ToLongTimeString()}]");
            foreach(var n in await AsyncUtils.GetNamesStdAsync())
            {
                Console.WriteLine("Std Async Hello World!");
                Console.WriteLine($"[{now.ToShortDateString()} {now.ToLongTimeString()}]");
            }

            Console.WriteLine("Now streams...");
            Console.WriteLine($"[{now.ToShortDateString()} {now.ToLongTimeString()}]");
            await foreach(var n in AsyncUtils.GetNamesAsyncStream())
            {
                Console.WriteLine("Std Async Hello World!");
                Console.WriteLine($"[{now.ToShortDateString()} {now.ToLongTimeString()}]");
            }
        }

        static void Tuples()
        {
            var t = (Key: "AKey", Value: "value");
            Console.WriteLine(t.Key);
            Console.WriteLine(t.Value);
        }

        static string FancySwitch(string color)
        {
            return color switch {
                "red" => "#FF0000",
                "green" => "#00FF00",
                "blue" => "#0000FF",
                _ => "#FFFFFF"
            };
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Conhecendo tipos de dados");
            Variaveis();

            Console.WriteLine("Trabalhando com condicões, laços e coleções");
            CondicoesLacosEColecoes();

            Console.WriteLine("Um pouco de tipagem dinamica...");
            Dynamics();

            Console.WriteLine("Herança e polimorfismo!");
            HerancaEPolimorfismo();

            Console.WriteLine("Funcional, lambda e generics");
            Funcional();

            Console.WriteLine("Async Await");
            await AsyncAwaitFct();

            Console.WriteLine("Tuples!");
            Tuples();

            Console.WriteLine("Fancy switch");
            Console.WriteLine(FancySwitch("green"));
            Console.WriteLine(FancySwitch("NoColor"));
        }
    }
}
