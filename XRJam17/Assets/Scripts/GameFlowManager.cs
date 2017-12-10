using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour {

    public Animator anim;

    public Button sing;
    public Button walk;
    public Button pet;

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
        sing.enabled = false;
        walk.enabled = false;
        pet.enabled = false;
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
    }

    public void Sing()
    {
        OnHappy();
        DisableButtons();
        //Insert microphone stuff
    }

    public void EnableButtons(){
        sing.enabled = true;
        walk.enabled = true;
        pet.enabled = true;
    }
}
