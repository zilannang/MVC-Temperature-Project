using System;

namespace MVC_Example
{
	
	public class FarenheitStrategy : ValueStrategy
	{	
		public FarenheitStrategy(TemperatureModel m)
		{
			model = m;
		}
		
		public override double Temperature
		{
			set
			{
		
				model.F = value;
			}
			get
			{
				return model.F;
			}
		}
	
		

	}
}
