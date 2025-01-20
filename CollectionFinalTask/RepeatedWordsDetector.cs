using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionFinalTask
{
    public class RepeatedWordsDetector
    {
        private Dictionary<string, int> uinqWordsDic;
        private string text;

        public RepeatedWordsDetector(string text)
        {
            uinqWordsDic = new Dictionary<string, int>();
            this.text = text;
        }

        public void GetUniqWords()
        {
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = noPunctuationText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            uinqWordsDic = words.Select(w => w.ToUpper()).GroupBy(word => word).ToDictionary(k => k.Key, v => v.Count()).OrderByDescending(p => p.Value).ToDictionary(k => k.Key, v => v.Value);
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("САМЫЕ ЧАСТО ВСТРЕЧАЕМЫ СЛОВА:");
            Console.WriteLine();

            int counter = 0;

            // Можно сделать через Linq .Take(10)
            while (counter < 10)
            {
                string word = uinqWordsDic.Keys.ElementAt(counter);
                int number = uinqWordsDic.Values.ElementAt(counter);

                Console.WriteLine($"{counter + 1}. {word}: {number} раз");

                counter++;
            }
        }
    }
}
