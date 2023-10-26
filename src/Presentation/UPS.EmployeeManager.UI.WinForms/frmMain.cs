using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Services;
using UPS.EmployeeManager.Services.Validation;
using UPS.EmployeeManager.Shared.Models;
using UPS.EmployeeManager.UI.WinForms.Utils;

namespace UPS.EmployeeManager.UI.WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<frmMain> _logger;

        public frmMain(IEmployeeService employeeService, ILogger<frmMain> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");

            // this.txtEmailAddress.Text = UPS.EmployeeManager.UI.WinForms.LocalizationResource.em;
            InitializeComponent();
            dgMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            await PerformInit();
        }



        private async Task PopulateGridView()
        {
            var task = _employeeService.GetAllAsync();
            var employees = await task;

            if (employees != null)
            {
                dgMain.DataSource = employees;

            }
            else
            {
                // Handle API error or request failure
            }
            dgMain.AutoResizeColumns();
        }


        private async Task PerformInit()
        {
            await PopulateGridView();
            PopulateCombobox();
        }
        private void PopulateCombobox()
        {

            cboGender.Items.Clear();

            clistitems clist;

            clist = new clistitems();
            clist.Name = "male";
            clist.Id = "male";
            this.cboGender.Items.Add(clist);

            clist = new clistitems();
            clist.Name = "female";
            clist.Id = "female";
            this.cboGender.Items.Add(clist);
        }

        public void ClearForm()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            chkStatus.Checked = false;
            PopulateCombobox();
            btnAdd.Text = "Save";
        }
        #region Events 
        private void dgMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null && dgv.SelectedRows.Count > 0)
                {
                    DataGridViewRow dataGridViewRow = dgv.SelectedRows[0];
                    if (dataGridViewRow != null)
                    {
                        txtId.Text = dataGridViewRow.Cells[0].Value.ToString();
                        txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        txtEmailAddress.Text = dataGridViewRow.Cells[2].Value.ToString();

                        cboGender.SelectedIndex = cboGender.FindString(dataGridViewRow.Cells[3].Value.ToString());

                        chkStatus.Checked = dataGridViewRow.Cells[4].Value.ToString().Equals("active");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                MessageBox.Show("A fatal error occured, the administrator has been notified", "Employee Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void dgMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    int selectedIndex = e.RowIndex;
                    DataGridViewRow dataGridViewRow = dgMain.Rows[selectedIndex];
                    txtId.Text = dataGridViewRow.Cells[0].Value.ToString();
                    txtName.Text = dataGridViewRow.Cells[1].Value.ToString();
                    txtEmailAddress.Text = dataGridViewRow.Cells[2].Value.ToString();
                    //cboGender.SelectedValue = dataGridViewRow.Cells[3].Value.ToString();
                    cboGender.SelectedIndex = cboGender.FindString(dataGridViewRow.Cells[3].Value.ToString());

                    chkStatus.Checked = dataGridViewRow.Cells[4].Value.ToString().Equals("active");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                MessageBox.Show("A fatal error occured, the administrator has been notified", "Employee Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion
        #region Form Actions
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                var selectedGender = cboGender.SelectedItem;

                if (selectedGender == null) // Check if an item is selected
                {
                    MessageBox.Show("Please select a gender from the ComboBox.", "Employee Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var employeeModel = new EmployeeModel();
                employeeModel.Name = txtName.Text;
                employeeModel.Email = txtEmailAddress.Text;
                employeeModel.Status = chkStatus.Checked == true ? "active" : "inactive";
                employeeModel.Gender = selectedGender.ToString();

                EmployeeValidator validationRules = new EmployeeValidator();
                var validationtask = validationRules.Validate(employeeModel);
                IList<ValidationFailure> errors = validationtask.Errors;
                if (!validationtask.IsValid)
                {
                    foreach (var error in errors)
                    {
                        MessageBox.Show(error.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(txtId.Text)) // if Id is not null, then it's an update
                {
                    employeeModel.Id = int.Parse(txtId.Text);
                    var updatedEmployee = await _employeeService.UpdateAsync(employeeModel.Id, employeeModel);
                    MessageBox.Show($"Employee ID: {updatedEmployee.Id}, Name: {updatedEmployee.Name}, Email: {updatedEmployee.Email} updated successfully!", "Employee Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await PopulateGridView();
                }
                else
                {
                    var createdEmployee = await _employeeService.CreateAsync(employeeModel);

                    if (createdEmployee != null)
                    {
                        ClearForm();
                    }
                    else
                    {
                        // Handle API error or request failure
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                MessageBox.Show("A fatal error occured, the administrator has been notified", "Employee Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dgMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgMain.SelectedRows[0];

                int employeeIdToDelete = int.Parse(selectedRow.Cells[0].Value.ToString());

                bool isDeleted = await _employeeService.DeleteAsync(employeeIdToDelete);

                if (isDeleted)
                {
                    MessageBox.Show($"Employee ID: {employeeIdToDelete} deleted successfully!", "Employee Manager",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await PopulateGridView();
                }
                else
                {
                    MessageBox.Show("Failed to delete the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearch.Text;

            var searchResults = await _employeeService.SearchByNameAsync(searchName);

            if (searchResults != null)
            {
                dgMain.DataSource = searchResults;
                dgMain.AutoGenerateColumns = true;
            }
            else
            {
                MessageBox.Show($"Employee with name = {searchName} was not found!", "Employee Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                await PopulateGridView();
            }
        }
        #endregion





    }
}