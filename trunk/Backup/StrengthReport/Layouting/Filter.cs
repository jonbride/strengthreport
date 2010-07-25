/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using StrengthReport.Measuring;
using System.Collections.ObjectModel;

namespace StrengthReport.Layouting {
    /// <summary>
    /// Filtering class, this is a part of LayoutElement, it is evaluated to the result of LayoutElement, 
    /// and gives a True or False value, according to the configuration.
    /// Serializable.
    /// </summary>
    public class Filter {

        private static List<string> m_ComparatorPasswordQuality = new List<string> { "<", "<=", "=", ">=", ">" };
        private static string[] m_ComparatorPasswordQualityArray = m_ComparatorPasswordQuality.ToArray();
        /// <summary>
        /// Available compare functions for <see>PasswordQuality</see> objects.
        /// </summary>
        public static string[] ComparatorPasswordQuality { get { return m_ComparatorPasswordQualityArray; } }

        private static List<string> m_ComparatorString = new List<string> { "shorter than", "length is", "longer than", "contains", "not contains", "< (string)", "<= (string)", "= (string)", ">= (string)", "> (string)" };
        private static string[] m_ComparatorStringArray = m_ComparatorString.ToArray();
        /// <summary>
        /// Available compares for Strings.
        /// </summary>
        public static string[] ComparatorString { get { return m_ComparatorStringArray; } }

        /// <summary>
        /// Selected comparator, represented as string, from the <see>comparatorPasswordQuality</see> and <see>comparatorString</see>.
        /// </summary>
        public string Comparator { get; set; }

        /// <summary>
        /// Etalon given for comparison.
        /// </summary>
        public string CompareWith { get; set; }

        /// <summary>
        /// Is this filter Active?
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Default constructor. (Needed for Serialization also.)
        /// </summary>
        public Filter() {
            Enabled = false;
        }

        /// <summary>
        /// Do the comparison for strings.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>True if the s gives true for the Etalon and the stored comparison method.</returns>
        private bool CompareString(string s) {
            int i = -1;
            try {
                i = int.Parse(this.CompareWith);
            } catch (FormatException e) {
                Console.Error.WriteLine(e.ToString());
            }

            switch (this.Comparator) {
                case "shorter than": if (i < 0) return true; else return s.Length < i;
                case "length is": if (i < 0) return true; else return s.Length == i;
                case "longer than": if (i < 0) return true; else return s.Length > i;
                case "contains": return s.Contains(this.CompareWith);
                case "not contains": return !s.Contains(this.CompareWith);
                case "< (string)": return s.CompareTo(this.CompareWith) < 0;
                case "<= (string)": return s.CompareTo(this.CompareWith) <= 0;
                case "= (string)": return s.CompareTo(this.CompareWith) == 0;
                case ">= (string)": return s.CompareTo(this.CompareWith) >= 0;
                case "> (string)": return s.CompareTo(this.CompareWith) > 0;
                default: return true;
            }
        }

        /// <summary>
        /// Compare for <see>PasswordQuality</see> object, if PQ comes in string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool ComparePasswordQuality(string s) {
            PasswordQuality q = PasswordQualityFormat.Parse(s);
            return ComparePasswordQuality(q);
        }

        /// <summary>
        /// Compare for <see>PasswordQuality</see> object.
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        private bool ComparePasswordQuality(PasswordQuality q) {
            PasswordQuality me = (PasswordQuality) Enum.Parse(typeof(PasswordQuality), CompareWith);
            switch (this.Comparator) {
                case "<": return q < me;
                case "<=": return q <= me;
                case "=": return q == me;
                case ">=": return q >= me;
                case ">": return q > me;
            }
            return true;
        }
        
        /// <summary>
        /// General evaluation for Filter.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Evaluate(string columnValue) {
            if (m_ComparatorPasswordQuality.Contains(this.Comparator)) {
                return ComparePasswordQuality(columnValue);
            } else if (m_ComparatorString.Contains(this.Comparator)) {
                return CompareString(columnValue);
            } else return true;
        }


        public Filter Clone() {
            Filter item = new Filter();
            item.Comparator = this.Comparator;
            item.CompareWith = this.CompareWith;
            item.Enabled = this.Enabled;
            return item;
        }

        public override bool Equals(object obj) {
            if (obj is Filter) {
                Filter item = (Filter)obj;
                return (item.Comparator == this.Comparator) && (item.CompareWith == this.CompareWith) && (item.Enabled == this.Enabled);
            } else 
                return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
