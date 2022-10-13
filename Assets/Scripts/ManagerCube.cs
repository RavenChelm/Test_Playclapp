using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManagerCube : MonoBehaviour
{
    [SerializeField] TMP_InputField TimeField;
    [SerializeField] TMP_InputField SpeedField;
    [SerializeField] TMP_InputField DistanceField;
    [SerializeField] TMP_Text TimeText;
    [SerializeField] TMP_Text SpeedText;
    [SerializeField] TMP_Text DistanceText;

    public static bool pause = true;
    public static float time = 1;
    public static float Distance = 100;
    public static float speed = 10;
    public List<GameObject> Cubes = new List<GameObject>();
    public GameObject lastCube;
    IEnumerator DeleteCube(float time)
    {
        yield return new WaitForSeconds(time);
        if (Cubes.Count > 0)
        {
            Destroy(Cubes[0]);
            Cubes.Remove(Cubes[0]);
        }
        pause = true;
    }
    private void addCube(GameObject cub)
    {
        Cubes.Add(cub);
        lastCube = cub;
    }
    public void setTime(string timeFromImput)
    {
        if (isDigitsOnly(timeFromImput))
        {
            time = float.Parse(timeFromImput);
            TimeText.SetText("V");
        }
        else
            TimeText.SetText("X");
    }
    public void setSpeed(string speedFromImput)
    {
        if (isDigitsOnly(speedFromImput))
        {
            speed = float.Parse(speedFromImput);
            SpeedText.SetText("V");
            foreach (var cube in Cubes)
            {
                cube.SendMessage("UpdSpeed", speed);
            }
        }
        else
            SpeedText.SetText("X");
    }
    public void setDistance(string DistanceFromImput)
    {
        if (isDigitsOnly(DistanceFromImput))
        {
            Distance = float.Parse(DistanceFromImput);
            DistanceText.SetText("V");
        }
        else
            DistanceText.SetText("X");
    }
    bool isDigitsOnly(string str)
    {
        if (str == null)
        {
            return false;
        }
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
}
