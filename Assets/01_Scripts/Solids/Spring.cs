﻿
using System;
using UnityEngine;

public class Spring : Solid
{
    private Animator anim;
    
    // const
    private const string StAnimSpringUp = "Spring_Up";
    private const string StAnimSpringDown = "Spring_Down";
    
    private bool onPlay = false;
    private bool isPlayingUp = false;
    private bool isPlayingDown = false;
    
    private float timer;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void OnTouchingActor()
    {
        onPlay = true;
        anim.Play(StAnimSpringUp, 0, 0);
    }

    private void Update()
    {
        if (onPlay)
        {
            onPlay = false;
            isPlayingUp = true;
            isPlayingDown = false;
            timer = anim.GetCurrentAnimatorStateInfo(0).length;
        }

        // playing
        if (timer > 0f)
            timer -= Time.deltaTime;
        else if (isPlayingUp)
        {
            anim.Play(StAnimSpringDown);
            isPlayingUp = false;
            isPlayingDown = true;
            timer = anim.GetCurrentAnimatorStateInfo(0).length;
        }
        else if (isPlayingDown)
        {
            isPlayingDown = false;
        }
            
    }
}


