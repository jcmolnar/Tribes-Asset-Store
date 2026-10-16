//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

MarkerData DropPointMarker {
	shapeFile = "endarrow";
};
MarkerData PathMarker {
	shapeFile = "dirArrows";
};
MarkerData MapMarker {
	description = "Map Legend";
	visibleToSensor = true;
	mapFilter = 8;
	mapIcon = "M_marker";
	shapeFile = "dirArrows";
};

// new here for teleporters in mod -plasmatic
MarkerData TeleDropMarker {
	shapeFile = "endarrow";
};