using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(15, 100)]
    public int tunnelHeight;

    int[,] map;

    void Start() {
        GenerateMap();
    }

    void GenerateMap() {
        map = new int[width, height];
        RandomFillMap();
    }

    void RandomFillMap() {
        if (useRandomSeed) {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                map[x, y] = (pseudoRandom.Next(0, 100) < tunnelHeight) ? 1: 0;
            }
        }
    }

    void OnDrawGizmos() {
        if(map != null) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    
                }
            }
        }
    }
}
