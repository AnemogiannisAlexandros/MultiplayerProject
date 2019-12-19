using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateButtons : MonoBehaviour
{
    public Material materialInstance;
    public float xoffsetMulty;
    public float yOffsetMulty;
    bool turnX,turnY = false;
    // Start is called before the first frame update
    void Start()
    {
        materialInstance = Instantiate(materialInstance);
        GetComponent<Image>().material = materialInstance;
    }

    // Update is called once per frame
    void Update()
    {
        // materialInstance.mainTextureOffset += new Vector2(speed * (Mathf.Sin(materialInstance.mainTextureOffset.x + materialInstance.mainTextureOffset.y) * speed + Time.deltaTime * xoffsetMulty), speed * (Mathf.Sin(materialInstance.mainTextureOffset.x + materialInstance.mainTextureOffset.y) * speed + Time.deltaTime * yOffsetMulty));
        ScrollBackground();

    }
    private void ScrollBackground()
    {
        Vector2 offset = materialInstance.mainTextureOffset;


        offset.x += Time.deltaTime * xoffsetMulty;
        if (!turnY)
        {
            offset.y += Time.deltaTime * yOffsetMulty;
            if (offset.y >= 0.2f)
            {
                turnY = !turnY;
            }
        }
        else 
        {
            offset.y -= Time.deltaTime * yOffsetMulty;
            if (offset.y <= 0) 
            {
                turnY = !turnY;
            }
        }
       


        materialInstance.mainTextureOffset = offset;
    }
}
