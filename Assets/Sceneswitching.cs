using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitching : MonoBehaviour
{
    public string scenename="";

    void Update()
    {
    
    }   
    public void switchscene() {
        Debug.Log("trigger?");
        SceneManager.LoadScene(scenename);
    }
}
