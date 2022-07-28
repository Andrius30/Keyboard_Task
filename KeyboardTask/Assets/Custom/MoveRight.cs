using Andrius.Utils.Timers;
using System.Collections;
using UnityEngine;

public class MoveRight
{
    public Timer holdTimer;
    VirtualKeyboard keyboard;
    WaitForSeconds wait;
    bool isRoutineRunning = false;

    public MoveRight(VirtualKeyboard keyboard)
    {
        this.keyboard = keyboard;
        holdTimer = new Timer(0, OnHoldMoveLeftTimeOut, false, true);
        wait = new WaitForSeconds(keyboard.updateRatio);
    }

    public void OnMoveRight()
    {
        keyboard.InputField.OnValueChanged();
        keyboard.InputField.IncreaseCaretPosition();
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
            keyboard.StartCoroutine(HoldMoveRightRoultine());
        }
    }
    IEnumerator HoldMoveRightRoultine()
    {
        if (isRoutineRunning) yield break;
        isRoutineRunning = true;
        while (keyboard.isHolding)
        {
            OnMoveRight();
            yield return wait;
        }
        isRoutineRunning = false;
        yield break;
    }
}