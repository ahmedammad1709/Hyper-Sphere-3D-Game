using UnityEngine;

public class SkyBoxScrippt : MonoBehaviour
{
    public float skyboxSpeed;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*skyboxSpeed);
        
    }
}
