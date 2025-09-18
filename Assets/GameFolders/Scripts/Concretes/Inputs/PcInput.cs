using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Inputs;

namespace UnityProject2.Inputs
{
    public class PcInput:IPlayerInput
    {// lambda yazimi, sadece bu iki inputumu tutacagi icin monobehaviourdan miras almasina gerek yok.
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}

