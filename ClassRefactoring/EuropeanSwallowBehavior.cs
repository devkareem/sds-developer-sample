using System;

namespace DeveloperSample.ClassRefactoring;

public class EuropeanSwallowBehavior : ISwallowBehavior
{
    public double CalculateAirspeedVelocity(SwallowLoad load)
    {
        return load switch
        {
            SwallowLoad.None => 20,
            SwallowLoad.Coconut => 16,
            _ => throw new InvalidOperationException()
        };
    }
}