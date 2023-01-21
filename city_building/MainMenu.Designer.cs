namespace city_building
{
	partial class MainMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any 
		/// being used.
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
			this.StartBtn = new System.Windows.Forms.Button();
			this.OptionsBtn = new System.Windows.Forms.Button();
			this.LeaderboardBtn = new System.Windows.Forms.Button();
			this.ExitBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StartBtn
			// 
			this.StartBtn.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.StartBtn.ForeColor = System.Drawing.Color.Maroon;
			this.StartBtn.Location = new System.Drawing.Point(12, 12);
			this.StartBtn.Name = "StartBtn";
			this.StartBtn.Size = new System.Drawing.Size(182, 43);
			this.StartBtn.TabIndex = 0;
			this.StartBtn.Text = "Start";
			this.StartBtn.UseVisualStyleBackColor = true;
			this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
			this.StartBtn.MouseLeave += new System.EventHandler(this.StartBtn_MouseLeave);
			this.StartBtn.MouseHover += new System.EventHandler(this.StartBtn_MouseHover);
			// 
			// OptionsBtn
			// 
			this.OptionsBtn.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.OptionsBtn.ForeColor = System.Drawing.Color.Maroon;
			this.OptionsBtn.Location = new System.Drawing.Point(12, 110);
			this.OptionsBtn.Name = "OptionsBtn";
			this.OptionsBtn.Size = new System.Drawing.Size(182, 43);
			this.OptionsBtn.TabIndex = 1;
			this.OptionsBtn.Text = "Options";
			this.OptionsBtn.UseVisualStyleBackColor = true;
			this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
			this.OptionsBtn.MouseLeave += new System.EventHandler(this.OptionsBtn_MouseLeave);
			this.OptionsBtn.MouseHover += new System.EventHandler(this.OptionsBtn_MouseHover);
			// 
			// LeaderboardBtn
			// 
			this.LeaderboardBtn.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.LeaderboardBtn.ForeColor = System.Drawing.Color.Maroon;
			this.LeaderboardBtn.Location = new System.Drawing.Point(12, 61);
			this.LeaderboardBtn.Name = "LeaderboardBtn";
			this.LeaderboardBtn.Size = new System.Drawing.Size(182, 43);
			this.LeaderboardBtn.TabIndex = 1;
			this.LeaderboardBtn.Text = "Leaderboard";
			this.LeaderboardBtn.UseVisualStyleBackColor = true;
			this.LeaderboardBtn.Click += new System.EventHandler(this.LeaderboardBtn_Click);
			this.LeaderboardBtn.MouseLeave += new System.EventHandler(this.LeaderboardBtn_MouseLeave);
			this.LeaderboardBtn.MouseHover += new System.EventHandler(this.LeaderboardBtn_MouseHover);
			// 
			// ExitBtn
			// 
			this.ExitBtn.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ExitBtn.ForeColor = System.Drawing.Color.Maroon;
			this.ExitBtn.Location = new System.Drawing.Point(688, 398);
			this.ExitBtn.Name = "ExitBtn";
			this.ExitBtn.Size = new System.Drawing.Size(182, 43);
			this.ExitBtn.TabIndex = 2;
			this.ExitBtn.Text = "Exit";
			this.ExitBtn.UseVisualStyleBackColor = true;
			this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
			this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtn_MouseLeave);
			this.ExitBtn.MouseHover += new System.EventHandler(this.ExitBtn_MouseHover);
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::city_building.Properties.Resources.pat_a_mat;
			this.ClientSize = new System.Drawing.Size(882, 453);
			this.Controls.Add(this.ExitBtn);
			this.Controls.Add(this.LeaderboardBtn);
			this.Controls.Add(this.OptionsBtn);
			this.Controls.Add(this.StartBtn);
			this.Name = "MainMenu";
			this.Text = "MainMenu";
			this.ResumeLayout(false);

		}

		#endregion

		private Button StartBtn;
		private Button OptionsBtn;
		private Button LeaderboardBtn;
		private Button ExitBtn;
	}
}