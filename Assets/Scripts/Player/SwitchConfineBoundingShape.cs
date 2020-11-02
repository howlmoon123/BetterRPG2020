using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    string sceneName;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += SwitchBoundingShape;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= SwitchBoundingShape;
    }

    private void Update()
    {
        
    }
    /// <summary>
    /// Switch the collider that cinemachine uses to define the edges of the screen
    /// </summary>
    private void SwitchBoundingShape()
    {
         sceneName = SceneManager.GetSceneByName(SceneName.Scene3_Cabin.ToString()).name;
        if (sceneName != SceneName.Scene3_Cabin.ToString())
        {
            //  Get the polygon collider on the 'boundsconfiner' gameobject which is used by Cinemachine to prevent the camera going beyond the screen edges
            PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
           // Debug.LogError(polygonCollider2D);
            CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

            cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

            var vCam = GetComponent<CinemachineVirtualCamera>();
            vCam.LookAt = player;
            vCam.Follow = player;
            // since the confiner bounds have changed need to call this to clear the cache;

            cinemachineConfiner.InvalidatePathCache();

        }
    }
}
