using LogBook.Lib;

Console.WriteLine("Willkommen beim Fahrtenbuch");

IRepository repository = new MemoryRepository();





List<Entry> entries = repository.GetAll();

foreach (Entry entry in entries)
{
    Console.WriteLine(entry.From);
}