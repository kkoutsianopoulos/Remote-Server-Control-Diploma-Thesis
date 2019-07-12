import java.net.*;
import java.io.*;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Server1{
    // initialize socket and input stream
    private Socket socket = null;
    private ServerSocket server = null;
    private DataInputStream in = null;

    //constructo with port
    public Server1(int port)
    {
        // starts server and waits for a connection
        try{
            server = new ServerSocket(port);
            System.out.println("Server started");

            System.out.println("Waiting for Client ...");

            socket = server.accept();
            System.out.println("Client accepted");

            
            
            
            BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

            String inputLine;
            while((inputLine = in.readLine()) != null) {
                System.out.println(inputLine);
                if(inputLine.equals("<EOF>"))
                    break;
            }
            System.out.println("Closing connection");
            //close connection
            socket.close();
            in.close();
        } catch(IOException i){
            System.out.println(i);
        }
    }

    // Run the server
    public static void main(String args[]){
        Server1 server = new Server1(8989);
    }
}
