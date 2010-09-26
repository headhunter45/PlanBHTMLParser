using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using PlanB.Html.Nodes;
using System.Text;
using PlanB.Html.Tokens;
using System.Text.RegularExpressions;

namespace PlanB.Html
{
    public class Parser
    {
        public static List<HtmlToken> Tokenize(string htmlText)
        {
            List<HtmlToken> tokens = new List<HtmlToken>();

            int position = 0;
            int startOfNextToken = htmlText.IndexOf("<");

            //If the whole document is text then just create one HtmlTextToken
            if (startOfNextToken == -1)
            {
                tokens.Add(new HtmlTextToken(htmlText));
                return tokens;
            }

            while (startOfNextToken >= 0)
            {
                if (startOfNextToken > position)
                {
                    tokens.Add(new HtmlTextToken(htmlText.Substring(position, startOfNextToken - position)));
                }
                
                //Identify the type of token we are aproaching
                string tokenText = htmlText.Substring(startOfNextToken);
                string tokenName = String.Empty;
                Regex r = new Regex(@"<(?<tagName>/?\w+)((\s+)(?<attributeName>\w*)=\""(?<attributeValue>[^""]*)\"")*(\s*)(/)?(\s*)>");
                r = new Regex(@"<(?<tagName>/?\w+)(((\s+((?<attributeName>\w+)=(""(?<attributeValue>[^""]*)""))\s*))|((\s+((?<attributeName>\w+)=('(?<attributeValue>[^']*)'))\s*))|((\s+((?<attributeName>\w+)=(?<attributeValue>[^\s>]*))\s*)))*\s*(/)?(\s*)>");
                Match m = r.Match(tokenText);
                Console.WriteLine(m.ToString());
                tokenName = m.Groups["tagName"].Value;

                if (tokenName == HtmlSpanNode.StaticTagName)//"span"
                {
                    //TODO: Handle attributes
                    HtmlBeginSpanToken token = new HtmlBeginSpanToken();
                    token.AddAttributes(m);
                    tokens.Add(token);

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else if (tokenName == "/" + HtmlSpanNode.StaticTagName)//"/span"
                {
                    tokens.Add(new HtmlEndSpanToken());

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else if (tokenName == HtmlBrNode.StaticTagName)//"br"
                {
                    HtmlBrToken token = new HtmlBrToken();
                    token.AddAttributes(m);
                    tokens.Add(token);

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else if(tokenName == HtmlDivNode.StaticTagName)//"div"
                {
                    HtmlBeginDivToken token = new HtmlBeginDivToken();

                    token.AddAttributes(m);
                    tokens.Add(token);

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else if (tokenName == "/" + HtmlDivNode.StaticTagName)//"/div"
                {
                    tokens.Add(new HtmlEndDivToken());

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else if (tokenName == HtmlImgNode.StaticTagName)//"img"
                {
                    HtmlImgToken token = new HtmlImgToken();

                    token.AddAttributes(m);
                    tokens.Add(token);

                    position = htmlText.IndexOf(">", startOfNextToken) + 1;
                    startOfNextToken = htmlText.IndexOf("<", position);
                }
                else
                {
                    position = startOfNextToken;
                    startOfNextToken = htmlText.IndexOf("<", startOfNextToken + 1);

                }

            }

            if (htmlText.Length - 1 > position)
            {
                tokens.Add(new HtmlTextToken(htmlText.Substring(position)));
            }

            return tokens;
        }

        public static HtmlNode Parse(List<HtmlToken> tokens)
        {
            HtmlNode rootNode = new HtmlDocumentNode();
            
            int position = 0;
            
            GetContents(rootNode, tokens, ref position);
            
            return rootNode;
        }

        private static void GetContents(HtmlNode parentNode, List<HtmlToken> tokens, ref int position)
        {
            HtmlToken currentToken;
            bool throwExceptions = false;

            HtmlTextToken textToken = null;
            HtmlBrToken brToken = null;
            HtmlBeginSpanToken beginSpanToken = null;
            HtmlEndSpanToken endSpanToken = null;
            HtmlBeginDivToken beginDivToken = null;
            HtmlEndDivToken endDivToken = null;
            HtmlImgToken imgToken = null;
            
            currentToken = tokens[position];

            while (currentToken != null)
            {
                textToken = currentToken as HtmlTextToken;
                brToken = currentToken as HtmlBrToken;
                beginSpanToken = currentToken as HtmlBeginSpanToken;
                endSpanToken = currentToken as HtmlEndSpanToken;
                beginDivToken = currentToken as HtmlBeginDivToken;
                endDivToken = currentToken as HtmlEndDivToken;
                imgToken = currentToken as HtmlImgToken;    

                if (textToken != null)
                {
                    HtmlTextNode textNode = new HtmlTextNode();
                    textNode.Text = textToken.Text;
                    position++;

                    while (tokens.Count > position && (textToken = tokens[position] as HtmlTextToken) != null)
                    {
                        textNode.Text += textToken.Text;
                        position++;
                    }

                    parentNode.Children.Add(textNode);
                }
                else if (beginSpanToken != null)
                {
                    HtmlSpanNode spanNode = new HtmlSpanNode();
                    position++;
                    GetAttributes(spanNode, beginSpanToken);
                    GetContents(spanNode, tokens, ref position);
                    if (tokens.Count < position || tokens[position] as HtmlEndSpanToken == null)
                    {
                        if (throwExceptions)
                        {
                            throw new Exception("Missing end span tag");
                        }
                    }
                    parentNode.Children.Add(spanNode);
                    position++;
                }
                else if (endSpanToken != null)
                {
                    if (parentNode.GetType() == typeof(HtmlSpanNode))
                    {
                        return;
                    }
                    else
                    {
                        if (throwExceptions)
                        {
                            throw new Exception("Encountered closing span tag without matching open tag.");
                        }
                        else
                        {
                            position++;
                        }
                    }
                }
                else if (beginDivToken != null)
                {
                    HtmlDivNode divNode = new HtmlDivNode();
                    position++;
                    GetAttributes(divNode, beginDivToken);
                    GetContents(divNode, tokens, ref position);
                    if (tokens.Count <= position || tokens[position] as HtmlEndDivToken == null)
                    {
                        if (throwExceptions)
                        {
                            throw new Exception("Missing end div tag");
                        }
                    }
                    parentNode.Children.Add(divNode);
                    position++;
                }
                else if (endDivToken != null)
                {
                    if (parentNode.GetType() == typeof(HtmlDivNode))
                    {
                        return;
                    }
                    else
                    {
                        if (throwExceptions)
                        {
                            throw new Exception("Encountered closing div tag without matching open tag.");
                        }
                        else
                        {
                            position++;
                        }
                    }
                }
                else if (brToken != null)
                {
                    HtmlBrNode brNode = new HtmlBrNode();
                    GetAttributes(brNode, brToken);
                    parentNode.Children.Add(brNode);

                    position++;
                }
                else if (imgToken != null)
                {
                    HtmlImgNode imgNode = new HtmlImgNode();
                    GetAttributes(imgNode, imgToken);
                    parentNode.Children.Add(imgNode);

                    position++;
                }
                else
                {
                    position++;
                }
                
                if (tokens.Count > position)
                {
                    currentToken = tokens[position];
                }
                else
                {
                    return;
                }
            }
        }

        private static void GetAttributes(HtmlNode htmlNode, HtmlToken htmlToken)
        {

            foreach (KeyValuePair<string, string> kvp in htmlToken.Attributes)
            {
                htmlNode.AddAttribute(kvp);
            }
        }

        public static HtmlNode Parse(string text)
        {
            List<HtmlToken> tokens = Tokenize(text);
            HtmlNode rootNode = Parse(tokens);
            return rootNode;
            //return Parse(Tokenize(text));
        }
    }
}
