using System;

namespace MVC_Example
{

	public class CelsiusStrategy : ValueStrategy
	{
		

		public CelsiusStrategy(TemperatureModel m)
		{
			model = m;	
		}
		
		public override double Temperature
		{
			set
			{
		
				model.C = value;
			}
			get
			{
				return model.C;
			}
		}
	
		

	}
}
