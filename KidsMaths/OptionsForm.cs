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
            // Addition and Subtraction
            rdoAdditionAndSubtraction.Checked = _mainForm.AdditionAndSubtraction;

            numFromAdditionAndSubtraction.Value = _mainForm.RangeFrom;
            numToAdditionAndSubtraction.Value = _mainForm.RangeTo;

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

            // Doubles
            rdoDoubles.Checked = _mainForm.Doubles;
            numFromDoubles.Value = _mainForm.DoublesRangeFrom;
            numToDoubles.Value = _mainForm.DoublesRangeTo;

            // Halves
            rdoHalf.Checked = _mainForm.Half;
            numFromHalves.Value = _mainForm.HalvesRangeFrom;
            numToHalves.Value = _mainForm.HalvesRangeTo;

            // Times Tables
            rdoTimesTables.Checked = _mainForm.TimesTables;
            cboTimesTables.Text = _mainForm.TimesTablesValue.ToString();
            rdoTimesTablesInOrder.Checked = _mainForm.TimesTablesInOrder;
            rdoTimesTablesRandom.Checked = _mainForm.TimesTablesRandom;

            // Tens
            rdoTens.Checked = _mainForm.Tens;
            cboTens.Text = _mainForm.TensValue.ToString();

            // Bonds
            rdoBonds.Checked = _mainForm.Bonds;
            cboBonds.Text = _mainForm.BondsValue.ToString();

            // Childs Name
            txtChildsName.Text = _mainForm.ChildsName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseMe();
        }

        private void CloseMe()
        {
            SaveSettings();

            Close();

        }

        private void SaveSettings()
        {
            // Addition and Subraction
            _mainForm.AdditionAndSubtraction = rdoAdditionAndSubtraction.Checked;
            _mainForm.RangeTo = Convert.ToInt32(numToAdditionAndSubtraction.Value);
            _mainForm.RangeFrom = Convert.ToInt32(numFromAdditionAndSubtraction.Value);

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

            // Doubles
            _mainForm.Doubles = rdoDoubles.Checked;
            _mainForm.DoublesRangeFrom = Convert.ToInt32(numFromDoubles.Value);
            _mainForm.DoublesRangeTo = Convert.ToInt32(numToDoubles.Value);

            // Halves
            _mainForm.Half = rdoHalf.Checked;
            _mainForm.HalvesRangeFrom = Convert.ToInt32(numFromHalves.Value);
            _mainForm.HalvesRangeTo = Convert.ToInt32(numToHalves.Value);

            // Times Tables
            _mainForm.TimesTables = rdoTimesTables.Checked;
            _mainForm.TimesTablesValue = Convert.ToInt32(cboTimesTables.Text);
            _mainForm.TimesTablesInOrder = rdoTimesTablesInOrder.Checked;
            _mainForm.TimesTablesRandom = rdoTimesTablesRandom.Checked;

            // Tens
            _mainForm.Tens = rdoTens.Checked;
            _mainForm.TensValue = Convert.ToInt32(cboTens.Text);
            if (rdoTensPattern1.Checked)
            {
                _mainForm.TensPattern = 1;
            }
            else if (rdoTensPattern2.Checked)
            {
                _mainForm.TensPattern = 2;
            }
            else if (rdoTensPattern3.Checked)
            {
                _mainForm.TensPattern = 3;
            }
            else if (rdoTensPattern4.Checked)
            {
                _mainForm.TensPattern = 4;
            }

            // Bonds
            _mainForm.Bonds = rdoBonds.Checked;
            _mainForm.BondsValue = Convert.ToInt32(cboBonds.Text);
            if (rdoGroupingPattern1.Checked)
            {
                _mainForm.GroupingsPattern = 1;
            }
            else if (rdoGroupingPattern2.Checked)
            {
                _mainForm.GroupingsPattern = 2;
            }
            else if (rdoGroupingPattern3.Checked)
            {
                _mainForm.GroupingsPattern = 3;
            }
            else if (rdoGroupingPattern4.Checked)
            {
                _mainForm.GroupingsPattern = 4;
            }

            // Childs Name
            _mainForm.ChildsName = txtChildsName.Text;
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
            if (numToAdditionAndSubtraction.Value < numFromAdditionAndSubtraction.Value)
            {
                MessageBox.Show("From cannot be less than To.", _mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numToAdditionAndSubtraction.Value = numFromAdditionAndSubtraction.Value;
                numToAdditionAndSubtraction.Focus();
            }
        }

        private void numFrom_Leave(object sender, EventArgs e)
        {
            if (numToAdditionAndSubtraction.Value < numFromAdditionAndSubtraction.Value)
            {
                MessageBox.Show("From cannot be less than To.", _mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numFromAdditionAndSubtraction.Value = numToAdditionAndSubtraction.Value;
                numFromAdditionAndSubtraction.Focus();
            }
        }

        private void rdoAdditionAndSubtraction_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            if (rdoAdditionAndSubtraction.Checked)
            {
                grpAdditionAndSubtraction.Enabled = true;
                grpDoubles.Enabled = false;
                grpHalves.Enabled = false;
                grpTimesTables.Enabled = false;
                cboTimesTables.Enabled = false;
                cboTens.Enabled = false;
                cboBonds.Enabled = false;
                grpTensOptions.Enabled = false;
                grpGroupingsOptions.Enabled = false;
            } else if (rdoDoubles.Checked)
            {
                grpAdditionAndSubtraction.Enabled = false;
                grpDoubles.Enabled = true;
                grpHalves.Enabled = false;
                grpTimesTables.Enabled = false;
                cboTimesTables.Enabled = false;
                cboTens.Enabled = false;
                cboBonds.Enabled = false;
                grpTensOptions.Enabled = false;
                grpGroupingsOptions.Enabled = false;
            }
            else if (rdoHalf.Checked)
            {
                grpAdditionAndSubtraction.Enabled = false;
                grpDoubles.Enabled = false;
                grpHalves.Enabled = true;
                grpTimesTables.Enabled = false;
                cboTens.Enabled = false;
                cboTimesTables.Enabled = false;
                cboBonds.Enabled = false;
                grpTensOptions.Enabled = false;
                grpGroupingsOptions.Enabled = false;
            }
            else if (rdoTimesTables.Checked)
            {
                grpAdditionAndSubtraction.Enabled = false;
                grpDoubles.Enabled = false;
                grpHalves.Enabled = false;
                grpTimesTables.Enabled = true;
                cboTimesTables.Enabled = true;
                cboTens.Enabled = false;
                cboBonds.Enabled = false;
                grpTensOptions.Enabled = false;
                grpGroupingsOptions.Enabled = false;
            } else if (rdoTens.Checked)
            {
                grpAdditionAndSubtraction.Enabled = false;
                grpDoubles.Enabled = false;
                grpHalves.Enabled = false;
                grpTimesTables.Enabled = false;
                cboTimesTables.Enabled = true;
                cboTens.Enabled = true;
                cboBonds.Enabled = false;
                grpTensOptions.Enabled = true;
                grpGroupingsOptions.Enabled = false;
            }
            else if (rdoBonds.Checked)
            {
                grpAdditionAndSubtraction.Enabled = false;
                grpDoubles.Enabled = false;
                grpHalves.Enabled = false;
                grpTimesTables.Enabled = false;
                cboTimesTables.Enabled = true;
                cboTens.Enabled = false;
                cboBonds.Enabled = true;
                grpTensOptions.Enabled = false;
                grpGroupingsOptions.Enabled = true;
            }
        }

        private void rdoTimesTables_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void rdoTens_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void rdoBonds_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void rdoDoubles_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void rdoHalf_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }
    }
}
