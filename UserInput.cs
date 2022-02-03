using System;
using System.Text;
using System.Collections.Generic;

static class Utility
{
    public static void PrintTable(List<string[]> printData)
    {
        int rows = printData.Count;
        if (rows == 0) return;
        int cols = printData[0].Length;
        if (cols == 0) return;

        int[] colLengths = new int[cols];

        for (int i = 0; i < cols; i++)
        {
            int length = 0;
            for (int j = 0; j < rows; j++)
            {
                if (printData[j][i].Length > length) length = printData[j][i].Length;
            }
            colLengths[i] = length;
        }

        for (int i = 0; i < rows; i++)
        {
            string row = "";
            for (int j = 0; j < cols; j++)
            {
                if (j == 0) row += "|";
                row += $" {printData[i][j].PadLeft(colLengths[j])} |";
            }
            if (i == 0)
            {
                Console.WriteLine(new String('-', row.Length));
            }
            Console.WriteLine(row);
            if (i == 0 || i == rows - 1)
            {
                Console.WriteLine(new String('-', row.Length));
            }
        }
    }
}

static class Input
{
    public static string GetFieldSimple(string field, int minLength = 0, int maxLength = -1)
    {
        do
        {
            Console.Write($"{field}: ");
            string input = ReadLineWithCancel();
            if (input == null) return null;
            else if (input.Length < minLength) Console.WriteLine($"{field} must be at least {minLength} characters");
            else if (maxLength > minLength && input.Length > maxLength) Console.WriteLine($"{field} must be at most {maxLength} characters");
            else return input;
        } while (true);
    }

    public static string GetFieldDate(string field)
    {
        do
        {
            Console.Write($"{field}: ");
            string input = ReadLineWithCancel();
            if (input == null) return null;
            try
            {
                DateTime.Parse(input);
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid date {input}");
            }
        } while (true);
    }

    public static string GetFieldInt(string field, int min = int.MinValue, int max = int.MaxValue, bool errors = true)
    {
        do
        {
            Console.Write($"{field}: ");
            string input = ReadLineWithCancel();
            if (input == null) return null;
            try
            {
                int result = int.Parse(input);
                if (result < min) { if (errors) Console.WriteLine($"{field} must be at least {min}"); continue; }
                if (result > max) { if (errors) Console.WriteLine($"{field} must be at most {max}"); continue; }
                return input;
            }
            catch (FormatException)
            {
                if (errors) Console.WriteLine($"{field} must be an integer");
            }
        } while (true);
    }

    public static string GetFieldOptions(string[] options, string field = null, bool returnOptionName = true)
    {
        if (field != null) Console.WriteLine($"{field}:");
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($" {i + 1}. {options[i]}");
        }
        Console.Write(" > ");
        Console.CursorVisible = true;

        do
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Backspace || input.Key == ConsoleKey.Escape) { Console.CursorVisible = false; return null; }
            try
            {
                int option = int.Parse(input.KeyChar.ToString());
                if (option >= 1 && option <= options.Length)
                {
                    Console.WriteLine(options[option - 1].ToString());
                    if (returnOptionName) return options[option - 1].ToString();
                    Console.CursorVisible = false;
                    return option.ToString();
                }
            }
            catch (FormatException)
            {

            }
        } while (true);
    }

    public static string GetFieldDouble(string field, double min = double.MinValue, double max = double.MaxValue, bool errors = true)
    {
        do
        {
            Console.Write($"{field}: ");
            string input = ReadLineWithCancel();
            if (input == null) return null;
            try
            {
                double result = double.Parse(input);
                if (result < min) { if (errors) Console.WriteLine($"{field} must be at least {min}"); continue; }
                if (result > max) { if (errors) Console.WriteLine($"{field} must be at most {max}"); continue; }
                return input;
            }
            catch (FormatException)
            {
                if (errors) Console.WriteLine($"{field} must be numeric");
            }
        } while (true);
    }

    public static char GetKeyChar(char[] options)
    {
        List<char> optionsList = new List<char>(options);
        char input;
        do
        {
            input = Console.ReadKey(true).KeyChar;
        } while (!optionsList.Contains(input));
        return input;
    }

    public static void GetEnter()
    {
        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape && key != ConsoleKey.Backspace);
    }

    public static string ReadLineWithCancel()
    {
        // https://stackoverflow.com/questions/31996519/listen-on-esc-while-reading-console-line
        Console.CursorVisible = true;
        string result = null;

        StringBuilder buffer = new StringBuilder();

        ConsoleKeyInfo info = Console.ReadKey(true);
        while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
        {
            if (info.Key == ConsoleKey.Backspace)
            {
                if (buffer.Length > 0)
                {
                    buffer.Remove(buffer.Length - 1, 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
                else
                {
                    Console.CursorVisible = false;
                    return null;
                }
            }
            else
            {
                string item = System.Text.RegularExpressions.Regex.Replace(info.KeyChar.ToString(), @"\p{C}+", string.Empty);
                if (item.Length > 0)
                {
                    Console.Write(item);
                    buffer.Append(item);
                }
            }

            info = Console.ReadKey(true);
        }

        if (info.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            result = buffer.ToString();
        }

        Console.CursorVisible = false;
        return result;
    }

    public static string GetFieldPassword(string message = "Enter a password")
    {
        Console.Write($"{message}: ");
        string password = string.Empty;

        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
            else if (key == ConsoleKey.Escape)
            {
                return null;
            }
        } while (key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }
}
