using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace home_work_wpf_color
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Color currentColor;
        private byte a = 0;
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;
        private readonly ICollection<Color> colors = new ObservableCollection<Color>();

        private Command addNewColorCommand; 
        public ViewModel()
        {
            addNewColorCommand = new DelegateCommand(AddColorCommand);

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentColor))
                {
                    addNewColorCommand.RaiseCanExecuteChanged();
                }
            };
        }

        public IEnumerable<Color> Colors => colors;
        public Color CurrentColor
        {
            get => currentColor;
            set
            {
                currentColor = value;
                OnPropertyChanged();
            }
        }
        public Color ColorInBorder => Color.FromArgb(A, R, G, B);
        public byte A
        {
            get => a;
            set
            {
                a = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte R
        {
            get => r;
            set
            {
                r = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte G
        {
            get => g;
            set
            {
                g = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }
        public byte B
        {
            get => b;
            set
            {
                b = Convert.ToByte(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorInBorder));
            }
        }

        public ICommand AddNewColorCommand => addNewColorCommand;

        public void AddColorCommand()
        {
            colors.Add(ColorInBorder);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


internal abstract class Command : ICommand
{
    public event EventHandler CanExecuteChanged;

    protected virtual bool CanExecute()
    {
        return true;
    }

    protected abstract void Execute();

    protected virtual void OnCanExecuteChanged(EventArgs e)
    {
        CanExecuteChanged?.Invoke(this, e);
    }

    public void RaiseCanExecuteChanged()
    {
        OnCanExecuteChanged(EventArgs.Empty);
    }

    bool ICommand.CanExecute(object parameter)
    {
        return CanExecute();
    }

    void ICommand.Execute(object parameter)
    {
        Execute();
    }
}


internal sealed class DelegateCommand : Command
{
    private static readonly Func<bool> defaultCanExecuteMethod = () => true;

    private readonly Func<bool> canExecuteMethod;
    private readonly Action executeMethod;

    public DelegateCommand(Action executeMethod) :
        this(executeMethod, defaultCanExecuteMethod)
    {
    }

    public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
        this.canExecuteMethod = canExecuteMethod;
        this.executeMethod = executeMethod;
    }

    protected override bool CanExecute()
    {
        return canExecuteMethod();
    }

    protected override void Execute()
    {
        executeMethod();
    }
}