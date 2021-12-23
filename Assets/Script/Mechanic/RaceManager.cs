using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    public static RaceManager Instance;

    public enum RaceState
    {
        Onwait,
        Countdown,
        Start,
        End
    }

    public RaceState raceState;

    #region Game_Variable

    [Header("On Lobby State Variable: ")]
    [SerializeField] bool isEnough;
    [SerializeField] GameObject StartButton;

    [Header("Countdown State Variable: ")]
    [SerializeField] List<GameObject> Countdown;

    [Header("Start State Variable: ")]
    [SerializeField] bool isTimer;
    [SerializeField] GameObject TimerUI;
    [SerializeField] TextMesh Timer;
    [SerializeField] float TimerValue = 0;
    RaceManager raceScript;
    [SerializeField] List<GameObject> Checkpoints;

    [Header("End State Variable: ")]
    [SerializeField] GameObject FinishPanel;


    #endregion

    private void Awake()
    {
        //for (int i = 0; i < Checkpoints.Count; i++)
        //{
        //    raceScript = Checkpoint;
        //}

    }

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
        //if player dah penuh start countdown
        if(isEnough == true && raceState == RaceState.Onwait)
        {
            EnoughPlayer();
        }

        //if isTimer true, start timer
        if(isTimer == true)
        {
            TimerValue += Time.deltaTime;
            Timer.text = TimerValue.ToString();
        }


    }

    void Init()
    {
        CheckRaceState();
    }

    void CheckRaceState()
    {
        switch (raceState)
        {

            case RaceState.Onwait:

                //Untuk tunggu player masuk

                break;

            case RaceState.Countdown:

                //Untuk start countdown 3,2,1
                StartCoroutine(StartCountdown());

                break;

            case RaceState.Start:

                //Bile dah start race
                StartStopwatch();
                DisplayCheckpoint();

                break;

            case RaceState.End:

                //End race
                //Display Results
                //Stop timer
                DisplayResults();
                

                break;            
        }
    }

    public void ChangeRaceState(RaceState state)
    {
        raceState = state;
        CheckRaceState();
    }

    #region OnWait

    public void EnoughPlayer()
    {
        if(isEnough == true)
        {
            StartButton.SetActive(true);
        }
    }

    //Untuk button start nanti kat game scene
    public void ProceedCountdown()
    {
        ChangeRaceState(RaceState.Countdown);
    }

    #endregion


    #region Countdown

    public IEnumerator StartCountdown()
    {
        //void start 

        while(raceState == RaceState.Countdown)
        {
            //void update
            for (int i = 0; i < Countdown.Count; i++)
            {
                Countdown[i].SetActive(true);
                yield return new WaitForSeconds(1.0f);
                Countdown[i].SetActive(false);
                yield return new WaitForSeconds(1.0f);
            }

            ChangeRaceState(RaceState.Start);
            
        }

        //StartCoroutine(RaceGo());
        //yield return new WaitForSeconds(3.1f);
        //ChangeRaceState(RaceState.Start);
        //yield return null;
    }

    //public IEnumerator RaceGo()
    //{

    //}

    #endregion


    #region Start

    //For starting stopwatch of the race
    public void StartStopwatch()
    {
        TimerUI.SetActive(true);
        isTimer = true;
    }

    //For displaying all checkpoints available around the track
    public void DisplayCheckpoint()
    {
        for (int i = 0; i < Checkpoints.Count; i++)
        {
            Checkpoints[i].SetActive(true);
        }
    }

    //For hiding checkpoint that player have passed
    public void HideCheckpoint()
    {
        
    }

    //For adding laps if player pass all checkpoints
    public void AddLaps()
    {
        
    }

    #endregion

    #region End

    //Display panel for congratulating player after finished the race
    public void DisplayResults()
    {

    }

    public void StopStopWatch()
    {
        isTimer = false;
    }

    #endregion

}
