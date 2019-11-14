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
