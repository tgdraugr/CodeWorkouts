using FluentAssertions;
using Xunit;

namespace Arithmetics.Tests;

public class TransactionTests
{
    [Fact]
    public void Should_evaluate_single_constant_expression()
    {
        EvaluatedTransactionFor("( 0 )").Result.Should().Be(0);
        EvaluatedTransactionFor("( 1 )").Result.Should().Be(1);
    }

    [Fact]
    public void Should_evaluate_a_simple_addition_expression()
    {
        EvaluatedTransactionFor("( 1 + 1 )").Result.Should().Be(2);
    }
    
    [Fact]
    public void Should_evaluate_a_simple_subtraction_expression()
    {
        EvaluatedTransactionFor("( 2 - 1 )").Result.Should().Be(1);
    }

    [Fact]
    public void Should_evaluate_a_simple_multiplication_expression()
    {
        EvaluatedTransactionFor("( 2 * 2 )").Result.Should().Be(4);
    }

    [Fact]
    public void Should_evaluate_a_simple_division_expression_when_division_is_exact()
    {
        EvaluatedTransactionFor("( 2 / 2 )").Result.Should().Be(1);
        EvaluatedTransactionFor("( 4 / 2 )").Result.Should().Be(2);
    }

    private static Transaction EvaluatedTransactionFor(string expression)
    {
        var transaction = new Transaction(expression);
        transaction.Evaluate();
        return transaction;
    }
}