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

namespace WebApplication
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Tests")]
	public partial class TestInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPair(Pair instance);
    partial void UpdatePair(Pair instance);
    partial void DeletePair(Pair instance);
    partial void InsertTest(Test instance);
    partial void UpdateTest(Test instance);
    partial void DeleteTest(Test instance);
    partial void InsertWord(Word instance);
    partial void UpdateWord(Word instance);
    partial void DeleteWord(Word instance);
    partial void Insertlogin(login instance);
    partial void Updatelogin(login instance);
    partial void Deletelogin(login instance);
    partial void InsertTestResult(TestResult instance);
    partial void UpdateTestResult(TestResult instance);
    partial void DeleteTestResult(TestResult instance);
    #endregion
		
		public TestInfoDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TestInfoDataContext"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TestInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TestInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Pair> Pairs
		{
			get
			{
				return this.GetTable<Pair>();
			}
		}
		
		public System.Data.Linq.Table<Test> Tests
		{
			get
			{
				return this.GetTable<Test>();
			}
		}
		
		public System.Data.Linq.Table<Word> Words
		{
			get
			{
				return this.GetTable<Word>();
			}
		}
		
		public System.Data.Linq.Table<login> logins
		{
			get
			{
				return this.GetTable<login>();
			}
		}
		
		public System.Data.Linq.Table<TestResult> TestResults
		{
			get
			{
				return this.GetTable<TestResult>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pairs")]
	public partial class Pair : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _testId;
		
		private string _pairname;
		
		private EntitySet<Test> _Tests;
		
		private EntitySet<Test> _Tests1;
		
		private EntitySet<Word> _Words;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntestIdChanging(int value);
    partial void OntestIdChanged();
    partial void OnpairnameChanging(string value);
    partial void OnpairnameChanged();
    #endregion
		
		public Pair()
		{
			this._Tests = new EntitySet<Test>(new Action<Test>(this.attach_Tests), new Action<Test>(this.detach_Tests));
			this._Tests1 = new EntitySet<Test>(new Action<Test>(this.attach_Tests1), new Action<Test>(this.detach_Tests1));
			this._Words = new EntitySet<Word>(new Action<Word>(this.attach_Words), new Action<Word>(this.detach_Words));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_testId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int testId
		{
			get
			{
				return this._testId;
			}
			set
			{
				if ((this._testId != value))
				{
					this.OntestIdChanging(value);
					this.SendPropertyChanging();
					this._testId = value;
					this.SendPropertyChanged("testId");
					this.OntestIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pairname", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string pairname
		{
			get
			{
				return this._pairname;
			}
			set
			{
				if ((this._pairname != value))
				{
					this.OnpairnameChanging(value);
					this.SendPropertyChanging();
					this._pairname = value;
					this.SendPropertyChanged("pairname");
					this.OnpairnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Test", Storage="_Tests", ThisKey="testId", OtherKey="majorPairId")]
		public EntitySet<Test> Tests
		{
			get
			{
				return this._Tests;
			}
			set
			{
				this._Tests.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Test1", Storage="_Tests1", ThisKey="testId", OtherKey="minorPairId")]
		public EntitySet<Test> Tests1
		{
			get
			{
				return this._Tests1;
			}
			set
			{
				this._Tests1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Word", Storage="_Words", ThisKey="testId", OtherKey="testId")]
		public EntitySet<Word> Words
		{
			get
			{
				return this._Words;
			}
			set
			{
				this._Words.Assign(value);
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
		
		private void attach_Tests(Test entity)
		{
			this.SendPropertyChanging();
			entity.Pair = this;
		}
		
		private void detach_Tests(Test entity)
		{
			this.SendPropertyChanging();
			entity.Pair = null;
		}
		
		private void attach_Tests1(Test entity)
		{
			this.SendPropertyChanging();
			entity.Pair1 = this;
		}
		
		private void detach_Tests1(Test entity)
		{
			this.SendPropertyChanging();
			entity.Pair1 = null;
		}
		
		private void attach_Words(Word entity)
		{
			this.SendPropertyChanging();
			entity.Pair = this;
		}
		
		private void detach_Words(Word entity)
		{
			this.SendPropertyChanging();
			entity.Pair = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Test")]
	public partial class Test : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _testName;
		
		private string _description;
		
		private int _majorPairId;
		
		private int _minorPairId;
		
		private EntitySet<TestResult> _TestResults;
		
		private EntityRef<Pair> _Pair;
		
		private EntityRef<Pair> _Pair1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OntestNameChanging(string value);
    partial void OntestNameChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnmajorPairIdChanging(int value);
    partial void OnmajorPairIdChanged();
    partial void OnminorPairIdChanging(int value);
    partial void OnminorPairIdChanged();
    #endregion
		
		public Test()
		{
			this._TestResults = new EntitySet<TestResult>(new Action<TestResult>(this.attach_TestResults), new Action<TestResult>(this.detach_TestResults));
			this._Pair = default(EntityRef<Pair>);
			this._Pair1 = default(EntityRef<Pair>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_testName", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string testName
		{
			get
			{
				return this._testName;
			}
			set
			{
				if ((this._testName != value))
				{
					this.OntestNameChanging(value);
					this.SendPropertyChanging();
					this._testName = value;
					this.SendPropertyChanged("testName");
					this.OntestNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_majorPairId", DbType="Int NOT NULL")]
		public int majorPairId
		{
			get
			{
				return this._majorPairId;
			}
			set
			{
				if ((this._majorPairId != value))
				{
					if (this._Pair.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmajorPairIdChanging(value);
					this.SendPropertyChanging();
					this._majorPairId = value;
					this.SendPropertyChanged("majorPairId");
					this.OnmajorPairIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_minorPairId", DbType="Int NOT NULL")]
		public int minorPairId
		{
			get
			{
				return this._minorPairId;
			}
			set
			{
				if ((this._minorPairId != value))
				{
					if (this._Pair1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnminorPairIdChanging(value);
					this.SendPropertyChanging();
					this._minorPairId = value;
					this.SendPropertyChanged("minorPairId");
					this.OnminorPairIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Test_TestResult", Storage="_TestResults", ThisKey="Id", OtherKey="test_Id")]
		public EntitySet<TestResult> TestResults
		{
			get
			{
				return this._TestResults;
			}
			set
			{
				this._TestResults.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Test", Storage="_Pair", ThisKey="majorPairId", OtherKey="testId", IsForeignKey=true)]
		public Pair Pair
		{
			get
			{
				return this._Pair.Entity;
			}
			set
			{
				Pair previousValue = this._Pair.Entity;
				if (((previousValue != value) 
							|| (this._Pair.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pair.Entity = null;
						previousValue.Tests.Remove(this);
					}
					this._Pair.Entity = value;
					if ((value != null))
					{
						value.Tests.Add(this);
						this._majorPairId = value.testId;
					}
					else
					{
						this._majorPairId = default(int);
					}
					this.SendPropertyChanged("Pair");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Test1", Storage="_Pair1", ThisKey="minorPairId", OtherKey="testId", IsForeignKey=true)]
		public Pair Pair1
		{
			get
			{
				return this._Pair1.Entity;
			}
			set
			{
				Pair previousValue = this._Pair1.Entity;
				if (((previousValue != value) 
							|| (this._Pair1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pair1.Entity = null;
						previousValue.Tests1.Remove(this);
					}
					this._Pair1.Entity = value;
					if ((value != null))
					{
						value.Tests1.Add(this);
						this._minorPairId = value.testId;
					}
					else
					{
						this._minorPairId = default(int);
					}
					this.SendPropertyChanged("Pair1");
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
		
		private void attach_TestResults(TestResult entity)
		{
			this.SendPropertyChanging();
			entity.Test = this;
		}
		
		private void detach_TestResults(TestResult entity)
		{
			this.SendPropertyChanging();
			entity.Test = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Words")]
	public partial class Word : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _testId;
		
		private string _words;
		
		private bool _isImg;
		
		private bool _groups;
		
		private EntityRef<Pair> _Pair;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntestIdChanging(int value);
    partial void OntestIdChanged();
    partial void OnwordsChanging(string value);
    partial void OnwordsChanged();
    partial void OnisImgChanging(bool value);
    partial void OnisImgChanged();
    partial void OngroupsChanging(bool value);
    partial void OngroupsChanged();
    #endregion
		
		public Word()
		{
			this._Pair = default(EntityRef<Pair>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_testId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int testId
		{
			get
			{
				return this._testId;
			}
			set
			{
				if ((this._testId != value))
				{
					if (this._Pair.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OntestIdChanging(value);
					this.SendPropertyChanging();
					this._testId = value;
					this.SendPropertyChanged("testId");
					this.OntestIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_words", DbType="NVarChar(900) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string words
		{
			get
			{
				return this._words;
			}
			set
			{
				if ((this._words != value))
				{
					this.OnwordsChanging(value);
					this.SendPropertyChanging();
					this._words = value;
					this.SendPropertyChanged("words");
					this.OnwordsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isImg", DbType="Bit NOT NULL")]
		public bool isImg
		{
			get
			{
				return this._isImg;
			}
			set
			{
				if ((this._isImg != value))
				{
					this.OnisImgChanging(value);
					this.SendPropertyChanging();
					this._isImg = value;
					this.SendPropertyChanged("isImg");
					this.OnisImgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_groups", DbType="Bit NOT NULL")]
		public bool groups
		{
			get
			{
				return this._groups;
			}
			set
			{
				if ((this._groups != value))
				{
					this.OngroupsChanging(value);
					this.SendPropertyChanging();
					this._groups = value;
					this.SendPropertyChanged("groups");
					this.OngroupsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pair_Word", Storage="_Pair", ThisKey="testId", OtherKey="testId", IsForeignKey=true)]
		public Pair Pair
		{
			get
			{
				return this._Pair.Entity;
			}
			set
			{
				Pair previousValue = this._Pair.Entity;
				if (((previousValue != value) 
							|| (this._Pair.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pair.Entity = null;
						previousValue.Words.Remove(this);
					}
					this._Pair.Entity = value;
					if ((value != null))
					{
						value.Words.Add(this);
						this._testId = value.testId;
					}
					else
					{
						this._testId = default(int);
					}
					this.SendPropertyChanged("Pair");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.login")]
	public partial class login : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _username;
		
		private string _pwd;
		
		private bool _isTeacher;
		
		private EntitySet<TestResult> _TestResults;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpwdChanging(string value);
    partial void OnpwdChanged();
    partial void OnisTeacherChanging(bool value);
    partial void OnisTeacherChanged();
    #endregion
		
		public login()
		{
			this._TestResults = new EntitySet<TestResult>(new Action<TestResult>(this.attach_TestResults), new Action<TestResult>(this.detach_TestResults));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pwd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string pwd
		{
			get
			{
				return this._pwd;
			}
			set
			{
				if ((this._pwd != value))
				{
					this.OnpwdChanging(value);
					this.SendPropertyChanging();
					this._pwd = value;
					this.SendPropertyChanged("pwd");
					this.OnpwdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isTeacher", DbType="Bit NOT NULL")]
		public bool isTeacher
		{
			get
			{
				return this._isTeacher;
			}
			set
			{
				if ((this._isTeacher != value))
				{
					this.OnisTeacherChanging(value);
					this.SendPropertyChanging();
					this._isTeacher = value;
					this.SendPropertyChanged("isTeacher");
					this.OnisTeacherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="login_TestResult", Storage="_TestResults", ThisKey="user_id", OtherKey="user_id")]
		public EntitySet<TestResult> TestResults
		{
			get
			{
				return this._TestResults;
			}
			set
			{
				this._TestResults.Assign(value);
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
		
		private void attach_TestResults(TestResult entity)
		{
			this.SendPropertyChanging();
			entity.login = this;
		}
		
		private void detach_TestResults(TestResult entity)
		{
			this.SendPropertyChanging();
			entity.login = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TestResults")]
	public partial class TestResult : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _user_id;
		
		private int _test_Id;
		
		private string _MistakesA;
		
		private string _MistakesB;
		
		private string _TimesA;
		
		private string _TimesB;
		
		private EntityRef<Test> _Test;
		
		private EntityRef<login> _login;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Ontest_IdChanging(int value);
    partial void Ontest_IdChanged();
    partial void OnMistakesAChanging(string value);
    partial void OnMistakesAChanged();
    partial void OnMistakesBChanging(string value);
    partial void OnMistakesBChanged();
    partial void OnTimesAChanging(string value);
    partial void OnTimesAChanged();
    partial void OnTimesBChanging(string value);
    partial void OnTimesBChanged();
    #endregion
		
		public TestResult()
		{
			this._Test = default(EntityRef<Test>);
			this._login = default(EntityRef<login>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._login.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_test_Id", DbType="Int NOT NULL")]
		public int test_Id
		{
			get
			{
				return this._test_Id;
			}
			set
			{
				if ((this._test_Id != value))
				{
					if (this._Test.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ontest_IdChanging(value);
					this.SendPropertyChanging();
					this._test_Id = value;
					this.SendPropertyChanged("test_Id");
					this.Ontest_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MistakesA", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string MistakesA
		{
			get
			{
				return this._MistakesA;
			}
			set
			{
				if ((this._MistakesA != value))
				{
					this.OnMistakesAChanging(value);
					this.SendPropertyChanging();
					this._MistakesA = value;
					this.SendPropertyChanged("MistakesA");
					this.OnMistakesAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MistakesB", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string MistakesB
		{
			get
			{
				return this._MistakesB;
			}
			set
			{
				if ((this._MistakesB != value))
				{
					this.OnMistakesBChanging(value);
					this.SendPropertyChanging();
					this._MistakesB = value;
					this.SendPropertyChanged("MistakesB");
					this.OnMistakesBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimesA", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string TimesA
		{
			get
			{
				return this._TimesA;
			}
			set
			{
				if ((this._TimesA != value))
				{
					this.OnTimesAChanging(value);
					this.SendPropertyChanging();
					this._TimesA = value;
					this.SendPropertyChanged("TimesA");
					this.OnTimesAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimesB", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string TimesB
		{
			get
			{
				return this._TimesB;
			}
			set
			{
				if ((this._TimesB != value))
				{
					this.OnTimesBChanging(value);
					this.SendPropertyChanging();
					this._TimesB = value;
					this.SendPropertyChanged("TimesB");
					this.OnTimesBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Test_TestResult", Storage="_Test", ThisKey="test_Id", OtherKey="Id", IsForeignKey=true)]
		public Test Test
		{
			get
			{
				return this._Test.Entity;
			}
			set
			{
				Test previousValue = this._Test.Entity;
				if (((previousValue != value) 
							|| (this._Test.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Test.Entity = null;
						previousValue.TestResults.Remove(this);
					}
					this._Test.Entity = value;
					if ((value != null))
					{
						value.TestResults.Add(this);
						this._test_Id = value.Id;
					}
					else
					{
						this._test_Id = default(int);
					}
					this.SendPropertyChanged("Test");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="login_TestResult", Storage="_login", ThisKey="user_id", OtherKey="user_id", IsForeignKey=true)]
		public login login
		{
			get
			{
				return this._login.Entity;
			}
			set
			{
				login previousValue = this._login.Entity;
				if (((previousValue != value) 
							|| (this._login.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._login.Entity = null;
						previousValue.TestResults.Remove(this);
					}
					this._login.Entity = value;
					if ((value != null))
					{
						value.TestResults.Add(this);
						this._user_id = value.user_id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("login");
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
