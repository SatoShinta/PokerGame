using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]Animator tutorialAnimator;
    [SerializeField] Animator tutorialAnimator2;

    public void Start()
    {
        tutorialAnimator2.Play("Sanim");
    }
    public void TutorialAnim()
    {
        tutorialAnimator.Play("MainCameraanim");
    }
}
