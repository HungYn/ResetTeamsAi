using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// 提供第二個手動清除步驟的引導視窗。
/// 主旨：移除「其他應用程式所使用的帳戶」。
/// </summary>
public partial class UiHelpers2 : Form
{
    public UiHelpers2()
    {
        InitializeComponent();
        this.Text = "手動清除指引 (2/3) - 移除其他應用程式帳戶";
        // 介面屬性已在 Designer.cs 中設定

        // 設定圖片資源
        // 假設 Properties.Resources._02 已經正確嵌入專案資源中
        this.pictureBoxInstruction.Image = ResetTeamsAi.Properties.Resources._02;

        // 設定步驟文字
        this.labelInstruction.Text =
            "請在 Windows 設定視窗中，繼續完成以下關鍵步驟：\n\n" +
            "1. 點擊「帳戶」→「電子郵件與帳戶」。\n" +
            "2. 找到「其他應用程式所使用的帳戶」清單。\n" +
            "3. 針對所有 Microsoft 或 Teams 相關的帳戶，點擊後選擇「移除」。\n" +
            "4. 移除所有相關帳戶後，點擊下方的「我已了解並完成移除」按鈕繼續。";

        // 指引二/三按鈕尺寸變更 (規格要求 200x32)
        this.btnOk.Size = new Size(200, 32);
        this.btnOk.Location = new Point((this.ClientSize.Width - this.btnOk.Width) / 2, 598);
    }

    /// <summary>
    /// 以模態方式顯示此指引視窗。
    /// </summary>
    public DialogResult ShowEmailOtherAppsAccountRemoval()
    {
        return this.ShowDialog();
    }
}