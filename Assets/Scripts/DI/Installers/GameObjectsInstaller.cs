using Components.Views;
using DI.Controllers;
using ScriptableObjects;
using UnityEngine;
using Zenject;

public class GameObjectsInstaller : MonoInstaller
{
    [SerializeField] private EnemiesConfigs _enemiesConfigs;
    [SerializeField] private EnemiesControllerView _view;
    public override void InstallBindings()
    {
        Container.Bind<EnemiesController>().AsSingle().WithArguments(_view, _enemiesConfigs).NonLazy();
    }
    
}