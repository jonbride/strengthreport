/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using StrengthReport.Layouting;
using StrengthReport.Reporting;
using StrengthReport.Measuring;

namespace StrengthReport.Layouting {
    /// <summary>
    /// Represent an element of a report layout. Serializable.
    /// </summary>
    [XmlRootAttribute(ElementName = "LayoutElement", IsNullable = false)]
    public class LayoutElement {
        #region Properties
        /// <summary>
        /// Width of column, represented by this element.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Represents the data that will be shown in the column. Can be static (any part of an entry) of dinamic (a function from FunctionAbstract)
        /// </summary>
        public DataElement Data { get; set; }

        public string DataDesc { get { return this.Data.Desc; } }

        /// <summary>
        /// Filter
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Title of column
        /// </summary>
        public string Title { get; set; }

        public string TitleExt { get { return this.ToString(); } }
        #endregion


        /// <summary>
        /// Default constructor. Needed by Serialization.
        /// </summary>
        public LayoutElement() {
            
        }

        /// <summary>
        /// Evaluate itself for a given <see>PwEntry</see>
        /// </summary>
        /// <param name="entry">KeePass database entry.</param>
        /// <returns></returns>
        public string EvaluateString(PwEntry entry) {
            if (Data.IsFunction)
                return PasswordQualityFormat.Format(this.Data.Function.Evaluate(entry));
            else if (Data.StaticData != EntryDataType.Empty)
                return FunctionAbstract.GetValue(entry, Data.StaticData);
            else
                return "";
        }

        /// <summary>
        /// Evaluates itself for a given <see>PwEntry</see>, but return a <see>PasswordQuality</see> object.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public PasswordQuality EvaluateQuality(PwEntry entry) {
            if (Data.IsFunction)
                return Data.Function.Evaluate(entry);
            else 
                return PasswordQuality.Error;
        }

        /// <summary>
        /// Concaterates a List of strings into a comma separated string.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string ListToString(List<string> list) {
            string ret = "";
            foreach (string o in list)
                ret += o + ", ";
            return ret;
        }

        public override string ToString() {
            return Title + ((Filter != null && Filter.Enabled) ? " FILTERED" : "");
        }

        #region ICloneable Members

        public LayoutElement Clone() {
            LayoutElement item = new LayoutElement();
            item.Width = Width;
            item.Data = Data.Clone();
            item.Filter = Filter.Clone();
            item.Title = Title;
            return item;
        }

        #endregion

        public override bool Equals(object obj) {
            if (obj is LayoutElement) {
                LayoutElement item = (LayoutElement)obj;
                return (this.Data.Equals(item.Data)) && (this.Filter.Equals(item.Filter)) && (this.Title.Equals(item.Title)) && (this.Width.Equals(item.Width));
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
        
    }
}
