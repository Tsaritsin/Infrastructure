using System;
using System.Windows.Input;

namespace Harmony.Infrastructure.MVVM
{
	public class DelegateCommand : ICommand
	{
		#region Fields

		

		#endregion

		#region Implementation ICommand

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
