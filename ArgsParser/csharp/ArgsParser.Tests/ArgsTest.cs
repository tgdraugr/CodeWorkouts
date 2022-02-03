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

    [Fact]
    public void Should_correctly_parse_multiple_boolean_arguments()
    {
        var args = new Args("x%b|y%b", new[] { "-x", "-y" });
        args.Parse();
        args.SchemaHas('x').Should().BeTrue();
        args.SchemaHas('y').Should().BeTrue();
        args.GetBoolean('x').Should().BeTrue();
        args.GetBoolean('y').Should().BeTrue();
    }

    [Fact]
    public void Should_correctly_parse_an_integer_argument()
    {
        var args = new Args("x%i", new[] { "-x", "1" });
        args.Parse();
        args.SchemaHas('x').Should().BeTrue();
        args.GetInteger('x').Should().Be(1);
    }
}