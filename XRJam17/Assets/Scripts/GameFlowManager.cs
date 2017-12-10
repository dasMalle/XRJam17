using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour {

    public Animator anim;

    public GameObject sing;
    public GameObject walk;
    public GameObject pet;
    public GameObject back;

    public static GameFlowManager instance = null; 

    // Use this for initialization
	void Start () {
        anim.SetBool("Petting", false);
        anim.SetBool("Happy", false);
        instance = this;
	}
	
	void OnPetting()
    {
        anim.SetBool("Petting", true);
        anim.SetBool("Happy", false);
    }

    void OnHappy()
    {
        anim.SetBool("Petting", false);
        anim.SetBool("Happy", true);
    }

    void OnSad(){
        anim.SetBool("Petting", false);
        anim.SetBool("Happy", false);
    }

    void DisableButtons()
    {
        sing.SetActive(false);
        walk.SetActive(false);
        pet.SetActive(false);
        back.SetActive(true);
    }

    public void Walking()
    {
        OnHappy();
        DisableButtons();
    }

    public void Petting()
    {
        OnPetting();
        DisableButtons();
        //add sounds and a mechanic
        Handheld.Vibrate();
    }

    public void Sing()
    {
        OnHappy();
        DisableButtons();
        //Insert microphone stuff
    }

    public void EnableButtons(){
        sing.SetActive(true);
        walk.SetActive(true);
        pet.SetActive(true);
        back.SetActive(false);
    }
}
