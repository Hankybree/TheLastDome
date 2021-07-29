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

    private void Start()
    {
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
}
