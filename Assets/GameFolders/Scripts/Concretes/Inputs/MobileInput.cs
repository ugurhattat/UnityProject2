using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject2.Abstracts.Inputs;

namespace UnityProject2.Inputs
{
    public class MobileInput:IPlayerInput
    {// simdilik mobile inputlari buymus gibi davraniyoruz.duzelticez IPlayerInput scriptini olusturuyoruz abstract olarak miras vermesi icin.interface olacak yani farkli makineler arasinda gecis yapabilmesi icin.
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}

