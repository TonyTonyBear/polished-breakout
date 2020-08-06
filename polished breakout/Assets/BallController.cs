using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public class BallController : MonoBehaviour
    {
        private Vector3 velocity;
        [SerializeField] private float speed = 5f;

        private void OnEnable()
        {
            velocity = Vector3.down;
        }

        private void Update()
        {
            transform.position += velocity * Time.deltaTime * speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PaddleController paddle = collision.gameObject.GetComponent<PaddleController>();
            WallCollision wall = collision.gameObject.GetComponent<WallCollision>();
            BrickCollision brick = collision.gameObject.GetComponent<BrickCollision>();

            if (brick != null)
            {
                velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
                brick.HandleCollision();
                return;
            }

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

                return;
            }

            if (wall != null)
            {
                if (wall.wallType == WallType.HORIZONTAL)
                    velocity.x *= -1f;
                else if (wall.wallType == WallType.VERTICAL)
                    velocity.y *= -1f;

                return;
            }
        }
    }
}

