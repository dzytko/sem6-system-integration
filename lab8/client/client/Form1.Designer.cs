namespace client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username_label = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.jwt_label = new System.Windows.Forms.Label();
            this.jwt_textbox = new System.Windows.Forms.RichTextBox();
            this.get_user_count_label = new System.Windows.Forms.Label();
            this.get_user_count_button = new System.Windows.Forms.Button();
            this.get_random_prime_label = new System.Windows.Forms.Label();
            this.get_random_prime_button = new System.Windows.Forms.Button();
            this.get_users_label = new System.Windows.Forms.Label();
            this.get_users_button = new System.Windows.Forms.Button();
            this.get_user_count_res_label = new System.Windows.Forms.Label();
            this.get_random_prime_res_label = new System.Windows.Forms.Label();
            this.get_users_res_textbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(79, 9);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(63, 15);
            this.username_label.TabIndex = 0;
            this.username_label.Text = "Username:";
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(79, 27);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(100, 23);
            this.username_textbox.TabIndex = 1;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(79, 65);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(60, 15);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password:";
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(79, 83);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 23);
            this.password_textbox.TabIndex = 3;
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(79, 112);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(100, 23);
            this.login_button.TabIndex = 4;
            this.login_button.Text = "Log in";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // jwt_label
            // 
            this.jwt_label.AutoSize = true;
            this.jwt_label.Location = new System.Drawing.Point(12, 180);
            this.jwt_label.Name = "jwt_label";
            this.jwt_label.Size = new System.Drawing.Size(31, 15);
            this.jwt_label.TabIndex = 5;
            this.jwt_label.Text = "JWT:";
            // 
            // jwt_textbox
            // 
            this.jwt_textbox.Location = new System.Drawing.Point(12, 198);
            this.jwt_textbox.Name = "jwt_textbox";
            this.jwt_textbox.Size = new System.Drawing.Size(238, 175);
            this.jwt_textbox.TabIndex = 6;
            this.jwt_textbox.Text = "";
            // 
            // get_user_count_label
            // 
            this.get_user_count_label.AutoSize = true;
            this.get_user_count_label.Location = new System.Drawing.Point(295, 27);
            this.get_user_count_label.Name = "get_user_count_label";
            this.get_user_count_label.Size = new System.Drawing.Size(95, 15);
            this.get_user_count_label.TabIndex = 7;
            this.get_user_count_label.Text = "Get users count: ";
            // 
            // get_user_count_button
            // 
            this.get_user_count_button.Location = new System.Drawing.Point(427, 23);
            this.get_user_count_button.Name = "get_user_count_button";
            this.get_user_count_button.Size = new System.Drawing.Size(75, 23);
            this.get_user_count_button.TabIndex = 8;
            this.get_user_count_button.Text = "Send";
            this.get_user_count_button.UseVisualStyleBackColor = true;
            this.get_user_count_button.Click += new System.EventHandler(this.get_user_count_button_Click);
            // 
            // get_random_prime_label
            // 
            this.get_random_prime_label.AutoSize = true;
            this.get_random_prime_label.Location = new System.Drawing.Point(295, 65);
            this.get_random_prime_label.Name = "get_random_prime_label";
            this.get_random_prime_label.Size = new System.Drawing.Size(110, 15);
            this.get_random_prime_label.TabIndex = 9;
            this.get_random_prime_label.Text = "Get random prime: ";
            // 
            // get_random_prime_button
            // 
            this.get_random_prime_button.Location = new System.Drawing.Point(427, 61);
            this.get_random_prime_button.Name = "get_random_prime_button";
            this.get_random_prime_button.Size = new System.Drawing.Size(75, 23);
            this.get_random_prime_button.TabIndex = 10;
            this.get_random_prime_button.Text = "Send";
            this.get_random_prime_button.UseVisualStyleBackColor = true;
            this.get_random_prime_button.Click += new System.EventHandler(this.get_random_prime_button_Click);
            // 
            // get_users_label
            // 
            this.get_users_label.AutoSize = true;
            this.get_users_label.Location = new System.Drawing.Point(295, 102);
            this.get_users_label.Name = "get_users_label";
            this.get_users_label.Size = new System.Drawing.Size(58, 15);
            this.get_users_label.TabIndex = 11;
            this.get_users_label.Text = "Get users:";
            // 
            // get_users_button
            // 
            this.get_users_button.Location = new System.Drawing.Point(427, 98);
            this.get_users_button.Name = "get_users_button";
            this.get_users_button.Size = new System.Drawing.Size(75, 23);
            this.get_users_button.TabIndex = 12;
            this.get_users_button.Text = "Send";
            this.get_users_button.UseVisualStyleBackColor = true;
            this.get_users_button.Click += new System.EventHandler(this.get_users_button_Click);
            // 
            // get_user_count_res_label
            // 
            this.get_user_count_res_label.AutoSize = true;
            this.get_user_count_res_label.Location = new System.Drawing.Point(532, 27);
            this.get_user_count_res_label.Name = "get_user_count_res_label";
            this.get_user_count_res_label.Size = new System.Drawing.Size(0, 15);
            this.get_user_count_res_label.TabIndex = 13;
            // 
            // get_random_prime_res_label
            // 
            this.get_random_prime_res_label.AutoSize = true;
            this.get_random_prime_res_label.Location = new System.Drawing.Point(532, 65);
            this.get_random_prime_res_label.Name = "get_random_prime_res_label";
            this.get_random_prime_res_label.Size = new System.Drawing.Size(0, 15);
            this.get_random_prime_res_label.TabIndex = 14;
            // 
            // get_users_res_textbox
            // 
            this.get_users_res_textbox.Location = new System.Drawing.Point(532, 98);
            this.get_users_res_textbox.Name = "get_users_res_textbox";
            this.get_users_res_textbox.Size = new System.Drawing.Size(282, 340);
            this.get_users_res_textbox.TabIndex = 15;
            this.get_users_res_textbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 450);
            this.Controls.Add(this.get_users_res_textbox);
            this.Controls.Add(this.get_random_prime_res_label);
            this.Controls.Add(this.get_user_count_res_label);
            this.Controls.Add(this.get_users_button);
            this.Controls.Add(this.get_users_label);
            this.Controls.Add(this.get_random_prime_button);
            this.Controls.Add(this.get_random_prime_label);
            this.Controls.Add(this.get_user_count_button);
            this.Controls.Add(this.get_user_count_label);
            this.Controls.Add(this.jwt_textbox);
            this.Controls.Add(this.jwt_label);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.username_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label jwt_label;
        private System.Windows.Forms.RichTextBox jwt_textbox;
        private System.Windows.Forms.Label get_user_count_label;
        private System.Windows.Forms.Button get_user_count_button;
        private System.Windows.Forms.Label get_random_prime_label;
        private System.Windows.Forms.Button get_random_prime_button;
        private System.Windows.Forms.Label get_users_label;
        private System.Windows.Forms.Button get_users_button;
        private System.Windows.Forms.Label get_user_count_res_label;
        private System.Windows.Forms.Label get_random_prime_res_label;
        private System.Windows.Forms.RichTextBox get_users_res_textbox;
    }
}