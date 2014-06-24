using UnityEngine;
using System.Collections;

public static class GameController  {

	public static Grid.Type[,] map;
	public static int mapWidth;
	public static int mapHeight;

	public static void setMap(Grid.Type[,] m, int width, int height) {
		map = m;
		mapWidth = width;
		mapHeight = height;
	}
}
