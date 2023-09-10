using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePlayerC : MonoBehaviour
{
    private Animator animator;
    public float animationDelay = 1.0f; // Adjust the delay time for each drone

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component

        // Set the AnimationDelay parameter to control the delay before animation starts
        animator.SetFloat("AnimationDelay", animationDelay);

        // Trigger the animation when the delay time elapses
        StartCoroutine(TriggerAnimation());
    }

    IEnumerator TriggerAnimation()
    {
        // Wait for the specified animation delay
        yield return new WaitForSeconds(animationDelay);

        // Trigger the animation by setting the parameter
        animator.SetBool("PlayAnimation", true);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any other update logic here if needed
    }
}
