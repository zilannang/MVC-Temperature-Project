using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace MVC_Example
{
	
	public class FarenheitGauge : System.Windows.Forms.Form, IView
	{
		
		private System.ComponentModel.Container components = null;
		public ValueStrategy valueStrategy;

		private int width = 20;
		private int top = 20;
		private int left = 100;
		private int height = 200;

		public double MaxTemp;
		public double MinTemp;


		public FarenheitGauge()
		{

			InitializeComponent();


		}

		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		private void InitializeComponent()
		{
			
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(208, 271);
			this.Location = new System.Drawing.Point(230, 70);
			this.Name = "FarenheitGauge";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Farenheit Gauge";
			this.Load += new System.EventHandler(this.FarenheitGauge_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FarenheitGauge_Paint);

		}
	

		private void FarenheitGauge_Load(object sender, System.EventArgs e)
		{
		
		}

		public void TemperatureDisplay(object sender, EventArgs e)
		{
			this.Refresh();
		}

		private void FarenheitGauge_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			
			g.DrawRectangle(new Pen(Color.Black), left,top, width, height);
			
			g.FillEllipse(new SolidBrush(Color.Red),left-width/2, top+height-width/3,width*2, width*2);
			
			g.DrawEllipse(new Pen(Color.Black),left-width/2, top+height-width/3,width*2, width*2);
	
			g.FillRectangle(new SolidBrush(Color.White) ,left+1,top+1, width-1, height-1);

			double redtop = height*(valueStrategy.Temperature - MaxTemp)/((MinTemp)-MaxTemp);
			g.FillRectangle(new SolidBrush(Color.Red),left+1, top + (int)redtop, width-1, height-(int)redtop);
		}


	}
}
