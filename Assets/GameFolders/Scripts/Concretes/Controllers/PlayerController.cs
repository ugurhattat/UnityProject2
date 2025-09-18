using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Inputs;
using UnityProject2.Animations;
using UnityProject2.Inputs;
using UnityProject2.Movements;

namespace UnityProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        float _horizontal;
        bool _isJump;

        IPlayerInput _input;
        Mover _mover;
        Jump _jump;
        CharacterAnimation _characterAnimation;
        Flip _flip;
        OnGround _onGround;
        //SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _input = new PcInput(); // kullanabilmemiz icin normal class larin instance'i(ornegini almak) alinir.ornegini almazsak null kalir ve kullanamayiz. 
            //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround)
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()  // fizik motoruyla uyumlu calistigi icin hareketleri fixedupdate'de veririrz.
        {
            _characterAnimation.MoveAnimation(_horizontal);

            _mover.HorizontalMove(_horizontal);

            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }

            _characterAnimation.JumpAnimation(_jump.IsJumpAction && !_onGround.IsOnGround);
        }
    }
}