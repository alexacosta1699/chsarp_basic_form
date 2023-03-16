using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public partial class ChildForm2 : Form
{
    private Socket socket;
    private const int port = 1112;
    private const int timeout = 30000;

    public ChildForm2()
    {
        InitializeComponent();
        label1.Text = "This is Child Form 2";
        StartPosition = FormStartPosition.CenterParent;
    }

    private void ConnectButton_Click(object sender, EventArgs e)
    {
        try
        {
            string ip = Microsoft.VisualBasic.Interaction.InputBox("Enter IP address of server:", "Connect to Server", "10.0.0.1");
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = timeout;
            socket.Connect(remoteEP);
            MessageBox.Show("Connected to server.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error connecting to server: " + ex.Message);
        }
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
        try
        {
            string message = MessageTextBox.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            socket.Send(buffer);
            MessageBox.Show("Message sent successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error sending message: " + ex.Message);
        }
    }

    private void ReceiveButton_Click(object sender, EventArgs e)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesRead = socket.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            File.WriteAllText("output.txt", message);
            MessageBox.Show("Message received and saved to file.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error receiving message: " + ex.Message);
        }
    }

    private void DisconnectButton_Click(object sender, EventArgs e)
    {
        try
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            MessageBox.Show("Disconnected from server.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error disconnecting from server: " + ex.Message);
        }
    }
}
