using System.Drawing;
using System.Windows.Forms;

partial class UiHelpers3
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label labelInstruction;
    private System.Windows.Forms.PictureBox pictureBoxInstruction;
    private System.Windows.Forms.Button btnOk;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

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
        this.labelInstruction.Font = System.Drawing.SystemFonts.DefaultFont;
        this.labelInstruction.Location = new System.Drawing.Point(10, 10);
        this.labelInstruction.Name = "labelInstruction";
        this.labelInstruction.Size = new System.Drawing.Size(590, 100);
        this.labelInstruction.TabIndex = 0;
        this.labelInstruction.Text = "步驟說明文字...";
        // 
        // pictureBoxInstruction
        // 
        this.pictureBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
        this.btnOk.Location = new System.Drawing.Point(210, 598); // 居中對齊 (620-200)/2 = 210
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(200, 32); // 規格尺寸 200x32
        this.btnOk.TabIndex = 2;
        this.btnOk.Text = "我已了解並完成移除"; // 指引三文案
        this.btnOk.UseVisualStyleBackColor = true;
        // 
        // UiHelpers3
        // 
        this.AcceptButton = this.btnOk;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(620, 650);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.pictureBoxInstruction);
        this.Controls.Add(this.labelInstruction);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "UiHelpers3";
        this.Text = "手動清除指引 (3/3)";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInstruction)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion
}