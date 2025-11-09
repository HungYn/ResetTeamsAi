//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace ResetTeamsAi
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

public partial class Form1 : Form
{
    // CancellationTokenSource 用於重啟倒數中斷
    private CancellationTokenSource _countdownCts;
    private int _countdownSeconds = 10;

    // UIHelpers 類別在此簡化，實際應為獨立檔案
    // 假設 UiHelpers.ShowManualClearInstruction(), UiHelpers2.ShowEmailOtherAppsAccountRemoval(), 
    // UiHelpers3.ShowEmailCalendarContactsRemoval() 已經實作並返回 DialogResult

    // ====================================================================
    // 1. 執行緒安全的日誌輸出方法
    // ====================================================================

    /// <summary>
    /// 以執行緒安全的方式將訊息附加到 txtOutput，並自動捲動。
    /// </summary>
    /// <param name="message">要輸出的訊息。</param>
    /// <param name="isError">是否為錯誤訊息，如果是則前綴 [錯誤]。</param>
    private void AppendOutput(string message, bool isError = false)
    {
        if (txtOutput.InvokeRequired)
        {
            // 將操作封送回 UI 執行緒
            txtOutput.Invoke(new Action(() => AppendOutput(message, isError)));
        }
        else
        {
            string prefix = isError ? "[錯誤] " : "[資訊] ";
            txtOutput.AppendText($"{prefix}{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            // 自動捲動到最底行
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }
    }

    // ====================================================================
    // 2. 按鈕點擊事件：啟動非同步清理流程
    // ====================================================================

    public Form1()
    {
        InitializeComponent();
        // 確保 Timer 被正確初始化 (在 Designer.cs 中)
        // countdownTimer.Interval = 1000;
        // countdownTimer.Tick += CountdownTimer_Tick;
    }

    private async void btnClearCache_Click(object sender, EventArgs e)
    {
        // 1. 介面控制
        btnClearCache.Enabled = false;
        txtOutput.Clear();
        AppendOutput("清除 Teams 緩存任務開始...");

        bool success = false;

        try
        {
            // 將耗時的清理任務移出 UI 執行緒
            success = await Task.Run(async () =>
            {
                // 執行序列操作
                KillTeamsProcesses();

                // 返回 UI 執行緒執行同步的 UI 引導
                this.Invoke(new Action(() => {
                    RunManualClearGuidance();
                }));

                // 繼續執行非同步操作
                CleanFileCache();
                CleanRegistryVault();
                return true;
            });
        }
        catch (Exception ex)
        {
            AppendOutput($"清理過程中發生未預期錯誤: {ex.Message}", true);
            success = false;
        }
        finally
        {
            // 3. 結果處理 (確保在 UI 執行緒執行)
            if (success)
            {
                AppendOutput("✅ Teams 緩存與登錄資訊清除完成。");
                PromptForRestart();
            }
            else
            {
                AppendOutput("❌ 清理任務失敗或中斷。", true);
            }
            btnClearCache.Enabled = true;
        }
    }

    // ====================================================================
    // 3. 清理子任務實作 (在 Task.Run 中執行)
    // ====================================================================

    /// <summary>
    /// 結束所有 ms-teams 相關程序。
    /// </summary>
    private void KillTeamsProcesses()
    {
        AppendOutput("嘗試結束所有 Teams 相關程序...");
        try
        {
            var teamsProcesses = Process.GetProcessesByName("ms-teams");
            if (teamsProcesses.Length == 0)
            {
                AppendOutput("未偵測到 'ms-teams' 程序正在執行，跳過。");
                return;
            }

            foreach (var proc in teamsProcesses)
            {
                AppendOutput($"正在結束程序 ID: {proc.Id} ({proc.ProcessName})...");
                proc.Kill();
                proc.WaitForExit(5000); // 最多等待 5 秒
                if (proc.HasExited)
                {
                    AppendOutput($"程序 {proc.Id} 已成功終止。");
                }
                else
                {
                    AppendOutput($"程序 {proc.Id} 無法在指定時間內終止。", true);
                }
            }
        }
        catch (Exception ex)
        {
            AppendOutput($"結束程序時發生錯誤: {ex.Message}", true);
        }
    }

    /// <summary>
    /// 刪除並重建關鍵緩存資料夾。
    /// </summary>
    private void CleanFileCache()
    {
        AppendOutput("開始清除檔案系統緩存...");
        string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string[] paths = new string[]
        {
            Path.Combine(localAppData, "Microsoft\\OneAuth\\accounts"),
            Path.Combine(localAppData, "Packages\\MSTeams_8wekyb3d8bbwe"),
            Path.Combine(localAppData, "Microsoft\\OneAuth"),
            Path.Combine(localAppData, "Microsoft\\TokenBroker"),
            Path.Combine(localAppData, "Microsoft\\IdentityCache")
        };

        foreach (var path in paths)
        {
            try
            {
                AppendOutput($"處理路徑: {path}...");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true); // 刪除資料夾及其內容
                    AppendOutput($"成功刪除 {path}。");
                }
                else
                {
                    AppendOutput($"路徑 {path} 不存在，跳過刪除。");
                }

                // 刪除後重建部分關鍵目錄
                if (!path.Contains("Packages")) // Packages 不需重建
                {
                    Directory.CreateDirectory(path);
                    AppendOutput($"成功重建空資料夾: {path}");
                }
            }
            catch (Exception ex)
            {
                AppendOutput($"處理路徑 {path} 失敗: {ex.Message}", true);
            }
        }
    }

    /// <summary>
    /// 刪除 Teams Vault 登錄檔機碼。
    /// </summary>
    private void CleanRegistryVault()
    {
        AppendOutput("開始清除登錄檔機碼...");
        const string keyPath = @"SOFTWARE\Microsoft\Teams";
        const string valueName = "Vault";

        try
        {
            using (RegistryKey teamsKey = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (teamsKey != null && teamsKey.GetSubKeyNames().Contains(valueName))
                {
                    teamsKey.DeleteSubKey(valueName, false);
                    AppendOutput($"成功刪除登錄檔機碼: HKCU\\{keyPath}\\{valueName}。");
                }
                else
                {
                    AppendOutput($"登錄檔機碼 HKCU\\{keyPath}\\{valueName} 不存在，跳過。");
                }
            }
        }
        catch (Exception ex)
        {
            AppendOutput($"清除登錄檔時發生錯誤: {ex.Message}", true);
        }
    }

    // ====================================================================
    // 4. 手動引導流程 (在 UI 執行緒執行)
    // ====================================================================

    /// <summary>
    /// 啟動 Windows 設定並彈出指引視窗。
    /// </summary>
    private void RunManualClearGuidance()
    {
        // 1. 開啟 Windows 設定
        AppendOutput("自動開啟 Windows 設定: 帳戶 -> 您的資訊...");
        try
        {
            Process.Start(new ProcessStartInfo("ms-settings:yourinfo") { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            AppendOutput($"開啟設定失敗: {ex.Message}", true);
            MessageBox.Show("無法自動開啟 Windows 設定。請手動前往：設定 -> 帳戶 -> 您的資訊。",
                            "手動操作提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // 2. 彈出三個指引視窗 (假設這些方法是同步阻塞的)
        AppendOutput("等待使用者完成手動清除帳戶引導...");

        // 實作中應使用您設計的 UiHelpers 彈窗類別
        // 假設這三個方法會阻塞直到使用者點擊確認按鈕。

        new UiHelpers().ShowManualClearInstruction(); // 指引一
        new UiHelpers2().ShowEmailOtherAppsAccountRemoval(); // 指引二
        new UiHelpers3().ShowEmailCalendarContactsRemoval(); // 指引三

        AppendOutput("手動清除帳戶引導流程完成。");
    }

    // ====================================================================
    // 5. 重啟倒數與中斷邏輯
    // ====================================================================

    /// <summary>
    /// 詢問是否重啟電腦並啟動倒數。
    /// </summary>
    private void PromptForRestart()
    {
        if (MessageBox.Show("是否立即重啟電腦以確保設定生效？ (可按 Ctrl+C 中斷倒數)", "重啟確認",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _countdownSeconds = 10;
            _countdownCts = new CancellationTokenSource();

            AppendOutput($"系統將在 {_countdownSeconds} 秒後重啟。按 Ctrl+C 中斷。");
            countdownTimer.Start();
        }
        else
        {
            AppendOutput("使用者選擇不重啟電腦。任務結束。");
        }
    }

    /// <summary>
    /// Timer 每秒觸發的事件。
    /// </summary>
    private void CountdownTimer_Tick(object sender, EventArgs e)
    {
        if (_countdownCts.IsCancellationRequested)
        {
            countdownTimer.Stop();
            return;
        }

        _countdownSeconds--;

        if (_countdownSeconds > 0)
        {
            AppendOutput($"正在倒數重啟：剩餘 {_countdownSeconds} 秒...");
        }
        else
        {
            countdownTimer.Stop();
            AppendOutput("倒數結束，正在執行重啟指令...");
            try
            {
                // 執行 shutdown /r /t 0
                Process.Start("shutdown", "/r /t 0");
            }
            catch (Exception ex)
            {
                AppendOutput($"執行重啟指令失敗: {ex.Message}", true);
            }
        }
    }

    /// <summary>
    /// 偵測快捷鍵 (Ctrl+C) 以中斷重啟倒數。
    /// </summary>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.C))
        {
            if (countdownTimer.Enabled && _countdownCts != null)
            {
                _countdownCts.Cancel();
                AppendOutput("🛑 偵測到 Ctrl+C。重啟倒數已中斷。");
                countdownTimer.Stop();
                return true; // 處理此按鍵
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}