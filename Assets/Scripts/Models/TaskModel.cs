using System;
using Abstracts;
using Components.Tasks;
using Enums;
using UniRx;

namespace Models
{
    [Serializable]
    public class TaskModel
    {
        public int Id;
        public string Name;
        public string Description;
        public ReactiveProperty<TaskStatus> Status;
    }
}