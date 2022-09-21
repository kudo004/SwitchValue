using UnityEditor;
using UnityEngine;

/// <summary>
/// ２つの状態を切り替える
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SwitchValue<T> : MonoBehaviour, ISwitchValue
{
    private bool _isTrue = false;

    [SerializeField] private T _trueValue;
    [SerializeField] private T _falseValue;
    
    /// <summary>
    /// 現在と反対の状態に切り替える
    /// </summary>
    public void Switch()
    {
        _isTrue = !_isTrue;
        OnChangeValue(CurrentValue());
    }

    /// <summary>
    /// 指定の状態に切り替え
    /// </summary>
    /// <param name="isTrue">trueの値にするか</param>
    public void Switch(bool isTrue)
    {
        _isTrue = isTrue;
        OnChangeValue(CurrentValue());
    }

    /// <summary>
    /// 現在の値
    /// </summary>
    /// <returns></returns>
    public T CurrentValue()
    {
        return _isTrue ? _trueValue : _falseValue;
    }

    /// <summary>
    /// 値が切り替わった際に呼ばれる
    /// </summary>
    /// <param name="value">切り替わり後の値</param>
    protected abstract void OnChangeValue(T value);
}

/// <summary>
/// 値切り替えようのインターフェース
/// </summary>
public interface ISwitchValue
{
    public void Switch();
    public void Switch(bool isTrue);
}

#if UNITY_EDITOR
    #region デバッグ
    [CustomEditor(typeof(SwitchValue<>), editorForChildClasses: true)]
    public class TestDebugSwitchValue : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var t = target as ISwitchValue;

            GUILayout.Space(20);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space();
                if (GUILayout.Button("Switch",
                        GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30)))
                {
                    t.Switch();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(20);
        }
    }
    #endregion
#endif

