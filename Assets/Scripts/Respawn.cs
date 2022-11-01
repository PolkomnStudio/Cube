using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Respawn : MonoBehaviour
{
    //public CubeMovement cubeMovement;
    public CubeMovement clone;

    [SerializeField] private TMP_InputField inputRespawnTime;
    [SerializeField] private TMP_InputField inputCubeSpeed;
    [SerializeField] private TMP_InputField inputLifeDistance;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CubeMovement cube;
    
    private float respawnTime = 0f;
    private float cubeSpeed = 0f;
    private float lifeDistance = 0f;

    

    private float TimeRespawn(float respawnTime)
    {
        InvokeRepeating("CubeRespawn", respawnTime, respawnTime);
        return respawnTime;
    }

    private void CubeRespawn()
    {

        clone = Instantiate(cube, spawnPoint.position, Quaternion.identity);
        clone.Speed = cubeSpeed;
        clone.Distance = lifeDistance;

    }

    public void SaveRespawnTime()
    {
        respawnTime = float.Parse(inputRespawnTime.text);
        CancelInvoke();
        TimeRespawn(respawnTime);
        
    }

    public void SaveCubeSpeed()
    {
        cubeSpeed = float.Parse(inputCubeSpeed.text);
        
    }

    public void SaveLifeDistance()
    {
        lifeDistance = float.Parse(inputLifeDistance.text);
        
    }
}
