﻿using LogBook.Lib;

Console.WriteLine("Willkommen beim Fahrtenbuch");

string path = "logbook.xml";

IRepository repository = new XMLRepository(path);

repository.Add(new Entry(DateTime.Now, DateTime.Now.AddHours(2).AddMinutes(22), 25000, 25170, "ZE-XY123", "Zell am See", "München"));

Entry entrySaalfelden = new Entry(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddMinutes(20), 25500, 25514, "ZE-XY123", "Zell am See", "Saalfelden");

List<Entry> entries = repository.GetAll();

foreach (Entry entry in entries)
{
    Console.WriteLine(entry);
}