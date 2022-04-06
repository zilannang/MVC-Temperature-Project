using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MVC_Example
{
	public class TemperatureForm : System.Windows.Forms.Form, IView
	{
		public System.Windows.Forms.Button buttonIncrease;
		public System.Windows.Forms.Button buttonDecrease;
		public System.Windows.Forms.Label labelIntro;
		public System.Windows.Forms.TextBox textBoxTemprerature;
		public ValueStrategy valueStrategy;

		private System.ComponentModel.Container components = null;

		public TemperatureForm(string Name)
		{
			
			InitializeComponent();

			this.labelIntro.Text = Name;
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
			this.textBoxTemprerature = new System.Windows.Forms.TextBox();
			this.buttonIncrease = new System.Windows.Forms.Button();
			this.buttonDecrease = new System.Windows.Forms.Button();
			this.labelIntro = new System.Windows.Forms.Label();
			this.SuspendLayout();
			
			this.textBoxTemprerature.Location = new System.Drawing.Point(16, 48);
			this.textBoxTemprerature.Name = "textBoxTemprerature";
			this.textBoxTemprerature.Size = new System.Drawing.Size(128, 20);
			this.textBoxTemprerature.TabIndex = 13;
			this.textBoxTemprerature.Text = "";
			
			this.buttonIncrease.Location = new System.Drawing.Point(16, 80);
			this.buttonIncrease.Name = "buttonIncrease";
			this.buttonIncrease.Size = new System.Drawing.Size(64, 23);
			this.buttonIncrease.TabIndex = 11;
			this.buttonIncrease.Text = "Increase";
			this.buttonIncrease.Click += new System.EventHandler(this.buttonIncrease_Click);
			
			this.buttonDecrease.Location = new System.Drawing.Point(80, 80);
			this.buttonDecrease.Name = "buttonDecrease";
			this.buttonDecrease.Size = new System.Drawing.Size(64, 23);
			this.buttonDecrease.TabIndex = 12;
			this.buttonDecrease.Text = "Decrease";
			this.buttonDecrease.Click += new System.EventHandler(this.buttonDecrease_Click);
		
			this.labelIntro.AutoSize = true;
			this.labelIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.labelIntro.Location = new System.Drawing.Point(40, 8);
			this.labelIntro.Name = "labelIntro";
			this.labelIntro.Size = new System.Drawing.Size(71, 25);
			this.labelIntro.TabIndex = 10;
			this.labelIntro.Text = "Celsius";
			
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(160, 123);
			this.Controls.Add(this.textBoxTemprerature);
			this.Controls.Add(this.buttonIncrease);
			this.Controls.Add(this.buttonDecrease);
			this.Controls.Add(this.labelIntro);
			this.Location = new System.Drawing.Point(0, 220);
			this.Name = "TemperatureForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Temperature";
			this.Load += new System.EventHandler(this.TemperatureForm_Load);
			this.ResumeLayout(false);

		}
		

		

		private void buttonIncrease_Click(object sender, System.EventArgs e)
		{
			++valueStrategy.Temperature;
			
		}

		private void buttonDecrease_Click(object sender, System.EventArgs e)
		{
			--valueStrategy.Temperature;
			
		}


		private void TemperatureForm_Load(object sender, System.EventArgs e)
		{
			
			textBoxTemprerature.Text = valueStrategy.Temperature.ToString();
		}

		public void TemperatureDisplay(object sender, EventArgs e)
		{
			textBoxTemprerature.Text = valueStrategy.Temperature.ToString("#.#");
		}
	}
}

