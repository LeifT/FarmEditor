﻿using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace FarmEditor.Utils
{
    public class MouseButtonEventArgsToPointConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var args = (MouseEventArgs)value;
            var element = (FrameworkElement)parameter;

            var point = args.GetPosition(element);
            return point;
        }
    }
}
