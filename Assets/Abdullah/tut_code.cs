using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tut_code : MonoBehaviour
{
    public string[] texts;
    public Sprite[] imgs;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = texts[index];
        gameObject.GetComponent<Image>().sprite = imgs[index];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){

            if(index < imgs.Length - 1){
                ++index;
                gameObject.GetComponent<Image>().sprite = imgs[index];
                gameObject.GetComponentInChildren<Text>().text = texts[index];
            }else{
                SceneManager.LoadScene("game");
                Destroy(this.gameObject);
            }
        } 
    }
}
