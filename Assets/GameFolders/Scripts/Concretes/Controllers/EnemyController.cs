using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Animations;
using UnityProject2.Combats;
using UnityProject2.ExtensionMethods;
using UnityProject2.Movements;

namespace UnityProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        Mover _mover;
        CharacterAnimation _characterAnimation;
        Health _health;
        Flip _flip;
        OnReachedEdge _onReachedEdge;

        bool _isOnEdge;
        float _direction;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _health = GetComponent<Health>();
            _flip = GetComponent<Flip>();
            _onReachedEdge = GetComponent<OnReachedEdge>();
            _direction = 1f;
        }

        private void OnEnable()
        {
            _health.OnDead += DeadAction;
        }

        private void FixedUpdate()
        {
            if (_health.IsDead) return;

            _mover.HorizontalMove(_direction);
        }

        private void LateUpdate()
        {
            if (_health.IsDead) return;

            if (_onReachedEdge.ReachedEdge())
            {
                _direction *= -1;
                _flip.FlipCharacter(_direction);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (collision.HasHitPlayer() && collision.WasHitBottomSide())
            {
                damage.HitTarget(_health);
            }
        }

        private void DeadAction()
        {
            Destroy(this.gameObject);
        }
    }
}

