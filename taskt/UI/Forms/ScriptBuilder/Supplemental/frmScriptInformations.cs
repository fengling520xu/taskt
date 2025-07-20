using System;
using System.Windows.Forms;
using taskt.Core.Script;

namespace taskt.UI.Forms.ScriptBuilder.Supplemental
{
    public partial class frmScriptInformations : ThemedForm
    {
        //public frmScriptBuilder scriptBuilderForm;
        public ScriptInformation infos { get; private set; }

        public frmScriptInformations()
        {
            InitializeComponent();
        }

        public frmScriptInformations(ScriptInformation infos) : this()
        {
            this.infos = new ScriptInformation(infos);
        }

        private void frmScriptInformations_Load(object sender, EventArgs e)
        {
            txtScriptAuthor.DataBindings.Add("Text", infos, "Author", false, DataSourceUpdateMode.OnPropertyChanged);
            txtScriptVersion.DataBindings.Add("Text", infos, "ScriptVersion", false, DataSourceUpdateMode.OnPropertyChanged);
            txtScriptDescription.DataBindings.Add("Text", infos, "Description", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTasktVersion.Text = infos.TasktVersion;
            txtRunTimes.Text = infos.RunTimes.ToString();
            txtScriptRevision.Text = infos.Revision.ToString();
            txtLastRun.Text = infos.LastRunTime.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmScriptInformations_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
