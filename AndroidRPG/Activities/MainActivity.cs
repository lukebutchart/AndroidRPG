using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidRPG.DataManagement;
using AndroidRPG.Objects;
using System.Collections.Generic;

namespace AndroidRPG
{
    [Activity(Label = "AndroidRPG", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DatabaseUpdates dataUpdates = GameMaster.DBUpdates;
            dataUpdates.SetContext(this);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button playButton = FindViewById<Button>(Resource.Id.PlayButton);

            PopulateTable<Ability>(dataUpdates);
            PopulateTable<Character>(dataUpdates);
            PopulateTable<Division>(dataUpdates);

            button.Click += (sender, e) =>
            {
                dataUpdates.GetAbility("Fireball").ReportAbility(dataUpdates.GetAbility("Fireball"));
                Console.WriteLine();
                Character mary = dataUpdates.GetCharacter("Mary");
                Console.WriteLine();
                Division div = dataUpdates.GetDivision("Mage");
                Console.WriteLine();
            };

            playButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(Activities.PlayActivity));
                StartActivity(intent);
            };
        }

        private static void PopulateTable<T>(DatabaseUpdates dataUpdates)
        {
            List<string> allNames = new List<string>();

            if (typeof(T) == typeof(Ability))
            {
                foreach (Ability ability in dataUpdates.GetAllAbilitys())
                {
                    allNames.Add(ability.Name);
                }

                foreach (Ability ability in GameMaster.Abilitys)
                {
                    if (!allNames.Contains(ability.Name))
                    {
                        dataUpdates.AddAbility(ability);
                    }
                }
            }
            if (typeof(T) == typeof(Character))
            {
                foreach (Character character in dataUpdates.GetAllCharacters())
                {
                    allNames.Add(character.Name);
                }

                foreach (Character character in GameMaster.Characters)
                {
                    if (!allNames.Contains(character.Name))
                    {
                        dataUpdates.AddCharacter(character);
                    }
                }
            }
            if (typeof(T) == typeof(Division))
            {
                foreach (Division division in dataUpdates.GetAllDivisions())
                {
                    allNames.Add(division.Name);
                }

                foreach (Division division in GameMaster.Divisions)
                {
                    if (!allNames.Contains(division.Name))
                    {
                        dataUpdates.AddDivision(division);
                    }
                }
            }
        }
    }
}

