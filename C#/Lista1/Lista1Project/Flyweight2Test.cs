using System;
using Flyweight2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesty
{
    [TestClass]
    public class Flyweight2Test
    {
        // Build a document with text
        private static readonly string document = "AAZZBBZB";
        private readonly char[] chars = document.ToCharArray();

        CharacterFactory factory = new CharacterFactory();

        // extrinsic state
        int pointSize = 10;
        [TestMethod]
        public void UseFlyweightObject()
        {
            foreach (char c in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }
        }
    }
}
