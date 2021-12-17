using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPoint : MonoBehaviourPun
{
    public Transform[] CarSpawn = null;
    public GameObject car;

    private void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        PhotonNetwork.Instantiate("DummyCar", CarSpawn[i].position, CarSpawn[i].rotation);
    }
    
}
