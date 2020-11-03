using Cinemachine;
using UnityEngine;


public class SwitchConfineBoundingShape : MonoBehaviour
{
    public Transform player;
   
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

     
            PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
           
            CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
           //Debug.Log("Confiner " + sceneName);
            cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

            var vCam = GetComponent<CinemachineVirtualCamera>();
            vCam.LookAt = player;
            vCam.Follow = player;
            // since the confiner bounds have changed need to call this to clear the cache;

     
    }
}
