/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using StrengthReport.Layouting;
using StrengthReport.Measuring;

namespace StrengthReport.Measuring {
    abstract public class FunctionAbstract {
        #region Fields
        protected string m_Title;
        protected string m_Desc;
        #endregion

        #region Properties
        public string Title { get { return m_Title; } }

        /*public string GetTitle() {
            return m_Title;
        }*/

        public string Desc { get { return m_Desc; } }

        /*public string GetDesc() {
            return m_Desc;
        }*/

        #endregion

        public abstract PasswordQuality Evaluate(PwEntry entry);

        public override string ToString() {
            return m_Title;
        }

        
        public static string GetValue(PwEntry entry, EntryDataType key) {
            return entry.Strings.Get(key.ToString()).ReadString();
        }

        public override bool Equals(object obj) {
            return (obj.GetType() == this.GetType());
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
