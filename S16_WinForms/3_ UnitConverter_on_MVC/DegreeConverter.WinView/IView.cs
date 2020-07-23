using DegreeConverter.Engine;
using System;

namespace DegreeConverter.WinView
{
	public interface IView
	{
		/// <summary>
		/// ����� �������� ������� 2
		/// </summary>
		void SetUnit2(double unit, string outPutPrecision);

		/// <summary>
		/// ����� �������� ������� 1
		/// </summary>
		void SetUnit1(double unit, string outPutPrecision);
		void SetLabels(string labelNameUnit1, string buttonNameUnit1, string labelNameUnit2, string buttonNameUnit2);
		Units UnitsIndex { get; }
		/// <summary>
		/// ���� ������ ��������
		/// </summary>
		double InputUnit { get; }

		/// <summary>
		/// ������� ����� �������� �� 2�� �������
		/// </summary>
		event EventHandler<EventArgs> Unit2Setted;

		/// <summary>
		/// ������� ����� �������� �� 1�� �������
		/// </summary>
		event EventHandler<EventArgs> Unit1Setted;

		event EventHandler<EventArgs> UnitsSelected;
	}
}