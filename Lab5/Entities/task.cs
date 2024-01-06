using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Models
{
    public class Task : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private DateTime deadline;
        private string tags;

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime Deadline
        {
            get { return deadline; }
            set
            {
                if (deadline != value)
                {
                    deadline = value;
                    OnPropertyChanged(nameof(Deadline));
                }
            }
        }

        public string Tags
        {
            get { return tags; }
            set
            {
                if (tags != value)
                {
                    tags = value;
                    OnPropertyChanged(nameof(Tags));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Print()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Deadline: {Deadline.ToShortDateString()}");
            Console.Write($"Tags : {string.Join(", ", Tags)}");
            Console.Write("\n\n");

        }
    }
}
