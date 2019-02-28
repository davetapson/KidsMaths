using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KidsMaths
{
    public partial class OptionsForm : Form
    {
        MainForm _mainForm;

        public OptionsForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            PopulateControls();
        }

        private void PopulateControls()
        {
            numFrom.Value = _mainForm.RangeFrom;
            numTo.Value = _mainForm.RangeTo;

            switch (_mainForm.AddSubtrPattern)
            {
                case 1:
                    rdoAdditionSubtractionPattern1.Checked = true;
                    break;
                case 2:
                    rdoAdditionSubtractionPattern2.Checked = true;
                    break;
                case 3:
                    rdoAdditionSubtractionPattern3.Checked = true;
                    break;
                case 4:
                    rdoAdditionSubtractionPattern4.Checked = true;
                    break;
                default:
                    rdoAdditionSubtractionPattern1.Checked = true;
                    break;
            }
            rdoDoubles.Checked = _mainForm.Doubles;
            rdoHalf.Checked = _mainForm.Half;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseMe();
        }

        private void CloseMe()
        {
            _mainForm.RangeTo = Convert.ToInt32(numTo.Value);
            _mainForm.RangeFrom = Convert.ToInt32(numFrom.Value);

            if (rdoAdditionSubtractionPattern1.Checked)
            {
                _mainForm.AddSubtrPattern = 1;
            }
            else if (rdoAdditionSubtractionPattern2.Checked)
            {
                _mainForm.AddSubtrPattern = 2;
            }
            else if (rdoAdditionSubtractionPattern3.Checked)
            {
                _mainForm.AddSubtrPattern = 3;
            }
            else if (rdoAdditionSubtractionPattern4.Checked)
            {
                _mainForm.AddSubtrPattern = 4;
            }

            _mainForm.Doubles = rdoDoubles.Checked;
            _mainForm.Half = rdoHalf.Checked;

            Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CloseMe();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {

        }

        private void numTo_Leave(object sender, EventArgs e)
        {
            if (numTo.Value < numFrom.Value)
            {
                MessageBox.Show("From cannot be less than To.", _mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numTo.Value = numFrom.Value;
                numTo.Focus();
            }
        }

        private void numFrom_Leave(object sender, EventArgs e)
        {
            if (numTo.Value < numFrom.Value)
            {
                MessageBox.Show("From cannot be less than To.", _mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numFrom.Value = numTo.Value;
                numFrom.Focus();
            }
        }
    }
}
