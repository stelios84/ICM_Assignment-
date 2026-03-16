using Microsoft.Data.Sqlite;
 

namespace Infrastructure.DB
{
    public class DatabaseSchemaService
    {
        public DatabaseSchemaService()
        {
            
            
        }

        public void DeleteIfExists(string filename)
        {
            if(System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
        }
        public void CreateDatabaseSchemaIfNotExists(string connectionstring)
        {
            CreateSingleTable(connectionstring);
            //CreateETH(connectionstring);
            //CreateBTC(connectionstring);
            //CreateBTCTest3(connectionstring);
            //CreateDash(connectionstring);
            //CreateLTC(connectionstring);

        }
        void CreateSingleTable(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"
    CREATE TABLE IF NOT EXISTS Chains(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    sourceProvider Text,
    name TEXT NOT NULL,
    JsonApi TEXT,
    CreatedAt TEXT
);", c);


                cmd.ExecuteNonQuery();
                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS Chains_CreatetAt ON Chains (CreatedAt)";
                indexcmd.ExecuteNonQuery();

                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS Chains_sourceProvider ON Chains (sourceProvider)";
                indexcmd.ExecuteNonQuery();

                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS Chains_name ON Chains (Name)";
                indexcmd.ExecuteNonQuery();

            }
        }

        void CreateETH(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"
    CREATE TABLE IF NOT EXISTS BS_chain_ETH(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    height INTEGER NOT NULL,
    hash TEXT NOT NULL,
    time TEXT NOT NULL,
    latest_url TEXT NOT NULL,
    previous_hash TEXT,
    previous_url TEXT,
    peer_count INTEGER,
    unconfirmed_count INTEGER,
    high_gas_price INTEGER,
    medium_gas_price INTEGER,
    low_gas_price INTEGER,
    high_priority_fee INTEGER,
    medium_priority_fee INTEGER,
    low_priority_fee INTEGER,
    base_fee INTEGER,
    last_fork_height INTEGER,
    last_fork_hash TEXT,
    CreatedAt TEXT,
JsonApi TEXT
);", c);


                cmd.ExecuteNonQuery();
                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS BS_chain_ETH_CreatetAt ON BS_chain_ETH (CreatedAt)";
                indexcmd.ExecuteNonQuery();
            }
        }

        void CreateDash(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"CREATE TABLE IF NOT EXISTS BS_chain_DASH(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    height INTEGER NOT NULL,
    hash TEXT NOT NULL,
    time TEXT NOT NULL,
    latest_url TEXT NOT NULL,
    previous_hash TEXT,
    previous_url TEXT,
    peer_count INTEGER,
    unconfirmed_count INTEGER,
    high_fee_per_kb INTEGER,
    medium_fee_per_kb INTEGER,
    low_fee_per_kb INTEGER,
    last_fork_height INTEGER,
    last_fork_hash TEXT,
CreatedAt TEXT,
JsonApi TEXT
);", c);


                cmd.ExecuteNonQuery();

                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS BS_chain_DASH_CreatetAt ON BS_chain_ETH (CreatedAt)";
                indexcmd.ExecuteNonQuery();
            }
        }

        void CreateBTC(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"CREATE TABLE IF NOT EXISTS BS_chain_BTC (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    height INTEGER NOT NULL,
    hash TEXT NOT NULL,
    time TEXT NOT NULL,
    latest_url TEXT NOT NULL,
    previous_hash TEXT,
    previous_url TEXT,
    peer_count INTEGER,
    unconfirmed_count INTEGER,
    high_fee_per_kb INTEGER,
    medium_fee_per_kb INTEGER,
    low_fee_per_kb INTEGER,
    last_fork_height INTEGER,
    last_fork_hash TEXT,
    CreatedAt TEXT,
JsonApi TEXT
);", c);


                cmd.ExecuteNonQuery();
                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS BS_chain_BTC_CreatetAt ON BS_chain_ETH (CreatedAt)";
                indexcmd.ExecuteNonQuery();
            }
        }

        void CreateLTC(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"
CREATE TABLE IF NOT EXISTS BS_chain_LTC (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    height INTEGER NOT NULL,
    hash TEXT NOT NULL,
    time TEXT NOT NULL,
    latest_url TEXT NOT NULL,
    previous_hash TEXT,
    previous_url TEXT,
    peer_count INTEGER,
    unconfirmed_count INTEGER,
    high_fee_per_kb INTEGER,
    medium_fee_per_kb INTEGER,
    low_fee_per_kb INTEGER,
    last_fork_height INTEGER,
    last_fork_hash TEXT,
CreatedAt TEXT,
JsonApi TEXT
);", c);


                cmd.ExecuteNonQuery();

                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS BS_chain_LTC_CreatetAt ON BS_chain_ETH (CreatedAt)";
                indexcmd.ExecuteNonQuery();
            }
        }

        void CreateBTCTest3(string cs)
        {
            using (var c = new SqliteConnection(cs))
            {
                c.Open();
                var cmd = new Microsoft.Data.Sqlite.SqliteCommand(@"
CREATE TABLE IF NOT EXISTS BS_chain_BTCTEST3 (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    height INTEGER NOT NULL,
    hash TEXT NOT NULL,
    time TEXT NOT NULL,
    latest_url TEXT NOT NULL,
    previous_hash TEXT NOT NULL,
    previous_url TEXT NOT NULL,
    peer_count INTEGER,
    unconfirmed_count INTEGER,
    high_fee_per_kb INTEGER,
    medium_fee_per_kb INTEGER,
    low_fee_per_kb INTEGER,
    last_fork_height INTEGER,
    last_fork_hash TEXT,
CreatedAt TEXT,
JsonApi TEXT
);", c);


                cmd.ExecuteNonQuery();

                var indexcmd = c.CreateCommand();
                indexcmd.CommandText = "CREATE INDEX IF NOT EXISTS BS_chain_BTCTEST3_CreatetAt ON BS_chain_ETH (CreatedAt)";
                indexcmd.ExecuteNonQuery();
            }
        }
    }

}
