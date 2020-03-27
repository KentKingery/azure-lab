using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureLab.JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Equity> eqList = new List<Equity>();

            Equity eq = new Equity() { Ticker = "IBM" };
            eq.Ask = new Ask() { Price = 117.96M, Size = 800};
            eq.Bid = new Bid() { Price = 118.01M, Size = 900};

            eqList.Add( eq );

            eq = new Equity() { Ticker = "MSFT" };
            eq.Ask = new Ask() { Price = 155.40M, Size = 1300};
            eq.Bid = new Bid() { Price = 155.00M, Size = 1300};

            eqList.Add( eq );

            string jsonString = JsonSerializer.Serialize(eqList);

            System.Console.WriteLine( jsonString );
            */

            Ingest();
        }

        static void Ingest()
        {
            string jsonText = "[{\"Ticker\":\"IBM\",\"Ask\":{\"Price\":117.96,\"Size\":800},\"Bid\":{\"Price\":118.01,\"Size\":900}},{\"Ticker\":\"MSFT\",\"Ask\":{\"Price\":155.40,\"Size\":1300},\"Bid\":{\"Price\":155.00,\"Size\":1300}}]";

            List<Equity> newEqList = JsonSerializer.Deserialize<List<Equity>>(jsonText);

            

        }
    }
}
