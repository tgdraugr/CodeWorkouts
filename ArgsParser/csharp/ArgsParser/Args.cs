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
        foreach (var arg in _args)
        {
            var flag = char.Parse(arg[1..]);
            _booleans[flag] = _detailedSchema.ContainsKey(flag);
        }
    }

    public bool GetBoolean(char flag)
    {
        return _booleans.TryGetValue(flag, out var value) && value;
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
            if (tail == "%b")
                detailedSchema[head] = typeof(bool);
        }

        return detailedSchema;
    }
}