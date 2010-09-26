using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanB.Html.Nodes
{
    public abstract class HtmlNode
    {
        public List<HtmlNode> Children { get; set; }
        public HtmlNodeType Type { get; protected set; }
        public List<KeyValuePair<string, string>> Attributes { get; set; }
        public List<KeyValuePair<string, string>> Styles { get; set; }

        public HtmlNode()
        {
            Attributes = new List<KeyValuePair<string, string>>();
            Children = new List<HtmlNode>();
            Styles = new List<KeyValuePair<string, string>>();
        }

        public virtual String InnerHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (HtmlNode childNode in Children)
                {
                    sb.Append(childNode.OuterHtml);
                }

                return sb.ToString();
            }
        }

        public virtual String OuterHtml
        {
            get
            {
                string styles = GetStylesString();
                string attributes = GetAttributesString();
                
                StringBuilder sb = new StringBuilder();

                sb.Append("<");
                sb.Append(TagName);
                
                if (!String.IsNullOrEmpty(styles))
                {
                    sb.Append(" ");
                    sb.Append(styles);
                }

                if (!String.IsNullOrEmpty(attributes))
                {
                    sb.Append(" ");
                    sb.Append(attributes);
                }

                if (Children.Count > 0)
                {
                    sb.Append(">");
                    sb.Append(InnerHtml);
                    sb.Append("</");
                    sb.Append(TagName);
                    sb.Append(">");
                }
                else
                {
                    sb.Append(" />");
                }

                return sb.ToString();
            }
        }

        public abstract String TagName{get;}

        protected virtual String GetAttributesString()
        {
            int numAttributes = Attributes.Count;

            if (numAttributes == 0)
            {
                return String.Empty;
            }
            else if (numAttributes == 1)
            {
                return Attributes[0].Key + "=\"" + Attributes[0].Value + "\"";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(Attributes[0].Key + "=\"" + Attributes[0].Value + "\"");

                foreach (KeyValuePair<string, string> attribute in Attributes.Skip(1))
                {
                    sb.Append(" " + attribute.Key + "=\"" + attribute.Value + "\"");
                }

                return sb.ToString();
            }
        }

        protected virtual String GetStylesString()
        {
            int numStyles = Styles.Count;

            if (numStyles == 0)
            {
                return String.Empty;
            }
            else if (numStyles == 1)
            {
                return "style=\"" + Styles[0].Key + ":" + Styles[0].Value + ";\"";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("style=\"" + Styles[0].Key + ":" + Styles[0].Value + ";\"");

                foreach (KeyValuePair<string, string> style in Styles.Skip(1))
                {
                    sb.Append(";" + style.Key + ":" + style.Value);
                }

                sb.Append("\"");

                return sb.ToString();
            }
        }

        public void AddAttribute(KeyValuePair<string, string> attribute)
        {
            KeyValuePair<string, string> newAttribute = new KeyValuePair<string, string>(attribute.Key.ToLower(), attribute.Value);

            if (newAttribute.Key == "style")
            {
                ClearStyles();
                String styleString = newAttribute.Value;
                string[] stylePairStrings = styleString.Split(new char[] { ';' });
                KeyValuePair<string, string> style;

                foreach (string stylePairString in stylePairStrings)
                {
                    string[] temp = stylePairString.Split(new char[] { ':' });
                    if (temp.Length == 1)
                    {
                        style = new KeyValuePair<string, string>(temp[0], String.Empty);
                    }
                    else if (temp.Length >= 2)
                    {
                        style = new KeyValuePair<string, string>(temp[0], temp[1]);
                    }
                    else
                    {
                        style = new KeyValuePair<string, string>();
                    }

                    if (!String.IsNullOrEmpty(style.Key))
                    {
                        AddStyle(style);
                    }
                }
            }
            else
            {
                Attributes.RemoveAll(i => i.Key == newAttribute.Key);
                Attributes.Add(newAttribute);
            }
        }

        private void ClearStyles()
        {
            Styles.Clear();
        }

        public void AddStyle(KeyValuePair<string, string> style)
        {
            KeyValuePair<string, string> newStyle = new KeyValuePair<string,string>(style.Key.ToLower(), style.Value);

            Styles.RemoveAll(i => i.Key == newStyle.Key);
            Styles.Add(newStyle);
        }
    }

    public enum HtmlNodeType { Document_, Text_, Br, Span, Img, Paragraph, Div }
}
