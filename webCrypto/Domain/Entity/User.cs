namespace Domain.Entity;
public class Crypto
{
    string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    public int Id { get; set; }

    public string? Original { get; set; }

    public string? Coded { get; set; }

    public int Key { get; set; }


    public string codeDecode(string? word, int key)
    {

        string newWord = "";
        string fullAlphabet = alphabet + alphabet.ToLower();
        int alphabetLength = fullAlphabet.Length;
        foreach (char c in word)
        {
            int index = fullAlphabet.IndexOf(c);
            if (index < 0)
            {
                newWord += c;
            }
            else
            {
                char codedLetter = fullAlphabet[(alphabetLength + index + key) % alphabetLength];
                newWord += codedLetter;
            }
        }
        if (Coded == null)
        {
            Coded = newWord;
        }
        else if (Original == null)
        {
            Original = newWord;
        }
        return newWord;
    }

    public string codeWord()
    {
        return codeDecode(Original, Key);
    }

    public string decodeWord(string? coded)
    {
        return codeDecode(coded, -Key);
    }
}
