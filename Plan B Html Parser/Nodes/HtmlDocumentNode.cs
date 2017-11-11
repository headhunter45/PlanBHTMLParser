using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public class HtmlDocumentNode: HtmlNode
    {
        public HtmlDocumentNode()
        {
            Type = HtmlNodeType.Document_;
        }

        public override string InnerHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (HtmlNode child in Children)
                {
                    sb.Append(child.OuterHtml);
                }

                return sb.ToString();
            }
        }

        public override string OuterHtml
        {
            get
            {
                return InnerHtml;
            }
        }





        public override string TagName
        {
            get { return "_Document"; }
        }
    }
}
