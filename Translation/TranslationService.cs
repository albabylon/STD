using System.Collections.Generic;

namespace Translator.Test
{
    public class TranslationService
    {
        public Dictionary<string, string> Translator;
        public TranslationService()
        {
            Translator = new Dictionary<string, string>();
        }

        public void AddTranslation(string word1, string word2)
        {
            //2 шаг TDD
            //return;

            //3 шаг TDD
            Translator.Add(word1, word2);
        }

        public string GetTranslation(string word)
        {
            //2 шаг TDD
            //return "апельсин";

            //3 шаг TDD
            return Translator[word];
        }
    }
}