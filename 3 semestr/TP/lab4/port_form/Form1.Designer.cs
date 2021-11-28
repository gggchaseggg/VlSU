namespace port_form
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
            this.GetInfo_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.AddPassenger_Button = new System.Windows.Forms.Button();
            this.AddSudno_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxVmestimost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxVes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxPassengerAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveSudnoInfo_Button = new System.Windows.Forms.Button();
            this.BackToMenu_Button = new System.Windows.Forms.Button();
            this.TextBoxNamePassenger = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxSat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SavePassengerAmount_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetInfo_Button
            // 
            this.GetInfo_Button.BackColor = System.Drawing.Color.SkyBlue;
            this.GetInfo_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GetInfo_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GetInfo_Button.ForeColor = System.Drawing.Color.Black;
            this.GetInfo_Button.Location = new System.Drawing.Point(65, 149);
            this.GetInfo_Button.Name = "GetInfo_Button";
            this.GetInfo_Button.Size = new System.Drawing.Size(200, 50);
            this.GetInfo_Button.TabIndex = 7;
            this.GetInfo_Button.Text = "Получить информацию";
            this.GetInfo_Button.UseVisualStyleBackColor = false;
            this.GetInfo_Button.Click += new System.EventHandler(this.GetInfo_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Exit_Button.ForeColor = System.Drawing.Color.White;
            this.Exit_Button.Location = new System.Drawing.Point(65, 309);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(200, 50);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Text = "Выход";
            this.Exit_Button.UseVisualStyleBackColor = false;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // AddPassenger_Button
            // 
            this.AddPassenger_Button.BackColor = System.Drawing.Color.SkyBlue;
            this.AddPassenger_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddPassenger_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddPassenger_Button.ForeColor = System.Drawing.Color.Black;
            this.AddPassenger_Button.Location = new System.Drawing.Point(65, 229);
            this.AddPassenger_Button.Name = "AddPassenger_Button";
            this.AddPassenger_Button.Size = new System.Drawing.Size(200, 50);
            this.AddPassenger_Button.TabIndex = 5;
            this.AddPassenger_Button.Text = "Добавить пассажиров";
            this.AddPassenger_Button.UseVisualStyleBackColor = false;
            this.AddPassenger_Button.Click += new System.EventHandler(this.AddPassenger_Button_Click);
            // 
            // AddSudno_Button
            // 
            this.AddSudno_Button.BackColor = System.Drawing.Color.YellowGreen;
            this.AddSudno_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSudno_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddSudno_Button.ForeColor = System.Drawing.Color.Black;
            this.AddSudno_Button.Location = new System.Drawing.Point(65, 69);
            this.AddSudno_Button.Margin = new System.Windows.Forms.Padding(0);
            this.AddSudno_Button.Name = "AddSudno_Button";
            this.AddSudno_Button.Size = new System.Drawing.Size(200, 50);
            this.AddSudno_Button.TabIndex = 4;
            this.AddSudno_Button.Text = "Добавить судно";
            this.AddSudno_Button.UseVisualStyleBackColor = false;
            this.AddSudno_Button.Click += new System.EventHandler(this.AddSudno_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название Судна";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(152, 36);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(160, 20);
            this.TextBoxName.TabIndex = 9;
            // 
            // TextBoxVmestimost
            // 
            this.TextBoxVmestimost.Location = new System.Drawing.Point(152, 86);
            this.TextBoxVmestimost.Name = "TextBoxVmestimost";
            this.TextBoxVmestimost.Size = new System.Drawing.Size(160, 20);
            this.TextBoxVmestimost.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Вместимость";
            // 
            // TextBoxVes
            // 
            this.TextBoxVes.Location = new System.Drawing.Point(152, 143);
            this.TextBoxVes.Name = "TextBoxVes";
            this.TextBoxVes.Size = new System.Drawing.Size(160, 20);
            this.TextBoxVes.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Вес";
            // 
            // TextBoxPassengerAmount
            // 
            this.TextBoxPassengerAmount.Location = new System.Drawing.Point(152, 197);
            this.TextBoxPassengerAmount.Name = "TextBoxPassengerAmount";
            this.TextBoxPassengerAmount.Size = new System.Drawing.Size(160, 20);
            this.TextBoxPassengerAmount.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Кол-во людей";
            // 
            // SaveSudnoInfo_Button
            // 
            this.SaveSudnoInfo_Button.BackColor = System.Drawing.Color.YellowGreen;
            this.SaveSudnoInfo_Button.Location = new System.Drawing.Point(54, 285);
            this.SaveSudnoInfo_Button.Name = "SaveSudnoInfo_Button";
            this.SaveSudnoInfo_Button.Size = new System.Drawing.Size(220, 40);
            this.SaveSudnoInfo_Button.TabIndex = 16;
            this.SaveSudnoInfo_Button.Text = "Сохранить";
            this.SaveSudnoInfo_Button.UseVisualStyleBackColor = false;
            this.SaveSudnoInfo_Button.Click += new System.EventHandler(this.SaveSudnoInfo_Button_Click);
            // 
            // BackToMenu_Button
            // 
            this.BackToMenu_Button.BackColor = System.Drawing.Color.LightCoral;
            this.BackToMenu_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackToMenu_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BackToMenu_Button.ForeColor = System.Drawing.Color.White;
            this.BackToMenu_Button.Location = new System.Drawing.Point(65, 370);
            this.BackToMenu_Button.Name = "BackToMenu_Button";
            this.BackToMenu_Button.Size = new System.Drawing.Size(200, 50);
            this.BackToMenu_Button.TabIndex = 17;
            this.BackToMenu_Button.Text = "Назад";
            this.BackToMenu_Button.UseVisualStyleBackColor = false;
            this.BackToMenu_Button.Click += new System.EventHandler(this.BackToMenu_Button_Click);
            // 
            // TextBoxNamePassenger
            // 
            this.TextBoxNamePassenger.Location = new System.Drawing.Point(152, 61);
            this.TextBoxNamePassenger.Name = "TextBoxNamePassenger";
            this.TextBoxNamePassenger.Size = new System.Drawing.Size(160, 20);
            this.TextBoxNamePassenger.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(12, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Название Судна";
            // 
            // TextBoxSat
            // 
            this.TextBoxSat.Location = new System.Drawing.Point(152, 112);
            this.TextBoxSat.Name = "TextBoxSat";
            this.TextBoxSat.Size = new System.Drawing.Size(160, 20);
            this.TextBoxSat.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Кол-во людей";
            // 
            // SavePassengerAmount_Button
            // 
            this.SavePassengerAmount_Button.BackColor = System.Drawing.Color.YellowGreen;
            this.SavePassengerAmount_Button.Location = new System.Drawing.Point(54, 309);
            this.SavePassengerAmount_Button.Name = "SavePassengerAmount_Button";
            this.SavePassengerAmount_Button.Size = new System.Drawing.Size(220, 40);
            this.SavePassengerAmount_Button.TabIndex = 22;
            this.SavePassengerAmount_Button.Text = "Сохранить";
            this.SavePassengerAmount_Button.UseVisualStyleBackColor = false;
            this.SavePassengerAmount_Button.Click += new System.EventHandler(this.SavePassengerAmount_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(324, 451);
            this.Controls.Add(this.SavePassengerAmount_Button);
            this.Controls.Add(this.TextBoxSat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBoxNamePassenger);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BackToMenu_Button);
            this.Controls.Add(this.SaveSudnoInfo_Button);
            this.Controls.Add(this.TextBoxPassengerAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxVes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxVmestimost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetInfo_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.AddPassenger_Button);
            this.Controls.Add(this.AddSudno_Button);
            this.Location = new System.Drawing.Point(150, 150);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetInfo_Button;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button AddPassenger_Button;
        private System.Windows.Forms.Button AddSudno_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxVmestimost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxVes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxPassengerAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveSudnoInfo_Button;
        private System.Windows.Forms.Button BackToMenu_Button;
        private System.Windows.Forms.TextBox TextBoxNamePassenger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxSat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SavePassengerAmount_Button;
    }
}

