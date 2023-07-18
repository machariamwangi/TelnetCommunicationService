using System.Net.Sockets;
using System.Text.RegularExpressions;


try
{
    var tcpClient = new TcpClient("your Ip Adress here", 23);
    var ns = tcpClient.GetStream();
    Byte[] output = new Byte[1024];
    String response = String.Empty;
    Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
    ns.Write(cmd, 0, cmd.Length);
    Int32 bytes = ns.Read(output, 0, output.Length);
    response = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
    Console.Write(response);


    Thread.Sleep(100);
    bytes = ns.Read(output, 0, output.Length);
    response = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
    Console.WriteLine(response);
    Regex objToMatch = new Regex("Username");
    if (objToMatch.IsMatch(response))  //Both Regex match
    {
        cmd = System.Text.Encoding.ASCII.GetBytes("your username here " + "\r");
        ns.Write(cmd, 0, cmd.Length);
    }
    Thread.Sleep(100);


    Thread.Sleep(100);
    bytes = ns.Read(output, 0, output.Length);
    response = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
    Console.WriteLine(response);
    objToMatch = new Regex("Password");
    if (objToMatch.IsMatch(response))  //Both Regex match
    {
        cmd = System.Text.Encoding.ASCII.GetBytes("your password here" + "\r");
        ns.Write(cmd, 0, cmd.Length);
    }
    Thread.Sleep(100);


    // at this point we prepare the command 
    Thread.Sleep(100);
    bytes = ns.Read(output, 0, output.Length);
    response = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
    Console.WriteLine(response);
    
        cmd = System.Text.Encoding.ASCII.GetBytes("user command here" + "\r");
        ns.Write(cmd, 0, cmd.Length);
    
    Thread.Sleep(100);

    bytes = ns.Read(output, 0, output.Length);
    response = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
    Console.WriteLine(response); //Invalid Username/Password response
    cmd = System.Text.Encoding.ASCII.GetBytes("\r");
    ns.Write(cmd, 0, cmd.Length); //Cannot send because connection is closed
    tcpClient.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
	throw;
}

