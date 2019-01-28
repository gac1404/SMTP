using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SMTPClient client = new SMTPClient();
        List<string> filePaths = new List<string>();


        public Form1()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxUser.Text = client.UserName;
            textBoxPassword.Text = client.Password;
            textBoxHost.Text = client.Host;
            textBoxPort.Text = client.Port.ToString();
            textBoxToEmail.Text = client.TextBoxToEmail;
            textBoxSubject.Text = client.Subject;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            client.UserName = textBoxUser.Text;
            client.Password = textBoxPassword.Text;
            client.Host = textBoxHost.Text;
            client.Port = Int32.Parse(textBoxPort.Text);
            client.TextBoxToEmail = textBoxToEmail.Text;
            client.Subject = textBoxSubject.Text;

            client.AddFiles(filePaths);
            client.Send(richTextBoxMessageContent.Text);


        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var path = openFileDialog1.FileName;

            if (path != "openFileDialog1")
            {
                filePaths.Add(path);
                path = path.Substring(path.LastIndexOf("\\") + 1);
                listBoxFiles.Items.Add(path);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUser.Text = "ga33822@onet.pl";
            textBoxPassword.Text = "Szczecinska143";
            textBoxHost.Text     = "smtp.poczta.onet.pl";
            textBoxPort.Text     = 587.ToString();
            textBoxToEmail.Text  = "ga33822@onet.pl";
            textBoxSubject.Text  = "PS LAB N2 ZIMA 2018 N14a";
            richTextBoxMessageContent.Text = "";

            filePaths.Clear();
            listBoxFiles.Items.Clear();

        }

        private void buttonRemoveFile_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex != -1)
            {

                filePaths.RemoveAt(listBoxFiles.SelectedIndex);
                listBoxFiles.Items.RemoveAt(listBoxFiles.SelectedIndex);
            }
        }
    }
}
