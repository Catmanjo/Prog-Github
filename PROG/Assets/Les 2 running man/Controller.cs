using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Animator am;
    [SerializeField] private AudioSource au;
    [SerializeField] private AudioClip clip;
    private int time = 15;
    [SerializeField] private int movementSpeed = 10;
    private float timepass = 0;
    [SerializeField] private Transform tf;
    [SerializeField] private TextMeshProUGUI tx;

    private void Start()
    {
        am = GetComponent<Animator>();
    }
    private void Update()
    {
        timepass += Time.deltaTime;
        tx.text = $"{(int)timepass} out of 15";
        if (timepass > time)
        {
            am.SetTrigger("Lose");
            au.PlayOneShot(clip);
        }
        if (tf.position.x > 28) 
        {
            timepass = 0;
            am.SetTrigger("Win");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            am.SetTrigger("Walk");
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        }
    }
}
