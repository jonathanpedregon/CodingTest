using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Program1
{
    public partial class Form1 : Form
    {
        private string Input { get; set; }
        private IEnumerable<char> LowerCaseChars { get; set; }
        private IGrouping<char, char> MostCommonCharGrouping { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Input = inputBox.Text;
            FindLowerCaseCharacters();
            FindMostCommonCharGrouping();
            PrintResults();
        }
        private void FindLowerCaseCharacters()
        {
            LowerCaseChars = from character in Input
                             where char.IsLower(character)
                             select character;
        }

        private void FindMostCommonCharGrouping()
        {
            //This will ONLY find one character. 
            //If there is a tie for the highest occurences this will only print the first one.
            MostCommonCharGrouping = LowerCaseChars.GroupBy(c => c).OrderByDescending(x => x.Count()).First();
        }

        private void PrintResults()
        {
            var mostCommonChar = MostCommonCharGrouping.Key;
            var mostCommonOccurrenceCount = MostCommonCharGrouping.Count();
            var occurrenceString = mostCommonOccurrenceCount > 1 ? "occurrences" : "occurrence";
            var outputString = $"{mostCommonChar} was the most common character, with {mostCommonOccurrenceCount}"
            + $" {occurrenceString}";

            outputTextBox.Text = outputString;
        }
    }
}
