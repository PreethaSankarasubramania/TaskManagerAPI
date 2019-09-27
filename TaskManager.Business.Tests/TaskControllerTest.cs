using NUnit.Framework;
using TaskManager.Business;
using TaskManager.Entities;
using TaskManager.Repositories;
using TaskManager.Services.Controllers;

namespace TaskManager.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        TasksController taskController;
        ITaskBusiness _taskBusiness;
        TaskViewModel model;
        IRepository<Task> repo;
        IParentTaskBusiness ptask;
        IRepository<ParentTask> prepo;
        IProjectBusiness procectBusiness;
        IRepository<Project> projectrepo;
        IRepository<User> userRepo;

        [SetUp]
        public void Setup()
        {
            repo = new Repository<Task>();
            projectrepo = new Repository<Project>();
            userRepo = new Repository<User>();
            prepo = new Repository<ParentTask>();
            ptask = new ParentTaskBusiness(prepo);
            procectBusiness = new ProjectBusiness(projectrepo, userRepo, repo);
            _taskBusiness = new TaskBusiness(repo, ptask,procectBusiness,userRepo);
        }

        [Test]
        public void GetAllTaskTest()
        {

            taskController = new TasksController(_taskBusiness);
            //Number of records
            var taskModels = taskController.GetAll();
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }

        [TestCase]
        public void EndTaskTest()
        {
            taskController = new TasksController(_taskBusiness);
            model = new TaskViewModel()
            {
                TaskId = 2,
                TaskName = "Task2",
                StartDate = System.DateTime.Now,
                Priority = 20
            };
            //Number of records
            var taskModels = taskController.Complete(model);
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }

        [TestCase]
        public void GetTaskByIDTest()
        {
            taskController = new TasksController(_taskBusiness);
            //Number of records
            var taskModels = taskController.GetById(1);
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }

        [TestCase]
        public void AddTaskTest()
        {
            taskController = new TasksController(_taskBusiness);
            model = new TaskViewModel()
            {
                TaskName = "Task234",
                StartDate = System.DateTime.Now,
                Priority = 20,
                ParentTaskId = 1
            };
            //Number of records
            var taskModels = taskController.Save(model);
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }
        [TestCase]
        public void AddParentTaskTest()
        {
            taskController = new TasksController(_taskBusiness);
            model = new TaskViewModel()
            {
                TaskName = "Task234"
            };
            //Number of records
            var taskModels = taskController.Save(model);
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }
        [TestCase]
        public void UpdateTask()
        {
            taskController = new TasksController(_taskBusiness);
            model = new TaskViewModel()
            {
                TaskId = 1,
                TaskName = "Task234",
                StartDate = System.DateTime.Now,
                Priority = 20,
                ParentTaskId = 1
            };
            //Number of records
            var taskModels = taskController.Save(model);
            if (taskModels != null)
                Assert.True(taskModels != null);
            else
                Assert.Fail();
        }
    }
}
