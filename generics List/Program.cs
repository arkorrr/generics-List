//Создайте приложение «Англо-украинский словарь», которое имеет
//сохранять следующую информацию:
// слово на английском языке;
// варианты перевода на украинский.
//Для хранения информации используйте Dictionary<T>.
//Приложение должно придавать такую ​​функциональность:
//  добавить слово и варианты перевода;
//  удалить слово;
// удалить варианты перевода; смена слова;
// изменение варианта перевода;
// поиск перевода слова.

using System.Collections;
using System.Collections.Generic;

class Dictionary
{
    List<Dictionary<string, List<string>>> listOfDictionaries = new List<Dictionary<string, List<string>>>();

    static void AddTranslation(Dictionary<string, List<string>> dictionary, string word, string translation)
    {
        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Add(translation);
        }
        else
        {
            dictionary[word] = new List<string> { translation };
        }
    }
    static void ReplaceWord(Dictionary<string, List<string>> dictionary, string oldWord, string newWord)
    {
        if (dictionary.ContainsKey(oldWord))
        {
            var translations = dictionary[oldWord];
            dictionary.Remove(oldWord);
            dictionary[newWord] = translations;
        }
    }
    static void RemoveTranslation(Dictionary<string, List<string>> dictionary, string word, string translation)
    {
        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Remove(translation);
            if (dictionary[word].Count == 0)
            {
                dictionary.Remove(word);
            }
        }
    }
    static void SearchTranslation(Dictionary<string, List<string>> dictionary, string word)
    {
        if (dictionary.ContainsKey(word))
        {
            Console.WriteLine(dictionary[word]);
        }
    }
    static void PrintAll(Dictionary<string, List<string>> dictionary)
    {
        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
        }
    }
    //Task2
    public static T Max<T>(T a, T b, T c) where T : IComparable<T>
    {
        T max = a;
        if (b.CompareTo(max) > 0)
        {
            max = b;
        }
        if (c.CompareTo(max) > 0)
        {
            max = c;
        }
        return max;
    }
    //Task3
    public class SeaCreature
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Habitat { get; set; }

        public SeaCreature(string name, string species, string habitat)
        {
            Name = name;
            Species = species;
            Habitat = habitat;
        }

        public override string ToString()
        {
            return $"{Name} ({Species}), Habitat: {Habitat}";
        }
    }
    public class Oceanarium : IEnumerable<SeaCreature>
    {
        private List<SeaCreature> seaCreatures = new List<SeaCreature>();

        public void AddSeaCreature(SeaCreature seaCreature)
        {
            seaCreatures.Add(seaCreature);
        }

        public IEnumerator<SeaCreature> GetEnumerator()
        {
            return seaCreatures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static void Main(string[] args)
        {
            //Task1
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>
        {
            {"hello", new List<string> {"привет", "здравствуйте"}},
            {"world", new List<string> {"мир", "свет"}}
        };
            AddTranslation(dictionary, "hello", "хай");
            ReplaceWord(dictionary, "world", "земля");
            RemoveTranslation(dictionary, "hello", "привет");
            SearchTranslation(dictionary, "земля");
            PrintAll(dictionary);
            //Task2
            int num1 = 10;
            int num2 = 20;
            int num3 = 15;
            int maxInt = Max(num1, num2, num3);
            Console.WriteLine($"Максимальное из трех целых чисел: {maxInt}");

            //Task3
            Oceanarium oceanarium = new Oceanarium();

            oceanarium.AddSeaCreature(new SeaCreature("Dolphin", "Delphinus", "Ocean"));
            oceanarium.AddSeaCreature(new SeaCreature("Shark", "Carcharodon carcharias", "Ocean"));
            oceanarium.AddSeaCreature(new SeaCreature("Octopus", "Octopus vulgaris", "Ocean"));

            foreach (var creature in oceanarium)
            {
                Console.WriteLine(creature);
            }
        }
    }
}
