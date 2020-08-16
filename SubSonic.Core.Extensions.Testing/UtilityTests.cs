using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubSonic.Core.Extensions.Testing
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        [TestCase("netcoreapp3.1", 2.1)]
        [TestCase("netcoreapp3.0", 2.1)]
        [TestCase("netcoreapp2.1", 2.0)]
        [TestCase("net472", 2.0)]
        public void GetNetStandardVersionTests(string framework, decimal expectedVersion)
        {
            Utilities.GetNetStandardVersion(framework).Should().Be(expectedVersion);
        }
    }
}
