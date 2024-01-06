using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Lab5.Models;
using Lab5;
using Lab5.Serializers;
using Lab5.ViewModels;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        public static ListBox taskBox;

        private static JsonObjectSerializer<Task> jsonSerializer = new JsonObjectSerializer<Task>();

        public TaskViewModel YourTaskViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            YourTaskViewModel = new TaskViewModel();
            DataContext = this;

            tasksPerPageComboBox = this.FindControl<ComboBox>("tasksPerPageComboBox");
            tagsSearchTextBox = this.FindControl<TextBox>("tagsSearchTextBox");
            taskListBox = this.FindControl<ListBox>("taskListBox"); // Инициализация taskBox
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            taskBox = this.FindControl<ListBox>("taskListBox");

            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
            foreach (Task task in tasks)
            {
                taskBox.Items.Add(task);
            }


        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                var editTaskWindow = new EditTaskWindow(selectedTask);
                editTaskWindow.ShowDialog(this);

                List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
                UpdateTaskListBox(tasks);
            }
        }

        private void AddTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog(this);

            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
            UpdateTaskListBox(tasks);
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");

                tasks.RemoveAll(x => x.Title == selectedTask.Title || x.Deadline == selectedTask.Deadline);

                selectedTask.Print();

                jsonSerializer.WriteDataToFile(tasks, "tasks.json");

                UpdateTaskListBox(tasks);
            }

        }

        internal static void UpdateTaskListBox(List<Task> tasks)
        {
            taskBox.Items.Clear();
            foreach (Task task in tasks)
            {
                taskBox.Items.Add(task);
            }
            taskBox.InvalidateVisual();
        }
        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                ShowTaskDetails(selectedTask);
            }

        }
        private void ShowTaskDetails(Task task)
        {
            var detailsWindow = new TaskDetailsWindow(task);
            detailsWindow.ShowDialog(this);
        }
        private void ApplyChanges_Click(object sender, RoutedEventArgs e)
        {

            int selectedTasksPerPage = int.Parse(((ComboBoxItem)tasksPerPageComboBox.SelectedItem).Content.ToString());

            string tagsSearchText = tagsSearchTextBox.Text ?? null;

            NTaskListBox(selectedTasksPerPage, tagsSearchText);
        }
        private void NTaskListBox(int tasksPerPage, string tagsSearchText)
        {
            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");

            List<Task> filteredTasks = FilterTasksByTags(tasks, tagsSearchText);
            taskListBox.Items.Clear();
            int count = tasks.Count;
            if (tasks.Count > filteredTasks.Count)
            { count = filteredTasks.Count; }

            for (int i = 0; i < Math.Min(tasksPerPage, count); i++)
            {
                taskListBox.Items.Add(filteredTasks[i]);
            }
        }

        private List<Task> FilterTasksByTags(List<Task> tasks, string tagsSearchText)
        {

            if (!string.IsNullOrWhiteSpace(tagsSearchText))
            {
                return tasks.Where(task => task.Tags.Contains(tagsSearchText)).ToList();
            }
            else
            {
                return tasks;
            }
        }
    }
}
