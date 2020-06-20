using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using server.Services;

namespace server
{
    public class GreeterService : Greeter.GreeterBase
    {
        // private readonly ILogger<GreeterService> _logger;
        // public GreeterService(ILogger<GreeterService> logger)
        // {
        //     _logger = logger;
        // }

        // public override Task<GreetingResponse> GetGreeting(GreetingRequest request, ServerCallContext context)
        // {
        //     return Task.FromResult(new GreetingResponse
        //     {
        //         Greeting = "Hello " + request.Country
        //     });
        // }

        private readonly IGreeterManager greeterManager;

        public GreeterService(IGreeterManager greeterManagerIn)
        {
            this.greeterManager = greeterManagerIn;
        }

        // public override async Task<GreetingResponse> GetGreeting(IAsyncStreamReader<GreetingRequest> requestStream, ServerCallContext context)
        // {
        //     var countriesGreetings = new List<string>();
        //     while (await requestStream.MoveNext())
        //     {
        //         var populationRequest = requestStream.Current;
        //         countriesGreetings.Add(greeterManager.Get(populationRequest.Country));
        //     }

        //     return new GreetingResponse { Greeting = countriesGreetings.ToString() };
        // }

        public override async Task GetGreeting(Empty request, IServerStreamWriter<GreetingResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new GreetingResponse { Greeting = greeterManager.Get("INDIA") });
            }
        }
    }
}
