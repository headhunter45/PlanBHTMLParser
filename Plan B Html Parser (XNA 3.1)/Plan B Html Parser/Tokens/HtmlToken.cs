using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlanB.Html.Tokens
{
    public class HtmlToken
    {
        public List<KeyValuePair<string, string>> Attributes { get; set; }

        public HtmlToken()
        {
            Attributes = new List<KeyValuePair<string, string>>();
        }

        public override string ToString()
        {
            return String.Empty;
        }

        internal void AddAttributes(Match m)
        {
            Group attributeNameGroup = m.Groups["attributeName"];
            Group attributeValueGroup = m.Groups["attributeValue"];

            //int numAttributes = m.Groups["attributeName"].Captures.Count;
            int numAttributes = attributeNameGroup.Captures.Count;

            for (int i = 0; i < numAttributes; i++)
            {
                //KeyValuePair<string, string> attribute = new KeyValuePair<string, string>(m.Groups["attributeName"].Captures[i].ToString(), m.Groups["attributeValue"].Captures[i].ToString());
                KeyValuePair<string, string> attribute = new KeyValuePair<string, string>(attributeNameGroup.Captures[i].ToString(), attributeValueGroup.Captures[i].ToString());
                Attributes.Add(attribute);
            }
        }
    }
}
