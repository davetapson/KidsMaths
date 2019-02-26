using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KidsMaths
{
    public partial class MainForm : Form
    {
        Sums _sums;
        bool formLoading = true;
        int numberOfQuestionsAnswered;
        List<SumDisplay> wrongSums = new List<SumDisplay>();
        SumDisplay sumDisplay;
        Random random = new Random();
        bool _doubles = false;

        public int RangeTo { get; internal set; }
        public int RangeFrom { get; internal set; }
        public int AddSubtrPattern { get; internal set; }
        public bool Half { get; internal set; }
        public bool Doubles {
            get {
                return _doubles;
            }
            set {
                txtMinus.Enabled = !value;
                txtPlus.Enabled = !value;
                _doubles = value;
            } }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _sums = new Sums();
            txtAnswer.Text = "";
            lblOperator.Text = "";

            PopulateControls();

            btnNext_Click(null, null);
            _sums._operator = Operator.Addition;
            txtPlus.BackColor = Color.LightGreen;

            
            formLoading = false;
        }

        private void PopulateControls()
        {
            RangeFrom = Properties.Settings.Default.RangeFrom;
            RangeTo = Properties.Settings.Default.RangeTo;
            AddSubtrPattern = Properties.Settings.Default.AddSubtrPattern;
            Half = Properties.Settings.Default.rdoHalf;
            Doubles = Properties.Settings.Default.rdoDoubles;            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextSum();
        }

        private void NextSum()
        {
            _sums.RangeHigh = Convert.ToInt32(RangeTo);
            _sums.RangeLow = Convert.ToInt32(RangeFrom);

            if (Doubles)
            {
                sumDisplay = _sums.GetDouble();

                txtFirstNumber.Text = sumDisplay.FirstNumber.ToString();
                txtSecondNumber.Text = sumDisplay.SecondNumber.ToString();
                txtAnswer.Text = sumDisplay.Answer.ToString();
                lblOperator.Text = sumDisplay.Operator;

                HideAnswer();
            }
            else if (Half)
            {
                sumDisplay = _sums.GetHalf();

                txtHalfOf.Text = "Half of " + sumDisplay.FirstNumber + " ";
                txtAnswer.Text = sumDisplay.Answer.ToString();

                HideAnswer();
            }
            else
            {
                sumDisplay = _sums.Get();

                txtFirstNumber.Text = sumDisplay.FirstNumber.ToString();
                txtSecondNumber.Text = sumDisplay.SecondNumber.ToString();
                txtAnswer.Text = sumDisplay.Answer.ToString();
                lblOperator.Text = sumDisplay.Operator;

                if (AddSubtrPattern == 1)
                {
                    HideAnswer();
                }
                else if (AddSubtrPattern == 2)
                {
                    HideSecondNumber();
                }
                else if (AddSubtrPattern == 3)
                {
                    HideFirstNumber();
                }
                else if (AddSubtrPattern == 4)
                {
                    int option = random.Next(0, 3);

                    switch (option)
                    {
                        case 0:
                            HideFirstNumber();
                            break;
                        case 1:
                            HideSecondNumber();
                            break;
                        case 2:
                            HideAnswer();
                            break;
                        default:
                            HideAnswer();
                            break;
                    }
                } 
            }

            btnNext.Enabled = false;
            btnAnswer.Enabled = true;
            btnAnswer.Focus();
        }

        private void HideHalfOfTextBox(bool hide)
        {
            txtFirstNumber.Visible = hide;
            txtSecondNumber.Visible = hide;
            lblOperator.Visible = hide;
            txtHalfOf.Visible = !hide;

            if (hide)
            {
                txtHalfOf.SendToBack();
            }
            else
            {
                txtFirstNumber.SendToBack();
                txtSecondNumber.SendToBack();
                lblOperator.SendToBack();
            }
        }

        private void HideFirstNumber()
        {
            txtHalfOf.Visible = false;
            txtFirstNumber.Visible = false;
            txtSecondNumber.Visible = true;
            txtAnswer.Visible = true;
            //lblEquals.Visible = txtAnswer.Visible;
        }

        private void HideSecondNumber()
        {
            txtHalfOf.Visible = false;
            txtFirstNumber.Visible = true;
            txtSecondNumber.Visible = false;
            txtAnswer.Visible = true;
            //lblEquals.Visible = txtAnswer.Visible;
        }

        private void HideAnswer()
        {
            if (Half)
            {
                txtHalfOf.Visible = true;
                txtFirstNumber.Visible = false;
                lblOperator.Visible = false;
                txtSecondNumber.Visible = false;
            }
            else
            {
                txtHalfOf.Visible = false;
                txtFirstNumber.Visible = true;
                lblOperator.Visible = true;
                txtSecondNumber.Visible = true;
            }
            
            txtAnswer.Visible = false;
            //lblEquals.Visible = txtAnswer.Visible;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            AnswerPressed();
        }

        private void AnswerPressed()
        {
            txtAnswer.Visible = true;
            //lblEquals.Visible = txtAnswer.Visible;
            if (!Half)
            {
                txtHalfOf.Visible = false;
                txtFirstNumber.Visible = true;
                txtSecondNumber.Visible = true;
            }
                        
            if (!formLoading) btnNext.Visible = true;

            btnAnswer.Enabled = false;
            btnNext.Enabled = true;
            btnNext.Focus();
            numberOfQuestionsAnswered++;
            sslNumberOfQuestionsAnswered.Text = numberOfQuestionsAnswered.ToString();
        }

        private void txtPlus_Click(object sender, EventArgs e)
        {
            if (txtPlus.BackColor == Color.LightGreen) return;

            _sums._operator = Operator.Addition;
            lblOperator.Text = "+";
            lblOperator.Left = lblOperator.Left - 11;
            txtPlus.BackColor = Color.LightGreen;
            txtMinus.BackColor = Color.White;
            NextSum();
            btnAnswer.Focus();
        }

        private void txtMinus_Click(object sender, EventArgs e)
        {
            if (txtMinus.BackColor == Color.LightGreen) return;
            _sums._operator = Operator.Subtraction;
            lblOperator.Text = "-";
            lblOperator.Left = lblOperator.Left + 11;
            txtMinus.BackColor = Color.LightGreen;
            txtPlus.BackColor = Color.White;
            NextSum();
            btnAnswer.Focus();
        }

        private void btnWrong_Click(object sender, EventArgs e)
        {
            wrongSums.Add(sumDisplay);
            sslNumWrongAnswers.Text = wrongSums.Count.ToString();
            NextSum();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserSettings();
        }

        private void SaveUserSettings()
        {
            Properties.Settings.Default.RangeFrom = Convert.ToInt32(RangeFrom);
            Properties.Settings.Default.RangeTo = Convert.ToInt32(RangeTo);

            Properties.Settings.Default.AddSubtrPattern = AddSubtrPattern;
            
            Properties.Settings.Default.rdoDoubles = Doubles;
            Properties.Settings.Default.rdoHalf = Half;


            Properties.Settings.Default.Save();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(this);
            optionsForm.ShowDialog();
        }
    }
}
