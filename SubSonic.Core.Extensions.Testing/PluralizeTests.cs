using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSonic.Core.Extensions.Testing
{
    [TestFixture]
    public class PluralizeTests
    {
        [Test]
        [TestCase("Table", "Tables")]
        [TestCase("Property", "Properties")]
        [TestCase("Bounty", "Bounties")]
        [TestCase("Man", "Men")]
        [TestCase("Person", "People")]
        public void ShouldBeAbleToPluralizeWords(string singlular, string expected)
        {
            singlular.Pluralize().Should().Be(expected);
        }
    }
}
