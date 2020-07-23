namespace DegreeConverter.Engine
{
	/// <summary>
	/// Конвертируемые единицы
	/// </summary>
	public enum Units 
		{
			CelsiusFahrenheit,
			KilometerMile,
			KilogramsPound,
			RubleDollar,
			MbBit
		}
	public class Model
	{



		private double _valueUnit2 = 0;
		private double _valueUnit1 = 0;
		public Units units { get; set; }

		/// <summary>
		/// Единицы 2
		/// </summary>

		public double valueUnit2
		{
			get { return _valueUnit2; }
			set 
			{
				_valueUnit2 = value;
				switch (units)
                {
					case Units.CelsiusFahrenheit:
						_valueUnit1 = (_valueUnit2 - 32) * 5 / 9;
						break;
					case Units.KilometerMile:
						_valueUnit1 = _valueUnit2 * 1.609;
						break;
					case Units.KilogramsPound:
						_valueUnit1 = _valueUnit2 * 0.454;
						break;
					case Units.RubleDollar:
						_valueUnit1 = _valueUnit2 * 70;
						break;
					case Units.MbBit:
						_valueUnit1 = _valueUnit2 /8/1000;
						break;

				}
					
			}
		}

		/// <summary>
		/// Единицы 1
		/// </summary>
		public double valueUnit1
		{
			get { return _valueUnit1; }
			set 
			{
				_valueUnit1 = value;
				switch (units)
				{
					case Units.CelsiusFahrenheit:
						_valueUnit2 = _valueUnit1 * 9 / 5 + 32;
						break;
					case Units.KilometerMile:
						_valueUnit2 = _valueUnit1 / 1.609;
						break;
					case Units.KilogramsPound:
						_valueUnit2 = _valueUnit1 / 0.454;
						break;
					case Units.RubleDollar:
						_valueUnit2 = _valueUnit1 / 70;
						break;
					case Units.MbBit:
						_valueUnit2 = _valueUnit1*8*1000;
						break;
				}
			}
		}
	}
}