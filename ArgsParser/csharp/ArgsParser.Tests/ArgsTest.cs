using FluentAssertions;
using Xunit;

namespace ArgsParser.Tests;

public class ArgsTest
{
    [Fact]
    public void Should_correctly_parse_a_boolean_argument()
    {
        var args = new Args("x%b", new []{ "-x" });
        args.Parse();
        args.SchemaHas('x').Should().BeTrue();
        args.GetBoolean('x').Should().BeTrue();
    }
}