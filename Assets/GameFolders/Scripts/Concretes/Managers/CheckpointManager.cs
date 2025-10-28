using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityProject2.Combats;
using UnityProject2.Controllers;

namespace UnityProject2.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        CheckpointController[] _checkpointControllers;
        Health _health;

        private void Awake()
        {
            _checkpointControllers = GetComponentsInChildren<CheckpointController>();
            _health = FindFirstObjectByType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth)
        {
            _health.transform.position = _checkpointControllers.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}

