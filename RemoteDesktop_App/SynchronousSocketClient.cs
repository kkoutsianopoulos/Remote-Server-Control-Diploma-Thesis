using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketClient
{
    private IPEndPoint remoteEP;
    private Socket sender;
    private int port;
    private String ip;
    private bool isOpen;
    private long numberOfSendTransactions;
    public bool getIsOpen()
    {
        return isOpen;
    }

    // Constructor with IP and port.
    public SynchronousSocketClient(String IpAddress, int _port)
    {
        numberOfSendTransactions = 0;
        this.ip = IpAddress;
        port = _port;
            // Establish remote endpoint for the socket.
            this.remoteEP = new IPEndPoint(IPAddress.Parse(this.ip), port);

        // Create TCP/IP Socket.
        sender = new Socket(IPAddress.Parse(this.ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    // Connect to the remote device.
    public void Connect()
    {
        // Connect the socket to the remote endpoint. Chatch any errors.
        try
        {
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        }
        catch (SocketException se)
        {
            Console.WriteLine("SocketException : {0}", se.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("UnexpectedException : {0}", e.ToString());
        }
    }

    public void Send(string data)
    {
        Console.WriteLine("In Send");
        try
        {
            // Encode the data string into a byte array.
            byte[] msg = Encoding.UTF8.GetBytes(data + "\n");
            numberOfSendTransactions += 1;
            // Send the data through the socket.
            int bytesSent = sender.Send(msg);

            Console.WriteLine(numberOfSendTransactions.ToString() +":"+bytesSent.ToString());
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        }
        catch (SocketException se)
        {
            Console.WriteLine("SocketException : {0}", se.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("UnexpectedException : {0}", e.ToString());
        }
        Console.WriteLine("Endind Send Operation");
    }

    public void Shutdown()
    {
        if (isOpen == true)
        {
            try
            {
                // Encode the data string into a byte array.
                byte[] msg = Encoding.UTF8.GetBytes("End of Connection <EOF>");

                // Send the data through the socket.
                int bytesSent = sender.Send(msg);
                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                isOpen = false;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("UnexpectedException : {0}", e.ToString());
            }
        }
    }


    public void StartClient()
    {
        // Data buffer for incoming data.  
        //byte[] bytes = new byte[1024];
        isOpen = false;
        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            remoteEP = new IPEndPoint(IPAddress.Parse(ip), 8989);

            // Create a TCP/IP  socket.  
            sender = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            try
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
                isOpen = true;
                // Encode the data string into a byte array.  
                byte[] msg = Encoding.UTF8.GetBytes("This is a test<_EOF> \n");

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                msg = Encoding.UTF8.GetBytes("Mouse connected to socket server! \n");

                // Send the data through the socket.  
                bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                // bytesRec = sender.Receive(bytes);
                // Console.WriteLine("Echoed test = {0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}