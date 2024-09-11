using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]Animator tutorialAnimator;
    public void TutorialAnim()
    {
        tutorialAnimator.Play("MainCameraanim");
    }
}
