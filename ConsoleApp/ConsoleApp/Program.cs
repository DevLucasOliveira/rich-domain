using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
       static void Main(string[] args)
        {
            // Dictionary<CHAVE, VALOR>
            var estados = new Dictionary<string, List<string>>();

            estados.Add("SP", new List<string> { "Santos", "Guarujá", "Itanhaém", "Peruíbe" });

            var praias = estados["SP"];

            foreach(var praia in praias)
            {
                Console.WriteLine(praia);
            }

            Console.Read();
        }
    }
}
