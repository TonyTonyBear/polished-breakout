using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    public void HandleCollision()
    {
        Destroy(gameObject);
    }
}
