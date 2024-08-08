using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChange : MonoBehaviour
{
    public Sprite image;
    public Button quit;
    // Start is called before the first frame update
    
    public void FlipImage(Button button)
    {
        button.GetComponent<Image>().sprite = image;

        button.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }
}
