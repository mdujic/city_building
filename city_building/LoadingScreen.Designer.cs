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
            this.BulbPicture = new System.Windows.Forms.PictureBox();
            this.HintLbl = new System.Windows.Forms.Label();
            this.HintRichTextBox = new System.Windows.Forms.RichTextBox();
            this.LoadingLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BulbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BulbPicture
            // 
            this.BulbPicture.BackColor = System.Drawing.Color.White;
            this.BulbPicture.Image = global::city_building.Properties.Resources.bulb;
            this.BulbPicture.Location = new System.Drawing.Point(41, 16);
            this.BulbPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BulbPicture.Name = "BulbPicture";
            this.BulbPicture.Size = new System.Drawing.Size(113, 68);
            this.BulbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BulbPicture.TabIndex = 0;
            this.BulbPicture.TabStop = false;
            // 
            // HintLbl
            // 
            this.HintLbl.AutoSize = true;
            this.HintLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HintLbl.ForeColor = System.Drawing.Color.Maroon;
            this.HintLbl.Location = new System.Drawing.Point(159, 16);
            this.HintLbl.Name = "HintLbl";
            this.HintLbl.Size = new System.Drawing.Size(53, 20);
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
            this.HintRichTextBox.Location = new System.Drawing.Point(224, 18);
            this.HintRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HintRichTextBox.Name = "HintRichTextBox";
            this.HintRichTextBox.Size = new System.Drawing.Size(187, 106);
            this.HintRichTextBox.TabIndex = 2;
            this.HintRichTextBox.Text = "";
            // 
            // LoadingLbl
            // 
            this.LoadingLbl.AutoSize = true;
            this.LoadingLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadingLbl.ForeColor = System.Drawing.Color.Maroon;
            this.LoadingLbl.Location = new System.Drawing.Point(309, 126);
            this.LoadingLbl.Name = "LoadingLbl";
            this.LoadingLbl.Size = new System.Drawing.Size(94, 20);
            this.LoadingLbl.TabIndex = 3;
            this.LoadingLbl.Text = "Loading...";
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 152);
            this.ControlBox = false;
            this.Controls.Add(this.LoadingLbl);
            this.Controls.Add(this.HintRichTextBox);
            this.Controls.Add(this.HintLbl);
            this.Controls.Add(this.BulbPicture);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Screen";
            ((System.ComponentModel.ISupportInitialize)(this.BulbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private PictureBox BulbPicture;
		private Label HintLbl;
		private RichTextBox HintRichTextBox;
		private Label LoadingLbl;
	}
}