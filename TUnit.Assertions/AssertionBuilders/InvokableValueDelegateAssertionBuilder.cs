﻿using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertConditions.Operators;

namespace TUnit.Assertions.AssertionBuilders;

public class InvokableValueDelegateAssertionBuilder<TActual> : InvokableAssertionBuilder<TActual>, IValueDelegateSource<TActual>
{
    internal InvokableValueDelegateAssertionBuilder(Func<Task<AssertionData<TActual>>> assertionDataDelegate, AssertionBuilder<TActual> assertionBuilder) : base(assertionDataDelegate, assertionBuilder)
    {
    }

    public AssertionBuilder<TActual> AssertionBuilder => this;
    
    public ValueDelegateAnd<TActual> And => new(AssertionBuilder.AppendConnector(ChainType.And));
    public ValueDelegateOr<TActual> Or => new(AssertionBuilder.AppendConnector(ChainType.Or));
}