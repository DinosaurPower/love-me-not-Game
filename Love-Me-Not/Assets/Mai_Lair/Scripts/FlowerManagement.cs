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
    public GameObject petalAnim;
    public GameObject animCenter;
   public RandomSoundScript randSound;
   public Effects grayscale;
   public int Rando;
   public GameObject pseudoPetals;
   void Start(){
    FlowerFaceValue = 0;
   }
    void Update()
    {
        for (int i = 0; i<petals.Length; i++){
            if (Input.GetKeyDown(keycode[i])&&petals[i].activeSelf){
                randSound.CallAudio();
                petals[i].SetActive(false);
                Rando = Random.Range(0, divinationOptions.Length);
                Divination.text = divinationOptions[Rando];
                 FlowerFaceValue++;
                 flowerFace.sprite = agFace;
                 animCenter.GetComponent<Transform>().position = petals[i].GetComponent<Transform>().position;
                  animCenter.GetComponent<Transform>().rotation = petals[i].GetComponent<Transform>().rotation;
                 GameObject petal = Instantiate(petalAnim, new Vector3(petals[i].GetComponent<Transform>().position.x, petals[i].GetComponent<Transform>().position.y, petals[i].GetComponent<Transform>().position.z), Quaternion.Euler(0, 0, petals[i].GetComponent<Transform>().rotation.z)) as GameObject;
                 petal.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
                grayscale.styleStrength+= 0.166f;
             
            }
            if (Input.GetKeyUp(keycode[i])){
                flowerFace.sprite = calmFaces[FlowerFaceValue];
            }
            if (Input.GetKeyDown(keycode[i])){
               // Debug.Log("Petal "+keycode[i].ToString()+" is inactive");
            }
        }

        if (FlowerFaceValue == calmFaces.Length-1){
           if (Rando == 0){
            grayscale.styleStrength = 0;
            pseudoPetals.SetActive(true);
            flowerFace.sprite = calmFaces[0];

           }
        }
        


    }
}
}

