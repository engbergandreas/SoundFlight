using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtest : MonoBehaviour
{
    AudioSource background_music;
    public float[] spectrum;
    public GameObject stapel;
    public GameObject[] stapel_array;

    // Start is called before the first frame update
    void Start()
    {
      int length = 128;
        background_music = GetComponent<AudioSource>();
        spectrum = new float[length];
        stapel_array = new GameObject[length];

        for(int i = 0; i < spectrum.Length; i++) {
          stapel_array[i] = Instantiate(stapel, new Vector3(i*0.1f,0,0),Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
      //What is channel 0???
      background_music.GetSpectrumData(spectrum,0,FFTWindow.Hanning);

      for(int i = 0; i < spectrum.Length; i++){
        Transform transform = stapel_array[i].GetComponent<Transform>();
        transform.localScale = new Vector3(0.1f, 10*spectrum[i], 0.1f);
        transform.position = new Vector3(i*0.1f, spectrum[i]*5, 0);
      }
    }
}
