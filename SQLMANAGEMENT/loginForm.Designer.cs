namespace SQLMANAGEMENT
{
    partial class loginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserPasswordLoginLabel = new System.Windows.Forms.TextBox();
            this.UserNameLoginLabel = new System.Windows.Forms.TextBox();
            this.enterLoginButton = new System.Windows.Forms.Button();
            this.DataBaseNameLoginLabel = new System.Windows.Forms.TextBox();
            this.ServerNameLoginLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topLabelInLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 468);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.UserPasswordLoginLabel);
            this.panel3.Controls.Add(this.UserNameLoginLabel);
            this.panel3.Controls.Add(this.enterLoginButton);
            this.panel3.Controls.Add(this.DataBaseNameLoginLabel);
            this.panel3.Controls.Add(this.ServerNameLoginLabel);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(18, 163);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 291);
            this.panel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(78, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Имя сервера: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Имя Базы данных: ";
            // 
            // UserPasswordLoginLabel
            // 
            this.UserPasswordLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordLoginLabel.Location = new System.Drawing.Point(291, 180);
            this.UserPasswordLoginLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserPasswordLoginLabel.Name = "UserPasswordLoginLabel";
            this.UserPasswordLoginLabel.PasswordChar = '*';
            this.UserPasswordLoginLabel.Size = new System.Drawing.Size(402, 35);
            this.UserPasswordLoginLabel.TabIndex = 7;
            this.UserPasswordLoginLabel.UseSystemPasswordChar = true;
            // 
            // UserNameLoginLabel
            // 
            this.UserNameLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLoginLabel.Location = new System.Drawing.Point(291, 131);
            this.UserNameLoginLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserNameLoginLabel.Name = "UserNameLoginLabel";
            this.UserNameLoginLabel.Size = new System.Drawing.Size(402, 35);
            this.UserNameLoginLabel.TabIndex = 6;
            // 
            // enterLoginButton
            // 
            this.enterLoginButton.BackColor = System.Drawing.Color.Tan;
            this.enterLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.Tan;
            this.enterLoginButton.FlatAppearance.BorderSize = 0;
            this.enterLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterLoginButton.Location = new System.Drawing.Point(498, 238);
            this.enterLoginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enterLoginButton.Name = "enterLoginButton";
            this.enterLoginButton.Size = new System.Drawing.Size(182, 40);
            this.enterLoginButton.TabIndex = 5;
            this.enterLoginButton.Text = "Войти";
            this.enterLoginButton.UseVisualStyleBackColor = false;
            this.enterLoginButton.Click += new System.EventHandler(this.enterLoginButton_Click);
            // 
            // DataBaseNameLoginLabel
            // 
            this.DataBaseNameLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataBaseNameLoginLabel.Location = new System.Drawing.Point(291, 82);
            this.DataBaseNameLoginLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DataBaseNameLoginLabel.Name = "DataBaseNameLoginLabel";
            this.DataBaseNameLoginLabel.Size = new System.Drawing.Size(402, 35);
            this.DataBaseNameLoginLabel.TabIndex = 4;
            // 
            // ServerNameLoginLabel
            // 
            this.ServerNameLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerNameLoginLabel.Location = new System.Drawing.Point(291, 32);
            this.ServerNameLoginLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServerNameLoginLabel.Name = "ServerNameLoginLabel";
            this.ServerNameLoginLabel.Size = new System.Drawing.Size(402, 35);
            this.ServerNameLoginLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(153, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(171, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.topLabelInLogin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 154);
            this.panel2.TabIndex = 0;
            // 
            // topLabelInLogin
            // 
            this.topLabelInLogin.BackColor = System.Drawing.Color.Tan;
            this.topLabelInLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLabelInLogin.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topLabelInLogin.Location = new System.Drawing.Point(0, 0);
            this.topLabelInLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topLabelInLogin.Name = "topLabelInLogin";
            this.topLabelInLogin.Size = new System.Drawing.Size(735, 154);
            this.topLabelInLogin.TabIndex = 0;
            this.topLabelInLogin.Text = "Авторизация пользователя";
            this.topLabelInLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 468);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "loginForm";
            this.Text = "Authorization";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label topLabelInLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox DataBaseNameLoginLabel;
        private System.Windows.Forms.TextBox ServerNameLoginLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button enterLoginButton;
        private System.Windows.Forms.TextBox UserPasswordLoginLabel;
        private System.Windows.Forms.TextBox UserNameLoginLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}

