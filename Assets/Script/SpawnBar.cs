using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.IO;

public class SpawnBar : MonoBehaviour
{
    public GameObject currentBar;
    public BaseBar[] Bar;
    public GameObject nevMeshObject;
    public float maxDistance;

    //CondfigFile
    public string ConfFileName = "ConfigData.csv";
    Dictionary<string, Bar> Bars = new Dictionary<string, Bar>();

    private void Awake() {
        ReadData();
    }
    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }
    void AssignData(string values)
        {
            string[] data = values.Split(',');
            float no = int.Parse(data[0]);
            string BarName = data[1];
            float speed = float.Parse(data[2]);
            int score = int.Parse(data[3]);
            Bar bar = new Bar(speed, score);
            Bars.Add(BarName, bar);
        }

    // Start is called before the first frame update
    void Start()
    {
        spawnNewBar();
    }

    // Update is called once per frame
    void Update()
    {
        currentBar = GameObject.FindGameObjectWithTag("Bar");

        if(currentBar == null){
            spawnNewBar();
        }
    }

    public Vector3 GetRandomPoint(Vector3 center, float maxDistance) {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = UnityEngine.Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;

    }

    void spawnNewBar(){
        int randomBar = UnityEngine.Random.Range(0,Bar.Length);

        string className = Bar[randomBar].GetType().Name;
            float speed = 3.5f;
            int score = 0;
            Bar BarData = new Bar(speed,score);
            switch(className){
                case "GoldBar" :
                    BarData = Bars["GoldBar"];
                    break;
                case "GreenBar" :
                    BarData = Bars["GreenBar"];
                    break;
                case "RedBar" :
                    BarData = Bars["RedBar"];
                    break;
                default:
                    break;
            }

            Bar[randomBar].speed = BarData.Speed;
            Bar[randomBar].score = BarData.Score;

        Instantiate(Bar[randomBar],GetRandomPoint(nevMeshObject.transform.position,maxDistance),Bar[randomBar].transform.rotation);
    }
}
