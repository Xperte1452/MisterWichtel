namespace WhatsWichtel
{
    partial class WichtelForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WichtelForm));
            this.listOfUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Email_label = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.startWichteln = new System.Windows.Forms.Button();
            this.lab_AnzTeilnehmer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labMailSend = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listOfUsers
            // 
            this.listOfUsers.FormattingEnabled = true;
            this.listOfUsers.Location = new System.Drawing.Point(13, 26);
            this.listOfUsers.Name = "listOfUsers";
            this.listOfUsers.Size = new System.Drawing.Size(216, 277);
            this.listOfUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teilnehmer";
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(236, 26);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(32, 13);
            this.Email_label.TabIndex = 2;
            this.Email_label.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(236, 43);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(152, 20);
            this.textBoxEmail.TabIndex = 3;
            this.textBoxEmail.Enter += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(236, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(235, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 33);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Entfernen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // startWichteln
            // 
            this.startWichteln.Location = new System.Drawing.Point(236, 260);
            this.startWichteln.Name = "startWichteln";
            this.startWichteln.Size = new System.Drawing.Size(97, 42);
            this.startWichteln.TabIndex = 6;
            this.startWichteln.Text = "Starte Wichteln";
            this.startWichteln.UseVisualStyleBackColor = true;
            this.startWichteln.Click += new System.EventHandler(this.startWichteln_Click);
            // 
            // lab_AnzTeilnehmer
            // 
            this.lab_AnzTeilnehmer.AutoSize = true;
            this.lab_AnzTeilnehmer.Location = new System.Drawing.Point(13, 310);
            this.lab_AnzTeilnehmer.Name = "lab_AnzTeilnehmer";
            this.lab_AnzTeilnehmer.Size = new System.Drawing.Size(97, 13);
            this.lab_AnzTeilnehmer.TabIndex = 7;
            this.lab_AnzTeilnehmer.Text = "Anzahl Teilnehmer:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(289, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // labMailSend
            // 
            this.labMailSend.AutoSize = true;
            this.labMailSend.Location = new System.Drawing.Point(275, 310);
            this.labMailSend.Name = "labMailSend";
            this.labMailSend.Size = new System.Drawing.Size(93, 13);
            this.labMailSend.TabIndex = 9;
            this.labMailSend.Text = "Emails versendet: ";
            // 
            // WichtelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(400, 332);
            this.Controls.Add(this.labMailSend);
            this.Controls.Add(this.lab_AnzTeilnehmer);
            this.Controls.Add(this.startWichteln);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.Email_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listOfUsers);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WichtelForm";
            this.Text = "Mister Wichtel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listOfUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button startWichteln;
        private System.Windows.Forms.Label lab_AnzTeilnehmer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labMailSend;
    }
}

