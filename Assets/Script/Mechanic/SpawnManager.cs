using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public Transform emptyPos;

    //nak check position
    public List<bool> positionBool; //set the array
    public List<Transform> positionTransform;
    public int nextPosition;

    private void Start()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }        
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
