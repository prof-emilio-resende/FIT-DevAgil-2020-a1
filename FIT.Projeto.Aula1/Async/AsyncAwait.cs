using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FIT.Projeto.Aula1.AsyncAwait
{
    public static class AsyncUtils {
        public static async Task<IEnumerable<string>> GetNamesStdAsync()
        {
            string[] names =
            {
                "essas", "são", "palavras", "para", "imprimir"
            };

            Range range = 1..4;

            var enumerable = new List<string>();

            foreach(var name in names[range]){
                await Task.Delay(1000);
                enumerable.Add(name);
            }

            return enumerable;
        }
    
        public static async IAsyncEnumerable<string> GetNamesAsyncStream()
        {
            string[] names =
            {
                "essas", "são", "palavras", "para", "imprimir"
            };

            //TODO: Ranges!!
            Range range = 1..4;

            foreach(var name in names[range]){
                await Task.Delay(1000);
                yield return name;
            }
        }
    }
}