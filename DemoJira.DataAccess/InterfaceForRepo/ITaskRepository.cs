﻿using DemoJira.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.DataAccess.InterfaceForRepo
{
    public interface ITaskRepository
    {
        Task<MyTask> CreateTask(MyTask task);
        Task<IEnumerable< MyTask>> GetAllTasks();
        Task<MyTask> GetTaskById(int id);
        Task<MyTask> UpdateTask(MyTask task);
        Task DeleteTask(MyTask task);
    }
}
