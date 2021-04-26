using UnityEngine;

public static class Pause
{
    public static bool IsPause()
    {
        if (Time.timeScale.Equals(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
