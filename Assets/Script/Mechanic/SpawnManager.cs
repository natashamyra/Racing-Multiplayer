using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [HideInInspector]
    public Transform emptyPos;

    //nak check position
    public List<bool> positionBool; //set the array
    public List<Transform> positionTransform;
    public int nextPosition;

    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }

        GetEmptyPosition();
    }

    public void GetEmptyPosition()
    {

        for (int i = 0; i < positionBool.Count; i++)
        {
            if (!positionBool[i])
            {
                nextPosition = i + 1;
                positionBool[i] = true;
                emptyPos = positionTransform[i];
                
            }
        }
        
    }
    

}
