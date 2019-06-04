using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Steamo
{
    public class _QuickControllerNET : MonoBehaviourPun
    {
       
        void Awake()
        {
            if (!photonView.IsMine && GetComponent<_QuickController>() != null)
                { Destroy(GetComponent<_QuickController>());}
        }

        public static void RefreshInstance(ref _QuickControllerNET controllerNET, _QuickControllerNET prefab)
        {
            var position = Vector3.zero;

            if (controllerNET != null)
            {
                position = controllerNET.transform.position;
                PhotonNetwork.Destroy(controllerNET.gameObject);
            }

            controllerNET = PhotonNetwork.Instantiate(prefab.gameObject.name, position, Quaternion.identity).GetComponent<_QuickControllerNET>();
        }
    }
}
