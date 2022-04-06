using System;

namespace MVC_Example
{

	public abstract class ValueStrategy
	{
		public abstract double Temperature{get;set;}
		
		protected TemperatureModel model;

		
	}
}
