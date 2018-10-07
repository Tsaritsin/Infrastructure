using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Harmony.Infrastructure.Common.ExtentionMethods;

namespace Harmony.Infrastructure.MVVM
{
	public abstract class ViewModelBase: INotifyPropertyChanged, INotifyPropertyChanging
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

		protected T GetPropertyValue<T>(string propertyName)
		{
			propertyName.ThrowIfArgumentIsNullOrEmpty(nameof(propertyName));

			object value;
			if (_propertyValues.TryGetValue(propertyName, out value))
				return (T)value;
			return default(T);
		}

		protected bool SetPropertyValue<T>(T newValue, string propertyName)
		{
			propertyName.ThrowIfArgumentIsNullOrEmpty(nameof(propertyName));
			
			if (EqualityComparer<T>.Default.Equals(newValue, GetPropertyValue<T>(propertyName)))
				return false;
			OnPropertyChanging(propertyName);
			_propertyValues[propertyName] = newValue;
			OnPropertyChanged(propertyName);
			return true;
		}

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

		public event PropertyChangedEventHandler PropertyChanged;

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

		public event PropertyChangingEventHandler PropertyChanging;

		protected void OnPropertyChanging(string propertyName)
		{
			PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
		}

		#endregion
	}
}
