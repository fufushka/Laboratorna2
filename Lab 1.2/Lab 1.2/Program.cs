using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {

        //string path = @"C:\Users\dimau\source\repos\Lab 1.2\output.json";


        //Dictionary<string, List<string>> inputDict = new Dictionary<string, List<string>>()
        //{
        //    { "1", new List<string> { "A", "d" } },
        //    { "2", new List<string> { "C", "B" } }
        //};


        //List<string> combinations = GenerateCombinations(inputDict);


        //Console.WriteLine(string.Join(" ", combinations));


        //SaveToJsonFile(combinations, path);


        /////////////////////////////////////////////////////// TASK 3 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<string> A = new List<string> { "Elephant", "NewYork", "Ivory", "Apple", "Red", "Kite", "Umbrella" };


        var result = A
            .Select(s => s.First())   // Беремо перший символ кожного рядка
            .Distinct()               // Видаляємо дублікати
            .Reverse();               // Інвертуємо рядок

        // Вивід результату
        Console.WriteLine(string.Join("", result)); // Виведе "Ukraine"
    }

    static List<string> GenerateCombinations(Dictionary<string, List<string>> dict)
    {
        List<string> result = new List<string>();
        GenerateCombinationsRecursive(dict, new List<string>(dict.Keys), 0, "", result);
        return result;
    }

    static void GenerateCombinationsRecursive(
        Dictionary<string, List<string>> dict,
        List<string> keys,
        int depth,
        string currentCombination,
        List<string> result)
    {
        
        if (depth == keys.Count)
        {
           
         
           result.Add(currentCombination); // Якщо досягли глибини, додаємо комбінацію до результату
            return; // не виходить з функції цілком, а повертає назад
        }

       
        string key = keys[depth]; // який ключ ми зараз розглядаємо(спочатку keys[0] потім 1)
       

        
        foreach (string letter in dict[key]) // Перебираємо всі літери з масиву літер 
        {
           
            GenerateCombinationsRecursive(dict, keys, depth + 1, currentCombination + letter, result); // викликаємо для кожної літери ще одну рекурсію
        }
    }

    static void SaveToJsonFile(List<string> combinations, string path)
    {
        try
        {
            
            string json = JsonConvert.SerializeObject(combinations, Formatting.Indented); // Конвертуємо список у JSON

            
            File.WriteAllText(path, json); // Записуємо у файл
            Console.WriteLine($"Результат збережено у файл за шляхом: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час збереження JSON: {ex.Message}");
        }
    }
}
