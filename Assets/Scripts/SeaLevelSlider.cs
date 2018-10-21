using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeaLevelSlider : MonoBehaviour
{

    [SerializeField] private GameObject _land;
    [SerializeField] private TextMeshProUGUI _yearLabel;
    [SerializeField] private TextMeshProUGUI _seaLevelLabel;
    [SerializeField] private Gradient _gradient;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _temperature;
    public float mmIncrease = 3.2f;
    public float minYearLevel = 1800;
    public float maxYearLevel = 2100;
    public float minSeaLevel = 0.5f;
    public float maxSeaLevel = 0.9f;
    public float deltaTempPerYear = 0.2f;

    private Material _landMat;

    // Use this for initialization
    void Start()
    {
        _landMat = _land.GetComponent<MeshRenderer>().material;
    }

    public void UpdateSeaLevel(float value)
    {
        var conv = (maxSeaLevel - minSeaLevel) / (maxYearLevel - minYearLevel - 1);
        _landMat.SetFloat("_Cutoff", value * conv + minSeaLevel);

        _yearLabel.text = (minYearLevel - 1 + value).ToString();
        _seaLevelLabel.text = ((value - 1) * mmIncrease) + "mm";

        _seaLevelLabel.color = _gradient.Evaluate(value / (maxYearLevel - minYearLevel - 1));

        MarkerOnClick.instance.deltaTempPerYear = deltaTempPerYear;
        MarkerOnClick.instance.value = value;


        for (int i = 0; i < WorldInfo.publicData.Length; i++)
        {
            var data = WorldInfo.publicData[i];
            data.temperature = data.baseTemperature + value * deltaTempPerYear;
            Debug.Log(data.temperature);

            if (data.city == MarkerOnClick.lastSelected.city)
            {
                var d = data;
                _name.text = d.city + ", " + d.country;
                _temperature.text = d.temperature + "° C";
                _temperature.color = _gradient.Evaluate(value / (maxYearLevel - minYearLevel - 1));
            }
        }
    }
}
