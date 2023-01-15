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
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.Ispis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReturnBtn.Location = new System.Drawing.Point(527, 307);
            this.ReturnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(163, 22);
            this.ReturnBtn.TabIndex = 0;
            this.ReturnBtn.Text = "Return to Main menu";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            this.ReturnBtn.MouseLeave += new System.EventHandler(this.ReturnBtn_MouseLeave);
            this.ReturnBtn.MouseHover += new System.EventHandler(this.ReturnBtn_MouseHover);
            // 
            // Ispis
            // 
            this.Ispis.AutoSize = true;
            this.Ispis.Location = new System.Drawing.Point(21, 305);
            this.Ispis.Name = "Ispis";
            this.Ispis.Size = new System.Drawing.Size(30, 15);
            this.Ispis.TabIndex = 1;
            this.Ispis.Text = "Ispis";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.ControlBox = false;
            this.Controls.Add(this.Ispis);
            this.Controls.Add(this.ReturnBtn);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Button ReturnBtn;
        private Label Ispis;
    }
}