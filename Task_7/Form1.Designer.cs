namespace Task_7
{
    partial class Form1
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.yearRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.dayRadioButton = new System.Windows.Forms.RadioButton();
            this.minuteRadioButton = new System.Windows.Forms.RadioButton();
            this.secondRadioButton = new System.Windows.Forms.RadioButton();
            this.timeSpanButton = new System.Windows.Forms.Button();
            this.inputDate = new System.Windows.Forms.Label();
            this.outputDate = new System.Windows.Forms.Label();
            this.outputResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 55);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(182, 20);
            this.inputTextBox.TabIndex = 0;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(11, 312);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(182, 20);
            this.outputTextBox.TabIndex = 1;
            // 
            // yearRadioButton
            // 
            this.yearRadioButton.AutoSize = true;
            this.yearRadioButton.Location = new System.Drawing.Point(12, 105);
            this.yearRadioButton.Name = "yearRadioButton";
            this.yearRadioButton.Size = new System.Drawing.Size(53, 17);
            this.yearRadioButton.TabIndex = 2;
            this.yearRadioButton.TabStop = true;
            this.yearRadioButton.Text = "годах";
            this.yearRadioButton.UseVisualStyleBackColor = true;
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(12, 128);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(68, 17);
            this.monthRadioButton.TabIndex = 3;
            this.monthRadioButton.TabStop = true;
            this.monthRadioButton.Text = "месяцах";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            // 
            // dayRadioButton
            // 
            this.dayRadioButton.AutoSize = true;
            this.dayRadioButton.Location = new System.Drawing.Point(12, 151);
            this.dayRadioButton.Name = "dayRadioButton";
            this.dayRadioButton.Size = new System.Drawing.Size(48, 17);
            this.dayRadioButton.TabIndex = 4;
            this.dayRadioButton.TabStop = true;
            this.dayRadioButton.Text = "днях";
            this.dayRadioButton.UseVisualStyleBackColor = true;
            // 
            // minuteRadioButton
            // 
            this.minuteRadioButton.AutoSize = true;
            this.minuteRadioButton.Location = new System.Drawing.Point(12, 174);
            this.minuteRadioButton.Name = "minuteRadioButton";
            this.minuteRadioButton.Size = new System.Drawing.Size(66, 17);
            this.minuteRadioButton.TabIndex = 5;
            this.minuteRadioButton.TabStop = true;
            this.minuteRadioButton.Text = "минутах";
            this.minuteRadioButton.UseVisualStyleBackColor = true;
            // 
            // secondRadioButton
            // 
            this.secondRadioButton.AutoSize = true;
            this.secondRadioButton.Location = new System.Drawing.Point(12, 197);
            this.secondRadioButton.Name = "secondRadioButton";
            this.secondRadioButton.Size = new System.Drawing.Size(71, 17);
            this.secondRadioButton.TabIndex = 6;
            this.secondRadioButton.TabStop = true;
            this.secondRadioButton.Text = "секундах";
            this.secondRadioButton.UseVisualStyleBackColor = true;
            // 
            // timeSpanButton
            // 
            this.timeSpanButton.Location = new System.Drawing.Point(12, 220);
            this.timeSpanButton.Name = "timeSpanButton";
            this.timeSpanButton.Size = new System.Drawing.Size(181, 23);
            this.timeSpanButton.TabIndex = 7;
            this.timeSpanButton.Text = "Считать";
            this.timeSpanButton.UseVisualStyleBackColor = true;
            this.timeSpanButton.Click += new System.EventHandler(this.timeSpanButton_Click);
            // 
            // inputDate
            // 
            this.inputDate.AutoSize = true;
            this.inputDate.Location = new System.Drawing.Point(12, 39);
            this.inputDate.Name = "inputDate";
            this.inputDate.Size = new System.Drawing.Size(77, 13);
            this.inputDate.TabIndex = 8;
            this.inputDate.Text = "Укажите дату";
            // 
            // outputDate
            // 
            this.outputDate.AutoSize = true;
            this.outputDate.Location = new System.Drawing.Point(9, 296);
            this.outputDate.Name = "outputDate";
            this.outputDate.Size = new System.Drawing.Size(100, 13);
            this.outputDate.TabIndex = 9;
            this.outputDate.Text = "До даты осталось";
            // 
            // outputResult
            // 
            this.outputResult.AutoSize = true;
            this.outputResult.Location = new System.Drawing.Point(12, 89);
            this.outputResult.Name = "outputResult";
            this.outputResult.Size = new System.Drawing.Size(119, 13);
            this.outputResult.TabIndex = 10;
            this.outputResult.Text = "Показать результат в";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.outputResult);
            this.Controls.Add(this.outputDate);
            this.Controls.Add(this.inputDate);
            this.Controls.Add(this.timeSpanButton);
            this.Controls.Add(this.secondRadioButton);
            this.Controls.Add(this.minuteRadioButton);
            this.Controls.Add(this.dayRadioButton);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.yearRadioButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.RadioButton yearRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.RadioButton dayRadioButton;
        private System.Windows.Forms.RadioButton minuteRadioButton;
        private System.Windows.Forms.RadioButton secondRadioButton;
        private System.Windows.Forms.Button timeSpanButton;
        private System.Windows.Forms.Label inputDate;
        private System.Windows.Forms.Label outputDate;
        private System.Windows.Forms.Label outputResult;
    }
}

