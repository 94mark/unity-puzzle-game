using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] n;

    int x, y;
    GameObject[,] Square = new GameObject[4, 4];
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void Spawn()
    {
        while(true)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
            if (Square[x, y] == null)
                break;
        }
        //(0,0) 좌표는 (-1.8, -1.8), 한칸씩 이동 시 1.2 만큼 이동
        Square[x, y] = Instantiate(Random.Range(0, 8) > 0 ? n[0] : n[1], new Vector3(1.2f * x - 1.8f, 1.2f * y - 1.8f, 0), Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
