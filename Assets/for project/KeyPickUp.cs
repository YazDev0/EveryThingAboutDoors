using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyimage;   // ’Ê—… «·„› «Õ ›Ì «·«‰›Ì‰ Ê—Ì
    public GameObject keyistrue;  // Õ«·… «·„› «Õ («Œ Ì«—Ì)

    public static bool hasKey = false; // „ €Ì— ⁄«„ Ìﬁ—√Â √Ì ”ﬂ—»  À«‰Ì

    private bool canPickUp = false; // Â· «··«⁄» ﬁ—Ì» „‰ «·„› «Õø

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true; // «··«⁄» œŒ· „‰ÿﬁ… «·„› «Õ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false; // «··«⁄» ÿ·⁄ „‰ „‰ÿﬁ… «·„› «Õ
        }
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E)) // ·Ê ﬁ—Ì» Ê÷€ÿ E
        {
            hasKey = true; // ’«— „⁄Â «·„› «Õ

            if (keyimage != null)
                keyimage.SetActive(true);

            if (keyistrue != null)
                keyistrue.SetActive(true);

            Debug.Log("Player picked up the key!");
            Destroy(gameObject); // ‰Œ›Ì «·„› «Õ „‰ «·⁄«·„
        }
    }
}