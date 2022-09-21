/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSegmentLoader : MonoBehaviour
{
    private bool isLoaded = false;
    private bool isUnloaded = true;
    public string sceneToLoad;
    public string sceneToUnload;

    // Start is called before the first frame update
    void Start()
    {
        checkLoadedScenesStatus();
    }

    void checkLoadedScenesStatus() {
        if(SceneManager.sceneCount > 0) {
            for(int i = 0; i < SceneManager.sceneCount; ++i) {
                Scene scene = SceneManager.GetSceneAt(i);
                if(scene.name == sceneToLoad) isLoaded = true;
                else isLoaded = false;
                if(scene.name == sceneToUnload) isUnloaded = false;
                else isUnloaded = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(sceneToUnload);
        checkLoadedScenesStatus();
        if(other.gameObject.CompareTag("Player")) {
            if(!sceneToLoad.Equals("")) LoadSceneSegment(sceneToLoad);
            if(!sceneToUnload.Equals("")) UnloadSceneSegment(sceneToUnload);
        }
    }

    void LoadSceneSegment(string sceneName) {
        if(isLoaded == false) {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void UnloadSceneSegment(string sceneName) {
        if(isUnloaded == false) {
            SceneManager.UnloadSceneAsync(sceneName);
            isUnloaded = true;
        }
    }
}
*/