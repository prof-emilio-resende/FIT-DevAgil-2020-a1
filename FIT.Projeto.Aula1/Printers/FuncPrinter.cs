using System;

namespace FIT.Projeto.Aula1.Printers {
    public static class FuncPrinter {

        public static Func<string, string> Logger(string prefix, string separator=":") {
            return str => {
                var text = $"[fnc]{prefix} {separator} {str}";
                DoPrint(text);
                return text;
            };
        }

        public static void DoPrint(string phrase) {
            Console.WriteLine(phrase);
        }
    }
}