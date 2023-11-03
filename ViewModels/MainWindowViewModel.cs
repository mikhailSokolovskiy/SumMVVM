using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    
    private int _number1;
    public int Number1 { 
        get => _number1;
        set 
        { 
            _number1 = value;
            OnPropertyChanged("Number3"); // уведомление View о том, что изменилась сумма
        }
    }

    private int _number2;
    public int Number2 { 
        get => _number2;
        set
        {
            _number2 = value; 
            OnPropertyChanged("Number3"); 
        } 
    }

    public int Number3 => MathFuncs.GetSumOf(Number1, Number2);
}
