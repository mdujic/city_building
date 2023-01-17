namespace city_building
{
	partial class LoadingScreen
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
			this.BulbPicture = new System.Windows.Forms.PictureBox();
			this.HintLbl = new System.Windows.Forms.Label();
			this.HintRichTextBox = new System.Windows.Forms.RichTextBox();
			this.LoadingLbl = new System.Windows.Forms.Label();
			this.LoadingTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.BulbPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// BulbPicture
			// 
			this.BulbPicture.BackColor = System.Drawing.Color.White;
			this.BulbPicture.Image = global::city_building.Properties.Resources.bulb;
			this.BulbPicture.Location = new System.Drawing.Point(47, 21);
			this.BulbPicture.Name = "BulbPicture";
			this.BulbPicture.Size = new System.Drawing.Size(129, 91);
			this.BulbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.BulbPicture.TabIndex = 0;
			this.BulbPicture.TabStop = false;
			// 
			// HintLbl
			// 
			this.HintLbl.AutoSize = true;
			this.HintLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.HintLbl.ForeColor = System.Drawing.Color.Maroon;
			this.HintLbl.Location = new System.Drawing.Point(182, 21);
			this.HintLbl.Name = "HintLbl";
			this.HintLbl.Size = new System.Drawing.Size(68, 26);
			this.HintLbl.TabIndex = 1;
			this.HintLbl.Text = "Hint:";
			// 
			// HintRichTextBox
			// 
			this.HintRichTextBox.BackColor = System.Drawing.Color.White;
			this.HintRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HintRichTextBox.Enabled = false;
			this.HintRichTextBox.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.HintRichTextBox.ForeColor = System.Drawing.Color.Maroon;
			this.HintRichTextBox.Location = new System.Drawing.Point(256, 24);
			this.HintRichTextBox.Name = "HintRichTextBox";
			this.HintRichTextBox.Size = new System.Drawing.Size(214, 141);
			this.HintRichTextBox.TabIndex = 2;
			this.HintRichTextBox.Text = "";
			// 
			// LoadingLbl
			// 
			this.LoadingLbl.AutoSize = true;
			this.LoadingLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.LoadingLbl.ForeColor = System.Drawing.Color.Maroon;
			this.LoadingLbl.Location = new System.Drawing.Point(353, 168);
			this.LoadingLbl.Name = "LoadingLbl";
			this.LoadingLbl.Size = new System.Drawing.Size(117, 26);
			this.LoadingLbl.TabIndex = 3;
			this.LoadingLbl.Text = "Loading...";
			// 
			// LoadingTimer
			// 
			this.LoadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
			// 
			// LoadingScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(482, 203);
			this.ControlBox = false;
			this.Controls.Add(this.LoadingLbl);
			this.Controls.Add(this.HintRichTextBox);
			this.Controls.Add(this.HintLbl);
			this.Controls.Add(this.BulbPicture);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadingScreen";
			this.ShowIcon = false;
			this.Text = "LoadingScreen";
			((System.ComponentModel.ISupportInitialize)(this.BulbPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PictureBox BulbPicture;
		private Label HintLbl;
		private RichTextBox HintRichTextBox;
		private Label LoadingLbl;
		private System.Windows.Forms.Timer LoadingTimer;
	}
}