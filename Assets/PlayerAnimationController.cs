using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerAnimationController : MonoBehaviour {
    //private PlatformerCharacter2D playerController;
    private Animator anim; // Reference to the player's animator component.
    // Use this for initialization
    void Start () {
        //playerController = GetComponentInParent<PlatformerCharacter2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        /*if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
            */

    }
}
