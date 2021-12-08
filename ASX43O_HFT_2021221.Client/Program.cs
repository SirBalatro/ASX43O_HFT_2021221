using ASX43O_HFT_2021221.Models;
using System;

namespace ASX43O_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RestService restService = new RestService("http://localhost:8797");
            /*
            var res = restService.Get<PlayerCharacter>("/PlayerCharacter");

            foreach (PlayerCharacter item in res)
            {
                Console.WriteLine(item.Name);
            }
            */
        }
    }
}
