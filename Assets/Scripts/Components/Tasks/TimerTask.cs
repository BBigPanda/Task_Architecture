using System;
using Abstracts;
using Enums;
using Interfaces;
using Models;
using UnityEngine;

namespace Components.Tasks
{
    public class TimerTask : BaseTask, ITask
    {
        private float _duration;
        private bool _isRunning;
        DateTime startTime = DateTime.Now;
        private TimeSpan _timer;

        public TimerTask(TaskModel details, BaseTaskView taskView, float duration) : base(details, taskView)
        {
            _duration = duration;
        }

        public void OnComplete(Action<ITask> onComplete)
        {
            OnCompleteCallBack = onComplete;
        }

        public void StartTask()
        {
            if (_isRunning)
                return;
            _isRunning = true;
            startTime = DateTime.Now;
            Details.Status.Value = TaskStatus.InProgress;
            UpdateText();
        }

        public void CompleteTask()
        {
            _isRunning = false;
            Details.Status.Value = TaskStatus.Completed;
            OnCompleteCallBack?.Invoke(this);
        }

        public TaskStatus GetStatus()
        {
            return Details.Status.Value;
        }

        public void UpdateTask()
        {
            if (_isRunning && Details.Status.Value == TaskStatus.InProgress)
            {
                _timer = DateTime.Now - startTime;
                UpdateText();
                if (_timer.TotalSeconds >= _duration)
                {
                    CompleteTask();
                }
            }
        }

        private void UpdateText()
        {
            TaskView.Text.text = $"{_timer:mm\\:ss} {Details.Description}";
        }

        public void CancelTask()
        {
            Details.Status.Value = TaskStatus.Cancelled;
        }
    }
}