using System.IO;
using System.Net.Sockets;
using UnityEngine;
using System.Text;

public class Client : MonoBehaviour
{
    private TcpClient _client;
    private StreamReader _reader;
    private StreamWriter _writer;

    private void Start()
    {
        _client = new TcpClient("127.0.0.1", 8888);
        NetworkStream stream = _client.GetStream();
        _reader = new StreamReader(stream, Encoding.UTF8);
        _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        _writer.WriteLine("�ȳ� ����!");

        string response = _reader.ReadLine();
        Debug.Log($"���� ����: {response}");
    }

    private void OnApplicationQuit()
    {
        _reader.Close();
        _writer.Close();
        _client.Close();
    }
}