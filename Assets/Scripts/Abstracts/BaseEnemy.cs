using Enums;
using Interfaces;
using UnityEngine;

namespace Abstracts
{
    public abstract class BaseEnemy: MonoBehaviour
    {
        [SerializeField] private EnemyType _type;

        public EnemyType Type => _type;
    }
}