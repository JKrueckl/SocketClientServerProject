namespace CMPE2800_SockGuess_Server_Jkrueckl_JVan
{
    partial class Form_Server
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
            this.UI_LB_Log = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UI_L_GeneratedNumber = new System.Windows.Forms.Label();
            this.ExitTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_LB_Log
            // 
            this.UI_LB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LB_Log.FormattingEnabled = true;
            this.UI_LB_Log.Location = new System.Drawing.Point(12, 37);
            this.UI_LB_Log.Name = "UI_LB_Log";
            this.UI_LB_Log.Size = new System.Drawing.Size(485, 277);
            this.UI_LB_Log.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log:";
            // 
            // UI_L_GeneratedNumber
            // 
            this.UI_L_GeneratedNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_L_GeneratedNumber.AutoSize = true;
            this.UI_L_GeneratedNumber.Location = new System.Drawing.Point(472, 13);
            this.UI_L_GeneratedNumber.Name = "UI_L_GeneratedNumber";
            this.UI_L_GeneratedNumber.Size = new System.Drawing.Size(25, 13);
            this.UI_L_GeneratedNumber.TabIndex = 2;
            this.UI_L_GeneratedNumber.Text = "500";
            // 
            // ExitTimer
            // 
            this.ExitTimer.Interval = 10000;
            this.ExitTimer.Tick += new System.EventHandler(this.ExitTimer_Tick);
            // 
            // Form_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 326);
            this.Controls.Add(this.UI_L_GeneratedNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UI_LB_Log);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form_Server";
            this.Text = "Server";
            this.Shown += new System.EventHandler(this.Form_Server_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UI_LB_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UI_L_GeneratedNumber;
        private System.Windows.Forms.Timer ExitTimer;
    }
}

