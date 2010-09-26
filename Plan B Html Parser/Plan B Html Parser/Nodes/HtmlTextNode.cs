using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlanB.Html.Nodes
{
    public class HtmlTextNode: HtmlNode
    {
        public String Text { get; set; }
        public override string ToString()
        {
            return Text;
        }

        public HtmlTextNode()
        {
            Text = String.Empty;
            Type = HtmlNodeType.Text_;
        }

        public HtmlTextNode(String text)
        {
            Text = text;
            Type = HtmlNodeType.Text_;
        }

        public override string InnerHtml
        {
            get
            {
                return String.Empty;
            }
        }

        public override string OuterHtml
        {
            get
            {
                return Entitize(Text);
            }
        }

        public override string TagName
        {
            get { return "_Text"; }
        }

        private string Entitize(string Text)
        {
            string temp = Text;

            temp = temp.Replace("&", "&amp;");
            temp = temp.Replace("<", "&lt;");
            temp = temp.Replace(">", "&gt;");
            temp = temp.Replace("\"", "&quot;");

            return temp;
        }
    }
}
