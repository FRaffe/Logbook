﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib;

public class XMLRepository : IRepository
{
    XElement _rootElement;
    public XMLRepository(string path)
    {
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
        throw new NotImplementedException();
    }

    public bool Delete(Entry entry)
    {
        throw new NotImplementedException();
    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootElement.Decendants("entry")
                      select entry;

        //TODO:
        //-objekt Entry erstellen
        //-liste zurückgeben
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }

    public bool Update(Entry entry)
    {
        throw new NotImplementedException();
    }
}
