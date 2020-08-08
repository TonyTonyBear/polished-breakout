using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public enum WallType { HORIZONTAL, VERTICAL }
    public class WallCollision : MonoBehaviour
    {
        private BoxCollider2D _boxCollider;
        public BoxCollider2D boxCollider { get { return _boxCollider; } }
        [SerializeField] private WallType _wallType;
        public WallType wallType { get { return _wallType; } }

        private void OnEnable()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }
    }
}

