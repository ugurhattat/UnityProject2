using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Uis
{
    public class LoadingCanvas : MonoBehaviour
    {
        void Start()
        {
            GameManager.Instance.LoadMenuAndUi(5f);
        }
    }
}

