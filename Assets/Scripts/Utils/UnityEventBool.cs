using System;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
 
    /// <summary>
    /// Needed to use UnityEvents with boolean parameters
    /// </summary>
    public class UnityEventBool : UnityEvent <bool>  {}
}
