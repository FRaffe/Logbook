using CommunityToolkit.Mvvm.ComponentModel;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogBookApp.ViewModels;

public partial class MainViewModel(IRepository repository) : ObservableObject
{
    public string Header => "Fahrtenbuch";
    IRepository _repository = repository;


}
