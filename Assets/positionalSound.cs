using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionalSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        if (audioSource != null)
        {
            audioSource.spatialBlend = 1f; // 3D
            audioSource.minDistance = 1f;
            audioSource.maxDistance = 30f;
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
            audioSource.Play();
        }
    }
}
