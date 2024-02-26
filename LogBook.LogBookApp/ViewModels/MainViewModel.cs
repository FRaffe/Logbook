using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogBookApp.ViewModels;

public partial class MainViewModel(IRepository repository) : ObservableObject
{
    public string Header => "Fahrtenbuch";
    IRepository _repository = repository;

    [ObservableProperty]
    ObservableCollection<Lib.Entry> _entries = [];

    #region Properties

    [ObservableProperty]
    DateTime _start = DateTime.Now;

    [ObservableProperty]
    DateTime _end = DateTime.Now;

    [ObservableProperty]
    string _description = string.Empty;

    [ObservableProperty]
    string _numberPlate = string.Empty;

    [ObservableProperty]
    int _startKM = 0;

    [ObservableProperty]
    int _endKM = 0;

    [ObservableProperty]
    string _from = string.Empty;

    [ObservableProperty]
    string _to = string.Empty;

    #endregion
    [RelayCommand]
    void LoadData()
    {
        var entries = _repository.GetAll();

        foreach (var entry in entries)
        {
            Entries.Add(entry);
        }
    }

    [RelayCommand]
    void Add()
    {
        Lib.Entry entrySaalfelden = new(
            DateTime.Now.AddDays(3), 
            DateTime.Now.AddDays(3).AddMinutes(20), 25500, 25514, 
            "ZE-XY123", "Zell am See", "Saalfelden") {
            Description = "Fahrt nach Saalfelden"
        };

        var result = _repository.Add(entrySaalfelden);
        if (result)
        {
            this.Entries.Add(entrySaalfelden);
        }
    }
}
