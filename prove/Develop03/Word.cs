public class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string word)
    {
        _word = word;
    }

    public void PrintWord()
    {
        if (!_isHidden)
        {
            Console.Write($"{_word} ");
        }
        else
        {
            foreach (char character in _word)
            {
                if (Char.IsLetter(character))
                {
                    Console.Write("?");
                }
                else
                {
                    Console.Write(character);
                }
            }
            Console.Write(" ");
        }
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public void RevealWord()
    {
        _isHidden = false;
    }
}