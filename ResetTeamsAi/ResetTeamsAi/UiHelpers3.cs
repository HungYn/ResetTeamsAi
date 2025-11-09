using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// 提供第三個手動清除步驟的引導視窗。
/// 主旨：移除「電子郵件、行事曆與連絡人所使用的帳戶」。
/// </summary>
public partial class UiHelpers3 : Form
{
    public UiHelpers3()
    {
        InitializeComponent();
        this.Text = "手動清除指引 (3/3) - 移除電子郵件帳戶";
        // 介面屬性已在 Designer.cs 中設定

        // 設定圖片資源
        // 假設 Properties.Resources._03 已經正確嵌入專案資源中
        this.pictureBoxInstruction.Image = ResetTeamsAi.Properties.Resources._03;

        // 設定步驟文字
        this.labelInstruction.Text =
            "這是最後一個手動清除步驟：\n\n" +
            "1. 在「電子郵件與帳戶」頁面，找到「電子郵件、行事曆與連絡人所使用的帳戶」清單。\n" +
            "2. 針對所有您不再需要或與 Teams/工作相關的帳戶，點擊後選擇「管理」或「移除」。\n" +
            "3. 確保所有 Teams 相關的帳戶都已被清除。\n" +
            "4. 完成後，點擊下方的「我已了解並完成移除」按鈕，程式將繼續進行自動清理。";

        // 指引二/三按鈕尺寸變更 (規格要求 200x32)
        this.btnOk.Size = new Size(200, 32);
        this.btnOk.Location = new Point((this.ClientSize.Width - this.btnOk.Width) / 2, 598);
    }

    /// <summary>
    /// 以模態方式顯示此指引視窗。
    /// </summary>
    public DialogResult ShowEmailCalendarContactsRemoval()
    {
        return this.ShowDialog();
    }
}