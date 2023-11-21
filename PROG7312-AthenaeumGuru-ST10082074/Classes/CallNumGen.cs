using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_AthenaeumGuru_ST10082074.Classes
{
    internal class CallNumGen
    {
        private List<string> callNums = new List<string>();
        private List<string> orderSorted = new List<string>();

        private Random random = new Random();

        public CallNumGen()
        {

        }

        //Generate 10 Random Library Call Numbers 
        public List<string> GenerateList()
        {
            String sub;
            String Hold;

            for (int i = 0; i < 10; i++)
            {
                String Auth = "";

                double TopicWholeNum = random.Next(0, 999);
                double TopicDecimalNum = random.NextDouble();
                double TopicNum = Math.Round(TopicWholeNum + TopicDecimalNum, 2);
                //Dewey_Decimal CallingNumber = new Dewey_Decimal();


                for (int n = 0; n < 3; n++)
                {
                    char randomLetter = (char)random.Next('A', 'Z' + 1);
                    Auth += randomLetter;
                }

                sub = TopicNum.ToString();

                if ((sub.Substring(0, 2)).Contains(","))
                {
                    Hold = "00" + TopicNum.ToString() + " " + Auth.ToString();
                }
                else if ((sub.Substring(0, 3)).Contains(","))
                {
                    Hold = "0" + TopicNum.ToString() + " " + Auth.ToString();
                }
                else
                {
                    Hold = TopicNum.ToString() + " " + Auth.ToString();
                }

                callNums.Add(Hold);
            }
            return callNums;

        }

        //Sorts Call Numbers to compare later stores in list
        public List<string> SortedList()
        {
            List<string> sortList = callNums.ToList();
            sortList.Sort();
            return sortList;
        }

        //list storing the srted order
        public List<string> SortedOrder()
        {
            int Count = -1;
            //string nums =
            //orderSorted

            foreach (string b in callNums)
            {
                Count = -1;
                foreach (string s in SortedList())
                {//orderSorted.Add("Book" + Count.ToString());
                    Count++;
                    if (b.Equals(s))
                    {
                        switch (Count)
                        {
                            case 0:
                                orderSorted.Add("0"); break;
                            case 1:
                                orderSorted.Add("102"); break;
                            case 2:
                                orderSorted.Add("204"); break;
                            case 3:
                                orderSorted.Add("306"); break;
                            case 4:
                                orderSorted.Add("408"); break;
                            case 5:
                                orderSorted.Add("510"); break;
                            case 6:
                                orderSorted.Add("612"); break;
                            case 7:
                                orderSorted.Add("714"); break;
                            case 8:
                                orderSorted.Add("816"); break;
                            case 9:
                                orderSorted.Add("918"); break;
                        }


                    }
                }
            }
            return orderSorted;
        }

        //Checks the users highscore
        public string CheckHighScore(int HighScore, int Score)
        {
            if (HighScore < Score)
            {
                HighScore = Score;
                return $"Your HighScore: {HighScore}/10";
            }
            return "Your HighScore";
        }
    }
}
