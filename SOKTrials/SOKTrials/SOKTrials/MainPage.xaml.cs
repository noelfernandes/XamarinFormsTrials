using SlideOverKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SOKTrials
{
	public partial class MainPage : ContentPage, IMenuContainerPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.ToolbarItems.Add(new ToolbarItem
            {
                Command = new Command(() =>
                {
                    if (this.SlideMenu.IsShown)
                    {
                        HideMenuAction?.Invoke();
                    }
                    else
                    {
                        ShowMenuAction?.Invoke();
                    }
                }),
                Icon = "icon.png",
                Text = "Settings",
                Priority = 0
            });
            this.SlideMenu = new SettingsPage();
		}

        public SlideMenuView SlideMenu { get; set; }
        public Action ShowMenuAction { get; set; }
        public Action HideMenuAction { get; set; }
    }
}
