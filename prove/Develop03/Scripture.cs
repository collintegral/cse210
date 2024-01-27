public class Scripture
{
    private List<Verse> _verseList = new List<Verse>();
    private ScriptRef _reference;
    private int _scriptLength = 0;
    private int _wordsToHide;
    private int _hiddenWords = 0;

    public Scripture(string reference, List<string> verses)
    {
        const int maxHiddenPerInstance = 8;
        const int minHiddenPerInstance = 3;

        _reference = new ScriptRef(reference);
        foreach (string verse in verses)
        {
            Verse verseObj = new Verse(verse);
            _verseList.Add(verseObj);

            _scriptLength += verseObj.CountWords();
        }

        if (_scriptLength/8 >= maxHiddenPerInstance)
        {
            _wordsToHide = maxHiddenPerInstance;
        }
        else if (_scriptLength/8 <= minHiddenPerInstance)
        {
            _wordsToHide = minHiddenPerInstance;
        }
        else
        {
            _wordsToHide = _scriptLength/8;
        }
        
    }

    public string GetRef()
    {
        return _reference.GetRef();
    }

    public void PrintScripture()
    {
        _reference.PrintRef();
        foreach (Verse verse in _verseList)
        {
            verse.PrintVerse();
            Console.WriteLine();
        }
        Console.WriteLine(_wordsToHide + " Words to hide; " + _scriptLength + " words; " + _hiddenWords + " words hidden.");
    }

    public bool HideWords(Random random)
    {
        int i = 0;
        while (i < _wordsToHide && _hiddenWords < _scriptLength)
        {
            int verseToHide = random.Next(_verseList.Count);
            if(_verseList[verseToHide].HideWord(random))
            {
                _hiddenWords += 1;
                i++;
            }
        }

        return _hiddenWords >= _scriptLength;
    }

    public void RevealAllWords()
    {
        foreach (Verse verse in _verseList)
        {
            verse.RevealAllWords();
            _hiddenWords = 0;
        }
    }
}