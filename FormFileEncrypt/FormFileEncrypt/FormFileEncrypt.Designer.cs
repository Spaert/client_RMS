namespace FormFileEncrypt
{
    partial class FormFileEncrypt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileEncrypt));
            this.getTemplatesBtn = new System.Windows.Forms.Button();
            this.templateListBox = new System.Windows.Forms.ComboBox();
            this.filepathBox = new System.Windows.Forms.TextBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_info = new System.Windows.Forms.Button();
            this.btn_fileinfo = new System.Windows.Forms.Button();
            this.file_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // getTemplatesBtn
            // 
            this.getTemplatesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getTemplatesBtn.Location = new System.Drawing.Point(607, 14);
            this.getTemplatesBtn.Margin = new System.Windows.Forms.Padding(2);
            this.getTemplatesBtn.Name = "getTemplatesBtn";
            this.getTemplatesBtn.Size = new System.Drawing.Size(85, 43);
            this.getTemplatesBtn.TabIndex = 0;
            this.getTemplatesBtn.Text = "連線";
            this.getTemplatesBtn.UseVisualStyleBackColor = true;
            this.getTemplatesBtn.Click += new System.EventHandler(this.getTemplatesBtn_Click);
            // 
            // templateListBox
            // 
            this.templateListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Location = new System.Drawing.Point(11, 24);
            this.templateListBox.Margin = new System.Windows.Forms.Padding(2);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(538, 28);
            this.templateListBox.TabIndex = 1;
            this.templateListBox.Text = "請點選連線以取得範本";
            // 
            // filepathBox
            // 
            this.filepathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepathBox.Location = new System.Drawing.Point(11, 82);
            this.filepathBox.Margin = new System.Windows.Forms.Padding(2);
            this.filepathBox.Name = "filepathBox";
            this.filepathBox.ReadOnly = true;
            this.filepathBox.Size = new System.Drawing.Size(538, 26);
            this.filepathBox.TabIndex = 2;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileBtn.Location = new System.Drawing.Point(607, 75);
            this.selectFileBtn.Margin = new System.Windows.Forms.Padding(2);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(85, 41);
            this.selectFileBtn.TabIndex = 3;
            this.selectFileBtn.Text = "選取文件";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.AutoSize = true;
            this.encryptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptBtn.Image = ((System.Drawing.Image)(resources.GetObject("encryptBtn.Image")));
            this.encryptBtn.Location = new System.Drawing.Point(573, 139);
            this.encryptBtn.Margin = new System.Windows.Forms.Padding(2);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(59, 54);
            this.encryptBtn.TabIndex = 4;
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(559, 258);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(340, 44);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.AutoSize = true;
            this.DecryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecryptButton.Image = ((System.Drawing.Image)(resources.GetObject("DecryptButton.Image")));
            this.DecryptButton.Location = new System.Drawing.Point(634, 139);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(2);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(58, 54);
            this.DecryptButton.TabIndex = 6;
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(14, 307);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(897, 374);
            this.log.TabIndex = 7;
            this.log.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(697, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_info
            // 
            this.btn_info.AutoSize = true;
            this.btn_info.Image = ((System.Drawing.Image)(resources.GetObject("btn_info.Image")));
            this.btn_info.Location = new System.Drawing.Point(567, 16);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(35, 36);
            this.btn_info.TabIndex = 9;
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // btn_fileinfo
            // 
            this.btn_fileinfo.AutoSize = true;
            this.btn_fileinfo.Image = ((System.Drawing.Image)(resources.GetObject("btn_fileinfo.Image")));
            this.btn_fileinfo.Location = new System.Drawing.Point(567, 79);
            this.btn_fileinfo.Name = "btn_fileinfo";
            this.btn_fileinfo.Size = new System.Drawing.Size(35, 36);
            this.btn_fileinfo.TabIndex = 10;
            this.btn_fileinfo.UseVisualStyleBackColor = true;
            this.btn_fileinfo.Click += new System.EventHandler(this.btn_fileinfo_Click);
            // 
            // file_label
            // 
            this.file_label.AutoSize = true;
            this.file_label.Font = new System.Drawing.Font("新細明體", 12F);
            this.file_label.Location = new System.Drawing.Point(9, 139);
            this.file_label.Name = "file_label";
            this.file_label.Size = new System.Drawing.Size(0, 16);
            this.file_label.TabIndex = 11;
            // 
            // FormFileEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 693);
            this.Controls.Add(this.file_label);
            this.Controls.Add(this.btn_fileinfo);
            this.Controls.Add(this.btn_info);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.filepathBox);
            this.Controls.Add(this.templateListBox);
            this.Controls.Add(this.getTemplatesBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFileEncrypt";
            this.Text = "RMS 加解密";
            this.Load += new System.EventHandler(this.FormFileEncrypt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTemplatesBtn;
        private System.Windows.Forms.ComboBox templateListBox;
        private System.Windows.Forms.TextBox filepathBox;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btn_fileinfo;
        private System.Windows.Forms.Label file_label;
    }
}

