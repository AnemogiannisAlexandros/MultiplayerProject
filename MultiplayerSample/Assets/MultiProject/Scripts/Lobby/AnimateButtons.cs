using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateButtons : MonoBehaviour
{
    public Material materialInstance;
    public float xoffsetMulty;
    public float yOffsetMulty;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        materialInstance = Instantiate(materialInstance);
        GetComponent<Image>().material = materialInstance;
    }

    // Update is called once per frame
    void Update()
    {
        materialInstance.mainTextureOffset += new Vector2(speed * (Mathf.Sin(materialInstance.mainTextureOffset.x + materialInstance.mainTextureOffset.y) * speed + Time.deltaTime* xoffsetMulty), speed * (Mathf.Sin(materialInstance.mainTextureOffset.x+ materialInstance.mainTextureOffset.y) * speed + Time.deltaTime * yOffsetMulty));
    }
}
