using System;
using LiteDB;
using MauiLiteDBDemo.Models;

namespace MauiLiteDBDemo.Services
{
	public class LiteDbService
	{
		private readonly LiteDatabase _database;
		private readonly ILiteCollection<TaskItemModel> _task;

		public LiteDbService()
		{
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "task.db");
			_database = new LiteDatabase(dbPath);
			_task = _database.GetCollection<TaskItemModel>("task");
			_task.EnsureIndex(x => x.Id, true);
		}

		public List<TaskItemModel> GetTasks() => _task.FindAll().ToList();

		public void AddTask(TaskItemModel task) => _task.Insert(task);

		public void UpdateTask(TaskItemModel task) => _task.Update(task);

		public void DeleteTask(int id) => _task.Delete(id);
	}
}

