using System;
using System.Windows.Forms;
using DegreeConverter.Engine;

namespace DegreeConverter.WinView
{
	public partial class FormView : Form, IView
	{
		public FormView()
		{
			InitializeComponent();
		}

		#region ���������� IView
		/// <summary>
		/// ��������� �������� ���������� ������
		/// </summary>
		public void SetLabels(string labelNameUnit1, string buttonNameUnit1, string labelNameUnit2, string buttonNameUnit2)
        {
			Unit1Label.Text = labelNameUnit1;
			_Unit1Button.Text = buttonNameUnit1;
			Unit2Label.Text = labelNameUnit2;
			_Unit2Button.Text = buttonNameUnit2;
		}

		/// <summary>
		/// ����� 2�� �������
		/// </summary>
		public void SetUnit2(double unit, string unitFormat)
		{
			_Unit2Box.Text = unit.ToString(unitFormat);
			
		}

		/// <summary>
		/// ����� 1�� �������
		/// </summary>
		public void SetUnit1(double unit, string unitFormat)
		{
			_Unit1Box.Text = unit.ToString(unitFormat);
		}
		
		/// <summary>
		/// �������������� ������� ������ � ������� ������������ ��� ������
		/// </summary>
		public Units UnitsIndex
        {
			get {
				Units units = Units.CelsiusFahrenheit;
				switch(unitsComboBox.SelectedIndex)
                {
					case 0:
						units = Units.CelsiusFahrenheit;
						break;
					case 1:
						units = Units.KilometerMile;
						break;
					case 2:
						units = Units.KilogramsPound;
						break;
					case 3:
						units = Units.RubleDollar;
						break;
					case 4:
						units = Units.MbBit;
						break;
				}
				return units; 
			}
        }
		/// <summary>
		/// ���� ������ �������� �������
		/// </summary>
		public double InputUnit
		{
			get 
			{
				double input=0.00;
				try 
				{ 
					input=Convert.ToDouble(_inputBox.Text); 
				}
				catch(Exception e) 
				{ 
					MessageBox.Show(e.Message);
					_inputBox.Text = "0";
				}
				return input;
			}
		}

		/// <summary>
		/// ������� ����� �������� 2�� �������
		/// </summary>
		public event EventHandler<EventArgs> Unit2Setted;

		/// <summary>
		/// ������� ����� �������� 1�� �������
		/// </summary>
		public event EventHandler<EventArgs> Unit1Setted;
		
		/// <summary>
		/// ������� ������ �������������������� ������ �� ������
		/// </summary>
		public event EventHandler<EventArgs> UnitsSelected;

		#endregion

		/// <summary>
		/// ��������� ������� ���� ����������, ��� ������ ��������������
		/// � ��������������� ������� �����������
		/// </summary>
		private void _UnitsComboBox_Select(object sender, EventArgs e)
        {
			if (UnitsSelected != null)
				UnitsSelected(this, EventArgs.Empty);
			_Unit1Button.Enabled = true;
			_Unit2Button.Enabled = true;
		}
		private void _Unit1Button_Click(object sender, EventArgs e)
		{
			if (Unit1Setted != null)
				Unit1Setted(this, EventArgs.Empty);
		}

		private void _Unit2Button_Click(object sender, EventArgs e)
		{
			if (Unit2Setted != null)
				Unit2Setted(this, EventArgs.Empty);
		}

    }
}