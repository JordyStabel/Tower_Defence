using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioObject : MonoBehaviour {

    private float soundLenght;

    // Use this for initialization
    void Start()
    {

        var Sound = this.GetComponent<AudioSource>();
        soundLenght = Sound.clip.length;

    }

    // Update is called once per frame
    void Update()
    {

        soundLenght -= Time.deltaTime;
        if (soundLenght <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}