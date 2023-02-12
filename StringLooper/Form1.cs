using System.Text.RegularExpressions;

namespace StringLooper
{
    public partial class Form1 : Form
    {
        private string[] _largeAlphabet = new[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z"
        };

        private string[] _smallAlphabet = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
            "v", "w", "x", "y", "z"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text != string.Empty || !string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                if (!Regex.IsMatch(InputTextBox.Text, "^[a-zA-Z]*$"))
                {
                    MessageBox.Show(@"Invalid input.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OutputTextBox.Text = string.Empty;
                for (var i = 0; i < 26; i++)
                {
                    OutputTextBox.Text += i + @": ";
                    for (var j = 0; j < InputTextBox.Text.Length; j++)
                    {
                        var small = Array.IndexOf(_smallAlphabet, InputTextBox.Text[j].ToString());
                        var large = Array.IndexOf(_largeAlphabet, InputTextBox.Text[j].ToString());
                        if (small != -1)
                        {
                            if (small + i > 25)
                            {
                                OutputTextBox.Text += _smallAlphabet[small + i - 26];
                            }
                            else
                            {
                                OutputTextBox.Text += _smallAlphabet[small + i];
                            }
                        }

                        if (large == -1) continue;
                        if (large + i > 25)
                        {
                            OutputTextBox.Text += _largeAlphabet[large + i - 26];
                        }
                        else
                        {
                            OutputTextBox.Text += _largeAlphabet[large + i];
                        }
                    }

                    OutputTextBox.Text += Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show(@"Invalid input.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}