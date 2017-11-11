using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Tokens
{
    internal class HtmlTextToken: HtmlToken
    {
        public string Text { get; set; }

        public HtmlTextToken()
        {
            Text = String.Empty;
        }

        public HtmlTextToken(string str)
        {
            Text = str;
        }

        public override string ToString()
        {
            return Text ?? String.Empty;
        }
    }
}
