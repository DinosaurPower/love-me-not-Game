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
   
   void Start(){
    FlowerFaceValue = 0;
   }
       
    

    public void Pluck(int c){
         for (int i = 0; i<petals.Length; i++){
            if (petals[c].activeSelf){
                petals[c].SetActive(false);
                Divination.text = divinationOptions[Random.Range(0, divinationOptions.Length)];
                 FlowerFaceValue++;
                StartCoroutine(faceExpress(FlowerFaceValue));
                 animCenter.GetComponent<Transform>().position = petals[c].GetComponent<Transform>().position;
                animCenter.GetComponent<Transform>().rotation = petals[c].GetComponent<Transform>().rotation;
                 GameObject petal = Instantiate(petalAnim, new Vector3(petals[c].GetComponent<Transform>().position.x, petals[c].GetComponent<Transform>().position.y, petals[c].GetComponent<Transform>().position.z), Quaternion.Euler(0, 0, petals[c].GetComponent<Transform>().rotation.z)) as GameObject;
                 petal.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);

            
             }
           

        }   
    }


    IEnumerator faceExpress(int i){       

        flowerFace.sprite = agFace;
        yield return new WaitForSeconds(.1f);
        flowerFace.sprite = agFace;
        flowerFace.sprite = calmFaces[FlowerFaceValue];

        }

 }

}
