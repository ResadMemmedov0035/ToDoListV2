using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using ToDoListV2.Commands;
using ToDoListV2.Models;

namespace ToDoListV2.ViewModels
{
    class MainVM : BaseViewModel
    {
        private string taskTitle;
        private string taskDescription;
        private bool taskIsDone;

        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public string TaskTitle { get => taskTitle;
            set
            {
                OnChanged(out taskTitle, value);
                AddTaskCommand.RaiseCanExecuteChanged();
            }
        }
        public string TaskDescription { get => taskDescription;
            set
            {
                OnChanged(out taskDescription, value);
                AddTaskCommand.RaiseCanExecuteChanged();
            }
        }
        public bool TaskIsDone { get => taskIsDone; set => OnChanged(out taskIsDone, value); }


        public Command AddTaskCommand { get; set; }
        public Command<Task> RemoveTaskCommand { get; set; }

        public MainVM()
        {
            InitalizeCommands();
        }

        private void InitalizeCommands()
        {
            AddTaskCommand = new Command(() => AddTask(), () => !IsAnyNullOrWhiteSpace(TaskTitle, TaskDescription));
            RemoveTaskCommand = new Command<Task>(x => Tasks.Remove(x));
        }

        private void AddTask()
        {
            Tasks.Add(new Task
            {
                Title = TaskTitle,
                Description = TaskDescription,
                IsDone = TaskIsDone
            });
            Clear();
        }

        private bool IsAnyNullOrWhiteSpace(params string[] strArr)
        {
            return strArr.Any(x => string.IsNullOrWhiteSpace(x));
        }

        private void Clear()
        {
            TaskTitle = string.Empty;
            TaskDescription = string.Empty;
            TaskIsDone = false;
        }
    }
}
