using Components.Views;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace DI.Controllers
{
    public class EnemiesController
    {
        private EnemiesControllerView _view;
        private EnemiesConfigs _enemiesConfigs;

        public EnemiesController(EnemiesControllerView view, EnemiesConfigs configs)
        {
            _view = view;
            _enemiesConfigs = configs;
            GameReady();
        }

        public async void GameReady()
        {
            await UniTask.DelayFrame(1);
            _view.Init();
            InstantiateEnemies();
        }

        private void InstantiateEnemies()
        {
            DOTween.SetTweensCapacity(
                tweenersCapacity: 280,
                sequencesCapacity: 200);
            foreach (var type in _enemiesConfigs.EnemiesTypes)
            {
                _view.InstantiateEnemies(type, _enemiesConfigs.EnemiesCount);
            }
        }
    }
}