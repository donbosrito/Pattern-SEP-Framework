namespace SEPFramework.MemberShip
{
    partial class SignupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_Title = new System.Windows.Forms.Label();
            this.lab_NewUsername = new System.Windows.Forms.Label();
            this.tb_NewUsername = new System.Windows.Forms.TextBox();
            this.lab_NewPassword = new System.Windows.Forms.Label();
            this.lab_ConfirmPassword = new System.Windows.Forms.Label();
            this.panel_TypeOfAccount = new System.Windows.Forms.Panel();
            this.rbt_Admin = new System.Windows.Forms.RadioButton();
            this.rbt_CanEdit = new System.Windows.Forms.RadioButton();
            this.rbt_CanView = new System.Windows.Forms.RadioButton();
            this.lab_TypeOfAccount = new System.Windows.Forms.Label();
            this.mtb_NewPassword = new System.Windows.Forms.MaskedTextBox();
            this.mtb_ComfirmPassword = new System.Windows.Forms.MaskedTextBox();
            this.panel_NewInfor = new System.Windows.Forms.Panel();
            this.panel_AdminInfor = new System.Windows.Forms.Panel();
            this.mtb_AdminPassword = new System.Windows.Forms.MaskedTextBox();
            this.lab_AdminPassword = new System.Windows.Forms.Label();
            this.tb_AdminUsername = new System.Windows.Forms.TextBox();
            this.lab_AdminUsername = new System.Windows.Forms.Label();
            this.lab_AdminInfor = new System.Windows.Forms.Label();
            this.lab_AccountInfor = new System.Windows.Forms.Label();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel_TypeOfAccount.SuspendLayout();
            this.panel_NewInfor.SuspendLayout();
            this.panel_AdminInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_Title
            // 
            this.lab_Title.AutoSize = true;
            this.lab_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Title.Location = new System.Drawing.Point(84, 9);
            this.lab_Title.Name = "lab_Title";
            this.lab_Title.Size = new System.Drawing.Size(88, 25);
            this.lab_Title.TabIndex = 0;
            this.lab_Title.Text = "Sign Up";
            // 
            // lab_NewUsername
            // 
            this.lab_NewUsername.AutoSize = true;
            this.lab_NewUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_NewUsername.Location = new System.Drawing.Point(8, 15);
            this.lab_NewUsername.Name = "lab_NewUsername";
            this.lab_NewUsername.Size = new System.Drawing.Size(101, 16);
            this.lab_NewUsername.TabIndex = 1;
            this.lab_NewUsername.Text = "New Username";
            // 
            // tb_NewUsername
            // 
            this.tb_NewUsername.Location = new System.Drawing.Point(8, 34);
            this.tb_NewUsername.Name = "tb_NewUsername";
            this.tb_NewUsername.Size = new System.Drawing.Size(260, 20);
            this.tb_NewUsername.TabIndex = 2;
            // 
            // lab_NewPassword
            // 
            this.lab_NewPassword.AutoSize = true;
            this.lab_NewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_NewPassword.Location = new System.Drawing.Point(8, 66);
            this.lab_NewPassword.Name = "lab_NewPassword";
            this.lab_NewPassword.Size = new System.Drawing.Size(98, 16);
            this.lab_NewPassword.TabIndex = 3;
            this.lab_NewPassword.Text = "New Password";
            // 
            // lab_ConfirmPassword
            // 
            this.lab_ConfirmPassword.AutoSize = true;
            this.lab_ConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ConfirmPassword.Location = new System.Drawing.Point(9, 117);
            this.lab_ConfirmPassword.Name = "lab_ConfirmPassword";
            this.lab_ConfirmPassword.Size = new System.Drawing.Size(116, 16);
            this.lab_ConfirmPassword.TabIndex = 5;
            this.lab_ConfirmPassword.Text = "Confirm Password";
            // 
            // panel_TypeOfAccount
            // 
            this.panel_TypeOfAccount.Controls.Add(this.rbt_Admin);
            this.panel_TypeOfAccount.Controls.Add(this.rbt_CanEdit);
            this.panel_TypeOfAccount.Controls.Add(this.rbt_CanView);
            this.panel_TypeOfAccount.Location = new System.Drawing.Point(12, 188);
            this.panel_TypeOfAccount.Name = "panel_TypeOfAccount";
            this.panel_TypeOfAccount.Size = new System.Drawing.Size(256, 22);
            this.panel_TypeOfAccount.TabIndex = 7;
            // 
            // rbt_Admin
            // 
            this.rbt_Admin.AutoSize = true;
            this.rbt_Admin.Location = new System.Drawing.Point(183, 2);
            this.rbt_Admin.Name = "rbt_Admin";
            this.rbt_Admin.Size = new System.Drawing.Size(54, 17);
            this.rbt_Admin.TabIndex = 2;
            this.rbt_Admin.Text = "Admin";
            this.rbt_Admin.UseVisualStyleBackColor = true;
            // 
            // rbt_CanEdit
            // 
            this.rbt_CanEdit.AutoSize = true;
            this.rbt_CanEdit.Location = new System.Drawing.Point(93, 3);
            this.rbt_CanEdit.Name = "rbt_CanEdit";
            this.rbt_CanEdit.Size = new System.Drawing.Size(65, 17);
            this.rbt_CanEdit.TabIndex = 1;
            this.rbt_CanEdit.Text = "Can Edit";
            this.rbt_CanEdit.UseVisualStyleBackColor = true;
            // 
            // rbt_CanView
            // 
            this.rbt_CanView.AutoSize = true;
            this.rbt_CanView.Checked = true;
            this.rbt_CanView.Location = new System.Drawing.Point(4, 4);
            this.rbt_CanView.Name = "rbt_CanView";
            this.rbt_CanView.Size = new System.Drawing.Size(70, 17);
            this.rbt_CanView.TabIndex = 0;
            this.rbt_CanView.TabStop = true;
            this.rbt_CanView.Text = "Can View";
            this.rbt_CanView.UseVisualStyleBackColor = true;
            // 
            // lab_TypeOfAccount
            // 
            this.lab_TypeOfAccount.AutoSize = true;
            this.lab_TypeOfAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TypeOfAccount.Location = new System.Drawing.Point(8, 169);
            this.lab_TypeOfAccount.Name = "lab_TypeOfAccount";
            this.lab_TypeOfAccount.Size = new System.Drawing.Size(105, 16);
            this.lab_TypeOfAccount.TabIndex = 8;
            this.lab_TypeOfAccount.Text = "Type of Account";
            // 
            // mtb_NewPassword
            // 
            this.mtb_NewPassword.Location = new System.Drawing.Point(8, 86);
            this.mtb_NewPassword.Name = "mtb_NewPassword";
            this.mtb_NewPassword.PasswordChar = '*';
            this.mtb_NewPassword.Size = new System.Drawing.Size(260, 20);
            this.mtb_NewPassword.TabIndex = 9;
            // 
            // mtb_ComfirmPassword
            // 
            this.mtb_ComfirmPassword.Location = new System.Drawing.Point(8, 136);
            this.mtb_ComfirmPassword.Name = "mtb_ComfirmPassword";
            this.mtb_ComfirmPassword.PasswordChar = '*';
            this.mtb_ComfirmPassword.Size = new System.Drawing.Size(260, 20);
            this.mtb_ComfirmPassword.TabIndex = 10;
            // 
            // panel_NewInfor
            // 
            this.panel_NewInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_NewInfor.Controls.Add(this.mtb_ComfirmPassword);
            this.panel_NewInfor.Controls.Add(this.mtb_NewPassword);
            this.panel_NewInfor.Controls.Add(this.lab_TypeOfAccount);
            this.panel_NewInfor.Controls.Add(this.panel_TypeOfAccount);
            this.panel_NewInfor.Controls.Add(this.lab_ConfirmPassword);
            this.panel_NewInfor.Controls.Add(this.lab_NewPassword);
            this.panel_NewInfor.Controls.Add(this.tb_NewUsername);
            this.panel_NewInfor.Controls.Add(this.lab_NewUsername);
            this.panel_NewInfor.Location = new System.Drawing.Point(4, 66);
            this.panel_NewInfor.Name = "panel_NewInfor";
            this.panel_NewInfor.Size = new System.Drawing.Size(277, 223);
            this.panel_NewInfor.TabIndex = 11;
            // 
            // panel_AdminInfor
            // 
            this.panel_AdminInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_AdminInfor.Controls.Add(this.mtb_AdminPassword);
            this.panel_AdminInfor.Controls.Add(this.lab_AdminPassword);
            this.panel_AdminInfor.Controls.Add(this.tb_AdminUsername);
            this.panel_AdminInfor.Controls.Add(this.lab_AdminUsername);
            this.panel_AdminInfor.Location = new System.Drawing.Point(4, 324);
            this.panel_AdminInfor.Name = "panel_AdminInfor";
            this.panel_AdminInfor.Size = new System.Drawing.Size(277, 101);
            this.panel_AdminInfor.TabIndex = 12;
            // 
            // mtb_AdminPassword
            // 
            this.mtb_AdminPassword.Location = new System.Drawing.Point(7, 75);
            this.mtb_AdminPassword.Name = "mtb_AdminPassword";
            this.mtb_AdminPassword.PasswordChar = '*';
            this.mtb_AdminPassword.Size = new System.Drawing.Size(260, 20);
            this.mtb_AdminPassword.TabIndex = 13;
            // 
            // lab_AdminPassword
            // 
            this.lab_AdminPassword.AutoSize = true;
            this.lab_AdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_AdminPassword.Location = new System.Drawing.Point(7, 55);
            this.lab_AdminPassword.Name = "lab_AdminPassword";
            this.lab_AdminPassword.Size = new System.Drawing.Size(159, 16);
            this.lab_AdminPassword.TabIndex = 12;
            this.lab_AdminPassword.Text = "Administrator\'s Password";
            // 
            // tb_AdminUsername
            // 
            this.tb_AdminUsername.Location = new System.Drawing.Point(7, 23);
            this.tb_AdminUsername.Name = "tb_AdminUsername";
            this.tb_AdminUsername.Size = new System.Drawing.Size(260, 20);
            this.tb_AdminUsername.TabIndex = 11;
            // 
            // lab_AdminUsername
            // 
            this.lab_AdminUsername.AutoSize = true;
            this.lab_AdminUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_AdminUsername.Location = new System.Drawing.Point(7, 4);
            this.lab_AdminUsername.Name = "lab_AdminUsername";
            this.lab_AdminUsername.Size = new System.Drawing.Size(162, 16);
            this.lab_AdminUsername.TabIndex = 10;
            this.lab_AdminUsername.Text = "Administrator\'s Username";
            // 
            // lab_AdminInfor
            // 
            this.lab_AdminInfor.AutoSize = true;
            this.lab_AdminInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_AdminInfor.Location = new System.Drawing.Point(12, 305);
            this.lab_AdminInfor.Name = "lab_AdminInfor";
            this.lab_AdminInfor.Size = new System.Drawing.Size(197, 16);
            this.lab_AdminInfor.TabIndex = 13;
            this.lab_AdminInfor.Text = "Enter an administrator\'s account";
            // 
            // lab_AccountInfor
            // 
            this.lab_AccountInfor.AutoSize = true;
            this.lab_AccountInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_AccountInfor.Location = new System.Drawing.Point(10, 47);
            this.lab_AccountInfor.Name = "lab_AccountInfor";
            this.lab_AccountInfor.Size = new System.Drawing.Size(184, 16);
            this.lab_AccountInfor.TabIndex = 14;
            this.lab_AccountInfor.Text = "Enter new account information";
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignUp.Location = new System.Drawing.Point(125, 431);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(75, 34);
            this.btn_SignUp.TabIndex = 15;
            this.btn_SignUp.Text = "Sign Up";
            this.btn_SignUp.UseVisualStyleBackColor = true;
            this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(206, 431);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 34);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 474);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.lab_AccountInfor);
            this.Controls.Add(this.lab_AdminInfor);
            this.Controls.Add(this.panel_AdminInfor);
            this.Controls.Add(this.panel_NewInfor);
            this.Controls.Add(this.lab_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SignupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignupForm";
            this.panel_TypeOfAccount.ResumeLayout(false);
            this.panel_TypeOfAccount.PerformLayout();
            this.panel_NewInfor.ResumeLayout(false);
            this.panel_NewInfor.PerformLayout();
            this.panel_AdminInfor.ResumeLayout(false);
            this.panel_AdminInfor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Title;
        private System.Windows.Forms.Label lab_NewUsername;
        private System.Windows.Forms.TextBox tb_NewUsername;
        private System.Windows.Forms.Label lab_NewPassword;
        private System.Windows.Forms.Label lab_ConfirmPassword;
        private System.Windows.Forms.Panel panel_TypeOfAccount;
        private System.Windows.Forms.RadioButton rbt_Admin;
        private System.Windows.Forms.RadioButton rbt_CanEdit;
        private System.Windows.Forms.RadioButton rbt_CanView;
        private System.Windows.Forms.Label lab_TypeOfAccount;
        private System.Windows.Forms.MaskedTextBox mtb_NewPassword;
        private System.Windows.Forms.MaskedTextBox mtb_ComfirmPassword;
        private System.Windows.Forms.Panel panel_NewInfor;
        private System.Windows.Forms.Panel panel_AdminInfor;
        private System.Windows.Forms.MaskedTextBox mtb_AdminPassword;
        private System.Windows.Forms.Label lab_AdminPassword;
        private System.Windows.Forms.TextBox tb_AdminUsername;
        private System.Windows.Forms.Label lab_AdminUsername;
        private System.Windows.Forms.Label lab_AdminInfor;
        private System.Windows.Forms.Label lab_AccountInfor;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.Button btn_Cancel;
    }
}