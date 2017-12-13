namespace ApenasTeste
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathDB = new System.Windows.Forms.TextBox();
            this.txtUserDB = new System.Windows.Forms.TextBox();
            this.txtPwdDB = new System.Windows.Forms.TextBox();
            this.txtPathWebService = new System.Windows.Forms.TextBox();
            this.txtDelayProcess = new System.Windows.Forms.TextBox();
            this.txtPathLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSaveXML = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(407, 205);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(508, 205);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caminho banco de dados";
            // 
            // txtPathDB
            // 
            this.txtPathDB.Location = new System.Drawing.Point(156, 9);
            this.txtPathDB.Name = "txtPathDB";
            this.txtPathDB.Size = new System.Drawing.Size(427, 20);
            this.txtPathDB.TabIndex = 3;
            // 
            // txtUserDB
            // 
            this.txtUserDB.Location = new System.Drawing.Point(156, 35);
            this.txtUserDB.Name = "txtUserDB";
            this.txtUserDB.Size = new System.Drawing.Size(427, 20);
            this.txtUserDB.TabIndex = 4;
            // 
            // txtPwdDB
            // 
            this.txtPwdDB.Location = new System.Drawing.Point(156, 61);
            this.txtPwdDB.Name = "txtPwdDB";
            this.txtPwdDB.PasswordChar = '*';
            this.txtPwdDB.Size = new System.Drawing.Size(427, 20);
            this.txtPwdDB.TabIndex = 5;
            // 
            // txtPathWebService
            // 
            this.txtPathWebService.Location = new System.Drawing.Point(156, 87);
            this.txtPathWebService.Name = "txtPathWebService";
            this.txtPathWebService.Size = new System.Drawing.Size(427, 20);
            this.txtPathWebService.TabIndex = 6;
            // 
            // txtDelayProcess
            // 
            this.txtDelayProcess.Location = new System.Drawing.Point(156, 113);
            this.txtDelayProcess.Name = "txtDelayProcess";
            this.txtDelayProcess.Size = new System.Drawing.Size(60, 20);
            this.txtDelayProcess.TabIndex = 7;
            // 
            // txtPathLog
            // 
            this.txtPathLog.Location = new System.Drawing.Point(156, 139);
            this.txtPathLog.Name = "txtPathLog";
            this.txtPathLog.Size = new System.Drawing.Size(427, 20);
            this.txtPathLog.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuário banco de dados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Senha banco de dados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Caminho Web Service";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Delay processo (minutos)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Caminho Log";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Salva XML";
            // 
            // cbSaveXML
            // 
            this.cbSaveXML.AutoSize = true;
            this.cbSaveXML.Location = new System.Drawing.Point(156, 169);
            this.cbSaveXML.Name = "cbSaveXML";
            this.cbSaveXML.Size = new System.Drawing.Size(15, 14);
            this.cbSaveXML.TabIndex = 15;
            this.cbSaveXML.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 250);
            this.Controls.Add(this.cbSaveXML);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathLog);
            this.Controls.Add(this.txtDelayProcess);
            this.Controls.Add(this.txtPathWebService);
            this.Controls.Add(this.txtPwdDB);
            this.Controls.Add(this.txtUserDB);
            this.Controls.Add(this.txtPathDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnSalvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.Text = "Configuração";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathDB;
        private System.Windows.Forms.TextBox txtUserDB;
        private System.Windows.Forms.TextBox txtPwdDB;
        private System.Windows.Forms.TextBox txtPathWebService;
        private System.Windows.Forms.TextBox txtDelayProcess;
        private System.Windows.Forms.TextBox txtPathLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbSaveXML;
    }
}