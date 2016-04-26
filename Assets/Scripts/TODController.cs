using UnityEngine;
using System.Collections;

public class TODController : MonoBehaviour {
    public float StartTime;
    public float EndTime;
    public float DayLength; // in minutes
    
    public float slider;
    public float slider2;
    public float Hour;
    public Light Sun;
    public float Speed = 50;

    public Color NightFogColor;
    public Color DuskFogColor;
    public Color MorningFogColor;
    public Color MiddayFogColor;

    public Color NightAmbientLight;
    public Color DuskAmbientLight;
    public Color MorningAmbientLight;
    public Color MiddayAmbientLight;

    public Color NightTint;
    public Color DuskTint;
    public Color MorningTint;
    public Color MiddayTint;

    public Material SkyBoxMaterial1;
    public Material SkyBoxMaterial2;

    public Color SunNight;
    public Color SunDay;

    public GameObject Water;
    public bool IncludeWater = false;
    public Color WaterNight;
    public Color WaterDay;

    private float _tod; // the actial time of day value
    private float _cycleStartTime;
    private float _cycleStopTime;
    private const int _numHoursInDay = 24;
    private const int _numSecondsInDay = 86400;
    
	// Use this for initialization
	void Start () {
	    //set the tod to the StartTime
        _tod = StartTime;
	}
	
	// Update is called once per frame
	void Update () {

        // figure out slider value
        slider = Hour / (EndTime - StartTime);

        Hour = slider * _numHoursInDay;
        _tod = slider2 * _numHoursInDay;

        Sun.transform.localEulerAngles = new Vector3((slider * 360f) - 90f, 0, 0);
        slider = slider + Time.deltaTime / Speed;
        Sun.color = Color.Lerp(SunNight, SunDay, slider * 2f);

        if (IncludeWater)
        {
            Water.GetComponent<Renderer>().material.SetColor("_horizonColor", Color.Lerp(WaterNight, WaterDay, slider2 * 2f - 0.2f));
        }

        if (slider < 0.5f)
        {
            slider2 = slider;
        }
        if (slider > 0.5f)
        {
            slider2 = (1 - slider);
        }
        Sun.intensity = (slider2 - 0.2f) * 1.7f;

        if (_tod < 4)
        {
            //it is Night
            RenderSettings.skybox = SkyBoxMaterial1;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            SkyBoxMaterial1.SetColor("_Tint", NightTint);
            RenderSettings.ambientLight = NightAmbientLight;
            RenderSettings.fogColor = NightFogColor;
        }
        if (_tod > 4 && _tod < 6)
        {
            RenderSettings.skybox = SkyBoxMaterial1;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            RenderSettings.skybox.SetFloat("_Blend", (_tod / 2) - 2);
            SkyBoxMaterial1.SetColor("_Tint", Color.Lerp(NightTint, DuskTint, (_tod / 2) - 2));
            RenderSettings.ambientLight = Color.Lerp(NightAmbientLight, DuskAmbientLight, (_tod / 2) - 2);
            RenderSettings.fogColor = Color.Lerp(NightFogColor, DuskFogColor, (_tod / 2) - 2);
            //it is Dusk

        }
        if (_tod > 6 && _tod < 8)
        {
            RenderSettings.skybox = SkyBoxMaterial2;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            RenderSettings.skybox.SetFloat("_Blend", (_tod / 2) - 3);
            SkyBoxMaterial2.SetColor("_Tint", Color.Lerp(DuskTint, MorningTint, (_tod / 2) - 3));
            RenderSettings.ambientLight = Color.Lerp(DuskAmbientLight, MorningAmbientLight, (_tod / 2) - 3);
            RenderSettings.fogColor = Color.Lerp(DuskFogColor, MorningFogColor, (_tod / 2) - 3);
            //it is Morning

        }
        if (_tod > 8 && _tod < 10)
        {
            RenderSettings.ambientLight = MiddayAmbientLight;
            RenderSettings.skybox = SkyBoxMaterial2;
            RenderSettings.skybox.SetFloat("_Blend", 1);
            SkyBoxMaterial2.SetColor("_Tint", Color.Lerp(MorningTint, MiddayTint, (_tod / 2) - 4));
            RenderSettings.ambientLight = Color.Lerp(MorningAmbientLight, MiddayAmbientLight, (_tod / 2) - 4);
            RenderSettings.fogColor = Color.Lerp(MorningFogColor, MiddayFogColor, (_tod / 2) - 4);

            //it is getting Midday

        }
	}
}
