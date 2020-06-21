using Grpc.Net.Client;
using server;
using System.Threading.Tasks;
using System;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
namespace client
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello Grpc World!");
        //     AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        //     using var channel = GrpcChannel.ForAddress("http://localhost:5000");
        //     var client = new Greeter.GreeterClient(channel);
        //     var reply =  client.GetGreeting(
        //                       new server.GreetingRequest { Language = "Hindi" });

        //     Console.WriteLine(reply.Greeting);
        // }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello gRPC streaming Demo! \n");
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Greeter.GreeterClient(channel);

            var token = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            using var greetings = client.GetGreeting(new Empty(),  cancellationToken: token.Token);
            try
            {
                await foreach (var item in greetings.ResponseStream.ReadAllAsync(token.Token))
                { Console.WriteLine(item.ToString()); }
            }
            catch (RpcException exc)
            {
                Console.WriteLine(exc.Message);
            }

        }
    }
}
