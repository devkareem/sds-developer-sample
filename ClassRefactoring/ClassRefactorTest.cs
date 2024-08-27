using System;
using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.African);
            Assert.Equal(22, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.African);
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(18, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.European);
            Assert.Equal(20, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.European);
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(16, swallow.GetAirspeedVelocity());
        }
        
        [Theory]
        [InlineData(SwallowType.African)]
        [InlineData(SwallowType.European)]
        public void GetAirspeedVelocity_ThrowsInvalidOperationException_ForUnsupportedSwallowLoad(SwallowType swallowType)
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(swallowType);
            swallow.ApplyLoad((SwallowLoad)999);
            Assert.Throws<InvalidOperationException>(() => swallow.GetAirspeedVelocity());
        }
        
        [Fact]
        public void GetBehavior_ReturnsAfricanSwallowBehavior_ForAfricanSwallowType()
        {
            var behavior = SwallowBehaviorFactory.GetBehavior(SwallowType.African);

            Assert.IsType<AfricanSwallowBehavior>(behavior);
        }

        [Fact]
        public void GetBehavior_ReturnsEuropeanSwallowBehavior_ForEuropeanSwallowType()
        {
            var behavior = SwallowBehaviorFactory.GetBehavior(SwallowType.European);
            
            Assert.IsType<EuropeanSwallowBehavior>(behavior);
        }

        [Fact]
        public void SwallowBehaviorFactory_ThrowsInvalidOperationException_ForUnsupportedSwallowType()
        {
            Assert.Throws<InvalidOperationException>(() => SwallowBehaviorFactory.GetBehavior((SwallowType)999));
        }
    }
}