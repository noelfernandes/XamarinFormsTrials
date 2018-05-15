using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFHttpClientTrials.Models;
using XFHttpClientTrials.Services;

namespace XFHttpClientTrials
{
	public partial class MainPage : ContentPage
	{
        IRequestService HttpRequestService;
        private List<Comment> Posts = new List<Comment>();
		public MainPage()
		{
			InitializeComponent();
            FetchData();
            this.LblMessage.Text = $"We have {Posts.Count} posts";
        }

        public async void FetchData()
        {
            HttpRequestService = new RequestService();
            Posts = await HttpRequestService.GetAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments", string.Empty);
        }
	}
}
