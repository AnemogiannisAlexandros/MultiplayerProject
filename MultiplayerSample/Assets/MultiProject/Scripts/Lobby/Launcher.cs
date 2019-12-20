using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace MyMultiplayerProject
{
    public class Launcher : MonoBehaviourPunCallbacks, IConnectionCallbacks, IMatchmakingCallbacks
    {

        #region Private Serializable Fields
        [SerializeField]
        private GameObject progressLabel;
        [SerializeField]
        private GameObject controlPanel;
        #endregion


        #region Private Fields


        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        string gameVersion = "1";


        #endregion


        #region MonoBehaviour CallBacks


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void Update()
        {
            if (PhotonNetwork.InRoom) 
            {
                Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
                if (PhotonNetwork.CurrentRoom.PlayerCount >= 2) 
                {
                    PhotonNetwork.LoadLevel(1);
                }
            }
        }
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {
            ConnectToMaster();
        }

        public void Connect() 
        {
            progressLabel.SetActive(true);
            PhotonNetwork.JoinRandomRoom();
        }

        #endregion


        #region Public Methods
        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room : " + PhotonNetwork.CurrentRoom.Name);
            base.OnJoinedRoom();
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            Debug.LogWarning(returnCode +" " +  message);
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom("SomeRoom",options,default,null);
        }

        /// <summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        public void ConnectToMaster()
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            if (!PhotonNetwork.IsConnected) 
            {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }

        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connected to : " + PhotonNetwork.CloudRegion);
            progressLabel.SetActive(false);
            StartCoroutine(FadePanel());
            if (PhotonNetwork.IsConnectedAndReady)
            {
                Debug.Log("Ready To Join Room");
            }
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            Debug.Log("Disconnected because : " + cause);
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        private IEnumerator FadePanel() 
        {
           
            while (controlPanel.GetComponent<Image>().color.a > 0) 
            {
                controlPanel.GetComponent<Image>().color = Color.Lerp(controlPanel.GetComponent<Image>().color, new Color(0, 0, 0, 0),0.01f);
                yield return null;
                controlPanel.GetComponent<Image>().raycastTarget = false;
            }

        }
        #endregion



    }
}
