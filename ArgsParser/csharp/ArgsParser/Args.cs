namespace ArgsParser;

public class Args
{
    private readonly string[] _args;

    private readonly Dictionary<char, Type?> _detailedSchema;
    private readonly Dictionary<char, bool> _booleans = new();
    private readonly Dictionary<char, int> _integers = new();
    private readonly Dictionary<char, string> _strings = new();
    private readonly Dictionary<char, string[]> _stringLists = new();

    public Args(string schema, string[] args)
    {
        _detailedSchema = ExtractSchema(schema);
        _args = args;
    }

    public void Parse()
    {
        foreach (var arg in _args)
        {
            if (IsNotFlag(arg.Trim())) 
                continue;
            
            var flag = char.Parse(arg[1..]);
                
            if (_detailedSchema[flag] == typeof(bool))
                _booleans[flag] = true;
                
            if (_detailedSchema[flag] == typeof(int))
                _integers[flag] = int.Parse(_args.Skip(1).First());

            if (_detailedSchema[flag] == typeof(string))
                _strings[flag] = _args.Skip(1).First();
            
            if (_detailedSchema[flag] == typeof(string[]))
                _stringLists[flag] = _args.Skip(1).First().Split(",");
        }
    }

    public bool GetBoolean(char flag)
    {
        return _booleans.TryGetValue(flag, out var value) && value;
    }

    public int GetInteger(char flag)
    {
        return _integers.TryGetValue(flag, out var value) ? value : 0;
    }

    public string GetString(char flag)
    {
        return _strings.TryGetValue(flag, out var value) ? value : "";
    }
    
    public IEnumerable<string> GetStrings(char flag)
    {
        return _stringLists.TryGetValue(flag, out var value) ? value : ArraySegment<string>.Empty;
    }

    public bool SchemaHas(char flag)
    {
        return _detailedSchema.ContainsKey(flag);
    }

    private static Dictionary<char, Type?> ExtractSchema(string schema, string separator = "|")
    {
        var detailedSchema = new Dictionary<char, Type?>();

        foreach (var element in schema.Split(separator))
        {
            var head = element[0];
            var tail = element[1..];
            detailedSchema[head] = tail switch
            {
                "%b" => typeof(bool),
                "%i" => typeof(int),
                "%s" => typeof(string),
                "[%s]" => typeof(string[]),
                _ => detailedSchema[head]
            };
        }

        return detailedSchema;
    }

    private static bool IsNotFlag(string arg)
    {
        return !arg.Contains('-');
    }
}