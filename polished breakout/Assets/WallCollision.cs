using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public class WallCollision : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        public BoxCollider2D boxCollider { get { return _boxCollider; } }

        private void OnEnable()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }
    }
}

