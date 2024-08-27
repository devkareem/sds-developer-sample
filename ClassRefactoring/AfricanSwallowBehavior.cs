using System;

namespace DeveloperSample.ClassRefactoring;

public class AfricanSwallowBehavior : ISwallowBehavior
{
    public double CalculateAirspeedVelocity(SwallowLoad load)
    {
        return load switch
        {
            SwallowLoad.None => 22,
            SwallowLoad.Coconut => 18,
            _ => throw new InvalidOperationException()
        };
    }
}