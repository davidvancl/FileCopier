namespace FileCopier
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.resultGroup = new System.Windows.Forms.GroupBox();
            this.resultState = new System.Windows.Forms.TextBox();
            this.copiedFilesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.copyButton = new System.Windows.Forms.Button();
            this.directoriesCheck = new System.Windows.Forms.Button();
            this.targetStatus = new System.Windows.Forms.TextBox();
            this.sourceStatus = new System.Windows.Forms.TextBox();
            this.targetStatusLabel = new System.Windows.Forms.Label();
            this.sourceStatusLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mobilePathLabel = new System.Windows.Forms.Label();
            this.mobilePath = new System.Windows.Forms.TextBox();
            this.isPhone = new System.Windows.Forms.CheckBox();
            this.additionalSettingsLabel = new System.Windows.Forms.Label();
            this.additionalSettings = new System.Windows.Forms.CheckedListBox();
            this.targetPathButton = new System.Windows.Forms.Button();
            this.targetPath = new System.Windows.Forms.TextBox();
            this.targetPathLabel = new System.Windows.Forms.Label();
            this.sourcePathButton = new System.Windows.Forms.Button();
            this.sourcePathLabel = new System.Windows.Forms.Label();
            this.sourcePath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.resultGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resultGroup);
            this.tabPage1.Controls.Add(this.copyButton);
            this.tabPage1.Controls.Add(this.directoriesCheck);
            this.tabPage1.Controls.Add(this.targetStatus);
            this.tabPage1.Controls.Add(this.sourceStatus);
            this.tabPage1.Controls.Add(this.targetStatusLabel);
            this.tabPage1.Controls.Add(this.sourceStatusLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(278, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kopírka";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // resultGroup
            // 
            this.resultGroup.Controls.Add(this.resultState);
            this.resultGroup.Controls.Add(this.copiedFilesCount);
            this.resultGroup.Controls.Add(this.label1);
            this.resultGroup.Controls.Add(this.progress);
            this.resultGroup.Location = new System.Drawing.Point(9, 262);
            this.resultGroup.Name = "resultGroup";
            this.resultGroup.Size = new System.Drawing.Size(260, 166);
            this.resultGroup.TabIndex = 6;
            this.resultGroup.TabStop = false;
            this.resultGroup.Text = "Stav kopírování";
            this.resultGroup.Visible = false;
            // 
            // resultState
            // 
            this.resultState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultState.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultState.Location = new System.Drawing.Point(6, 68);
            this.resultState.Name = "resultState";
            this.resultState.Size = new System.Drawing.Size(248, 45);
            this.resultState.TabIndex = 3;
            this.resultState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // copiedFilesCount
            // 
            this.copiedFilesCount.AutoSize = true;
            this.copiedFilesCount.Location = new System.Drawing.Point(93, 148);
            this.copiedFilesCount.Name = "copiedFilesCount";
            this.copiedFilesCount.Size = new System.Drawing.Size(13, 15);
            this.copiedFilesCount.TabIndex = 2;
            this.copiedFilesCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Počet souborů:";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 22);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(248, 23);
            this.progress.TabIndex = 0;
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.copyButton.Location = new System.Drawing.Point(9, 166);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(260, 90);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "KOPÍROVAT";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // directoriesCheck
            // 
            this.directoriesCheck.Location = new System.Drawing.Point(9, 59);
            this.directoriesCheck.Name = "directoriesCheck";
            this.directoriesCheck.Size = new System.Drawing.Size(260, 23);
            this.directoriesCheck.TabIndex = 4;
            this.directoriesCheck.Text = "Zkontrolovat adresáře";
            this.directoriesCheck.UseVisualStyleBackColor = true;
            this.directoriesCheck.Click += new System.EventHandler(this.directoriesCheck_Click);
            // 
            // targetStatus
            // 
            this.targetStatus.BackColor = System.Drawing.Color.Red;
            this.targetStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.targetStatus.Location = new System.Drawing.Point(156, 41);
            this.targetStatus.Name = "targetStatus";
            this.targetStatus.Size = new System.Drawing.Size(113, 16);
            this.targetStatus.TabIndex = 3;
            this.targetStatus.Text = "neaktivní";
            this.targetStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sourceStatus
            // 
            this.sourceStatus.BackColor = System.Drawing.Color.Red;
            this.sourceStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceStatus.Location = new System.Drawing.Point(156, 17);
            this.sourceStatus.Name = "sourceStatus";
            this.sourceStatus.Size = new System.Drawing.Size(113, 16);
            this.sourceStatus.TabIndex = 2;
            this.sourceStatus.Text = "neaktivní";
            this.sourceStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // targetStatusLabel
            // 
            this.targetStatusLabel.AutoSize = true;
            this.targetStatusLabel.Location = new System.Drawing.Point(9, 41);
            this.targetStatusLabel.Name = "targetStatusLabel";
            this.targetStatusLabel.Size = new System.Drawing.Size(127, 15);
            this.targetStatusLabel.TabIndex = 1;
            this.targetStatusLabel.Text = "Stav cílového adresáře:";
            // 
            // sourceStatusLabel
            // 
            this.sourceStatusLabel.AutoSize = true;
            this.sourceStatusLabel.Location = new System.Drawing.Point(9, 17);
            this.sourceStatusLabel.Name = "sourceStatusLabel";
            this.sourceStatusLabel.Size = new System.Drawing.Size(141, 15);
            this.sourceStatusLabel.TabIndex = 0;
            this.sourceStatusLabel.Text = "Stav zdrojového adresáře:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mobilePathLabel);
            this.tabPage2.Controls.Add(this.mobilePath);
            this.tabPage2.Controls.Add(this.isPhone);
            this.tabPage2.Controls.Add(this.additionalSettingsLabel);
            this.tabPage2.Controls.Add(this.additionalSettings);
            this.tabPage2.Controls.Add(this.targetPathButton);
            this.tabPage2.Controls.Add(this.targetPath);
            this.tabPage2.Controls.Add(this.targetPathLabel);
            this.tabPage2.Controls.Add(this.sourcePathButton);
            this.tabPage2.Controls.Add(this.sourcePathLabel);
            this.tabPage2.Controls.Add(this.sourcePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(278, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nastavení";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mobilePathLabel
            // 
            this.mobilePathLabel.AutoSize = true;
            this.mobilePathLabel.Location = new System.Drawing.Point(6, 86);
            this.mobilePathLabel.Name = "mobilePathLabel";
            this.mobilePathLabel.Size = new System.Drawing.Size(132, 15);
            this.mobilePathLabel.TabIndex = 10;
            this.mobilePathLabel.Text = "Zdrojová cesta (odkud):";
            this.mobilePathLabel.Visible = false;
            // 
            // mobilePath
            // 
            this.mobilePath.Location = new System.Drawing.Point(6, 104);
            this.mobilePath.Name = "mobilePath";
            this.mobilePath.Size = new System.Drawing.Size(266, 23);
            this.mobilePath.TabIndex = 9;
            this.mobilePath.Visible = false;
            this.mobilePath.TextChanged += new System.EventHandler(this.mobilePath_TextChanged);
            // 
            // isPhone
            // 
            this.isPhone.AutoSize = true;
            this.isPhone.Location = new System.Drawing.Point(144, 7);
            this.isPhone.Name = "isPhone";
            this.isPhone.Size = new System.Drawing.Size(80, 19);
            this.isPhone.TabIndex = 8;
            this.isPhone.Text = "Z telefonu";
            this.isPhone.UseVisualStyleBackColor = true;
            this.isPhone.CheckedChanged += new System.EventHandler(this.isPhone_CheckedChanged);
            // 
            // additionalSettingsLabel
            // 
            this.additionalSettingsLabel.AutoSize = true;
            this.additionalSettingsLabel.Location = new System.Drawing.Point(3, 233);
            this.additionalSettingsLabel.Name = "additionalSettingsLabel";
            this.additionalSettingsLabel.Size = new System.Drawing.Size(85, 15);
            this.additionalSettingsLabel.TabIndex = 7;
            this.additionalSettingsLabel.Text = "Další nastavení";
            // 
            // additionalSettings
            // 
            this.additionalSettings.FormattingEnabled = true;
            this.additionalSettings.Items.AddRange(new object[] {
            "Kopírovat podložky",
            "Kopírovat pouze obrázky",
            "Přepsat již existující položky",
            "Uložit do nové složky",
            "Přidat k cílové složce datum"});
            this.additionalSettings.Location = new System.Drawing.Point(6, 251);
            this.additionalSettings.Name = "additionalSettings";
            this.additionalSettings.Size = new System.Drawing.Size(266, 166);
            this.additionalSettings.TabIndex = 6;
            this.additionalSettings.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.additionalSettings_ItemCheck);
            // 
            // targetPathButton
            // 
            this.targetPathButton.Location = new System.Drawing.Point(6, 202);
            this.targetPathButton.Name = "targetPathButton";
            this.targetPathButton.Size = new System.Drawing.Size(266, 23);
            this.targetPathButton.TabIndex = 5;
            this.targetPathButton.Text = "Výběr cílové cesty";
            this.targetPathButton.UseVisualStyleBackColor = true;
            this.targetPathButton.Click += new System.EventHandler(this.targetPathButton_Click);
            // 
            // targetPath
            // 
            this.targetPath.Location = new System.Drawing.Point(6, 173);
            this.targetPath.Name = "targetPath";
            this.targetPath.ReadOnly = true;
            this.targetPath.Size = new System.Drawing.Size(266, 23);
            this.targetPath.TabIndex = 4;
            // 
            // targetPathLabel
            // 
            this.targetPathLabel.AutoSize = true;
            this.targetPathLabel.Location = new System.Drawing.Point(6, 155);
            this.targetPathLabel.Name = "targetPathLabel";
            this.targetPathLabel.Size = new System.Drawing.Size(104, 15);
            this.targetPathLabel.TabIndex = 3;
            this.targetPathLabel.Text = "Cílová cesta (kam)";
            // 
            // sourcePathButton
            // 
            this.sourcePathButton.Location = new System.Drawing.Point(6, 55);
            this.sourcePathButton.Name = "sourcePathButton";
            this.sourcePathButton.Size = new System.Drawing.Size(266, 23);
            this.sourcePathButton.TabIndex = 2;
            this.sourcePathButton.Text = "Výběr zdrojové cesty";
            this.sourcePathButton.UseVisualStyleBackColor = true;
            this.sourcePathButton.Click += new System.EventHandler(this.sourcePathButton_Click);
            // 
            // sourcePathLabel
            // 
            this.sourcePathLabel.AutoSize = true;
            this.sourcePathLabel.Location = new System.Drawing.Point(6, 8);
            this.sourcePathLabel.Name = "sourcePathLabel";
            this.sourcePathLabel.Size = new System.Drawing.Size(132, 15);
            this.sourcePathLabel.TabIndex = 1;
            this.sourcePathLabel.Text = "Zdrojová cesta (odkud):";
            // 
            // sourcePath
            // 
            this.sourcePath.Location = new System.Drawing.Point(6, 26);
            this.sourcePath.Name = "sourcePath";
            this.sourcePath.ReadOnly = true;
            this.sourcePath.Size = new System.Drawing.Size(266, 23);
            this.sourcePath.TabIndex = 0;
            this.sourcePath.TextChanged += new System.EventHandler(this.sourcePath_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(278, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nápověda";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(9, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(260, 125);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Správce";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.resultGroup.ResumeLayout(false);
            this.resultGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label additionalSettingsLabel;
        private CheckedListBox additionalSettings;
        private Button targetPathButton;
        private TextBox targetPath;
        private Label targetPathLabel;
        private Button sourcePathButton;
        private Label sourcePathLabel;
        private TextBox sourcePath;
        private Label targetStatusLabel;
        private Label sourceStatusLabel;
        private Button directoriesCheck;
        private TextBox targetStatus;
        private TextBox sourceStatus;
        private Button copyButton;
        private GroupBox resultGroup;
        private Label copiedFilesCount;
        private Label label1;
        private ProgressBar progress;
        private TextBox resultState;
        private CheckBox isPhone;
        private Label mobilePathLabel;
        private TextBox mobilePath;
        private TabPage tabPage3;
        private TextBox textBox1;
    }
}