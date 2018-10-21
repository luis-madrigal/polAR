using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WorldInfo : MonoBehaviour
{


    [System.Serializable]
    public class Event : UnityEvent<Data> { }

    [System.Serializable]
    public struct Data
    {

        public string country;
        public string city;
        public float latitude;
        public float longitude;
        public float baseTemperature;
        public float temperature;

        public Data(string country, string city, float latitude, float longitude, float baseTemperature)
        {
            this.country = country;
            this.city = city;
            this.latitude = latitude;
            this.longitude = longitude;
            this.baseTemperature = baseTemperature;
            this.temperature = baseTemperature;
        }

        public override string ToString()
        {
            return "{Name:" + country + ",lat:" + latitude + ",long:" + longitude + "}";
        }
    }

    public class Marker : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField] internal WorldInfo basis;
        [SerializeField] internal Data data;

        public void OnPointerClick(PointerEventData eventData)
        {
            basis.onMarkerClick.Invoke(data);
        }

        void Update()
        {
            var pos = Quaternion.AngleAxis(data.longitude, -Vector3.up) * Quaternion.AngleAxis(data.latitude, -Vector3.right) * new Vector3(0, 0, basis.sphereRadius);
            transform.localPosition = pos;
        }
    }

    public GameObject markerPrefab;
    public Transform sphereCenter;
    public float sphereRadius;
    public Data[] places;
    public Event onMarkerClick;

    public static Data[] publicData;
    void Awake()
    {
        publicData = places;
    }
    void Start()
    {
        foreach (var place in places)
        {

            var marker = Instantiate(markerPrefab, Vector3.zero, Quaternion.identity);
            marker.transform.parent = sphereCenter;

            var clickable = marker.GetComponent<Marker>();
            if (!clickable) clickable = marker.AddComponent<Marker>();
            clickable.basis = this;
            clickable.data = place;
        }
    }

}
