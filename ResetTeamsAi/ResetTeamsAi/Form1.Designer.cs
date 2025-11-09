
    partial class Form1
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
            this.btnClearCache = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnClearCache
            // 
            this.btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215))))); // 建議的強調色 #0078D7 (略微調整為系統藍)
            this.btnClearCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCache.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136))); // 建議字體/粗體/尺寸
            this.btnClearCache.ForeColor = System.Drawing.Color.White;
            this.btnClearCache.Location = new System.Drawing.Point(12, 12); // 規格位置
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(140, 32); // 建議優化尺寸 (140x32)
            this.btnClearCache.TabIndex = 0;
            this.btnClearCache.Text = "清除 Teams 緩存"; // 規格文字
            this.btnClearCache.UseVisualStyleBackColor = false;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click); // 綁定事件
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.White; // 規格背景色 #FFF
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // 建議字體
            this.txtOutput.Location = new System.Drawing.Point(12, 54); // 調整位置以適應優化後的按鈕尺寸
            this.txtOutput.Multiline = true; // 規格屬性
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; // 建議垂直捲軸
            this.txtOutput.Size = new System.Drawing.Size(337, 190); // 調整高度以維持整體 Form 尺寸
            this.txtOutput.TabIndex = 1;
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 1000; // 規格間隔 1000ms
            this.countdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick); // 綁定事件
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F); // 規格屬性
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // 規格屬性
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245))))); // 建議背景色 #F5F5F5
            this.ClientSize = new System.Drawing.Size(361, 256); // 規格尺寸
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnClearCache);
            this.MinimumSize = new System.Drawing.Size(377, 295); // 建議最小尺寸
            this.Name = "Form1";
            this.Text = "ResetTeams"; // 規格標題
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // 公開的元件變數宣告，供 Form1.cs 存取
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Timer countdownTimer;
    }
