using DemoJira.Bussiness.DTO;
using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess.Entities;
using DemoJira.DataAccess.InterfaceForRepo;
using DemoJira.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;
        //private readonly HttpClient _httpClient;


        public TaskService(ITaskRepository repos)

        {
            // _httpClient = httpClient;
            repository = repos;
        }

        public async Task<MyTask> CreateTask(TaskDTO taskDTO)
        {
            if (taskDTO.AssigneeId == taskDTO.ReporterId)
            {
                throw new InvalidOperationException("Assignee and Reporter cannot be the same.");
            }

            MyTask task = new MyTask
            {
                TaskId=taskDTO.Id,
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                TaskStatus = taskDTO.TaskStatus,
                BugStatus = taskDTO.BugStatus,
                StoryPoint = taskDTO.StoryPoint,
                Priority = taskDTO.Priority,
                ProjectId = taskDTO.ProjectId,
                IterationId = taskDTO.IterationId,
                //  AttachmentUrl ="",  
                ExpEndDate = taskDTO.EndDate,
                ExpStartDate = taskDTO.StartDate,
                CreatedAt=DateTime.Now,
                ActEndDate = DateTime.Now.AddDays(1),
                ActStartDate = DateTime.Now,
                Type = taskDTO.Type,
                MyUserId = taskDTO.AssigneeId,
                ReporterId=taskDTO.ReporterId
               /* ParentTasks = taskDTO.ParentTasks.Select(MapToEntity).ToList(),
                ChildTasks = taskDTO.ChildTasks.Select(MapToEntity).ToList()
              */  // RelatedTasks = taskDTO.RelatedTasks




            };
            var response = await repository.CreateTask(task);
            return response;

            // throw new NotImplementedException();
        }

        public async Task DeleteTask(string Id)
        {

            var task = await repository.GetTaskById(Id);
            await repository.DeleteTask(task);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {

            var Tasks = await repository.GetAllTasks();
            var response = Tasks.Select(t => new TaskDTO
            {
                Id = t.TaskId,
                Title = t.Title,
               // HexaId = t.HexId,
                TaskStatus = t.TaskStatus,
                BugStatus = t.BugStatus,
                Description = t.Description,
                StoryPoint = t.StoryPoint,
                Priority = t.Priority,
                CreatedAt=t.CreatedAt,
                //AttachmentUrl=t.AttachmentUrl,
                StartDate = t.ExpStartDate,
                AssigneeId = t.MyUserId,
                ReporterId=t.ReporterId,
                ActStartDate = t.ActStartDate,
                ActEndDate = t.ActEndDate,
                Type = t.Type,
                // AssignedToUserId = t.AssignedToUserId,
                EndDate = t.ExpEndDate,
                ProjectId = t.ProjectId,
                IterationId = t.IterationId
            });
            return response;
            /*     var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDTO>>("api/tasks");
                 return response;*/


            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {

            var projects = await repository.GetAllProjs();
            var resp = projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                /* Iterations = p.Iterations.Select(c => new IterationDTO
                 {
                     Id = c.Id,
                     Name = c.Name,

                 }).ToList()
 */
            });
            return resp;

        }

        public async Task<ProjectDTO> GetProjectById(int Id)
        {
            var Proj = await repository.GetProjectById(Id);
            return new ProjectDTO
            {
                Id = Proj.Id,
                Name = Proj.Name,

                //  IterationId=Proj.IterationId,
                /* Iterations = Proj.Iterations.Select(c => new IterationDTO { Id = c.Id,
                     Name = c.Name,
                     //projID=Proj.Id

                 }).ToList()*/

            };

            //  throw new NotImplementedException();
        }

        public async Task<TaskDTO> GetTaskById(string Id)
        {
            var Task = await repository.GetTaskById(Id);
            if (Task == null) return null;
            return new TaskDTO
            {

                Id = Task.TaskId,
                Title = Task.Title,
                //HexaId = Task.HexId,
                StoryPoint = Task.StoryPoint,
                TaskStatus = Task.TaskStatus,
                BugStatus = Task.BugStatus,
                Description = Task.Description,
                Priority = Task.Priority,
                CreatedAt= Task.CreatedAt,
                // AttachmentUrl=Task.AttachmentUrl,
                StartDate = Task.ExpStartDate,
                EndDate = Task.ExpEndDate,
                ProjectId = Task.ProjectId,
                AssigneeId   = Task.MyUserId,
                ReporterId=Task.ReporterId,
                Type = Task.Type,
                ActStartDate = Task.ActStartDate,
                ActEndDate = Task.ActEndDate,
                //  AssignedToUserId=Task.AssignedToUserId,
                IterationId = Task.IterationId,
                /* Comments = Task.Comments.Select(c => new CommentDTO
                 {
                     CommentId = c.CommentId,
                     Content = c.Content,
                     CreatedAt = c.CreatedAt,
                     UserName = c.User.UserName
                 }).ToList(),
 */


            };

            // throw new NotImplementedException();
        }

        public async Task<TaskDTO> UpdateTask(string Id, TaskDTO taskDTO)
        {
            var existingTask = await repository.GetTaskById(Id);
            if (existingTask == null) return null;

            //existingTask.TaskId = taskDTO.Id;
            existingTask.Title = taskDTO.Title;
            existingTask.Description = taskDTO.Description;
            existingTask.ProjectId = taskDTO.ProjectId;
            existingTask.IterationId = taskDTO.IterationId;
            existingTask.TaskStatus = taskDTO.TaskStatus;
            existingTask.StoryPoint = taskDTO.StoryPoint;
            existingTask.BugStatus = taskDTO.BugStatus;

            // existingTask.AttachmentUrl = taskDTO.AttachmentUrl;
            existingTask.Priority = taskDTO.Priority;
            existingTask.ExpStartDate = taskDTO.StartDate;
            existingTask.MyUserId = taskDTO.AssigneeId;
            existingTask.ReporterId=taskDTO.ReporterId;
            existingTask.Type = taskDTO.Type;
            existingTask.ActStartDate = taskDTO.ActStartDate;
            existingTask.ActEndDate = taskDTO.ActEndDate;
            // existingTask.AssignedToUserId = taskDTO.AssignedToUserId;
            existingTask.ExpEndDate = taskDTO.EndDate;

            await repository.UpdateTask(existingTask);
            return taskDTO;




            //   throw new NotImplementedException();
        }

        public async Task<IEnumerable<IterationDTO>> GetAllIterations()
        {
            var iterations = await repository.GetIterationAll();
            var resp = iterations.Select(p => new IterationDTO
            {
                Id = p.IterationId,
                Name = p.Name,
                projID = p.ProjId
            });
            return resp;
        }






        public async Task AddTaskRelationshipAsync(TaskRelationshipDTO relationshipDTO)
        {
            if (relationshipDTO.RelationshipType == TaskRelationshipType.Parent && await repository.IsChildOfAsync(relationshipDTO.ChildTaskId, relationshipDTO.ParentTaskId))
            {
                throw new InvalidOperationException("A child task cannot be a parent of its own parent.");
            }


            var relationship = new TaskRelationship
            {
                Id = relationshipDTO.Id,
                MainTaskId = relationshipDTO.ParentTaskId,
                RelatedTaskId = relationshipDTO.ChildTaskId,
                RelationshipType = relationshipDTO.RelationshipType
            };


            await repository.AddTaskRelationshipAsync(relationship);

        }

        public async Task RemoveTaskRelationshipAsync(string parentTaskId, string childTaskId)
        {
            await repository.RemoveTaskRelationshipAsync(parentTaskId, childTaskId);
        }

        public async Task<List<TaskRelationshipDTO>> GetTaskRelationshipsAsync(string taskId)
        {
            var relationships = await repository.GetTaskRelationshipsAsync(taskId);
            return relationships.Select(r => new TaskRelationshipDTO
            {
                Id = r.Id,
                ParentTaskId = r.MainTaskId,
                ChildTaskId = r.RelatedTaskId,
                RelationshipType = r.RelationshipType
            }).ToList();
        }

       /* public async Task addRelation(TaskDTO t1, TaskDTO t2)
        {
            var task1 = await repository.GetTaskById(t1.Id);
            //  if (task1 == null) { return null; }
            var task2 = await repository.GetTaskById(t2.Id);
            task1.RelatedTasks.Add(task2);
            await repository.UpdateTask(task1);
            // throw new NotImplementedException();
        }*/



    }
}
