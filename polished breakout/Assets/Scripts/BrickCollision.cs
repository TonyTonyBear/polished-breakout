using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    private Vector3 scaleOrigin;

    private void Awake()
    {
        scaleOrigin = transform.localScale;
    }

    public void HandleCollision()
    {
        StartCoroutine(ShrinkOut());
    }

    private IEnumerator ShrinkOut()
    {
        float duration = 0.25f;
        float timer = 0f;

        while (timer <= duration)
        {
            float t = timer / duration;
            transform.localScale = Vector3.Lerp(scaleOrigin, Vector3.zero, t);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
