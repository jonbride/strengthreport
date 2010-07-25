/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;

namespace StrengthReport.Layouting {
    /// <summary>
    /// Each enum value match a value from an PwEntry's Dictionary.
    /// </summary>
    public enum EntryDataType {
        Empty,
        UserName,
        Password,
        Title,
        Notes,
        URL
    }

    /// <summary>
    /// Gives formatting function for the Enum of EntryDataType.
    /// </summary>
    sealed public class EntryDataTypeFormat {
         private EntryDataTypeFormat() { }
        /// <summary>
        /// Matches a string to each value of DataTypeEntry.
        /// </summary>
        /// <param name="dataType">The enum value which needs a string representation.</param>
        /// <returns></returns>
        public static string Format(EntryDataType dataType) {
            switch (dataType) {
                case EntryDataType.Empty: return "Empty string";
                case EntryDataType.Notes: return "The Notes value of the entry from KeePass database.";
                case EntryDataType.Password: return "The Password value of the entry from KeePass database.";
                case EntryDataType.Title: return "The Title value of the entry from KeePass database.";
                case EntryDataType.URL: return "The URL value of the entry from KeePass database.";
                case EntryDataType.UserName: return "The Username value of the entry from KeePass database.";
            }
            return "";
        }
    }
}
