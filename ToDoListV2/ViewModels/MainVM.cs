using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ToDoListV2.Commands;
using ToDoListV2.Models;

namespace ToDoListV2.ViewModels
{
    class MainVM : BaseViewModel
    {
        private string taskTitle;
        private string taskDescription;

        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public string TaskTitle { get => taskTitle; set => OnChanged(out taskTitle, value); }
        public string TaskDescription { get => taskDescription; set => OnChanged(out taskDescription, value); }
        public bool TaskIsDone { get; set; }

        public Command AddTaskCommand { get; set; }
        public Command RemoveTaskCommand { get; set; }

        public MainVM()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AddTaskCommand = new Command(x => { AddTask(); });
            RemoveTaskCommand = new Command(x => { RemoveTask(); });
        }

        private void AddTask()
        {
            Tasks.Add(new Task
            {
                Title = TaskTitle,
                Description = TaskDescription,
                IsDone = TaskIsDone
            });
        }

        private void RemoveTask()
        { 

        }
    }
}
