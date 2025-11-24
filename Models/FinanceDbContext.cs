using System;
using System.Data.SQLite;
using System.IO;

namespace PersonalFinanceTracker.Models
{
    // Represents income entry
    public class Income
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaySchedule { get; set; } // "Fortnightly" or "Monthly"
        public DateTime DateAdded { get; set; }
        
        // Calculated property for monthly income
        public decimal MonthlyAmount => PaySchedule == "Fortnightly" 
            ? (Amount * 26) / 12 
            : Amount;
    }

    // Represents fixed monthly bills
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string DueDate { get; set; }
        public DateTime DateAdded { get; set; }
    }

    // Represents budget allocations (Credit Card, Savings, etc.)
    public class BudgetAllocation
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal Percentage { get; set; }
        public decimal AllocatedAmount { get; set; }
        public DateTime DateCreated { get; set; }
    }

    // Database context class - handles all SQLite operations
    public class FinanceDbContext
    {
        private readonly string _connectionString;
        private readonly string _dbPath;

        public FinanceDbContext()
        {
            // Store database in AppData folder
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appData, "PersonalFinanceTracker");
            
            // Create folder if it doesn't exist
            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);
            
            _dbPath = Path.Combine(appFolder, "FinanceTracker.db");
            _connectionString = $"Data Source={_dbPath};Version=3;";
            
            InitializeDatabase();
        }

        // Create database tables if they don't exist
        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Create Income table
                string createIncomeTable = @"
                    CREATE TABLE IF NOT EXISTS Income (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Amount REAL NOT NULL,
                        PaySchedule TEXT NOT NULL,
                        DateAdded TEXT NOT NULL
                    )";

                // Create Bills table
                string createBillsTable = @"
                    CREATE TABLE IF NOT EXISTS Bills (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Amount REAL NOT NULL,
                        DueDate TEXT,
                        DateAdded TEXT NOT NULL
                    )";

                // Create BudgetAllocations table
                string createAllocationsTable = @"
                    CREATE TABLE IF NOT EXISTS BudgetAllocations (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CategoryName TEXT NOT NULL,
                        Percentage REAL NOT NULL,
                        AllocatedAmount REAL NOT NULL,
                        DateCreated TEXT NOT NULL
                    )";

                using (var command = new SQLiteCommand(createIncomeTable, connection))
                    command.ExecuteNonQuery();

                using (var command = new SQLiteCommand(createBillsTable, connection))
                    command.ExecuteNonQuery();

                using (var command = new SQLiteCommand(createAllocationsTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        // Get SQLite connection
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
