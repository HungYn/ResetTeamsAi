using System.Drawing;
using System.Windows.Forms;

    partial class UiHelpers
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
            this.labelInstruction = new System.Windows.Forms.Label();
            this.pictureBoxInstruction = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInstruction
            // 
            this.labelInstruction.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInstruction.Location = new System.Drawing.Point(10, 10);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(590, 100);
            this.labelInstruction.TabIndex = 0;
            this.labelInstruction.Text = "步驟說明文字...";
            // 
            // pictureBoxInstruction
            // 
            this.pictureBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxInstruction.ErrorImage = global::ResetTeamsAi.Properties.Resources._01;
            this.pictureBoxInstruction.Location = new System.Drawing.Point(18, 120);
            this.pictureBoxInstruction.Name = "pictureBoxInstruction";
            this.pictureBoxInstruction.Size = new System.Drawing.Size(584, 437);
            this.pictureBoxInstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInstruction.TabIndex = 1;
            this.pictureBoxInstruction.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(220, 598);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "我已了解並開啟設定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // UiHelpers
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 650);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBoxInstruction);
            this.Controls.Add(this.labelInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UiHelpers";
            this.Text = "手動清除指引 (1/3)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInstruction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.PictureBox pictureBoxInstruction;
        private System.Windows.Forms.Button btnOk;
    }
