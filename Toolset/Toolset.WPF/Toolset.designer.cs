﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Toolset.WPF
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="da2_content")]
	public partial class ToolsetDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertt_ModulesTable(t_ModulesTable instance);
    partial void Updatet_ModulesTable(t_ModulesTable instance);
    partial void Deletet_ModulesTable(t_ModulesTable instance);
    #endregion
		
		public ToolsetDataContext() : 
				base(global::Toolset.WPF.Properties.Settings.Default.da2_contentConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsetDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsetDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsetDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ToolsetDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<t_HashesTable> t_HashesTables
		{
			get
			{
				return this.GetTable<t_HashesTable>();
			}
		}
		
		public System.Data.Linq.Table<t_PlotsTable> t_PlotsTables
		{
			get
			{
				return this.GetTable<t_PlotsTable>();
			}
		}
		
		public System.Data.Linq.Table<t_TalkTable> t_TalkTables
		{
			get
			{
				return this.GetTable<t_TalkTable>();
			}
		}
		
		public System.Data.Linq.Table<t_ModulesTable> t_ModulesTables
		{
			get
			{
				return this.GetTable<t_ModulesTable>();
			}
		}
		
		public System.Data.Linq.Table<t_ResourcePathTable> t_ResourcePathTables
		{
			get
			{
				return this.GetTable<t_ResourcePathTable>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_HashesTable")]
	public partial class t_HashesTable
	{
		
		private string _FullName;
		
		private string _FileType;
		
		private string _NameHash;
		
		private string _TypeHash;
		
		private string _Parent;
		
		private string _Project;
		
		public t_HashesTable()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="VarChar(255)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this._FullName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileType", DbType="VarChar(64)")]
		public string FileType
		{
			get
			{
				return this._FileType;
			}
			set
			{
				if ((this._FileType != value))
				{
					this._FileType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameHash", DbType="VarChar(MAX)")]
		public string NameHash
		{
			get
			{
				return this._NameHash;
			}
			set
			{
				if ((this._NameHash != value))
				{
					this._NameHash = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeHash", DbType="VarChar(MAX)")]
		public string TypeHash
		{
			get
			{
				return this._TypeHash;
			}
			set
			{
				if ((this._TypeHash != value))
				{
					this._TypeHash = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parent", DbType="VarChar(MAX)")]
		public string Parent
		{
			get
			{
				return this._Parent;
			}
			set
			{
				if ((this._Parent != value))
				{
					this._Parent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project", DbType="VarChar(MAX)")]
		public string Project
		{
			get
			{
				return this._Project;
			}
			set
			{
				if ((this._Project != value))
				{
					this._Project = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_PlotsTable")]
	public partial class t_PlotsTable
	{
		
		private string _Name;
		
		private string _UUID;
		
		public t_PlotsTable()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(MAX)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UUID", DbType="VarChar(MAX)")]
		public string UUID
		{
			get
			{
				return this._UUID;
			}
			set
			{
				if ((this._UUID != value))
				{
					this._UUID = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_TalkTable")]
	public partial class t_TalkTable
	{
		
		private System.Nullable<int> _ID;
		
		private string _String;
		
		private string _Project;
		
		private string _LanguageID;
		
		private System.Nullable<bool> _IsPatch;
		
		public t_TalkTable()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int")]
		public System.Nullable<int> ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_String", DbType="NVarChar(MAX)")]
		public string String
		{
			get
			{
				return this._String;
			}
			set
			{
				if ((this._String != value))
				{
					this._String = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project", DbType="NVarChar(MAX)")]
		public string Project
		{
			get
			{
				return this._Project;
			}
			set
			{
				if ((this._Project != value))
				{
					this._Project = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LanguageID", DbType="NVarChar(MAX)")]
		public string LanguageID
		{
			get
			{
				return this._LanguageID;
			}
			set
			{
				if ((this._LanguageID != value))
				{
					this._LanguageID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPatch", DbType="Bit")]
		public System.Nullable<bool> IsPatch
		{
			get
			{
				return this._IsPatch;
			}
			set
			{
				if ((this._IsPatch != value))
				{
					this._IsPatch = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_ModulesTable")]
	public partial class t_ModulesTable : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _ModuleID;
		
		private string _DisplayName;
		
		private string _Name;
		
		private string _UUID;
		
		private string _LanguageID;
		
		private string _Details;
		
		private string _ProjectType;
		
		private System.Nullable<bool> _IsActive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnModuleIDChanging(System.Nullable<int> value);
    partial void OnModuleIDChanged();
    partial void OnDisplayNameChanging(string value);
    partial void OnDisplayNameChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnUUIDChanging(string value);
    partial void OnUUIDChanged();
    partial void OnLanguageIDChanging(string value);
    partial void OnLanguageIDChanged();
    partial void OnDetailsChanging(string value);
    partial void OnDetailsChanged();
    partial void OnProjectTypeChanging(string value);
    partial void OnProjectTypeChanged();
    partial void OnIsActiveChanging(System.Nullable<bool> value);
    partial void OnIsActiveChanged();
    #endregion
		
		public t_ModulesTable()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModuleID", DbType="Int")]
		public System.Nullable<int> ModuleID
		{
			get
			{
				return this._ModuleID;
			}
			set
			{
				if ((this._ModuleID != value))
				{
					this.OnModuleIDChanging(value);
					this.SendPropertyChanging();
					this._ModuleID = value;
					this.SendPropertyChanged("ModuleID");
					this.OnModuleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayName", DbType="VarChar(MAX)")]
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if ((this._DisplayName != value))
				{
					this.OnDisplayNameChanging(value);
					this.SendPropertyChanging();
					this._DisplayName = value;
					this.SendPropertyChanged("DisplayName");
					this.OnDisplayNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(MAX)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UUID", DbType="VarChar(MAX)", IsPrimaryKey=true)]
		public string UUID
		{
			get
			{
				return this._UUID;
			}
			set
			{
				if ((this._UUID != value))
				{
					this.OnUUIDChanging(value);
					this.SendPropertyChanging();
					this._UUID = value;
					this.SendPropertyChanged("UUID");
					this.OnUUIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LanguageID", DbType="VarChar(MAX)")]
		public string LanguageID
		{
			get
			{
				return this._LanguageID;
			}
			set
			{
				if ((this._LanguageID != value))
				{
					this.OnLanguageIDChanging(value);
					this.SendPropertyChanging();
					this._LanguageID = value;
					this.SendPropertyChanged("LanguageID");
					this.OnLanguageIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Details", DbType="VarChar(MAX)")]
		public string Details
		{
			get
			{
				return this._Details;
			}
			set
			{
				if ((this._Details != value))
				{
					this.OnDetailsChanging(value);
					this.SendPropertyChanging();
					this._Details = value;
					this.SendPropertyChanged("Details");
					this.OnDetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectType", DbType="VarChar(MAX)")]
		public string ProjectType
		{
			get
			{
				return this._ProjectType;
			}
			set
			{
				if ((this._ProjectType != value))
				{
					this.OnProjectTypeChanging(value);
					this.SendPropertyChanging();
					this._ProjectType = value;
					this.SendPropertyChanged("ProjectType");
					this.OnProjectTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_ResourcePathTable")]
	public partial class t_ResourcePathTable
	{
		
		private string _FullRelativePath;
		
		private string _ResourceName;
		
		private System.Nullable<bool> _IsOverride;
		
		public t_ResourcePathTable()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullRelativePath", DbType="VarChar(MAX)")]
		public string FullRelativePath
		{
			get
			{
				return this._FullRelativePath;
			}
			set
			{
				if ((this._FullRelativePath != value))
				{
					this._FullRelativePath = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ResourceName", DbType="VarChar(MAX)")]
		public string ResourceName
		{
			get
			{
				return this._ResourceName;
			}
			set
			{
				if ((this._ResourceName != value))
				{
					this._ResourceName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsOverride", DbType="Bit")]
		public System.Nullable<bool> IsOverride
		{
			get
			{
				return this._IsOverride;
			}
			set
			{
				if ((this._IsOverride != value))
				{
					this._IsOverride = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
