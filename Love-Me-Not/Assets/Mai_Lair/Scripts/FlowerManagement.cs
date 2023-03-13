using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace godzillabanana{
public class FlowerManagement : MonoBehaviour
{
    public GameObject[] petals;
    public KeyCode[] keycode;
    public TMP_Text Divination;
    public string[] divinationOptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<petals.Length; i++){
            if (Input.GetKeyDown(keycode[i])&&petals[i].activeSelf){
                Debug.Log("Petal "+ keycode[i].ToString()+" is active");
            }
            if (Input.GetKeyDown(keycode[i])){
                Debug.Log(keycode[i].ToString());
            }
        }
        

    }
}
}

