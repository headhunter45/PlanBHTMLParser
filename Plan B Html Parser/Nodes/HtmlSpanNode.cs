using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public class HtmlSpanNode: HtmlNode
    {
        public HtmlSpanNode()
        {
            Type = HtmlNodeType.Span;
        }

        public HtmlSpanNode(String text)
            :this()
        {
            Children.Add(new HtmlTextNode(text));
        }

        public HtmlSpanNode(IEnumerable<HtmlNode> children)
            :this()
        {
            foreach (HtmlNode child in children)
            {
                Children.Add(child);
            }
        }

        public override string TagName
        {
            get { return StaticTagName; }
        }

        public static string StaticTagName { get { return "span"; } }
    }
}
