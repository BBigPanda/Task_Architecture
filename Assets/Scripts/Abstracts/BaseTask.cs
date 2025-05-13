using System;
using Interfaces;
using Models;
using UniRx;
using UnityEngine;

namespace Abstracts
{
    public abstract class BaseTask
    {
        
        public TaskModel Details;
        public BaseTaskView TaskView;
        public Action<ITask> OnCompleteCallBack;
        private IDisposable _disposable;
        
        protected BaseTask(TaskModel details, BaseTaskView taskView)
        {
            Details = details;
            TaskView = taskView;
            SubscribeOnState();
        }

        private void SubscribeOnState()
        {
            _disposable = Details.Status.Subscribe(state => { TaskView.SetStatus(state); });
        }

        public void UnSubscribeOnState()
        {
            _disposable?.Dispose();
        }
        
        
    }
}