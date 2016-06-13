using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidRPG.Activities
{
    [Activity(Label = "PlayActivity")]
    public class PlayActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayLayout);

            ImageButton rightArrow = FindViewById<ImageButton>(Resource.Id.RightButton);
            ImageButton leftArrow = FindViewById<ImageButton>(Resource.Id.LeftButton);
            ImageButton upArrow = FindViewById<ImageButton>(Resource.Id.UpButton);
            ImageButton downArrow = FindViewById<ImageButton>(Resource.Id.DownButton);
            ImageButton menuButton = FindViewById<ImageButton>(Resource.Id.MenuButton);
            ImageButton enterButton = FindViewById<ImageButton>(Resource.Id.EnterButton);

            rightArrow.SetImageResource(Resource.Drawable.RightArrow);
            leftArrow.SetImageResource(Resource.Drawable.LeftArrow);
            upArrow.SetImageResource(Resource.Drawable.UpArrow);
            downArrow.SetImageResource(Resource.Drawable.DownArrow);
            menuButton.SetImageResource(Resource.Drawable.MenuButton);
            enterButton.SetImageResource(Resource.Drawable.EnterButton);

            upArrow.Click += (sender, e) =>
            {

            };

            downArrow.Click += (sender, e) =>
            {

            };

            leftArrow.Click += (sender, e) =>
            {

            };

            rightArrow.Click += (sender, e) =>
            {

            };

            enterButton.Click += (sender, e) =>
            {

            };

            menuButton.Click += (sender, e) =>
            {

            };
        }

        void AskName()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            alert.SetTitle("Welcome! What is your name?");

            //alert.

            //alert.SetIcon(AppManager.DBUpdates.GetCollectable(selected).ImageResourceId);

            //Need to get the player's name somehow

            alert.SetPositiveButton("Yes", (senderAlert, args) =>
            {

            });

            alert.SetNegativeButton("No", (senderAlert, args) =>
            {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}