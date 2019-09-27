using NBench;
using System;
using TaskManager.Entities;
using TaskManager.Repositories;
using TaskManager.Services.Controllers;
using TaskManager.Business;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TaskManager.NBenchTest.TaskBusinessTests), "Start")]
namespace TaskManager.NBenchTest
{
    public class TaskBusinessTests
    {
        //TasksController taskController;
        ITaskBusiness _taskBusiness;
        TaskViewModel model;
        IRepository<Task> repo;
        IParentTaskBusiness ptask;
        IRepository<ParentTask> prepo;
        IProjectBusiness procectBusiness;
        IRepository<Project> projectrepo;
        IRepository<User> userRepo;


        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            repo = new Repository<Task>();
            projectrepo = new Repository<Project>();
            userRepo = new Repository<User>();
            prepo = new Repository<ParentTask>();
            ptask = new ParentTaskBusiness(prepo);
            procectBusiness = new ProjectBusiness(projectrepo, userRepo, repo);
            _taskBusiness = new TaskBusiness(repo, ptask, procectBusiness, userRepo);
        }

        [PerfBenchmark(Description = "GetAll task method performance performance benchmark.",
            NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Measurement, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkGetAllTaskTest()
        {
            try
            {  
                var taskModels = _taskBusiness.GetAllTasks();
            }
            catch (Exception ex)
            {

            }
        }

        [PerfBenchmark(Description = "End Task method performance performance benchmark.",
           NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkEndTaskTest()
        {
            try
            {                
                model = new TaskViewModel()
                {
                    TaskId = 2,
                    TaskName = "Task2",
                    StartDate = System.DateTime.Now,
                    Priority = 20
                };
                //Number of records
                _taskBusiness.Complete(model);
            }
            catch (Exception ex)
            {

            }
        }

        [PerfBenchmark(Description = "End Task method performance performance benchmark.",
          NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkGetTaskByIDTest()
        {
            try
            {                
                var taskModels = _taskBusiness.GetById(1);
            }
            catch (Exception ex)
            {

            }
        }

        [PerfBenchmark(Description = "Add Task method performance performance benchmark.",
          NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkAddTaskTest()
        {
            try
            {
               
                model = new TaskViewModel()
                {
                    TaskName = "Task234 by Benhc Mark",
                    StartDate = System.DateTime.Now,
                    Priority = 20,
                    ParentTaskId = 1
                };
                //Number of records
                _taskBusiness.Save(model);
            }
            catch (Exception ex)
            {

            }
        }

        [PerfBenchmark(Description = "End Add Parent method performance performance benchmark.",
          NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkAddParentTaskTest()
        {
            try
            {
                
                model = new TaskViewModel()
                {
                    TaskName = "Task234 by BenchMarch"
                };
                //Number of records
                _taskBusiness.Save(model);
            }
            catch (Exception ex)
            {

            }
        }

        [PerfBenchmark(Description = "Update Task method performance performance benchmark.",
          NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkUpdateTaskTest()
        {
            try
            {
               
                model = new TaskViewModel()
                {
                    TaskId = 1,
                    TaskName = "Task234",
                    StartDate = System.DateTime.Now,
                    Priority = 20,
                    ParentTaskId = 1
                };
                //Number of records
                _taskBusiness.Save(model);
            }
            catch (Exception ex)
            {

            }
        }

        [PerfCleanup]
        public void Cleanup()
        {
        }
    }
}
