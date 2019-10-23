using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSounds : MonoBehaviour
{
    public AK.Wwise.Event destroySound;

    private void OnSceneWasChanged(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.buildIndex == 1)
        {
            destroySound.Post(gameObject);
        }
    }
}
