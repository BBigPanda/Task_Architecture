using System;
using Abstracts;
using Components.Tasks;
using DG.Tweening;
using Interfaces;
using UnityEngine;

public class EnemyView : BaseEnemy, IEnemy
{
    [SerializeField] private float _moveRadius = 5f;
    [SerializeField] private float _moveDuration = 2f;
    [SerializeField] private float _rotateDuration = 2f;
    [SerializeField] private bool _loopMovement = true;

    private Sequence tweenSequence;

    public void Start()
    {
        Move();
    }

    public void Move()
    {
        tweenSequence = DOTween.Sequence();
        Vector3 randomOffset = new Vector3(
            UnityEngine.Random.Range(-_moveRadius, _moveRadius),
            0f,
            UnityEngine.Random.Range(-_moveRadius, _moveRadius)
        );

        Vector3 targetPosition = transform.position + randomOffset;
        tweenSequence.Append(transform.DOLookAt(targetPosition, _rotateDuration).SetEase(Ease.OutBack));
        tweenSequence.Append(transform.DOMove(targetPosition, _moveDuration)
            .SetEase(Ease.Linear));
        tweenSequence.Play();
        tweenSequence.OnComplete(() =>
        {
            if (_loopMovement) Move();
        });
    }

    public void OnDeath()
    {
        KillEnemiesTask.OnKillEnemies?.Invoke(Type);
        tweenSequence.Kill();
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnDeath();
        }
    }
}