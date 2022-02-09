using System;
using FluentAssertions;
using Xunit;
using RecordError = Arithmetics.InvalidRecordException.RecordError;

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
    
    [Fact]
    public void Should_evaluate_a_simple_division_expression_when_division_is_not_exact()
    {
        EvaluatedTransactionFor("( 3 / 2 )").Result.Should().Be(1.5f);
    }

    [Fact]
    public void Should_throw_error_on_division_by_zero()
    {
        Action intent = () => EvaluatedTransactionFor("( 2 / 0 )");
        intent.Should().Throw<InvalidRecordException>()
            .Where(exception => exception.Error == RecordError.DivisionByZero);
    }

    [Theory]
    [InlineData("( 2 & 0 )")]
    [InlineData("( 3 % 0 )")]
    public void Should_throw_error_on_invalid_operation(string expression)
    {
        Action intent = () => EvaluatedTransactionFor(expression);
        intent.Should().Throw<InvalidRecordException>()
            .Where(exception => exception.Error == RecordError.InvalidOperation);
    }

    [Theory]
    [InlineData("( _ )")]
    [InlineData("( x + 2 )")]
    [InlineData("( 2 - ? )")]
    public void Should_throw_error_on_bad_syntax(string expression)
    {
        Action intent = () => EvaluatedTransactionFor(expression);
        intent.Should().Throw<InvalidRecordException>()
            .Where(exception => exception.Error == RecordError.BadSyntax);
    }

    [Fact]
    public void Should_evaluate_addition_of_constant_to_expression()
    {
        EvaluatedTransactionFor("( 1 + ( 1 + 1 ) )").Result.Should().Be(3);
    }

    private static Transaction EvaluatedTransactionFor(string expression)
    {
        var transaction = new Transaction(expression);
        transaction.Evaluate();
        return transaction;
    }
}