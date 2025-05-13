using System;
using Enums;

namespace Interfaces
{
    public interface ITask
    {
        public void OnComplete(Action<ITask> onComplete);
        public void StartTask();
        public void UpdateTask();
        public void CompleteTask();
    }
}