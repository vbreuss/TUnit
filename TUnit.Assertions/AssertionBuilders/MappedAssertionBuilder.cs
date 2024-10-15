﻿namespace TUnit.Assertions.AssertionBuilders;

public class MappedAssertionBuilder<TActual, TTarget> : AssertionBuilder<TTarget>
{
    public MappedAssertionBuilder(
        AssertionBuilder<TActual> assertionBuilder,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
        : base(() => MapDelegate(assertionBuilder, mapper, expression), "")
    {
        ActualExpression = assertionBuilder.ActualExpression;
    }

    private static async Task<AssertionData<TTarget>> MapDelegate(
        AssertionBuilder<TActual> source,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
    {
        var data = await source.AssertionDataDelegate();
        return new AssertionData<TTarget>(mapper(data.Result, data.Exception), data.Exception, expression)
        {
            ActualExpression = source.ActualExpression
        };
    }
}