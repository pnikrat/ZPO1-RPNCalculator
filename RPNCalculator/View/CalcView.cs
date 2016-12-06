﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPNCalculator.View;
using RPNCalculator.Presenter;
using System.Threading;

namespace RPNCalculator
{
    public partial class CalcView : Form, ICalcView
    {
        private String decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public event EventHandler<EventArgs<String>> StackPush;
        public event EventHandler Addition;

        public CalcView()
        {
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            SetTextCurrentNumber("");
            ClearStackValues();
        }

        private void DisplayCurrentNumber(String value)
        {
            CurrentNumber.Text += value;
        }

        public void SetTextCurrentNumber(String value)
        {
            CurrentNumber.Text = value;
        }

        public void ClearStackValues()
        {
            SetTextL1StackValue("");
            SetTextL2StackValue("");
            SetTextL3StackValue("");
            SetTextL4StackValue("");
        }

        public void SetTextL1StackValue(String value)
        {
            L1StackValue.Text = value;
        }

        public void SetTextL2StackValue(String value)
        {
            L2StackValue.Text = value;
        }

        public void SetTextL3StackValue(String value)
        {
            L3StackValue.Text = value;
        }

        public void SetTextL4StackValue(String value)
        {
            L4StackValue.Text = value;
        }

        //public CalcPresenter _presenter    
        //{ private get; set; }

        protected virtual void OnStackPush(EventArgs<String> args)
        {
            var eventHandler = this.StackPush;
            if (eventHandler != null)
                eventHandler.Invoke(this, args);
        }

        protected virtual void OnAddition()
        {
            var eventHandler = this.Addition;
            if (eventHandler != null)
                eventHandler.Invoke(this, null);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D1 || keyData == Keys.NumPad1)
            {
                OneButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D2 || keyData == Keys.NumPad2)
            {
                TwoButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D0 || keyData == Keys.NumPad0)
            {
                ZeroButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D3 || keyData == Keys.NumPad3)
            {
                ThreeButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D4 || keyData == Keys.NumPad4)
            {
                FourButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.D5 || keyData == Keys.NumPad5)
            {
                FiveButton_Click(this, null);
            }
            else if (keyData == Keys.D6 || keyData == Keys.NumPad6)
            {
                SixButton_Click(this, null);
            }
            else if (keyData == Keys.D7 || keyData == Keys.NumPad7)
            {
                SevenButton_Click(this, null);
            }
            else if (keyData == Keys.D8 || keyData == Keys.NumPad8)
            {
                EightButton_Click(this, null);
            }
            else if (keyData == Keys.D9 || keyData == Keys.NumPad9)
            {
                NineButton_Click(this, null);
            }
            else if (keyData == Keys.OemPeriod || keyData == Keys.Decimal)
            {
                DecimalMarkButton_Click(this, null);
            }
            else if (keyData == Keys.Enter)
            {
                EnterButton_Click(this, null);
                return true;
            }
            else if (keyData == Keys.Add || keyData == (Keys.Shift | Keys.Oemplus))
            {
                AddButton_Click(this, null);
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("1");
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            OnStackPush(new EventArgs<String>(CurrentNumber.Text));
            SetTextCurrentNumber("");
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("2");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            OnAddition();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("0");
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("3");
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("4");
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("5");
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("6");
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("7");
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("8");
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            DisplayCurrentNumber("9");
        }

        private void DecimalMarkButton_Click(object sender, EventArgs e)
        {
            if (!CurrentNumber.Text.Contains(decimalSeparator) && CurrentNumber.Text.Length > 0)               
                DisplayCurrentNumber(decimalSeparator);
        }
    }
}