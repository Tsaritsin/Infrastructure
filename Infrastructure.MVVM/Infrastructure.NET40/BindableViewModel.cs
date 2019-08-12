using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Harmony.Infrastructure.MVVM
{
	public abstract class BindableViewModel : INotifyPropertyChanged, INotifyPropertyChanging
	{
		#region Fields

		private readonly Dictionary<string, object> _propertyValues = new Dictionary<string, object>();

		/// <summary>
		/// Cache, which contains all propeties, marked of DependencyFromPropertyAttribute.
		/// Contains: Property and property which depend from him
		/// </summary>
		private ILookup<string, string> _propertiesForRaisingOfEventPropertyChanged;

		#endregion

		#region Methods

		/// <summary>
		/// Return value of property
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		protected T GetPropertyValue<T>(string propertyName)
		{
			if(String.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException(nameof(propertyName));

			object value;
			if (_propertyValues.TryGetValue(propertyName, out value))
				return (T)value;
			return default(T);
		}

		/// <summary>
		/// return true if property value do not equals to new value and rase PropertyChanged event
		/// </summary>
		/// <typeparam name="T">Type of value</typeparam>
		/// <param name="newValue">New Value</param>
		/// <param name="propertyName">Name of property</param>
		/// <returns></returns>
		protected bool SetPropertyValue<T>(T newValue, string propertyName)
		{
			if (String.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException(nameof(propertyName));

			if (EqualityComparer<T>.Default.Equals(newValue, GetPropertyValue<T>(propertyName)))
				return false;
			OnPropertyChanging(propertyName);
			_propertyValues[propertyName] = newValue;
			OnPropertyChanged(propertyName);
			return true;
		}

		/// <summary>
		/// List of dependecly properties for all properties in class
		/// </summary>
		/// <returns></returns>
		private ILookup<string, string> GetPropertiesWhichHasDependencies()
		{
			return _propertiesForRaisingOfEventPropertyChanged ??
			(
				_propertiesForRaisingOfEventPropertyChanged = (
					from p in GetType().GetProperties()
					let attrs = p.GetCustomAttributes(typeof(DependencyFromPropertyAttribute), false)
					from DependencyFromPropertyAttribute a in attrs
					select new
					{
						MainProperty = a.PropertyName,
						PropertyWhichIsDepend = p.Name
					}).ToLookup(
					main => main.MainProperty,
					isDepend => isDepend.PropertyWhichIsDepend)
			);
		}

		#endregion

		#region Implementation INotifyPropertyChanged

		/// <summary>
		/// Raised when changed value for some property
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raise event PropertyChanged
		/// </summary>
		/// <param name="propertyName"></param>
		protected void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler == null)
				return;

			handler(this, new PropertyChangedEventArgs(propertyName));

			var dependentProperties = GetPropertiesWhichHasDependencies();
			// Raice of event PropertyChanged for all properties, which marked of DependencyFromPropertyAttribute
			foreach (var dependentPropertyName in dependentProperties[propertyName])
				OnPropertyChanged(dependentPropertyName);
		}

		#endregion

		#region Implementation INotifyPropertyChanging

		/// <summary>
		/// Raised when changing value for some property
		/// </summary>
		public event PropertyChangingEventHandler PropertyChanging;

		/// <summary>
		/// Raise event PropertyChanging
		/// </summary>
		/// <param name="propertyName"></param>
		protected void OnPropertyChanging(string propertyName)
		{
			PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
		}

		#endregion
	}
}
