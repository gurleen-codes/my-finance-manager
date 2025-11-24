using System;
using System.Drawing;
using System.Windows.Forms;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker
{
    public partial class MainForm : Form
    {
        private readonly FinanceRepository _repository;

        public MainForm()
        {
            InitializeComponent();
            _repository = new FinanceRepository();
            
            // Load existing data on startup
            LoadAllData();
        }

        #region Data Loading Methods

        // Load all data from database into UI
        private void LoadAllData()
        {
            LoadIncomeData();
            LoadBillsData();
            LoadBudgetSummary();
        }

        // Load income entries into DataGridView
        private void LoadIncomeData()
        {
            var incomes = _repository.GetAllIncome();
            dgvIncome.DataSource = null;
            dgvIncome.DataSource = incomes;
            
            // Format columns
            if (dgvIncome.Columns.Count > 0)
            {
                dgvIncome.Columns["Id"].Visible = false;
                dgvIncome.Columns["Amount"].DefaultCellStyle.Format = "C2";
                dgvIncome.Columns["MonthlyAmount"].DefaultCellStyle.Format = "C2";
                dgvIncome.Columns["MonthlyAmount"].HeaderText = "Monthly Equivalent";
                dgvIncome.Columns["DateAdded"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        // Load bills into DataGridView
        private void LoadBillsData()
        {
            var bills = _repository.GetAllBills();
            dgvBills.DataSource = null;
            dgvBills.DataSource = bills;
            
            // Format columns
            if (dgvBills.Columns.Count > 0)
            {
                dgvBills.Columns["Id"].Visible = false;
                dgvBills.Columns["Amount"].DefaultCellStyle.Format = "C2";
                dgvBills.Columns["DateAdded"].Visible = false;
            }
            
            // Update total bills display
            UpdateTotalBills();
        }

        // Update the total bills label
        private void UpdateTotalBills()
        {
            decimal total = _repository.GetTotalMonthlyBills();
            lblTotalBills.Text = $"Total Monthly Bills: {total:C2}";
        }

        // Load and display budget summary
        private void LoadBudgetSummary()
        {
            try
            {
                var latestIncome = _repository.GetLatestIncome();
                if (latestIncome == null)
                {
                    txtSummary.Text = "No income data available. Please add your income first.";
                    return;
                }

                var bills = _repository.GetAllBills();
                var allocations = _repository.GetAllAllocations();

                decimal monthlyIncome = latestIncome.MonthlyAmount;
                decimal totalBills = _repository.GetTotalMonthlyBills();
                decimal remainingAfterBills = monthlyIncome - totalBills;

                // Build summary text
                var summary = new System.Text.StringBuilder();
                summary.AppendLine("═══════════════════════════════════════════════════════════");
                summary.AppendLine("                  MONTHLY BUDGET SUMMARY");
                summary.AppendLine("═══════════════════════════════════════════════════════════");
                summary.AppendLine();
                summary.AppendLine($"💰 Total Monthly Income:        {monthlyIncome:C2}");
                summary.AppendLine($"   Pay Schedule:                {latestIncome.PaySchedule}");
                if (latestIncome.PaySchedule == "Fortnightly")
                {
                    summary.AppendLine($"   Per Paycheck:                {latestIncome.Amount:C2}");
                }
                summary.AppendLine();
                summary.AppendLine("───────────────────────────────────────────────────────────");
                summary.AppendLine("📋 FIXED MONTHLY BILLS");
                summary.AppendLine("───────────────────────────────────────────────────────────");
                
                foreach (var bill in bills)
                {
                    summary.AppendLine($"   {bill.Name,-30} {bill.Amount,10:C2}");
                }
                
                summary.AppendLine("                                   ─────────────");
                summary.AppendLine($"   {"Total Bills:",-30} {totalBills,10:C2}");
                summary.AppendLine();
                summary.AppendLine("───────────────────────────────────────────────────────────");
                summary.AppendLine($"💵 Remaining After Bills:       {remainingAfterBills:C2}");
                summary.AppendLine("───────────────────────────────────────────────────────────");
                summary.AppendLine();

                if (allocations.Count > 0)
                {
                    summary.AppendLine("📊 BUDGET ALLOCATIONS");
                    summary.AppendLine("───────────────────────────────────────────────────────────");
                    
                    foreach (var alloc in allocations)
                    {
                        summary.AppendLine($"   {alloc.CategoryName,-30} {alloc.AllocatedAmount,10:C2}  ({alloc.Percentage}%)");
                    }
                    
                    summary.AppendLine();
                }

                summary.AppendLine("═══════════════════════════════════════════════════════════");
                
                // Check if budget is balanced
                if (remainingAfterBills < 0)
                {
                    summary.AppendLine();
                    summary.AppendLine("⚠️  WARNING: Your bills exceed your income!");
                }
                else if (allocations.Count > 0)
                {
                    decimal totalAllocated = 0;
                    foreach (var alloc in allocations)
                        totalAllocated += alloc.AllocatedAmount;
                    
                    if (Math.Abs(totalAllocated - remainingAfterBills) < 0.01m)
                    {
                        summary.AppendLine();
                        summary.AppendLine("✓ Budget is balanced! All income is allocated.");
                    }
                }

                txtSummary.Text = summary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading summary: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Income Tab Events

        // Update monthly equivalent display when income changes
        private void txtIncomeAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateMonthlyEquivalent();
        }

        // Update monthly equivalent when pay schedule changes
        private void rbPaySchedule_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMonthlyEquivalent();
        }

        // Calculate and display monthly equivalent income
        private void UpdateMonthlyEquivalent()
        {
            if (decimal.TryParse(txtIncomeAmount.Text, out decimal amount) && amount > 0)
            {
                string schedule = rbFortnightly.Checked ? "Fortnightly" : "Monthly";
                decimal monthlyAmount = schedule == "Fortnightly" 
                    ? (amount * 26) / 12 
                    : amount;

                lblMonthlyEquiv.Text = $"Monthly Equivalent: {monthlyAmount:C2}";
                lblMonthlyEquiv.ForeColor = Color.FromArgb(102, 126, 234);
            }
            else
            {
                lblMonthlyEquiv.Text = "Monthly Equivalent: $0.00";
                lblMonthlyEquiv.ForeColor = Color.Gray;
            }
        }

        // Save income to database (CREATE operation)
        private void btnSaveIncome_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtIncomeAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid income amount.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var income = new Income
                {
                    Amount = amount,
                    PaySchedule = rbFortnightly.Checked ? "Fortnightly" : "Monthly",
                    DateAdded = DateTime.Now
                };

                int id = _repository.AddIncome(income);
                
                if (id > 0)
                {
                    MessageBox.Show("Income saved successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear input
                    txtIncomeAmount.Clear();
                    
                    // Reload data
                    LoadIncomeData();
                    LoadBudgetSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving income: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete selected income (DELETE operation)
        private void btnDeleteIncome_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIncome.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an income entry to delete.", "No Selection", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this income entry?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedIncome = (Income)dgvIncome.SelectedRows[0].DataBoundItem;
                    
                    if (_repository.DeleteIncome(selectedIncome.Id))
                    {
                        MessageBox.Show("Income deleted successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        LoadIncomeData();
                        LoadBudgetSummary();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting income: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Bills Tab Events

        // Add new bill (CREATE operation)
        private void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBillName.Text))
                {
                    MessageBox.Show("Please enter a bill name.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtBillAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid bill amount.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var bill = new Bill
                {
                    Name = txtBillName.Text.Trim(),
                    Amount = amount,
                    DueDate = txtBillDue.Text.Trim(),
                    DateAdded = DateTime.Now
                };

                int id = _repository.AddBill(bill);
                
                if (id > 0)
                {
                    MessageBox.Show("Bill added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear inputs
                    txtBillName.Clear();
                    txtBillAmount.Clear();
                    txtBillDue.Text = "End of month";
                    
                    // Reload data
                    LoadBillsData();
                    LoadBudgetSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding bill: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete selected bill (DELETE operation)
        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBills.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a bill to delete.", "No Selection", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this bill?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedBill = (Bill)dgvBills.SelectedRows[0].DataBoundItem;
                    
                    if (_repository.DeleteBill(selectedBill.Id))
                    {
                        MessageBox.Show("Bill deleted successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        LoadBillsData();
                        LoadBudgetSummary();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting bill: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Budget Tab Events

        // Validate percentage totals in real-time
        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            ValidatePercentages();
        }

        // Check if percentages total 100%
        private void ValidatePercentages()
        {
            if (decimal.TryParse(txtCreditCardPercent.Text, out decimal credit) &&
                decimal.TryParse(txtSavingsPercent.Text, out decimal savings))
            {
                decimal total = credit + savings;
                
                if (Math.Abs(total - 100) < 0.01m)
                {
                    lblPercentTotal.Text = "✓ Total: 100%";
                    lblPercentTotal.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    lblPercentTotal.Text = $"⚠ Current Total: {total}% (should be 100%)";
                    lblPercentTotal.ForeColor = Color.FromArgb(231, 76, 60);
                }
            }
        }

        // Calculate budget allocations
        private void btnCalculateBudget_Click(object sender, EventArgs e)
        {
            try
            {
                // Get latest income
                var latestIncome = _repository.GetLatestIncome();
                if (latestIncome == null)
                {
                    MessageBox.Show("Please add your income first before calculating budget.", 
                        "No Income Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = tabIncome;
                    return;
                }

                // Validate percentages
                if (!decimal.TryParse(txtCreditCardPercent.Text, out decimal creditPercent) ||
                    !decimal.TryParse(txtSavingsPercent.Text, out decimal savingsPercent))
                {
                    MessageBox.Show("Please enter valid percentages.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalPercent = creditPercent + savingsPercent;
                if (Math.Abs(totalPercent - 100) > 0.01m)
                {
                    MessageBox.Show($"Percentages must total 100%. Current total: {totalPercent}%", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate amounts
                decimal monthlyIncome = latestIncome.MonthlyAmount;
                decimal totalBills = _repository.GetTotalMonthlyBills();
                decimal remainingAfterBills = monthlyIncome - totalBills;

                if (remainingAfterBills <= 0)
                {
                    MessageBox.Show("Your bills exceed your income! Please review your bills.", 
                        "Budget Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Clear previous allocations
                _repository.ClearAllocations();

                // Create new allocations
                var creditAllocation = new BudgetAllocation
                {
                    CategoryName = "💳 Credit Card Budget",
                    Percentage = creditPercent,
                    AllocatedAmount = (creditPercent / 100) * remainingAfterBills,
                    DateCreated = DateTime.Now
                };

                var savingsAllocation = new BudgetAllocation
                {
                    CategoryName = "💎 Savings & Investment",
                    Percentage = savingsPercent,
                    AllocatedAmount = (savingsPercent / 100) * remainingAfterBills,
                    DateCreated = DateTime.Now
                };

                _repository.AddBudgetAllocation(creditAllocation);
                _repository.AddBudgetAllocation(savingsAllocation);

                // Display results
                var allocations = _repository.GetAllAllocations();
                dgvAllocations.DataSource = null;
                dgvAllocations.DataSource = allocations;

                // Format columns
                if (dgvAllocations.Columns.Count > 0)
                {
                    dgvAllocations.Columns["Id"].Visible = false;
                    dgvAllocations.Columns["DateCreated"].Visible = false;
                    dgvAllocations.Columns["AllocatedAmount"].DefaultCellStyle.Format = "C2";
                    dgvAllocations.Columns["Percentage"].DefaultCellStyle.Format = "0.00'%'";
                    dgvAllocations.Columns["CategoryName"].HeaderText = "Category";
                    dgvAllocations.Columns["AllocatedAmount"].HeaderText = "Amount";
                }

                MessageBox.Show($"Budget calculated successfully!\n\nRemaining after bills: {remainingAfterBills:C2}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh summary
                LoadBudgetSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating budget: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
