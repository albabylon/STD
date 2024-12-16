using System;

public class SurnamesReader
{
    public delegate void SortSurnames(string[] surnames, int value);
    public event SortSurnames SortSurnamesEvent;

    private string[] surnames;

    public SurnamesReader()
    {
        string[] surnames = new string[5];

        Console.WriteLine($"Необходимо ввести 5 фамилий");
        for (int i = 0; i < surnames.Length; i++)
        {
            Console.WriteLine($"Введите фамилию {i + 1}:");

            string enteredSurname = Console.ReadLine();
            surnames[i] = enteredSurname;
        }

        this.surnames = surnames;
    }

    public void GetSortedSurnames()
    {
        Console.WriteLine($"Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");

        string enteredValue = Console.ReadLine();
        if (int.TryParse(enteredValue, out int value))
        {
            if (value != 1 && value != 2)
                throw new FormatException("Было введено число не равное 1 или 2\nПрограмма будет закрыта");
        }
        else
            throw new FormatException("Были неверно введены данные для сортировки\nПрограмма будет закрыта");

        SortTypeEntered(surnames, value);
    }

    private void SortTypeEntered(string[] surnames, int value)
    {
        SortSurnamesEvent?.Invoke(surnames, value);
    }
}
