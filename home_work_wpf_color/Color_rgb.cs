using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace home_work_wpf_color
{
    public class Color_rgb : INotifyPropertyChanged
    {

        private Color currentColor = new Color();
        private byte a = 0;
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

    }
}
