using System;
using System.Collections.Generic;

namespace AndroidRPG.Objects
{
    class Division : MasterClass
    {
        public string Weapon { get; set; }
        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Perception { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Staff { get; set; }
        public int Bow { get; set; }        
        public List<Ability> AbilList { get; set; }


        public Division(){}

        public Division(string name, string weapon, int agility, int endurance, int intelligence, int strength, int vitality, int perception, int sword, int axe, int staff, int bow, bool existence = true)
        {
            this.Name = name;
            this.Weapon = weapon;
            this.Agility = agility;
            this.Endurance = endurance;
            this.Intelligence = intelligence;
            this.Strength = strength;
            this.Vitality = vitality;
            this.Perception = perception;
            this.Sword = sword;
            this.Axe = axe;
            this.Staff = staff;
            this.Bow = bow;
            this.Existence = existence;
        }

        //public Division GetNewClass(string className, Data data)
        //{
        //    Division division = new Division();

        //    try
        //    {
        //        int classIndex = data.GetIndex(data.Division, "Name", className);

        //        division.Name = data.GetData(data.Division, "Name", classIndex);
        //        division.Weapon = data.GetData(data.Division, "Weapon", classIndex);
        //        division.Agility = int.Parse(data.GetData(data.Division, "Agility", classIndex));
        //        division.Endurance = int.Parse(data.GetData(data.Division, "Endurance", classIndex));
        //        division.Intelligence = int.Parse(data.GetData(data.Division, "Intelligence", classIndex));
        //        division.Strength = int.Parse(data.GetData(data.Division, "Strength", classIndex));
        //        division.Vitality = int.Parse(data.GetData(data.Division, "Vitality", classIndex));
        //        division.Perception = int.Parse(data.GetData(data.Division, "Perception", classIndex));
        //        division.Sword = int.Parse(data.GetData(data.Division, "Sword", classIndex));
        //        division.Axe = int.Parse(data.GetData(data.Division, "Axe", classIndex));
        //        division.Staff = int.Parse(data.GetData(data.Division, "Staff", classIndex));
        //        division.Bow = int.Parse(data.GetData(data.Division, "Endurance", classIndex));

        //        string abilityName1 = data.GetData(data.Division, "Ability1", classIndex);
        //        string abilityName2 = data.GetData(data.Division, "Ability2", classIndex);
        //        string abilityName3 = data.GetData(data.Division, "Ability3", classIndex);

        //        division.AbilList = new List<Ability>();

        //        foreach (Ability ability in data.Abilities.AbilityList)
        //        {
        //            if ((ability.RefName == abilityName1 || ability.RefName == abilityName2 || ability.RefName == abilityName3) && !division.AbilList.Contains(ability))
        //            {
        //                division.AbilList.Add(ability);
        //            }
        //        }

        //        division.Existence = true;

        //        return division;
        //    }
        //    catch (Exception)
        //    {
        //        division.Existence = false;
        //        return null;
        //    }
        //}

        public void ReportClass(Division @class)
        {
            if (@class.Existence)
            {
                Console.WriteLine("Name  : {0}", @class.Name);
                Console.WriteLine("Weapon: {0}", @class.Weapon);
            }
            else
            {
                Console.WriteLine("Class does not exist.");
            }
        }
    }
}
