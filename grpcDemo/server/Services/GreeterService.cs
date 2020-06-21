using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using server;

namespace server
{
    public class GreeterService : Greeter.GreeterBase
    {

        private readonly IGreetingManager greetingManager;

        public GreeterService(IGreetingManager greeterManagerIn)
        {
            this.greetingManager = greeterManagerIn;
        }
        // public override Task<GreetingResponse> GetGreeting(GreetingRequest request, ServerCallContext context)
        // {
        //     return Task.FromResult(new GreetingResponse
        //     {
        //         Greeting = "Hello " + request.Language
        //     });
        // }

        public override async Task GetGreeting(Empty request, IServerStreamWriter<GreetingResponse> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new GreetingResponse { Greeting = greetingManager.GetRandom() });
            }
        }
    }
}
