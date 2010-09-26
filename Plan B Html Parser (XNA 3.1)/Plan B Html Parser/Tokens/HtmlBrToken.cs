using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Tokens
{
    public class HtmlBrToken: HtmlToken
    {
        public override string ToString()
        {
            return "<br/>";
        }
    }
}
