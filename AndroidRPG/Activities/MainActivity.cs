using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidRPG
{
    [Activity(Label = "AndroidRPG", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            
            button.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(AndroidRPG.MainActivity));
            };
        }
    }
}

