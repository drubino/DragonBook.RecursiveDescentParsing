using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonBook.RecursiveDescentParsing.ExerciseA;

namespace DragonBook.RecursiveDescentParsing.Test
{
    [TestClass]
    public class TestExerciseA : Test
    {
        [TestMethod]
        public void ParseTest()
        {
            var parser = new Parser();
            var node1 = parser.Parse("a");
            var node2 = parser.Parse("+aa");
            var node3 = parser.Parse("-aa");
            var node4 = parser.Parse("+-aaa");
            var node5 = parser.Parse("+-aa+aa");

            AssertThrows(() => parser.Parse(""));
            AssertThrows(() => parser.Parse("b"));
            AssertThrows(() => parser.Parse("+"));
            AssertThrows(() => parser.Parse("-"));
            AssertThrows(() => parser.Parse("+a"));
            AssertThrows(() => parser.Parse("-a"));
        }
    }
}
