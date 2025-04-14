namespace Stack
{
    internal class Program
    {
        static void Main()
        {

            // Основное задание:

            var s = new Stack("a", "b", "c");
            // Вывод: "size = 3, Top = 'c'"
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            var deleted = s.Pop();
            // Вывод: "Извлек верхний элемент 'c' Size = 2"
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");

            s.Add("d");
            // Вывод: "size = 3, Top = 'd'"
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            try
            {
                s.Pop();
                s.Pop();
                s.Pop();
                // Вывод: "size = 0, Top = null"
                Console.WriteLine($"size = {s.Size}, Top = {(s.Top ?? "null")}");
                // Вывод перехвата исключения: "Стек пуст"
                s.Pop();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            
            // Доп. задание #1:

            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));

            // В стеке s1 элементы - "a", "b", "c", "3", "2", "1" <- верхний
            // Вывод: "s1: size = 6, Top = '1'"
            Console.WriteLine($"s1: size = {s1.Size}, Top = '{s1.Top}'");


            // Доп. задание #2:

            var s2 = Stack.Concate(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            
            // В стеке s2 элементы -  "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
            // Вывод: "s2: size = 9, Top = 'А'"
            Console.WriteLine($"s2: size = {s2.Size}, Top = '{s2.Top}'");

            
            // Доп. задание #3: стек изначально реализован по условию доп. задания #3
        }
    }
}
