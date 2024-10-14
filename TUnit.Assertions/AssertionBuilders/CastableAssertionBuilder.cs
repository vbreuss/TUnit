using System.Runtime.CompilerServices;
using System.Text;
using TUnit.Assertions.AssertConditions;

namespace TUnit.Assertions.AssertionBuilders;

public class CastableAssertionBuilder<TActual, TExpected> : InvokableValueAssertionBuilder<TActual>
{
    private readonly Func<AssertionData<TActual>, TExpected?> _mapper;

    internal CastableAssertionBuilder(InvokableAssertionBuilder<TActual> assertionBuilder) : base(assertionBuilder)
    {
        _mapper = DefaultMapper;
    }

    internal CastableAssertionBuilder(InvokableAssertionBuilder<TActual> assertionBuilder, Func<AssertionData<TActual>, TExpected?> mapper) : base(assertionBuilder)
    {
        _mapper = mapper;
    }

    public new TaskAwaiter<TExpected?> GetAwaiter()
    {
        return AssertType().GetAwaiter();
    }

    private static TExpected? DefaultMapper(AssertionData<TActual> data)
    {
        try
        {
            return (TExpected)Convert.ChangeType(data.Result, typeof(TExpected))!;
        }
        catch
        {
            return default;
        }
    }

    private async Task<TExpected?> AssertType()
    {
        var data = await ProcessAssertionsAsync();
        return _mapper(data);
    }
}

public class MappedInvokableAssertionBuilder<TActual, TTarget> : InvokableAssertionBuilder<TTarget>
{
    public MappedInvokableAssertionBuilder(
        AssertionBuilder<TActual> assertionBuilder,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
        : base(new MappedAssertionBuilder<TActual,TTarget>(assertionBuilder, mapper, expression))
    {
        ActualExpression = assertionBuilder.ActualExpression;
    }
}

public class MappedAssertionBuilder<TActual, TTarget> : AssertionBuilder<TTarget>
{
    public MappedAssertionBuilder(
        AssertionBuilder<TActual> assertionBuilder,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
        : base(
            () => MapDelegate(assertionBuilder.AssertionDataDelegate, mapper, expression),
            "")
    {
        ActualExpression = assertionBuilder.ActualExpression;
    }

    private static async Task<AssertionData<TTarget>> MapDelegate(
        Func<Task<AssertionData<TActual>>> source,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
    {
        var data = await source();
        return new AssertionData<TTarget>(mapper(data.Result, data.Exception), data.Exception, expression);
    }
}