using SlideOverKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOKTrials
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : SlideMenuView
	{
		public SettingsPage ()
		{
			InitializeComponent ();

            #region SlideDownMenu
            // You must set HeightRequest in this case
            this.HeightRequest = 600;
            // You must set IsFullScreen in this case, 
            // otherwise you need to set WidthRequest, 
            // just like the QuickInnerMenu sample
            this.IsFullScreen = true;
            this.MenuOrientations = MenuOrientation.TopToBottom;

            // You must set BackgroundColor, 
            // and you cannot put another layout with background color cover the whole View
            // otherwise, it cannot be dragged on Android
            this.BackgroundColor = Color.FromHex("#D8DDE7");
            #endregion

            #region RightSideMasterView
            //// You must set IsFullScreen in this case, 
            //// otherwise you need to set HeightRequest, 
            //// just like the QuickInnerMenu sample
            //this.IsFullScreen = true;
            //// You must set WidthRequest in this case
            //this.WidthRequest = 250;
            //this.MenuOrientations = MenuOrientation.RightToLeft;

            //// You must set BackgroundColor, 
            //// and you cannot put another layout with background color cover the whole View
            //// otherwise, it cannot be dragged on Android
            //this.BackgroundColor = Color.White;

            //// This is shadow view color, you can set a transparent color
            //this.BackgroundViewColor = Color.FromHex("#CE766C");
            #endregion

        }
	}
}