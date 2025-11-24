namespace PersonalFinanceTracker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabIncome = new System.Windows.Forms.TabPage();
            this.tabBills = new System.Windows.Forms.TabPage();
            this.tabBudget = new System.Windows.Forms.TabPage();
            this.tabSummary = new System.Windows.Forms.TabPage();
            
            // Income Tab Controls
            this.grpIncomeInput = new System.Windows.Forms.GroupBox();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.txtIncomeAmount = new System.Windows.Forms.TextBox();
            this.lblPaySchedule = new System.Windows.Forms.Label();
            this.rbFortnightly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.btnSaveIncome = new System.Windows.Forms.Button();
            this.lblMonthlyEquiv = new System.Windows.Forms.Label();
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.btnDeleteIncome = new System.Windows.Forms.Button();
            
            // Bills Tab Controls
            this.grpBillInput = new System.Windows.Forms.GroupBox();
            this.lblBillName = new System.Windows.Forms.Label();
            this.txtBillName = new System.Windows.Forms.TextBox();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.lblBillDue = new System.Windows.Forms.Label();
            this.txtBillDue = new System.Windows.Forms.TextBox();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            this.lblTotalBills = new System.Windows.Forms.Label();
            
            // Budget Tab Controls
            this.grpBudgetCategories = new System.Windows.Forms.GroupBox();
            this.lblCreditCard = new System.Windows.Forms.Label();
            this.txtCreditCardPercent = new System.Windows.Forms.TextBox();
            this.lblSavings = new System.Windows.Forms.Label();
            this.txtSavingsPercent = new System.Windows.Forms.TextBox();
            this.lblPercentTotal = new System.Windows.Forms.Label();
            this.btnCalculateBudget = new System.Windows.Forms.Button();
            this.dgvAllocations = new System.Windows.Forms.DataGridView();
            
            // Summary Tab Controls
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabIncome);
            this.tabControl.Controls.Add(this.tabBills);
            this.tabControl.Controls.Add(this.tabBudget);
            this.tabControl.Controls.Add(this.tabSummary);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 600);
            this.tabControl.TabIndex = 0;
            
            // 
            // tabIncome
            // 
            this.tabIncome.BackColor = System.Drawing.Color.White;
            this.tabIncome.Controls.Add(this.grpIncomeInput);
            this.tabIncome.Controls.Add(this.dgvIncome);
            this.tabIncome.Controls.Add(this.btnDeleteIncome);
            this.tabIncome.Location = new System.Drawing.Point(4, 28);
            this.tabIncome.Name = "tabIncome";
            this.tabIncome.Padding = new System.Windows.Forms.Padding(20);
            this.tabIncome.Size = new System.Drawing.Size(892, 568);
            this.tabIncome.TabIndex = 0;
            this.tabIncome.Text = "💰 Income";
            
            // 
            // grpIncomeInput
            // 
            this.grpIncomeInput.Controls.Add(this.lblIncomeAmount);
            this.grpIncomeInput.Controls.Add(this.txtIncomeAmount);
            this.grpIncomeInput.Controls.Add(this.lblPaySchedule);
            this.grpIncomeInput.Controls.Add(this.rbFortnightly);
            this.grpIncomeInput.Controls.Add(this.rbMonthly);
            this.grpIncomeInput.Controls.Add(this.lblMonthlyEquiv);
            this.grpIncomeInput.Controls.Add(this.btnSaveIncome);
            this.grpIncomeInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpIncomeInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpIncomeInput.Location = new System.Drawing.Point(20, 20);
            this.grpIncomeInput.Name = "grpIncomeInput";
            this.grpIncomeInput.Padding = new System.Windows.Forms.Padding(15);
            this.grpIncomeInput.Size = new System.Drawing.Size(852, 240);
            this.grpIncomeInput.TabIndex = 0;
            this.grpIncomeInput.TabStop = false;
            this.grpIncomeInput.Text = "Income Information";
            
            // 
            // lblIncomeAmount
            // 
            this.lblIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIncomeAmount.Location = new System.Drawing.Point(20, 40);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(200, 25);
            this.lblIncomeAmount.TabIndex = 0;
            this.lblIncomeAmount.Text = "Income per Pay Period:";
            
            // 
            // txtIncomeAmount
            // 
            this.txtIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIncomeAmount.Location = new System.Drawing.Point(20, 68);
            this.txtIncomeAmount.Name = "txtIncomeAmount";
            this.txtIncomeAmount.Size = new System.Drawing.Size(300, 25);
            this.txtIncomeAmount.TabIndex = 1;
            this.txtIncomeAmount.TextChanged += new System.EventHandler(this.txtIncomeAmount_TextChanged);
            
            // 
            // lblPaySchedule
            // 
            this.lblPaySchedule.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaySchedule.Location = new System.Drawing.Point(20, 110);
            this.lblPaySchedule.Name = "lblPaySchedule";
            this.lblPaySchedule.Size = new System.Drawing.Size(200, 25);
            this.lblPaySchedule.TabIndex = 2;
            this.lblPaySchedule.Text = "Pay Schedule:";
            
            // 
            // rbFortnightly
            // 
            this.rbFortnightly.Checked = true;
            this.rbFortnightly.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbFortnightly.Location = new System.Drawing.Point(20, 138);
            this.rbFortnightly.Name = "rbFortnightly";
            this.rbFortnightly.Size = new System.Drawing.Size(130, 25);
            this.rbFortnightly.TabIndex = 3;
            this.rbFortnightly.TabStop = true;
            this.rbFortnightly.Text = "📅 Fortnightly";
            this.rbFortnightly.CheckedChanged += new System.EventHandler(this.rbPaySchedule_CheckedChanged);
            
            // 
            // rbMonthly
            // 
            this.rbMonthly.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbMonthly.Location = new System.Drawing.Point(160, 138);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(130, 25);
            this.rbMonthly.TabIndex = 4;
            this.rbMonthly.Text = "📆 Monthly";
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbPaySchedule_CheckedChanged);
            
            // 
            // lblMonthlyEquiv
            // 
            this.lblMonthlyEquiv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyEquiv.ForeColor = System.Drawing.Color.FromArgb(102, 126, 234);
            this.lblMonthlyEquiv.Location = new System.Drawing.Point(350, 68);
            this.lblMonthlyEquiv.Name = "lblMonthlyEquiv";
            this.lblMonthlyEquiv.Size = new System.Drawing.Size(400, 60);
            this.lblMonthlyEquiv.TabIndex = 5;
            this.lblMonthlyEquiv.Text = "Monthly Equivalent: $0.00";
            
            // 
            // btnSaveIncome
            // 
            this.btnSaveIncome.BackColor = System.Drawing.Color.FromArgb(102, 126, 234);
            this.btnSaveIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveIncome.ForeColor = System.Drawing.Color.White;
            this.btnSaveIncome.Location = new System.Drawing.Point(20, 180);
            this.btnSaveIncome.Name = "btnSaveIncome";
            this.btnSaveIncome.Size = new System.Drawing.Size(200, 40);
            this.btnSaveIncome.TabIndex = 6;
            this.btnSaveIncome.Text = "💾 Save Income";
            this.btnSaveIncome.UseVisualStyleBackColor = false;
            this.btnSaveIncome.Click += new System.EventHandler(this.btnSaveIncome_Click);
            
            // 
            // dgvIncome
            // 
            this.dgvIncome.AllowUserToAddRows = false;
            this.dgvIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncome.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIncome.Location = new System.Drawing.Point(20, 280);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.ReadOnly = true;
            this.dgvIncome.RowHeadersVisible = false;
            this.dgvIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncome.Size = new System.Drawing.Size(852, 220);
            this.dgvIncome.TabIndex = 7;
            
            // 
            // btnDeleteIncome
            // 
            this.btnDeleteIncome.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteIncome.ForeColor = System.Drawing.Color.White;
            this.btnDeleteIncome.Location = new System.Drawing.Point(20, 510);
            this.btnDeleteIncome.Name = "btnDeleteIncome";
            this.btnDeleteIncome.Size = new System.Drawing.Size(200, 35);
            this.btnDeleteIncome.TabIndex = 8;
            this.btnDeleteIncome.Text = "🗑️ Delete Selected";
            this.btnDeleteIncome.UseVisualStyleBackColor = false;
            this.btnDeleteIncome.Click += new System.EventHandler(this.btnDeleteIncome_Click);
            
            // Continue in next part...
            this.InitializeComponentPart2();
            
            this.ResumeLayout(false);
        }
        private void InitializeComponentPart2()
        {
            // 
            // tabBills - Bills Management Tab
            // 
            this.tabBills.BackColor = System.Drawing.Color.White;
            this.tabBills.Controls.Add(this.grpBillInput);
            this.tabBills.Controls.Add(this.dgvBills);
            this.tabBills.Controls.Add(this.btnDeleteBill);
            this.tabBills.Controls.Add(this.lblTotalBills);
            this.tabBills.Location = new System.Drawing.Point(4, 28);
            this.tabBills.Name = "tabBills";
            this.tabBills.Padding = new System.Windows.Forms.Padding(20);
            this.tabBills.Size = new System.Drawing.Size(892, 568);
            this.tabBills.TabIndex = 1;
            this.tabBills.Text = "📋 Fixed Bills";
            
            // 
            // grpBillInput
            // 
            this.grpBillInput.Controls.Add(this.lblBillName);
            this.grpBillInput.Controls.Add(this.txtBillName);
            this.grpBillInput.Controls.Add(this.lblBillAmount);
            this.grpBillInput.Controls.Add(this.txtBillAmount);
            this.grpBillInput.Controls.Add(this.lblBillDue);
            this.grpBillInput.Controls.Add(this.txtBillDue);
            this.grpBillInput.Controls.Add(this.btnAddBill);
            this.grpBillInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBillInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBillInput.Location = new System.Drawing.Point(20, 20);
            this.grpBillInput.Name = "grpBillInput";
            this.grpBillInput.Padding = new System.Windows.Forms.Padding(15);
            this.grpBillInput.Size = new System.Drawing.Size(852, 200);
            this.grpBillInput.TabIndex = 0;
            this.grpBillInput.TabStop = false;
            this.grpBillInput.Text = "Add New Bill";
            
            // 
            // lblBillName
            // 
            this.lblBillName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBillName.Location = new System.Drawing.Point(20, 40);
            this.lblBillName.Name = "lblBillName";
            this.lblBillName.Size = new System.Drawing.Size(150, 25);
            this.lblBillName.TabIndex = 0;
            this.lblBillName.Text = "Bill Name:";
            
            // 
            // txtBillName
            // 
            this.txtBillName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBillName.Location = new System.Drawing.Point(20, 68);
            this.txtBillName.Name = "txtBillName";
            this.txtBillName.Size = new System.Drawing.Size(250, 25);
            this.txtBillName.TabIndex = 1;
            
            // 
            // lblBillAmount
            // 
            this.lblBillAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBillAmount.Location = new System.Drawing.Point(290, 40);
            this.lblBillAmount.Name = "lblBillAmount";
            this.lblBillAmount.Size = new System.Drawing.Size(150, 25);
            this.lblBillAmount.TabIndex = 2;
            this.lblBillAmount.Text = "Amount:";
            
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBillAmount.Location = new System.Drawing.Point(290, 68);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(150, 25);
            this.txtBillAmount.TabIndex = 3;
            
            // 
            // lblBillDue
            // 
            this.lblBillDue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBillDue.Location = new System.Drawing.Point(460, 40);
            this.lblBillDue.Name = "lblBillDue";
            this.lblBillDue.Size = new System.Drawing.Size(150, 25);
            this.lblBillDue.TabIndex = 4;
            this.lblBillDue.Text = "Due Date:";
            
            // 
            // txtBillDue
            // 
            this.txtBillDue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBillDue.Location = new System.Drawing.Point(460, 68);
            this.txtBillDue.Name = "txtBillDue";
            this.txtBillDue.Size = new System.Drawing.Size(200, 25);
            this.txtBillDue.TabIndex = 5;
            this.txtBillDue.Text = "End of month";
            
            // 
            // btnAddBill
            // 
            this.btnAddBill.BackColor = System.Drawing.Color.FromArgb(102, 126, 234);
            this.btnAddBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddBill.ForeColor = System.Drawing.Color.White;
            this.btnAddBill.Location = new System.Drawing.Point(20, 120);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(200, 40);
            this.btnAddBill.TabIndex = 6;
            this.btnAddBill.Text = "➕ Add Bill";
            this.btnAddBill.UseVisualStyleBackColor = false;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBills.Location = new System.Drawing.Point(20, 240);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(852, 220);
            this.dgvBills.TabIndex = 7;
            
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteBill.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBill.Location = new System.Drawing.Point(20, 470);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(200, 35);
            this.btnDeleteBill.TabIndex = 8;
            this.btnDeleteBill.Text = "🗑️ Delete Selected";
            this.btnDeleteBill.UseVisualStyleBackColor = false;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            
            // 
            // lblTotalBills
            // 
            this.lblTotalBills.BackColor = System.Drawing.Color.FromArgb(255, 249, 230);
            this.lblTotalBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalBills.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalBills.ForeColor = System.Drawing.Color.FromArgb(102, 126, 234);
            this.lblTotalBills.Location = new System.Drawing.Point(20, 515);
            this.lblTotalBills.Name = "lblTotalBills";
            this.lblTotalBills.Padding = new System.Windows.Forms.Padding(10);
            this.lblTotalBills.Size = new System.Drawing.Size(852, 40);
            this.lblTotalBills.TabIndex = 9;
            this.lblTotalBills.Text = "Total Monthly Bills: $0.00";
            this.lblTotalBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // tabBudget - Budget Allocation Tab
            // 
            this.tabBudget.BackColor = System.Drawing.Color.White;
            this.tabBudget.Controls.Add(this.grpBudgetCategories);
            this.tabBudget.Controls.Add(this.btnCalculateBudget);
            this.tabBudget.Controls.Add(this.dgvAllocations);
            this.tabBudget.Location = new System.Drawing.Point(4, 28);
            this.tabBudget.Name = "tabBudget";
            this.tabBudget.Padding = new System.Windows.Forms.Padding(20);
            this.tabBudget.Size = new System.Drawing.Size(892, 568);
            this.tabBudget.TabIndex = 2;
            this.tabBudget.Text = "📊 Budget Plan";
            
            // 
            // grpBudgetCategories
            // 
            this.grpBudgetCategories.Controls.Add(this.lblCreditCard);
            this.grpBudgetCategories.Controls.Add(this.txtCreditCardPercent);
            this.grpBudgetCategories.Controls.Add(this.lblSavings);
            this.grpBudgetCategories.Controls.Add(this.txtSavingsPercent);
            this.grpBudgetCategories.Controls.Add(this.lblPercentTotal);
            this.grpBudgetCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBudgetCategories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBudgetCategories.Location = new System.Drawing.Point(20, 20);
            this.grpBudgetCategories.Name = "grpBudgetCategories";
            this.grpBudgetCategories.Padding = new System.Windows.Forms.Padding(15);
            this.grpBudgetCategories.Size = new System.Drawing.Size(852, 180);
            this.grpBudgetCategories.TabIndex = 0;
            this.grpBudgetCategories.TabStop = false;
            this.grpBudgetCategories.Text = "Allocate Remaining Income (After Bills)";
            
            // 
            // lblCreditCard
            // 
            this.lblCreditCard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCreditCard.Location = new System.Drawing.Point(20, 40);
            this.lblCreditCard.Name = "lblCreditCard";
            this.lblCreditCard.Size = new System.Drawing.Size(250, 25);
            this.lblCreditCard.TabIndex = 0;
            this.lblCreditCard.Text = "💳 Credit Card Budget (%)";
            
            // 
            // txtCreditCardPercent
            // 
            this.txtCreditCardPercent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCreditCardPercent.Location = new System.Drawing.Point(20, 68);
            this.txtCreditCardPercent.Name = "txtCreditCardPercent";
            this.txtCreditCardPercent.Size = new System.Drawing.Size(100, 25);
            this.txtCreditCardPercent.TabIndex = 1;
            this.txtCreditCardPercent.Text = "60";
            this.txtCreditCardPercent.TextChanged += new System.EventHandler(this.txtPercent_TextChanged);
            
            // 
            // lblSavings
            // 
            this.lblSavings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSavings.Location = new System.Drawing.Point(300, 40);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(250, 25);
            this.lblSavings.TabIndex = 2;
            this.lblSavings.Text = "💎 Savings & Investment (%)";
            
            // 
            // txtSavingsPercent
            // 
            this.txtSavingsPercent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSavingsPercent.Location = new System.Drawing.Point(300, 68);
            this.txtSavingsPercent.Name = "txtSavingsPercent";
            this.txtSavingsPercent.Size = new System.Drawing.Size(100, 25);
            this.txtSavingsPercent.TabIndex = 3;
            this.txtSavingsPercent.Text = "40";
            this.txtSavingsPercent.TextChanged += new System.EventHandler(this.txtPercent_TextChanged);
            
            // 
            // lblPercentTotal
            // 
            this.lblPercentTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPercentTotal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblPercentTotal.Location = new System.Drawing.Point(20, 120);
            this.lblPercentTotal.Name = "lblPercentTotal";
            this.lblPercentTotal.Size = new System.Drawing.Size(800, 40);
            this.lblPercentTotal.TabIndex = 4;
            this.lblPercentTotal.Text = "✓ Total: 100%";
            
            // 
            // btnCalculateBudget
            // 
            this.btnCalculateBudget.BackColor = System.Drawing.Color.FromArgb(102, 126, 234);
            this.btnCalculateBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateBudget.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCalculateBudget.ForeColor = System.Drawing.Color.White;
            this.btnCalculateBudget.Location = new System.Drawing.Point(20, 220);
            this.btnCalculateBudget.Name = "btnCalculateBudget";
            this.btnCalculateBudget.Size = new System.Drawing.Size(852, 50);
            this.btnCalculateBudget.TabIndex = 5;
            this.btnCalculateBudget.Text = "🧮 Calculate My Budget";
            this.btnCalculateBudget.UseVisualStyleBackColor = false;
            this.btnCalculateBudget.Click += new System.EventHandler(this.btnCalculateBudget_Click);
            
            // 
            // dgvAllocations
            // 
            this.dgvAllocations.AllowUserToAddRows = false;
            this.dgvAllocations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllocations.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllocations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAllocations.Location = new System.Drawing.Point(20, 290);
            this.dgvAllocations.Name = "dgvAllocations";
            this.dgvAllocations.ReadOnly = true;
            this.dgvAllocations.RowHeadersVisible = false;
            this.dgvAllocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllocations.Size = new System.Drawing.Size(852, 260);
            this.dgvAllocations.TabIndex = 6;
            
            // 
            // tabSummary - Summary Overview Tab
            // 
            this.tabSummary.BackColor = System.Drawing.Color.White;
            this.tabSummary.Controls.Add(this.lblSummaryTitle);
            this.tabSummary.Controls.Add(this.txtSummary);
            this.tabSummary.Location = new System.Drawing.Point(4, 28);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Windows.Forms.Padding(20);
            this.tabSummary.Size = new System.Drawing.Size(892, 568);
            this.tabSummary.TabIndex = 3;
            this.tabSummary.Text = "📈 Summary";
            
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(852, 40);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "📊 Your Monthly Budget Summary";
            this.lblSummaryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.Color.FromArgb(248, 249, 255);
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummary.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtSummary.Location = new System.Drawing.Point(20, 70);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(852, 480);
            this.txtSummary.TabIndex = 1;
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💰 Personal Finance Tracker";
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocations)).EndInit();
        }

        // Declare all controls
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabIncome;
        private System.Windows.Forms.TabPage tabBills;
        private System.Windows.Forms.TabPage tabBudget;
        private System.Windows.Forms.TabPage tabSummary;
        
        // Income controls
        private System.Windows.Forms.GroupBox grpIncomeInput;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.TextBox txtIncomeAmount;
        private System.Windows.Forms.Label lblPaySchedule;
        private System.Windows.Forms.RadioButton rbFortnightly;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.Label lblMonthlyEquiv;
        private System.Windows.Forms.Button btnSaveIncome;
        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Button btnDeleteIncome;
        
        // Bills controls
        private System.Windows.Forms.GroupBox grpBillInput;
        private System.Windows.Forms.Label lblBillName;
        private System.Windows.Forms.TextBox txtBillName;
        private System.Windows.Forms.Label lblBillAmount;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label lblBillDue;
        private System.Windows.Forms.TextBox txtBillDue;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Button btnDeleteBill;
        private System.Windows.Forms.Label lblTotalBills;
        
        // Budget controls
        private System.Windows.Forms.GroupBox grpBudgetCategories;
        private System.Windows.Forms.Label lblCreditCard;
        private System.Windows.Forms.TextBox txtCreditCardPercent;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.TextBox txtSavingsPercent;
        private System.Windows.Forms.Label lblPercentTotal;
        private System.Windows.Forms.Button btnCalculateBudget;
        private System.Windows.Forms.DataGridView dgvAllocations;
        
        // Summary controls
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.TextBox txtSummary;
    }
}
