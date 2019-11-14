using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace MyMultiplayerProject
{


    public class RoomManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("Maximum amount of players in the room")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        string gameVersion = "0.0.0.0";

        [Tooltip("The Ui Panel to let the user enter name, connect and play")]
        [SerializeField]
        private GameObject controlPanel;
        [Tooltip("The UI Label to inform the user that the connection is in progress")]
        [SerializeField]
        private GameObject progressLabel;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        private void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        public void Connect()
        {
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        public override void OnConnectedToMaster()
        {
            progressLabel.SetActive(false);
            Debug.Log("Pun Connected To ServerMaster");
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogFormat("Disconnected because : {0}", cause);
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.LogFormat("Join Random Room Failed. Creating new room");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }
        public override void OnJoinedRoom()
        {
            Debug.LogFormat("Joined Room : {0}", PhotonNetwork.CurrentRoom.Name);
        }
    }
}
