using Android.Content;
using Android.Database.Sqlite;

namespace AndroidRPG.DataManagement
{
    class DataManager : SQLiteOpenHelper
    {
        // specifies the database name
        private const string DatabaseName = "gameDatabaseName";
        //specifies the database version (increment this number each time you make database related changes)
        private const int DatabaseVersion = 1;

        private const string TABLE_ABILITY = "ability";
        private const string TABLE_CHARACTER = "character";
        private const string TABLE_DIVISION = "division";

        public DataManager(Context context) : base(context, DatabaseName, null, DatabaseVersion){}

        public override void OnCreate(SQLiteDatabase db)        //When changing these, also change the respective class
        {
            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS Ability (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name            TEXT NOT NULL UNIQUE,
                            Existence       BOOLEAN NOT NULL,
                            ImageResourceId INTEGER NOT NULL,
 
                            RefName         TEXT NOT NULL UNIQUE,
                            DamageEffect    TEXT NOT NULL,
                            StatusEffect    TEXT NOT NULL,
                            Level           INTEGER NOT NULL,
                            CostBase        INTEGER NOT NULL,
                            CostIncrease    INTEGER NOT NULL,
                            PowerBase       INTEGER NOT NULL,
                            PowerIncrease   INTEGER NOT NULL,
                            MaxLevel        INTEGER NOT NULL    )");

            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS Character       (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name            TEXT NOT NULL,
                            Existence       BOOLEAN NOT NULL,
                            ImageResourceId INTEGER NOT NULL,

                            Gender          TEXT NOT NULL,
                            Health          INTEGER NOT NULL,
                            Mana            INTEGER NOT NULL,
                            Attack          INTEGER NOT NULL,
                            Magic           INTEGER NOT NULL,
                            Defence         INTEGER NOT NULL,
                            Speed           INTEGER NOT NULL,
                            Vitality        INTEGER NOT NULL,
                            Perception      INTEGER NOT NULL,
                            Strength        INTEGER NOT NULL,
                            Intelligence    INTEGER NOT NULL,
                            Endurance       INTEGER NOT NULL,
                            Agility         INTEGER NOT NULL,
                            AbilityListString   TEXT NOT NULL       )");

            db.ExecSQL(@"
                        CREATE TABLE IF NOT EXISTS Division       (
                            Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name            TEXT NOT NULL,
                            Existence       BOOLEAN NOT NULL,
                            ImageResourceId INTEGER NOT NULL,

                            Weapon          TEXT NOT NULL,
                            Agility         INTEGER NOT NULL,
                            Endurance       INTEGER NOT NULL,
                            Intelligence    INTEGER NOT NULL,
                            Strength        INTEGER NOT NULL,
                            Vitality        INTEGER NOT NULL,
                            Perception      INTEGER NOT NULL,
                            Sword           INTEGER NOT NULL,
                            Axe             INTEGER NOT NULL,
                            Staff           INTEGER NOT NULL,
                            Bow             INTEGER NOT NULL,

                            AbilityListString   TEXT NOT NULL       )");

            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS NAME_ABILITY ON ABILITY (NAME)");
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS NAME_CHARACTER ON CHARACTER (NAME)");
            db.ExecSQL(@"CREATE INDEX IF NOT EXISTS NAME_DIVISION ON DIVISION (NAME)");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            //db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_ABILITY);
            //db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_CHARACTER);
            //db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_DIVISION);

            OnCreate(db);
        }
    }
}