using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarkerOnClick : MonoBehaviour
{

    public static MarkerOnClick instance;
    public static WorldInfo.Data lastSelected = new WorldInfo.Data("", "", 0, 0, 0);

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _temperature;

    public float deltaTempPerYear;

    public float value;

    private void Awake()
    {
        instance = this;
        lastSelected = WorldInfo.publicData[0];
    }

    public void Process(WorldInfo.Data d)
    {
        lastSelected = d;
        Debug.Log(d.temperature);
        _name.text = d.city + ", " + d.country;
        _temperature.text = d.temperature + "° C";


        for (int i = 0; i < WorldInfo.publicData.Length; i++)
        {
            var data = WorldInfo.publicData[i];
            data.temperature = data.baseTemperature + value * deltaTempPerYear;
            Debug.Log(data.temperature);

            if (data.city == MarkerOnClick.lastSelected.city)
            {
                _name.text = data.city + ", " + data.country;
                _temperature.text = data.temperature + "° C";
            }
        }
    }
}
