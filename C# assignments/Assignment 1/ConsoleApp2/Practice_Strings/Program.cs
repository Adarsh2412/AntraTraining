// See https://aka.ms/new-console-template for more information

void reverse_string()
{
    string input = Console.ReadLine();
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    Console.WriteLine(new string(charArray));
}

void reverse_words()
{
    string input = Console.ReadLine();
    char[] delimiters = { ' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', '\t', '\n' };

    List<string> words = new List<string>();
    List<char> separators = new List<char>();

    int start = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (Array.IndexOf(delimiters, input[i]) >= 0)
        {
            if (i > start)
            {
                words.Add(input.Substring(start, i - start));
            }
            separators.Add(input[i]);
            start = i + 1;
        }
    }

    if (start < input.Length)
    {
        words.Add(input.Substring(start));
    }

    words.Reverse();

    int wordIndex = 0, sepIndex = 0;
    bool isWord = true;

    for (int i = 0; i < input.Length; i++)
    {
        if (isWord && wordIndex < words.Count)
        {
            Console.Write(words[wordIndex]);
            i += words[wordIndex].Length - 1;
            wordIndex++;
            isWord = false;
        }
        else if (!isWord && sepIndex < separators.Count)
        {
            Console.Write(separators[sepIndex]);
            sepIndex++;
            isWord = true;
        }
    }

    Console.WriteLine();
}

void unique_palindromes()
{
    string input = Console.ReadLine();
    HashSet<string> palindromes = new HashSet<string>();
    List<string> words = new List<string>();

    int start = 0;

    for (int i = 0; i <= input.Length; i++)
    {
        if (i == input.Length || !char.IsLetterOrDigit(input[i]))
        {
            if (start < i)
            {
                words.Add(input.Substring(start, i - start));
            }
            start = i + 1;
        }
    }

    foreach (var word in words)
    {
        if (IsPalindrome(word))
        {
            palindromes.Add(word);
        }
    }

    Console.WriteLine(string.Join(", ", palindromes.OrderBy(x => x)));
}

static bool IsPalindrome(string s)
{
    int len = s.Length;
    for (int i = 0; i < len / 2; i++)
    {
        if (s[i] != s[len - 1 - i])
        {
            return false;
        }
    }
    return true;
}

void url_parsing()
{
    string input = Console.ReadLine();
    string protocol = "", server = "", resource = "";
        
    int protocolEndIndex = input.IndexOf("://");
    if (protocolEndIndex != -1)
    {
        protocol = input.Substring(0, protocolEndIndex);
        input = input.Substring(protocolEndIndex + 3);
    }

    int serverEndIndex = input.IndexOf('/');
    if (serverEndIndex != -1)
    {
        server = input.Substring(0, serverEndIndex);
        resource = input.Substring(serverEndIndex + 1);
    }
    else
    {
        server = input;
    }

    Console.WriteLine($"[protocol] = \"{protocol}\"");
    Console.WriteLine($"[server] = \"{server}\"");
    Console.WriteLine($"[resource] = \"{resource}\"");
}

reverse_string();
reverse_words();
unique_palindromes();
url_parsing();

