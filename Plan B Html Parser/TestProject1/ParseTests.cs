using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanB.Html.Nodes;
using PlanB.Html;

namespace TestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ParseTests
    {
        public ParseTests()
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
        public void Test_Parse_HtmlTextNode()
        {
            String htmlText = "asdf";
            String expectedResult = "asdf";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 1);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlTextNode));

            HtmlTextNode htmlTextNode = htmlNode.Children[0] as HtmlTextNode;

            Assert.AreEqual(expectedResult, htmlTextNode.Text);
        }

        [TestMethod]
        public void Test_Parse_Returns_HtmlDocumentNode()
        {
            String htmlText = String.Empty;

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsInstanceOfType(htmlNode, typeof(HtmlDocumentNode));
        }

        [TestMethod]
        public void Test_HtmlTextNode_Constructors()
        {
            HtmlTextNode htmlTextNode = new HtmlTextNode();

            Assert.IsNotNull(htmlTextNode.Attributes, "The default constructor failed to initialize the Attributes property.");
            Assert.IsNotNull(htmlTextNode.Children, "The default constructor failed to initialize the Children property.");
            Assert.IsNotNull(htmlTextNode.InnerHtml, "The default constructor failed to initialize the InnerHtml property.");
            Assert.IsNotNull(htmlTextNode.OuterHtml, "The default constructor failed to initialize the OuterHtml property.");
            Assert.IsNotNull(htmlTextNode.Text, "The default constructor failed to initialize the Text property");
            Assert.IsNotNull(htmlTextNode.Type, "The default constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Text_, htmlTextNode.Type);

            String expectedValue = "This is some sample text.";
            htmlTextNode = new HtmlTextNode(expectedValue);
            Assert.IsNotNull(htmlTextNode.Attributes, "The HtmlTextNode(string) constructor failed to initialize the Attributes property.");
            Assert.IsNotNull(htmlTextNode.Children, "The HtmlTextNode(string) constructor failed to initialize the Children property.");
            Assert.IsNotNull(htmlTextNode.InnerHtml, "The HtmlTextNode(string) constructor failed to initialize the InnerHtml property.");
            Assert.AreEqual<String>(String.Empty, htmlTextNode.InnerHtml);
            Assert.IsNotNull(htmlTextNode.OuterHtml, "The HtmlTextNode(string) constructor failed to initialize the OuterHtml property.");
            Assert.AreEqual<String>(expectedValue, htmlTextNode.OuterHtml);
            Assert.IsNotNull(htmlTextNode.Text, "The HtmlTextNode(string) constructor failed to initialize the Text property");
            Assert.AreEqual<String>(expectedValue, htmlTextNode.Text);
            Assert.IsNotNull(htmlTextNode.Type, "The HtmlTextNode(string) constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Text_, htmlTextNode.Type);
        }

        [TestMethod]
        public void Test_HtmlDocumentNode_Constructors()
        {
            HtmlDocumentNode htmlDocumentNode = new HtmlDocumentNode();
            Assert.IsNotNull(htmlDocumentNode.Attributes);
            Assert.IsNotNull(htmlDocumentNode.Children);
            Assert.AreEqual<int>(0, htmlDocumentNode.Children.Count);
            Assert.IsNotNull(htmlDocumentNode.InnerHtml);
            Assert.AreEqual<String>(String.Empty, htmlDocumentNode.InnerHtml);
            Assert.IsNotNull(htmlDocumentNode.OuterHtml);
            Assert.AreEqual<String>(String.Empty, htmlDocumentNode.OuterHtml);
            Assert.IsNotNull(htmlDocumentNode.Type);
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Document_, htmlDocumentNode.Type);
        }

        [TestMethod]
        public void Test_HtmlBrNode_Constructor()
        {
            HtmlBrNode htmlBrNode = new HtmlBrNode();
            String expectedOuterHtml = "<br />";

            Assert.IsNotNull(htmlBrNode.Attributes, "The default constructor failed to initialize the Attributes property.");
            Assert.AreEqual<int>(0, htmlBrNode.Attributes.Count);
            Assert.IsNotNull(htmlBrNode.Children, "The default constructor failed to initialize the Children property.");
            Assert.AreEqual<int>(0, htmlBrNode.Children.Count);
            Assert.IsNotNull(htmlBrNode.InnerHtml, "The default constructor failed to initialize the InnerHtml property.");
            Assert.AreEqual<String>(htmlBrNode.InnerHtml, String.Empty);
            Assert.IsNotNull(htmlBrNode.OuterHtml, "The default constructor failed to initialize the OuterHtml property.");
            Assert.AreEqual<String>(htmlBrNode.OuterHtml, expectedOuterHtml);
            Assert.IsNotNull(htmlBrNode.Type, "The default constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Br, htmlBrNode.Type);
        }

        [TestMethod]
        public void Test_HtmlSpanNode_Constructor()
        {
            
            //Default constructor
            HtmlSpanNode  htmlSpanNode = new HtmlSpanNode();
            Assert.IsNotNull(htmlSpanNode.Attributes, "The default constructor failed to initialize the Attributes property.");
            Assert.AreEqual<int>(0, htmlSpanNode.Attributes.Count);
            Assert.IsNotNull(htmlSpanNode.Children, "The default constructor failed to initialize the Children property.");
            Assert.AreEqual<int>(0, htmlSpanNode.Children.Count);
            Assert.IsNotNull(htmlSpanNode.InnerHtml, "The default constructor failed to initialize the InnerHtml property.");
            Assert.AreEqual<string>(String.Empty, htmlSpanNode.InnerHtml);
            Assert.IsNotNull(htmlSpanNode.OuterHtml, "The default constructor failed to initialize the OuterHtml property.");
            Assert.AreEqual<string>("<span />", htmlSpanNode.OuterHtml);
            Assert.IsNotNull(htmlSpanNode.Type, "The default constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Span, htmlSpanNode.Type);

            //HtmlSpanNode(String)
            String text = "test";
            htmlSpanNode = new HtmlSpanNode(text);
            Assert.IsNotNull(htmlSpanNode.Attributes, "The HtmlSpanNode(String) constructor failed to initialize the Attributes property.");
            Assert.AreEqual<int>(0, htmlSpanNode.Attributes.Count);
            Assert.IsNotNull(htmlSpanNode.Children, "The HtmlSpanNode(String) constructor failed to initialize the Children property.");
            Assert.AreEqual<int>(1, htmlSpanNode.Children.Count);
            Assert.IsNotNull(htmlSpanNode.InnerHtml, "The HtmlSpanNode(String) constructor failed to initialize the InnerHtml property.");
            Assert.AreEqual<string>(text, htmlSpanNode.InnerHtml);
            Assert.IsNotNull(htmlSpanNode.OuterHtml, "The HtmlSpanNode(String) constructor failed to initialize the OuterHtml property.");
            Assert.AreEqual<string>("<span>" + text + "</span>", htmlSpanNode.OuterHtml);
            Assert.IsNotNull(htmlSpanNode.Type, "The HtmlSpanNode(String) constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Span, htmlSpanNode.Type);
            
            //HtmlSpanNode(IEnumerable<HtmlNode>)
            htmlSpanNode = new HtmlSpanNode(new HtmlNode[] { new HtmlTextNode(text), new HtmlBrNode(), new HtmlTextNode(text) });
            Assert.IsNotNull(htmlSpanNode.Attributes, "The HtmlSpanNode(IEnumerable<HtmlNode>) constructor failed to initialize the Attributes property.");
            Assert.AreEqual<int>(0, htmlSpanNode.Attributes.Count);
            Assert.IsNotNull(htmlSpanNode.Children, "The HtmlSpanNode(IEnumerable<HtmlNode>) constructor failed to initialize the Children property.");
            Assert.AreEqual<int>(3, htmlSpanNode.Children.Count);
            Assert.IsNotNull(htmlSpanNode.InnerHtml, "The HtmlSpanNode(IEnumerable<HtmlNode>) constructor failed to initialize the InnerHtml property.");
            Assert.AreEqual<string>(text + "<br />" + text, htmlSpanNode.InnerHtml);
            Assert.IsNotNull(htmlSpanNode.OuterHtml, "The HtmlSpanNode(IEnumerable<HtmlNode>) constructor failed to initialize the OuterHtml property.");
            Assert.AreEqual<string>("<span>" + text + "<br />" + text + "</span>", htmlSpanNode.OuterHtml);
            Assert.IsNotNull(htmlSpanNode.Type, "The HtmlSpanNode(IEnumerable<HtmlNode>) constructor failed to initialize the Type property");
            Assert.AreEqual<HtmlNodeType>(HtmlNodeType.Span, htmlSpanNode.Type);
        }

        [TestMethod]
        public void Test_Parse_TextWithSpanTag()
        {
            String htmlText = "asdf<span>123</span>fdsa";
            String expectedFirstNodeOuterHtml = "asdf";
            String expectedSecondNodeOuterHtml = "<span>123</span>";
            String expectedThirdNodeOuterHtml = "fdsa";
            String expectedSecondNodeInnerHtml = "123";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "");
            Assert.IsInstanceOfType(htmlNode, typeof(HtmlDocumentNode));
            Assert.AreEqual<string>(htmlText, htmlNode.OuterHtml);
            Assert.AreEqual<int>(3, htmlNode.Children.Count);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlTextNode));
            Assert.AreEqual<string>(expectedFirstNodeOuterHtml, htmlNode.Children[0].OuterHtml);
            Assert.AreEqual<int>(0, htmlNode.Children[0].Children.Count);

            Assert.IsInstanceOfType(htmlNode.Children[1], typeof(HtmlSpanNode));
            Assert.AreEqual<string>(expectedSecondNodeOuterHtml, htmlNode.Children[1].OuterHtml);
            Assert.AreEqual<int>(1, htmlNode.Children[1].Children.Count);

            Assert.IsInstanceOfType(htmlNode.Children[1].Children[0], typeof(HtmlTextNode));
            Assert.AreEqual<string>(expectedSecondNodeInnerHtml, htmlNode.Children[1].Children[0].OuterHtml);
            Assert.AreEqual<int>(0, htmlNode.Children[1].Children[0].Children.Count);

            Assert.IsInstanceOfType(htmlNode.Children[2], typeof(HtmlTextNode));
            Assert.AreEqual<string>(expectedThirdNodeOuterHtml, htmlNode.Children[2].OuterHtml);
            Assert.AreEqual<int>(0, htmlNode.Children[2].Children.Count);
        }


        [TestMethod]
        public void Test_Parse_TextWithBrTag()
        {
            String htmlText = "asdf<br />asdf";
            String expectedResult = "asdf<br />asdf";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 3);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlTextNode));

            HtmlTextNode htmlTextNode = htmlNode.Children[0] as HtmlTextNode;
            
            Assert.IsInstanceOfType(htmlNode.Children[1], typeof(HtmlBrNode));

            HtmlBrNode htmlBrNode = htmlNode.Children[1] as HtmlBrNode;

            Assert.IsInstanceOfType(htmlNode.Children[2], typeof(HtmlTextNode));

            htmlTextNode = htmlNode.Children[2] as HtmlTextNode;

            Assert.AreEqual(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_SpanWithStyle()
        {
            String htmlText = "<span style=\"color:black\">asdf</span>";
            String expectedResult = "<span style=\"color:rgb(0, 0, 0);\">asdf</span>";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 1);
            
            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlSpanNode));

            HtmlSpanNode spanNode = htmlNode.Children[0] as HtmlSpanNode;

            IEnumerable<KeyValuePair<string,string>> spanStyleAttributes = spanNode.Attributes.Where(i=>i.Key == "style");
            
            Assert.AreEqual<int>(spanStyleAttributes.Count(), 0);

            IEnumerable<KeyValuePair<string, string>> spanColorStyles = spanNode.Styles.Where(i => i.Key == "color");

            Assert.AreEqual<int>(spanColorStyles.Count(), 1);

            KeyValuePair<string, string> spanColorStyle = spanColorStyles.First();

            Assert.AreEqual<string>("rgb(0, 0, 0)", spanColorStyle.Value);
            //Assert.AreEqual<string>(spanColorStyle.Value, "black");
            /**/

            Assert.AreEqual(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_Div()
        {
            String htmlText = "<div>asdf</div>";
            String expectedResult = "<div>asdf</div>";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 1);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlDivNode));

            HtmlDivNode divNode = htmlNode.Children[0] as HtmlDivNode;

            Assert.AreEqual<int>(divNode.Children.Count, 1);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);
        }

        [TestMethod]
        public void Test_Parse_Img()
        {
            String htmlText = "<img src=\"http://blogs.msdn.com/blogfiles/klevereblog/WindowsLiveWriter/Bingishere_A002/bing-logo_2.jpg\"/>";
            String expectedResult = "<img src=\"http://blogs.msdn.com/blogfiles/klevereblog/WindowsLiveWriter/Bingishere_A002/bing-logo_2.jpg\" />";

            HtmlNode htmlNode = Parser.Parse(htmlText);

            Assert.IsNotNull(htmlNode, "The HtmlNode returned by the parser is null.");

            Assert.AreEqual<int>(htmlNode.Children.Count, 1);

            Assert.IsInstanceOfType(htmlNode.Children[0], typeof(HtmlImgNode));

            HtmlImgNode imgNode = htmlNode.Children[0] as HtmlImgNode;

            Assert.AreEqual<int>(imgNode.Children.Count, 0);

            Assert.AreEqual<string>(expectedResult, htmlNode.InnerHtml);

            Assert.AreEqual<int>(imgNode.Attributes.Count, 1);
            Assert.AreEqual<int>(imgNode.Styles.Count, 0);
            var temp = imgNode.Attributes.Where(i=>i.Key == "src");
            Assert.AreEqual<int>(temp.Count(), 1);
            Assert.AreEqual<string>(temp.Single().Value, "http://blogs.msdn.com/blogfiles/klevereblog/WindowsLiveWriter/Bingishere_A002/bing-logo_2.jpg");
        }
    }
}

