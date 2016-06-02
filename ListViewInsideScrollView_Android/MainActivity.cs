using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace ListViewInsideScrollView_Android
{
	[Activity (Label = "ListViewInsideScrollView_Android", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		string[] items;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource.
			SetContentView (Resource.Layout.Main);

			items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers", "Seeds", "Leafs", "Roots", "Mushrooms" };
			ListView listView = FindViewById<ListView> (Resource.Id.listView);
			var listAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
			listView.Adapter = listAdapter;
			listView.ItemClick += OnListItemClick;

			Utility.setListViewHeightBasedOnChildren(listView);
		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var t = items[e.Position];
			Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
			Console.WriteLine("Clicked on " + t);
		}
	}

	public class Utility
	{
		public static void setListViewHeightBasedOnChildren (ListView listView)
		{
			if (listView.Adapter == null) {
				// Pre-condition.
				return;
			}

			int totalHeight = listView.PaddingTop + listView.PaddingBottom;
			for (int i = 0; i < listView.Count; i++) {
				View listItem = listView.Adapter.GetView (i, null, listView);
				if (listItem.GetType () == typeof(ViewGroup)) {
					listItem.LayoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
				}
				listItem.Measure (0, 0);
				totalHeight += listItem.MeasuredHeight;
			}

			listView.LayoutParameters.Height = totalHeight + (listView.DividerHeight * (listView.Count - 1));
		}
	}
}


