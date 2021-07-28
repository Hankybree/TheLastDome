using System;
using TMPro;
using UnityEngine;

public class Dome : MonoBehaviour
{
    [Header("Environment")]
    [SerializeField] double temperature = 30;
    [SerializeField] double oxygen = 30;
    private int numberOfTrees = 0;

    [Header("Reduce values")]
    [SerializeField] double tempReduction = 0.01;
    [SerializeField] double oxygenReduction = 0.01;

    [Header("UI Elements")]
    [SerializeField] GameObject tempLabel;
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
        }
    }
    public int NumberOfTrees
    {
        get
        {
            return numberOfTrees;
        }
        set
        {
            numberOfTrees = value;
            nrOfTreesLabel.GetComponent<TextMeshProUGUI>().text = "Trees: " + numberOfTrees;
        }
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
        Debug.Log(oxygenReduction);
        // TODO: Calculate reduction based on number of trees and amount of furnace uses
    }
}
