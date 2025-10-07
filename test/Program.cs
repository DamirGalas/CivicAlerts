using NATS.Client;
using System;
using System.Text;
using System.Threading;

ConnectionFactory cf = new ConnectionFactory();
using IConnection connection = cf.CreateConnection("nats://localhost:4222");

connection.SubscribeAsync("test", (object sender, MsgHandlerEventArgs args) =>
{
    Console.WriteLine("Primljena poruka: " + Encoding.UTF8.GetString(args.Message.Data));
});

string message = "Pozdrav od NATS-a";
Console.WriteLine("Salje se poruka " + message);
connection.Publish("test", Encoding.UTF8.GetBytes(message));

Thread.Sleep(1000);
