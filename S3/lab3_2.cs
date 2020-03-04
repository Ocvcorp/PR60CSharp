using System;

namespace ClassLib
{
	enum buildingType
	{
		Office,
		Residential
	}
	class Building
	{
		private int floorNumber;
		private double totalArea;
		private int occupantsNumber;
		private buildingType buildType;
		public Building(int fN, double tA, int oN, buildingType bT)
		{
			floorNumber=fN;
			totalArea=tA;
			occupantsNumber=oN;
			buildType=bT;
		}
		public void printBuildInfo()
		{
			string outputType="";
			switch (buildType)
			{
				case buildingType.Office:
					outputType="Office";
					break;
				case buildingType.Residential:
					outputType="Residential";
					break;					
			}
			Console.WriteLine("We have a {0}-floor building with a type {1}, area {2} m2 and capacitiy of {3} occupants",
			floorNumber, outputType, totalArea, occupantsNumber);
		}
	}
}
