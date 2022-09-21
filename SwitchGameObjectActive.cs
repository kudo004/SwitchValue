using UnityEngine;

/// <summary>
///　GameObjectのアクティブ状態を切り替える
/// </summary>
public class SwitchGameObjectActive : SwitchValue<bool>
{
    [SerializeField] private GameObject _target;

    protected override void OnChangeValue(bool value)
    {
        _target.SetActive(value);
    }
}

