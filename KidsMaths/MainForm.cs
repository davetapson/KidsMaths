using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KidsMaths
{
    public enum NumberToHide
    {
        Answer, First, Second
    }

    public partial class MainForm : Form
    {
        Sums _sums;
        bool formLoading = true;
        int numberOfQuestionsAnswered;
        List<SumDisplay> wrongSums = new List<SumDisplay>();
        SumDisplay sumDisplay;
        Random random = new Random();
        bool _doubles = false;

        SpeechSynthesizer synth = new SpeechSynthesizer();

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

        public bool TimesTables { get; internal set; }
        public int TimesTablesValue { get; internal set; }
        public bool TimesTablesInOrder { get; internal set; }
        public bool TimesTablesRandom { get; internal set; }
        public bool AdditionAndSubtraction { get; internal set; }
        public int DoublesRangeFrom { get; internal set; }
        public int DoublesRangeTo { get; internal set; }
        public bool Tens { get; internal set; }
        public int TensValue { get; internal set; }
        public bool Bonds { get; internal set; }
        public int BondsValue { get; internal set; }
        public int HalvesRangeFrom { get; internal set; }
        public int HalvesRangeTo { get; internal set; }
        public string ChildsName { get; internal set; }
        public int TensPattern { get; internal set; }
        public int GroupingsPattern { get; internal set; }
        public bool UseSpeechOutput { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //GetVoices();
            synth.SelectVoice("Microsoft Zira Desktop");

            _sums = new Sums();
            txtAnswer.Text = "";
            lblOperator.Text = "";

            PopulateControls();

            btnNext_Click(null, null);
            _sums._operator = Operator.Addition;
            txtPlus.BackColor = Color.LightGreen;

            formLoading = false;
        }

        private void GetVoices()
        {
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                VoiceInfo info = voice.VoiceInfo;
                string AudioFormats = "";
                foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                {
                    AudioFormats += String.Format("{0}\n",
                    fmt.EncodingFormat.ToString());
                }

                Console.WriteLine(" Name:          " + info.Name);
                Console.WriteLine(" Culture:       " + info.Culture);
                Console.WriteLine(" Age:           " + info.Age);
                Console.WriteLine(" Gender:        " + info.Gender);
                Console.WriteLine(" Description:   " + info.Description);
                Console.WriteLine(" ID:            " + info.Id);
                Console.WriteLine(" Enabled:       " + voice.Enabled);
                if (info.SupportedAudioFormats.Count != 0)
                {
                    Console.WriteLine(" Audio formats: " + AudioFormats);
                }
                else
                {
                    Console.WriteLine(" No supported audio formats found");
                }

                string AdditionalInfo = "";
                foreach (string key in info.AdditionalInfo.Keys)
                {
                    AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
                }

                Console.WriteLine(" Additional Info - " + AdditionalInfo);
                Console.WriteLine();
            }
        }

        private void PopulateControls()
        {
            //Addition and Subtraction
            AdditionAndSubtraction = Properties.Settings.Default.AdditionAndSubtraction;
            RangeFrom = Properties.Settings.Default.RangeFrom;
            RangeTo = Properties.Settings.Default.RangeTo;
            AddSubtrPattern = Properties.Settings.Default.AddSubtrPattern;

            // Times Tables
            TimesTables = Properties.Settings.Default.rdoTimesTables;
            TimesTablesValue = Properties.Settings.Default.cboTimesTables;
            TimesTablesInOrder = Properties.Settings.Default.TimesTableInOrder;
            TimesTablesRandom = Properties.Settings.Default.TimesTableRandom;

            // Tens
            Tens = Properties.Settings.Default.Tens;
            TensValue = Properties.Settings.Default.TensValue;

            // Groups / Bonds
            Bonds = Properties.Settings.Default.Bonds;
            BondsValue = Properties.Settings.Default.BondsValue;

            // Doubles
            Doubles = Properties.Settings.Default.rdoDoubles;
            DoublesRangeFrom = Properties.Settings.Default.DoublesRangeFrom;
            DoublesRangeTo = Properties.Settings.Default.DoublesRangeTo;

            // Halves
            Half = Properties.Settings.Default.rdoHalf;
            HalvesRangeFrom = Properties.Settings.Default.HalvesRangeFrom;
            HalvesRangeTo = Properties.Settings.Default.HalvesRangeTo;

            // Childs Name
            ChildsName = Properties.Settings.Default.ChildsName;

            // Voice output
            UseSpeechOutput = Properties.Settings.Default.UseVoiceOutput;

            ReSetForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextSum();
        }

        private void NextSum()
        {
            try
            {
                if (Doubles)
                {
                    _sums.RangeLow = DoublesRangeFrom;
                    _sums.RangeHigh = DoublesRangeTo;

                    sumDisplay = _sums.GetDouble();

                    SetDisplay(sumDisplay, NumberToHide.Answer);
                }
                else if (Half)
                {
                    _sums.RangeLow = HalvesRangeFrom;
                    _sums.RangeHigh = HalvesRangeTo;

                    sumDisplay = _sums.GetHalf();

                    txtHalfOf.Text = "Half of " + sumDisplay.FirstNumber + " ";
                    txtAnswer.Text = sumDisplay.Answer.ToString();

                    HideAnswer();
                }
                else if (TimesTables)
                {
                    if (TimesTablesRandom)
                    {
                        sumDisplay = _sums.GetTimesTables(TimesTablesValue);
                    }
                    else
                    {
                        int lastNumber = 0;

                        if (!string.IsNullOrWhiteSpace(txtFirstNumber.Text)) lastNumber = Convert.ToInt32(txtFirstNumber.Text);
                        if (!string.IsNullOrWhiteSpace(txtFirstNumber.Text) && (Convert.ToInt32(txtSecondNumber.Text) != TimesTablesValue)) lastNumber = 0;

                        if (lastNumber >= 12)
                        {
                            lastNumber = 1;
                        }
                        else
                        {
                            lastNumber++;
                        }

                        sumDisplay = new SumDisplay(lastNumber, TimesTablesValue, lastNumber * TimesTablesValue, Operator.Multiplication);
                    }

                    SetDisplay(sumDisplay, NumberToHide.Answer);
                }
                else if (Tens)
                {
                    sumDisplay = _sums.GetTens(TensValue);
                    SetDisplay(sumDisplay, TensPattern);
                }
                else if (Bonds)
                {
                    sumDisplay = _sums.GetGroupings(BondsValue);
                    //SetDisplay(sumDisplay, _sums._operator == Operator.Addition ? NumberToHide.Second : NumberToHide.Answer);
                    SetDisplay(sumDisplay, GroupingsPattern);
                }
                else if (AdditionAndSubtraction)
                {
                    _sums.RangeHigh = Convert.ToInt32(RangeTo);
                    _sums.RangeLow = Convert.ToInt32(RangeFrom);

                    sumDisplay = _sums.GetAdditionAndSubtraction();

                    SetDisplay(sumDisplay, AddSubtrPattern);
                }                    

                if (UseSpeechOutput)
                {
                    SayQuestion();
                }

                btnNext.Enabled = false;
                btnAnswer.Enabled = true;
                btnAnswer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPatternToDisplay(int pattern)
        {
            if (pattern == 1)
            {
                HideAnswer();
            }
            else if (pattern == 2)
            {
                HideSecondNumber();
            }
            else if (pattern == 3)
            {
                HideFirstNumber();
            }
            else if (pattern == 4)
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

        private void SayQuestion()
        {
            string speech = GetSpeech();

            ThreadPool.QueueUserWorkItem(delegate { synth.Speak(speech); }, null);            
        }

        private string GetSpeech()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!Half)
            {
                if (txtFirstNumber.Visible)
                {
                    stringBuilder.Append(txtFirstNumber.Text);
                }
                else
                {
                    stringBuilder.Append("what ");
                }

                switch (lblOperator.Text)
                {
                    case "+":
                        stringBuilder.Append(" plus ");
                        break;
                    case "-":
                        stringBuilder.Append(" minus ");
                        break;
                    case "x":
                        stringBuilder.Append(" times ");
                        break;
                    case "/":
                        stringBuilder.Append(" divided by ");
                        break;
                    default:
                        break;
                }

                if (txtSecondNumber.Visible)
                {
                    stringBuilder.Append(txtSecondNumber.Text);
                }
                else
                {
                    stringBuilder.Append(" what ");
                }

                stringBuilder.Append(" equals ");

                if (txtAnswer.Visible)
                {
                    stringBuilder.Append(txtAnswer.Text);
                }
                else
                {
                    stringBuilder.Append(" what ");
                } 
            }
            else
            {
                stringBuilder.Append(txtHalfOf.Text);
            }

            return stringBuilder.ToString();
        }

        private void SetDisplay(SumDisplay sumDisplay, NumberToHide answer)
        {
            // todo - set + - icons accordign to option
            txtFirstNumber.Text = sumDisplay.FirstNumber.ToString();
            txtSecondNumber.Text = sumDisplay.SecondNumber.ToString();
            txtAnswer.Text = sumDisplay.Answer.ToString();
            lblOperator.Text = sumDisplay.Operator;            

            switch (answer)
            {
                case NumberToHide.Answer:
                    HideAnswer();
                    break;
                case NumberToHide.First:
                    HideFirstNumber();
                    break;
                case NumberToHide.Second:
                    HideSecondNumber();
                    break;
                default:
                    break;
            }
        }

        private void SetDisplay(SumDisplay sumDisplay, int displayPattern)
        {
            // todo - set + - icons accordign to option
            txtFirstNumber.Text = sumDisplay.FirstNumber.ToString();
            txtSecondNumber.Text = sumDisplay.SecondNumber.ToString();
            txtAnswer.Text = sumDisplay.Answer.ToString();
            lblOperator.Text = sumDisplay.Operator;

            ApplyPatternToDisplay(displayPattern);
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
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            AnswerPressed();
        }

        private void AnswerPressed()
        {
            string speech = "";

            // speech
            if (UseSpeechOutput)
            {
                if (!Half)
                {

                    if (!txtFirstNumber.Visible)
                    {
                        speech = txtFirstNumber.Text;
                    }
                    else if (!txtSecondNumber.Visible)
                    {
                        speech = txtSecondNumber.Text;
                    }
                    else
                    {
                        speech = txtAnswer.Text;
                    }
                }
                else
                {
                    speech = txtAnswer.Text;
                }
            }
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

            if(speech != "") synth.Speak(speech);

        }

        private void txtPlus_Click(object sender, EventArgs e)
        {
            SetPlusOptions();
        }

        private void SetPlusOptions()
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
            SetMinusOptions();
        }

        private void SetMinusOptions()
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
            // Addition and Subtraction
            Properties.Settings.Default.AdditionAndSubtraction = AdditionAndSubtraction;
            Properties.Settings.Default.RangeFrom = Convert.ToInt32(RangeFrom);
            Properties.Settings.Default.RangeTo = Convert.ToInt32(RangeTo);

            Properties.Settings.Default.AddSubtrPattern = AddSubtrPattern;

            // Times Tables
            Properties.Settings.Default.rdoTimesTables = TimesTables;
            Properties.Settings.Default.cboTimesTables = Convert.ToInt32(TimesTablesValue);
            Properties.Settings.Default.TimesTableInOrder = TimesTablesInOrder;
            Properties.Settings.Default.TimesTableRandom = TimesTablesRandom;

            // Tens
            Properties.Settings.Default.Tens = Tens;
            Properties.Settings.Default.TensValue = TensValue;
            Properties.Settings.Default.TensPattern = TensPattern;

            // Groups / Bonds
            Properties.Settings.Default.Bonds = Bonds;
            Properties.Settings.Default.BondsValue = BondsValue;
            Properties.Settings.Default.GroupingsPattern = GroupingsPattern;

            // Doubles
            Properties.Settings.Default.rdoDoubles = Doubles;
            Properties.Settings.Default.DoublesRangeFrom = DoublesRangeFrom;
            Properties.Settings.Default.DoublesRangeTo = DoublesRangeTo;

            // Halves
            Properties.Settings.Default.rdoHalf = Half;
            Properties.Settings.Default.HalvesRangeFrom = HalvesRangeFrom;
            Properties.Settings.Default.HalvesRangeTo = HalvesRangeTo;

            // Childs Name
            Properties.Settings.Default.ChildsName = ChildsName;

            // Voice Output
            Properties.Settings.Default.UseVoiceOutput = UseSpeechOutput;

            Properties.Settings.Default.Save();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptionsForm();
        }

        private void ShowOptionsForm()
        {
            OptionsForm optionsForm = new OptionsForm(this);
            optionsForm.ShowDialog();
            ReSetForm();
            NextSum();
        }

        private void ReSetForm()
        {
            string title = ChildsName + " Maths: ";

            if (AdditionAndSubtraction)
            {
                Text = title + "Addition & Subtraction from " + RangeFrom + " to " + RangeTo;
                EnableOperators(true);
            }
            else if (TimesTables) {
                Text = title + "Times Tables of " + TimesTablesValue;
                EnableOperators(false);
            }
            else if (Tens) {
                Text = title + "Tens to " + TensValue;
                EnableOperators(true);
            }
            else if (Bonds) {
                Text = title + "Groups / Bonds of " + BondsValue;
                EnableOperators(true);
            }
            else if (Doubles) {
                Text = title + "Doubles from " + DoublesRangeFrom + " to " + DoublesRangeTo;
                EnableOperators(false);
            }
            else if (Half) {
                Text = title + "Halves from " + HalvesRangeFrom + " to " + HalvesRangeTo;
                EnableOperators(false);
            }

            if (!Half) lblOperator.Visible = true;
        }

        private void EnableOperators(bool enable)
        {
            txtPlus.Enabled = enable;
            txtMinus.Enabled = enable;
        }

        private void txtPlus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
