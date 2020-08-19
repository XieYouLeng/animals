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
            this.Dtp_dateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Pic_track = new System.Windows.Forms.PictureBox();
            this.Cbo_selectID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lbl_vertAct = new System.Windows.Forms.Label();
            this.Lbl_clockwiseTimes = new System.Windows.Forms.Label();
            this.Lbl_counterclockwiseTimes = new System.Windows.Forms.Label();
            this.Lbl_verticalActivity = new System.Windows.Forms.Label();
            this.Lbl_clockwise = new System.Windows.Forms.Label();
            this.Lbl_counterclockwise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).BeginInit();
            this.SuspendLayout();
            // 
            // Dtp_dateTime
            // 
            this.Dtp_dateTime.CustomFormat = " ";
            this.Dtp_dateTime.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Dtp_dateTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Dtp_dateTime.Location = new System.Drawing.Point(567, 54);
            this.Dtp_dateTime.Margin = new System.Windows.Forms.Padding(2);
            this.Dtp_dateTime.Name = "Dtp_dateTime";
            this.Dtp_dateTime.Size = new System.Drawing.Size(151, 27);
            this.Dtp_dateTime.TabIndex = 1;
            this.Dtp_dateTime.Value = new System.DateTime(2020, 7, 31, 0, 0, 0, 0);
            this.Dtp_dateTime.ValueChanged += new System.EventHandler(this.Dtp_dateTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 8;
            // 
            // Pic_track
            // 
            this.Pic_track.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_track.Location = new System.Drawing.Point(20, 20);
            this.Pic_track.Margin = new System.Windows.Forms.Padding(2);
            this.Pic_track.Name = "Pic_track";
            this.Pic_track.Size = new System.Drawing.Size(510, 510);
            this.Pic_track.TabIndex = 6;
            this.Pic_track.TabStop = false;
            // 
            // Cbo_selectID
            // 
            this.Cbo_selectID.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cbo_selectID.FormattingEnabled = true;
            this.Cbo_selectID.Location = new System.Drawing.Point(738, 54);
            this.Cbo_selectID.Margin = new System.Windows.Forms.Padding(2);
            this.Cbo_selectID.Name = "Cbo_selectID";
            this.Cbo_selectID.Size = new System.Drawing.Size(92, 24);
            this.Cbo_selectID.TabIndex = 10;
            this.Cbo_selectID.SelectedIndexChanged += new System.EventHandler(this.Cbo_selectID_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(564, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "請選擇日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(735, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "請選擇ID：";
            // 
            // Lbl_vertAct
            // 
            this.Lbl_vertAct.AutoSize = true;
            this.Lbl_vertAct.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_vertAct.Location = new System.Drawing.Point(564, 141);
            this.Lbl_vertAct.Name = "Lbl_vertAct";
            this.Lbl_vertAct.Size = new System.Drawing.Size(120, 16);
            this.Lbl_vertAct.TabIndex = 13;
            this.Lbl_vertAct.Text = "垂直活動次數：";
            // 
            // Lbl_clockwiseTimes
            // 
            this.Lbl_clockwiseTimes.AutoSize = true;
            this.Lbl_clockwiseTimes.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_clockwiseTimes.Location = new System.Drawing.Point(564, 220);
            this.Lbl_clockwiseTimes.Name = "Lbl_clockwiseTimes";
            this.Lbl_clockwiseTimes.Size = new System.Drawing.Size(104, 16);
            this.Lbl_clockwiseTimes.TabIndex = 14;
            this.Lbl_clockwiseTimes.Text = "順時針次數：";
            // 
            // Lbl_counterclockwiseTimes
            // 
            this.Lbl_counterclockwiseTimes.AutoSize = true;
            this.Lbl_counterclockwiseTimes.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_counterclockwiseTimes.Location = new System.Drawing.Point(564, 299);
            this.Lbl_counterclockwiseTimes.Name = "Lbl_counterclockwiseTimes";
            this.Lbl_counterclockwiseTimes.Size = new System.Drawing.Size(104, 16);
            this.Lbl_counterclockwiseTimes.TabIndex = 15;
            this.Lbl_counterclockwiseTimes.Text = "逆時針次數：";
            // 
            // Lbl_verticalActivity
            // 
            this.Lbl_verticalActivity.AutoSize = true;
            this.Lbl_verticalActivity.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_verticalActivity.Location = new System.Drawing.Point(677, 141);
            this.Lbl_verticalActivity.Name = "Lbl_verticalActivity";
            this.Lbl_verticalActivity.Size = new System.Drawing.Size(32, 16);
            this.Lbl_verticalActivity.TabIndex = 16;
            this.Lbl_verticalActivity.Text = "...";
            // 
            // Lbl_clockwise
            // 
            this.Lbl_clockwise.AutoSize = true;
            this.Lbl_clockwise.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_clockwise.Location = new System.Drawing.Point(661, 220);
            this.Lbl_clockwise.Name = "Lbl_clockwise";
            this.Lbl_clockwise.Size = new System.Drawing.Size(32, 16);
            this.Lbl_clockwise.TabIndex = 17;
            this.Lbl_clockwise.Text = "...";
            // 
            // Lbl_counterclockwise
            // 
            this.Lbl_counterclockwise.AutoSize = true;
            this.Lbl_counterclockwise.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_counterclockwise.Location = new System.Drawing.Point(661, 299);
            this.Lbl_counterclockwise.Name = "Lbl_counterclockwise";
            this.Lbl_counterclockwise.Size = new System.Drawing.Size(32, 16);
            this.Lbl_counterclockwise.TabIndex = 18;
            this.Lbl_counterclockwise.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.Lbl_counterclockwise);
            this.Controls.Add(this.Lbl_clockwise);
            this.Controls.Add(this.Lbl_verticalActivity);
            this.Controls.Add(this.Lbl_counterclockwiseTimes);
            this.Controls.Add(this.Lbl_clockwiseTimes);
            this.Controls.Add(this.Lbl_vertAct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cbo_selectID);
            this.Controls.Add(this.Pic_track);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dtp_dateTime);
            this.Name = "Form1";
            this.Text = "可彈性擴充之動物行為量測系統-動物實驗結果";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker Dtp_dateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbo_selectID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox Pic_track;
        private System.Windows.Forms.Label Lbl_vertAct;
        private System.Windows.Forms.Label Lbl_clockwiseTimes;
        private System.Windows.Forms.Label Lbl_counterclockwiseTimes;
        private System.Windows.Forms.Label Lbl_verticalActivity;
        private System.Windows.Forms.Label Lbl_clockwise;
        private System.Windows.Forms.Label Lbl_counterclockwise;
    }
}

