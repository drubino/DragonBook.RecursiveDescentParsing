using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonBook.RecursiveDescentParsing.ExerciseC;

namespace DragonBook.RecursiveDescentParsing.Test
{
    [TestClass]
    public class TestExerciseC : Test
    {
        [TestMethod]
        public void ParseTest()
        {
            var parser = new Parser();
            var node1 = parser.Parse("01");
            var node2 = parser.Parse("0011");
            var node3 = parser.Parse("000111");

            AssertThrows(() => parser.Parse(""));
            AssertThrows(() => parser.Parse("0"));
            AssertThrows(() => parser.Parse("1"));
            AssertThrows(() => parser.Parse("011"));
            AssertThrows(() => parser.Parse("001"));
            AssertThrows(() => parser.Parse("10"));
            AssertThrows(() => parser.Parse("1100"));
        }
    }
}
