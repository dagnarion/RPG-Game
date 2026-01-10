using UnityEngine;

public class CustomTimeCount
{
    private float duration;
    private float timer;
    public void SetDuration(float _duration) => duration = _duration;
    public void ResetCountdown() => timer = duration;
    public bool IsComplete()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return false;
        return true;
    }
}
