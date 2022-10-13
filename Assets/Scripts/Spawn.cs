using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject _This;
    [SerializeField] Vector3 SpawnPoint;
    public bool pauseCreate = false;
    public bool pause = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (pauseCreate == true)
        {
            StartCoroutine(CreateCube(ManagerCube.time));
            pauseCreate = false;
        }
    }
    IEnumerator CreateCube(float time)
    {
        var t_cube = Instantiate(cube, SpawnPoint, Quaternion.identity, this.transform);
        this.SendMessage("addCube", t_cube);
        t_cube.SendMessage("UpdSpeed", ManagerCube.speed);


        yield return new WaitForSeconds(time);
        pauseCreate = true;
    }
    public void LaunchCube()
    {
        if (pauseCreate != true)
            pauseCreate = !pauseCreate;
    }
    public void StopCube()
    {
        if (pause == true)
        {
            pause = !pause;
            Time.timeScale = 1;
        }
        else
        {
            pause = !pause;
            Time.timeScale = 0;
        }
    }
    public void DeleteCubeButton()
    {
        this.SendMessage("DeleteCube", 0.1);
    }
}
