namespace TUnit.Assertions.AssertionBuilders;

public class MappedInvokableAssertionBuilder<TActual, TTarget> : InvokableAssertionBuilder<TTarget>
{
    public MappedInvokableAssertionBuilder(
        InvokableAssertionBuilder<TActual> assertionBuilder,
        Func<TActual?, Exception?, TTarget> mapper,
        string? expression)
        : base(new MappedAssertionBuilder<TActual,TTarget>(assertionBuilder, mapper, expression))
    {
        if (expression != null)
        {
            assertionBuilder.AppendExpression(expression);
        }
        ActualExpression = assertionBuilder.ActualExpression;
        ExpressionBuilder = assertionBuilder.ExpressionBuilder;
    }
}