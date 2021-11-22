using ASX43O_HFT_2021221.Models;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Test
{
    [TestFixture]
    public class PlayerCharacterTests
    {
        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void PlayerInitializes()
        {
            var p = new PlayerCharacter();

            Assert.That(p.CharacterLevel.Equals(0));
        }
    }
}
