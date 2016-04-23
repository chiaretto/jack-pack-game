using System;
using UnityEngine;

public static class MetaUtils {
	
	public static float getWidth(GameObject go){
		return go.GetComponent<Renderer>().bounds.size.x * 100;
	}
		
	public static float getHeight(GameObject go){
		return go.GetComponent<Renderer>().bounds.size.y * 100;
	}

	public static float getScreenWidth(){
		return Screen.width / 100;
	}

	public static float getScreenHeight(){
		return Screen.height / 100;
	}
}