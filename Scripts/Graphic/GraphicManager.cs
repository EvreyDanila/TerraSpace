using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    public void SetQuality(int id)
    {
        QualitySettings.SetQualityLevel(id);
    }
}
