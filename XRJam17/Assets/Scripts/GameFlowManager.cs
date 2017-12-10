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

    public Text Steps; //Geez sort this!
    public AudioRecorder rec;


    public enum GameScreens
    {
        MainScreen = 0, 
        PetScreen = 1, 
        WalkScreen = 2,
        SingScreen = 3

    }

    public GameScreens ScreenState;

    public static GameFlowManager instance = null; 

    // Use this for initialization
	void Start () {
        anim.SetBool("Petting", false);
        anim.SetBool("Happy", false);
        instance = this;

        ScreenState = GameScreens.MainScreen;
	}
	

    void Update(){
        switch(ScreenState){
            case GameScreens.MainScreen:
                EnableButtons();
                Steps.color = Color.clear;
                break;
            case GameScreens.PetScreen:
                Petting();
                DisableButtons();
                Steps.color = Color.clear;
                break;
            case GameScreens.SingScreen:
                Sing();
                DisableButtons();
                Steps.color = Color.clear;
                break;
            case GameScreens.WalkScreen:
                Walking();
                DisableButtons();
                Steps.color = Color.blue;
                break;
        }
    }

    public void SetScreen(int screen)
    {
        ScreenState = (GameScreens)screen;
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

     void Walking()
    {
        OnHappy();
        DisableButtons();

    }

    private void Petting()
    {
        OnPetting();
        DisableButtons();
    }

     void Sing()
    {
        OnHappy();
        DisableButtons();
        //Insert microphone stuff
        rec.StartRecording();


    }
    //this is the back button
    void EnableButtons(){
        sing.SetActive(true);
        walk.SetActive(true);
        pet.SetActive(true);
        back.SetActive(false);
        OnSad();
    }
}
