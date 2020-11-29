namespace animalsTrack
{
    partial class Form2
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
            this.Btn_changeFar = new System.Windows.Forms.Button();
            this.Pic_track = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Lbl_startTime = new System.Windows.Forms.Label();
            this.Lbl_endTime = new System.Windows.Forms.Label();
            this.Lbl_clockwiseTimes = new System.Windows.Forms.Label();
            this.Lbl_vertAct = new System.Windows.Forms.Label();
            this.Lbl_counterclockwiseTimes = new System.Windows.Forms.Label();
            this.Lbl_showStartTime = new System.Windows.Forms.Label();
            this.Lbl_showEndTime = new System.Windows.Forms.Label();
            this.Lbl_showVerAct = new System.Windows.Forms.Label();
            this.Lbl_showClockwise = new System.Windows.Forms.Label();
            this.Lbl_showCounterClockwise = new System.Windows.Forms.Label();
            this.Btn_saveCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_changeFar
            // 
            this.Btn_changeFar.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_changeFar.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Btn_changeFar.Location = new System.Drawing.Point(890, 495);
            this.Btn_changeFar.Name = "Btn_changeFar";
            this.Btn_changeFar.Size = new System.Drawing.Size(130, 35);
            this.Btn_changeFar.TabIndex = 0;
            this.Btn_changeFar.Text = "切換遠端模式";
            this.Btn_changeFar.UseVisualStyleBackColor = false;
            this.Btn_changeFar.Click += new System.EventHandler(this.Btn_changeFar_Click);
            // 
            // Pic_track
            // 
            this.Pic_track.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_track.Location = new System.Drawing.Point(20, 20);
            this.Pic_track.Margin = new System.Windows.Forms.Padding(2);
            this.Pic_track.Name = "Pic_track";
            this.Pic_track.Size = new System.Drawing.Size(520, 520);
            this.Pic_track.TabIndex = 2;
            this.Pic_track.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(927, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1064, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(557, 20);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(296, 52);
            this.textBox4.TabIndex = 8;
            // 
            // Lbl_startTime
            // 
            this.Lbl_startTime.AutoSize = true;
            this.Lbl_startTime.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_startTime.Location = new System.Drawing.Point(554, 117);
            this.Lbl_startTime.Name = "Lbl_startTime";
            this.Lbl_startTime.Size = new System.Drawing.Size(120, 16);
            this.Lbl_startTime.TabIndex = 9;
            this.Lbl_startTime.Text = "實驗開始時間：";
            // 
            // Lbl_endTime
            // 
            this.Lbl_endTime.AutoSize = true;
            this.Lbl_endTime.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_endTime.Location = new System.Drawing.Point(554, 184);
            this.Lbl_endTime.Name = "Lbl_endTime";
            this.Lbl_endTime.Size = new System.Drawing.Size(120, 16);
            this.Lbl_endTime.TabIndex = 9;
            this.Lbl_endTime.Text = "實驗結束時間：";
            // 
            // Lbl_clockwiseTimes
            // 
            this.Lbl_clockwiseTimes.AutoSize = true;
            this.Lbl_clockwiseTimes.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_clockwiseTimes.Location = new System.Drawing.Point(554, 318);
            this.Lbl_clockwiseTimes.Name = "Lbl_clockwiseTimes";
            this.Lbl_clockwiseTimes.Size = new System.Drawing.Size(104, 16);
            this.Lbl_clockwiseTimes.TabIndex = 9;
            this.Lbl_clockwiseTimes.Text = "順時針次數：";
            // 
            // Lbl_vertAct
            // 
            this.Lbl_vertAct.AutoSize = true;
            this.Lbl_vertAct.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_vertAct.Location = new System.Drawing.Point(554, 251);
            this.Lbl_vertAct.Name = "Lbl_vertAct";
            this.Lbl_vertAct.Size = new System.Drawing.Size(120, 16);
            this.Lbl_vertAct.TabIndex = 9;
            this.Lbl_vertAct.Text = "垂直活動次數：";
            // 
            // Lbl_counterclockwiseTimes
            // 
            this.Lbl_counterclockwiseTimes.AutoSize = true;
            this.Lbl_counterclockwiseTimes.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_counterclockwiseTimes.Location = new System.Drawing.Point(554, 385);
            this.Lbl_counterclockwiseTimes.Name = "Lbl_counterclockwiseTimes";
            this.Lbl_counterclockwiseTimes.Size = new System.Drawing.Size(104, 16);
            this.Lbl_counterclockwiseTimes.TabIndex = 9;
            this.Lbl_counterclockwiseTimes.Text = "逆時針次數：";
            // 
            // Lbl_showStartTime
            // 
            this.Lbl_showStartTime.AutoSize = true;
            this.Lbl_showStartTime.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_showStartTime.Location = new System.Drawing.Point(670, 117);
            this.Lbl_showStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_showStartTime.Name = "Lbl_showStartTime";
            this.Lbl_showStartTime.Size = new System.Drawing.Size(32, 16);
            this.Lbl_showStartTime.TabIndex = 13;
            this.Lbl_showStartTime.Text = "...";
            // 
            // Lbl_showEndTime
            // 
            this.Lbl_showEndTime.AutoSize = true;
            this.Lbl_showEndTime.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_showEndTime.Location = new System.Drawing.Point(670, 184);
            this.Lbl_showEndTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_showEndTime.Name = "Lbl_showEndTime";
            this.Lbl_showEndTime.Size = new System.Drawing.Size(32, 16);
            this.Lbl_showEndTime.TabIndex = 13;
            this.Lbl_showEndTime.Text = "...";
            // 
            // Lbl_showVerAct
            // 
            this.Lbl_showVerAct.AutoSize = true;
            this.Lbl_showVerAct.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_showVerAct.Location = new System.Drawing.Point(670, 251);
            this.Lbl_showVerAct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_showVerAct.Name = "Lbl_showVerAct";
            this.Lbl_showVerAct.Size = new System.Drawing.Size(32, 16);
            this.Lbl_showVerAct.TabIndex = 13;
            this.Lbl_showVerAct.Text = "...";
            // 
            // Lbl_showClockwise
            // 
            this.Lbl_showClockwise.AutoSize = true;
            this.Lbl_showClockwise.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_showClockwise.Location = new System.Drawing.Point(654, 318);
            this.Lbl_showClockwise.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_showClockwise.Name = "Lbl_showClockwise";
            this.Lbl_showClockwise.Size = new System.Drawing.Size(32, 16);
            this.Lbl_showClockwise.TabIndex = 13;
            this.Lbl_showClockwise.Text = "...";
            // 
            // Lbl_showCounterClockwise
            // 
            this.Lbl_showCounterClockwise.AutoSize = true;
            this.Lbl_showCounterClockwise.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl_showCounterClockwise.Location = new System.Drawing.Point(654, 385);
            this.Lbl_showCounterClockwise.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_showCounterClockwise.Name = "Lbl_showCounterClockwise";
            this.Lbl_showCounterClockwise.Size = new System.Drawing.Size(32, 16);
            this.Lbl_showCounterClockwise.TabIndex = 13;
            this.Lbl_showCounterClockwise.Text = "...";
            // 
            // Btn_saveCSV
            // 
            this.Btn_saveCSV.Location = new System.Drawing.Point(1064, 502);
            this.Btn_saveCSV.Name = "Btn_saveCSV";
            this.Btn_saveCSV.Size = new System.Drawing.Size(75, 23);
            this.Btn_saveCSV.TabIndex = 14;
            this.Btn_saveCSV.Text = "Save";
            this.Btn_saveCSV.UseVisualStyleBackColor = true;
            this.Btn_saveCSV.Click += new System.EventHandler(this.Btn_saveCSV_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 551);
            this.Controls.Add(this.Btn_saveCSV);
            this.Controls.Add(this.Lbl_showCounterClockwise);
            this.Controls.Add(this.Lbl_showClockwise);
            this.Controls.Add(this.Lbl_showVerAct);
            this.Controls.Add(this.Lbl_showEndTime);
            this.Controls.Add(this.Lbl_showStartTime);
            this.Controls.Add(this.Lbl_counterclockwiseTimes);
            this.Controls.Add(this.Lbl_vertAct);
            this.Controls.Add(this.Lbl_clockwiseTimes);
            this.Controls.Add(this.Lbl_endTime);
            this.Controls.Add(this.Lbl_startTime);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Pic_track);
            this.Controls.Add(this.Btn_changeFar);
            this.Name = "Form2";
            this.Text = "可彈性擴充之動物行為量測系統-PC端模式-動物實驗結果";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_track)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_changeFar;
        public System.Windows.Forms.PictureBox Pic_track;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label Lbl_startTime;
        private System.Windows.Forms.Label Lbl_endTime;
        private System.Windows.Forms.Label Lbl_clockwiseTimes;
        private System.Windows.Forms.Label Lbl_vertAct;
        private System.Windows.Forms.Label Lbl_counterclockwiseTimes;
        private System.Windows.Forms.Label Lbl_showStartTime;
        private System.Windows.Forms.Label Lbl_showEndTime;
        private System.Windows.Forms.Label Lbl_showVerAct;
        private System.Windows.Forms.Label Lbl_showClockwise;
        private System.Windows.Forms.Label Lbl_showCounterClockwise;
        private System.Windows.Forms.Button Btn_saveCSV;
    }
}