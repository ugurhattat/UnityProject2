using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Combats;
using UnityProject2.ExtensionMethods;

namespace UnityProject2.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        Damage _damage;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();

            if (health != null)
            {
                health.TakeHit(_damage);
            }
        }
    }
}

