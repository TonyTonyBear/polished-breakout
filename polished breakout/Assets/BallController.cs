using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolishedBreakout
{
    public class BallController : MonoBehaviour
    {
        private Vector3 velocity, scaleOrigin;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Transform paddleTransform;
        private bool gameStarted = false;

        private void OnEnable()
        {
            velocity = Vector3.down;
            scaleOrigin = transform.localScale;
        }

        private void Update()
        {
            if (!gameStarted)
            {
                Vector3 updatedPosition = transform.position;
                updatedPosition.x = paddleTransform.position.x;
                transform.position = updatedPosition;
            }
            else
                transform.position += velocity * Time.deltaTime * speed;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(SquashAnim());
            }
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
            }

            if (wall != null)
            {
                if (wall.wallType == WallType.HORIZONTAL)
                    velocity.x *= -1f;
                else if (wall.wallType == WallType.VERTICAL)
                    velocity.y *= -1f;
            }

            Vector2 contactNormal = collision.contacts[0].normal;

            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(contactNormal.y, contactNormal.x) * Mathf.Rad2Deg);
            StartCoroutine(SquashAnim());
        }

        private IEnumerator SquashAnim()
        {
            float duration = 0.125f;
            float timer = 0f;
            float t;

            Vector3 targetScale = scaleOrigin;
            targetScale.x /= 2f;

            while (timer < duration)
            {
                t = timer / duration;
                transform.localScale = Vector3.Lerp(scaleOrigin, targetScale, t);
                timer += Time.deltaTime;
                yield return null;
            }

            while (timer >= 0)
            {
                t = timer / duration;
                transform.localScale = Vector3.Lerp(scaleOrigin, targetScale, t);
                timer -= Time.deltaTime;
                yield return null;
            }

            transform.localScale = scaleOrigin;
        }
    }
}

