using System.Net.Mail;

public partial class ChildForm1 : Form
{
    public ChildForm1()
    {
        InitializeComponent();
        label1.Text = "This is Child Form 1";
        StartPosition = FormStartPosition.CenterParent;
    }

    private void SendEmailButton_Click(object sender, EventArgs e)
    {
        string fromAddress = "yourEmailAddress@example.com";
        string toAddress = "recipientEmailAddress@example.com";
        string subject = "Test email";
        string body = "This is a test email.";

        SmtpClient smtpClient = new SmtpClient("smtp.example.com", 587);
        smtpClient.Credentials = new NetworkCredential("yourEmailAddress@example.com", "yourEmailPassword");

        MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);

        try
        {
            smtpClient.Send(message);
            MessageBox.Show("Email sent successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error sending email: " + ex.Message);
        }
    }
}
