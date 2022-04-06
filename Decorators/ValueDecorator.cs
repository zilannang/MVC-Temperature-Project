using System;

namespace MVC_Example
{
	
	public class ValueDecorator : ValueStrategy
	{
		ValueStrategy strategy;
		private int maxTemp = 300;
		private int minTemp = -200;

	
		private double tempTemp;

		public ValueDecorator(ValueStrategy valueStrategy)
		{
			
			strategy = valueStrategy;
			tempTemp = strategy.Temperature;
		}

		public ValueDecorator(ValueStrategy valueStrategy,int MaxTemp, int MinTemp)
		{
			strategy = valueStrategy;
			tempTemp = strategy.Temperature;
			maxTemp = MaxTemp;
			minTemp = MinTemp;
		}

		public override double Temperature
		{
			set
			{
				if (value < maxTemp && value > minTemp)
				strategy.Temperature = value;
				
			}
			get
			{
				if (strategy.Temperature < maxTemp && strategy.Temperature > minTemp)
				{
					tempTemp = strategy.Temperature;
					return strategy.Temperature;
				}
				else
				{
					strategy.Temperature = tempTemp;
					return tempTemp;
				}
			}
		}
	}
}
