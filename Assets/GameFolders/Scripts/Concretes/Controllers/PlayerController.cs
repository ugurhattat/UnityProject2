using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Inputs;
using UnityProject2.Animations;
using UnityProject2.Combats;
using UnityProject2.Inputs;
using UnityProject2.Movements;

namespace UnityProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        float _horizontal;
        float _vertical;
        bool _isJump;

        IPlayerInput _input;
        Mover _mover;
        Jump _jump;
        CharacterAnimation _characterAnimation;
        Flip _flip;
        OnGround _onGround;
        Climbing _climbing;
        Health _health;
        //SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _input = new PcInput(); // kullanabilmemiz icin normal class larin instance'i(ornegini almak) alinir.ornegini almazsak null kalir ve kullanamayiz. 
            //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void Update()
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);
            _characterAnimation.ClimbingAnimation(_climbing.IsClimbing);
        }

        private void FixedUpdate()  // fizik motoruyla uyumlu calistigi icin hareketleri fixedupdate'de veririrz.
        {
            _climbing.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (damage != null)
            {
                damage.HitTarget(_health);
            }
        }
    }
}