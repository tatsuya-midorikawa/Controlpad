using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlpad;

namespace ControlPadSampleForm
{
    public partial class Form1 : Form
    {
        private readonly Snapshot<TextBox, string> snapshot;
        private readonly Runbook runbook;

        public Form1()
        {
            InitializeComponent();

            snapshot = new Snapshot<TextBox, string>(ContentArea, ContentArea.Text, (contentArea, newText) =>
            {
                contentArea.Text = newText;
            });

            runbook = new Runbook(capacity: 10);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (runbook.CanUndo)
                runbook.Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            if (runbook.CanRedo)
                runbook.Redo();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var command = snapshot.ToCommand(ContentArea.Text);
            if (!runbook.Invoke(command))
                MessageBox.Show("The command storage limit has been exceeded.");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            runbook.Refresh();
        }
    }
}
