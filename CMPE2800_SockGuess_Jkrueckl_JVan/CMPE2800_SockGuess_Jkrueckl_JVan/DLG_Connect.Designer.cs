namespace CMPE2800_SockGuess_Jkrueckl_JVan
{
    partial class DLG_Connect
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
            this.components = new System.ComponentModel.Container();
            this.UI_B_Cancel = new System.Windows.Forms.Button();
            this.UI_B_Connect = new System.Windows.Forms.Button();
            this.UI_L_Status = new System.Windows.Forms.Label();
            this.UI_L_Port = new System.Windows.Forms.Label();
            this.UI_L_Addr = new System.Windows.Forms.Label();
            this.UI_TB_Port = new System.Windows.Forms.TextBox();
            this.UI_TB_Address = new System.Windows.Forms.TextBox();
            this.UI_L_Timeout = new System.Windows.Forms.Label();
            this.UI_Tim_Timout = new System.Windows.Forms.Timer(this.components);
            this.UI_PB_Connecting = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // UI_B_Cancel
            // 
            this.UI_B_Cancel.Location = new System.Drawing.Point(211, 90);
            this.UI_B_Cancel.Name = "UI_B_Cancel";
            this.UI_B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.UI_B_Cancel.TabIndex = 12;
            this.UI_B_Cancel.Text = "Cancel";
            this.UI_B_Cancel.UseVisualStyleBackColor = true;
            this.UI_B_Cancel.Click += new System.EventHandler(this.UI_B_Cancel_Click);
            // 
            // UI_B_Connect
            // 
            this.UI_B_Connect.Location = new System.Drawing.Point(112, 90);
            this.UI_B_Connect.Name = "UI_B_Connect";
            this.UI_B_Connect.Size = new System.Drawing.Size(75, 23);
            this.UI_B_Connect.TabIndex = 10;
            this.UI_B_Connect.Text = "Connect";
            this.UI_B_Connect.UseVisualStyleBackColor = true;
            this.UI_B_Connect.Click += new System.EventHandler(this.UI_B_Connect_Click);
            // 
            // UI_L_Status
            // 
            this.UI_L_Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UI_L_Status.Location = new System.Drawing.Point(16, 35);
            this.UI_L_Status.Name = "UI_L_Status";
            this.UI_L_Status.Size = new System.Drawing.Size(274, 21);
            this.UI_L_Status.TabIndex = 14;
            this.UI_L_Status.Text = "Status";
            this.UI_L_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_L_Port
            // 
            this.UI_L_Port.AutoSize = true;
            this.UI_L_Port.Location = new System.Drawing.Point(180, 15);
            this.UI_L_Port.Name = "UI_L_Port";
            this.UI_L_Port.Size = new System.Drawing.Size(29, 13);
            this.UI_L_Port.TabIndex = 13;
            this.UI_L_Port.Text = "Port:";
            // 
            // UI_L_Addr
            // 
            this.UI_L_Addr.AutoSize = true;
            this.UI_L_Addr.Location = new System.Drawing.Point(12, 15);
            this.UI_L_Addr.Name = "UI_L_Addr";
            this.UI_L_Addr.Size = new System.Drawing.Size(48, 13);
            this.UI_L_Addr.TabIndex = 11;
            this.UI_L_Addr.Text = "Address:";
            // 
            // UI_TB_Port
            // 
            this.UI_TB_Port.Location = new System.Drawing.Point(215, 12);
            this.UI_TB_Port.Name = "UI_TB_Port";
            this.UI_TB_Port.ReadOnly = true;
            this.UI_TB_Port.Size = new System.Drawing.Size(75, 20);
            this.UI_TB_Port.TabIndex = 9;
            this.UI_TB_Port.Text = "1666";
            this.UI_TB_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UI_TB_Address
            // 
            this.UI_TB_Address.Location = new System.Drawing.Point(66, 12);
            this.UI_TB_Address.Name = "UI_TB_Address";
            this.UI_TB_Address.Size = new System.Drawing.Size(108, 20);
            this.UI_TB_Address.TabIndex = 8;
            // 
            // UI_L_Timeout
            // 
            this.UI_L_Timeout.AutoSize = true;
            this.UI_L_Timeout.BackColor = System.Drawing.Color.Transparent;
            this.UI_L_Timeout.Location = new System.Drawing.Point(13, 68);
            this.UI_L_Timeout.Name = "UI_L_Timeout";
            this.UI_L_Timeout.Size = new System.Drawing.Size(48, 13);
            this.UI_L_Timeout.TabIndex = 16;
            this.UI_L_Timeout.Text = "Timeout:";
            // 
            // UI_Tim_Timout
            // 
            this.UI_Tim_Timout.Tick += new System.EventHandler(this.UI_Tim_Timout_Tick);
            // 
            // UI_PB_Connecting
            // 
            this.UI_PB_Connecting.Enabled = false;
            this.UI_PB_Connecting.Location = new System.Drawing.Point(66, 64);
            this.UI_PB_Connecting.Maximum = 180;
            this.UI_PB_Connecting.Name = "UI_PB_Connecting";
            this.UI_PB_Connecting.Size = new System.Drawing.Size(224, 20);
            this.UI_PB_Connecting.Step = 1;
            this.UI_PB_Connecting.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.UI_PB_Connecting.TabIndex = 15;
            // 
            // DLG_Connect
            // 
            this.AcceptButton = this.UI_B_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 128);
            this.Controls.Add(this.UI_L_Timeout);
            this.Controls.Add(this.UI_PB_Connecting);
            this.Controls.Add(this.UI_B_Cancel);
            this.Controls.Add(this.UI_B_Connect);
            this.Controls.Add(this.UI_L_Status);
            this.Controls.Add(this.UI_L_Port);
            this.Controls.Add(this.UI_L_Addr);
            this.Controls.Add(this.UI_TB_Port);
            this.Controls.Add(this.UI_TB_Address);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DLG_Connect";
            this.Text = "Connect To Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UI_B_Cancel;
        private System.Windows.Forms.Button UI_B_Connect;
        private System.Windows.Forms.Label UI_L_Status;
        private System.Windows.Forms.Label UI_L_Port;
        private System.Windows.Forms.Label UI_L_Addr;
        private System.Windows.Forms.TextBox UI_TB_Port;
        private System.Windows.Forms.TextBox UI_TB_Address;
        private System.Windows.Forms.Label UI_L_Timeout;
        private System.Windows.Forms.Timer UI_Tim_Timout;
        private System.Windows.Forms.ProgressBar UI_PB_Connecting;
    }
}