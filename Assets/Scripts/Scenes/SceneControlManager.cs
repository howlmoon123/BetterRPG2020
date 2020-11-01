using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : SingletonMonobehaviour<SceneControlManager>
{

    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene name , LoadSceneMode mode)
    {

        EventHandler.CallAfterSceneLoadEvent();
    }

   
}
