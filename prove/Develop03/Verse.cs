public class Verse
{
    private List<Word> _textList = new List<Word>();
    private int _verseNum;
    
    public Verse(string verse)
    {
        _verseNum = int.Parse(verse.Split(' ')[0]);
        string[] trimmedVerse = verse.Split(' ').Skip(1).ToArray();
        foreach (string word in trimmedVerse)
        {
            Word wordObj = new Word(word);
            _textList.Add(wordObj);
        }
    }
    public void PrintVerse()
    {
        Console.Write($"{_verseNum}  ");
        foreach (Word word in _textList)
        {
            word.PrintWord();
        }
    }

    public int CountWords()
    {
        return _textList.Count;
    }

    public bool HideWord(Random random)
    {
        bool successfulHide = false;
        int hideAttempts = 0;
        do
        {
            int wordToHide = random.Next(_textList.Count);
            if (!_textList[wordToHide].GetIsHidden())
            {
                _textList[wordToHide].HideWord();
                successfulHide = true;
            }
            hideAttempts++;
        }
        while (!successfulHide & hideAttempts < 10);

        return successfulHide;
    }

    public void RevealAllWords()
    {
        foreach (Word word in _textList)
        {
            word.RevealWord();
        }
    }
}