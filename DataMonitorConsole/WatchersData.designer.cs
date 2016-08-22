﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataMonitorConsole
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DataMonitor")]
	public partial class WatchersDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertWatcher(Watcher instance);
    partial void UpdateWatcher(Watcher instance);
    partial void DeleteWatcher(Watcher instance);
    #endregion
		
		public WatchersDataDataContext() : 
				base(global::DataMonitorConsole.Properties.Settings.Default.DataMonitorConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public WatchersDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WatchersDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WatchersDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WatchersDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<vWatcher> vWatchers
		{
			get
			{
				return this.GetTable<vWatcher>();
			}
		}
		
		public System.Data.Linq.Table<Watcher> Watchers
		{
			get
			{
				return this.GetTable<Watcher>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vWatchers")]
	public partial class vWatcher
	{
		
		private int _Id;
		
		private string _Name;
		
		private string _LevelName;
		
		private System.Nullable<int> _ClientId;
		
		private string _ClientName;
		
		private string _DBServer;
		
		private string _Database;
		
		private System.Nullable<int> _SourceId;
		
		private string _SourceName;
		
		private string _Table;
		
		private System.Nullable<int> _MetricId;
		
		private string _MetricName;
		
		private string _Email;
		
		private System.Nullable<long> _LastValue;
		
		private string _ThreasholdName;
		
		private int _Percentage;
		
		public vWatcher()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LevelName", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string LevelName
		{
			get
			{
				return this._LevelName;
			}
			set
			{
				if ((this._LevelName != value))
				{
					this._LevelName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientId", DbType="Int")]
		public System.Nullable<int> ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				if ((this._ClientId != value))
				{
					this._ClientId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientName", DbType="NVarChar(50)")]
		public string ClientName
		{
			get
			{
				return this._ClientName;
			}
			set
			{
				if ((this._ClientName != value))
				{
					this._ClientName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBServer", DbType="NVarChar(100)")]
		public string DBServer
		{
			get
			{
				return this._DBServer;
			}
			set
			{
				if ((this._DBServer != value))
				{
					this._DBServer = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Database]", Storage="_Database", DbType="NVarChar(50)")]
		public string Database
		{
			get
			{
				return this._Database;
			}
			set
			{
				if ((this._Database != value))
				{
					this._Database = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceId", DbType="Int")]
		public System.Nullable<int> SourceId
		{
			get
			{
				return this._SourceId;
			}
			set
			{
				if ((this._SourceId != value))
				{
					this._SourceId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceName", DbType="NVarChar(50)")]
		public string SourceName
		{
			get
			{
				return this._SourceName;
			}
			set
			{
				if ((this._SourceName != value))
				{
					this._SourceName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Table]", Storage="_Table", DbType="NVarChar(50)")]
		public string Table
		{
			get
			{
				return this._Table;
			}
			set
			{
				if ((this._Table != value))
				{
					this._Table = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MetricId", DbType="Int")]
		public System.Nullable<int> MetricId
		{
			get
			{
				return this._MetricId;
			}
			set
			{
				if ((this._MetricId != value))
				{
					this._MetricId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MetricName", DbType="NVarChar(50)")]
		public string MetricName
		{
			get
			{
				return this._MetricName;
			}
			set
			{
				if ((this._MetricName != value))
				{
					this._MetricName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastValue", DbType="BigInt")]
		public System.Nullable<long> LastValue
		{
			get
			{
				return this._LastValue;
			}
			set
			{
				if ((this._LastValue != value))
				{
					this._LastValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThreasholdName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ThreasholdName
		{
			get
			{
				return this._ThreasholdName;
			}
			set
			{
				if ((this._ThreasholdName != value))
				{
					this._ThreasholdName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Percentage", DbType="Int NOT NULL")]
		public int Percentage
		{
			get
			{
				return this._Percentage;
			}
			set
			{
				if ((this._Percentage != value))
				{
					this._Percentage = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Watchers")]
	public partial class Watcher : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _LevelId;
		
		private System.Nullable<int> _ClientId;
		
		private System.Nullable<int> _SourceId;
		
		private System.Nullable<int> _MetricId;
		
		private int _ThreasholdId;
		
		private int _NotificationId;
		
		private System.Nullable<long> _LastValue;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLevelIdChanging(int value);
    partial void OnLevelIdChanged();
    partial void OnClientIdChanging(System.Nullable<int> value);
    partial void OnClientIdChanged();
    partial void OnSourceIdChanging(System.Nullable<int> value);
    partial void OnSourceIdChanged();
    partial void OnMetricIdChanging(System.Nullable<int> value);
    partial void OnMetricIdChanged();
    partial void OnThreasholdIdChanging(int value);
    partial void OnThreasholdIdChanged();
    partial void OnNotificationIdChanging(int value);
    partial void OnNotificationIdChanged();
    partial void OnLastValueChanging(System.Nullable<long> value);
    partial void OnLastValueChanged();
    #endregion
		
		public Watcher()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LevelId", DbType="Int NOT NULL")]
		public int LevelId
		{
			get
			{
				return this._LevelId;
			}
			set
			{
				if ((this._LevelId != value))
				{
					this.OnLevelIdChanging(value);
					this.SendPropertyChanging();
					this._LevelId = value;
					this.SendPropertyChanged("LevelId");
					this.OnLevelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClientId", DbType="Int")]
		public System.Nullable<int> ClientId
		{
			get
			{
				return this._ClientId;
			}
			set
			{
				if ((this._ClientId != value))
				{
					this.OnClientIdChanging(value);
					this.SendPropertyChanging();
					this._ClientId = value;
					this.SendPropertyChanged("ClientId");
					this.OnClientIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SourceId", DbType="Int")]
		public System.Nullable<int> SourceId
		{
			get
			{
				return this._SourceId;
			}
			set
			{
				if ((this._SourceId != value))
				{
					this.OnSourceIdChanging(value);
					this.SendPropertyChanging();
					this._SourceId = value;
					this.SendPropertyChanged("SourceId");
					this.OnSourceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MetricId", DbType="Int")]
		public System.Nullable<int> MetricId
		{
			get
			{
				return this._MetricId;
			}
			set
			{
				if ((this._MetricId != value))
				{
					this.OnMetricIdChanging(value);
					this.SendPropertyChanging();
					this._MetricId = value;
					this.SendPropertyChanged("MetricId");
					this.OnMetricIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThreasholdId", DbType="Int NOT NULL")]
		public int ThreasholdId
		{
			get
			{
				return this._ThreasholdId;
			}
			set
			{
				if ((this._ThreasholdId != value))
				{
					this.OnThreasholdIdChanging(value);
					this.SendPropertyChanging();
					this._ThreasholdId = value;
					this.SendPropertyChanged("ThreasholdId");
					this.OnThreasholdIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NotificationId", DbType="Int NOT NULL")]
		public int NotificationId
		{
			get
			{
				return this._NotificationId;
			}
			set
			{
				if ((this._NotificationId != value))
				{
					this.OnNotificationIdChanging(value);
					this.SendPropertyChanging();
					this._NotificationId = value;
					this.SendPropertyChanged("NotificationId");
					this.OnNotificationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastValue", DbType="BigInt")]
		public System.Nullable<long> LastValue
		{
			get
			{
				return this._LastValue;
			}
			set
			{
				if ((this._LastValue != value))
				{
					this.OnLastValueChanging(value);
					this.SendPropertyChanging();
					this._LastValue = value;
					this.SendPropertyChanged("LastValue");
					this.OnLastValueChanged();
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