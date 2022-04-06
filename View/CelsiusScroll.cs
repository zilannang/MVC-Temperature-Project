using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MVC_Example
{
	/// <summary>
	/// Summary description for FarenheitScroll.
	/// </summary>
	public class CelsiusScroll : System.Windows.Forms.Form, IView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.HScrollBar hScrollBarTemperature;

		public ValueStrategy valueStrategy;
		
		public int MaxTemp = 300;
		public int MinTemp = -200;

		public CelsiusScroll()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.hScrollBarTemperature = new System.Windows.Forms.HScrollBar();
			this.SuspendLayout();
			 
			this.hScrollBarTemperature.Location = new System.Drawing.Point(16, 8);
			this.hScrollBarTemperature.Name = "hScrollBarTemperature";
			this.hScrollBarTemperature.Size = new System.Drawing.Size(232, 17);
			this.hScrollBarTemperature.TabIndex = 0;
			this.hScrollBarTemperature.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarTemperature_Scroll);
			
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 35);
			this.Controls.Add(this.hScrollBarTemperature);
			this.Location = new System.Drawing.Point(200, 0);
			this.Name = "CelsiusScroll";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CelsiusScroll";
			this.Load += new System.EventHandler(this.FarenheitScroll_Load);
			this.ResumeLayout(false);

		}
		
        public void TemperatureDisplay(object sender, EventArgs e)
		{

			hScrollBarTemperature.Value = (int)valueStrategy.Temperature;
		}

		private void FarenheitScroll_Load(object sender, System.EventArgs e)
		{
			hScrollBarTemperature.Maximum = MaxTemp;
			hScrollBarTemperature.Minimum = MinTemp;
			hScrollBarTemperature.Value = (int)valueStrategy.Temperature;
			
		}

		private void hScrollBarTemperature_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			valueStrategy.Temperature = hScrollBarTemperature.Value;
		}
	}
}
