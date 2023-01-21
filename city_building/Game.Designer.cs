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
            this.ImmobilizeSoldierBtn = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NoHousesLbl = new System.Windows.Forms.Label();
            this.NoBuildingsLbl = new System.Windows.Forms.Label();
            this.NoTowersLbl = new System.Windows.Forms.Label();
            this.NoWondersLbl = new System.Windows.Forms.Label();
            this.TmpLabel = new System.Windows.Forms.Label();
            this.TmpLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReturnBtn.Location = new System.Drawing.Point(686, 684);
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
            this.TimeLabel.Location = new System.Drawing.Point(10, 7);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(98, 20);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "Time: 00:00";
            // 
            // OutsidePanel
            // 
            this.OutsidePanel.Location = new System.Drawing.Point(149, 9);
            this.OutsidePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutsidePanel.Name = "OutsidePanel";
            this.OutsidePanel.Size = new System.Drawing.Size(700, 600);
            this.OutsidePanel.TabIndex = 2;
            // 
            // AddSoldierBtn
            // 
            this.AddSoldierBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddSoldierBtn.Location = new System.Drawing.Point(10, 170);
            this.AddSoldierBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddSoldierBtn.Name = "AddSoldierBtn";
            this.AddSoldierBtn.Size = new System.Drawing.Size(133, 34);
            this.AddSoldierBtn.TabIndex = 3;
            this.AddSoldierBtn.Text = "Add soldier";
            this.ToolTip.SetToolTip(this.AddSoldierBtn, "Soldier costs 10 gold and requires 10 iron.");
            this.AddSoldierBtn.UseVisualStyleBackColor = true;
            this.AddSoldierBtn.Click += new System.EventHandler(this.AddSoldierBtn_Click);
            // 
            // SoldiersAvailableLbl
            // 
            this.SoldiersAvailableLbl.AutoSize = true;
            this.SoldiersAvailableLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SoldiersAvailableLbl.Location = new System.Drawing.Point(10, 136);
            this.SoldiersAvailableLbl.Name = "SoldiersAvailableLbl";
            this.SoldiersAvailableLbl.Size = new System.Drawing.Size(123, 14);
            this.SoldiersAvailableLbl.TabIndex = 5;
            this.SoldiersAvailableLbl.Text = "Soldiers available:";
            // 
            // WorkersAvailableLbl
            // 
            this.WorkersAvailableLbl.AutoSize = true;
            this.WorkersAvailableLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WorkersAvailableLbl.Location = new System.Drawing.Point(10, 56);
            this.WorkersAvailableLbl.Name = "WorkersAvailableLbl";
            this.WorkersAvailableLbl.Size = new System.Drawing.Size(125, 14);
            this.WorkersAvailableLbl.TabIndex = 6;
            this.WorkersAvailableLbl.Text = "Workers available:";
            this.ToolTip.SetToolTip(this.WorkersAvailableLbl, "Nesto drugo");
            // 
            // NoSoldiersLbl
            // 
            this.NoSoldiersLbl.AutoSize = true;
            this.NoSoldiersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoSoldiersLbl.Location = new System.Drawing.Point(63, 148);
            this.NoSoldiersLbl.Name = "NoSoldiersLbl";
            this.NoSoldiersLbl.Size = new System.Drawing.Size(18, 20);
            this.NoSoldiersLbl.TabIndex = 7;
            this.NoSoldiersLbl.Text = "0";
            // 
            // NoWorkersLbl
            // 
            this.NoWorkersLbl.AutoSize = true;
            this.NoWorkersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoWorkersLbl.Location = new System.Drawing.Point(52, 68);
            this.NoWorkersLbl.Name = "NoWorkersLbl";
            this.NoWorkersLbl.Size = new System.Drawing.Size(34, 20);
            this.NoWorkersLbl.TabIndex = 8;
            this.NoWorkersLbl.Text = "0/0";
            // 
            // ChooseBuildingLbl
            // 
            this.ChooseBuildingLbl.AutoSize = true;
            this.ChooseBuildingLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChooseBuildingLbl.Location = new System.Drawing.Point(10, 336);
            this.ChooseBuildingLbl.Name = "ChooseBuildingLbl";
            this.ChooseBuildingLbl.Size = new System.Drawing.Size(110, 14);
            this.ChooseBuildingLbl.TabIndex = 9;
            this.ChooseBuildingLbl.Text = "Choose Building:";
            // 
            // HouseBtn
            // 
            this.HouseBtn.BackgroundImage = global::city_building.Properties.Resources.house;
            this.HouseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HouseBtn.Location = new System.Drawing.Point(10, 366);
            this.HouseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseBtn.Name = "HouseBtn";
            this.HouseBtn.Size = new System.Drawing.Size(44, 38);
            this.HouseBtn.TabIndex = 10;
            this.HouseBtn.Tag = "House";
            this.ToolTip.SetToolTip(this.HouseBtn, "Building of a house requires 10 people, 5 seconds, and 10 of each resource. In ea" +
        "ch house live 5 people.");
            this.HouseBtn.UseVisualStyleBackColor = true;
            this.HouseBtn.Click += new System.EventHandler(this.HouseBtn_Click);
            // 
            // WonderBtn
            // 
            this.WonderBtn.BackgroundImage = global::city_building.Properties.Resources.jesus;
            this.WonderBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WonderBtn.Location = new System.Drawing.Point(81, 449);
            this.WonderBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WonderBtn.Name = "WonderBtn";
            this.WonderBtn.Size = new System.Drawing.Size(44, 38);
            this.WonderBtn.TabIndex = 11;
            this.WonderBtn.Tag = "Wonder";
            this.ToolTip.SetToolTip(this.WonderBtn, "Building of a wonder requires 1000 people, 1000 seconds, and 1000 of each resourc" +
        "e. When wonder is built, game is finished.");
            this.WonderBtn.UseVisualStyleBackColor = true;
            this.WonderBtn.Click += new System.EventHandler(this.WonderBtn_Click);
            // 
            // TowerBtn
            // 
            this.TowerBtn.BackgroundImage = global::city_building.Properties.Resources.tower;
            this.TowerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TowerBtn.Location = new System.Drawing.Point(10, 449);
            this.TowerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TowerBtn.Name = "TowerBtn";
            this.TowerBtn.Size = new System.Drawing.Size(44, 38);
            this.TowerBtn.TabIndex = 12;
            this.TowerBtn.Tag = "Tower";
            this.ToolTip.SetToolTip(this.TowerBtn, "Building of a tower requires 30 people, 15 seconds, and 30 of each resource. Towe" +
        "r produces 5 gold each 5 seconds.");
            this.TowerBtn.UseVisualStyleBackColor = true;
            this.TowerBtn.Click += new System.EventHandler(this.TowerBtn_Click);
            // 
            // BuildingBtn
            // 
            this.BuildingBtn.BackgroundImage = global::city_building.Properties.Resources.building;
            this.BuildingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BuildingBtn.Location = new System.Drawing.Point(81, 366);
            this.BuildingBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BuildingBtn.Name = "BuildingBtn";
            this.BuildingBtn.Size = new System.Drawing.Size(44, 38);
            this.BuildingBtn.TabIndex = 13;
            this.BuildingBtn.Tag = "Building";
            this.ToolTip.SetToolTip(this.BuildingBtn, "Building of a building requires 20 people, 10 seconds, and 20 of each resource. I" +
        "n each building lives 20 people.");
            this.BuildingBtn.UseVisualStyleBackColor = true;
            this.BuildingBtn.Click += new System.EventHandler(this.BuildingBtn_Click);
            // 
            // WonderLbl
            // 
            this.WonderLbl.AutoSize = true;
            this.WonderLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WonderLbl.Location = new System.Drawing.Point(74, 489);
            this.WonderLbl.Name = "WonderLbl";
            this.WonderLbl.Size = new System.Drawing.Size(57, 14);
            this.WonderLbl.TabIndex = 14;
            this.WonderLbl.Text = "Wonder";
            // 
            // TowerLbl
            // 
            this.TowerLbl.AutoSize = true;
            this.TowerLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TowerLbl.Location = new System.Drawing.Point(6, 489);
            this.TowerLbl.Name = "TowerLbl";
            this.TowerLbl.Size = new System.Drawing.Size(46, 14);
            this.TowerLbl.TabIndex = 15;
            this.TowerLbl.Text = "Tower";
            // 
            // BuildingLbl
            // 
            this.BuildingLbl.AutoSize = true;
            this.BuildingLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BuildingLbl.Location = new System.Drawing.Point(72, 406);
            this.BuildingLbl.Name = "BuildingLbl";
            this.BuildingLbl.Size = new System.Drawing.Size(60, 14);
            this.BuildingLbl.TabIndex = 16;
            this.BuildingLbl.Text = "Building";
            // 
            // HouseLbl
            // 
            this.HouseLbl.AutoSize = true;
            this.HouseLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HouseLbl.Location = new System.Drawing.Point(10, 406);
            this.HouseLbl.Name = "HouseLbl";
            this.HouseLbl.Size = new System.Drawing.Size(44, 14);
            this.HouseLbl.TabIndex = 17;
            this.HouseLbl.Text = "House";
            // 
            // ResourcesLbl
            // 
            this.ResourcesLbl.AutoSize = true;
            this.ResourcesLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResourcesLbl.Location = new System.Drawing.Point(147, 611);
            this.ResourcesLbl.Name = "ResourcesLbl";
            this.ResourcesLbl.Size = new System.Drawing.Size(74, 14);
            this.ResourcesLbl.TabIndex = 18;
            this.ResourcesLbl.Text = "Resources:";
            // 
            // WoodBtn
            // 
            this.WoodBtn.BackgroundImage = global::city_building.Properties.Resources.wood;
            this.WoodBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WoodBtn.Location = new System.Drawing.Point(147, 626);
            this.WoodBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WoodBtn.Name = "WoodBtn";
            this.WoodBtn.Size = new System.Drawing.Size(44, 38);
            this.WoodBtn.TabIndex = 19;
            this.WoodBtn.Tag = "wood";
            this.ToolTip.SetToolTip(this.WoodBtn, "Harvesting wood requires 1 worker and 10 seconds.");
            this.WoodBtn.UseVisualStyleBackColor = true;
            this.WoodBtn.Click += new System.EventHandler(this.WoodBtn_Click);
            // 
            // StoneBtn
            // 
            this.StoneBtn.BackgroundImage = global::city_building.Properties.Resources.stone;
            this.StoneBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StoneBtn.Location = new System.Drawing.Point(211, 626);
            this.StoneBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StoneBtn.Name = "StoneBtn";
            this.StoneBtn.Size = new System.Drawing.Size(44, 38);
            this.StoneBtn.TabIndex = 20;
            this.StoneBtn.Tag = "stone";
            this.ToolTip.SetToolTip(this.StoneBtn, "Taking out stone requires 1 worker and 20 seconds.");
            this.StoneBtn.UseVisualStyleBackColor = true;
            this.StoneBtn.Click += new System.EventHandler(this.StoneBtn_Click);
            // 
            // IronBtn
            // 
            this.IronBtn.BackgroundImage = global::city_building.Properties.Resources.iron;
            this.IronBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IronBtn.Location = new System.Drawing.Point(275, 626);
            this.IronBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IronBtn.Name = "IronBtn";
            this.IronBtn.Size = new System.Drawing.Size(44, 38);
            this.IronBtn.TabIndex = 21;
            this.IronBtn.Tag = "iron";
            this.ToolTip.SetToolTip(this.IronBtn, "Mining iron requires 1 worker and 30 seconds.");
            this.IronBtn.UseVisualStyleBackColor = true;
            this.IronBtn.Click += new System.EventHandler(this.IronBtn_Click);
            // 
            // GoldBtn
            // 
            this.GoldBtn.BackgroundImage = global::city_building.Properties.Resources.gold;
            this.GoldBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GoldBtn.Location = new System.Drawing.Point(339, 626);
            this.GoldBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoldBtn.Name = "GoldBtn";
            this.GoldBtn.Size = new System.Drawing.Size(44, 38);
            this.GoldBtn.TabIndex = 23;
            this.GoldBtn.Tag = "gold";
            this.GoldBtn.UseVisualStyleBackColor = true;
            this.GoldBtn.Click += new System.EventHandler(this.GoldBtn_Click);
            // 
            // GoldLbl
            // 
            this.GoldLbl.AutoSize = true;
            this.GoldLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoldLbl.Location = new System.Drawing.Point(344, 666);
            this.GoldLbl.Name = "GoldLbl";
            this.GoldLbl.Size = new System.Drawing.Size(37, 14);
            this.GoldLbl.TabIndex = 24;
            this.GoldLbl.Text = "Gold";
            // 
            // IronLbl
            // 
            this.IronLbl.AutoSize = true;
            this.IronLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IronLbl.Location = new System.Drawing.Point(275, 666);
            this.IronLbl.Name = "IronLbl";
            this.IronLbl.Size = new System.Drawing.Size(35, 14);
            this.IronLbl.TabIndex = 25;
            this.IronLbl.Text = "Iron";
            // 
            // StoneLbl
            // 
            this.StoneLbl.AutoSize = true;
            this.StoneLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StoneLbl.Location = new System.Drawing.Point(211, 666);
            this.StoneLbl.Name = "StoneLbl";
            this.StoneLbl.Size = new System.Drawing.Size(41, 14);
            this.StoneLbl.TabIndex = 26;
            this.StoneLbl.Text = "Stone";
            // 
            // WoodLbl
            // 
            this.WoodLbl.AutoSize = true;
            this.WoodLbl.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WoodLbl.Location = new System.Drawing.Point(145, 666);
            this.WoodLbl.Name = "WoodLbl";
            this.WoodLbl.Size = new System.Drawing.Size(43, 14);
            this.WoodLbl.TabIndex = 27;
            this.WoodLbl.Text = "Wood";
            // 
            // WoodCountLbl
            // 
            this.WoodCountLbl.AutoSize = true;
            this.WoodCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WoodCountLbl.Location = new System.Drawing.Point(158, 679);
            this.WoodCountLbl.Name = "WoodCountLbl";
            this.WoodCountLbl.Size = new System.Drawing.Size(16, 18);
            this.WoodCountLbl.TabIndex = 28;
            this.WoodCountLbl.Text = "0";
            // 
            // StoneCountLbl
            // 
            this.StoneCountLbl.AutoSize = true;
            this.StoneCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StoneCountLbl.Location = new System.Drawing.Point(225, 679);
            this.StoneCountLbl.Name = "StoneCountLbl";
            this.StoneCountLbl.Size = new System.Drawing.Size(16, 18);
            this.StoneCountLbl.TabIndex = 29;
            this.StoneCountLbl.Text = "0";
            // 
            // IronCountLbl
            // 
            this.IronCountLbl.AutoSize = true;
            this.IronCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IronCountLbl.Location = new System.Drawing.Point(283, 679);
            this.IronCountLbl.Name = "IronCountLbl";
            this.IronCountLbl.Size = new System.Drawing.Size(16, 18);
            this.IronCountLbl.TabIndex = 30;
            this.IronCountLbl.Text = "0";
            // 
            // GoldCountLbl
            // 
            this.GoldCountLbl.AutoSize = true;
            this.GoldCountLbl.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoldCountLbl.Location = new System.Drawing.Point(353, 679);
            this.GoldCountLbl.Name = "GoldCountLbl";
            this.GoldCountLbl.Size = new System.Drawing.Size(16, 18);
            this.GoldCountLbl.TabIndex = 31;
            this.GoldCountLbl.Text = "0";
            // 
            // ImmobilizeSoldierBtn
            // 
            this.ImmobilizeSoldierBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImmobilizeSoldierBtn.Location = new System.Drawing.Point(10, 209);
            this.ImmobilizeSoldierBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImmobilizeSoldierBtn.Name = "ImmobilizeSoldierBtn";
            this.ImmobilizeSoldierBtn.Size = new System.Drawing.Size(133, 34);
            this.ImmobilizeSoldierBtn.TabIndex = 32;
            this.ImmobilizeSoldierBtn.Text = "Immobilize soldier";
            this.ToolTip.SetToolTip(this.ImmobilizeSoldierBtn, "Soldier immobilizes back to worker and without returning previously spent gold.");
            this.ImmobilizeSoldierBtn.UseVisualStyleBackColor = true;
            this.ImmobilizeSoldierBtn.Click += new System.EventHandler(this.DemobilizeSoldierBtn_Click);
            // 
            // NoHousesLbl
            // 
            this.NoHousesLbl.AutoSize = true;
            this.NoHousesLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoHousesLbl.Location = new System.Drawing.Point(22, 418);
            this.NoHousesLbl.Name = "NoHousesLbl";
            this.NoHousesLbl.Size = new System.Drawing.Size(18, 20);
            this.NoHousesLbl.TabIndex = 33;
            this.NoHousesLbl.Text = "0";
            // 
            // NoBuildingsLbl
            // 
            this.NoBuildingsLbl.AutoSize = true;
            this.NoBuildingsLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoBuildingsLbl.Location = new System.Drawing.Point(92, 418);
            this.NoBuildingsLbl.Name = "NoBuildingsLbl";
            this.NoBuildingsLbl.Size = new System.Drawing.Size(18, 20);
            this.NoBuildingsLbl.TabIndex = 34;
            this.NoBuildingsLbl.Text = "0";
            // 
            // NoTowersLbl
            // 
            this.NoTowersLbl.AutoSize = true;
            this.NoTowersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoTowersLbl.Location = new System.Drawing.Point(22, 502);
            this.NoTowersLbl.Name = "NoTowersLbl";
            this.NoTowersLbl.Size = new System.Drawing.Size(18, 20);
            this.NoTowersLbl.TabIndex = 35;
            this.NoTowersLbl.Text = "0";
            // 
            // NoWondersLbl
            // 
            this.NoWondersLbl.AutoSize = true;
            this.NoWondersLbl.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoWondersLbl.Location = new System.Drawing.Point(92, 502);
            this.NoWondersLbl.Name = "NoWondersLbl";
            this.NoWondersLbl.Size = new System.Drawing.Size(18, 20);
            this.NoWondersLbl.TabIndex = 36;
            this.NoWondersLbl.Text = "0";
            // 
            // TmpLabel
            // 
            this.TmpLabel.AutoSize = true;
            this.TmpLabel.Location = new System.Drawing.Point(28, 543);
            this.TmpLabel.Name = "TmpLabel";
            this.TmpLabel.Size = new System.Drawing.Size(38, 15);
            this.TmpLabel.TabIndex = 37;
            this.TmpLabel.Text = "label1";
            // 
            // TmpLabel2
            // 
            this.TmpLabel2.AutoSize = true;
            this.TmpLabel2.Location = new System.Drawing.Point(28, 562);
            this.TmpLabel2.Name = "TmpLabel2";
            this.TmpLabel2.Size = new System.Drawing.Size(38, 15);
            this.TmpLabel2.TabIndex = 38;
            this.TmpLabel2.Text = "label2";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 715);
            this.ControlBox = false;
            this.Controls.Add(this.TmpLabel2);
            this.Controls.Add(this.TmpLabel);
            this.Controls.Add(this.NoWondersLbl);
            this.Controls.Add(this.NoTowersLbl);
            this.Controls.Add(this.NoBuildingsLbl);
            this.Controls.Add(this.NoHousesLbl);
            this.Controls.Add(this.ImmobilizeSoldierBtn);
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
            this.Controls.Add(this.AddSoldierBtn);
            this.Controls.Add(this.OutsidePanel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ReturnBtn);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.Text = "Game";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Game_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Button ReturnBtn;

		public System.Windows.Forms.Timer GameTimer;
		public Label TimeLabel;
		private Panel OutsidePanel;
		private Button AddSoldierBtn;
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
		private Button ImmobilizeSoldierBtn;
		private ToolTip ToolTip;
		private Label NoHousesLbl;
		private Label NoBuildingsLbl;
		private Label NoTowersLbl;
		private Label NoWondersLbl;
        private Label TmpLabel;
        private Label TmpLabel2;
    }

}