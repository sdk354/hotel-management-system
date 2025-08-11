using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Hotel_Room_Booking_System
{
    public partial class RegistrationForm : Form
    {
        private int? selectedAdminId = null;

        // Accept role explicitly; fallback to SessionManager if not provided
        private string _explicitRole;

        public RegistrationForm(string? currentRole = null)
        {
            _explicitRole = (currentRole ?? SessionManager.CurrentUserRole)?.Trim() ?? "";
            InitializeComponent();
        }

        // If you keep a parameterless constructor, it still works by falling back to SessionManager
        public RegistrationForm() : this(null) { }

        // Always use the best-known role
        private string EffectiveRole =>
            string.IsNullOrWhiteSpace(_explicitRole)
                ? (SessionManager.CurrentUserRole?.Trim() ?? "")
                : _explicitRole;

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new[] { "SuperAdmin", "Admin", "Manager" });
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 1;

            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAdmins.SelectionChanged += DgvAdmins_SelectionChanged;

            ApplyRolePermissions();
            LoadAdmins();

            // If the role gets set after the form opens, this will re-apply permissions when you refocus the form
            this.Activated += (_, __) => ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            bool isSuper = IsSuperAdmin();

            btnSave.Enabled = isSuper;
            btnUpdate.Enabled = isSuper;
            btnDelete.Enabled = isSuper;
            btnRefresh.Enabled = isSuper;
            btnClear.Enabled = isSuper;

            txtUsername.ReadOnly = !isSuper;
            txtPassword.ReadOnly = !isSuper;
            cmbRole.Enabled = isSuper;
        }

        private bool IsSuperAdmin()
        {
            return string.Equals(EffectiveRole, "SuperAdmin", StringComparison.OrdinalIgnoreCase);
        }

        private void LoadAdmins()
        {
            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var da = new SqlDataAdapter("SELECT AdminID, Username, Role FROM Admins ORDER BY AdminID", conn))
            {
                var dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    dgvAdmins.DataSource = dt;
                    dgvAdmins.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading admins: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                MessageBox.Show("Access denied.");
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? "Admin";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand("INSERT INTO Admins (Username, Password, Role) VALUES (@u, @p, @r);", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadAdmins();
                    ClearInputs();
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Username already exists.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                MessageBox.Show("Access denied.");
                return;
            }

            if (selectedAdminId == null)
            {
                MessageBox.Show("Select an admin.");
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? "Admin";

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand(
                @"UPDATE Admins
                  SET Username = @u, 
                      Password = CASE WHEN @p = '' THEN Password ELSE @p END,
                      Role = @r
                  WHERE AdminID = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password ?? string.Empty);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.Parameters.AddWithValue("@id", selectedAdminId.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadAdmins();
                    ClearInputs();
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Username already exists.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsSuperAdmin())
            {
                MessageBox.Show("Access denied.");
                return;
            }

            if (selectedAdminId == null)
            {
                MessageBox.Show("Select an admin.");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            var conn = DatabaseHelper.GetConnection();
            if (conn == null) return;

            using (conn)
            using (var cmd = new SqlCommand("DELETE FROM Admins WHERE AdminID = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", selectedAdminId.Value);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadAdmins();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!IsSuperAdmin()) return;
            LoadAdmins();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!IsSuperAdmin()) return;
            ClearInputs();
        }

        private void DgvAdmins_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0)
            {
                selectedAdminId = null;
                return;
            }

            var row = dgvAdmins.SelectedRows[0];
            if (row.Cells["AdminID"].Value == null) return;

            selectedAdminId = Convert.ToInt32(row.Cells["AdminID"].Value);
            txtUsername.Text = row.Cells["Username"]?.Value?.ToString() ?? "";
            cmbRole.SelectedItem = row.Cells["Role"]?.Value?.ToString() ?? "Admin";
            txtPassword.Text = "";
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 1;
            selectedAdminId = null;
            dgvAdmins.ClearSelection();
        }
    }
}
