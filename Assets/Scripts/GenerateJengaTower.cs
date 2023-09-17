using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJengaTower : MonoBehaviour
{
    public GameObject jengaBlockPrefab;
    public int jengaTowerHeight = 10;
	public float xDistPercentage = 0.5f;
	public float yDistPercentage = 0.4f;

	private GameObject[] blocks;


	public void GenerateTower()
    {
		DeleteCurrentTower();

		blocks = new GameObject[jengaTowerHeight * 3];

		int i = 0;
		for (int y = 0; y < jengaTowerHeight; y++)
		{
			for (int x = -1; x <= 1; x++)
			{
				if (blocks[i] != null) GameObject.Destroy(blocks[i]);
				if ((y & 1) == 0)
					blocks[i] = (GameObject)GameObject.Instantiate(jengaBlockPrefab, new Vector3(x * xDistPercentage, y * yDistPercentage, 0.0f) + this.transform.position, Quaternion.identity, this.transform);
				else
					blocks[i] = (GameObject)GameObject.Instantiate(jengaBlockPrefab, new Vector3(0.0f, y * yDistPercentage, x * xDistPercentage) + this.transform.position, Quaternion.Euler(0.0f, 90.0f, 0.0f), this.transform);

				blocks[i].name = jengaBlockPrefab.name + "(" + (x + 1) + "," + y + ")";
				i++;
			}
		}
	}

	public void DeleteCurrentTower()
    {
		Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 1; i < children.Length; i += 2)
        {
            GameObject.DestroyImmediate(children[i].gameObject);
        }
    }
}
