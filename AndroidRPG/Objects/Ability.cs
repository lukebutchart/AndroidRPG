using System;

namespace AndroidRPG.Objects
{
    class Ability : MasterClass
    {
        public string RefName { get; set; }
        public string DamageEffect { get; set; }
        public string StatusEffect { get; set; }
        public int Level { get; set; }
        public int CostBase { get; set; }
        public int CostIncrease { get; set; }
        public int PowerBase { get; set; }
        public int PowerIncrease { get; set; }
        public int MaxLevel { get; set; }

        public Ability(){}

        public Ability(string name, string damageEffect, string statusEffect, int costBase, int costIncrease, int powerBase, int powerIncrease, bool existence = true, int maxLevel = 5)
        {
            this.Name = name;
            this.DamageEffect = damageEffect;
            this.StatusEffect = statusEffect;
            this.CostBase = costBase;
            this.PowerBase = powerBase;
            this.PowerIncrease = powerIncrease;
            this.Existence = existence;
            this.MaxLevel = maxLevel;
        }


        ///// <summary>
        ///// Gets a new ability using xml data. OUTDATED
        ///// </summary>
        ///// <param name="abilityName">The name of the ability to get.</param>
        ///// <param name="abilityLevel">The level of the ability to get.</param>
        ///// <returns>The ability object.</returns>
        //public Ability GetNewAbilityXML(string abilityName, int abilityLevel)
        //{
        //    XMLClass abilitiesXML = new XMLClass();
        //    Ability ability = new Ability();

        //    ability = abilitiesXML.XMLReadAbilitiesReturn(abilityName, abilityLevel);

        //    if (ability.Name != null && ability.DamageEffect != null && ability.Level != 0)
        //    {
        //        ability.RefName = ability.Level.ToString() + ability.Name;
        //        ability.Existence = true;
        //    }
        //    else
        //    {
        //        ability.Existence = false;
        //    }

        //    return ability;
        //}

        //public Ability GetNewAbility(string abilityName, int abilityLevel, Data data)
        //{
        //    CSVClass abilitiesXML = new CSVClass();
        //    Ability ability = new Ability();

        //    string refName = abilityLevel.ToString() + abilityName;

        //    try
        //    {
        //        int abilityIndex = data.GetIndex(data.Abilities, "RefName", refName);

        //        ability.ID = int.Parse(data.GetData(data.Abilities, "ID", abilityIndex));
        //        ability.RefName = data.GetData(data.Abilities, "RefName", abilityIndex);
        //        ability.Name = data.GetData(data.Abilities, "Name", abilityIndex);
        //        ability.DamageEffect = data.GetData(data.Abilities, "DamageEffect", abilityIndex);
        //        ability.StatusEffect = data.GetData(data.Abilities, "StatusEffect", abilityIndex);
        //        ability.Level = int.Parse(data.GetData(data.Abilities, "Level", abilityIndex));
        //        ability.CostBase = int.Parse(data.GetData(data.Abilities, "Cost", abilityIndex));
        //        ability.PowerBase = int.Parse(data.GetData(data.Abilities, "Power", abilityIndex));

        //        ability.Existence = true;

        //        return ability;
        //    }
        //    catch (Exception)
        //    {
        //        ability.Existence = false;
        //        return null;
        //    }
        //}

        public void ReportAbility(Ability ability)
        {
            if (ability.Existence)
            {
                //Console.WriteLine("ID    : {0}", ability.ID);
                //Console.WriteLine("RefNam: {0}", ability.RefName);

                Console.WriteLine("Name  : {0}", ability.Name);
                Console.WriteLine("Level : {0}", ability.Level);
                Console.WriteLine("DamEff: {0}", ability.DamageEffect);
                Console.WriteLine("StaEff: {0}", ability.StatusEffect);
                Console.WriteLine("Cost  : {0}", ability.CostBase);
                Console.WriteLine("Power : {0}", ability.PowerBase);
            }
            else
            {
                Console.WriteLine("Ability does not exist.");
            }
        }


    }
}