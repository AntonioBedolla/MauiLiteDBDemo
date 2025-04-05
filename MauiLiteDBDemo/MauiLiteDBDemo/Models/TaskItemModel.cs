using System;
namespace MauiLiteDBDemo.Models
{
	public class TaskItemModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsCompleted { get; set; }
	}
}

