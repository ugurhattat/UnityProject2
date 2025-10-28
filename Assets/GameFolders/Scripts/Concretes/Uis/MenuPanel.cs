using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

