using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Steamo
{
    public class _ValueTest : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {

        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { ConnectToMaster();}

        }


        public void ConnectToMaster()
        {
            PhotonNetwork.OfflineMode = false;              // true "fake" an online connection

            PhotonNetwork.ConnectUsingSettings();           //  Auto Connection
        }

        #region Connection

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connection Success");
            OnConnectedToRoom();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
        }

        public void OnConnectedToRoom()
        {
            if (!PhotonNetwork.IsConnected)
                return;
            PhotonNetwork.JoinRandomRoom();
        }

        #endregion

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            Debug.Log(message);
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.Name);
            SceneManager.LoadScene("_KilianLobbyRoom");
        }

    }
}
