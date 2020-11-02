using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : SingletonMonobehaviour<SceneControlManager>
{

    protected override void Awake()
    {
        base.Awake();

       
        if(SceneManager.GetActiveScene().name == SceneName.Scene3_Cabin.ToString())
        {
            var vCam = FindObjectOfType<CinemachineVirtualCamera>();
            vCam.enabled = false;
            var bshape = FindObjectOfType<SwitchConfineBoundingShape>();
            bshape.enabled = false;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoad;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnLoad;
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        
        if(scene.name == SceneName.Scene3_Cabin.ToString())
        {
            var vCam = FindObjectOfType<CinemachineVirtualCamera>();
            vCam.enabled = false;
            var bshape = FindObjectOfType<SwitchConfineBoundingShape>();
            bshape.enabled = false;

        }

        EventHandler.CallAfterSceneLoadEvent();
    }


    void OnSceneUnLoad(Scene current)
    {
        Debug.Log("On Un Load " + current.name);
        if (current.name == SceneName.Scene3_Cabin.ToString())
        {
            var vCam = FindObjectOfType<CinemachineVirtualCamera>();
            vCam.enabled = true;
            var bshape = FindObjectOfType<SwitchConfineBoundingShape>();
            bshape.enabled = true;

            EventHandler.CallAfterSceneLoadEvent();
        }


    }
   
}
