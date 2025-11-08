using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        // Guardamos usando un separador que no choque con el contenido
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 3) return null;

        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];

        Entry entry = new Entry(prompt, response);
        entry._date = date; // restauramos la fecha original
        return entry;
    }
}
