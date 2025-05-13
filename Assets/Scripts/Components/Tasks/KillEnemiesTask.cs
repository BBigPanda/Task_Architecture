using System;
using Abstracts;
using Enums;
using Interfaces;
using Models;
using UnityEngine;

namespace Components.Tasks
{
    public class KillEnemiesTask : BaseTask, ITask
    {
        public static Action<EnemyType> OnKillEnemies;

        private EnemyType _enemyType;
        private int _targetKills;
        private int _currentKills;
        private bool _isRunning;

        public KillEnemiesTask(TaskModel details, BaseTaskView taskView, int targetKills,
            EnemyType type = EnemyType.None) : base(details, taskView)
        {
            _targetKills = targetKills;
            _enemyType = type;
        }

        public void StartTask()
        {
            if (_isRunning)
                return;
            _isRunning = true;
            Details.Status.Value = TaskStatus.InProgress;
            _currentKills = 0;
            OnKillEnemies += OnKillEnemy;
            UpdateText();
        }

        private void UpdateText()
        {
            if (_isRunning && Details.Status.Value == TaskStatus.InProgress)
                TaskView.Text.text = $"({_targetKills}/{_currentKills}) {Details.Description}";
        }

        private void OnKillEnemy(EnemyType type)
        {
            if (_enemyType == EnemyType.None)
            {
                _currentKills++;
            }
            else if (type == _enemyType)
            {
                _currentKills++;
            }

            UpdateText();
            if (_currentKills >= _targetKills)
            {
                CompleteTask();
            }
        }

        public void CompleteTask()
        {
            _isRunning = false;
            Details.Status.Value = TaskStatus.Completed;
            OnCompleteCallBack?.Invoke(this);
        }

        public void OnComplete(Action<ITask> onComplete)
        {
            OnCompleteCallBack = onComplete;
        }

        public void UpdateTask()
        {
        }

        public void CancelTask()
        {
            Details.Status.Value = TaskStatus.Cancelled;
        }
    }
}