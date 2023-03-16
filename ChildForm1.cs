using System.Net.Mail;

public partial class ChildForm1 : Form
{
    public ChildForm1()
    {
        InitializeComponent();
        label1.Text = "This is Child Form 1";
        StartPosition = FormStartPosition.CenterParent;
    }

    private void SendEmail(string recipient, string subject, string body)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("your_email_address@example.com");
                mail.To.Add(recipient);
                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("your_email_address@example.com", "your_email_password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            MessageBox.Show("Email sent successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error sending email: " + ex.Message);
        }
    }
}


