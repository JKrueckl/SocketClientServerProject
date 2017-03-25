namespace CMPE2800_SockGuess_Jkrueckl_JVan
{
    partial class Form_Client
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
            this.UI_TB_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_TBr_Guess = new System.Windows.Forms.TrackBar();
            this.UI_LB_TBrValue = new System.Windows.Forms.Label();
            this.UI_LB_Min = new System.Windows.Forms.Label();
            this.UI_LB_Max = new System.Windows.Forms.Label();
            this.UI_B_ManageConnection = new System.Windows.Forms.Button();
            this.UI_B_Guess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TBr_Guess)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_TB_Status
            // 
            this.UI_TB_Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TB_Status.Location = new System.Drawing.Point(53, 12);
            this.UI_TB_Status.Name = "UI_TB_Status";
            this.UI_TB_Status.ReadOnly = true;
            this.UI_TB_Status.Size = new System.Drawing.Size(821, 20);
            this.UI_TB_Status.TabIndex = 3;
            this.UI_TB_Status.Text = "Connect to a server to play.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // UI_TBr_Guess
            // 
            this.UI_TBr_Guess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TBr_Guess.Location = new System.Drawing.Point(12, 38);
            this.UI_TBr_Guess.Maximum = 1000;
            this.UI_TBr_Guess.Minimum = 1;
            this.UI_TBr_Guess.Name = "UI_TBr_Guess";
            this.UI_TBr_Guess.Size = new System.Drawing.Size(862, 45);
            this.UI_TBr_Guess.TabIndex = 2;
            this.UI_TBr_Guess.TickFrequency = 20;
            this.UI_TBr_Guess.Value = 500;
            this.UI_TBr_Guess.ValueChanged += new System.EventHandler(this.UI_TBr_Guess_ValueChanged);
            // 
            // UI_LB_TBrValue
            // 
            this.UI_LB_TBrValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LB_TBrValue.Location = new System.Drawing.Point(36, 70);
            this.UI_LB_TBrValue.Name = "UI_LB_TBrValue";
            this.UI_LB_TBrValue.Size = new System.Drawing.Size(810, 13);
            this.UI_LB_TBrValue.TabIndex = 6;
            this.UI_LB_TBrValue.Text = "500";
            this.UI_LB_TBrValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_LB_Min
            // 
            this.UI_LB_Min.AutoSize = true;
            this.UI_LB_Min.Location = new System.Drawing.Point(17, 70);
            this.UI_LB_Min.Name = "UI_LB_Min";
            this.UI_LB_Min.Size = new System.Drawing.Size(13, 13);
            this.UI_LB_Min.TabIndex = 5;
            this.UI_LB_Min.Text = "1";
            // 
            // UI_LB_Max
            // 
            this.UI_LB_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LB_Max.AutoSize = true;
            this.UI_LB_Max.Location = new System.Drawing.Point(852, 70);
            this.UI_LB_Max.Name = "UI_LB_Max";
            this.UI_LB_Max.Size = new System.Drawing.Size(31, 13);
            this.UI_LB_Max.TabIndex = 7;
            this.UI_LB_Max.Text = "1000";
            // 
            // UI_B_ManageConnection
            // 
            this.UI_B_ManageConnection.Location = new System.Drawing.Point(12, 89);
            this.UI_B_ManageConnection.Name = "UI_B_ManageConnection";
            this.UI_B_ManageConnection.Size = new System.Drawing.Size(75, 23);
            this.UI_B_ManageConnection.TabIndex = 0;
            this.UI_B_ManageConnection.Text = "Connect";
            this.UI_B_ManageConnection.UseVisualStyleBackColor = true;
            this.UI_B_ManageConnection.Click += new System.EventHandler(this.UI_B_ManageConnection_Click);
            // 
            // UI_B_Guess
            // 
            this.UI_B_Guess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_B_Guess.Enabled = false;
            this.UI_B_Guess.Location = new System.Drawing.Point(799, 89);
            this.UI_B_Guess.Name = "UI_B_Guess";
            this.UI_B_Guess.Size = new System.Drawing.Size(75, 23);
            this.UI_B_Guess.TabIndex = 1;
            this.UI_B_Guess.Text = "Guess";
            this.UI_B_Guess.UseVisualStyleBackColor = true;
            this.UI_B_Guess.Click += new System.EventHandler(this.UI_B_Guess_Click);
            // 
            // Form_Client
            // 
            this.AcceptButton = this.UI_B_Guess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 121);
            this.Controls.Add(this.UI_B_Guess);
            this.Controls.Add(this.UI_B_ManageConnection);
            this.Controls.Add(this.UI_LB_Max);
            this.Controls.Add(this.UI_LB_Min);
            this.Controls.Add(this.UI_LB_TBrValue);
            this.Controls.Add(this.UI_TBr_Guess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_TB_Status);
            this.MinimumSize = new System.Drawing.Size(400, 160);
            this.Name = "Form_Client";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.UI_TBr_Guess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UI_TB_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar UI_TBr_Guess;
        private System.Windows.Forms.Label UI_LB_TBrValue;
        private System.Windows.Forms.Label UI_LB_Min;
        private System.Windows.Forms.Label UI_LB_Max;
        private System.Windows.Forms.Button UI_B_ManageConnection;
        private System.Windows.Forms.Button UI_B_Guess;
    }
}

