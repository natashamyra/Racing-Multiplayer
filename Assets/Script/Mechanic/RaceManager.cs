using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;

    public enum RaceState
    {
        Start,
        End
    }

    public RaceState raceState;

    #region Game_Variable



    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        CheckRaceState();
    }

    void CheckRaceState()
    {
        switch (raceState)
        {
            case RaceState.Start:

                StartStopwatch();
                DisplayCheckpoint();

                break;

            case RaceState.End:

                DisplayResults();

                break;            
        }
    }

    public void ChangeRaceState(RaceState state)
    {
        raceState = state;
        CheckRaceState();
    }

    #region Start

    //For starting stopwatch of the race
    public void StartStopwatch()
    {

    }
    
    //For adding laps if player pass all checkpoints
    public void AddLaps()
    {

    }

    //For displaying all checkpoints available around the track
    public void DisplayCheckpoint()
    {

    }

    //For hiding checkpoint that player have passed
    public void HideCheckpoint()
    {

    }

    #endregion

    #region End

    //Display panel for congratulating player after finished the race
    public void DisplayResults()
    {

    }

    #endregion

}
