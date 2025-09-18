using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 350f;

        Rigidbody2D _rigidbody2D;

        public bool IsJumpAction => _rigidbody2D.velocity != Vector2.zero; // x ve y degerleri 0'dan buyukse true don yani is jump'tir.

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void JumpAction()
        {
            _rigidbody2D.velocity = Vector2.zero; // once hizi 0'la sonra zipla gibi.
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}