/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;


namespace StrengthReport.Layouting {
    /// <summary>
    /// Layout is a content mapping object for report.
    /// </summary>
    [XmlRoot("Layout")]
    public class Layout : List<LayoutElement>, IXmlSerializable {
        public Layout() : base() {
            
        }

        /// <summary>
        /// Sum width of all columns in the layout.
        /// </summary>
        public double Width {
            get {
                double width = 0;
                foreach (LayoutElement element in this) {
                    width += element.Width;
                }
                return width;
            }
        }

        /// <summary>
        /// Get each column width in an array.
        /// </summary>
        /// <returns></returns>
        public float[] GetColumnWidths() {
            float[] widths = new float[this.Count];
            double fullWidth = this.Width;
            for (int i = 0; i < this.Count; i++) {
                widths[i] = (float)(this[i].Width / fullWidth) * 100;
            }
            return widths;
        }

        /// <summary>
        /// Deep clone.
        /// </summary>
        /// <returns></returns>
        public Layout Clone() {
            Layout item = new Layout();
            foreach (LayoutElement element in this) {
                item.Add(element.Clone());
            }
            return item;
        }

        public override bool Equals(object obj) {
            if (obj is Layout) {
                Layout other = (Layout)obj;
                if (other.Count == this.Count) {
                    for (int i = 0; i < this.Count; i++) {
                        if (!this.Contains(other[i]))
                            return false;
                    }
                    return true;
                } else
                    return false;
            } else
                return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        private string m_Name;
        /// <summary>
        /// Name of Layout.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name {
            get { if (m_Name != null && m_Name.Length > 0) return m_Name; else return ""; }
            set { m_Name = value; }
        }

        private string m_Title;
        /// <summary>
        /// Title of Layout.
        /// </summary>
        [XmlAttribute("Title")]
        public string Title { get { if (m_Title == null || m_Title.Length == 0) return Name; else return m_Title; } set { m_Title = value; } }

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }

        public void ReadXml(XmlReader reader) {
            Name = reader.GetAttribute("Name");
            Title = reader.GetAttribute("Title");
            reader.ReadStartElement();
            this.AddRange((List<LayoutElement>)new XmlSerializer(typeof(List<LayoutElement>)).Deserialize(reader));
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("Name", Name);
            writer.WriteAttributeString("Title", Title);
            new XmlSerializer(typeof(List<LayoutElement>)).Serialize(writer, this);
        }

        #endregion
    }
}
