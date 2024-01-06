using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Lab5.Models;
using Lab5.Serializers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace Lab5
{
    public partial class TaskDetailsWindow : Window
    {
        public TaskDetailsWindow(Task task)
        {
            InitializeComponent();
            DataContext = task;
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
