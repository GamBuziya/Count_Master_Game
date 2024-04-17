using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void StartPause()
    {
        Time.timeScale = 0f;
    }

    public void EndPause()
    {
        Time.timeScale = 1f;
    }
    
}
