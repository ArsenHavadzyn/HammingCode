using System.Text;


// Encoding function
string Encode(string input)
{
    byte[] bytes = Encoding.ASCII.GetBytes(input); // Step 1
    string[] binary = new string[bytes.Length];
    string tripled = "";
    for (int i = 0; i < bytes.Length; i++)
    {
        binary[i] = Convert.ToString(bytes[i], 2); // Step 2
    }
    for (int i = 0; i < binary.Length; i++)
    {
        for (int j = 0; j < binary[i].Length; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                tripled += binary[i][j]; // Steps 3 & 4
            }
        }
    }
    return tripled;
}


// Decoding function
string Decode(string input)
{
    List<string> groups = new List<string>();
    for (int i = 0; i < input.Length; i += 3)
    {
        groups.Add(input[i..(i + 3)]);  // Step 1
    }
    for (int i = 0; i < groups.Count; i++)
    {
        groups[i] = groups[i].Count(x => x == '1') == 2 || groups[i].Count(x => x == '1') == 3 ? "1" : "0"; // Step 2
    }
    string[] binary = new string[groups.Count / 7];
    int t = 0;
    for (int i = 0; i < groups.Count / 7; i++)
    {
        binary[i] += "0";
        while (t < groups.Count)
        {
            binary[i] += groups[t++]; // Step 3.1
            if ((t % 7 == 0) && t != 0) break;
        }
    }
    byte[] bytes = new byte[binary.Length];
    for (int i = 0; i < binary.Length; i++)
    {
        bytes[i] = Convert.ToByte(binary[i], 2);  // Step 3.2 
    }
    return System.Text.Encoding.UTF8.GetString(bytes); // Steps 4 & 5
}

// Testing
Console.Write("Введiть слово, яке бажаєте закодувати: ");
string input = Console.ReadLine();
string output = Encode(input);
string decoded = Decode(output);
Console.WriteLine($"Так виглядає ваше слово в кодi Хеммiнга:\n{output}");
Console.WriteLine($"Результат декодування: {decoded}");
