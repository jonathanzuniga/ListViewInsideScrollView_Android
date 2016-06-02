using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace ListViewInsideScrollView_Android
{
	[Activity (Label = "ListViewInsideScrollView_Android", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ListActivity
	{
		string[] items;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource.
//			SetContentView (Resource.Layout.Main);

			items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
//			ListView listView = FindViewById<ListView> (Resource.Id.listView);
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var t = items[position];
			Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
			Console.WriteLine("Clicked on " + t);
		}
	}
}


