using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Tokens
{
    internal class HtmlBrToken: HtmlToken
    {
        public override string ToString()
        {
            return "<br/>";
        }
    }
}
