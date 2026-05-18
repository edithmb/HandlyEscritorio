using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Models;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Views
{
    public partial class SolveReport : Form
    {
        // Estados de denuncia que va a usar el admin app para resolver.
        // OJO: estos IDs tienen que existir en la tabla Report_states.
        // Si no, hay que insertarlos con el SQL que se da en la conversación.
        private const int STATE_REPORTER_WINS = 2;
        private const int STATE_REPORTEE_WINS = 3;
        private const int STATE_DISMISSED    = 4;

        // estado "baneado" en App_users.account_state_id
        private const int ACCOUNT_STATE_BANNED = 2;

        private readonly Report _report;
        private readonly ApiService _api = new ApiService();
        private ReportContext _context;

        public SolveReport(Report report)
        {
            InitializeComponent();
            _report = report ?? new Report();
        }

        private async void SolveReport_Load(object sender, EventArgs e)
        {
            // pintamos la cabecera con la info que ya tenemos
            this.Text = $"Resolver denuncia #{_report.Id}";
            lblReporterValue.Text = FormatNameWithRole(_report.ReporterFullName, _report.ReporterRoleLabel);
            lblReporteeValue.Text = FormatNameWithRole(_report.ReporteeFullName, _report.ReporteeRoleLabel);
            lblCauseValue.Text = SafeData.Text(_report.Cause, "-");
            lblOriginValue.Text = SafeData.Text(_report.ReportOrigin, "-");

            // si la denuncia ya está resuelta, pre-seleccionamos su estado actual
            if (_report.StateId.HasValue)
            {
                if (_report.StateId.Value == STATE_REPORTER_WINS) rbReporterWins.Checked = true;
                else if (_report.StateId.Value == STATE_REPORTEE_WINS) rbReporteeWins.Checked = true;
                else if (_report.StateId.Value == STATE_DISMISSED) rbDismiss.Checked = true;
            }

            // cargamos el contexto desde la API
            await LoadContextAsync();
        }

        private async System.Threading.Tasks.Task LoadContextAsync()
        {
            try
            {
                var result = await _api.GetReportContextAsync(_report.Id);
                if (!result.Success || result.Data == null)
                {
                    ShowEmptyContext("No se pudo cargar el contexto: " +
                        (result.ErrorMessage ?? "sin detalles"));
                    return;
                }

                _context = result.Data;
                RenderContext();
            }
            catch (Exception ex)
            {
                ShowEmptyContext("Error inesperado al cargar el contexto.");
                System.Diagnostics.Debug.WriteLine("LoadContextAsync error: " + ex.Message);
            }
        }

        private static string FormatNameWithRole(string fullName, string roleLabel)
        {
            string name = SafeData.Text(fullName, "-");
            if (string.IsNullOrEmpty(roleLabel)) return name;
            return name + "  (" + roleLabel + ")";
        }

        private void RenderContext()
        {
            cmbContextItem.Items.Clear();

            // si la denuncia es de "Chat" -> mostramos los chats
            // si la denuncia es de "Task"/"Tarea" -> mostramos las tareas
            // si no hay nada -> mensaje informativo
            bool hasChats = _context?.Chats != null && _context.Chats.Count > 0;
            bool hasTasks = _context?.Tasks != null && _context.Tasks.Count > 0;

            if (hasChats)
            {
                lblContextPicker.Text = "Ver chat:";
                foreach (var c in _context.Chats)
                {
                    cmbContextItem.Items.Add(
                        $"Chat #{c.Id}  (tarea #{c.TaskId})  - {c.Messages?.Count ?? 0} mensajes");
                }
                cmbContextItem.SelectedIndex = 0;
            }
            else if (hasTasks)
            {
                lblContextPicker.Text = "Ver tarea:";
                foreach (var t in _context.Tasks)
                {
                    cmbContextItem.Items.Add(
                        $"Tarea #{t.Id}  - {SafeData.Text(t.Title, "(sin título)")}  ({SafeData.Text(t.TaskStateName, "?")})");
                }
                cmbContextItem.SelectedIndex = 0;
            }
            else
            {
                ShowEmptyContext("No hay chats ni tareas entre las dos partes.");
            }
        }

        private void cmbContextItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_context == null) return;
            int idx = cmbContextItem.SelectedIndex;
            if (idx < 0) return;

            // según lo que esté cargado, mostramos chat o tarea
            if (_context.Chats != null && idx < _context.Chats.Count)
            {
                ShowChat(_context.Chats[idx]);
            }
            else if (_context.Tasks != null && idx < _context.Tasks.Count)
            {
                ShowTask(_context.Tasks[idx]);
            }
        }

        private void ShowChat(ChatInfo chat)
        {
            panelTaskDetails.Visible = false;
            lblContextEmpty.Visible = false;
            gridMessages.Visible = true;

            // simple proyección: cada mensaje como una fila legible
            var rows = (chat.Messages ?? new List<MessageInfo>())
                .Select(m => new
                {
                    Fecha = m.MessageDate.HasValue
                        ? m.MessageDate.Value.ToString("dd/MM/yyyy HH:mm")
                        : "-",
                    De = m.SentBy.HasValue ? m.SentBy.Value.ToString() : "-",
                    Mensaje = SafeData.Text(m.Text, "")
                })
                .ToList();

            gridMessages.DataSource = null;
            gridMessages.DataSource = rows;
            if (gridMessages.Columns["Fecha"] != null) gridMessages.Columns["Fecha"].Width = 140;
            if (gridMessages.Columns["De"] != null) gridMessages.Columns["De"].Width = 100;
        }

        private void ShowTask(TaskInfo task)
        {
            gridMessages.Visible = false;
            lblContextEmpty.Visible = false;
            panelTaskDetails.Visible = true;

            lblTaskTitleValue.Text = SafeData.Text(task.Title, "-");
            lblTaskStateValue.Text = SafeData.Text(task.TaskStateName, "-");
            lblTaskCreationValue.Text = task.CreationDate.HasValue
                ? task.CreationDate.Value.ToString("dd/MM/yyyy HH:mm")
                : "-";
            lblTaskDescriptionValue.Text = SafeData.Text(task.Description, "-");
        }

        private void ShowEmptyContext(string message)
        {
            gridMessages.Visible = false;
            panelTaskDetails.Visible = false;
            cmbContextItem.Visible = false;
            lblContextPicker.Visible = false;
            lblContextEmpty.Text = message;
            lblContextEmpty.Visible = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. validar que el admin haya elegido un veredicto
            if (!rbReporterWins.Checked && !rbReporteeWins.Checked && !rbDismiss.Checked)
            {
                SafeData.ShowError("Veredicto requerido", "Elige un veredicto antes de guardar.");
                return;
            }

            int newStateId;
            long? loserUserId = null;

            if (rbReporterWins.Checked)
            {
                newStateId = STATE_REPORTER_WINS;
                loserUserId = _report.ReporteeUserId;
            }
            else if (rbReporteeWins.Checked)
            {
                newStateId = STATE_REPORTEE_WINS;
                loserUserId = _report.ReporterUserId;
            }
            else // rbDismiss
            {
                newStateId = STATE_DISMISSED;
                loserUserId = null; // nadie pierde, nadie se banea
            }

            bool wantsBan = chkBanLoser.Checked && loserUserId.HasValue && loserUserId.Value > 0;

            // 2. confirmar si la acción tiene consecuencias importantes
            string confirmMsg = "¿Confirmas el veredicto?";
            if (wantsBan)
            {
                confirmMsg += Environment.NewLine + "También se baneará al usuario perdedor (id " + loserUserId.Value + ").";
            }
            var confirm = MessageBox.Show(confirmMsg, "Confirmar",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm != DialogResult.OK) return;

            SetBusy(true);
            try
            {
                // 3. cambiar estado de la denuncia
                var stateResult = await _api.UpdateReportStatusAsync(_report.Id, newStateId);
                if (!stateResult.Success)
                {
                    SafeData.ShowError("No se pudo guardar",
                        "Error al actualizar el estado de la denuncia: " + stateResult.ErrorMessage);
                    return;
                }

                // 4. banear al perdedor si procede
                if (wantsBan)
                {
                    var banResult = await _api.ChangeUserStateAsync(loserUserId.Value, ACCOUNT_STATE_BANNED);
                    if (!banResult.Success)
                    {
                        SafeData.ShowError("Aviso parcial",
                            "El veredicto se guardó, pero no se pudo banear al perdedor: " + banResult.ErrorMessage);
                        // seguimos: el veredicto sí se guardó
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                SafeData.ShowError("Error inesperado",
                    "No se pudo resolver la denuncia.", ex);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetBusy(bool busy)
        {
            btnSave.Enabled = !busy;
            btnCancel.Enabled = !busy;
            rbReporterWins.Enabled = !busy;
            rbReporteeWins.Enabled = !busy;
            rbDismiss.Enabled = !busy;
            chkBanLoser.Enabled = !busy;
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
