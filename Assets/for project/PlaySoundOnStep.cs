using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlaySoundOnStep : MonoBehaviour
{
    private bool IsAtDoor = false;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;

    [Header("Sounds")]
    public AudioSource doorAudio;   // ’Ê  «·»«»
    public AudioSource button1Audio;
    public AudioSource button2Audio;
    public AudioSource button3Audio;
    public AudioSource button4Audio;

    void Start()
    {
        anim = GetComponent<Animator>();



    }

    void Update()
    {


        CodeText.text = codeTextValue;
        if (codeTextValue == safeCode)
        {
            anim.SetTrigger("OpenWall");
            CodePanel.SetActive(false);

            if (doorAudio != null)
                doorAudio.Play();
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
    }

    // -------------------
    // √“—«— «·√—ﬁ«„
    // -------------------
    public void PressButton1()
    {
        codeTextValue += "1";
        if (button1Audio != null) button1Audio.Play();
    }

    public void PressButton2()
    {
        codeTextValue += "2";
        if (button2Audio != null) button2Audio.Play();
    }

    public void PressButton3()
    {
        codeTextValue += "3";
        if (button3Audio != null) button3Audio.Play();
    }

    public void PressButton4()
    {
        codeTextValue += "4";
        if (button4Audio != null) button4Audio.Play();
    }
}