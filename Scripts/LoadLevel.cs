using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
   private float delayBeforeLoading = 10f;
   [SerializeField]
   private string sceneNameToLoad;

   private float timeElapsed;

    // Update is called once per frame
    private void Update()
    {
       timeElapsed += Time.deltaTime;

      if(timeElapsed > delayBeforeLoading)
      {
          SceneManager.LoadScene(sceneNameToLoad);
      }  
    }
}

