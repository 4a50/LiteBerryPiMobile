using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LiteBerryPiMobile.Droid.Services;
using LiteBerryPiMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Audio))]
namespace LiteBerryPiMobile.Droid.Services
{
	public class Audio : IAudio
	{
		public Audio()
    {

    }

		public bool PlayAudioFile(string fileName)
		{
			var player = new MediaPlayer();
			var fd = Android.App.Application.Context.Assets.OpenFd(fileName);
			player.Prepared += (s, e) =>
			{
				player.Start();
			};
			player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
			player.Prepare();
			return true;
		}
	}
}