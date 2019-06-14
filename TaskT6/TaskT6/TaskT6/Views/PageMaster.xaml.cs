using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskT6.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskT6.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageMaster : MasterDetailPage
	{
		public PageMaster ()
		{
			InitializeComponent ();
            btnlogout.Effects.Add(Effect.Resolve($"TaskT6.{nameof(LongPressedEffect)}"));
          
		}

      
    }
}