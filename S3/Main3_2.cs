using System;
using ClassLib;

namespace ConsoleApp
{
	class Programm
	{
		static void Main()
		{
			Building Office = new Building(9, 180000.0, 25000, buildingType.Office);
			Building House = new Building(5, 10000.0, 400, buildingType.Residential);
			Office.printBuildInfo();
			House.printBuildInfo();
		}
	}
}
