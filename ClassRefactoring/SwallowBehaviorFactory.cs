using System;

namespace DeveloperSample.ClassRefactoring;

public static class SwallowBehaviorFactory
{
    public static ISwallowBehavior GetBehavior(SwallowType type)
    {
        return type switch
        {
            SwallowType.African => new AfricanSwallowBehavior(),
            SwallowType.European => new EuropeanSwallowBehavior(),
            _ => throw new InvalidOperationException()
        };
    }
}