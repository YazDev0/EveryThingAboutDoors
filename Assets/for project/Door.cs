using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{


    private bool canOpen = false; // هل اللاعب قريب من الباب؟
    private bool isOpen = false;  // هل الباب مفتوح بالفعل؟

    private Animator animator; // اربط Animator تبع الباب في Inspector
    public AudioSource doorSound;

    void Start()
    {
            animator = GetComponent<Animator>(); // لو ما ربطته في Inspector

            doorSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

    void Update()
    {
        if (canOpen && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            if (KeyPickUp.hasKey) // لازم يكون معه مفتاح
            {
                isOpen = true;

                if (animator != null)
                {
                    animator.SetTrigger("OpenDoor"); // يشغل أنيميشن فتح الباب
                }

                if (doorSound != null)
                    doorSound.Play(); // يشغل الصوت

                Debug.Log("🚪 الباب انفتح بالأنيميشن!");
            }
            else
            {
                Debug.Log("🔒 الباب مقفل، تحتاج مفتاح.");
            }
        }
    }
}