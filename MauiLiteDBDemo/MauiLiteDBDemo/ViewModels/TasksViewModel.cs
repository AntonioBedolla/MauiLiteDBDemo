using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiLiteDBDemo.Models;
using MauiLiteDBDemo.Services;

namespace MauiLiteDBDemo.ViewModels
{
	public class TasksViewModel: BaseViewModel
	{
        #region Service DB
        private readonly LiteDbService _dbService;
        #endregion

        #region Collections
        private ObservableCollection<TaskItemModel> _Tasks = new ObservableCollection<TaskItemModel>();
        #endregion

        #region Commands
        public Command AddTaskCommand => new Command(AddTask);
		public Command ToggleCompleteCommand => new Command<TaskItemModel>(ToggleComplete);
		public Command DeleteTaskCommand => new Command<TaskItemModel>(DeleteTask);
        #endregion

        private string _taskName;

        #region Properties
        public string TaskName
        {
            get => _taskName;
            set => SetProperty(ref _taskName, value);
        }

        public ObservableCollection<TaskItemModel> Tasks
        {
            get { return _Tasks; }
        }
        #endregion


        public TasksViewModel(LiteDbService dbService)
		{
            _dbService = dbService;
            LoadTasks();
        }

        private void LoadTasks()
        {
            Tasks.Clear();
            foreach (var task in _dbService.GetTasks())
            {
                Tasks.Add(task);
            }
        }

        private void AddTask()
        {
            if (string.IsNullOrWhiteSpace(TaskName))
                return;

            var newTask = new TaskItemModel { Name = TaskName };
            _dbService.AddTask(newTask);
            TaskName = string.Empty;
            LoadTasks();
        }

        private void ToggleComplete(TaskItemModel task)
        {
            task.IsCompleted = !task.IsCompleted;
            _dbService.UpdateTask(task);
            LoadTasks();
        }

        private void DeleteTask(TaskItemModel task)
        {
            _dbService.DeleteTask(task.Id);
            LoadTasks();
        }
    }
}

