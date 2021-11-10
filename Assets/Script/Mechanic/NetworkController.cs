using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace GameJam.Mechanic
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {
        //public GameObject Cube;

        [Space(10)]
        public TMP_InputField createInputText;
        public TMP_InputField joinInputText;
        
        

        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        //Use this method dont need dontdestroyonload but it will spawn in another level
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "LevelDesign_1")
            {
               Transform emptyPos = SpawnManager.instance.emptyPos; //run the function

                    PhotonNetwork.Instantiate("DummyCar", emptyPos.position, emptyPos.rotation);
                    GetComponent<SpawnManager>();


                //1) Transform emptyPos = SpawnManager.instance.emptyPos;

                //2) *cara susah/advanced


            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to Master server");
        }        

        public void CreateRoom()
        {
            //For specific
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.BroadcastPropsChangeToAll = true; //custom property
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(createInputText.text);

            Debug.Log("Create Room");
        }

        public void JoinRoom()
        {
            //By name
            PhotonNetwork.JoinRoom(joinInputText.text);//dynamic
            Debug.Log("Join Room" + createInputText.text);
        }

        //To join a random room
        public void QuickStart()
        {
            string randomRoom = "Room";
            Photon.Realtime.RoomOptions opts = new Photon.Realtime.RoomOptions();
            opts.IsOpen = true;
            opts.IsVisible = true;
            opts.MaxPlayers = 4;

            PhotonNetwork.JoinOrCreateRoom(randomRoom, opts, Photon.Realtime.TypedLobby.Default);
            Debug.Log("Joined random room");

        }

        //Depends on what we want to do else dont need it
        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();

            
            //Debug.Log("LoadLevel");
        }

        //ada dontdestroyonload and it will automatically bring the spawn object into next level
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            PhotonNetwork.LoadLevel("LevelDesign_1");
            //PhotonNetwork.Instantiate("Cube", Vector3.zero, Quaternion.identity);
            Debug.Log("Detect spawn");
        }

        
    }
}
