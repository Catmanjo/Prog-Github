using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    [SerializeField] private GameObject gb;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gb);
    }
}
