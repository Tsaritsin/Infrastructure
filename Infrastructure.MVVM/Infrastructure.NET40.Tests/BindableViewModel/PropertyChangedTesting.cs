
namespace Infrastructure.NET40.Tests.BindableViewModel
{
	public class PropertyChangedTesting: Harmony.Infrastructure.MVVM.BindableViewModel
	{
		public string TestProp1
		{
			get { return GetPropertyValue<string>(nameof(TestProp1)); }
			set { SetPropertyValue(value, nameof(TestProp1)); }
		}
	}
}
