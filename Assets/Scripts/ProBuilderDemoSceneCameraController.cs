/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBuilderDemoSceneCameraController : MonoBehaviour
{

    public float maxDistance = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
        transform.Translate(translation, 0, 0);
        if(transform.position.x > maxDistance) {
            transform.position = new Vector3(maxDistance, 1, 0);
        }
        if(transform.position.x < 0) {
            transform.position = new Vector3(0, 1, 0);
        }
    }
}
*/