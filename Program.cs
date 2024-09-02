// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;

class Program 

{
    public class MarketData 
    {
        public required string AssetType { get; set; }
        public required string RiskLevel { get; set; }
        public int PercentageChange { get; set; }
    }

    static void Main(string[] args)
    {
        bool anotherGO = true;

        while (anotherGO)
        {
            Console.WriteLine("Hello, Ten Ten please tell me how long you want to invest in years");

            Console.Write("Enter number 1-10:  ");
            int year = int.Parse(Console.ReadLine()!);

            Console.Write("How much risk do you want to take, 1 - 100?  ");
            int risk = int.Parse(Console.ReadLine()!);

            ProcessInput(year, risk);

            Console.Write("Do you want another try? Yes/No:  ");
            string response = Console.ReadLine()!.Trim().ToLower();

            if (response != "yes")
            {
                anotherGO = false;
                Console.Write("Thank you for your time Ten Ten");
            }
    
        }
        
    }



    static void ProcessInput(int year, int risk)
    {
        List<MarketData> marketData = new List<MarketData>{
            new MarketData { AssetType = "Tech Stocks", RiskLevel = "High", PercentageChange = 40 },
            new MarketData { AssetType = "Index Funds", RiskLevel = "Low", PercentageChange = 8 },
            new MarketData { AssetType = "Real Estate", RiskLevel = "Medium", PercentageChange = 10 },
            new MarketData { AssetType = "Crypto", RiskLevel = "High Crazy", PercentageChange = 200 },

        };


        var riskHighest = marketData.Where(asset => asset.RiskLevel == "High").ToList();

        var riskLowest = marketData.Where(asset => asset.RiskLevel == "Low" && asset.PercentageChange < 9).ToList();

        var riskMedium = marketData.Where(asset => asset.RiskLevel == "Medium").ToList();

        if(risk > 90 && year >= 5)
        {
            Console.WriteLine($"You crazy fool buy Crypto at your own risk");
        }

        if (risk > 60 && year >= 5)
        {
            Console.WriteLine($"Buy {riskHighest[0].AssetType} but beware the market value is volatile with changes of {riskHighest[0].PercentageChange} % anually");
        }

        if (risk <= 60 && risk > 20 && year >= 5)
        {
            Console.WriteLine($"For a medium risk long term investment {riskMedium[0].AssetType} with a recorded percentage change of {riskMedium[0].PercentageChange} % anually");
        }

        if (risk < 20 && risk >= 1 && year >= 5)
        {
            Console.WriteLine($"We recommend {riskLowest[0].AssetType} but remember nothing is zero risk");
        }

        if (year < 5)
        {
            Console.WriteLine("We recommend a longer time in the market (not timing the market!!!)");
        }
        else {
            Console.WriteLine("We regret to anounce the markets are closed");
        }
    }
}

