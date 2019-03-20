using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public class GridBuilder : MonoBehaviour
    {

        public static GridBuilder instance;

        [Range(2, 100)]
        public int ZRowCount = 2;
        [Range(2, 100)]
        public int XRowCount = 2;
        public float Spacing;
        public float GridLineWidth;
        public Material gridLineMat;
        public List<Vector3> SnapPoints;
        public RandomCubesGenerator randomCubesGenerator;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.Log("Duplicate Singleton GridBuilder instance");
            }
        }

        void Start()
        {
            BuildGrid();
            CalculateSnapPoints();
            randomCubesGenerator.GenerateObstacles();
        }


        void CalculateSnapPoints()
        {
            SnapPoints.Clear();
            SnapPoints = new List<Vector3>(ZRowCount * XRowCount);

            for (int z = 0; z < ZRowCount; z++)
                for (int x = 0; x < XRowCount; x++)
                {
                    SnapPoints.Add(new Vector3(x * Spacing + Spacing / 2f, 0, z * Spacing + Spacing / 2f));
                }
        }

        public void BuildGrid()
        {
            for (int i = 0; i <= ZRowCount; i++)
            {
                GameObject gridLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gridLine.name = "grid line";
                gridLine.GetComponent<Renderer>().sharedMaterial = gridLineMat;
                gridLine.transform.localScale = new Vector3(Spacing * XRowCount, GridLineWidth, GridLineWidth);
                gridLine.transform.position = new Vector3(0, 0, i * Spacing);
                gridLine.transform.Translate(new Vector3(XRowCount * Spacing / 2f, 0, 0));
            }

            for (int j = 0; j <= XRowCount; j++)
            {
                GameObject gridLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gridLine.name = "grid line";
                gridLine.GetComponent<Renderer>().sharedMaterial = gridLineMat;
                gridLine.transform.localScale = new Vector3(Spacing * ZRowCount, GridLineWidth, GridLineWidth);
                gridLine.transform.position = new Vector3(j * Spacing, 0, 0);
                gridLine.transform.Translate(new Vector3(0, 0, ZRowCount * Spacing / 2f));
                gridLine.transform.Rotate(0, 90, 0);
            }
        }
    }
}