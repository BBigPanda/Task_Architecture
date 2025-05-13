using Enums;
using UnityEngine;

namespace Interfaces
{
    public interface IEnemy
    {
        public void Move();
        public void OnDeath();
    }
}