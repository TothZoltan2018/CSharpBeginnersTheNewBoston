using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //
using System.Net.Mail; //

namespace Project1EmailSender
{
    //Part74, 75, 76 Project1EmailSender
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                if (!textBox4.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("gmail-es cimet adj meg a \"Credentials\" alatt!");
                    return;
                }                
                MailMessage message = new MailMessage();
                message.From = new MailAddress(textBox4.Text);
                message.Subject = textBox2.Text;
                message.Body = textBox3.Text;
                foreach (string address in textBox1.Text.Split(';'))
                {
                    message.To.Add(address);
                }

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);
                //hasznaljunk gmail-t, de lehetne mas is
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587; //a gmail portja
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
            catch (Exception eSentEmail)
            {
                MessageBox.Show("Hibas levelkuldesi kiserlet:" +
                                Environment.NewLine + eSentEmail.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }
        }
    }
}
