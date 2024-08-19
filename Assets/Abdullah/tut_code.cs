using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tut_code : MonoBehaviour
{
    public string[] texts;
    public Sprite[] imgs;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = texts[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = imgs[index];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){

            if(index < imgs.Length - 1){
                ++index;
                gameObject.GetComponent<SpriteRenderer>().sprite = imgs[index];
                gameObject.GetComponent<TextMeshProUGUI>().text = texts[index];
            }else{
                Destroy(this.gameObject);
            }
        } 
    }
}
