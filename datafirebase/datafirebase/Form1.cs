using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace datafirebase
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yZGx0MXUxvM0yFA9zZtqdToyTOeiCiX66i2730kt",
            BasePath = "https://cproject-436a8.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client!=null)
            {
                MessageBox.Show("Connected");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            //ทำอะไร
            var student = new Student {
               ID=passstu.Text,
               fname=namestu.Text,
               lname=laststu.Text
            };
            SetResponse response = await client.SetTaskAsync("Student/"+passstu.Text,student);
            Student result = response.ResultAs<Student>();
        }
    }
}
