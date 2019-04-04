namespace emulatorMT
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelNumberProcessedWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tapeContainer = new System.Windows.Forms.Panel();
            this.logPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.commandsPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.startStateTextBox = new System.Windows.Forms.TextBox();
            this.loadCmdFromFileBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.commandsTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resumeMTBtn = new System.Windows.Forms.Button();
            this.pauseMTBtn = new System.Windows.Forms.Button();
            this.createAndShowChartBtn = new System.Windows.Forms.Button();
            this.slowRadioButton = new System.Windows.Forms.RadioButton();
            this.normalRadioButton = new System.Windows.Forms.RadioButton();
            this.fastRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.startMTBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.wordLenghtNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.commandsPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordLenghtNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLog});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // saveLog
            // 
            this.saveLog.Enabled = false;
            this.saveLog.Image = ((System.Drawing.Image)(resources.GetObject("saveLog.Image")));
            this.saveLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveLog.Name = "saveLog";
            this.saveLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveLog.Size = new System.Drawing.Size(194, 22);
            this.saveLog.Text = "&Сохранить лог";
            this.saveLog.Click += new System.EventHandler(this.saveLog_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelNumberProcessedWords});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelNumberProcessedWords
            // 
            this.LabelNumberProcessedWords.Name = "LabelNumberProcessedWords";
            this.LabelNumberProcessedWords.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tapeContainer);
            this.groupBox1.Controls.Add(this.logPanel);
            this.groupBox1.Controls.Add(this.commandsPanel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1184, 515);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // tapeContainer
            // 
            this.tapeContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tapeContainer.BackColor = System.Drawing.SystemColors.Control;
            this.tapeContainer.Location = new System.Drawing.Point(153, 16);
            this.tapeContainer.Name = "tapeContainer";
            this.tapeContainer.Size = new System.Drawing.Size(758, 213);
            this.tapeContainer.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logPanel.BackColor = System.Drawing.Color.DarkCyan;
            this.logPanel.Controls.Add(this.label4);
            this.logPanel.Controls.Add(this.logTextBox);
            this.logPanel.Location = new System.Drawing.Point(153, 235);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(758, 274);
            this.logPanel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Лог:";
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTextBox.Location = new System.Drawing.Point(3, 28);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(752, 243);
            this.logTextBox.TabIndex = 0;
            // 
            // commandsPanel
            // 
            this.commandsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsPanel.AutoScroll = true;
            this.commandsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.commandsPanel.Controls.Add(this.label6);
            this.commandsPanel.Controls.Add(this.startStateTextBox);
            this.commandsPanel.Controls.Add(this.loadCmdFromFileBtn);
            this.commandsPanel.Controls.Add(this.label3);
            this.commandsPanel.Controls.Add(this.commandsTextBox);
            this.commandsPanel.Location = new System.Drawing.Point(917, 16);
            this.commandsPanel.Name = "commandsPanel";
            this.commandsPanel.Size = new System.Drawing.Size(255, 493);
            this.commandsPanel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Номер начального состояния:";
            // 
            // startStateTextBox
            // 
            this.startStateTextBox.Location = new System.Drawing.Point(171, 7);
            this.startStateTextBox.Name = "startStateTextBox";
            this.startStateTextBox.Size = new System.Drawing.Size(81, 20);
            this.startStateTextBox.TabIndex = 16;
            // 
            // loadCmdFromFileBtn
            // 
            this.loadCmdFromFileBtn.Location = new System.Drawing.Point(177, 34);
            this.loadCmdFromFileBtn.Name = "loadCmdFromFileBtn";
            this.loadCmdFromFileBtn.Size = new System.Drawing.Size(75, 23);
            this.loadCmdFromFileBtn.TabIndex = 14;
            this.loadCmdFromFileBtn.Text = "Загрузить";
            this.loadCmdFromFileBtn.UseVisualStyleBackColor = true;
            this.loadCmdFromFileBtn.Click += new System.EventHandler(this.loadCmdFromFileBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Список команд:";
            // 
            // commandsTextBox
            // 
            this.commandsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsTextBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commandsTextBox.Location = new System.Drawing.Point(3, 61);
            this.commandsTextBox.Multiline = true;
            this.commandsTextBox.Name = "commandsTextBox";
            this.commandsTextBox.ReadOnly = true;
            this.commandsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commandsTextBox.Size = new System.Drawing.Size(249, 429);
            this.commandsTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.wordLenghtNumUpDown);
            this.groupBox2.Controls.Add(this.resumeMTBtn);
            this.groupBox2.Controls.Add(this.pauseMTBtn);
            this.groupBox2.Controls.Add(this.createAndShowChartBtn);
            this.groupBox2.Controls.Add(this.slowRadioButton);
            this.groupBox2.Controls.Add(this.normalRadioButton);
            this.groupBox2.Controls.Add(this.fastRadioButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.wordTextBox);
            this.groupBox2.Controls.Add(this.startMTBtn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 509);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // resumeMTBtn
            // 
            this.resumeMTBtn.Enabled = false;
            this.resumeMTBtn.Location = new System.Drawing.Point(28, 206);
            this.resumeMTBtn.Name = "resumeMTBtn";
            this.resumeMTBtn.Size = new System.Drawing.Size(83, 23);
            this.resumeMTBtn.TabIndex = 12;
            this.resumeMTBtn.Text = "Продолжить";
            this.resumeMTBtn.UseVisualStyleBackColor = true;
            this.resumeMTBtn.Click += new System.EventHandler(this.resumeMT_Click);
            // 
            // pauseMTBtn
            // 
            this.pauseMTBtn.Enabled = false;
            this.pauseMTBtn.Location = new System.Drawing.Point(28, 177);
            this.pauseMTBtn.Name = "pauseMTBtn";
            this.pauseMTBtn.Size = new System.Drawing.Size(83, 23);
            this.pauseMTBtn.TabIndex = 10;
            this.pauseMTBtn.Text = "Пауза";
            this.pauseMTBtn.UseVisualStyleBackColor = true;
            this.pauseMTBtn.Click += new System.EventHandler(this.pauseMT_Click);
            // 
            // createAndShowChartBtn
            // 
            this.createAndShowChartBtn.Location = new System.Drawing.Point(6, 263);
            this.createAndShowChartBtn.Name = "createAndShowChartBtn";
            this.createAndShowChartBtn.Size = new System.Drawing.Size(83, 25);
            this.createAndShowChartBtn.TabIndex = 9;
            this.createAndShowChartBtn.Text = "График";
            this.createAndShowChartBtn.UseVisualStyleBackColor = true;
            this.createAndShowChartBtn.Click += new System.EventHandler(this.createAndShowChart_Click);
            // 
            // slowRadioButton
            // 
            this.slowRadioButton.AutoSize = true;
            this.slowRadioButton.Location = new System.Drawing.Point(28, 123);
            this.slowRadioButton.Name = "slowRadioButton";
            this.slowRadioButton.Size = new System.Drawing.Size(76, 17);
            this.slowRadioButton.TabIndex = 7;
            this.slowRadioButton.Text = "Медленно";
            this.slowRadioButton.UseVisualStyleBackColor = true;
            // 
            // normalRadioButton
            // 
            this.normalRadioButton.AutoSize = true;
            this.normalRadioButton.Location = new System.Drawing.Point(28, 100);
            this.normalRadioButton.Name = "normalRadioButton";
            this.normalRadioButton.Size = new System.Drawing.Size(83, 17);
            this.normalRadioButton.TabIndex = 6;
            this.normalRadioButton.Text = "Нормально";
            this.normalRadioButton.UseVisualStyleBackColor = true;
            // 
            // fastRadioButton
            // 
            this.fastRadioButton.AutoSize = true;
            this.fastRadioButton.Checked = true;
            this.fastRadioButton.Location = new System.Drawing.Point(28, 77);
            this.fastRadioButton.Name = "fastRadioButton";
            this.fastRadioButton.Size = new System.Drawing.Size(63, 17);
            this.fastRadioButton.TabIndex = 5;
            this.fastRadioButton.TabStop = true;
            this.fastRadioButton.Text = "Быстро";
            this.fastRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cкорость выполнения: ";
            // 
            // wordTextBox
            // 
            this.wordTextBox.Location = new System.Drawing.Point(22, 32);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(100, 20);
            this.wordTextBox.TabIndex = 3;
            this.wordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // startMTBtn
            // 
            this.startMTBtn.Location = new System.Drawing.Point(28, 146);
            this.startMTBtn.Name = "startMTBtn";
            this.startMTBtn.Size = new System.Drawing.Size(83, 23);
            this.startMTBtn.TabIndex = 2;
            this.startMTBtn.Text = "Старт";
            this.startMTBtn.UseVisualStyleBackColor = true;
            this.startMTBtn.Click += new System.EventHandler(this.startMT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Входное слово (0,1):";
            // 
            // wordLenghtNumUpDown
            // 
            this.wordLenghtNumUpDown.Location = new System.Drawing.Point(96, 266);
            this.wordLenghtNumUpDown.Name = "wordLenghtNumUpDown";
            this.wordLenghtNumUpDown.Size = new System.Drawing.Size(45, 20);
            this.wordLenghtNumUpDown.TabIndex = 13;
            this.wordLenghtNumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.wordLenghtNumUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.commandsPanel.ResumeLayout(false);
            this.commandsPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordLenghtNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelNumberProcessedWords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Panel commandsPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button resumeMTBtn;
        private System.Windows.Forms.Button pauseMTBtn;
        private System.Windows.Forms.Button createAndShowChartBtn;
        private System.Windows.Forms.RadioButton slowRadioButton;
        private System.Windows.Forms.RadioButton normalRadioButton;
        private System.Windows.Forms.RadioButton fastRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Button startMTBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel tapeContainer;
        private System.Windows.Forms.TextBox commandsTextBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button loadCmdFromFileBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox startStateTextBox;
        private System.Windows.Forms.NumericUpDown wordLenghtNumUpDown;
    }
}

