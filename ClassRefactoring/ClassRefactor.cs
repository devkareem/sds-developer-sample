using System;

namespace DeveloperSample.ClassRefactoring
{
    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }
        private readonly ISwallowBehavior _behavior;
        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
            _behavior = SwallowBehaviorFactory.GetBehavior(swallowType);
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return _behavior.CalculateAirspeedVelocity(Load);
        }
    }
}