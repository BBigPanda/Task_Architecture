using System.Collections.Generic;
using Components.Tasks;
using Cysharp.Threading.Tasks;
using DI.Managers;
using Enums;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace DI.Controllers
{
    public class TasksControllerView : MonoBehaviour
    {
        [SerializeField] private RectTransform _tasksContainer;
        [SerializeField] private TasksDetails _tasksDetails;
        [SerializeField] private BaseTaskView _taskViewPrefab;
        [SerializeField] private RectTransform congratulationsPanel;
        [Inject] private TasksManager _tasksManager;

        private List<BaseTaskView> _taskViews;

        private void Awake()
        {
            _taskViews = new List<BaseTaskView>();
            for (int i = 0; i < _tasksDetails.Tasks.Count; i++)
            {
                _taskViews.Add(Instantiate(_taskViewPrefab, _tasksContainer));
            }

            _tasksManager.CallBackTasksCompleted += OnTasksCompleted;
            _tasksManager.AddTask(new TimerTask(_tasksDetails.Tasks[0], _taskViews[0], 20));
            _tasksManager.AddTask(new KillEnemiesTask(_tasksDetails.Tasks[1], _taskViews[1], 10));
            _tasksManager.AddTask(new KillEnemiesTask(_tasksDetails.Tasks[2], _taskViews[2], 10, EnemyType.Sphere));
        }

        private void OnTasksCompleted()
        {
            congratulationsPanel.gameObject.SetActive(true);
        }

        private void Start()
        {
            _tasksManager.StartTasks();
        }
    }
}