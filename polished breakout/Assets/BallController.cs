using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public class BallController : MonoBehaviour
    {
        private Vector3 velocity;

        private void OnEnable()
        {
            velocity = Vector3.down;
        }

        private void Update()
        {
            transform.position += velocity * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PaddleController paddle = collision.GetComponent<PaddleController>();
            WallCollision wall = collision.GetComponent<WallCollision>();

            if (paddle != null)
            {
                velocity.y *= -1f;

                float distanceToCenter = transform.position.x - paddle.transform.position.x;

                if (distanceToCenter < 0)
                {
                    float t = Mathf.InverseLerp(paddle.transform.position.x,
                                                paddle.transform.position.x - paddle.boxCollider.bounds.extents.x,
                                                transform.position.x);

                    Quaternion angle = Quaternion.Lerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 50f), t);
                    velocity = angle * velocity;
                    velocity.Normalize();
                }
                else
                {
                    float t = Mathf.InverseLerp(paddle.transform.position.x,
                                                paddle.transform.position.x + paddle.boxCollider.bounds.extents.x,
                                                transform.position.x);

                    Quaternion angle = Quaternion.Lerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -50f), t);
                    velocity = angle * velocity;
                    velocity.Normalize();
                }
            }

            if (wall != null)
            {
                velocity.y *= -1f;
            }
        }
    }
}

