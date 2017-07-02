using SEPFramework.Model;

namespace SEPFramework.MemberShip
{
    partial class LoginForm<T> where T : BaseModel, new()
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
            this.lab_UserName = new System.Windows.Forms.Label();
            this.lab_Password = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.MaskedTextBox();
            this.lab_Title = new System.Windows.Forms.Label();
            this.lab_Login = new System.Windows.Forms.Label();
            this.lab_Create = new System.Windows.Forms.Label();
            this.lab_Cancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_UserName
            // 
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_UserName.Location = new System.Drawing.Point(12, 56);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(98, 20);
            this.lab_UserName.TabIndex = 0;
            this.lab_UserName.Text = "User\'s name";
            // 
            // lab_Password
            // 
            this.lab_Password.AutoSize = true;
            this.lab_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Password.Location = new System.Drawing.Point(12, 111);
            this.lab_Password.Name = "lab_Password";
            this.lab_Password.Size = new System.Drawing.Size(78, 20);
            this.lab_Password.TabIndex = 1;
            this.lab_Password.Text = "Password";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(15, 79);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(247, 20);
            this.tb_UserName.TabIndex = 2;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(16, 134);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(246, 20);
            this.tb_Password.TabIndex = 3;
            // 
            // lab_Title
            // 
            this.lab_Title.AutoSize = true;
            this.lab_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Title.Location = new System.Drawing.Point(110, 22);
            this.lab_Title.Name = "lab_Title";
            this.lab_Title.Size = new System.Drawing.Size(54, 25);
            this.lab_Title.TabIndex = 4;
            this.lab_Title.Text = "SEP";
            // 
            // lab_Login
            // 
            this.lab_Login.AutoSize = true;
            this.lab_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Login.Location = new System.Drawing.Point(12, 168);
            this.lab_Login.Name = "lab_Login";
            this.lab_Login.Size = new System.Drawing.Size(48, 20);
            this.lab_Login.TabIndex = 5;
            this.lab_Login.Text = "Login";
            this.lab_Login.Click += new System.EventHandler(this.lab_Login_Click);
            this.lab_Login.MouseEnter += new System.EventHandler(this.lab_Login_MouseEnter);
            this.lab_Login.MouseLeave += new System.EventHandler(this.lab_Login_MouseLeave);
            // 
            // lab_Create
            // 
            this.lab_Create.AutoSize = true;
            this.lab_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Create.Location = new System.Drawing.Point(12, 188);
            this.lab_Create.Name = "lab_Create";
            this.lab_Create.Size = new System.Drawing.Size(131, 20);
            this.lab_Create.TabIndex = 6;
            this.lab_Create.Text = "Create a account";
            this.lab_Create.Click += new System.EventHandler(this.lab_Create_Click);
            this.lab_Create.MouseEnter += new System.EventHandler(this.lab_Create_MouseEnter);
            this.lab_Create.MouseLeave += new System.EventHandler(this.lab_Create_MouseLeave);
            // 
            // lab_Cancel
            // 
            this.lab_Cancel.AutoSize = true;
            this.lab_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Cancel.Location = new System.Drawing.Point(12, 207);
            this.lab_Cancel.Name = "lab_Cancel";
            this.lab_Cancel.Size = new System.Drawing.Size(58, 20);
            this.lab_Cancel.TabIndex = 7;
            this.lab_Cancel.Text = "Cancel";
            this.lab_Cancel.Click += new System.EventHandler(this.lab_Cancel_Click);
            this.lab_Cancel.MouseEnter += new System.EventHandler(this.lab_Cancel_MouseEnter);
            this.lab_Cancel.MouseLeave += new System.EventHandler(this.lab_Cancel_MouseLeave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(280, 236);
            this.Controls.Add(this.lab_Cancel);
            this.Controls.Add(this.lab_Create);
            this.Controls.Add(this.lab_Login);
            this.Controls.Add(this.lab_Title);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.lab_Password);
            this.Controls.Add(this.lab_UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_UserName;
        private System.Windows.Forms.Label lab_Password;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.MaskedTextBox tb_Password;
        private System.Windows.Forms.Label lab_Title;
        private System.Windows.Forms.Label lab_Login;
        private System.Windows.Forms.Label lab_Create;
        private System.Windows.Forms.Label lab_Cancel;
    }
}