using System;

namespace FIT.Projeto.Aula1.Printers {
    public class OOPrinter {

        public string? _prefix = null;

        public OOPrinter(string prefix)
        {
            _prefix = prefix;
        }
        
        public void DoPrint(string phrase) {
            Console.WriteLine($"[oo]{_prefix} : {phrase}");
        }
    }
}