namespace ArgsParser;

public class Args
{
    private readonly string[] _args;
    private readonly HashSet<char> _allFlags;
    private readonly Dictionary<char, Type?> _detailedSchema;
    private readonly Dictionary<char, bool> _booleanValues = new();
    private readonly Dictionary<char, int> _integerValues = new();
    private readonly Dictionary<char, string> _stringValues = new();
    private readonly Dictionary<char, string[]> _stringListValues = new();

    public Args(string schema, string[] args)
    {
        _detailedSchema = ExtractSchema(schema);
        _allFlags = _detailedSchema.Keys.ToHashSet();
        _args = args;
    }

    public void Parse()
    {
        for (var current = 0; current < _args.Length; current++)
        {
            var arg = _args[current].Trim();
            
            if (IsNotFlag(arg)) 
                continue;

            var flag = char.Parse(arg[1..]);
            ParseArgument(flag, current, _detailedSchema[flag]);
        }
    }

    private void ParseArgument(char flag, int current, Type? flagType)
    {
        var next = current + 1;

        if (flagType == typeof(bool))
            _booleanValues[flag] = true;

        if (flagType == typeof(int))
            _integerValues[flag] = int.Parse(_args[next]);
        
        if (flagType == typeof(string))
            _stringValues[flag] = _args[next];
        
        if (flagType == typeof(string[]))
            _stringListValues[flag] = _args[next].Split(",");
    }

    public bool GetBoolean(char flag)
    {
        return _booleanValues.TryGetValue(flag, out var value) && value;
    }

    public int GetInteger(char flag)
    {
        return _integerValues.TryGetValue(flag, out var value) ? value : 0;
    }

    public string GetString(char flag)
    {
        return _stringValues.TryGetValue(flag, out var value) ? value : "";
    }
    
    public IEnumerable<string> GetStrings(char flag)
    {
        return _stringListValues.TryGetValue(flag, out var value) ? value : ArraySegment<string>.Empty;
    }

    public bool SchemaHas(char flag)
    {
        return _allFlags.Contains(flag);
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
        return arg.Contains('-') is false;
    }
}
