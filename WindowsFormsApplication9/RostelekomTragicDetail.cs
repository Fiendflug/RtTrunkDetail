using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class RostelekomTragicDetail : Form
    {
        bool formatExc, rangeExc, cancelled, ioExc, commonExc;
        string targetFolderPath = Application.StartupPath + "\\Reports";

        public RostelekomTragicDetail()
        {
            InitializeComponent();
            if (!Directory.Exists(targetFolderPath)) Directory.CreateDirectory(targetFolderPath);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerCommon.IsBusy)
            {
                if (openFileDialogCdrs.ShowDialog() == DialogResult.OK)
                {
                    buttonStart.Text = "Отменить";
                    label1.Text = "В процессе";
                    if (formatExc || rangeExc || cancelled || ioExc || commonExc)
                    {
                        formatExc = false;
                        rangeExc = false;
                        cancelled = false;
                        ioExc = false;
                        commonExc = false;
                    }
                    backgroundWorkerCommon.RunWorkerAsync();                    
                }
            }
            else
            {   
                backgroundWorkerCommon.CancelAsync();
                cancelled = true;
            }
        }        

        private void backgroundWorkerCommon_DoWork(object sender, DoWorkEventArgs e)
        {
            createReport();            
        }

        private void backgroundWorkerCommon_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.ToString();
        }

        void createReport()
        {
            foreach (string reportPath in Directory.GetFiles(Application.StartupPath + "\\Reports"))
            {
                if (File.Exists(reportPath))
                {
                    if (MessageBox.Show("Файл " + reportPath + " уже существует. Перезаписать файл?", "Файл существует", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) File.Delete(reportPath);
                }
            }

            foreach (string fileName in openFileDialogCdrs.FileNames)
            {
                if (backgroundWorkerCommon.CancellationPending) return;
                RtReport.Create(fileName);
            }
            RtReport.CreatePS();
            if (MessageBox.Show("Открыть папку с отчетами?", "Отрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("explorer", targetFolderPath);
            }
            //try
            //{
                
            //}
            //catch (System.FormatException e)
            //{
            //    formatExc = true;
            //    File.AppendAllText("Error.log", e.ToString());
            //}
            //catch (System.IndexOutOfRangeException e)
            //{
            //    rangeExc = true;
            //    File.AppendAllText("Error.log", e.ToString());
            //}
            //catch (System.IO.IOException e)
            //{
            //    ioExc = true;
            //    File.AppendAllText("Error.log", e.ToString());
            //}
            //catch (SystemException e)
            //{
            //    commonExc = true;
            //    File.AppendAllText("Error.log", e.ToString());
            //}
        }

        private void backgroundWorkerCommon_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (formatExc) label1.Text = "Неверный формат файла. Проверьте лог-файл для доп. информации";
                else if (rangeExc) label1.Text = "Файл некорректен. Проверьте лог-файл для доп. информации";
                else if (cancelled) label1.Text = "Операция отменена. Результаы не сохранены";
                else if (ioExc) label1.Text = "Нет доступа к отчету. Убедитесь, что копия не открыта в другом приложении";
                else if (commonExc) label1.Text = "Неизвестная ошибка. Проверьте лог-файл для доп. информации";
                else label1.Text = "Готово"; 
                buttonStart.Text = "Сфорировать";             
            }
            else
            {
                label1.Text = "Ошибка. Проверьте логи";
                File.AppendAllText("Error.log", e.Error.Message);                
            }
        }
    }
}
