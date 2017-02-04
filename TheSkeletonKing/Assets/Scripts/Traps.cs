﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    //get soul color from other class
    public int soulColor;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        soulColor = GameObject.FindWithTag("Player").GetComponent<PlayerController>().currentSoul;
    }

    void playDeathAnimation()
    {
        StartCoroutine("waitThreeSeconds");
    }

    IEnumerator waitThreeSeconds()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAnimator.Play("");
        yield return new WaitForSeconds(3.0f);
        DestroyImmediate(GameObject.FindWithTag("Player"));
        SceneManager.LoadScene("Lose");
    }

    void OnTriggerEnter2D(Collider2D trap)
    {
        if (soulColor == 1 && (trap.tag == "spikes" || trap.tag == "arrows"))
        {
            playDeathAnimation();
        }

        else if (soulColor == 2 && (trap.tag == "pitfalls" || trap.tag == "arrows"))
        {
            playDeathAnimation();
        }

        else if (soulColor == 3 && (trap.tag == "pitfalls" || trap.tag == "spikes"))
        {
            playDeathAnimation();
        }
    }
}