using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using SQLite;
using System.Threading;

namespace AndroidRPG.DataManagement
{
    class DatabaseUpdates
    {
        private DataManager _dataMan;

        public void SetContext(Context context)
        {
            if (context != null)
            {
                _dataMan = new DataManager(context);
            }
        }

        /// <summary>
        /// Adds a given Ability to database.
        /// </summary>
        /// <param name="addAbility"></param>
        /// <returns></returns>
        public long AddAbility(Objects.Ability addAbility)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Insert(addAbility);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);

                    try
                    {
                        return db.Insert(addAbility);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Trying to add a non-unique name: '{0}'.", addAbility);
                        return 0;
                    }
                }
            }
        }

        public long AddCharacter(Objects.Character addCharacter)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Insert(addCharacter);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);

                    try
                    {
                        return db.Insert(addCharacter);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Trying to add a non-unique name: '{0}'.", addCharacter);
                        return 0;
                    }
                }
            }
        }
        public long AddDivision(Objects.Division addDivision)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Insert(addDivision);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);

                    try
                    {
                        return db.Insert(addDivision);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Trying to add a non-unique name: '{0}'.", addDivision);
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a given collectable from a database.
        /// </summary>
        /// <param name="deleteColl">The collectable to delete</param>
        /// <returns></returns>
        public long DeleteAbility(Objects.Ability deleteColl)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Delete(deleteColl);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return DeleteAbility(deleteColl);
                }
            }
        }

        public long DeleteCharacter(Objects.Character deleteCharacter)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Delete(deleteCharacter);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return DeleteCharacter(deleteCharacter);
                }
            }
        }

        public long DeleteDivision(Objects.Division deleteDivision)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Delete(deleteDivision);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return DeleteDivision(deleteDivision);
                }
            }
        }

        /// <summary>
        /// Updates a given collectable in a database.
        /// </summary>
        /// <param name="updColl">The collectable to update (still unsure how)</param>
        /// <returns></returns>
        public long UpdateAbility(Objects.Ability updColl)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Update(updColl);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return UpdateAbility(updColl);
                }
            }
        }

        public long UpdateCharacter(Objects.Character updPlay)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Update(updPlay);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return UpdateCharacter(updPlay);
                }
            }
        }

        public long UpdateDivision(Objects.Division updDivision)
        {
            using (var db = new SQLiteConnection(_dataMan.WritableDatabase.Path))
            {
                try
                {
                    return db.Update(updDivision);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return UpdateDivision(updDivision);
                }
            }
        }

        ////Get the total number of collectables with a specific cost
        //public int GetTotalAbilitysCount(int cost)
        //{
        //    using (var db = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
        //    {
        //        try
        //        {
        //            if (!string.IsNullOrEmpty(cost.ToString()))
        //            {
        //                int count = db.Table<Objects.Ability>().Count(c => c.CostBase == cost);
        //                return count;
        //            }
        //            return 0;
        //        }
        //        catch (Exception)
        //        {
        //            Thread.Sleep(500);
        //            return GetTotalAbilitysCount(cost);
        //        }
        //    }
        //}

        //retrieve a specific user by querying against their  name
        public Objects.Ability GetAbility(string name)
        {
            name = name.Replace(" ", "");

            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Ability>().FirstOrDefault(u => u.Name == name);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetAbility(name);
                }
            }
        }

        public Objects.Character GetCharacter(string name)
        {
            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Character>().FirstOrDefault(u => u.Name == name);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetCharacter(name);
                }
            }
        }

        public Objects.Division GetDivision(string name)
        {
            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Division>().FirstOrDefault(u => u.Name == name);
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetDivision(name);
                }
            }
        }

        //public List<Objects.Ability> GetDivisionLikes(string name)
        //{
        //    Objects.Division friend = GetDivision(name);
        //    List<string> likesList = friend.Likes.Split(',').ToList<string>();
        //    List<Objects.Ability> collList = new List<Objects.Ability>();

        //    foreach (string like in likesList)
        //    {
        //        collList.Add(GetAbility(like));
        //    }

        //    return collList;
        //}

        //retrieve a list of all Abilitys
        public List<Objects.Ability> GetAllAbilitys()
        {
            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Ability>().ToList();
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetAllAbilitys();
                }
            }
        }

        public List<Objects.Character> GetAllCharacters()
        {
            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Character>().ToList();
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetAllCharacters();
                }
            }
        }

        public List<Objects.Division> GetAllDivisions()
        {
            using (var database = new SQLiteConnection(_dataMan.ReadableDatabase.Path))
            {
                try
                {
                    return database.Table<Objects.Division>().ToList();
                }
                catch (Exception)
                {
                    //exception handling code to go here
                    Thread.Sleep(500);
                    return GetAllDivisions();
                }
            }
        }
    }
}