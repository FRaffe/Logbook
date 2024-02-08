using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public class MemoryRepository : IRepository
{
    List<Entry> list = new List<Entry>()
        {
            new Entry(DateTime.Now, DateTime.Now, 10000, 10100, "ZE-1234", "Zell am See", "Salzburg"),
            new Entry(DateTime.Now, DateTime.Now, 10100, 10200, "ZE-1234", "Salzburg", "Zell am See")
        };


    public bool Add(Entry entry)
    {
        list.Add(entry);
        return true;
    }

    public bool Delete(Entry entry)
    {
        return list.Remove(entry);
    }

    public Entry? Find(string id)
    {
        var entries = from e in list
                      where e.Id == id 
                      select e;

        return entries.FirstOrDefault();
    }

    public List<Entry> GetAll()
    {


        return this.list;

    }

    public bool Save()
    {
        return true;
    }

    public bool Update(Entry entry)
    {
        var item = (from search in list
                   where entry.Id == search.Id
                   select search).FirstOrDefault();

        if (item != null) 
        {
            item = entry;
            return true;
        }

        return false;
    }
}
