using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Data
{
    // Repository pattern - handles all database CRUD operations
    public class FinanceRepository
    {
        private readonly FinanceDbContext _context;

        public FinanceRepository()
        {
            _context = new FinanceDbContext();
        }

        #region Income CRUD Operations

        // CREATE - Add new income entry
        public int AddIncome(Income income)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Income (Amount, PaySchedule, DateAdded) 
                               VALUES (@Amount, @PaySchedule, @DateAdded);
                               SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", income.Amount);
                    command.Parameters.AddWithValue("@PaySchedule", income.PaySchedule);
                    command.Parameters.AddWithValue("@DateAdded", income.DateAdded.ToString("yyyy-MM-dd HH:mm:ss"));

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // READ - Get all income entries
        public List<Income> GetAllIncome()
        {
            var incomes = new List<Income>();
            
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "SELECT Id, Amount, PaySchedule, DateAdded FROM Income ORDER BY DateAdded DESC";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        incomes.Add(new Income
                        {
                            Id = reader.GetInt32(0),
                            Amount = reader.GetDecimal(1),
                            PaySchedule = reader.GetString(2),
                            DateAdded = DateTime.Parse(reader.GetString(3))
                        });
                    }
                }
            }
            
            return incomes;
        }

        // READ - Get latest income entry
        public Income GetLatestIncome()
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Id, Amount, PaySchedule, DateAdded 
                               FROM Income 
                               ORDER BY DateAdded DESC 
                               LIMIT 1";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Income
                        {
                            Id = reader.GetInt32(0),
                            Amount = reader.GetDecimal(1),
                            PaySchedule = reader.GetString(2),
                            DateAdded = DateTime.Parse(reader.GetString(3))
                        };
                    }
                }
            }
            return null;
        }

        // UPDATE - Modify existing income
        public bool UpdateIncome(Income income)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Income 
                               SET Amount = @Amount, 
                                   PaySchedule = @PaySchedule 
                               WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Amount", income.Amount);
                    command.Parameters.AddWithValue("@PaySchedule", income.PaySchedule);
                    command.Parameters.AddWithValue("@Id", income.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // DELETE - Remove income entry
        public bool DeleteIncome(int id)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Income WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        #endregion

        #region Bills CRUD Operations

        // CREATE - Add new bill
        public int AddBill(Bill bill)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Bills (Name, Amount, DueDate, DateAdded) 
                               VALUES (@Name, @Amount, @DueDate, @DateAdded);
                               SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", bill.Name);
                    command.Parameters.AddWithValue("@Amount", bill.Amount);
                    command.Parameters.AddWithValue("@DueDate", bill.DueDate ?? "");
                    command.Parameters.AddWithValue("@DateAdded", bill.DateAdded.ToString("yyyy-MM-dd HH:mm:ss"));

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // READ - Get all bills
        public List<Bill> GetAllBills()
        {
            var bills = new List<Bill>();
            
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "SELECT Id, Name, Amount, DueDate, DateAdded FROM Bills ORDER BY Name";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bills.Add(new Bill
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Amount = reader.GetDecimal(2),
                            DueDate = reader.GetString(3),
                            DateAdded = DateTime.Parse(reader.GetString(4))
                        });
                    }
                }
            }
            
            return bills;
        }

        // UPDATE - Modify existing bill
        public bool UpdateBill(Bill bill)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Bills 
                               SET Name = @Name, 
                                   Amount = @Amount, 
                                   DueDate = @DueDate 
                               WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", bill.Name);
                    command.Parameters.AddWithValue("@Amount", bill.Amount);
                    command.Parameters.AddWithValue("@DueDate", bill.DueDate ?? "");
                    command.Parameters.AddWithValue("@Id", bill.Id);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // DELETE - Remove bill
        public bool DeleteBill(int id)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Bills WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        #endregion

        #region Budget Allocations CRUD Operations

        // CREATE - Add budget allocation
        public int AddBudgetAllocation(BudgetAllocation allocation)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO BudgetAllocations 
                               (CategoryName, Percentage, AllocatedAmount, DateCreated) 
                               VALUES (@CategoryName, @Percentage, @AllocatedAmount, @DateCreated);
                               SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", allocation.CategoryName);
                    command.Parameters.AddWithValue("@Percentage", allocation.Percentage);
                    command.Parameters.AddWithValue("@AllocatedAmount", allocation.AllocatedAmount);
                    command.Parameters.AddWithValue("@DateCreated", allocation.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"));

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // READ - Get all allocations
        public List<BudgetAllocation> GetAllAllocations()
        {
            var allocations = new List<BudgetAllocation>();
            
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = @"SELECT Id, CategoryName, Percentage, AllocatedAmount, DateCreated 
                               FROM BudgetAllocations 
                               ORDER BY DateCreated DESC";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allocations.Add(new BudgetAllocation
                        {
                            Id = reader.GetInt32(0),
                            CategoryName = reader.GetString(1),
                            Percentage = reader.GetDecimal(2),
                            AllocatedAmount = reader.GetDecimal(3),
                            DateCreated = DateTime.Parse(reader.GetString(4))
                        });
                    }
                }
            }
            
            return allocations;
        }

        // DELETE - Clear all allocations (for recalculation)
        public bool ClearAllocations()
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM BudgetAllocations";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        #endregion

        #region Summary Calculations

        // Calculate total monthly bills
        public decimal GetTotalMonthlyBills()
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                string query = "SELECT COALESCE(SUM(Amount), 0) FROM Bills";

                using (var command = new SQLiteCommand(query, connection))
                {
                    return Convert.ToDecimal(command.ExecuteScalar());
                }
            }
        }

        #endregion
    }
}
