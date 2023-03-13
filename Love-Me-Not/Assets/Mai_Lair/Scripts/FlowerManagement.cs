using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace godzillabanana{
public class FlowerManagement : MonoBehaviour
{
    public GameObject[] petals;
    public KeyCode[] keycode;
    public TMP_Text Divination;
    public string[] divinationOptions;
    private int FlowerFaceValue;
    public Sprite[] calmFaces;
    public Sprite agFace;
    public Image flowerFace;
   
   void Start(){
    FlowerFaceValue = 0;
   }
    void Update()
    {
        for (int i = 0; i<petals.Length; i++){
            if (Input.GetKeyDown(keycode[i])&&petals[i].activeSelf){
                petals[i].SetActive(false);
                Divination.text = divinationOptions[Random.Range(0, divinationOptions.Length)];
                 FlowerFaceValue++;
                 flowerFace.sprite = agFace;
             
            }
            if (Input.GetKeyUp(keycode[i])){
                flowerFace.sprite = calmFaces[FlowerFaceValue];
            }
            if (Input.GetKeyDown(keycode[i])){
                Debug.Log("Petal "+keycode[i].ToString()+" is inactive");
            }
        }
        


    }
}
}

