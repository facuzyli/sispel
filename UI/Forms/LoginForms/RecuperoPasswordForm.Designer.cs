using System.Drawing;

namespace UI.Forms.LoginForms
{
    partial class RecuperoPasswordForm
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
            this.labelUserPrompt = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserPrompt
            // 
            this.labelUserPrompt.AutoSize = true;
            this.labelUserPrompt.Location = new System.Drawing.Point(21, 25);
            this.labelUserPrompt.Name = "labelUserPrompt";
            this.labelUserPrompt.Size = new System.Drawing.Size(98, 13);
            this.labelUserPrompt.TabIndex = 0;
            this.labelUserPrompt.Tag = "IngresarElUsuario:";
            this.labelUserPrompt.Text = "Ingresar el Usuario:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(150, 25);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(200, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(24, 113);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(131, 30);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Tag = "RecuperarContraseña";
            this.buttonSend.Text = "Recupera Contraseña";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(50, 130);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            label1.Visible = false;
           
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Tag = "IngresarElToken";
            this.label2.Text = "Ingresar el Token:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 195);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 7;
            this.button1.Tag = "EnviarToken";
            this.button1.Text = "Enviar Token";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecuperoPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelUserPrompt);
            this.Name = "RecuperoPasswordForm";
            this.Text = "RecuperoPasswordForm";
            this.Load += new System.EventHandler(this.RecuperoPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUserPrompt;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}