using UnityEngine;
using System.Collections.Generic;

public static class FactionController {
	public static readonly Dictionary<FactionColor, Color> toRGB = new Dictionary<FactionColor, Color>() {
		{ FactionColor.Blue, new Color(0.2039f, 0.5960f, 0.8588f)},
		{ FactionColor.Red, new Color(0.9058f, 0.2980f, 0.2353f)},
		{ FactionColor.Purple, new Color(0.6078f, 0.3490f, 0.7137f)}
	};

	public enum FactionColor {
		Unknown,
		Blue,
		Red,
		Purple
	}

	public static bool Damages(FactionColor source, FactionColor target){
		if( source != target){
			return true;
		}
		return false;
	}
}
