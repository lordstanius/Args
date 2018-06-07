using System;
using System.Linq;
using CmdLineParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ArgsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Args args = new Args("a,b,c,d", new[] { "-a", "-b", "/cd" });

            Assert.IsTrue(args.Has('a') && args.Has('b') && args.Has('c') && args.Has('d'));
            Assert.IsTrue(args.GetBool('a'));
            Assert.IsTrue(args.GetBool('b'));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Args args = new Args("l,p#,d*", new[] { "-l", "/p", "80", "/d", "Test" });

            Assert.IsTrue(args.Has('l') && args.Has('p') && args.Has('d'));
            Assert.IsTrue(args.GetBool('l'));
            Assert.IsTrue(args.GetInt('p') == 80);
            Assert.AreEqual(args.GetString('d'), "Test");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] test = { "Test", "Another test", "Yet another test" };
            Args args = new Args("p##,d[*]", new[] { "/p", "8.04", "/d" }.Concat(test));

            Assert.IsTrue(args.Has('p') && args.Has('d'));
            Assert.IsTrue(args.GetDouble('p') == 8.04);

            string[] result = args.GetStringArray('d');
            for (int i = 0; i < test.Length; ++i)
                Assert.AreEqual(test[i], result[i]);
        }
    }
}
