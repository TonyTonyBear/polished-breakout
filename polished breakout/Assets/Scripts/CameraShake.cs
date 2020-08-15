using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        float timer = 0f;
        Vector3 originalPosition = transform.localPosition;

        while (timer < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
