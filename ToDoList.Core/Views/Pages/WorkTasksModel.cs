using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ToDoList.Core
{
    public class WorkTasksModel : BaseView
    {
        public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

        public string NewTaskTitle { get; set; }

        public string NewTaskDescription { get; set; }

        public System.Windows.Input.ICommand AddTaskComand { get; set; }
        public System.Windows.Input.ICommand DeleteTaskComand { get; set; }

        public WorkTasksModel()
        {
            AddTaskComand = new RelayCommand(AddNewTask);
            DeleteTaskComand = new RelayCommand(DeleteSelectedTasks);

           foreach (var task in  DatabaseLocator.Database.WorkTasks.ToList())
            {
                WorkTaskList.Add(new WorkTaskViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    CreatedAt = task.CreatedAt
                });
            }
        }

        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
                {
                    Title = NewTaskTitle,
                    Description = NewTaskDescription,
                    CreatedAt = DateTime.Now
                };

            WorkTaskList.Add(newTask);

            DatabaseLocator.Database.WorkTasks.Add(new Database.WorkTask
            {
                Title = newTask.Title,
                Description = newTask.Description,
                CreatedAt = newTask.CreatedAt
            });

            DatabaseLocator.Database.SaveChanges();
        }

        private void DeleteSelectedTasks()
        {
            var selectedTasks = WorkTaskList.Where(x => x.IsSelected).ToList();


            foreach (var task in selectedTasks)
            {
                WorkTaskList.Remove(task);
                var foundEntity = DatabaseLocator.Database.WorkTasks.FirstOrDefault(x => x.Id == task.Id);

                if(foundEntity != null)
                {
                    DatabaseLocator.Database.WorkTasks.Remove(foundEntity);
                }

            }
            DatabaseLocator.Database.SaveChanges();
        }
    }
}
