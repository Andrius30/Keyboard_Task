using Andrius.Utils.Timers;
using System.Collections;
using UnityEngine;

public class MoveLeft
{
    public Timer holdTimer;
    VirtualKeyboard keyboard;
    WaitForSeconds wait;
    bool isRoutineRunning = false;

    public MoveLeft(VirtualKeyboard keyboard)
    {
        this.keyboard = keyboard;
        holdTimer = new Timer(0, OnHoldMoveLeftTimeOut, false, true);
        wait = new WaitForSeconds(keyboard.updateRatio);
    }

    public void OnMoveLeft()
    {
        keyboard.InputField.OnValueChanged();
        keyboard.InputField.DecreaseCaretPosition();
        keyboard.InputField.OnValueChanged();
    }
    public void OnUpdate()
    {
        if (holdTimer.IsDone()) return;
        holdTimer.StartTimer();
    }

    void OnHoldMoveLeftTimeOut()
    {
        if (keyboard.isHolding)
        {
            keyboard.StartCoroutine(HoldMoveLeftRoultine());
        }
    }
    IEnumerator HoldMoveLeftRoultine()
    {
        if (isRoutineRunning) yield break;
        isRoutineRunning = true;
        while (keyboard.isHolding)
        {
            OnMoveLeft();
            yield return wait;
        }
        isRoutineRunning = false;
        yield break;
    }

}
