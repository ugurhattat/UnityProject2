using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Managers;

namespace UnityProject2.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClick()
        {
            GameManager.Instance.LoadMenuAndUi(2f);
        }
    }
}

