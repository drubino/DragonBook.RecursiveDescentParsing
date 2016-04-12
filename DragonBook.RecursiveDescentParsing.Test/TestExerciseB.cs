using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonBook.RecursiveDescentParsing.ExerciseB;

namespace DragonBook.RecursiveDescentParsing.Test
{
    [TestClass]
    public class TestExerciseB : Test
    {
        [TestMethod]
        public void ParseTest()
        {
            var parser = new Parser();
            var node1 = parser.Parse("()");
            var node2 = parser.Parse("((()))");
            var node3 = parser.Parse("()()()");
            var node4 = parser.Parse("(())((()))(())");

            AssertThrows(() => parser.Parse(""));
            AssertThrows(() => parser.Parse("("));
            AssertThrows(() => parser.Parse(")"));
            AssertThrows(() => parser.Parse("(()"));
            AssertThrows(() => parser.Parse("())"));
            AssertThrows(() => parser.Parse("()()("));
            AssertThrows(() => parser.Parse("(()()"));
        }
    }
}
