using System;

using Newtonsoft.Json;

namespace ConsoleApp_BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {

           
            Blockchain TechCoin = new Blockchain();
            var startTime1 = DateTime.Now;
            TechCoin.AddBlock(new Block(DateTime.Now, null, "{sender:ahmet,receiver:orhan,amount:10}"));
            Console.WriteLine($"Duration1: {DateTime.Now - startTime1}");
            var startTime2 = DateTime.Now;
            TechCoin.AddBlock(new Block(DateTime.Now, null, "{sender:orhan,receiver:ahmet,amount:5}"));
            Console.WriteLine($"Duration2: {DateTime.Now - startTime2}");
            var startTime3 = DateTime.Now;
            TechCoin.AddBlock(new Block(DateTime.Now, null, "{sender:orhan,receiver:ahmet,amount:5}"));
            Console.WriteLine($"Duration3: {DateTime.Now - startTime3}");

            //  var endTime = DateTime.Now;




            Console.WriteLine(JsonConvert.SerializeObject(TechCoin, Formatting.Indented));
            Console.WriteLine(TechCoin.IsValid());
            TechCoin.chain[1].Data = "{sender:ahmet,receiver:orhan,amount:1000}";
            Console.WriteLine(TechCoin.IsValid());
            
            Console.ReadKey();
        }
    }
}
