using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(name);
    }

    // Update is called once per frame
    public void Exit(){
        Application.Quit();
    }
}
