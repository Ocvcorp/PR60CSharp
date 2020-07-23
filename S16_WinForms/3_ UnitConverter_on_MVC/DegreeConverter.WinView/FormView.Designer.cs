namespace DegreeConverter.WinView
{
	partial class FormView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this._Unit1Box = new System.Windows.Forms.TextBox();
            this._Unit2Box = new System.Windows.Forms.TextBox();
            this.Unit1Label = new System.Windows.Forms.Label();
            this.Unit2Label = new System.Windows.Forms.Label();
            this._inputBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._Unit1Button = new System.Windows.Forms.Button();
            this._Unit2Button = new System.Windows.Forms.Button();
            this.unitsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _Unit1Box
            // 
            this._Unit1Box.Location = new System.Drawing.Point(138, 60);
            this._Unit1Box.Name = "_Unit1Box";
            this._Unit1Box.ReadOnly = true;
            this._Unit1Box.Size = new System.Drawing.Size(73, 20);
            this._Unit1Box.TabIndex = 0;
            // 
            // _Unit2Box
            // 
            this._Unit2Box.Location = new System.Drawing.Point(138, 86);
            this._Unit2Box.Name = "_Unit2Box";
            this._Unit2Box.ReadOnly = true;
            this._Unit2Box.Size = new System.Drawing.Size(73, 20);
            this._Unit2Box.TabIndex = 1;
            // 
            // Unit1Label
            // 
            this.Unit1Label.AutoSize = true;
            this.Unit1Label.Location = new System.Drawing.Point(12, 60);
            this.Unit1Label.Name = "Unit1Label";
            this.Unit1Label.Size = new System.Drawing.Size(59, 13);
            this.Unit1Label.TabIndex = 2;
            this.Unit1Label.Text = "Единица1:";
            // 
            // Unit2Label
            // 
            this.Unit2Label.AutoSize = true;
            this.Unit2Label.Location = new System.Drawing.Point(12, 89);
            this.Unit2Label.Name = "Unit2Label";
            this.Unit2Label.Size = new System.Drawing.Size(59, 13);
            this.Unit2Label.TabIndex = 3;
            this.Unit2Label.Text = "Единица2:";
            // 
            // _inputBox
            // 
            this._inputBox.Location = new System.Drawing.Point(365, 57);
            this._inputBox.Name = "_inputBox";
            this._inputBox.Size = new System.Drawing.Size(98, 20);
            this._inputBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Новое значение:";
            // 
            // _Unit1Button
            // 
            this._Unit1Button.Enabled = false;
            this._Unit1Button.Location = new System.Drawing.Point(270, 86);
            this._Unit1Button.Name = "_Unit1Button";
            this._Unit1Button.Size = new System.Drawing.Size(89, 23);
            this._Unit1Button.TabIndex = 6;
            this._Unit1Button.Text = "В Единицах1";
            this._Unit1Button.UseVisualStyleBackColor = true;
            this._Unit1Button.Click += new System.EventHandler(this._Unit1Button_Click);
            // 
            // _Unit2Button
            // 
            this._Unit2Button.Enabled = false;
            this._Unit2Button.Location = new System.Drawing.Point(363, 86);
            this._Unit2Button.Name = "_Unit2Button";
            this._Unit2Button.Size = new System.Drawing.Size(100, 23);
            this._Unit2Button.TabIndex = 7;
            this._Unit2Button.Text = "В Единицах2";
            this._Unit2Button.UseVisualStyleBackColor = true;
            this._Unit2Button.Click += new System.EventHandler(this._Unit2Button_Click);
            // 
            // unitsComboBox
            // 
            this.unitsComboBox.FormattingEnabled = true;
            this.unitsComboBox.Items.AddRange(new object[] {
            "Градусы Целься - Градусы Фаренгейта",
            "Километры - Мили",
            "Килограммы - Фунты",
            "Рубли - Доллары",
            "Мегабайты - Биты"});
            this.unitsComboBox.Location = new System.Drawing.Point(15, 22);
            this.unitsComboBox.Name = "unitsComboBox";
            this.unitsComboBox.Size = new System.Drawing.Size(447, 21);
            this.unitsComboBox.TabIndex = 8;
            this.unitsComboBox.SelectedIndexChanged += new System.EventHandler(this._UnitsComboBox_Select);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Единицы измерения:";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 122);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unitsComboBox);
            this.Controls.Add(this._Unit2Button);
            this.Controls.Add(this._Unit1Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._inputBox);
            this.Controls.Add(this.Unit2Label);
            this.Controls.Add(this.Unit1Label);
            this.Controls.Add(this._Unit2Box);
            this.Controls.Add(this._Unit1Box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormView";
            this.Text = "Unit Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _Unit1Box;
		private System.Windows.Forms.TextBox _Unit2Box;
		private System.Windows.Forms.Label Unit1Label;
		private System.Windows.Forms.Label Unit2Label;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button _Unit1Button;
		private System.Windows.Forms.Button _Unit2Button;
		private System.Windows.Forms.TextBox _inputBox;
        private System.Windows.Forms.ComboBox unitsComboBox;
        private System.Windows.Forms.Label label4;
    }
}

