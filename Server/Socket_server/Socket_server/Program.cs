using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_server;

public class Program
{
    public static void Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8888);
        server.Start();
        Console.WriteLine("서버 시작... 기다리는 중...");
        
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("클라이언트 연결됨!");
        
        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        StreamWriter writer = new StreamWriter(stream, Encoding.UTF8){AutoFlush = true};

        while (true)
        {
            string msg = reader.ReadLine();
            Console.WriteLine($"받은 메세지: {msg}");
            
            writer.WriteLine($"서버 응답: {msg.ToUpper()}");
        }
    }
}