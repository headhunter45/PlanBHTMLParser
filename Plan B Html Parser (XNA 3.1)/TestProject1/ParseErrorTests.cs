using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanB.Html.Nodes;
using PlanB.Html;

namespace TestProject1
{
    [TestClass]
    public class ParseErrorTests
    {
        public ParseErrorTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Parse_UnknownTag()
        {
            String htmlText = "<asdf></asdf>";
            String expectedResult = "&lt;asdf&gt;&lt;/asdf&gt;";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 1);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlTextNode));

            Assert.AreEqual<int>(htmlNode.Children[0].Children.Count, 0);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnclosedTag()
        {
            String htmlText = "<div>asdf<span>fdsa</span>jkl;";
            String expectedResult = "<div>asdf<span>fdsa</span>jkl;</div>";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlDivNode));

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnescapedAmpersand()
        {
            String htmlText = "hello&world";
            String expectedResult = "hello&amp;world";
            
            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnescapedLessThan()
        {
            String htmlText = "hello<world";
            String expectedResult = "hello&lt;world";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnescapedLessThanThatLooksLikeATag()
        {
            String htmlText = "hello<div world";
            String expectedResult = "hello&lt;div world";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnescapedGreaterThan()
        {
            String htmlText = "hello>world";
            String expectedResult = "hello&gt;world";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);

        }

        [TestMethod]
        public void Test_Parse_UnescapedQuote()
        {
            String htmlText = "hello\"world";
            String expectedResult = "hello&quot;world";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlTextNode));

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_UnopenedTag()
        {
            String htmlText = "<div>hello world</span></div>";
            String expectedResult = "<div>hello world</div>";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlDivNode));

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }
    }
}
