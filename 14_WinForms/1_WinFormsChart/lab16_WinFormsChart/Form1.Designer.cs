
namespace lab16_WinFormsChart
{
    partial class Form
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonFunc1 = new System.Windows.Forms.RadioButton();
            this.radioButtonFunc2 = new System.Windows.Forms.RadioButton();
            this.X0textBox = new System.Windows.Forms.TextBox();
            this.XNtextBox = new System.Windows.Forms.TextBox();
            this.BtextBox = new System.Windows.Forms.TextBox();
            this.AtextBox = new System.Windows.Forms.TextBox();
            this.StepComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.UpdateDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(632, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Хнач";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(696, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Хкон";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(772, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "dx";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(646, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "b";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(711, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "a";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(627, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Функция";
            // 
            // radioButtonFunc1
            // 
            this.radioButtonFunc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonFunc1.AutoSize = true;
            this.radioButtonFunc1.Checked = true;
            this.radioButtonFunc1.Image = global::lab16_WinFormsChart.Properties.Resources.func1;
            this.radioButtonFunc1.Location = new System.Drawing.Point(631, 35);
            this.radioButtonFunc1.Name = "radioButtonFunc1";
            this.radioButtonFunc1.Size = new System.Drawing.Size(185, 30);
            this.radioButtonFunc1.TabIndex = 0;
            this.radioButtonFunc1.TabStop = true;
            this.radioButtonFunc1.UseVisualStyleBackColor = true;
            this.radioButtonFunc1.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // radioButtonFunc2
            // 
            this.radioButtonFunc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonFunc2.AutoSize = true;
            this.radioButtonFunc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonFunc2.Image = global::lab16_WinFormsChart.Properties.Resources.func2;
            this.radioButtonFunc2.Location = new System.Drawing.Point(631, 66);
            this.radioButtonFunc2.Name = "radioButtonFunc2";
            this.radioButtonFunc2.Size = new System.Drawing.Size(181, 34);
            this.radioButtonFunc2.TabIndex = 8;
            this.radioButtonFunc2.UseVisualStyleBackColor = true;
            this.radioButtonFunc2.CheckedChanged += new System.EventHandler(this.RadioButton_Checked);
            // 
            // X0textBox
            // 
            this.X0textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.X0textBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.X0textBox.Location = new System.Drawing.Point(631, 201);
            this.X0textBox.Name = "X0textBox";
            this.X0textBox.Size = new System.Drawing.Size(51, 29);
            this.X0textBox.TabIndex = 10;
            // 
            // XNtextBox
            // 
            this.XNtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XNtextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XNtextBox.Location = new System.Drawing.Point(696, 201);
            this.XNtextBox.Name = "XNtextBox";
            this.XNtextBox.Size = new System.Drawing.Size(51, 29);
            this.XNtextBox.TabIndex = 11;
            // 
            // BtextBox
            // 
            this.BtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtextBox.Location = new System.Drawing.Point(631, 264);
            this.BtextBox.Name = "BtextBox";
            this.BtextBox.Size = new System.Drawing.Size(51, 29);
            this.BtextBox.TabIndex = 12;
            // 
            // AtextBox
            // 
            this.AtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AtextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AtextBox.Location = new System.Drawing.Point(696, 264);
            this.AtextBox.Name = "AtextBox";
            this.AtextBox.Size = new System.Drawing.Size(51, 29);
            this.AtextBox.TabIndex = 13;
            // 
            // StepComboBox
            // 
            this.StepComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StepComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StepComboBox.FormattingEnabled = true;
            this.StepComboBox.Items.AddRange(new object[] {
            "0,1",
            "0,5",
            "1",
            "5",
            "10"});
            this.StepComboBox.Location = new System.Drawing.Point(758, 201);
            this.StepComboBox.Name = "StepComboBox";
            this.StepComboBox.Size = new System.Drawing.Size(58, 29);
            this.StepComboBox.TabIndex = 14;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(627, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Данные";
            // 
            // UpdateDataButton
            // 
            this.UpdateDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDataButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateDataButton.Location = new System.Drawing.Point(715, 114);
            this.UpdateDataButton.Name = "UpdateDataButton";
            this.UpdateDataButton.Size = new System.Drawing.Size(101, 34);
            this.UpdateDataButton.TabIndex = 16;
            this.UpdateDataButton.TabStop = false;
            this.UpdateDataButton.Text = "Обновить";
            this.UpdateDataButton.UseVisualStyleBackColor = true;
            this.UpdateDataButton.Click += new System.EventHandler(this.UpdateDataButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 386);
            this.Controls.Add(this.UpdateDataButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StepComboBox);
            this.Controls.Add(this.AtextBox);
            this.Controls.Add(this.BtextBox);
            this.Controls.Add(this.XNtextBox);
            this.Controls.Add(this.X0textBox);
            this.Controls.Add(this.radioButtonFunc2);
            this.Controls.Add(this.radioButtonFunc1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form";
            this.Text = "Function Diagram";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonFunc1;
        private System.Windows.Forms.RadioButton radioButtonFunc2;
        private System.Windows.Forms.TextBox X0textBox;
        private System.Windows.Forms.TextBox XNtextBox;
        private System.Windows.Forms.TextBox BtextBox;
        private System.Windows.Forms.TextBox AtextBox;
        private System.Windows.Forms.ComboBox StepComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button UpdateDataButton;
        private System.Windows.Forms.Label label7;
    }
}

