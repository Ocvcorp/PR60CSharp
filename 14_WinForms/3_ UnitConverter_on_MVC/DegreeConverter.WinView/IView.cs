using DegreeConverter.Engine;
using System;

namespace DegreeConverter.WinView
{
	public interface IView
	{
		/// <summary>
		/// Вывод значений единицы 2
		/// </summary>
		void SetUnit2(double unit, string outPutPrecision);

		/// <summary>
		/// Вывод значений единицы 1
		/// </summary>
		void SetUnit1(double unit, string outPutPrecision);
		void SetLabels(string labelNameUnit1, string buttonNameUnit1, string labelNameUnit2, string buttonNameUnit2);
		Units UnitsIndex { get; }
		/// <summary>
		/// Ввод нового значения
		/// </summary>
		double InputUnit { get; }

		/// <summary>
		/// Событие ввода значения по 2ой единице
		/// </summary>
		event EventHandler<EventArgs> Unit2Setted;

		/// <summary>
		/// Событие ввода значения по 1ой единице
		/// </summary>
		event EventHandler<EventArgs> Unit1Setted;

		event EventHandler<EventArgs> UnitsSelected;
	}
}