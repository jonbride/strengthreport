/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using StrengthReport.Measuring;

namespace StrengthReport.Layouting {

    /// <summary>
    /// Collection of "DataElement"-s
    /// </summary>
    public class DataElementList : List<DataElement> {

        /// <summary>
        /// Basic collection of available data elements.
        /// Discover classes implements FunctionAbstract, and put them into a list.
        /// </summary>
        public static DataElementList Standard {
            get {
                DataElementList lib = new DataElementList();

                foreach (EntryDataType e in Enum.GetValues(typeof(EntryDataType)))
                    lib.Add(new DataElement(e));

                List<FunctionAbstract> functions = FunctionBox.GetFunctionClasses();
                foreach (FunctionAbstract fnc in functions) {
                    lib.Add(new DataElement(fnc));
                }

                return lib;

            }
        }
    }

    /// <summary>
    /// Represent the "databinding" of a column in a Layout. This is a part of the
    /// LayoutElement. It binds the column to a static data of a function.
    /// Serializable.
    /// </summary>
    public class DataElement {

        #region Derived Properties
        /// <summary>
        /// Title of the dataelement.
        /// </summary>
        public string Title {
            get {
                if (IsFunction) 
                    return m_Function.Title;
                else 
                    return m_StaticData.ToString();
            }
        }

        /// <summary>
        /// Description of the DataElement.
        /// </summary>
        public string Desc {
            get {
                if (IsFunction)
                    return m_Function.Desc;
                else
                    return EntryDataTypeFormat.Format(m_StaticData);
            }
        }

        #endregion

        #region Fields
        private EntryDataType m_StaticData;
        private FunctionAbstract m_Function;
        #endregion

        #region Real Properties

        /// <summary>
        /// Represents a column from KeePass database.
        /// </summary>
        public EntryDataType StaticData {
            get { return m_StaticData; }
            set {
                m_StaticData = value;
                m_Function = null;
            }
        }

        /// <summary>
        /// Represents a function which implements FunctionAbstract, in the namespace Measuring
        /// Can be set on construction OR through FunctionType.
        /// </summary>
        public FunctionAbstract Function { 
            get { return m_Function; }
        }

        /// <summary>
        /// Represents the Function with it's name. Read-write, so when write it sets the m_Function.
        /// Needed for right serialization.
        /// </summary>
        public string FunctionType {
            get { return (m_Function == null ? "" : m_Function.GetType().FullName); }
            set {
                if (value.Length != 0) {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    Type type = asm.GetType(value);
                    if (type != null) {
                        Object o = asm.CreateInstance(type.FullName);
                        if (o is FunctionAbstract) {
                            m_Function = (FunctionAbstract)o;
                            m_StaticData = EntryDataType.Empty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tells if this element represents a Function or a StaticData (EntryDataType)
        /// </summary>
        public bool IsFunction { get { return (Function != null); } }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor, needed for Serialization.
        /// </summary>
        public DataElement() {
            StaticData = EntryDataType.Empty;
        }

        /// <summary>
        /// Create Dataelement with a Function content.
        /// </summary>
        /// <param name="function">The "function" itself wich implements FunctionAbstract.</param>
        public DataElement(FunctionAbstract function) {
            m_Function = function; 
            m_StaticData = EntryDataType.Empty;
        }

        /// <summary>
        /// Creates a DataElement with a Static Data. "Reference"
        /// </summary>
        /// <param name="staticData">The field'n name from KeePass database, enum.</param>
        public DataElement(EntryDataType staticData) {
            StaticData = staticData;
        }
        #endregion

        #region Methods from Object
        public override string ToString() {
            return Title;
        }

        public override bool Equals(Object other) {
            if (other is DataElement) {
                DataElement otherElement = (DataElement)other;
                if (this.IsFunction == otherElement.IsFunction) {
                    if (this.IsFunction == true) {
                        return (this.m_Function.Equals(otherElement.m_Function));
                    } else {
                        return (this.m_StaticData.Equals(otherElement.m_StaticData));
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #endregion


        public DataElement Clone() {
            if (this.IsFunction) {
                return new DataElement(this.Function);
            } else {
                return new DataElement(this.StaticData);
            }
        }
    }
}
