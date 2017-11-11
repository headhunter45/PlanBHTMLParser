using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public class HtmlImgNode: HtmlNode
    {
        public static string StaticTagName { get { return "img"; } }
        public override string TagName { get { return StaticTagName; } }

        public HtmlImgNode()
        {
            Type = HtmlNodeType.Img;
        }
    }
}
