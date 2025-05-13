using DI.Controllers;
using DI.Factories;
using DI.Managers;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace DI.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;
            Container.BindInterfacesAndSelfTo<PrefabFactory>().AsSingle();
            Container.Bind<TasksManager>().AsSingle().NonLazy();;
        }
    }
}