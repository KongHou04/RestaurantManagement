using BUS.Handler;
using BUS.Repository.Implements.Setters;
using BUS.Repository.Interfaces.Setters;
using DAO.Repository.Implements;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class Login : Form
    {
        private IAccountBUS accountBUS = new AccountBUS(new AccountDAO(new DAO.Context.RMDbContext()));

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var a = await accountBUS.Login(textBox1.Text, textBox2.Text, false);
            if (a != null)
                MessageBox.Show("Login successfully");
        }
    }
}
