using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dome : MonoBehaviour
{
    [Header("Environment")]
    [SerializeField] double temperature = 30;
    [SerializeField] double oxygen = 30;
    //private int numberOfTrees = 10;
    [SerializeField] GameObject treeManager;
    private List<GameObject> trees;

    [Header("Reduce values")]
    [SerializeField] double tempReduction = 0.01;
    [SerializeField] double oxygenReduction = 1;
    [SerializeField] float oxygenTicks = 1;

    [Header("UI Elements")]
    [SerializeField] GameObject tempLabel;
    [SerializeField] GameObject oxygenLabel;
    [SerializeField] GameObject nrOfTreesLabel;

    public double Temperature
    {
        get
        {
            return temperature;
        }
        set
        {
            temperature = value;
            tempLabel.GetComponent<TextMeshProUGUI>().text = "Temperature: " + Math.Round(temperature, 1);
        }
    }
    public double Oxygen
    {
        get
        {
            return oxygen;
        }
        set
        {
            oxygen = value;
            oxygenLabel.GetComponent<TextMeshProUGUI>().text = "Oxygen: " + Math.Round(oxygen, 1);
        }
    }

    private void Start()
    {
        InitTreeList();
        InvokeRepeating(nameof(ReduceOxygen), oxygenTicks, oxygenTicks);
    }

    private void Update()
    {
        ReduceTemp();
    }

    private void ReduceTemp()
    {
        Temperature -= tempReduction;
    }

    private void ReduceOxygen()
    {
        Oxygen -= oxygenReduction;
    }

    private void InitTreeList()
    {
        trees = new List<GameObject>();

        foreach (Transform tree in treeManager.transform)
        {
            trees.Add(tree.gameObject);
        }

        nrOfTreesLabel.GetComponent<TextMeshProUGUI>().text = "Trees: " + trees.Count;
    }

    public void PlantTree(GameObject tree, Vector3 position)
    {
        GameObject newTree = Instantiate(tree, position, Quaternion.identity);
        newTree.transform.parent = treeManager.transform;
        trees.Add(newTree);
        nrOfTreesLabel.GetComponent<TextMeshProUGUI>().text = "Trees: " + trees.Count;
    }
}
