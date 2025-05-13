using System.Collections.Generic;
using System.Linq;
using DI.Interfaces;
using Enums;
using UnityEngine;
using Zenject;

namespace Components.Views
{
    public class EnemiesControllerView : MonoBehaviour
    {
        [SerializeField] private List<EnemyView> _prefabsEnemy;

        [Inject] private IPrefabFactory _prefabFactory;

        public void Init()
        {
        }

        public void InstantiateEnemies(EnemyType type, int count)
        {
            EnemyView prefab = GetEnemyPrefabByType(type);
            if (prefab == null)
                return;
            for (int i = 0; i < count; i++)
            {
                _prefabFactory.Create(prefab, transform);
            }
        }

        private EnemyView GetEnemyPrefabByType(EnemyType type)
        {
            return _prefabsEnemy.FirstOrDefault(x => x.Type == type);
        }
    }
}