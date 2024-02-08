using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib;

public class XMLRepository : IRepository
{
    XElement _rootElement;
    private string _path;
    public XMLRepository(string path)
    {
        _path = path;
        if (File.Exists(path))
        {
            _rootElement = XElement.Load(path);
        }
        else
        {
            _rootElement = new XElement("entries");
        }
    }
    public bool Add(Entry entry)
    {
        XElement node = new XElement("entry");

        var idAttrib = new XAttribute("id", entry.Id.ToString());
        node.Add(idAttrib);

        var startAttrib = new XAttribute("start", entry.Start.ToString());
        node.Add(startAttrib);

        var endAttrib = new XAttribute("end", entry.End.ToString());
        node.Add(endAttrib);

        var startKmAttrib = new XAttribute("startkm", entry.StartKM.ToString());
        node.Add(startKmAttrib);

        var endKmAttrib = new XAttribute("endKm", entry.EndKM.ToString());
        node.Add(endKmAttrib);

        var numberPlateAttrib = new XAttribute("numberplate", entry.NumberPlate.ToString());
        node.Add(numberPlateAttrib);

        var fromAttrib = new XAttribute("from", entry.From.ToString());
        node.Add(fromAttrib);

        var toAttrib = new XAttribute("to", entry.To.ToString());
        node.Add(toAttrib);

        node.Add(entry.Description.ToString());

        _rootElement.Add(node);

        return this.Save();
    }

    public bool Delete(Entry entry)
    {
        var itemsDel = from e in _rootElement.Descendants("entry")
                       where (string)e.Attribute("id") == entry.Id
                       select e;

        itemsDel.Remove();

        return this.Save();
    }

    public Entry? Find(string id)
    {
        var item = (from e in _rootElement.Descendants("entry")
                    where (string)e.Attribute("id") == id
                    select new Entry(Convert.ToDateTime(entry.Attribute("start").Value),
                                        Convert.ToDateTime(entry.Attribute("end").Value),
                                        (int)entry.Attribute("startkm"),
                                        (int)entry.Attribute("endkm"),
                                        entry.Attribute("numberplate").Value,
                                        entry.Attribute("from").Value,
                                        entry.Attribute("to").Value,
                                        entry.Attribute("id").Value
                                        )
                    {
                        Description = entry.Value
                    }).FirstOrDefault();

    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootElement.Descendants("entry")
                      select new Entry(Convert.ToDateTime(entry.Attribute("start").Value),
                                        Convert.ToDateTime(entry.Attribute("end").Value),
                                        (int)entry.Attribute("startkm"),
                                        (int)entry.Attribute("endkm"),
                                        entry.Attribute("numberplate").Value,
                                        entry.Attribute("from").Value,
                                        entry.Attribute("to").Value,
                                        entry.Attribute("id").Value
                                        )
                                        {
                                        Description = entry.Value
                                       };


        //TODO:
        //-objekt Entry erstellen
        //-liste zurückgeben

       // throw new NotImplementedException();

        return entries.ToList<Entry>();

        //return entries;
    }

    public bool Save()
    {
        try
        {
            _rootElement.Save(_path);
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Update(Entry entry)
    {
        var item = (from e in _rootElement.Descendants("entry")
                       where (string)e.Attribute("id") == entry.Id
                       select e).FirstOrDefault();

        if (item != null)
        {
            item.SetAttributeValue("start", entry.Start.ToString());
            item.SetAttributeValue("end", entry.End.ToString());
            item.SetAttributeValue("startkm", entry.StartKM.ToString());
            item.SetAttributeValue("endkm", entry.EndKM.ToString());
            item.SetAttributeValue("numberplate", entry.NumberPlate.ToString());
            item.SetAttributeValue("to", entry.To.ToString());
            item.SetAttributeValue("from", entry.From.ToString());

            // id nicht, da das object sonst nicht gefunden wird

            return this.Save();
        }
        else
        {
            return false;
        }

    }
}
