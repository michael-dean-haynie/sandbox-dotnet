
namespace LeetCode.Problems._648_ReplaceWords;

// https://leetcode.com/problems/replace-words/description/
public class Solution  
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        // create/hydrate trie
        var trie = new Trie();
        foreach (var word in dictionary)
        {
            trie.Insert(word);
        }     
        
        // split sentence
        // iterate over words
        // replace words with roots in trie
        var newWords = new List<string>();
        foreach (var word in sentence.Split(' '))
        {
            var root = trie.FindRoot(word);
            newWords.Add(root ?? word);
        }

        return string.Join(' ', newWords);
    }
}

public class Trie
{
    public string Value { get; set;  }
    
    public bool IsEndOfWord { get; set; }
    
    public bool IsRootNode { get; set; }

    public IDictionary<string, Trie> Children { get; }

    public Trie(): this(string.Empty) {}

    public Trie(string value)
    {
        Value = value;
        IsEndOfWord = false;
        IsRootNode = Value == string.Empty;
        Children = new Dictionary<string, Trie>();
    }

    public void Insert(string value)
    {
        if (value.Length < 1)
        {
            return;
        }
        string firstChar = value[0].ToString();
        
        Children.TryGetValue(firstChar, out Trie? child);
        if (child == null)
        {
            child = new Trie(firstChar);
            Children[firstChar] = child;
        }

        // recursively insert the rest of the value, or mark it as the end of a word
        if (value.Length > 1)
        {
            child.Insert(value[1..]);
        }
        else
        {
            child.IsEndOfWord = true;
        }
    }

    public string? FindRoot(string word)
    {
        if (word.Length < 1)
        {
            return null;
        }
        
        string firstChar = word[0].ToString();
        var restOfWord = IsRootNode ? word : word.Substring(1);

        if (firstChar == Value || IsRootNode)
        {
            if (IsEndOfWord)
            {
                return Value;
            }
            
            foreach (var (key, child) in Children)
            {
                var childResult = child.FindRoot(restOfWord);
                if (childResult != null)
                {
                    return Value + childResult;
                }
            }

            return null;
        }
        
        return null;
    }
}