// This is a part implementation of Template class, separated, 
// because the XSD based generated code in the Template.cs, can be regenerated.


using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StrengthReport.Templating {

    /// <summary>
    /// Template is the representation of visual design or a report.
    /// </summary>
    public partial class Template {

    }

    public partial class Style {
        /// <summary>
        /// Key: PATH (FontName property), Value: The generated name. 
        /// </summary>
        private static Dictionary<string, string> FontAliases = new Dictionary<string, string>();

        internal int getAlignment() {
            switch (this.Alignment) {
                case StyleAlignment.Center: return Element.ALIGN_CENTER;
                case StyleAlignment.Left: return Element.ALIGN_LEFT;
                case StyleAlignment.Right: return Element.ALIGN_RIGHT;
                default: return Element.ALIGN_UNDEFINED;
            }
        }


        internal iTextSharp.text.Font getFont() {
            //TODO:Error handling

            int fontStyle = iTextSharp.text.Font.NORMAL;
            switch (this.Font.FontStyle) {
                case FontFontStyle.Normal:
                    fontStyle = iTextSharp.text.Font.NORMAL;
                    break;
                case FontFontStyle.Bold:
                    fontStyle = iTextSharp.text.Font.BOLD;
                    break;
                case FontFontStyle.Italic:
                    fontStyle = iTextSharp.text.Font.ITALIC;
                    break;
                case FontFontStyle.BoldItalic:
                    fontStyle = iTextSharp.text.Font.BOLDITALIC;
                    break;
            }

            iTextSharp.text.Font iFont = null;
            if (this.Font.Source == FontSource.SYSTEM) {
                iFont = FontFactory.GetFont(this.Font.FontName, this.Font.getEncoding(), this.Font.Embed, this.Font.Size, fontStyle, this.Font.getColor());
            } else {
                if (!FontAliases.ContainsKey(Font.FontName)) {
                    Guid guid = new Guid();
                    FontFactory.Register(Font.FontName, guid.ToString("N"));
                    FontAliases.Add(Font.FontName, guid.ToString("N"));
                }
                iFont = FontFactory.GetFont(FontAliases[Font.FontName], Font.getEncoding(), Font.Embed, Font.Size, fontStyle, this.Font.getColor());
            }
            return iFont;
        }

        internal Color Background {
            get { return Backgrounds.Items[0]; }
        }

        internal Color BackgroundA {
            get { return Backgrounds.Items[0]; }
        }
        internal Color BackgroundB {
            get { if (Backgrounds.Items.Length > 1) return Backgrounds.Items[1]; else return Backgrounds.Items[0]; }
        }


    }

    public partial class Font {
        internal iTextSharp.text.Color getColor() {
            return this.Color.ToColor();
        }

        internal string getEncoding() {
            if (this.Encoding == "default") return iTextSharp.text.FontFactory.DefaultEncoding;
            else return this.Encoding;
        }
    }

    public partial class Color {
        public string GetHex() {
            double _C = (C / 100.0 * (1 - K/100.0) + K/100.0);
            double _M = (M / 100.0 * (1 - K / 100.0) + K / 100.0);
            double _Y = (Y / 100.0 * (1 - K / 100.0) + K / 100.0);
            int R = (int)((1 - _C) * 255);
            int G = (int)((1 - _M) * 255);
            int B = (int)((1 - _Y) * 255);
            return "#" + R.ToString("X2") + G.ToString("X2") + G.ToString("X2");
        }

        public CMYKColor ToColor() {
            return new CMYKColor((int)(C * 2.55), (int)(M * 2.55), (int)(Y * 2.55), (int)(K * 2.55));
        }
    }
}
