﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public enum CollisionState { LEFT, RIGHT, NONE }

    public class PaddleController : MonoBehaviour
    {
        private CollisionState currentCollisionState;
        private BoxCollider2D _boxCollider;
        public BoxCollider2D boxCollider { get { return _boxCollider; } }

        private void OnEnable()
        {
            currentCollisionState = CollisionState.NONE;
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            Vector3 updatedPosition = Vector3.zero;
            float moveSpeed = 5f;

            if (Input.GetKey(KeyCode.A))
            {
                // Move left.
                updatedPosition.x -= currentCollisionState == CollisionState.LEFT ? 0f : Time.deltaTime * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Move right.
                updatedPosition.x += currentCollisionState == CollisionState.RIGHT ? 0f : Time.deltaTime * moveSpeed;
            }

            transform.localPosition += updatedPosition;

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            WallCollision wall = collision.gameObject.GetComponent<WallCollision>();

            if (wall != null)
            {
                // Determine the direction of the collision to know what our wall collision is.
                if (collision.transform.position.x > transform.position.x)
                {
                    currentCollisionState = CollisionState.RIGHT;

                    Vector3 updatedPosition = transform.position;
                    updatedPosition.x = wall.transform.position.x -
                                        wall.boxCollider.bounds.extents.x -
                                        _boxCollider.bounds.extents.x;

                    transform.position = updatedPosition;
                }
                else
                {
                    currentCollisionState = CollisionState.LEFT;

                    Vector3 updatedPosition = transform.position;

                    updatedPosition.x = wall.transform.position.x +
                                        wall.boxCollider.bounds.extents.x +
                                        _boxCollider.bounds.extents.x;

                    transform.position = updatedPosition;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<WallCollision>() != null)
            {
                currentCollisionState = CollisionState.NONE;
            }
        }
    }
}

