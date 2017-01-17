namespace WindowsFormsApplication9
{
    partial class RostelekomTragicDetail
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RostelekomTragicDetail));
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialogCdrs = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerCommon = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(432, 38);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Сформировать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // openFileDialogCdrs
            // 
            this.openFileDialogCdrs.FileName = "comlog_XX_XX_20XX.log";
            this.openFileDialogCdrs.Filter = "CDR-файлы в формате CallBuilder|*.log";
            this.openFileDialogCdrs.Multiselect = true;
            // 
            // backgroundWorkerCommon
            // 
            this.backgroundWorkerCommon.WorkerReportsProgress = true;
            this.backgroundWorkerCommon.WorkerSupportsCancellation = true;
            this.backgroundWorkerCommon.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCommon_DoWork);
            this.backgroundWorkerCommon.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCommon_ProgressChanged);
            this.backgroundWorkerCommon.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCommon_RunWorkerCompleted_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Готов к работе";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RostelekomTragicDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(456, 82);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RostelekomTragicDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RostelekomTragicDetail";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.OpenFileDialog openFileDialogCdrs;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCommon;
        private System.Windows.Forms.Label label1;
    }
}

