using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace MyMultiplayerProject
{

    public class GameManager : MonoBehaviourPunCallbacks
    {
        public static GameManager Instance;
        public GameObject playerPrefab;

        private void Start()
        {
            Instance = this;
            if (playerPrefab == null) 
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                }
                else 
                {
                    Debug.LogFormat("Ignoring scen load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }
        

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("Not the Master Client");
            }
            Debug.LogFormat("Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("FirstRoom");
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.LogFormat("OnPlayerEneteredRoom : {0}", newPlayer.NickName);
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("Master Client is ", newPlayer.NickName);
                LoadArena();
            }
        }
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.LogFormat("OnPlayerLeftRoom : {0}", otherPlayer.NickName);
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("MasterClient Left : {0}", PhotonNetwork.IsMasterClient);
                LoadArena();
            }
        }
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}
