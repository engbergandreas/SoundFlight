using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour
{
   int downSpeed = 20, upSpeed = 5;


    int interpolationFramesCount = 20; // number of frames to complete interpolation
    int elapsedFrames = 0;

    Vector3 minSize, maxSize;
    bool lerpMinToMax = true;

    public void SetMinMax(float min, float max, float sizeXZ)  {
        if (elapsedFrames == 0)
        {
            minSize = new Vector3(sizeXZ, min, sizeXZ);
            maxSize = new Vector3(sizeXZ, max, sizeXZ);
            lerpMinToMax = !lerpMinToMax;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 interpolatedSize = lerpMinToMax ? Vector3.Lerp(minSize, maxSize, interpolationRatio ) :
            Vector3.Lerp(maxSize, minSize, interpolationRatio); //lerp from min to max and then max to min 
        
        
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1); //reset elapsedFrames to 0 when it reaches framescount + 1
        interpolationFramesCount = lerpMinToMax ? upSpeed : downSpeed; //set speed depending on going up or down

        transform.localScale = interpolatedSize;
        transform.position = new Vector3(transform.position.x, interpolatedSize.y /2, transform.position.z);
    }
}
