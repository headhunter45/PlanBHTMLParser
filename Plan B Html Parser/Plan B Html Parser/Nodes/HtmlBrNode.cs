using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public class HtmlBrNode: HtmlNode
    {
        public override string ToString()
        {
            return Environment.NewLine;
        }

        public HtmlBrNode()
        {
            Type = HtmlNodeType.Br;
        }

        public override string TagName
        {
            get { return StaticTagName; }
        }

        public static string StaticTagName
        {
            get { return "br"; }
        }
    }
}
