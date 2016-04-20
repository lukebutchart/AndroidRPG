using System;
using System.Collections.Generic;

namespace AndroidRPG.DataManagement
{
    class GameMaster
    {
        private static readonly DatabaseUpdates dbUpdates = new DatabaseUpdates();

        public static DatabaseUpdates DBUpdates
        {
            get { return dbUpdates; }
        }

        private static readonly List<Objects.Ability> abilities = new List<Objects.Ability>()
        {
            new Objects.Ability("Icebolt",      "Ice",          "Freeze",   100 ,10  ,6  ,2),
            new Objects.Ability("Fireball",     "Fire",         "Burn",     100 ,10  ,6  ,2),
            new Objects.Ability("Zap",          "Electricity",  "Shock",    80  ,10  ,5  ,1),      //Balance this/these
            new Objects.Ability("Blizzard",     "Ice",          "Freeze",   150 ,20  ,10 ,3),
            new Objects.Ability("Lightning",    "Electricity",  "Shock",    150 ,20  ,10 ,3),
            new Objects.Ability("Chop",         "Physical",     "None",     80  ,10  ,6  ,2),
            new Objects.Ability("Strike",       "Physical",     "None",     100 ,10  ,5  ,1)

            //new Classes.Ability("   ","   ","   ",000,000,000,000),
        };

        private static readonly List<Objects.Division> divisions = new List<Objects.Division>()
        {
            new Objects.Division("Barbarian",   "Axe",      -1,  1, -1,  1,  1, -1, 2, 3, 1, 1),
            new Objects.Division("Mage",        "Staff",     0, -1,  2, -1, -1,  1, 1, 1, 3, 1)

            //new Objects.Division("Barbarian",   "Axe",  -1, 1,-1, 1, 1,-1, 2, 3, 1, 1),
        };

        private static readonly List<Objects.Character> characters = new List<Objects.Character>()
        {
            new Objects.Character("Barry",      "M"),
            new Objects.Character("Gary",       "M"),
            new Objects.Character("John",       "M"),
            new Objects.Character("David",      "M"),
            new Objects.Character("Mary",       "F"),
            new Objects.Character("Stephanie",  "F"),
            new Objects.Character("Hannah",     "F"),
            new Objects.Character("Rachel",     "F")
        };



        //private static readonly List<Collectable> collectables = new List<Collectable>()    // Nothing can contain spaces
        //{                                                                                   // Max Cost: 50 (PlayActivity.CheckForFriend)
        //    new Collectable("Ball"      ,20 ,Resource.Drawable.Ball     ),
        //    new Collectable("Bandana"   ,50 ,Resource.Drawable.Bandana  ),
        //    new Collectable("Book"      ,40                             ),
        //    new Collectable("Carrot"    ,20 ,Resource.Drawable.Carrot   ),
        //    new Collectable("Chocolate" ,25                             ),
        //    new Collectable("Crisps"    ,35                             ),
        //    new Collectable("Egg"       ,10 ,Resource.Drawable.Egg      ),
        //    new Collectable("Grass"     ,15 ,Resource.Drawable.Grass    ),
        //    new Collectable("Hat"       ,40                             ),
        //    new Collectable("IceCube"   ,25 ,Resource.Drawable.IceCube  ),
        //    new Collectable("MusicBox"  ,50                             ),
        //    new Collectable("Paper"     ,10 ,Resource.Drawable.Paper    ),
        //    new Collectable("Penny"     ,50 ,Resource.Drawable.Penny    ),
        //    new Collectable("Pillow"    ,25                             ),
        //    new Collectable("Softner"   ,30                             ),
        //    new Collectable("Treat"     ,20                             ),
        //    new Collectable("Tin"       ,5                              )
        //    //new Collectable("     "   ,10                             )
        //};

        //private static readonly List<Friend> friends = new List<Friend>()
        //{
        //    new Friend("Angus",         "Grass"     +","+   "MusicBox"  +","+   ""          +","+   ""),
        //    new Friend("Big Puppy",     "Ball"      +","+   "Treat"     +","+   "Bandana"   +","+   ""),
        //    new Friend("Bunny",         "Carrot"    +","+   "Softner"   +","+   ""          +","+   ""),
        //    new Friend("Charlie",       "Egg"       +","+   "Chocolate" +","+   "Softner"   +","+   ""),
        //    new Friend("Eric",          "Pillow"    +","+   "IceCube"   +","+   "Ball"      +","+   ""),
        //    new Friend("Little Luke",   "IceCube"   +","+   "Penny"     +","+   "Book"      +","+   ""),
        //    new Friend("Sausage",       "Pillow"    +","+   "Ball"      +","+   "Treat"     +","+   ""),
        //    new Friend("Susee",         "Crisps"    +","+   "Book"      +","+   "Penny"     +","+   ""),
        //    new Friend("Sydney",        "Treat"     +","+   "Hat"       +","+   ""          +","+   "")
        //};

        /// <summary>
        /// The list of all collectables sorted alphabetically.
        /// </summary>
        //public static List<Collectable> Collectables
        //{
        //    get
        //    {
        //        collectables.Sort(delegate (Collectable c1, Collectable c2) { return c1.Name.CompareTo(c2.Name); });
        //        return collectables;
        //    }
        //}

        //public static List<Friend> Friends
        //{
        //    get
        //    {
        //        friends.Sort(delegate (Friend c1, Friend c2) { return c1.Name.CompareTo(c2.Name); });
        //        return friends;
        //    }
        //}

        //private static readonly Player player = new Player();

        //public static Player Player
        //{
        //    get { return player; }
        //}

        private static string PName { get; set; } = "Luke";
        public static string PlayerName
        {
            get { return PName; }
        }

        private static int claimCoin = 0;

        public static int ClaimCoin
        {
            get { return claimCoin; }
            set { claimCoin = value; }
        }


        private static Random rand = new Random();
        private static List<List<int>> randSeeds = new List<List<int>>();

        private static List<int> randSeed = new List<int>();
        
        private static List<List<int>> RandomSeeds
        {
            set { randSeeds = value; }
        }

        public static List<int> RandomNums
        {
            get
            {
                if (randSeeds == null)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        randSeeds.Add(new List<int>());

                        for (int j = 0; j < 100; j++)
                        {
                            randSeeds[i].Add(rand.Next(i));
                        }
                    }
                }

                if (randSeed != null)
                {
                    randSeed.Clear();
                }

                foreach (List<int> list in randSeeds)
                {
                    randSeed.Add(list[0]);
                    list.Add(list[0]);
                    list.RemoveAt(0);
                }

                return randSeed;
            }
        }



        /// <summary>
        /// Returns the writable name of an object. (e.g. obj with name of "IceCube" returns "Ice Cube")
        /// </summary>
        /// <typeparam name="T">Can be a type with a Name and ID property.</typeparam>
        /// <param name="obj">The object to get the name of.</param>
        /// <returns>The given object's writeable name.</returns>
        public string GetWriteName<T>(T obj) where T : Objects.MasterClass
        {
            string name = obj.Name;
            List<int> splitPoints = new List<int>();

            for (int i = 0; i < name.Length; i++) //char letter in obj.Name)
            {
                if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(name[i].ToString()) && i > 0 && name[i - 1] != ' ')
                {
                    splitPoints.Add(i);
                }
            }

            for (int i = splitPoints.Count - 1; i > -1; i--)
            {
                name = name.Insert(splitPoints[i], " ");
            }

            return name;
        }
    }
}