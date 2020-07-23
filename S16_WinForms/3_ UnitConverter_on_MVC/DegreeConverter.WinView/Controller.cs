using System;
using DegreeConverter.Engine;

namespace DegreeConverter.WinView
{
	public class Controller
	{
		private Model _model = new Model();
		private IView _view;

		private string unitFormat;

		public Controller(IView view)
		{
			_view = view;
			_view.UnitsSelected += new EventHandler<EventArgs>(OnSelectUnits);
			_view.Unit1Setted += new EventHandler<EventArgs>(OnSetUnit1);
			_view.Unit2Setted += new EventHandler<EventArgs>(OnSetUnit2);
			RefreshView("");
		}

		/// <summary>
		/// ��������� ������� ������ ���� ������ �� ������
		/// </summary>
		private void OnSelectUnits(object sender, EventArgs e)
        {
			_model.units = _view.UnitsIndex;
			//������������� �������
			string label1 = "", button1 = "", label2 = "", button2 = "";
			switch(_view.UnitsIndex)
            {
				case Units.CelsiusFahrenheit:
					label1 = "������� �������";
					button1 = "� ��������";
					label2 = "������� ����������";
					button2 = "� �����������";
					unitFormat = "N2";
					_model.valueUnit1 = 0.0;
					_model.valueUnit2 = 32.0;
					break;
				case Units.KilometerMile:
					label1 = "���������";
					button1 = "� ����������";
					label2 = "����";
					button2 = "� �����";
					unitFormat = "N2";
					_model.valueUnit1 = 0.0;
					_model.valueUnit2 = 0.0;
					break;
				case Units.KilogramsPound:
					label1 = "����������";
					button1 = "� ��";
					label2 = "�����";
					button2 = "� ������";
					unitFormat = "N2";
					_model.valueUnit1 = 0.0;
					_model.valueUnit2 = 0.0;
					break;
				case Units.RubleDollar:
					label1 = "�����";
					button1 = "� ������";
					label2 = "�������";
					button2 = "� ��������";
					unitFormat = "N2";
					_model.valueUnit1 = 0.0;
					_model.valueUnit2 = 0.0;
					break;
				case Units.MbBit:
					label1 = "���������";
					button1 = "� ����������";
					label2 = "����";
					button2 = "� �����";
					unitFormat = "N4";
					_model.valueUnit1 = 0.0;
					_model.valueUnit2 = 0.0;
					break;
			}
			_view.SetLabels(label1 , button1 , label2 ,button2);
			RefreshView(unitFormat);
		}

		/// <summary>
		/// ��������� �������, ��������� ������ �������� ������� 2
		/// </summary>
		private void OnSetUnit2(object sender, EventArgs e)
		{
			_model.valueUnit2 = _view.InputUnit;
			RefreshView(unitFormat);
		}

		/// <summary>
		/// ��������� �������, ��������� ������ �������� ������� 1
		/// </summary>
		private void OnSetUnit1(object sender, EventArgs e)
		{
			_model.valueUnit1 = _view.InputUnit;
			RefreshView(unitFormat);
		}



		/// <summary>
		/// ���������� ����c�������� ������ ���������� ������.
		/// �� ���� Binding (��������) �������� ������ � �������������. 
		/// </summary>
		private void RefreshView(string unitFormat)
		{
			_view.SetUnit1(_model.valueUnit1, unitFormat);
			_view.SetUnit2(_model.valueUnit2, unitFormat);
		}
	}
}