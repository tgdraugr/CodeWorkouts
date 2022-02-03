namespace ArgsParser;

public class Args
{
    private readonly string[] _args;

    private readonly Dictionary<char, Type?> _detailedSchema;
    private readonly Dictionary<char, bool> _booleans = new();

    public Args(string schema, string[] args)
    {
        _detailedSchema = ExtractSchema(schema);
        _args = args;
    }

    public void Parse()
    {
        var flag = char.Parse(_args[0][1..]);
        _booleans[flag] = _detailedSchema.ContainsKey(flag);
    }

    public bool GetBoolean(char flag)
    {
        return _booleans.TryGetValue(flag, out var value) && value;
    }

    public bool SchemaHas(char flag)
    {
        return _detailedSchema.ContainsKey(flag);
    }

    private static Dictionary<char, Type?> ExtractSchema(string schema)
    {
        Type? theType = null;
        var flag = schema[0];
        var type = schema[1..];
        if (type == "%b")
            theType = typeof(bool);
        
        return new Dictionary<char, Type?>
        {
            { flag, theType }
        };
    }
}