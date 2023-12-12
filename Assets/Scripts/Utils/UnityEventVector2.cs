using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
 
    /// <summary>
    /// Needed to use UnityEvents with Vector2 parameters
    /// </summary>
    public class UnityEventVector2 : UnityEvent <Vector2>  {}
}
