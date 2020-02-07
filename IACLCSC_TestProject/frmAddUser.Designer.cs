namespace IACLCSC_TestProject
{
    partial class frmAddUser
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.mskPass = new System.Windows.Forms.MaskedTextBox();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsertype = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.mskConfirmPass = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(74, 196);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(109, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(251, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // mskPass
            // 
            this.mskPass.Location = new System.Drawing.Point(109, 83);
            this.mskPass.Name = "mskPass";
            this.mskPass.PasswordChar = '*';
            this.mskPass.Size = new System.Drawing.Size(251, 20);
            this.mskPass.TabIndex = 4;
            this.mskPass.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(109, 135);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(251, 21);
            this.cmbUserType.TabIndex = 5;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 86);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // lblUsertype
            // 
            this.lblUsertype.AutoSize = true;
            this.lblUsertype.Location = new System.Drawing.Point(12, 138);
            this.lblUsertype.Name = "lblUsertype";
            this.lblUsertype.Size = new System.Drawing.Size(56, 13);
            this.lblUsertype.TabIndex = 7;
            this.lblUsertype.Text = "User Type";
            this.lblUsertype.Click += new System.EventHandler(this.lblUsertype_Click);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(12, 112);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(91, 13);
            this.lblConfirm.TabIndex = 9;
            this.lblConfirm.Text = "Confirm Password";
            this.lblConfirm.Click += new System.EventHandler(this.lblConfirm_Click);
            // 
            // mskConfirmPass
            // 
            this.mskConfirmPass.Location = new System.Drawing.Point(109, 109);
            this.mskConfirmPass.Name = "mskConfirmPass";
            this.mskConfirmPass.PasswordChar = '*';
            this.mskConfirmPass.Size = new System.Drawing.Size(251, 20);
            this.mskConfirmPass.TabIndex = 8;
            this.mskConfirmPass.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox2_MaskInputRejected);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 236);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.mskConfirmPass);
            this.Controls.Add(this.lblUsertype);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.mskPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddUser);
            this.Name = "frmAddUser";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.MaskedTextBox mskPass;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsertype;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.MaskedTextBox mskConfirmPass;
    }
}