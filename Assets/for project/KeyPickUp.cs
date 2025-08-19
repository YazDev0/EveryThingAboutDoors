using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject keyimage;   // ���� ������� �� �����������
    public GameObject keyistrue;  // ���� ������� (�������)

    public static bool hasKey = false; // ����� ��� ����� �� ����� ����

    private bool canPickUp = false; // �� ������ ���� �� ������Ϳ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true; // ������ ��� ����� �������
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false; // ������ ��� �� ����� �������
        }
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E)) // �� ���� ���� E
        {
            hasKey = true; // ��� ��� �������

            if (keyimage != null)
                keyimage.SetActive(true);

            if (keyistrue != null)
                keyistrue.SetActive(true);

            Debug.Log("Player picked up the key!");
            Destroy(gameObject); // ���� ������� �� ������
        }
    }
}