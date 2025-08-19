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
    public float walkThreshold = 0.05f; // ����� ���� ������� ��� ���� ����

    // cached inputs
    float inputX, inputZ;
    bool isMoving, isSprinting;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (anim == null) anim = GetComponent<Animator>();

        // ���� ����� AudioSources �� �� ������ �����������
        if (footstepsSource == null || sprintSource == null)
        {
            AudioSource[] sources = GetComponents<AudioSource>();
            if (sources.Length > 0)
            {
                if (footstepsSource == null) footstepsSource = sources[0];
                if (sprintSource == null && sources.Length > 1) sprintSource = sources[1];
            }
        }

        // ���� �� ������� AudioSource �� ��� Inspector:
        // Loop = true, Play On Awake = false
    }

    void Update()
    {
        // ����� ������� �� Update (������ ��������� �� FixedUpdate)
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        isMoving = (Mathf.Abs(inputX) > walkThreshold || Mathf.Abs(inputZ) > walkThreshold);
        isSprinting = isMoving && Input.GetKey(KeyCode.LeftShift);

        // ������� (��� ���� �������� H � V)
        if (anim != null)
        {
            anim.SetFloat("H", inputX);
            anim.SetFloat("V", inputZ);
        }

        // ����� ����� �����/����� (������ Play/Stop)
        HandleFootstepSounds();
    }

    void FixedUpdate()
    {
        // ������ ������� ��� Rigidbody.velocity �� �������� ��� rb.velocity.y
        Vector3 move = new Vector3(inputX, 0f, inputZ);
        Vector3 moveDir = move.normalized; // ������ ������� ��� ����� ����
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
                // ����� ��� ����� ����� ��� �����
                if (sprintSource != null && !sprintSource.isPlaying) sprintSource.Play();
                if (footstepsSource != null && footstepsSource.isPlaying) footstepsSource.Stop();
            }
            else
            {
                // ����� ��� ����� ����� ��� �����
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
