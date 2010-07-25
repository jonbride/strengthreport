using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StrengthReport.Reporting {
    public interface IReport {
        
        Stream Output { get; }

        /// <summary>
        /// Add a new heading, beginning of a new password group
        /// </summary>
        /// <param name="title"></param>
        void AddGroup(string title);

        /// <summary>
        /// Add a row to the report where data[i] represents 
        /// the i.th column of the new row.
        /// </summary>
        /// <param name="data">String for each column.</param>
        void AddRow(string[] data);

        /// <summary>
        /// Finishes the report and close it.
        /// </summary>
        void Close();
    }
}
