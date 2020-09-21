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


    const int SAMPLE_RATE = 22050;
    const int LENGTH = 4096; //Amount of samples
    const int BANDS = 30; //Amount of eq bands

    //The size of 4096 equally sized sample intervall
    float hzwidth = SAMPLE_RATE / LENGTH;
    float multiplier = 10;

    // Start is called before the first frame update
    void Start()
    {
        background_music = GetComponent<AudioSource>();
        spectrum = new float[LENGTH];
        stapel_array = new GameObject[BANDS];
        band_spectrum = new float[BANDS];

        for(int i = 0; i < BANDS; i++) {
          stapel_array[i] = Instantiate(stapel, new Vector3(i*0.1f,0,0),Quaternion.identity);
        }
    }
<<<<<<< Updated upstream

    // Update size every frame
=======
    public void Test()
    {
    }
    // Update is called once per frame
>>>>>>> Stashed changes
    void Update()
    {
      //Eqbands creates a spectrum of values for the different frequencybands
      MakeBands();

      //FFT spectrum, Hanning window
      background_music.GetSpectrumData(spectrum,0,FFTWindow.Hanning);

<<<<<<< Updated upstream
      for(int i = 0; i < band_spectrum.Length; i++){
        Transform transform = stapel_array[i].GetComponent<Transform>();
        transform.localScale = new Vector3(0.1f, multiplier*band_spectrum[i], 0.1f);
        transform.position = new Vector3(i*0.1f, band_spectrum[i]*(multiplier/2), 0);
      }
    }


    void MakeBands()
    {
      float cur_hz = 20;
      int counter = 0;

      float maxval = 0;

      for(int i = 0; i < LENGTH; i++)
      {
          if(hzwidth*i > cur_hz)
          {
            band_spectrum[counter] = Mathf.Log10(1+maxval); //sets max value in the range
            //reset for new range
            counter++;
            cur_hz *= Mathf.Pow(2,1/3f);
            maxval = 0;
          }
          maxval = (maxval < spectrum[i]) ? spectrum[i] : maxval; //find max value in band range
=======
      for(int i = 0; i < spectrum.Length; i++){
          HeightController hc = stapel_array[i].GetComponent<HeightController>();
            hc.SetMinMax(stapel_array[i].transform.position.y, spectrum[i] * 10, 0.1f);
>>>>>>> Stashed changes
      }
    }
}
