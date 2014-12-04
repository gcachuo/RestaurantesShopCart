﻿using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Rest_Hotel")]
	public partial class CarritoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCarritoe(Carritoe instance);
    partial void UpdateCarritoe(Carritoe instance);
    partial void DeleteCarritoe(Carritoe instance);
    #endregion
		
		public CarritoDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Rest_HotelConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CarritoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarritoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarritoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarritoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Carritoe> Carritoes
		{
			get
			{
				return this.GetTable<Carritoe>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Carritoes")]
	public partial class Carritoe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        [Key]
		
		private int _Carrito_Llave;
		
		private System.Nullable<int> _Carrito_Id;
		
		private string _Carrito_Restaurante;
		
		private string _Carrito_Tipo;
		
		private string _Carrito_Nombre;
		
		private string _Carrito_Descripcion;
		
		private System.Nullable<decimal> _Carrito_Precio;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCarrito_LlaveChanging(int value);
    partial void OnCarrito_LlaveChanged();
    partial void OnCarrito_IdChanging(System.Nullable<int> value);
    partial void OnCarrito_IdChanged();
    partial void OnCarrito_RestauranteChanging(string value);
    partial void OnCarrito_RestauranteChanged();
    partial void OnCarrito_TipoChanging(string value);
    partial void OnCarrito_TipoChanged();
    partial void OnCarrito_NombreChanging(string value);
    partial void OnCarrito_NombreChanged();
    partial void OnCarrito_DescripcionChanging(string value);
    partial void OnCarrito_DescripcionChanged();
    partial void OnCarrito_PrecioChanging(System.Nullable<decimal> value);
    partial void OnCarrito_PrecioChanged();
    #endregion
		
		public Carritoe()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Llave", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		[Key]
        public int Carrito_Llave
		{
			get
			{
				return this._Carrito_Llave;
			}
			set
			{
				if ((this._Carrito_Llave != value))
				{
					this.OnCarrito_LlaveChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Llave = value;
					this.SendPropertyChanged("Carrito_Llave");
					this.OnCarrito_LlaveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Id", DbType="Int")]
		public System.Nullable<int> Carrito_Id
		{
			get
			{
				return this._Carrito_Id;
			}
			set
			{
				if ((this._Carrito_Id != value))
				{
					this.OnCarrito_IdChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Id = value;
					this.SendPropertyChanged("Carrito_Id");
					this.OnCarrito_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Restaurante", DbType="NVarChar(255)")]
		public string Carrito_Restaurante
		{
			get
			{
				return this._Carrito_Restaurante;
			}
			set
			{
				if ((this._Carrito_Restaurante != value))
				{
					this.OnCarrito_RestauranteChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Restaurante = value;
					this.SendPropertyChanged("Carrito_Restaurante");
					this.OnCarrito_RestauranteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Tipo", DbType="NVarChar(255)")]
		public string Carrito_Tipo
		{
			get
			{
				return this._Carrito_Tipo;
			}
			set
			{
				if ((this._Carrito_Tipo != value))
				{
					this.OnCarrito_TipoChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Tipo = value;
					this.SendPropertyChanged("Carrito_Tipo");
					this.OnCarrito_TipoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Nombre", DbType="NVarChar(255)")]
		public string Carrito_Nombre
		{
			get
			{
				return this._Carrito_Nombre;
			}
			set
			{
				if ((this._Carrito_Nombre != value))
				{
					this.OnCarrito_NombreChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Nombre = value;
					this.SendPropertyChanged("Carrito_Nombre");
					this.OnCarrito_NombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Descripcion", DbType="NVarChar(255)")]
		public string Carrito_Descripcion
		{
			get
			{
				return this._Carrito_Descripcion;
			}
			set
			{
				if ((this._Carrito_Descripcion != value))
				{
					this.OnCarrito_DescripcionChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Descripcion = value;
					this.SendPropertyChanged("Carrito_Descripcion");
					this.OnCarrito_DescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Carrito_Precio", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Carrito_Precio
		{
			get
			{
				return this._Carrito_Precio;
			}
			set
			{
				if ((this._Carrito_Precio != value))
				{
					this.OnCarrito_PrecioChanging(value);
					this.SendPropertyChanging();
					this._Carrito_Precio = value;
					this.SendPropertyChanged("Carrito_Precio");
					this.OnCarrito_PrecioChanged();
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
