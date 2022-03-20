using CoffeeShopManagement.DAL;
using CoffeeShopManagement.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }


        bool validation()
        {
            bool flag = true;
            string error = "";
            Regex regName = new Regex(@"^[a-zA-Z\s]+$");
            //validate username
            if (txtUser.Text == "")
            {
                flag = false;
                error += "User name is not empty!\n";
                txtUser.Focus();
            }
            //valid fullname
            
            if (!regName.IsMatch(txtFullName.Text))
            {
                flag = false;
                error += "fullname invalid!\n";
                txtFullName.Focus();
            }
            //validate dateofbirth
            Regex regDate = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
            if (!regDate.IsMatch(txtDateOfBirth.Text))
            {
                flag = false;
                error += "date of birth is not empty!\n";
                txtDateOfBirth.Focus();
            }
            //validate gender
            if(!rbMale.Checked && !rbFemale.Checked)
            {
                flag = false;
                error += "Gender is not empty!\n";

            }
            Regex regPhone = new Regex(@"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$");
            //validate phone
            if (!regPhone.IsMatch(txtPhone.Text))
            {
                flag = false;
                error += "Phone invalid (format 0xxxxxxxxx)!\n";
                txtPhone.Focus();
            }
            //validate address
            if (txtAddress.Text == "")
            {
                flag = false;
                error += "Address is not empty!\n";
                txtAddress.Focus();
            }
            //validate password
            if (txtPass.Text == "")
            {
                flag = false;
                error += "Password is not empty!\n";
                txtPass.Focus();
            }
            //validate repass
            if (txtRePass.Text == "")
            {
                flag = false;
                error += "Re-Password is not empty!\n";
                txtRePass.Focus();
            }
            //if pass not equal repass
             if (!txtPass.Text.Equals(txtRePass.Text))
            {
                flag=false;
                error += "Password and Re-Password is not match!\n";
            }

            if (flag == false)
            {
                MessageBox.Show(error);
            }

            return flag;
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignupDAL dal = new SignupDAL();
            if (true)
            {
                var account = new Account()
                {
                    userName = txtUser.Text,
                    fullName = txtFullName.Text,
                    dateOfBirth = txtDateOfBirth.Text,
                    gender = rbMale.Checked ? 1 : 0,
                    phone = txtPhone.Text,
                    address = txtAddress.Text,
                    password = txtPass.Text
                };
                if(dal.SignUp(account) > 0)
                {
                    MessageBox.Show("SignUp success!");
                }else
                {
                    MessageBox.Show("SignUp invalid");
                }
            } 


        }
    }
}
