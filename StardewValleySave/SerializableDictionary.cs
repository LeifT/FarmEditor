using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace StardewValleySave {
    [XmlRoot("dictionary")]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable, INotifyCollectionChanged
    {
        public SerializableDictionary()
        {
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (object)key, 0));
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(null, e);
            }
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(TValue));
            bool isEmptyElement = reader.IsEmptyElement;
            reader.Read();
            if (isEmptyElement)
            {
                return;
            }
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey tKey = (TKey)xmlSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue tValue = (TValue)xmlSerializer1.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(tKey, tValue);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        public new bool Remove(TKey key)
        {
            bool flag = base.Remove(key);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, (object)key, 0));
            return flag;
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(TValue));
            foreach (TKey key in base.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                xmlSerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                xmlSerializer1.Serialize(writer, base[key]);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
