using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPSignalSender : MonoBehaviour
{
    private string ipAddress = "192.168.0.200"; // IP address of the receiver
    private int port = 25000; // Port to send the data
    public double friction=0.0113;
    public bool collision=false;

    private UdpClient udpClient;

    void Start()
    {
        udpClient = new UdpClient(25000);
        SendData();
        Debug.Log("Start sending data ");
    }

    // Update is called once per frame
    void Update()
    {
        SendData();
    }
    void SendData()
    {
        // Serialize Data
        byte[] data = new byte[12]; // One Float (8Bytes) and one Boolean Data (4Bytes)
        System.BitConverter.GetBytes(friction).CopyTo(data, 0);
        System.BitConverter.GetBytes(collision).CopyTo(data, 8);
        Debug.Log("Data ready ");
        

        // Send data
        udpClient.Send(data, data.Length, ipAddress, port);
        Debug.Log("Sent friction data: " + friction);
         
         Debug.Log("Sent collision data: " + collision);
    }

    void OnDestroy()
    {
        udpClient.Close();
    }
}
