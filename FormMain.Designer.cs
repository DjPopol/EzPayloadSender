namespace EzPayloadSender
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            groupBoxConnection = new GroupBox();
            labelPort = new Label();
            textBoxPort = new TextBox();
            textBoxIpAddress = new TextBox();
            labelIp = new Label();
            groupBoxBrowse = new GroupBox();
            labelPayload = new Label();
            buttonBrowse = new Button();
            groupBoxSend = new GroupBox();
            buttonSend = new Button();
            buttonCancel = new Button();
            pictureBoxGitHub = new PictureBox();
            labelDjPopol = new Label();
            menuStrip1 = new MenuStrip();
            updateToolStripMenuItem = new ToolStripMenuItem();
            groupBoxConnection.SuspendLayout();
            groupBoxBrowse.SuspendLayout();
            groupBoxSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGitHub).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(labelPort);
            groupBoxConnection.Controls.Add(textBoxPort);
            groupBoxConnection.Controls.Add(textBoxIpAddress);
            groupBoxConnection.Controls.Add(labelIp);
            groupBoxConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxConnection.ForeColor = Color.White;
            groupBoxConnection.Location = new Point(11, 25);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Size = new Size(278, 50);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "PlayStation";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(190, 21);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(37, 15);
            labelPort.TabIndex = 2;
            labelPort.Text = "Port :";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(228, 18);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(43, 23);
            textBoxPort.TabIndex = 1;
            textBoxPort.TextChanged += TextBoxPort_TextChanged;
            textBoxPort.KeyPress += TextBoxPort_KeyPress;
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Location = new Point(80, 18);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.Size = new Size(104, 23);
            textBoxIpAddress.TabIndex = 0;
            textBoxIpAddress.TextChanged += TextBoxIpAddress_TextChanged;
            textBoxIpAddress.KeyPress += TextBoxIpAddress_KeyPress;
            // 
            // labelIp
            // 
            labelIp.AutoSize = true;
            labelIp.BackColor = Color.Transparent;
            labelIp.Location = new Point(6, 21);
            labelIp.Name = "labelIp";
            labelIp.Size = new Size(74, 15);
            labelIp.TabIndex = 3;
            labelIp.Text = "Ip Address : ";
            // 
            // groupBoxBrowse
            // 
            groupBoxBrowse.Controls.Add(labelPayload);
            groupBoxBrowse.Controls.Add(buttonBrowse);
            groupBoxBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxBrowse.ForeColor = Color.White;
            groupBoxBrowse.Location = new Point(11, 81);
            groupBoxBrowse.Name = "groupBoxBrowse";
            groupBoxBrowse.Size = new Size(278, 75);
            groupBoxBrowse.TabIndex = 1;
            groupBoxBrowse.TabStop = false;
            groupBoxBrowse.Text = "Payload";
            // 
            // labelPayload
            // 
            labelPayload.BackColor = Color.White;
            labelPayload.BorderStyle = BorderStyle.Fixed3D;
            labelPayload.ForeColor = Color.DodgerBlue;
            labelPayload.Location = new Point(6, 19);
            labelPayload.Name = "labelPayload";
            labelPayload.Size = new Size(265, 23);
            labelPayload.TabIndex = 7;
            labelPayload.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonBrowse
            // 
            buttonBrowse.ForeColor = Color.DodgerBlue;
            buttonBrowse.Location = new Point(6, 45);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(266, 23);
            buttonBrowse.TabIndex = 5;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += ButtonBrowse_Click;
            // 
            // groupBoxSend
            // 
            groupBoxSend.Controls.Add(buttonSend);
            groupBoxSend.Controls.Add(buttonCancel);
            groupBoxSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxSend.ForeColor = Color.White;
            groupBoxSend.Location = new Point(11, 162);
            groupBoxSend.Name = "groupBoxSend";
            groupBoxSend.Size = new Size(278, 54);
            groupBoxSend.TabIndex = 6;
            groupBoxSend.TabStop = false;
            groupBoxSend.Text = "Send Payload";
            // 
            // buttonSend
            // 
            buttonSend.ForeColor = Color.DodgerBlue;
            buttonSend.Location = new Point(10, 22);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(262, 23);
            buttonSend.TabIndex = 5;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += ButtonSend_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.ForeColor = Color.DodgerBlue;
            buttonCancel.Location = new Point(9, 22);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(262, 23);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // pictureBoxGitHub
            // 
            pictureBoxGitHub.BackColor = Color.Transparent;
            pictureBoxGitHub.Cursor = Cursors.Hand;
            pictureBoxGitHub.Image = Properties.Resources.github;
            pictureBoxGitHub.Location = new Point(11, 222);
            pictureBoxGitHub.Name = "pictureBoxGitHub";
            pictureBoxGitHub.Size = new Size(100, 25);
            pictureBoxGitHub.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGitHub.TabIndex = 7;
            pictureBoxGitHub.TabStop = false;
            pictureBoxGitHub.Click += PictureBoxGitHub_Click;
            // 
            // labelDjPopol
            // 
            labelDjPopol.AutoSize = true;
            labelDjPopol.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelDjPopol.ForeColor = Color.White;
            labelDjPopol.Location = new Point(137, 222);
            labelDjPopol.Name = "labelDjPopol";
            labelDjPopol.Size = new Size(152, 25);
            labelDjPopol.TabIndex = 8;
            labelDjPopol.Text = "©2024 DjPopol";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { updateToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(301, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateToolStripMenuItem.ForeColor = Color.DodgerBlue;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(60, 20);
            updateToolStripMenuItem.Text = "Update";
            updateToolStripMenuItem.Click += UpdateToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(301, 256);
            Controls.Add(labelDjPopol);
            Controls.Add(pictureBoxGitHub);
            Controls.Add(groupBoxSend);
            Controls.Add(groupBoxBrowse);
            Controls.Add(groupBoxConnection);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Ez Payload Sender";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            groupBoxBrowse.ResumeLayout(false);
            groupBoxSend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGitHub).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxConnection;
        private TextBox textBoxPort;
        private TextBox textBoxIpAddress;
        private GroupBox groupBoxBrowse;
        private Button buttonBrowse;
        private GroupBox groupBoxSend;
        private Button buttonSend;
        private Label labelPayload;
        private Label labelIp;
        private Label labelPort;
        private PictureBox pictureBoxGitHub;
        private Label labelDjPopol;
        private Button buttonCancel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
    }
}
