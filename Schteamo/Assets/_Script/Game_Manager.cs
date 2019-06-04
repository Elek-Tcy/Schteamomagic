using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Steamo
{
    public class Game_Manager : MonoBehaviourPunCallbacks
    {
        public _QuickControllerNET playerPrefab;

        [HideInInspector]
        public _QuickControllerNET localPlayer;

        private void Awake()                                                        // Check if is connected
        {
            if (!PhotonNetwork.IsConnected)
            { SceneManager.LoadScene("_KilianDev");  return;}
        }

        private void Start()
        {
            _QuickControllerNET.RefreshInstance(ref localPlayer, playerPrefab);
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)  // Create a player when entering in a room
        {
            base.OnPlayerEnteredRoom(newPlayer);
            _QuickControllerNET.RefreshInstance(ref localPlayer, playerPrefab);
        }
    }
}
