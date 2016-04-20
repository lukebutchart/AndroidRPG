using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.App;

namespace AndroidRPG.Objects
{
    class Character : MasterClass
    {
        public string           Gender          { get; set; }
        public int              Health          { get; set; }
        public int              Mana            { get; set; }
        public int              Attack          { get; set; }
        public int              Magic           { get; set; }
        public int              Defence         { get; set; }
        public int              Speed           { get; set; }
        public int              Vitality        { get; set; }
        public int              Perception      { get; set; }
        public int              Strength        { get; set; }
        public int              Intelligence    { get; set; }
        public int              Endurance       { get; set; }
        public int              Agility         { get; set; }
        public List<int>        StatRoll        { get; set; }
        public List<Ability>    AbilityList     { get; set; }


        public Character() { }

        public Character(string name, string gender)//, string statusEffect, int costBase, int costIncrease, int powerBase, int powerIncrease, bool existence = true, int maxLevel = 5)
        {
            this.Name = name;
            this.Gender = gender;
            //this.StatusEffect = statusEffect;
            //this.CostBase = costBase;
            //this.PowerBase = powerBase;
            //this.PowerIncrease = powerIncrease;
            //this.Existence = existence;
            //this.MaxLevel = maxLevel;
        }

        public void GenerateStats(Character character) //, List<int> randomSeed, Data data)
        {
            string statsListString = Application.Context.GetString(Resource.String.StatsList);
            List<string> statsList = statsListString.Split(',').ToList<string>();

            character.Attack    = character.Strength     *  int.Parse(Application.Context.GetString(Resource.Integer.StrengthMultiplier));
            character.Defence   = character.Endurance    *  int.Parse(Application.Context.GetString(Resource.Integer.EnduranceMultiplier));
            character.Health    = character.Vitality     *  int.Parse(Application.Context.GetString(Resource.Integer.VitalityMultiplier));
            character.Magic     = character.Intelligence *  int.Parse(Application.Context.GetString(Resource.Integer.IntelligenceMultiplier));
            character.Mana      = character.Perception   *  int.Parse(Application.Context.GetString(Resource.Integer.PerceptionMultiplier));
            character.Speed     = character.Agility      *  int.Parse(Application.Context.GetString(Resource.Integer.AgilityMultiplier));

            character.Attack    +=  character.StatRoll[statsList.IndexOf("Attack")];
            character.Defence   +=  character.StatRoll[statsList.IndexOf("Defence")];
            character.Health    +=  character.StatRoll[statsList.IndexOf("Health")];
            character.Magic     +=  character.StatRoll[statsList.IndexOf("Magic")];
            character.Mana      +=  character.StatRoll[statsList.IndexOf("Mana")];
            character.Speed     +=  character.StatRoll[statsList.IndexOf("Speed")];

            //character.Attack = character.Strength * int.Parse(data.GetData(data.Special, "Strength")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Attack")];
            //character.Defence = character.Endurance * int.Parse(data.GetData(data.Special, "Endurance")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Defence")];
            //character.Health = character.Vitality * int.Parse(data.GetData(data.Special, "Vitality")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Health")];
            //character.Magic = character.Intelligence * int.Parse(data.GetData(data.Special, "Intelligence")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Magic")];
            //character.Mana = character.Perception * int.Parse(data.GetData(data.Special, "Perception")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Mana")];
            //character.Speed = character.Agility * int.Parse(data.GetData(data.Special, "Agility")) + character.StatRoll[data.Stats.ColumnNames.IndexOf("Speed")];
            //Console.WriteLine();
        }


        /// <summary>
        /// Returns a person with a new random name for them based on gender. (can be used to clone a person with a new name if 'clone' bool is supplied)
        /// </summary>
        /// <param name="person">The person to give a new random name.</param>
        /// <param name="clone">If 'true' the person's previous name will not be re-chosen.</param>
        /// <returns>A clone of the input person with a new randomised name.</returns>
        //public void GenerateName(Character person, /*List<int> randomSeed, Data data, */ bool clone = false)
        //{
        //    List<string> nameList;
        //    int nameCount;
        //    Rand rand = new Rand();
        //    string name;

        //    if (person.Gender == "M" || person.Gender == "m")
        //    {
        //        nameList = data.Names.MaleNameList;
        //    }
        //    else if (person.Gender == "F" || person.Gender == "f")
        //    {
        //        nameList = data.Names.FemaleNameList;
        //    }
        //    else
        //    {
        //        nameList = data.Names.MaleNameList;
        //        nameList.AddRange(data.Names.FemaleNameList);
        //    }

        //    if (clone && person.Name != null)
        //    {
        //        nameList.Remove(person.Name);
        //    }

        //    nameCount = nameList.Count();

        //    name = nameList[rand.GetRandomInt(randomSeed, nameCount)];

        //    person.Name = name;
        //}

        public void GenerateGender(Character character) //, List<int> randomSeed, Data data)
        {
            //int genderCount = genderList.Count();

            string genderListString = Application.Context.GetString(Resource.String.GenderList);

            List<string> genderList = genderListString.Split(',').ToList<string>();  //data.Names.UniqueGenders;

            if (genderList.Contains(""))
            {
                genderList.Remove("");
            }

            int genderCount = genderList.Count();

            character.Gender = genderList[DataManagement.GameMaster.RandomNums[genderCount]];  //rand.GetRandomInt(randomSeed, genderCount)];
        }

        public void GenerateSpecial(Character character) //, List<int> randomSeed, Data data)
        {
            //THESE ARE LIKELY TO SCREW THIS UP. May need to put integers in a table or something.
            int specialBase = int.Parse(Application.Context.GetString(Resource.Integer.SpecialBase));
            int specialRollVariance = int.Parse(Application.Context.GetString(Resource.Integer.SpecialRollVariance));
            
            character.Agility       =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];
            character.Endurance     =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];
            character.Intelligence  =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];
            character.Strength      =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];
            character.Vitality      =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];
            character.Perception    =   specialBase + DataManagement.GameMaster.RandomNums[specialRollVariance];

            //character.Agility = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
            //character.Endurance = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
            //character.Intelligence = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
            //character.Strength = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
            //character.Vitality = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
            //character.Perception = specialBase + rand.GetRandomInt(randomSeed, specialRollVariance);
            //rand.RefreshRandomSeed(randomSeed, 1);
        }

        public void GenerateStatRoll(Character character) //, List<int> randomSeed, Data data)
        {
            int statRollVariance = int.Parse(Application.Context.GetString(Resource.Integer.StatRollVariance)); //int.Parse(data.GetData(data.GenerationNumbers, "StatRollVariance"));
                        
            if (character.StatRoll == null)
            {
                character.StatRoll = new List<int>();
            }

            string statsListString = Application.Context.GetString(Resource.String.StatsList);

            List<string> statsList = statsListString.Split(',').ToList<string>();

            for (int i = 0; i < statsList.Count(); i++)
            {
                if (character.StatRoll.Count <= i)
                {
                    character.StatRoll.Add(0);
                }

                character.StatRoll[i] = DataManagement.GameMaster.RandomNums[statRollVariance * 2] - statRollVariance; //rand.GetRandomInt(randomSeed, statRollVariance * 2) - statRollVariance;
                //rand.RefreshRandomSeed(randomSeed, 1);
            }
        }

        public void GenerateClass(Character person, string className)
        {

        }
    }
}