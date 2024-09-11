using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CineChange : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("Titele");
    }


    public IEnumerator CangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

}
