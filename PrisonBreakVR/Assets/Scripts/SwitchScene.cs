using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    public int sceneIndex;
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            SceneManager.LoadScene(sceneIndex);

            SceneManager.LoadScene(sceneName);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
