using System.ComponentModel;

namespace Harmony.Infrastructure.MVVM
{
	public abstract class ViewModelBase: INotifyPropertyChanged
	{
		#region Implementation INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}
