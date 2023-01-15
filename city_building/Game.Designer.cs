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
			this.AddSoldierBtn = new System.Windows.Forms.Button();
			this.AddWorkerBtn = new System.Windows.Forms.Button();
			this.SoldiersAvailableLbl = new System.Windows.Forms.Label();
			this.WorkersAvailableLbl = new System.Windows.Forms.Label();
			this.NoSoldiersLbl = new System.Windows.Forms.Label();
			this.NoWorkersLbl = new System.Windows.Forms.Label();
			this.ChooseBuildingLbl = new System.Windows.Forms.Label();
			this.HouseBtn = new System.Windows.Forms.Button();
			this.WonderBtn = new System.Windows.Forms.Button();
			this.TowerBtn = new System.Windows.Forms.Button();
			this.BuildingBtn = new System.Windows.Forms.Button();
			this.WonderLbl = new System.Windows.Forms.Label();
			this.TowerLbl = new System.Windows.Forms.Label();
			this.BuildingLbl = new System.Windows.Forms.Label();
			this.HouseLbl = new System.Windows.Forms.Label();
			this.ResourcesLbl = new System.Windows.Forms.Label();
			this.WoodBtn = new System.Windows.Forms.Button();
			this.StoneBtn = new System.Windows.Forms.Button();
			this.IronBtn = new System.Windows.Forms.Button();
			this.GoldBtn = new System.Windows.Forms.Button();
			this.GoldLbl = new System.Windows.Forms.Label();
			this.IronLbl = new System.Windows.Forms.Label();
			this.StoneLbl = new System.Windows.Forms.Label();
			this.WoodLbl = new System.Windows.Forms.Label();
			this.WoodCountLbl = new System.Windows.Forms.Label();
			this.StoneCountLbl = new System.Windows.Forms.Label();
			this.IronCountLbl = new System.Windows.Forms.Label();
			this.GoldCountLbl = new System.Windows.Forms.Label();
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
			// AddSoldierBtn
			// 
			this.AddSoldierBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.AddSoldierBtn.Location = new System.Drawing.Point(12, 119);
			this.AddSoldierBtn.Name = "AddSoldierBtn";
			this.AddSoldierBtn.Size = new System.Drawing.Size(152, 41);
			this.AddSoldierBtn.TabIndex = 3;
			this.AddSoldierBtn.Text = "Add soldier";
			this.AddSoldierBtn.UseVisualStyleBackColor = true;
			// 
			// AddWorkerBtn
			// 
			this.AddWorkerBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.AddWorkerBtn.Location = new System.Drawing.Point(12, 252);
			this.AddWorkerBtn.Name = "AddWorkerBtn";
			this.AddWorkerBtn.Size = new System.Drawing.Size(152, 41);
			this.AddWorkerBtn.TabIndex = 4;
			this.AddWorkerBtn.Text = "Add worker";
			this.AddWorkerBtn.UseVisualStyleBackColor = true;
			// 
			// SoldiersAvailableLbl
			// 
			this.SoldiersAvailableLbl.AutoSize = true;
			this.SoldiersAvailableLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SoldiersAvailableLbl.Location = new System.Drawing.Point(12, 71);
			this.SoldiersAvailableLbl.Name = "SoldiersAvailableLbl";
			this.SoldiersAvailableLbl.Size = new System.Drawing.Size(144, 17);
			this.SoldiersAvailableLbl.TabIndex = 5;
			this.SoldiersAvailableLbl.Text = "Soldiers available:";
			// 
			// WorkersAvailableLbl
			// 
			this.WorkersAvailableLbl.AutoSize = true;
			this.WorkersAvailableLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.WorkersAvailableLbl.Location = new System.Drawing.Point(12, 198);
			this.WorkersAvailableLbl.Name = "WorkersAvailableLbl";
			this.WorkersAvailableLbl.Size = new System.Drawing.Size(147, 17);
			this.WorkersAvailableLbl.TabIndex = 6;
			this.WorkersAvailableLbl.Text = "Workers available:";
			// 
			// NoSoldiersLbl
			// 
			this.NoSoldiersLbl.AutoSize = true;
			this.NoSoldiersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.NoSoldiersLbl.Location = new System.Drawing.Point(81, 90);
			this.NoSoldiersLbl.Name = "NoSoldiersLbl";
			this.NoSoldiersLbl.Size = new System.Drawing.Size(24, 26);
			this.NoSoldiersLbl.TabIndex = 7;
			this.NoSoldiersLbl.Text = "0";
			// 
			// NoWorkersLbl
			// 
			this.NoWorkersLbl.AutoSize = true;
			this.NoWorkersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.NoWorkersLbl.Location = new System.Drawing.Point(81, 223);
			this.NoWorkersLbl.Name = "NoWorkersLbl";
			this.NoWorkersLbl.Size = new System.Drawing.Size(24, 26);
			this.NoWorkersLbl.TabIndex = 8;
			this.NoWorkersLbl.Text = "0";
			// 
			// ChooseBuildingLbl
			// 
			this.ChooseBuildingLbl.AutoSize = true;
			this.ChooseBuildingLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ChooseBuildingLbl.Location = new System.Drawing.Point(12, 448);
			this.ChooseBuildingLbl.Name = "ChooseBuildingLbl";
			this.ChooseBuildingLbl.Size = new System.Drawing.Size(131, 17);
			this.ChooseBuildingLbl.TabIndex = 9;
			this.ChooseBuildingLbl.Text = "Choose Building:";
			// 
			// HouseBtn
			// 
			this.HouseBtn.BackgroundImage = global::city_building.Properties.Resources.house;
			this.HouseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.HouseBtn.Location = new System.Drawing.Point(12, 488);
			this.HouseBtn.Name = "HouseBtn";
			this.HouseBtn.Size = new System.Drawing.Size(50, 50);
			this.HouseBtn.TabIndex = 10;
			this.HouseBtn.UseVisualStyleBackColor = true;
			// 
			// WonderBtn
			// 
			this.WonderBtn.BackgroundImage = global::city_building.Properties.Resources.jesus;
			this.WonderBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.WonderBtn.Location = new System.Drawing.Point(93, 585);
			this.WonderBtn.Name = "WonderBtn";
			this.WonderBtn.Size = new System.Drawing.Size(50, 50);
			this.WonderBtn.TabIndex = 11;
			this.WonderBtn.UseVisualStyleBackColor = true;
			// 
			// TowerBtn
			// 
			this.TowerBtn.BackgroundImage = global::city_building.Properties.Resources.tower;
			this.TowerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.TowerBtn.Location = new System.Drawing.Point(12, 585);
			this.TowerBtn.Name = "TowerBtn";
			this.TowerBtn.Size = new System.Drawing.Size(50, 50);
			this.TowerBtn.TabIndex = 12;
			this.TowerBtn.UseVisualStyleBackColor = true;
			// 
			// BuildingBtn
			// 
			this.BuildingBtn.BackgroundImage = global::city_building.Properties.Resources.building;
			this.BuildingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.BuildingBtn.Location = new System.Drawing.Point(93, 488);
			this.BuildingBtn.Name = "BuildingBtn";
			this.BuildingBtn.Size = new System.Drawing.Size(50, 50);
			this.BuildingBtn.TabIndex = 13;
			this.BuildingBtn.UseVisualStyleBackColor = true;
			// 
			// WonderLbl
			// 
			this.WonderLbl.AutoSize = true;
			this.WonderLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.WonderLbl.Location = new System.Drawing.Point(84, 638);
			this.WonderLbl.Name = "WonderLbl";
			this.WonderLbl.Size = new System.Drawing.Size(67, 17);
			this.WonderLbl.TabIndex = 14;
			this.WonderLbl.Text = "Wonder";
			// 
			// TowerLbl
			// 
			this.TowerLbl.AutoSize = true;
			this.TowerLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TowerLbl.Location = new System.Drawing.Point(7, 638);
			this.TowerLbl.Name = "TowerLbl";
			this.TowerLbl.Size = new System.Drawing.Size(57, 17);
			this.TowerLbl.TabIndex = 15;
			this.TowerLbl.Text = "Tower";
			// 
			// BuildingLbl
			// 
			this.BuildingLbl.AutoSize = true;
			this.BuildingLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.BuildingLbl.Location = new System.Drawing.Point(82, 541);
			this.BuildingLbl.Name = "BuildingLbl";
			this.BuildingLbl.Size = new System.Drawing.Size(72, 17);
			this.BuildingLbl.TabIndex = 16;
			this.BuildingLbl.Text = "Building";
			// 
			// HouseLbl
			// 
			this.HouseLbl.AutoSize = true;
			this.HouseLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.HouseLbl.Location = new System.Drawing.Point(12, 541);
			this.HouseLbl.Name = "HouseLbl";
			this.HouseLbl.Size = new System.Drawing.Size(52, 17);
			this.HouseLbl.TabIndex = 17;
			this.HouseLbl.Text = "House";
			// 
			// ResourcesLbl
			// 
			this.ResourcesLbl.AutoSize = true;
			this.ResourcesLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ResourcesLbl.Location = new System.Drawing.Point(168, 815);
			this.ResourcesLbl.Name = "ResourcesLbl";
			this.ResourcesLbl.Size = new System.Drawing.Size(86, 17);
			this.ResourcesLbl.TabIndex = 18;
			this.ResourcesLbl.Text = "Resources:";
			// 
			// WoodBtn
			// 
			this.WoodBtn.BackgroundImage = global::city_building.Properties.Resources.wood;
			this.WoodBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.WoodBtn.Location = new System.Drawing.Point(168, 835);
			this.WoodBtn.Name = "WoodBtn";
			this.WoodBtn.Size = new System.Drawing.Size(50, 50);
			this.WoodBtn.TabIndex = 19;
			this.WoodBtn.UseVisualStyleBackColor = true;
			// 
			// StoneBtn
			// 
			this.StoneBtn.BackgroundImage = global::city_building.Properties.Resources.stone;
			this.StoneBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.StoneBtn.Location = new System.Drawing.Point(241, 835);
			this.StoneBtn.Name = "StoneBtn";
			this.StoneBtn.Size = new System.Drawing.Size(50, 50);
			this.StoneBtn.TabIndex = 20;
			this.StoneBtn.UseVisualStyleBackColor = true;
			// 
			// IronBtn
			// 
			this.IronBtn.BackgroundImage = global::city_building.Properties.Resources.iron;
			this.IronBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.IronBtn.Location = new System.Drawing.Point(314, 835);
			this.IronBtn.Name = "IronBtn";
			this.IronBtn.Size = new System.Drawing.Size(50, 50);
			this.IronBtn.TabIndex = 21;
			this.IronBtn.UseVisualStyleBackColor = true;
			// 
			// GoldBtn
			// 
			this.GoldBtn.BackgroundImage = global::city_building.Properties.Resources.gold;
			this.GoldBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.GoldBtn.Location = new System.Drawing.Point(387, 835);
			this.GoldBtn.Name = "GoldBtn";
			this.GoldBtn.Size = new System.Drawing.Size(50, 50);
			this.GoldBtn.TabIndex = 23;
			this.GoldBtn.UseVisualStyleBackColor = true;
			// 
			// GoldLbl
			// 
			this.GoldLbl.AutoSize = true;
			this.GoldLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GoldLbl.Location = new System.Drawing.Point(393, 888);
			this.GoldLbl.Name = "GoldLbl";
			this.GoldLbl.Size = new System.Drawing.Size(44, 17);
			this.GoldLbl.TabIndex = 24;
			this.GoldLbl.Text = "Gold";
			// 
			// IronLbl
			// 
			this.IronLbl.AutoSize = true;
			this.IronLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.IronLbl.Location = new System.Drawing.Point(314, 888);
			this.IronLbl.Name = "IronLbl";
			this.IronLbl.Size = new System.Drawing.Size(41, 17);
			this.IronLbl.TabIndex = 25;
			this.IronLbl.Text = "Iron";
			// 
			// StoneLbl
			// 
			this.StoneLbl.AutoSize = true;
			this.StoneLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.StoneLbl.Location = new System.Drawing.Point(241, 888);
			this.StoneLbl.Name = "StoneLbl";
			this.StoneLbl.Size = new System.Drawing.Size(50, 17);
			this.StoneLbl.TabIndex = 26;
			this.StoneLbl.Text = "Stone";
			// 
			// WoodLbl
			// 
			this.WoodLbl.AutoSize = true;
			this.WoodLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.WoodLbl.Location = new System.Drawing.Point(166, 888);
			this.WoodLbl.Name = "WoodLbl";
			this.WoodLbl.Size = new System.Drawing.Size(52, 17);
			this.WoodLbl.TabIndex = 27;
			this.WoodLbl.Text = "Wood";
			// 
			// WoodCountLbl
			// 
			this.WoodCountLbl.AutoSize = true;
			this.WoodCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.WoodCountLbl.Location = new System.Drawing.Point(181, 905);
			this.WoodCountLbl.Name = "WoodCountLbl";
			this.WoodCountLbl.Size = new System.Drawing.Size(20, 21);
			this.WoodCountLbl.TabIndex = 28;
			this.WoodCountLbl.Text = "0";
			// 
			// StoneCountLbl
			// 
			this.StoneCountLbl.AutoSize = true;
			this.StoneCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.StoneCountLbl.Location = new System.Drawing.Point(257, 905);
			this.StoneCountLbl.Name = "StoneCountLbl";
			this.StoneCountLbl.Size = new System.Drawing.Size(20, 21);
			this.StoneCountLbl.TabIndex = 29;
			this.StoneCountLbl.Text = "0";
			// 
			// IronCountLbl
			// 
			this.IronCountLbl.AutoSize = true;
			this.IronCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.IronCountLbl.Location = new System.Drawing.Point(323, 905);
			this.IronCountLbl.Name = "IronCountLbl";
			this.IronCountLbl.Size = new System.Drawing.Size(20, 21);
			this.IronCountLbl.TabIndex = 30;
			this.IronCountLbl.Text = "0";
			// 
			// GoldCountLbl
			// 
			this.GoldCountLbl.AutoSize = true;
			this.GoldCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GoldCountLbl.Location = new System.Drawing.Point(403, 905);
			this.GoldCountLbl.Name = "GoldCountLbl";
			this.GoldCountLbl.Size = new System.Drawing.Size(20, 21);
			this.GoldCountLbl.TabIndex = 31;
			this.GoldCountLbl.Text = "0";
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 953);
			this.ControlBox = false;
			this.Controls.Add(this.GoldCountLbl);
			this.Controls.Add(this.IronCountLbl);
			this.Controls.Add(this.StoneCountLbl);
			this.Controls.Add(this.WoodCountLbl);
			this.Controls.Add(this.WoodLbl);
			this.Controls.Add(this.StoneLbl);
			this.Controls.Add(this.IronLbl);
			this.Controls.Add(this.GoldLbl);
			this.Controls.Add(this.GoldBtn);
			this.Controls.Add(this.IronBtn);
			this.Controls.Add(this.StoneBtn);
			this.Controls.Add(this.WoodBtn);
			this.Controls.Add(this.ResourcesLbl);
			this.Controls.Add(this.HouseLbl);
			this.Controls.Add(this.BuildingLbl);
			this.Controls.Add(this.TowerLbl);
			this.Controls.Add(this.WonderLbl);
			this.Controls.Add(this.BuildingBtn);
			this.Controls.Add(this.TowerBtn);
			this.Controls.Add(this.WonderBtn);
			this.Controls.Add(this.HouseBtn);
			this.Controls.Add(this.ChooseBuildingLbl);
			this.Controls.Add(this.NoWorkersLbl);
			this.Controls.Add(this.NoSoldiersLbl);
			this.Controls.Add(this.WorkersAvailableLbl);
			this.Controls.Add(this.SoldiersAvailableLbl);
			this.Controls.Add(this.AddWorkerBtn);
			this.Controls.Add(this.AddSoldierBtn);
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
		public System.Windows.Forms.Timer GameTimer;
		public Label TimeLabel;
		private Panel OutsidePanel;
		private Button AddSoldierBtn;
		private Button AddWorkerBtn;
		private Label SoldiersAvailableLbl;
		private Label WorkersAvailableLbl;
		private Label NoSoldiersLbl;
		private Label NoWorkersLbl;
		private Label ChooseBuildingLbl;
		private Button HouseBtn;
		private Button WonderBtn;
		private Button TowerBtn;
		private Button BuildingBtn;
		private Label WonderLbl;
		private Label TowerLbl;
		private Label BuildingLbl;
		private Label HouseLbl;
		private Label ResourcesLbl;
		private Button WoodBtn;
		private Button StoneBtn;
		private Button IronBtn;
		private Button GoldBtn;
		private Label GoldLbl;
		private Label IronLbl;
		private Label StoneLbl;
		private Label WoodLbl;
		private Label WoodCountLbl;
		private Label StoneCountLbl;
		private Label IronCountLbl;
		private Label GoldCountLbl;
	}
}