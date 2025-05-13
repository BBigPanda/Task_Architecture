using System.Collections.Generic;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TasksDetails", menuName = "ScriptableObjects/TasksDetails", order = 0)]
    public class TasksDetails : ScriptableObject
    {
        [SerializeField] private List<TaskModel> _tasks;
        public List<TaskModel> Tasks => _tasks;
    }
}