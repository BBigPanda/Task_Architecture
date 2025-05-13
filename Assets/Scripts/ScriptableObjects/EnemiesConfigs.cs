using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemiesConfigs", menuName = "ScriptableObjects/EnemiesConfigs", order = 0)]
    public class EnemiesConfigs : ScriptableObject
    {
        [SerializeField] private int _enemiesCount;
        [SerializeField] private List<EnemyType> _enemiesTypes;
        
        public int EnemiesCount => _enemiesCount;
        public List<EnemyType> EnemiesTypes => _enemiesTypes;
    }
}