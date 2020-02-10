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
using Project1EmailSender.Resources;

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

                if (!IsFormStatusReadyToSend()) return; 

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
                MessageBox.Show("Mail has been sent.");
            }
            catch (Exception eSentEmail)
            {
                MessageBox.Show("Sending mail has failed:" +
                                Environment.NewLine + eSentEmail.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);}
            finally
            {
                button1.Enabled = true;
            }
        }

        private bool IsFormStatusReadyToSend()
        {
            if (!CheckFieldsAndShowMessageBox(textBox1 => textBox1.Text == string.Empty,
                        textBox1, GlobalStrings.troubleMessageTextBox1, GlobalStrings.mesBoxErr,
                        MessageBoxButtons.OK, MessageBoxIcon.Error)) return false;

            if (!CheckFieldsAndShowMessageBox(textBox2 => textBox2.Text == string.Empty,
                        textBox2, GlobalStrings.troubleMessageTextBox2, GlobalStrings.mesBoxInf,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) return false;
            if (!CheckFieldsAndShowMessageBox(textBox3 => textBox3.Text == string.Empty,
                        textBox3, GlobalStrings.troubleMessageTextBox3, GlobalStrings.mesBoxInf,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) return false;

            if (!CheckFieldsAndShowMessageBox(textBox1 => !textBox4.Text.Contains(GlobalStrings.gmailPostFix),
                        textBox4, GlobalStrings.troubleMessageTextBox4, GlobalStrings.mesBoxErr,
                        MessageBoxButtons.OK, MessageBoxIcon.Error)) return false;

             if (!CheckFieldsAndShowMessageBox(textBox5 => textBox5.Text == string.Empty,
                        textBox5, GlobalStrings.troubleMessageTextBox5, GlobalStrings.mesBoxErr,
                        MessageBoxButtons.OK, MessageBoxIcon.Error)) return false;

            return true;
        }

        private bool CheckFieldsAndShowMessageBox(Func<TextBox, bool> check, TextBox textbox, string troublemessageTextbox, string msgBoxCaption, MessageBoxButtons msgStatus, MessageBoxIcon icon)
        {
            bool fieldsAreOk = true;
           
            if (check(textbox))
            {//Hibas/ki nem toltott field adat eseten jovunk ide
                fieldsAreOk = false;
                switch (msgStatus)
                {
                    case MessageBoxButtons.OK:
                        MessageBox.Show(troublemessageTextbox, msgBoxCaption, msgStatus, icon);
                        break;
                    case MessageBoxButtons.OKCancel:
                        if (DialogResult.OK == MessageBox.Show(troublemessageTextbox, msgBoxCaption, msgStatus, icon)) return true;
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        break;
                    case MessageBoxButtons.YesNo:
                        break;
                    case MessageBoxButtons.RetryCancel:
                        break;
                    default:
                        break;
                }
            }

            return fieldsAreOk;
        }
    }
}
