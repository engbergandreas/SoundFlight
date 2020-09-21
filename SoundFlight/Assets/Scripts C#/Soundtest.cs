using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soundtest : MonoBehaviour
{
    AudioSource background_music;
    public float[] spectrum;
    public float[] band_spectrum;
    public GameObject stapel;
    public GameObject[] stapel_array;

    const int LENGTH = 1024;
    const int BANDS = 24;

    // Start is called before the first frame update
    void Start()
    {
        background_music = GetComponent<AudioSource>();
        spectrum = new float[LENGTH];
        stapel_array = new GameObject[BANDS];

        for(int i = 0; i < BANDS; i++) {
          stapel_array[i] = Instantiate(stapel, new Vector3(i*0.1f,0,0),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
      MakeBands();

      //What is channel 0???
      background_music.GetSpectrumData(spectrum,0,FFTWindow.Hanning);

      for(int i = 0; i < band_spectrum.Length; i++){
        Transform transform = stapel_array[i].GetComponent<Transform>();
        transform.localScale = new Vector3(0.1f, 10*band_spectrum[i], 0.1f);
        transform.position = new Vector3(i*0.1f, band_spectrum[i]*5, 0);
      }
    }

    void MakeBands()
    {
      band_spectrum = new float[BANDS];
      for(int i = 0; i < BANDS; i++)
      {
        for(int j = 0; j < LENGTH/BANDS; j++)
        {
          //Logarithmic scale
          band_spectrum[i] += spectrum[j + LENGTH/BANDS*i];
        }
        band_spectrum[i] /= LENGTH/BANDS;
      }
    }
}
