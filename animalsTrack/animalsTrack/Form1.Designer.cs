namespace animalsTrack
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Dtp_dateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_cancel = new System.Windows.Forms.Button();
            this.Pic_track = new System.Windows.Forms.PictureBox();
            this.Cbo_selectID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(937, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dtp_dateTime
            // 
            this.Dtp_dateTime.CustomFormat = " ";
            this.Dtp_dateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Dtp_dateTime.Location = new System.Drawing.Point(541, 69);
            this.Dtp_dateTime.Name = "Dtp_dateTime";
            this.Dtp_dateTime.Size = new System.Drawing.Size(200, 25);
            this.Dtp_dateTime.TabIndex = 1;
            this.Dtp_dateTime.Value = new System.DateTime(2020, 7, 31, 0, 0, 0, 0);
            this.Dtp_dateTime.ValueChanged += new System.EventHandler(this.Dtp_dateTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(577, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 8;
            // 
            // Btn_cancel
            // 
            this.Btn_cancel.Location = new System.Drawing.Point(666, 450);
            this.Btn_cancel.Name = "Btn_cancel";
            this.Btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_cancel.TabIndex = 5;
            this.Btn_cancel.Text = "cancel";
            this.Btn_cancel.UseVisualStyleBackColor = true;
            this.Btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // Pic_track
            // 
            this.Pic_track.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_track.Location = new System.Drawing.Point(12, 26);
            this.Pic_track.Name = "Pic_track";
            this.Pic_track.Size = new System.Drawing.Size(512, 512);
            this.Pic_track.TabIndex = 6;
            this.Pic_track.TabStop = false;
            // 
            // Cbo_selectID
            // 
            this.Cbo_selectID.FormattingEnabled = true;
            this.Cbo_selectID.Location = new System.Drawing.Point(772, 69);
            this.Cbo_selectID.Name = "Cbo_selectID";
            this.Cbo_selectID.Size = new System.Drawing.Size(121, 23);
            this.Cbo_selectID.TabIndex = 10;
            this.Cbo_selectID.SelectedIndexChanged += new System.EventHandler(this.Cbo_selectID_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "請選擇日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(769, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "請選擇ID：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cbo_selectID);
            this.Controls.Add(this.Pic_track);
            this.Controls.Add(this.Btn_cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dtp_dateTime);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "可彈性擴充之動物行為量測系統-動物實驗結果";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker Dtp_dateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_cancel;
        private System.Windows.Forms.PictureBox Pic_track;
        private System.Windows.Forms.ComboBox Cbo_selectID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

