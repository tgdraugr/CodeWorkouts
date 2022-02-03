namespace ArgsParser;

public class Args
{
    private readonly string[] _args;

    private readonly Dictionary<char, Type?> _detailedSchema;
    private readonly Dictionary<char, bool> _booleans = new();
    private readonly Dictionary<char, int> _integers = new();

    public Args(string schema, string[] args)
    {
        _detailedSchema = ExtractSchema(schema);
        _args = args;
    }

    public void Parse()
    {
        foreach (var arg in _args)
        {
            if (IsNotFlag(arg)) 
                continue;
            
            var flag = char.Parse(arg[1..]);
                
            if (_detailedSchema[flag] == typeof(bool))
                _booleans[flag] = _detailedSchema.ContainsKey(flag);
                
            if (_detailedSchema[flag] == typeof(int))
                _integers[flag] = int.Parse(_args.Skip(1).First());
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