using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// 提供第一個手動清除步驟的引導視窗。
/// 主旨：停止自動登入所有 Microsoft 應用程式。
/// </summary>
public partial class UiHelpers : Form
{
    public UiHelpers()
    {
        InitializeComponent();
        this.Text = "手動清除指引 (1/3)";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ShowIcon = false;

        // 設定圖片資源
        // 假設 Properties.Resources._01 已經正確嵌入專案資源中 (584x437)
        this.pictureBoxInstruction.Image = ResetTeamsAi.Properties.Resources._01;

        // 設定步驟文字
        this.labelInstruction.Text =
            "請依照以下步驟操作，以防止 Teams 重新自動登入並抓取舊緩存：\n\n" +
            "1. 在您剛剛開啟的 Windows 設定視窗中，點選「帳戶」。\n" +
            "2. 點擊畫面上的「您的資訊」。\n" +
            "3. 尋找「停止自動登入所有 Microsoft 應用程式」或類似選項。\n" +
            "4. 點擊並完成設定，避免後續自動登入。";
    }

    /// <summary>
    /// 以模態方式顯示此指引視窗，並等待使用者確認。
    /// </summary>
    public DialogResult ShowManualClearInstruction()
    {
        // 如果此方法是從非 UI 執行緒呼叫（雖然在 Form1.cs 中已使用 Invoke，但仍是良好的防禦性編程習慣）
        // 在這裡，我們假設 Form1 已經將此操作封送回 UI 執行緒，因此直接顯示即可。
        return this.ShowDialog();
    }

    // 可以在這裡添加其他行為或事件處理，但根據規格只需顯示和確認。
}