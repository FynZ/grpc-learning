// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

Thread.Sleep(5_000);

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Greeter.GreeterClient(channel);

var names = new[] { "Sophie", "Patrick", "Romain", "Bernard", "Louise", "Marie" };
var random = new Random();

while (true)
{

    var response = await client.SayHelloAsync(new HelloRequest
    {
        Name = names[random.Next(0, names.Length)]
    });

    Console.WriteLine(response.Message);

    Thread.Sleep(2_000);
}
