﻿using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using TraderSys.Portfolios.Protos;

namespace TraderSys.Portfolios.ClientConsole
{
    class Program
    {
        private const string ServerAddress = "https://localhost:5001";

        static async Task Main()
        {
            var channel = GrpcChannel.ForAddress(ServerAddress);
            var portfolios = new Protos.Portfolios.PortfoliosClient(channel);

            try
            {
                var request = new GetRequest
                {
                    TraderId = "68CB16F7-42BD-4330-A191-FA5904D2E5A0",
                    PortfolioId = 42
                };
                var response = await portfolios.GetAsync(request);
            
                Console.WriteLine($"Portfolio contains {response.Portfolio.Items.Count} items.");
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
