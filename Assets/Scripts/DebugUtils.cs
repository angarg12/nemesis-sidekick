using System;

public class DebugUtils {
	public static void Assert(bool condition) {
		if (!condition) {
			throw new Exception ();
		}
	}

	public static void Assert(bool condition, String message) {
		if (!condition) {
			throw new Exception (message);
		}
	}
}