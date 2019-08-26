namespace FileEncryptor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Password = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileChooser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Path_Box = new System.Windows.Forms.TextBox();
            this.Cryptor = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(129, 116);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(217, 20);
            this.Password.TabIndex = 0;
            // 
            // State
            // 
            this.State.BackColor = System.Drawing.Color.Lime;
            this.State.Enabled = false;
            this.State.Font = new System.Drawing.Font("Arial", 9F);
            this.State.Location = new System.Drawing.Point(350, 49);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(50, 50);
            this.State.TabIndex = 1;
            this.State.Text = "Status";
            this.State.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(2, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter password:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileChooser
            // 
            this.FileChooser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FileChooser.Location = new System.Drawing.Point(29, 63);
            this.FileChooser.Name = "FileChooser";
            this.FileChooser.Size = new System.Drawing.Size(94, 22);
            this.FileChooser.TabIndex = 4;
            this.FileChooser.Text = "Choose File...";
            this.FileChooser.UseVisualStyleBackColor = true;
            this.FileChooser.Click += new System.EventHandler(this.FileChooser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose file to encrypt/decrypt. Press the \"Action\" button\nwhen GREEN to encrypt, " +
    "press when RED to decrypt";
            // 
            // Path_Box
            // 
            this.Path_Box.Location = new System.Drawing.Point(129, 65);
            this.Path_Box.Name = "Path_Box";
            this.Path_Box.ReadOnly = true;
            this.Path_Box.Size = new System.Drawing.Size(217, 20);
            this.Path_Box.TabIndex = 6;
            // 
            // Cryptor
            // 
            this.Cryptor.BackColor = System.Drawing.Color.Gray;
            this.Cryptor.Font = new System.Drawing.Font("Arial", 9F);
            this.Cryptor.Location = new System.Drawing.Point(350, 100);
            this.Cryptor.Name = "Cryptor";
            this.Cryptor.Size = new System.Drawing.Size(50, 50);
            this.Cryptor.TabIndex = 1;
            this.Cryptor.Text = "Action";
            this.Cryptor.UseVisualStyleBackColor = false;
            this.Cryptor.Click += new System.EventHandler(this.Cryptor_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.checkBox1.Location = new System.Drawing.Point(129, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Show password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 161);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Path_Box);
            this.Controls.Add(this.FileChooser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cryptor);
            this.Controls.Add(this.State);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "File Cryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button State;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button FileChooser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Path_Box;
        private System.Windows.Forms.Button Cryptor;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

