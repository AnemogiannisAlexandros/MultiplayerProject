using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace MyMultiplayerProject
{
    public class Client : MonoBehaviourPunCallbacks, IConnectionCallbacks, IMatchmakingCallbacks
    {
        private LoadBalancingClient loadBalancingClient;

        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        string gameVersion = "1";

        public Client()
        {
            this.loadBalancingClient = new LoadBalancingClient();
            this.SubscribeToCallbacks();
        }
        ~Client()
        {
            this.UnsubscribeFromCallbacks();
        }
        private void SubscribeToCallbacks()
        {
            this.loadBalancingClient.AddCallbackTarget(this);
        }
        private void UnsubscribeFromCallbacks()
        {
            this.loadBalancingClient.RemoveCallbackTarget(this);
        }

        void JoinRandomRoom(byte maxPlayers) 
        {
            PhotonNetwork.JoinRandomRoom(default, maxPlayers);
        }
        void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message) 
        {
            if (returnCode == ErrorCode.NoRandomMatchFound) 
            {

            }

        }
    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Client: OnConnectedToMaster() was called by PUN");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Client: OnDisconnected() was called by PUN with reason {0}", cause);
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        Connect();
    }






    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            Debug.Log("User Is Connected");
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    }
}
