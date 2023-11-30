using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication1.Model;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public string Greeting => "Welcome to Avalonia!";

    private DateTimeOffset _date;
    
    private bool _isOld;
    
    public DateTimeOffset Date
    {
        get => _date;

        set
        {
            SetField(ref _date, value);
            var newDate = DateTime.Now.Year;
            SetField(ref _isOld, true);
           
        }
    }

    public bool IsOld
    {
        get => _isOld;
        set => SetField(ref _isOld, value);
    }

    public IList<SampleDto> List { get; } = new ObservableCollection<SampleDto>
        { { new SampleDto { Header = "", Message = "" } } };

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName= null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}