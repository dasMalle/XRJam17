using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //mute audiosource
public class MicrophoneInput : MonoBehaviour
{

    AudioSource aud;
    float[] clipSampleData = new float[1024];
    bool isSpeaking = false;
    public float minimumLevel = 10f;



    void Start()
    {
        aud = GetComponent<AudioSource>();

        StartCoroutine(InitMicrophone());

    }

    public void OnStartRecord()
    {
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        while (!(Microphone.GetPosition(null) > 0)) { }
        aud.Play();
    }

   

    IEnumerator InitMicrophone()
    {
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        aud.Play();
        yield return new WaitForSeconds(1);
        Microphone.End("Built-in Microphone");
        minimumLevel = aud.volume;
    }


    void Update()
    {
        aud.GetSpectrumData(clipSampleData, 0, FFTWindow.Rectangular);
        float currentAverageVolume = clipSampleData.Average();

        if (currentAverageVolume > minimumLevel)
        {
            isSpeaking = true;
        }
        else if (isSpeaking)
        {
            isSpeaking = false;
            //volume below level, but user was speaking before. So user stopped speaking
            OnStopRecord();
        }
    }


    private void OnStopRecord()
    {
        Microphone.End("Built-in Microphone");
    }


    public bool SangEnough(float minLength){

        if(aud.clip.length >  minLength)
            return true;
        return false;
    }
}
