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
        private readonly Runbook runbook;

        public Form1()
        {
            InitializeComponent();

            runbook = new Runbook(capacity: 10);
            runbook.TryAdd(ContentArea, ContentArea.Text, (contentArea, newText) =>
            {
                contentArea.Text = newText;
            });
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
            runbook.Invoke(ContentArea, ContentArea.Text);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            runbook.Refresh();
        }
    }
}
