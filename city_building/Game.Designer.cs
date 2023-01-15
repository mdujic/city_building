namespace city_building
{
	partial class Game
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ReturnBtn = new System.Windows.Forms.Button();
			this.GameTimer = new System.Windows.Forms.Timer(this.components);
			this.TimeLabel = new System.Windows.Forms.Label();
			this.OutsidePanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// ReturnBtn
			// 
			this.ReturnBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ReturnBtn.Location = new System.Drawing.Point(784, 912);
			this.ReturnBtn.Name = "ReturnBtn";
			this.ReturnBtn.Size = new System.Drawing.Size(186, 29);
			this.ReturnBtn.TabIndex = 0;
			this.ReturnBtn.Text = "Return to Main menu";
			this.ReturnBtn.UseVisualStyleBackColor = true;
			this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
			this.ReturnBtn.MouseLeave += new System.EventHandler(this.ReturnBtn_MouseLeave);
			this.ReturnBtn.MouseHover += new System.EventHandler(this.ReturnBtn_MouseHover);
			// 
			// GameTimer
			// 
			this.GameTimer.Enabled = true;
			this.GameTimer.Interval = 1000;
			this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
			// 
			// TimeLabel
			// 
			this.TimeLabel.AutoSize = true;
			this.TimeLabel.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TimeLabel.Location = new System.Drawing.Point(12, 9);
			this.TimeLabel.Name = "TimeLabel";
			this.TimeLabel.Size = new System.Drawing.Size(126, 26);
			this.TimeLabel.TabIndex = 1;
			this.TimeLabel.Text = "Time: 00:00";
			// 
			// OutsidePanel
			// 
			this.OutsidePanel.Location = new System.Drawing.Point(170, 12);
			this.OutsidePanel.Name = "OutsidePanel";
			this.OutsidePanel.Size = new System.Drawing.Size(800, 800);
			this.OutsidePanel.TabIndex = 2;
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 953);
			this.ControlBox = false;
			this.Controls.Add(this.OutsidePanel);
			this.Controls.Add(this.TimeLabel);
			this.Controls.Add(this.ReturnBtn);
			this.ForeColor = System.Drawing.Color.Maroon;
			this.Name = "Game";
			this.Text = "Game";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Button ReturnBtn;

    }

		public System.Windows.Forms.Timer GameTimer;
		public Label TimeLabel;
		private Panel OutsidePanel;
	}

}