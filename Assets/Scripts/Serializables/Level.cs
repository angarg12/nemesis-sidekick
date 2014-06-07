public class Level {
	public string Name { get; set; }
	public string DisplayName { get; set; }
	// Order in which they will be displayed in the GUI. 
	// This may change if the display method changes (e.g. a map).
	public int Order { get; set; }
	public string Description { get; set; }
	// TODO: Path to the file that actually describes the level (or embedded)
	// The descriptions of the preconditions to unlock this level
	// Anything more that may be needed.
}
