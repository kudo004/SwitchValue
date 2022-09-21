using UnityEngine;
using UnityEngine.UI;

/// <summary>
///　Imageに対し2つのSpriteを切り替える
/// </summary>
public class SwitchSprite : SwitchValue<Sprite>
{
    [SerializeField] private Image _target;

    protected override void OnChangeValue(Sprite value)
    {
        _target.sprite = value;
    }
}

