using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public class PaddleController : MonoBehaviour
    {
        void Update()
        {
            Vector3 updatedPosition = Vector3.zero;
            float moveSpeed = 5f;

            if (Input.GetKey(KeyCode.A))
            {
                // Move left.
                updatedPosition.x -= Time.deltaTime * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Move right.
                updatedPosition.x += Time.deltaTime * moveSpeed;
            }

            transform.localPosition += updatedPosition;

        }
    }
}

