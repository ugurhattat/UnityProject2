using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; } // interfacelerin acces modifier'lari olmaz yani public gibi private gibi
        float Vertical { get; }
        bool IsJumpButtonDown { get; }
    }
}