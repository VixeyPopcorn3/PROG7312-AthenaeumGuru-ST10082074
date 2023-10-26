using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_AthenaeumGuru_ST10082074.Classes
{
    internal class IdentifyingAreas
    {

        private Dictionary<string, string> deweyDecDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> displayedQDictionary = new Dictionary<string, string>();

        public IdentifyingAreas()
        {
            DeweyDecsDictionary.Add("000-099", "General Knowledge");
            DeweyDecsDictionary.Add("100-199", "Philosophy and Psychology");
            DeweyDecsDictionary.Add("200-299", "Religions and Mythology");
            DeweyDecsDictionary.Add("300-399", "Social Sciences and Folklore");
            DeweyDecsDictionary.Add("400-499", "Languages and Grammer");
            DeweyDecsDictionary.Add("500-599", "Mathematics and Science");
            DeweyDecsDictionary.Add("600-699", "Medicine and Technology");
            DeweyDecsDictionary.Add("700-799", "Arts and Recreation");
            DeweyDecsDictionary.Add("800-899", "Literature");
            DeweyDecsDictionary.Add("900-999", "Geography and History");
            SetupMatchingGame();
        }

        public Dictionary<string, string> DisplayedQDictionary { get => displayedQDictionary; set => displayedQDictionary = value; }
        public Dictionary<string, string> DeweyDecsDictionary { get => deweyDecDictionary; set => deweyDecDictionary = value; }
        public Dictionary<string, string> questionsColumn = new Dictionary<string, string>();
        public Dictionary<string, string> incorectAnsColumn = new Dictionary<string, string>();

        public void SetupMatchingGame()
        {
            // First, clear both columns.
            questionsColumn.Clear();
            incorectAnsColumn.Clear();

            //var identifyingAreas = new IdentifyingAreas(); // Initialize your IdentifyingAreas class

            var keysToChooseFrom = this.DeweyDecsDictionary.Keys.ToList();
            var random = new Random();

            // Get 4 unique random items from deweyDecDictionary for the left column.
            while (questionsColumn.Count < 4 && keysToChooseFrom.Count > 0)
            {
                int index = random.Next(0, keysToChooseFrom.Count);
                string key = keysToChooseFrom[index];
                string value = this.DeweyDecsDictionary[key];

                questionsColumn.Add(key, value);
                keysToChooseFrom.RemoveAt(index);
            }

            // Get 3 unique incorrect answers for the right column.
            keysToChooseFrom = this.DeweyDecsDictionary.Keys.ToList(); // Reset the keys.

            while (incorectAnsColumn.Count < 3 && keysToChooseFrom.Count > 0)
            {
                int index = random.Next(0, keysToChooseFrom.Count);
                string key = keysToChooseFrom[index];

                // Ensure that the key is not in the left column.
                if (!questionsColumn.ContainsKey(key))
                {
                    string value = this.DeweyDecsDictionary[key];
                    incorectAnsColumn.Add(key, value);
                }

                keysToChooseFrom.RemoveAt(index);
            }

            // Now, you have two dictionaries: leftColumn and rightColumn with unique items.
        }
    }
}
