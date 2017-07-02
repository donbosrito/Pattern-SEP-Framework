using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SEPFramework.MemberShip
{
    public partial class LoginForm<T> : Form
    {
        private MainForm<T> _mainForm = null;
        private SignupForm _signupForm = null;
        public LoginForm()
        {
            InitializeComponent();
            this._firstTime();
        }

        public void setMainForm(ref MainForm<T> mainForm)
        {
            this._mainForm = mainForm;
        }

        private bool _firstTime()
        {
            if (AccountManager.DBConnector != null && AccountManager.getInstance().IsEmpty())
            {
                MessageBox.Show("Run for the first time.\nPlease register a account first.", "First time running",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this._signupForm = new SignupForm();
                this._signupForm.firstTime();
                this._signupForm.ShowDialog();
                return true;
            }

            return false;
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lab_Cancel_MouseEnter(object sender, EventArgs e)
        {
            this.lab_Cancel.ForeColor = Color.DeepSkyBlue;
        }

        private void lab_Cancel_MouseLeave(object sender, EventArgs e)
        {
            this.lab_Cancel.ForeColor = Color.Black;
        }

        private void lab_Create_MouseEnter(object sender, EventArgs e)
        {
            this.lab_Create.ForeColor = Color.DeepSkyBlue;
        }

        private void lab_Create_MouseLeave(object sender, EventArgs e)
        {
            this.lab_Create.ForeColor = Color.Black;
        }

        private void lab_Login_MouseEnter(object sender, EventArgs e)
        {
            this.lab_Login.ForeColor = Color.DeepSkyBlue;
        }

        private void lab_Login_MouseLeave(object sender, EventArgs e)
        {
            this.lab_Login.ForeColor = Color.Black;
        }

        private void lab_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lab_Login_Click(object sender, EventArgs e)
        {
            if (this._firstTime()) return;

            var acc = new Account();
            acc.Username = this.tb_UserName.Text;
            acc.Password = this.tb_Password.Text;
            acc = AccountManager.getInstance().IsExist(acc);
            if (acc == null)
            {
                MessageBox.Show("Incorrect Username or Password!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (acc.Role == MemberRoles.CanCreate.ToString() || acc.Role == MemberRoles.CanEdit.ToString())
            {
                this._mainForm.CanEdit();
            }
            else
            {
                this._mainForm.CanView();
            }
            this._mainForm.Show();
            this.Hide();
        }

        private void lab_Create_Click(object sender, EventArgs e)
        {
            if (this._firstTime()) return;

            this._signupForm = new SignupForm();
            this._signupForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._mainForm != null)
            {
                this._mainForm.Close();
            }
        }
    }
}
