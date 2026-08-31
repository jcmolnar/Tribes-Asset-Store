//  Set up the 3Space default properties...
//

// 	setMaterialProperty (TYPE,	  FRICTION, ELASTICITY);
// REPACK PORT 2026-08-29: was lowercase "default", which is the switch/case
// RESERVED WORD in this dialect (scan.l) -- the parse aborted here and, because
// CMDConsole::evaluate parses a whole file in ONE CMDparse(), EVERY line below
// was silently discarded. Measured: "tsDefaultMatProps.cs Line: 5 - Syntax error"
// on every -mod TotalAnnihilation boot, and zero of the 15 surface frictions
// registered -- i.e. stock ski/slide physics on ice, snow, sand and mud.
// base\scripts and all 8 other mods here spell it "Default"; only this copy did not.
	setMaterialProperty (Default	 ,  1.0		, 1.0 );
	setMaterialProperty (Concrete	 ,  1.3		, 0.8 );
	setMaterialProperty (Carpet	 ,  2.0		, 0.4 );
	setMaterialProperty (Metal	 ,  0.6		, 1.4 );
	setMaterialProperty (Glass	 ,  0.5		, 1.6 );
	setMaterialProperty (Plastic	 ,  1.0		, 1.0 );
	setMaterialProperty (Wood	 ,  1.3		, 0.75);
	setMaterialProperty (Marble	 ,  1.0		, 1.2 );
	setMaterialProperty (Snow	 ,  0.5		, 0.4 );
	setMaterialProperty (Ice	 ,  0.2		, 1.2 );
	setMaterialProperty (Sand	 ,  2.0		, 0.2 );
	setMaterialProperty (Mud	 ,  1.5		, 0.2 );
	setMaterialProperty (Stone	 ,  1.0		, 1.3 );
	setMaterialProperty (SoftEarth	 ,  1.4		, 0.6 );
	setMaterialProperty (PackedEarth ,  1.0		, 0.9 );

