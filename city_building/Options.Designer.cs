namespace city_building
{
	partial class Options
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
			this.SoundBtn = new System.Windows.Forms.PictureBox();
			this.sound_label = new System.Windows.Forms.Label();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.MapSizeLabel = new System.Windows.Forms.Label();
			this.MapSizeNumeric = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.SoundBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MapSizeNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// SoundBtn
			// 
			this.SoundBtn.Image = global::city_building.Properties.Resources.sound_on;
			this.SoundBtn.Location = new System.Drawing.Point(174, 59);
			this.SoundBtn.Name = "SoundBtn";
			this.SoundBtn.Size = new System.Drawing.Size(58, 62);
			this.SoundBtn.TabIndex = 0;
			this.SoundBtn.TabStop = false;
			this.SoundBtn.Click += new System.EventHandler(this.SoundBtn_Click);
			// 
			// sound_label
			// 
			this.sound_label.AutoSize = true;
			this.sound_label.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.sound_label.ForeColor = System.Drawing.Color.Maroon;
			this.sound_label.Location = new System.Drawing.Point(117, 30);
			this.sound_label.Name = "sound_label";
			this.sound_label.Size = new System.Drawing.Size(164, 26);
			this.sound_label.TabIndex = 1;
			this.sound_label.Text = "Sound On/Off:";
			this.sound_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SaveBtn
			// 
			this.SaveBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SaveBtn.ForeColor = System.Drawing.Color.Maroon;
			this.SaveBtn.Location = new System.Drawing.Point(253, 409);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(149, 29);
			this.SaveBtn.TabIndex = 2;
			this.SaveBtn.Text = "Save and return";
			this.SaveBtn.UseVisualStyleBackColor = true;
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			this.SaveBtn.MouseLeave += new System.EventHandler(this.SaveBtn_MouseLeave);
			this.SaveBtn.MouseHover += new System.EventHandler(this.SaveBtn_MouseHover);
			// 
			// MapSizeLabel
			// 
			this.MapSizeLabel.AutoSize = true;
			this.MapSizeLabel.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MapSizeLabel.ForeColor = System.Drawing.Color.Maroon;
			this.MapSizeLabel.Location = new System.Drawing.Point(136, 171);
			this.MapSizeLabel.Name = "MapSizeLabel";
			this.MapSizeLabel.Size = new System.Drawing.Size(136, 26);
			this.MapSizeLabel.TabIndex = 3;
			this.MapSizeLabel.Text = "Size of map:";
			this.MapSizeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MapSizeNumeric
			// 
			this.MapSizeNumeric.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MapSizeNumeric.ForeColor = System.Drawing.Color.Maroon;
			this.MapSizeNumeric.Location = new System.Drawing.Point(171, 200);
			this.MapSizeNumeric.Name = "MapSizeNumeric";
			this.MapSizeNumeric.Size = new System.Drawing.Size(61, 32);
			this.MapSizeNumeric.TabIndex = 4;
			this.MapSizeNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.MapSizeNumeric.ValueChanged += new System.EventHandler(this.MapSizeNumeric_ValueChanged);
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 450);
			this.ControlBox = false;
			this.Controls.Add(this.MapSizeNumeric);
			this.Controls.Add(this.MapSizeLabel);
			this.Controls.Add(this.SaveBtn);
			this.Controls.Add(this.sound_label);
			this.Controls.Add(this.SoundBtn);
			this.Name = "Options";
			this.Text = "Options";
			((System.ComponentModel.ISupportInitialize)(this.SoundBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MapSizeNumeric)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private PictureBox SoundBtn;
		private Label sound_label;
		private Button SaveBtn;
		private Label MapSizeLabel;
		private NumericUpDown MapSizeNumeric;
	}
}