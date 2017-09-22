using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Project2
{
    public partial class UserInfoForm : Form
    {
        public static User user;
        public UserInfoForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// event handler for the OK button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            user = new User(textBox1.Text, "1111111111", textBox2.Text);
            Close();
        }
    }
}
