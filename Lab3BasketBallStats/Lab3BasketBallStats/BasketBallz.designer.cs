﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab3BasketBallStats
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Stats")]
	public partial class StatsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertGame(Game instance);
    partial void UpdateGame(Game instance);
    partial void DeleteGame(Game instance);
    partial void InsertLeague(League instance);
    partial void UpdateLeague(League instance);
    partial void DeleteLeague(League instance);
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    partial void InsertStat(Stat instance);
    partial void UpdateStat(Stat instance);
    partial void DeleteStat(Stat instance);
    partial void InsertTeam(Team instance);
    partial void UpdateTeam(Team instance);
    partial void DeleteTeam(Team instance);
    partial void InsertPlayers_Team(Players_Team instance);
    partial void UpdatePlayers_Team(Players_Team instance);
    partial void DeletePlayers_Team(Players_Team instance);
    #endregion
		
		public StatsDataContext() : 
				base(global::Lab3BasketBallStats.Properties.Settings.Default.StatsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StatsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StatsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StatsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StatsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Game> Games
		{
			get
			{
				return this.GetTable<Game>();
			}
		}
		
		public System.Data.Linq.Table<League> Leagues
		{
			get
			{
				return this.GetTable<League>();
			}
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
		
		public System.Data.Linq.Table<Stat> Stats
		{
			get
			{
				return this.GetTable<Stat>();
			}
		}
		
		public System.Data.Linq.Table<Team> Teams
		{
			get
			{
				return this.GetTable<Team>();
			}
		}
		
		public System.Data.Linq.Table<Players_Team> Players_Teams
		{
			get
			{
				return this.GetTable<Players_Team>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Games")]
	public partial class Game : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _date;
		
		private string _location;
		
		private System.Nullable<int> _home_team_id;
		
		private System.Nullable<int> _visiting_team_id;
		
		private System.Nullable<int> _home_team_score;
		
		private System.Nullable<int> _visiting_team_score;
		
		private EntitySet<Stat> _Stats;
		
		private EntityRef<Team> _Team;
		
		private EntityRef<Team> _Team1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    partial void OnlocationChanging(string value);
    partial void OnlocationChanged();
    partial void Onhome_team_idChanging(System.Nullable<int> value);
    partial void Onhome_team_idChanged();
    partial void Onvisiting_team_idChanging(System.Nullable<int> value);
    partial void Onvisiting_team_idChanged();
    partial void Onhome_team_scoreChanging(System.Nullable<int> value);
    partial void Onhome_team_scoreChanged();
    partial void Onvisiting_team_scoreChanging(System.Nullable<int> value);
    partial void Onvisiting_team_scoreChanged();
    #endregion
		
		public Game()
		{
			this._Stats = new EntitySet<Stat>(new Action<Stat>(this.attach_Stats), new Action<Stat>(this.detach_Stats));
			this._Team = default(EntityRef<Team>);
			this._Team1 = default(EntityRef<Team>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="Date")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location", DbType="VarChar(50)")]
		public string location
		{
			get
			{
				return this._location;
			}
			set
			{
				if ((this._location != value))
				{
					this.OnlocationChanging(value);
					this.SendPropertyChanging();
					this._location = value;
					this.SendPropertyChanged("location");
					this.OnlocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_home_team_id", DbType="Int")]
		public System.Nullable<int> home_team_id
		{
			get
			{
				return this._home_team_id;
			}
			set
			{
				if ((this._home_team_id != value))
				{
					if (this._Team.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onhome_team_idChanging(value);
					this.SendPropertyChanging();
					this._home_team_id = value;
					this.SendPropertyChanged("home_team_id");
					this.Onhome_team_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_visiting_team_id", DbType="Int")]
		public System.Nullable<int> visiting_team_id
		{
			get
			{
				return this._visiting_team_id;
			}
			set
			{
				if ((this._visiting_team_id != value))
				{
					if (this._Team1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onvisiting_team_idChanging(value);
					this.SendPropertyChanging();
					this._visiting_team_id = value;
					this.SendPropertyChanged("visiting_team_id");
					this.Onvisiting_team_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_home_team_score", DbType="Int")]
		public System.Nullable<int> home_team_score
		{
			get
			{
				return this._home_team_score;
			}
			set
			{
				if ((this._home_team_score != value))
				{
					this.Onhome_team_scoreChanging(value);
					this.SendPropertyChanging();
					this._home_team_score = value;
					this.SendPropertyChanged("home_team_score");
					this.Onhome_team_scoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_visiting_team_score", DbType="Int")]
		public System.Nullable<int> visiting_team_score
		{
			get
			{
				return this._visiting_team_score;
			}
			set
			{
				if ((this._visiting_team_score != value))
				{
					this.Onvisiting_team_scoreChanging(value);
					this.SendPropertyChanging();
					this._visiting_team_score = value;
					this.SendPropertyChanged("visiting_team_score");
					this.Onvisiting_team_scoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Game_Stat", Storage="_Stats", ThisKey="Id", OtherKey="game_id")]
		public EntitySet<Stat> Stats
		{
			get
			{
				return this._Stats;
			}
			set
			{
				this._Stats.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Game", Storage="_Team", ThisKey="home_team_id", OtherKey="Id", IsForeignKey=true)]
		public Team Team
		{
			get
			{
				return this._Team.Entity;
			}
			set
			{
				Team previousValue = this._Team.Entity;
				if (((previousValue != value) 
							|| (this._Team.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Team.Entity = null;
						previousValue.Games.Remove(this);
					}
					this._Team.Entity = value;
					if ((value != null))
					{
						value.Games.Add(this);
						this._home_team_id = value.Id;
					}
					else
					{
						this._home_team_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Team");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Game1", Storage="_Team1", ThisKey="visiting_team_id", OtherKey="Id", IsForeignKey=true)]
		public Team Team1
		{
			get
			{
				return this._Team1.Entity;
			}
			set
			{
				Team previousValue = this._Team1.Entity;
				if (((previousValue != value) 
							|| (this._Team1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Team1.Entity = null;
						previousValue.Games1.Remove(this);
					}
					this._Team1.Entity = value;
					if ((value != null))
					{
						value.Games1.Add(this);
						this._visiting_team_id = value.Id;
					}
					else
					{
						this._visiting_team_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Team1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Stats(Stat entity)
		{
			this.SendPropertyChanging();
			entity.Game = this;
		}
		
		private void detach_Stats(Stat entity)
		{
			this.SendPropertyChanging();
			entity.Game = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Leagues")]
	public partial class League : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private EntitySet<Team> _Teams;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public League()
		{
			this._Teams = new EntitySet<Team>(new Action<Team>(this.attach_Teams), new Action<Team>(this.detach_Teams));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="League_Team", Storage="_Teams", ThisKey="Id", OtherKey="league_id")]
		public EntitySet<Team> Teams
		{
			get
			{
				return this._Teams;
			}
			set
			{
				this._Teams.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Teams(Team entity)
		{
			this.SendPropertyChanging();
			entity.League = this;
		}
		
		private void detach_Teams(Team entity)
		{
			this.SendPropertyChanging();
			entity.League = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Players")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private System.Nullable<int> _team_id;
		
		private System.Nullable<int> _height;
		
		private System.Nullable<int> _weight;
		
		private System.Nullable<int> _salary;
		
		private System.Nullable<System.DateTime> _DBO;
		
		private EntitySet<Stat> _Stats;
		
		private EntitySet<Players_Team> _Players_Teams;
		
		private EntityRef<Team> _Team;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void Onteam_idChanging(System.Nullable<int> value);
    partial void Onteam_idChanged();
    partial void OnheightChanging(System.Nullable<int> value);
    partial void OnheightChanged();
    partial void OnweightChanging(System.Nullable<int> value);
    partial void OnweightChanged();
    partial void OnsalaryChanging(System.Nullable<int> value);
    partial void OnsalaryChanged();
    partial void OnDBOChanging(System.Nullable<System.DateTime> value);
    partial void OnDBOChanged();
    #endregion
		
		public Player()
		{
			this._Stats = new EntitySet<Stat>(new Action<Stat>(this.attach_Stats), new Action<Stat>(this.detach_Stats));
			this._Players_Teams = new EntitySet<Players_Team>(new Action<Players_Team>(this.attach_Players_Teams), new Action<Players_Team>(this.detach_Players_Teams));
			this._Team = default(EntityRef<Team>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_team_id", DbType="Int")]
		public System.Nullable<int> team_id
		{
			get
			{
				return this._team_id;
			}
			set
			{
				if ((this._team_id != value))
				{
					if (this._Team.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onteam_idChanging(value);
					this.SendPropertyChanging();
					this._team_id = value;
					this.SendPropertyChanged("team_id");
					this.Onteam_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_height", DbType="Int")]
		public System.Nullable<int> height
		{
			get
			{
				return this._height;
			}
			set
			{
				if ((this._height != value))
				{
					this.OnheightChanging(value);
					this.SendPropertyChanging();
					this._height = value;
					this.SendPropertyChanged("height");
					this.OnheightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_weight", DbType="Int")]
		public System.Nullable<int> weight
		{
			get
			{
				return this._weight;
			}
			set
			{
				if ((this._weight != value))
				{
					this.OnweightChanging(value);
					this.SendPropertyChanging();
					this._weight = value;
					this.SendPropertyChanged("weight");
					this.OnweightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_salary", DbType="Int")]
		public System.Nullable<int> salary
		{
			get
			{
				return this._salary;
			}
			set
			{
				if ((this._salary != value))
				{
					this.OnsalaryChanging(value);
					this.SendPropertyChanging();
					this._salary = value;
					this.SendPropertyChanged("salary");
					this.OnsalaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBO", DbType="Date")]
		public System.Nullable<System.DateTime> DBO
		{
			get
			{
				return this._DBO;
			}
			set
			{
				if ((this._DBO != value))
				{
					this.OnDBOChanging(value);
					this.SendPropertyChanging();
					this._DBO = value;
					this.SendPropertyChanged("DBO");
					this.OnDBOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Stat", Storage="_Stats", ThisKey="Id", OtherKey="player_id")]
		public EntitySet<Stat> Stats
		{
			get
			{
				return this._Stats;
			}
			set
			{
				this._Stats.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Players_Team", Storage="_Players_Teams", ThisKey="Id", OtherKey="player_id")]
		public EntitySet<Players_Team> Players_Teams
		{
			get
			{
				return this._Players_Teams;
			}
			set
			{
				this._Players_Teams.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Player", Storage="_Team", ThisKey="team_id", OtherKey="Id", IsForeignKey=true)]
		public Team Team
		{
			get
			{
				return this._Team.Entity;
			}
			set
			{
				Team previousValue = this._Team.Entity;
				if (((previousValue != value) 
							|| (this._Team.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Team.Entity = null;
						previousValue.Players.Remove(this);
					}
					this._Team.Entity = value;
					if ((value != null))
					{
						value.Players.Add(this);
						this._team_id = value.Id;
					}
					else
					{
						this._team_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Team");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Stats(Stat entity)
		{
			this.SendPropertyChanging();
			entity.Player = this;
		}
		
		private void detach_Stats(Stat entity)
		{
			this.SendPropertyChanging();
			entity.Player = null;
		}
		
		private void attach_Players_Teams(Players_Team entity)
		{
			this.SendPropertyChanging();
			entity.Player = this;
		}
		
		private void detach_Players_Teams(Players_Team entity)
		{
			this.SendPropertyChanging();
			entity.Player = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Stats")]
	public partial class Stat : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _game_id;
		
		private System.Nullable<int> _player_id;
		
		private System.Nullable<int> _points_scored;
		
		private System.Nullable<int> _rebounds;
		
		private System.Nullable<int> _shot_attemps;
		
		private EntityRef<Game> _Game;
		
		private EntityRef<Player> _Player;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Ongame_idChanging(System.Nullable<int> value);
    partial void Ongame_idChanged();
    partial void Onplayer_idChanging(System.Nullable<int> value);
    partial void Onplayer_idChanged();
    partial void Onpoints_scoredChanging(System.Nullable<int> value);
    partial void Onpoints_scoredChanged();
    partial void OnreboundsChanging(System.Nullable<int> value);
    partial void OnreboundsChanged();
    partial void Onshot_attempsChanging(System.Nullable<int> value);
    partial void Onshot_attempsChanged();
    #endregion
		
		public Stat()
		{
			this._Game = default(EntityRef<Game>);
			this._Player = default(EntityRef<Player>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_game_id", DbType="Int")]
		public System.Nullable<int> game_id
		{
			get
			{
				return this._game_id;
			}
			set
			{
				if ((this._game_id != value))
				{
					if (this._Game.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ongame_idChanging(value);
					this.SendPropertyChanging();
					this._game_id = value;
					this.SendPropertyChanged("game_id");
					this.Ongame_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_id", DbType="Int")]
		public System.Nullable<int> player_id
		{
			get
			{
				return this._player_id;
			}
			set
			{
				if ((this._player_id != value))
				{
					if (this._Player.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onplayer_idChanging(value);
					this.SendPropertyChanging();
					this._player_id = value;
					this.SendPropertyChanged("player_id");
					this.Onplayer_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_points_scored", DbType="Int")]
		public System.Nullable<int> points_scored
		{
			get
			{
				return this._points_scored;
			}
			set
			{
				if ((this._points_scored != value))
				{
					this.Onpoints_scoredChanging(value);
					this.SendPropertyChanging();
					this._points_scored = value;
					this.SendPropertyChanged("points_scored");
					this.Onpoints_scoredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rebounds", DbType="Int")]
		public System.Nullable<int> rebounds
		{
			get
			{
				return this._rebounds;
			}
			set
			{
				if ((this._rebounds != value))
				{
					this.OnreboundsChanging(value);
					this.SendPropertyChanging();
					this._rebounds = value;
					this.SendPropertyChanged("rebounds");
					this.OnreboundsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shot_attemps", DbType="Int")]
		public System.Nullable<int> shot_attemps
		{
			get
			{
				return this._shot_attemps;
			}
			set
			{
				if ((this._shot_attemps != value))
				{
					this.Onshot_attempsChanging(value);
					this.SendPropertyChanging();
					this._shot_attemps = value;
					this.SendPropertyChanged("shot_attemps");
					this.Onshot_attempsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Game_Stat", Storage="_Game", ThisKey="game_id", OtherKey="Id", IsForeignKey=true)]
		public Game Game
		{
			get
			{
				return this._Game.Entity;
			}
			set
			{
				Game previousValue = this._Game.Entity;
				if (((previousValue != value) 
							|| (this._Game.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Game.Entity = null;
						previousValue.Stats.Remove(this);
					}
					this._Game.Entity = value;
					if ((value != null))
					{
						value.Stats.Add(this);
						this._game_id = value.Id;
					}
					else
					{
						this._game_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Game");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Stat", Storage="_Player", ThisKey="player_id", OtherKey="Id", IsForeignKey=true)]
		public Player Player
		{
			get
			{
				return this._Player.Entity;
			}
			set
			{
				Player previousValue = this._Player.Entity;
				if (((previousValue != value) 
							|| (this._Player.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Player.Entity = null;
						previousValue.Stats.Remove(this);
					}
					this._Player.Entity = value;
					if ((value != null))
					{
						value.Stats.Add(this);
						this._player_id = value.Id;
					}
					else
					{
						this._player_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Player");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Teams")]
	public partial class Team : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _league_id;
		
		private string _name;
		
		private EntitySet<Game> _Games;
		
		private EntitySet<Game> _Games1;
		
		private EntitySet<Player> _Players;
		
		private EntitySet<Players_Team> _Players_Teams;
		
		private EntityRef<League> _League;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onleague_idChanging(System.Nullable<int> value);
    partial void Onleague_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Team()
		{
			this._Games = new EntitySet<Game>(new Action<Game>(this.attach_Games), new Action<Game>(this.detach_Games));
			this._Games1 = new EntitySet<Game>(new Action<Game>(this.attach_Games1), new Action<Game>(this.detach_Games1));
			this._Players = new EntitySet<Player>(new Action<Player>(this.attach_Players), new Action<Player>(this.detach_Players));
			this._Players_Teams = new EntitySet<Players_Team>(new Action<Players_Team>(this.attach_Players_Teams), new Action<Players_Team>(this.detach_Players_Teams));
			this._League = default(EntityRef<League>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_league_id", DbType="Int")]
		public System.Nullable<int> league_id
		{
			get
			{
				return this._league_id;
			}
			set
			{
				if ((this._league_id != value))
				{
					if (this._League.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onleague_idChanging(value);
					this.SendPropertyChanging();
					this._league_id = value;
					this.SendPropertyChanged("league_id");
					this.Onleague_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Game", Storage="_Games", ThisKey="Id", OtherKey="home_team_id")]
		public EntitySet<Game> Games
		{
			get
			{
				return this._Games;
			}
			set
			{
				this._Games.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Game1", Storage="_Games1", ThisKey="Id", OtherKey="visiting_team_id")]
		public EntitySet<Game> Games1
		{
			get
			{
				return this._Games1;
			}
			set
			{
				this._Games1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Player", Storage="_Players", ThisKey="Id", OtherKey="team_id")]
		public EntitySet<Player> Players
		{
			get
			{
				return this._Players;
			}
			set
			{
				this._Players.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Players_Team", Storage="_Players_Teams", ThisKey="Id", OtherKey="team_id")]
		public EntitySet<Players_Team> Players_Teams
		{
			get
			{
				return this._Players_Teams;
			}
			set
			{
				this._Players_Teams.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="League_Team", Storage="_League", ThisKey="league_id", OtherKey="Id", IsForeignKey=true)]
		public League League
		{
			get
			{
				return this._League.Entity;
			}
			set
			{
				League previousValue = this._League.Entity;
				if (((previousValue != value) 
							|| (this._League.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._League.Entity = null;
						previousValue.Teams.Remove(this);
					}
					this._League.Entity = value;
					if ((value != null))
					{
						value.Teams.Add(this);
						this._league_id = value.Id;
					}
					else
					{
						this._league_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("League");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Games(Game entity)
		{
			this.SendPropertyChanging();
			entity.Team = this;
		}
		
		private void detach_Games(Game entity)
		{
			this.SendPropertyChanging();
			entity.Team = null;
		}
		
		private void attach_Games1(Game entity)
		{
			this.SendPropertyChanging();
			entity.Team1 = this;
		}
		
		private void detach_Games1(Game entity)
		{
			this.SendPropertyChanging();
			entity.Team1 = null;
		}
		
		private void attach_Players(Player entity)
		{
			this.SendPropertyChanging();
			entity.Team = this;
		}
		
		private void detach_Players(Player entity)
		{
			this.SendPropertyChanging();
			entity.Team = null;
		}
		
		private void attach_Players_Teams(Players_Team entity)
		{
			this.SendPropertyChanging();
			entity.Team = this;
		}
		
		private void detach_Players_Teams(Players_Team entity)
		{
			this.SendPropertyChanging();
			entity.Team = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Players_Teams")]
	public partial class Players_Team : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _player_id;
		
		private System.Nullable<int> _team_id;
		
		private System.DateTime _start_date;
		
		private System.Nullable<System.DateTime> _end_date;
		
		private EntityRef<Player> _Player;
		
		private EntityRef<Team> _Team;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onplayer_idChanging(System.Nullable<int> value);
    partial void Onplayer_idChanged();
    partial void Onteam_idChanging(System.Nullable<int> value);
    partial void Onteam_idChanged();
    partial void Onstart_dateChanging(System.DateTime value);
    partial void Onstart_dateChanged();
    partial void Onend_dateChanging(System.Nullable<System.DateTime> value);
    partial void Onend_dateChanged();
    #endregion
		
		public Players_Team()
		{
			this._Player = default(EntityRef<Player>);
			this._Team = default(EntityRef<Team>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_id", DbType="Int")]
		public System.Nullable<int> player_id
		{
			get
			{
				return this._player_id;
			}
			set
			{
				if ((this._player_id != value))
				{
					if (this._Player.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onplayer_idChanging(value);
					this.SendPropertyChanging();
					this._player_id = value;
					this.SendPropertyChanged("player_id");
					this.Onplayer_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_team_id", DbType="Int")]
		public System.Nullable<int> team_id
		{
			get
			{
				return this._team_id;
			}
			set
			{
				if ((this._team_id != value))
				{
					if (this._Team.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onteam_idChanging(value);
					this.SendPropertyChanging();
					this._team_id = value;
					this.SendPropertyChanged("team_id");
					this.Onteam_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_start_date", DbType="Date NOT NULL")]
		public System.DateTime start_date
		{
			get
			{
				return this._start_date;
			}
			set
			{
				if ((this._start_date != value))
				{
					this.Onstart_dateChanging(value);
					this.SendPropertyChanging();
					this._start_date = value;
					this.SendPropertyChanged("start_date");
					this.Onstart_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_end_date", DbType="Date")]
		public System.Nullable<System.DateTime> end_date
		{
			get
			{
				return this._end_date;
			}
			set
			{
				if ((this._end_date != value))
				{
					this.Onend_dateChanging(value);
					this.SendPropertyChanging();
					this._end_date = value;
					this.SendPropertyChanged("end_date");
					this.Onend_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Players_Team", Storage="_Player", ThisKey="player_id", OtherKey="Id", IsForeignKey=true)]
		public Player Player
		{
			get
			{
				return this._Player.Entity;
			}
			set
			{
				Player previousValue = this._Player.Entity;
				if (((previousValue != value) 
							|| (this._Player.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Player.Entity = null;
						previousValue.Players_Teams.Remove(this);
					}
					this._Player.Entity = value;
					if ((value != null))
					{
						value.Players_Teams.Add(this);
						this._player_id = value.Id;
					}
					else
					{
						this._player_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Player");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Team_Players_Team", Storage="_Team", ThisKey="team_id", OtherKey="Id", IsForeignKey=true)]
		public Team Team
		{
			get
			{
				return this._Team.Entity;
			}
			set
			{
				Team previousValue = this._Team.Entity;
				if (((previousValue != value) 
							|| (this._Team.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Team.Entity = null;
						previousValue.Players_Teams.Remove(this);
					}
					this._Team.Entity = value;
					if ((value != null))
					{
						value.Players_Teams.Add(this);
						this._team_id = value.Id;
					}
					else
					{
						this._team_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Team");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
