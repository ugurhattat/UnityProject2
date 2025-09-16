using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;

        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");

            Debug.Log(Mathf.Abs(horizontal));
            _animator.SetFloat("moveSpeed", Mathf.Abs(horizontal));
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        }
    }
}


