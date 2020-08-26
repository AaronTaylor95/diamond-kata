using System;

namespace diamond
{
    class Program
    {        
        static void Main(string[] args)
        {
            var diamondRows = new PaddedDiamond('C').Print();
            diamondRows.ForEach(Console.WriteLine);

            var result = new AlphabetChain.AlphabetChain(new Letter('Z')).Execute();

            result.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }        
    }       
}
