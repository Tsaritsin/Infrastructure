using System;
using System.Windows.Input;

namespace Harmony.Infrastructure.MVVM
{
	/// <summary>
	/// It is implementation of interface <see cref="ICommand"/> />.
	/// </summary>
	public class DelegateCommand : ICommand
	{
		#region Fields

		private readonly Action<object> _executeMethod;
		private readonly Predicate<object> _canExecuteMethod;

		#endregion

		/// <summary>
		/// Creates a new instance of <see cref="DelegateCommand"/>
		/// </summary>
		/// <param name="executeMethod">Invoke when <see cref="ICommand.Execute"/> is called.</param>
		/// <param name="canExecuteMethod">Invoke when <see cref="ICommand.CanExecute"/> is called</param>
		public DelegateCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
		{
			_executeMethod = executeMethod ?? throw new ArgumentNullException(nameof(executeMethod));
			_canExecuteMethod = canExecuteMethod ?? throw new ArgumentNullException(nameof(canExecuteMethod));
		}

		#region Implementation ICommand

		#region Events

		#region CanExecuteChanged

		public event EventHandler CanExecuteChanged;

		public void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		#endregion

		#region Methods

		/// <summary>
		/// Determines if the command can be executed.
		/// </summary>
		/// <returns>Returns <see langword="true"/> if the command can execute,otherwise returns <see langword="false"/>.</returns>
		public bool CanExecute(object parameter)
		{
			return _canExecuteMethod(parameter);
		}

		///<summary>
		/// Executes the command.
		///</summary>
		public void Execute(object parameter)
		{
			_executeMethod(parameter);
		}

		#endregion

		#endregion
	}
}
