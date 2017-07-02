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
    public partial class SignupForm : Form
    {
        private MemberRoles getRoleFormRadioButton()
        {
            if (this.rbt_Admin.Checked || AccountManager.getInstance().IsEmpty())
            {
                return MemberRoles.CanCreate;
            }
            else if (this.rbt_CanEdit.Checked)
            {
                return MemberRoles.CanEdit;
            }

            return MemberRoles.CanView;

        }

        public SignupForm()
        {
            InitializeComponent();
        }

        public void firstTime()
        {
            this.panel_AdminInfor.Enabled = false;
            this.panel_TypeOfAccount.Enabled = false;
            this.lab_AdminInfor.Enabled = false;
            this.lab_TypeOfAccount.Enabled = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            if (this.mtb_NewPassword.Text != this.mtb_ComfirmPassword.Text)
            {
                MessageBox.Show("Confirm Password isn't correct!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var new_username = this.tb_NewUsername.Text;
            var new_password = this.mtb_NewPassword.Text;

            if (new_username == "")
            {
                MessageBox.Show("Username is empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (new_password == "")
            {
                MessageBox.Show("Password is empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!AccountManager.getInstance().IsEmpty())
            {
                var admin = new Account();
                admin.Username = this.tb_AdminUsername.Text;
                admin.Password = this.mtb_AdminPassword.Text;
                admin = AccountManager.getInstance().IsExist(admin);

                if (admin == null || admin.Role != MemberRoles.CanCreate.ToString())
                {
                    MessageBox.Show("Administrator's account is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new Account();
                user.Username = this.tb_NewUsername.Text;
                user.Password = this.mtb_ComfirmPassword.Text;
                if (AccountManager.getInstance().IsExist(user) != null)
                {
                    MessageBox.Show("Username's already exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            

            var member = new Account();
            member.Username = new_username;
            member.Password = new_password;
            member.Role = this.getRoleFormRadioButton().ToString();

            MessageBox.Show("Sign up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AccountManager.getInstance().Add(member);
            this.Close();
        }
    }
}
