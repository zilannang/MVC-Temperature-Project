using System;
using System.Collections;

namespace MVC_Example
{
	
	public class TemperatureModel
	{
		
		public delegate void TemperatureChangedHandler(object sender, EventArgs e);

	

		public event TemperatureChangedHandler TemperatureChanged;

		private double temperatureF = 32.0;

		public double F
		{
			get {return temperatureF;}
			set 
			{
				temperatureF = value;

				//raise event
				OnTemperatureChanged();
				
			}

		}

		public double C
		{
			get {return (temperatureF - 32.0) * 5.0 / 9.0;}
			set 
			{
				temperatureF = value*9.0/5.0 + 32.0;
				OnTemperatureChanged();
				
			}
		}
		

		
		public TemperatureModel(double Temperature) 
		{
			temperatureF = Temperature;
			
		}

	
		public TemperatureModel()
		{
	
		}
		
		

		private void OnTemperatureChanged()
		{
			TemperatureChanged(this, new EventArgs());
		}
		
	}

}
