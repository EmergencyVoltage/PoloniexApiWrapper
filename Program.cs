using System;
using Poloniex;

namespace poloniex_sharp_api_writer
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new Wrapper();
            while (true)
            {
                
                api.returnTicker();
            }
        }

    
    }
}
