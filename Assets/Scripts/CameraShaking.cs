using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] float shakeMagnitude = 0.15f;
    [SerializeField] float shakeDuration = 1f;
    Vector3 initialPos;
    void Awake()
    {
        initialPos = transform.position;
    }

    public void ShakeCamera() => StartCoroutine(Shake());

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        do
        {
            elapsedTime += Time.deltaTime;
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        while (elapsedTime < shakeDuration);
    }
}
