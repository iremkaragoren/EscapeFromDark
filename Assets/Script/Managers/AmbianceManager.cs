using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class AmbianceManager : MonoBehaviour
{
    [SerializeField] private Light2D lightSource;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField, Range(0f, 1f)] private float maxVolume = 1f;
    [SerializeField] private float initialLightIntensity;

    [SerializeField] private Transform characterPosition;

    private float distanceBetweenPoints;

    private void Start()
    {
        if (lightSource == null)
        {
           
            return;
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (startPoint == null || endPoint == null)
        {
           
            return;
        }

        initialLightIntensity = lightSource.intensity;
        distanceBetweenPoints = Vector3.Distance(startPoint.position, endPoint.position);
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(characterPosition.position, endPoint.position);
        float t = Mathf.Clamp01(1 - currentDistance / distanceBetweenPoints);

        lightSource.intensity = initialLightIntensity * (1 - t);
        audioSource.volume = maxVolume * t;
    }
}
