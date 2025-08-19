using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Rigidbody))]

public class SoundEffectForPlayer : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float sprintMultiplier = 1.8f;

    [Header("References (optional - auto-find if empty)")]
    public Rigidbody rb;
    public Animator anim;

    [Header("Audio (assign in Inspector)")]
    public AudioSource footstepsSource; // loop = true, playOnAwake = false
    public AudioSource sprintSource;    // loop = true, playOnAwake = false

    [Header("Settings")]
    public float walkThreshold = 0.05f; // „ﬁœ«— »”Ìÿ ·· „ÌÌ“ »Ì‰ ÊﬁÊ› Ê„‘Ì

    // cached inputs
    float inputX, inputZ;
    bool isMoving, isSprinting;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (anim == null) anim = GetComponent<Animator>();

        // Õ«Ê· ≈Õ÷«— AudioSources ·Ê „« ⁄Ì‰ Â„ »«·≈‰”»ﬂ Ê—
        if (footstepsSource == null || sprintSource == null)
        {
            AudioSource[] sources = GetComponents<AudioSource>();
            if (sources.Length > 0)
            {
                if (footstepsSource == null) footstepsSource = sources[0];
                if (sprintSource == null && sources.Length > 1) sprintSource = sources[1];
            }
        }

        //  √ﬂœ „‰ ≈⁄œ«œ«  AudioSource ›Ì «·‹ Inspector:
        // Loop = true, Play On Awake = false
    }

    void Update()
    {
        // ﬁ—«¡… «·≈œŒ«· ›Ì Update ( Œ“Ì‰Â ·«” Œœ«„Â ›Ì FixedUpdate)
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        isMoving = (Mathf.Abs(inputX) > walkThreshold || Mathf.Abs(inputZ) > walkThreshold);
        isSprinting = isMoving && Input.GetKey(KeyCode.LeftShift);

        // √‰Ì„Ì‘‰ (≈–« ⁄‰œﬂ »Ì—«„Ì — H Ê V)
        if (anim != null)
        {
            anim.SetFloat("H", inputX);
            anim.SetFloat("V", inputZ);
        }

        // ≈œ«—… √’Ê«  «·„‘Ì/«·Ã—Ì (‰” Œœ„ Play/Stop)
        HandleFootstepSounds();
    }

    void FixedUpdate()
    {
        // «·Õ—ﬂ… «·›⁄·Ì… ⁄»— Rigidbody.velocity „⁄ «·„Õ«›Ÿ… ⁄·Ï rb.velocity.y
        Vector3 move = new Vector3(inputX, 0f, inputZ);
        Vector3 moveDir = move.normalized; // · ›«œÌ «· ”«—⁄ ⁄‰œ «·„‘Ì ﬁÿ—Ì
        float targetSpeed = walkSpeed * (isSprinting ? sprintMultiplier : 1f);

        Vector3 newVel = new Vector3(moveDir.x * targetSpeed, rb.velocity.y, moveDir.z * targetSpeed);
        rb.velocity = newVel;
    }

    void HandleFootstepSounds()
    {
        if (isMoving)
        {
            if (isSprinting)
            {
                //  ‘€Ì· ’Ê  «·Ã—Ì° ≈Ìﬁ«› ’Ê  «·„‘Ì
                if (sprintSource != null && !sprintSource.isPlaying) sprintSource.Play();
                if (footstepsSource != null && footstepsSource.isPlaying) footstepsSource.Stop();
            }
            else
            {
                //  ‘€Ì· ’Ê  «·„‘Ì° ≈Ìﬁ«› ’Ê  «·Ã—Ì
                if (footstepsSource != null && !footstepsSource.isPlaying) footstepsSource.Play();
                if (sprintSource != null && sprintSource.isPlaying) sprintSource.Stop();
            }
        }
        else
        {
            if (footstepsSource != null && footstepsSource.isPlaying) footstepsSource.Stop();
            if (sprintSource != null && sprintSource.isPlaying) sprintSource.Stop();
        }
    }
}
