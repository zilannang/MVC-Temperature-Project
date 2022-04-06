using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MVC_Example
{
	public class MVCForm : System.Windows.Forms.Form
	{
		
		private System.ComponentModel.Container components = null;
		public TemperatureModel temperature = new TemperatureModel();

		public MVCForm()
		{
			
			InitializeComponent();


		}

		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
 
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // MVCForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = global::MVC_Example.Properties.Resources.IMG_16251;
            this.ClientSize = new System.Drawing.Size(520, 443);
            this.IsMdiContainer = true;
            this.Name = "MVCForm";
            this.Text = "MVC Example";
            this.Load += new System.EventHandler(this.MVCForm_Load);
            this.ResumeLayout(false);

		}
		
	
		static void Main() 
		{
			Application.Run(new MVCForm());
		}

		private void MVCForm_Load(object sender, System.EventArgs e)
		{
			TemperatureForm celsius = new TemperatureForm("Celsius");
			TemperatureForm farenheit = new TemperatureForm("Farenheit");
			FarenheitGauge farenheitGauge = new FarenheitGauge();
			CelsiusScroll celsiusScroll = new CelsiusScroll();

			celsius.MdiParent = this;
			celsius.valueStrategy = new CelsiusStrategy(temperature);
			celsius.Location = new Point(0,0);
			celsius.Show();
			temperature.TemperatureChanged+= new TemperatureModel.TemperatureChangedHandler(celsius.TemperatureDisplay);
			
			farenheit.MdiParent = this;
			farenheit.valueStrategy = new FarenheitStrategy(temperature);
			farenheit.Show();
			temperature.TemperatureChanged+= new TemperatureModel.TemperatureChangedHandler(farenheit.TemperatureDisplay);

			farenheitGauge.MdiParent = this;
			farenheitGauge.valueStrategy = new ValueDecorator(new FarenheitStrategy(temperature),300,-200);
			farenheitGauge.MaxTemp = 300;
			farenheitGauge.MinTemp = -200;
			farenheitGauge.Show();
			temperature.TemperatureChanged+= new TemperatureModel.TemperatureChangedHandler(farenheitGauge.TemperatureDisplay);

			celsiusScroll.MdiParent = this;
			celsiusScroll.valueStrategy = new ValueDecorator(new CelsiusStrategy(temperature),150,-100);
			celsiusScroll.MaxTemp = 150;
			celsiusScroll.MinTemp = -100;
			celsiusScroll.Show();
			temperature.TemperatureChanged+= new TemperatureModel.TemperatureChangedHandler(celsiusScroll.TemperatureDisplay);

		}

	}
}
