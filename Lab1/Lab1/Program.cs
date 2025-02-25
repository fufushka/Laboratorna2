
class Program
{
    static void Main()
    {

        List<int> list = new List<int>(); // cписок елементів
        for (int i = 1; i <= 100; i++) // заповнити числами від 1 до 100
        {
            list.Add(i);
        }


        PrintListSpiral(list); 

        


    static void PrintListSpiral(List<int> list)
        {
            int itemsPerRow = 10; 
            int totalRows = (int)Math.Ceiling((double)list.Count / itemsPerRow); // Загальна кількість рядків


            for (int i = 0; i < totalRows; i++)
            {
                int startIndex = i * itemsPerRow; // 0 * 10=0; 1 * 10 = 10 etc.
                int endIndex = Math.Min(startIndex + itemsPerRow, list.Count); //0 + 10 = 10 or 100(щоб не виходити за межі, якщо елементи не будуть ділитися націло totalRows)


                List<int> row = list.GetRange(startIndex, endIndex - startIndex);

                
                if (i % 2 == 1)
                {
                    row.Reverse(); // Якщо це парний рядок, розвертаємо його
                }

                // Виводимо рядок
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }

    
};
