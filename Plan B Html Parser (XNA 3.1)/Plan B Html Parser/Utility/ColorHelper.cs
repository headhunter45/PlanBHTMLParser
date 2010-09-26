using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanB.Html.Utility
{
    internal class ColorHelper
    {
        internal static Color FromHtml(string htmlColorString)
        {
            Regex htmlColorRegex = new Regex("^#(?<color>[0-9A-Fa-f]{6})(?<alpha>[0-9A-Fa-f]{2})?$");

            Match match = htmlColorRegex.Match(htmlColorString);

            if (match.Success)
            {
                string strColor = match.Groups["color"].Value;
                string strAlpha = match.Groups["alpha"].Value;

                int red = int.Parse(strColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                int green = int.Parse(strColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                int blue = int.Parse(strColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                int alpha = 255;
                if (!String.IsNullOrEmpty(strAlpha))
                {
                    alpha = int.Parse(strAlpha, System.Globalization.NumberStyles.HexNumber);
                }

                Vector4 v = new Vector4();
                v.W = alpha / 255.0f;
                v.X = red / 255.0f;
                v.Y = green / 255.0f;
                v.Z = blue / 255.0f;

                return new Color(v);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal static Color FromCssName(string cssName)
        {
            cssName = cssName.ToLower();
            if (cssName == "aliceblue")
            {
                return FromHtml("#F0F8FF");
            }
            else if (cssName == "antiquewhite")
            {
                return FromHtml("#FAEBD7");
            }
            else if (cssName == "aqua")
            {
                return FromHtml("#00FFFF");
            }
            else if (cssName == "aquamarine")
            {
                return FromHtml("#7FFFD4");
            }
            else if (cssName == "azure")
            {
                return FromHtml("#F0FFFF");
            }
            else if (cssName == "beige")
            {
                return FromHtml("#F5F5DC");
            }
            else if (cssName == "bisque")
            {
                return FromHtml("#FFE4C4");
            }
            else if (cssName == "black")
            {
                return FromHtml("#000000");
            }
            else if (cssName == "blanchedalmond")
            {
                return FromHtml("#FFEBCD");
            }
            else if (cssName == "blue")
            {
                return FromHtml("#0000FF");
            }
            else if (cssName == "blueviolet")
            {
                return FromHtml("#8A2BE2");
            }
            else if (cssName == "brown")
            {
                return FromHtml("#A52A2A");
            }
            else if (cssName == "burlywood")
            {
                return FromHtml("#DEB887");
            }
            else if (cssName == "cadetblue")
            {
                return FromHtml("#5F9EA0");
            }
            else if (cssName == "chartreuse")
            {
                return FromHtml("#7FFF00");
            }
            else if (cssName == "chocolate")
            {
                return FromHtml("#D2691E");
            }
            else if (cssName == "coral")
            {
                return FromHtml("#FF7F50");
            }
            else if (cssName == "cornflowerblue")
            {
                return FromHtml("#6495ED");
            }
            else if (cssName == "cornsilk")
            {
                return FromHtml("#FFF8DC");
            }
            else if (cssName == "crimson")
            {
                return FromHtml("#DC143C");
            }
            else if (cssName == "cyan")
            {
                return FromHtml("#00FFFF");
            }
            else if (cssName == "darkblue")
            {
                return FromHtml("#00008B");
            }
            else if (cssName == "darkvyan")
            {
                return FromHtml("#008B8B");
            }
            else if (cssName == "darkgoldenrod")
            {
                return FromHtml("#B8860B");
            }
            else if (cssName == "darkgray")
            {
                return FromHtml("#A9A9A9");
            }
            else if (cssName == "darkgreen")
            {
                return FromHtml("#006400");
            }
            else if (cssName == "darkkhaki")
            {
                return FromHtml("#BDB76B");
            }
            else if (cssName == "darkmagenta")
            {
                return FromHtml("#8B008B");
            }
            else if (cssName == "darkolivegreen")
            {
                return FromHtml("#556B2F");
            }
            else if (cssName == "darkorange")
            {
                return FromHtml("#FF8C00");
            }
            else if (cssName == "darkorchid")
            {
                return FromHtml("#9932CC");
            }
            else if (cssName == "darkred")
            {
                return FromHtml("#8B0000");
            }
            else if (cssName == "darksalmon")
            {
                return FromHtml("#E9967A");
            }
            else if (cssName == "darkseagreen")
            {
                return FromHtml("#8FBC8F");
            }
            else if (cssName == "darkslateblue")
            {
                return FromHtml("#483D8B");
            }
            else if (cssName == "darkslategray")
            {
                return FromHtml("#2F4F4F");
            }
            else if (cssName == "darkturquoise")
            {
                return FromHtml("#00CED1");
            }
            else if (cssName == "darviolet")
            {
                return FromHtml("#9400D3");
            }
            else if (cssName == "deeppink")
            {
                return FromHtml("#FF1493");
            }
            else if (cssName == "deepskyblue")
            {
                return FromHtml("#00BFFF");
            }
            else if (cssName == "dimgray")
            {
                return FromHtml("#696969");
            }
            else if (cssName == "dodgerblue")
            {
                return FromHtml("#1E90FF");
            }
            else if (cssName == "firebrick")
            {
                return FromHtml("#B22222");
            }
            else if (cssName == "floralwhite")
            {
                return FromHtml("#FFFAF0");
            }
            else if (cssName == "forestgreen")
            {
                return FromHtml("#228B22");
            }
            else if (cssName == "fuchsia")
            {
                return FromHtml("#FF00FF");
            }
            else if (cssName == "gainsboro")
            {
                return FromHtml("#DCDCDC");
            }
            else if (cssName == "ghostwhite")
            {
                return FromHtml("#F8F8FF");
            }
            else if (cssName == "gold")
            {
                return FromHtml("#FFD700");
            }
            else if (cssName == "goldenrod")
            {
                return FromHtml("#DAA520");
            }
            else if (cssName == "gray")
            {
                return FromHtml("#808080");
            }
            else if (cssName == "green")
            {
                return FromHtml("#008000");
            }
            else if (cssName == "greenyellow")
            {
                return FromHtml("#ADFF2F");
            }
            else if (cssName == "honeydew")
            {
                return FromHtml("#F0FFF0");
            }
            else if (cssName == "hotpink")
            {
                return FromHtml("#FF69B4");
            }
            else if (cssName == "indianred") { return FromHtml("#CD5C5C"); }
            else if (cssName == "indigo") { return FromHtml("#4B0082"); }
            else if (cssName == "ivory")
            {
                return FromHtml("#FFFFF0");
            }
            else if (cssName == "khaki")
            {
                return FromHtml("#F0E68C");
            }
            else if (cssName == "lavender")
            {
                return FromHtml("#E6E6FA");
            }
            else if (cssName == "lavenderblush")
            {
                return FromHtml("#FFF0F5");
            }
            else if (cssName == "lawngreen")
            {
                return FromHtml("#7CFC00");
            }
            else if (cssName == "lemonchiffon")
            {
                return FromHtml("#FFFACD");
            }
            else if (cssName == "lightblue")
            {
                return FromHtml("#ADD8E6");
            }
            else if (cssName == "lightcoral")
            {
                return FromHtml("#F08080");
            }
            else if (cssName == "lightcyan")
            {
                return FromHtml("#E0FFFF");
            }
            else if (cssName == "lightgoldenrodyellow")
            {
                return FromHtml("#FAFAD2");
            }
            else if (cssName == "lightgrey")
            {
                return FromHtml("#D3D3D3");
            }
            else if (cssName == "lightgreen")
            {
                return FromHtml("#90EE90");
            }
            else if (cssName == "lightpink")
            {
                return FromHtml("#FFB6C1");
            }
            else if (cssName == "lightsalmon")
            {
                return FromHtml("#FFA07A");
            }
            else if (cssName == "lightseagreen")
            {
                return FromHtml("#20B2AA");
            }
            else if (cssName == "lightskyblue")
            {
                return FromHtml("#87CEFA");
            }
            else if (cssName == "lightslategray")
            {
                return FromHtml("#778899");
            }
            else if (cssName == "lightsteelblue")
            {
                return FromHtml("#B0C4DE");
            }
            else if (cssName == "lightyellow")
            {
                return FromHtml("#FFFFE0");
            }
            else if (cssName == "lime")
            {
                return FromHtml("#00FF00");
            }
            else if (cssName == "limegreen")
            {
                return FromHtml("#32CD32");
            }
            else if (cssName == "linen")
            {
                return FromHtml("#FAF0E6");
            }
            else if (cssName == "magenta")
            {
                return FromHtml("#FF00FF");
            }
            else if (cssName == "maroon")
            {
                return FromHtml("#800000");
            }
            else if (cssName == "mediumaquamarine")
            {
                return FromHtml("#66CDAA");
            }
            else if (cssName == "mediumblue")
            {
                return FromHtml("#0000CD");
            }
            else if (cssName == "mediumorchid")
            {
                return FromHtml("#BA55D3");
            }
            else if (cssName == "mediumpurple")
            {
                return FromHtml("#9370D8");
            }
            else if (cssName == "mediumseagreen")
            {
                return FromHtml("#3CB371");
            }
            else if (cssName == "mediumslateblue")
            {
                return FromHtml("#7B68EE");
            }
            else if (cssName == "mediumspringgreen")
            {
                return FromHtml("#00FA9A");
            }
            else if (cssName == "mediumturquoise")
            {
                return FromHtml("#48D1CC");
            }
            else if (cssName == "mediumvioletred")
            {
                return FromHtml("#C71585");
            }
            else if (cssName == "midnightblue")
            {
                return FromHtml("#191970");
            }
            else if (cssName == "mintcream")
            {
                return FromHtml("#F5FFFA");
            }
            else if (cssName == "mistyrose")
            {
                return FromHtml("#FFE4E1");
            }
            else if (cssName == "moccasin")
            {
                return FromHtml("#FFE4B5");
            }
            else if (cssName == "navajowhite")
            {
                return FromHtml("#FFDEAD");
            }
            else if (cssName == "navy")
            {
                return FromHtml("#000080");
            }
            else if (cssName == "oldlace")
            {
                return FromHtml("#FDF5E6");
            }
            else if (cssName == "olive")
            {
                return FromHtml("#808000");
            }
            else if (cssName == "olivedrab")
            {
                return FromHtml("#6B8E23");
            }
            else if (cssName == "orange")
            {
                return FromHtml("#FFA500");
            }
            else if (cssName == "orangered")
            {
                return FromHtml("#FF4500");
            }
            else if (cssName == "orchid")
            {
                return FromHtml("#DA70D6");
            }
            else if (cssName == "palegoldenrod")
            {
                return FromHtml("#EEE8AA");
            }
            else if (cssName == "palegreen")
            {
                return FromHtml("#98FB98");
            }
            else if (cssName == "paleturquoise")
            {
                return FromHtml("#AFEEEE");
            }
            else if (cssName == "palevioletred")
            {
                return FromHtml("#D87093");
            }
            else if (cssName == "papayawhip")
            {
                return FromHtml("#FFEFD5");
            }
            else if (cssName == "peachpuff")
            {
                return FromHtml("#FFDAB9");
            }
            else if (cssName == "peru")
            {
                return FromHtml("#CD853F");
            }
            else if (cssName == "pink")
            {
                return FromHtml("#FFC0CB");
            }
            else if (cssName == "plum")
            {
                return FromHtml("#DDA0DD");
            }
            else if (cssName == "powderblue")
            {
                return FromHtml("#B0E0E6");
            }
            else if (cssName == "purple")
            {
                return FromHtml("#800080");
            }
            else if (cssName == "red")
            {
                return FromHtml("#FF0000");
            }
            else if (cssName == "rosybrown")
            {
                return FromHtml("#BC8F8F");
            }
            else if (cssName == "royalblue")
            {
                return FromHtml("#4169E1");
            }
            else if (cssName == "saddlebrown")
            {
                return FromHtml("#8B4513");
            }
            else if (cssName == "salmon")
            {
                return FromHtml("#FA8072");
            }
            else if (cssName == "sandybrown")
            {
                return FromHtml("#F4A460");
            }
            else if (cssName == "seagreen")
            {
                return FromHtml("#2E8B57");
            }
            else if (cssName == "seashell")
            {
                return FromHtml("#FFF5EE");
            }
            else if (cssName == "sienna")
            {
                return FromHtml("#A0522D");
            }
            else if (cssName == "silver")
            {
                return FromHtml("#C0C0C0");
            }
            else if (cssName == "skyblue")
            {
                return FromHtml("#87CEEB");
            }
            else if (cssName == "slateblue")
            {
                return FromHtml("#6A5ACD");
            }
            else if (cssName == "slategray")
            {
                return FromHtml("#708090");
            }
            else if (cssName == "snow")
            {
                return FromHtml("#FFFAFA");
            }
            else if (cssName == "springgreen")
            {
                return FromHtml("#00FF7F");
            }
            else if (cssName == "steelblue")
            {
                return FromHtml("#4682B4");
            }
            else if (cssName == "tan")
            {
                return FromHtml("#D2B48C");
            }
            else if (cssName == "teal")
            {
                return FromHtml("#008080");
            }
            else if (cssName == "thistle")
            {
                return FromHtml("#D8BFD8");
            }
            else if (cssName == "tomato")
            {
                return FromHtml("#FF6347");
            }
            else if (cssName == "turquoise")
            {
                return FromHtml("#40E0D0");
            }
            else if (cssName == "violet")
            {
                return FromHtml("#EE82EE");
            }
            else if (cssName == "wheat")
            {
                return FromHtml("#F5DEB3");
            }
            else if (cssName == "white")
            {
                return FromHtml("#FFFFFF");
            }
            else if (cssName == "whitesmoke")
            {
                return FromHtml("#F5F5F5");
            }
            else if (cssName == "yellow")
            {
                return FromHtml("#FFFF00");
            }
            else if (cssName == "yellowgreen")
            {
                return FromHtml("#9ACD32");
            }

            throw new NotImplementedException();
        }

        internal static Color FromCss(string cssColor)
        {
            //TODO: Identify the different types of colors in css ie "rgb(0, 1, 2)", "black", "#FFEE00", their rbga varieties and any others I've missed.
            return FromCssName(cssColor);
        }
    }
}
