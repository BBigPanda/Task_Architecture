using System;
using System.Collections.Generic;
using Interfaces;
using UniRx;
using UnityEngine;

namespace DI.Managers
{
    public class TasksManager
    {
        private List<ITask> _tasks = new List<ITask>();
        private IDisposable _disposable;
        public Action CallBackTasksCompleted;

        public TasksManager()
        {
            Debug.Log("TasksManager");
            _tasks = new List<ITask>();
        }

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
        }

        private void TasksCompleted()
        {
            CallBackTasksCompleted?.Invoke();
        }

        public void CompleteTask(ITask task)
        {
            _disposable?.Dispose();
            RemoveTask(task);
            if (_tasks.Count > 0)
            {
                UpdateTasksEveryFrame();
            }
            else
            {
                TasksCompleted();
            }

            Debug.unityLogger.Log("_tasks.Count+" + _tasks.Count);
        }

        public void StartTasks()
        {
            foreach (var task in _tasks)
            {
                task.OnComplete(CompleteTask);
                task.StartTask();
            }

            UpdateTasksEveryFrame();
        }

        private void UpdateTasksEveryFrame()
        {
            _disposable = Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
            {
                for (int i = 0; i < _tasks.Count; i++)
                {
                    _tasks[i].UpdateTask();
                }
            });
        }
    }
}