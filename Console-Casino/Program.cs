using System;
using System.Linq;
using Casino;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Console_Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BDDSingleton BDD = BDDSingleton.Instance;
            Console.WriteLine("OK");
          


        }
    }
}
