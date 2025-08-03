using System.IO.Pipes;
using System.Text.Json.Nodes;

namespace Nixill.Streaming.JoltBotClient;

public static class JoltBotClient
{
  static void Main(string[] args)
  {
    Console.WriteLine("Running!");

    NamedPipeClientStream client = new NamedPipeClientStream(".", "NixJoltBot", PipeDirection.Out);

    client.Connect(TimeSpan.FromSeconds(5));

    StreamWriter writer = new StreamWriter(client);

    writer.WriteLine(new JsonArray(args.Select(s => (JsonNode)s).ToArray()).ToJsonString());
    writer.Flush();
    writer.Dispose();
    client.Dispose();
  }
}