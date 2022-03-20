using CoffeeShopManagement.DAL;
using CoffeeShopManagement.Models;
using System;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSignUp frmSignUp = new FrmSignUp();
            frmSignUp.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool Login(string username, string pass)
        {
            
            LoginDAL dal = new LoginDAL();
            Account acc = dal.Login(username, pass);
            if(acc != null)
            {
                return true;
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txtUserName.Text.Trim(), txtPass.Text.Trim()) != false)
            {
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }

        }

        
    }
}
