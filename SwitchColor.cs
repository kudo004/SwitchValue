using UnityEngine;
using UnityEngine.UI;

namespace KDLib
{
    /// <summary>
    /// 2つの色を切り替える
    /// </summary>
    public class SwitchColor : SwitchValue<Color>
    {
        [SerializeField] private Graphic _target;
        
        protected override void OnChangeValue(bool value)
        {
            _target.color = value;
        }
    }
}
