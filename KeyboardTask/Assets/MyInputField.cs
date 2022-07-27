
using UnityEngine;

public class MyInputField : InputFieldOriginal
{

    public void Delete()
    {
        OnSelect();
        OnValueChanged();
        caretPositionInternal = text.Length - 1;
        if (text.Length - 1 >= 0)
        {
            Debug.Log($"[DELETE] Caret position {caretPositionInternal}");
            m_Text = text.Remove(caretPositionInternal, 1);
            OnValueChanged();
        }
    }

    public void OnValueChanged() => SendOnValueChangedAndUpdateLabel();
    public void OnSelect() => OnSelect(null);
}