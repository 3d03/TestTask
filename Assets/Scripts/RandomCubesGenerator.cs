using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask { 
public class RandomCubesGenerator : MonoBehaviour {

    public int countOfObstacles;
    public List<int> TakenSnapPoints;
 
	public  void GenerateObstacles () {

        TakenSnapPoints.Clear();
        TakenSnapPoints = new List<int>();
        int randomFreeSnapPoint;

        List<int> indecesOfFreeSnapPoints = new List<int>();
        for (int i = 0; i <  GridBuilder.instance.XRowCount* GridBuilder.instance.ZRowCount; i++)
        {
            indecesOfFreeSnapPoints.Add(i);
        }

        for  (int i=0; i< countOfObstacles;i++)
        {
            randomFreeSnapPoint = UnityEngine.Random.Range(0, indecesOfFreeSnapPoints.Count);
            GameObject someObstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            someObstacle.name = "Obstacle Cube";
            someObstacle.transform.position = GridBuilder.instance.SnapPoints[indecesOfFreeSnapPoints[randomFreeSnapPoint]];
            someObstacle.transform.localScale = new Vector3(GridBuilder.instance.Spacing, GridBuilder.instance.GridLineWidth*2f, GridBuilder.instance.Spacing);
            TakenSnapPoints.Add(indecesOfFreeSnapPoints[randomFreeSnapPoint]);
            indecesOfFreeSnapPoints.RemoveAt(randomFreeSnapPoint);
        }


        foreach (int i in TakenSnapPoints)
        {
            GridBuilder.instance.SnapPoints[i] = new Vector3(1000, 0, 10000);
        }
    }
  }
}
