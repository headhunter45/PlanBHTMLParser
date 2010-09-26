using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public class HtmlDivNode: HtmlNode
    {
        public static string StaticTagName { get { return "div"; } }
        public override string TagName { get { return StaticTagName; } }
    }
}
