using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steamo
{
    public class _QuickController : MonoBehaviour
    {
        Rigidbody body;
        _QuickControllerNET controllerNET;

        float horizontal;
        float vertical;

        public float runSpeed = 20.0f;

        void Start()
        {
            body = GetComponent<Rigidbody>();
            controllerNET = GetComponent<_QuickControllerNET>();
        }

        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            body.velocity = new Vector3(horizontal * runSpeed,0, vertical * runSpeed);
        }
    }
}
