/// <author>Adam Erdelyi (Erdelyi.Adam@stud.u-szeged.hu)</author>

namespace StrengthReport.Measuring {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum PasswordQuality {
        Error = -1,
        VeryWeak,
        Weak,
        Better,
        Medium,
        Strong,
        Strongest,
    }

    sealed public class PasswordQualityFormat {
        private PasswordQualityFormat() { }

        public static string Format(PasswordQuality quality) {
            switch (quality) {
                case PasswordQuality.Error: return "Error!";
                case PasswordQuality.VeryWeak: return "Very weak 1/6";
                case PasswordQuality.Weak: return "Weak 2/6";
                case PasswordQuality.Better: return "Better 3/6";
                case PasswordQuality.Medium: return "Medium 4/6";
                case PasswordQuality.Strong: return "Strong 5/6";
                case PasswordQuality.Strongest: return "Strongest 6/6";
            }
            return "Error!?";
        }

        internal static PasswordQuality Parse(string s) {
            switch (s) {
                case "Error!": return PasswordQuality.Error;
                case "Very weak 1/6": return PasswordQuality.VeryWeak;
                case "Weak 2/6": return PasswordQuality.Weak;
                case "Better 3/6": return PasswordQuality.Better;
                case "Medium 4/6": return PasswordQuality.Medium;
                case "Strong 5/6": return PasswordQuality.Strong;
                case "Strongest 6/6": return PasswordQuality.Strongest;
            }
            return PasswordQuality.Error;
        }
    }
}
