namespace VolvoCanLogger
{
    partial class MessageList
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
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.tbData1 = new System.Windows.Forms.TextBox();
            this.tbDataDiff = new System.Windows.Forms.TextBox();
            this.tbData2 = new System.Windows.Forms.TextBox();
            this.tbItem1 = new System.Windows.Forms.TextBox();
            this.tbItem2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMessages
            // 
            this.lbMessages.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.ItemHeight = 14;
            this.lbMessages.Location = new System.Drawing.Point(3, 97);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMessages.Size = new System.Drawing.Size(257, 438);
            this.lbMessages.TabIndex = 0;
            this.lbMessages.SelectedIndexChanged += new System.EventHandler(this.lbMessages_SelectedIndexChanged);
            // 
            // tbData1
            // 
            this.tbData1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbData1.Location = new System.Drawing.Point(3, 12);
            this.tbData1.Name = "tbData1";
            this.tbData1.ReadOnly = true;
            this.tbData1.Size = new System.Drawing.Size(506, 20);
            this.tbData1.TabIndex = 1;
            // 
            // tbDataDiff
            // 
            this.tbDataDiff.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDataDiff.Location = new System.Drawing.Point(3, 38);
            this.tbDataDiff.Name = "tbDataDiff";
            this.tbDataDiff.ReadOnly = true;
            this.tbDataDiff.Size = new System.Drawing.Size(506, 20);
            this.tbDataDiff.TabIndex = 2;
            // 
            // tbData2
            // 
            this.tbData2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbData2.Location = new System.Drawing.Point(3, 64);
            this.tbData2.Name = "tbData2";
            this.tbData2.ReadOnly = true;
            this.tbData2.Size = new System.Drawing.Size(506, 20);
            this.tbData2.TabIndex = 3;
            // 
            // tbItem1
            // 
            this.tbItem1.Location = new System.Drawing.Point(276, 100);
            this.tbItem1.Name = "tbItem1";
            this.tbItem1.ReadOnly = true;
            this.tbItem1.Size = new System.Drawing.Size(232, 20);
            this.tbItem1.TabIndex = 4;
            // 
            // tbItem2
            // 
            this.tbItem2.Location = new System.Drawing.Point(276, 126);
            this.tbItem2.Name = "tbItem2";
            this.tbItem2.ReadOnly = true;
            this.tbItem2.Size = new System.Drawing.Size(232, 20);
            this.tbItem2.TabIndex = 5;
            // 
            // MessageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 555);
            this.Controls.Add(this.tbItem2);
            this.Controls.Add(this.tbItem1);
            this.Controls.Add(this.tbData2);
            this.Controls.Add(this.tbDataDiff);
            this.Controls.Add(this.tbData1);
            this.Controls.Add(this.lbMessages);
            this.Name = "MessageList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Investigation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.TextBox tbData1;
        private System.Windows.Forms.TextBox tbDataDiff;
        private System.Windows.Forms.TextBox tbData2;
        private System.Windows.Forms.TextBox tbItem1;
        private System.Windows.Forms.TextBox tbItem2;
    }
}