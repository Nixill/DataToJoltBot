using System.IO.Pipes;

namespace Nixill.Streaming.JoltBotClient;

public static class JoltBotClient
{
  static void Main(string[] args)
  {
    Console.WriteLine("Running!");

    NamedPipeClientStream client = new NamedPipeClientStream(".", "NixJoltBot", PipeDirection.Out);

    client.Connect();

    StreamWriter writer = new StreamWriter(client);

    writer.WriteLine(args.FirstOrDefault("{}"));
    writer.Flush();
    writer.Dispose();
    client.Dispose();
  }
}