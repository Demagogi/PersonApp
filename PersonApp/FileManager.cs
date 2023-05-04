using System.IO;

public static class FileManager
{
    private static string path = ""; // Put Path to .txt file here

    public static void Sw(string data)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(data);
        }
    }

    public static string Sr()
    {
        string data = "";
        using (StreamReader sr = new StreamReader(path))
        {
            data = sr.ReadLine();
        }
        return data;
    }
}