using System;
using System.Collections.Generic;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }
    
    internal class AnotherContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }
        
        [Fact]
        public void Bind_ShouldThrowArgumentNullException_WhenInterfaceTypeIsNull()
        {
            var container = new Container();
            
            Assert.Throws<ArgumentNullException>(() =>
                container.Bind(null, typeof(ContainerTestClass)));
        }

        [Fact]
        public void Bind_ShouldThrowArgumentNullException_WhenImplementationTypeIsNull()
        {
            var container = new Container();
            
            Assert.Throws<ArgumentNullException>(() =>
                container.Bind(typeof(IContainerTestInterface), null));
        }
        
        [Fact]
        public void Get_ShouldThrowKeyNotFoundException_WhenTypeNotBonded()
        {
            var container = new Container();
            
            Assert.Throws<KeyNotFoundException>(() => container.Get<IContainerTestInterface>());
        }

        [Fact]
        public void Bind_ShouldOverrideExistingBinding()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            
            container.Bind(typeof(IContainerTestInterface), typeof(AnotherContainerTestClass));
            var resolvedInstance = container.Get<IContainerTestInterface>();
            
            Assert.IsType<AnotherContainerTestClass>(resolvedInstance);
        }
    }
}