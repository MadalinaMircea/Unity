using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundScript : MonoBehaviour {

    public AudioSource EvenFootstep;
    public AudioSource OddFootstep;

    bool even = true;

    private void OnTriggerEnter(Collider other)
    {
        if (even)
        {
            EvenFootstep.Play();
            even = false;
        }
        else
        {
            OddFootstep.Play();
            even = true;
        }
    }
}
