using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Steamo
{
    public class _CountPlayers : MonoBehaviour
    {
        void Update()
        {
            Debug.Log(PhotonNetwork.CountOfPlayers);
        }
    }
}
