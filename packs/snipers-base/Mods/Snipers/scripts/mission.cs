//Extreme Mappers Mod v1.0

//Mission.cs - Loaded during server startup, perfect to get alot of item/staticshape declorations
//in =P

//*sniff sniff* no modder ever wanted to modify this poor script...so there it was all alone
//in the volume...nobody to pay attention to it. No modder ever had a use to modify it...
//but Now it has a hope...the Extreme Mappers Mod to the rescue!

//Mappers Extreme Object Declaration Loader script
//a few of these are from the Shifter mod...thanks Emo & Quikfix!
//(but most of them....by me :)

//===============================================================================================
//===============================================================================================

//=============================================================ForceField
StaticShapeData ExForceField
{
shapeFile = "forcefield";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Force Field";
};

function ForceField::onDamage(){}
//=============================================================3x4 ForceField
StaticShapeData ExForceField1
{
shapeFile = "ForceField_3x4";
debrisId = defaultDebrisSmall;
maxDamage = 36.0;
isTranslucent = true;
description = "Force Field";
};

function ExForceField1::onDamage(){}
//=============================================================4x17ForceField
StaticShapeData ExForceField2
{
shapeFile = "ForceField_4x17";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Force Field";
};

function ExForceField2::onDamage(){}
//=============================================================4x8 ForceField
StaticShapeData ExForceField3
{
shapeFile = "ForceField_4x8";
debrisId = defaultDebrisSmall;
maxDamage = 36.0; isTranslucent = true;
description = "Force Field";
};

function ExForceField3::onDamage(){}
//=============================================================5x5 ForceField
StaticShapeData ExForceField4
{
shapeFile = "ForceField_5x5";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Force Field";
};

function ExForceField4::onDamage(){}
//=============================================================4x14 ForceField
StaticShapeData ExForceField5
{
shapeFile = "ForceField_4x14";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Force Field";
};

function ExForceField5::onDamage(){}
//=============================================================PlasmaWall
StaticShapeData ExPlasmaWall
{
shapeFile = "plasmawall";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "PlasmaWall";
};

function ExPlasmaWall::onDamage(){}
//==============================================================enerpad (TeleportPad)
StaticShapeData ExEnerpad
{
ShapeFile = "enerpad";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Telepad";
};

function ExEnerpad::onDamage(){}
//==============================================================Mainpad (no idea, probaly old model that didn't make it in the mix =P)
StaticShapeData ExMainpad
{
shapeFile = "mainpad";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "MainPad";
};

function ExMainpad::onDamage(){}
//==============================================================Tribeslogo
StaticShapeData ExTribesLogo
{
shapeFile = "logo";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "logo";
};

function ExTribesLogo::onDamage(){}
//==============================================================Bridge (No idea why it's named that)
StaticShapeData ExBridge
{
shapeFile = "bridge";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "Bridge";
};

function ExBridge::onDamage(){}
//==============================================================GunTurret...Not working...just for decoration
StaticShapeData ExGunTurret
{
shapeFile = "GunTuret";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "gunturret";
};

function ExGunTurret::onDamage(){}
//==============================================================Big Satilite
StaticShapeData ExSatBig
{
shapeFile = "sat_big";
debrisId = defaultDebrisSmall;
maxDamage = 10000.0;
isTranslucent = true;
description = "SatBig";
};

function ExSatBig::onDamage(){}
//==============================================================Blinking Lights

ItemData SlowSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.5; lightColor = { 1, 0.5, 0 }; };
ItemData SlowSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 0, 0 }; };
ItemData SlowMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 0, 0 }; }; 
ItemData SlowLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 0, 0 }; }; 
ItemData SlowSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 0, 1 }; }; 
ItemData SlowMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 0, 1 }; }; 
ItemData SlowLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 0, 1 }; };
ItemData SlowSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 0 }; };
ItemData SlowSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 0, 1, 0 }; };
ItemData SlowSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.5; lightColor = { 1, 1, 1 }; };
ItemData SlowLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.5; lightColor = { 1, 1, 1 }; };

//==============================================================fast flares
ItemData FastSmallOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastMedOrange 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastLargeOrange 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 16; lightTime = 0.07; lightColor = { 1, 0.5, 0 }; };
ItemData FastSmallRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 0, 0 }; };
ItemData FastMedRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 0, 0 }; }; 
ItemData FastLargeRed 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 0, 0 }; }; 
ItemData FastSmallBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 0, 1 }; }; 
ItemData FastMedBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 0, 1 }; }; 
ItemData FastLargeBlue 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 0, 1 }; };
ItemData FastSmallYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastMedYellow 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastLargeYellow 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 0 }; };
ItemData FastSmallGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastMedGreen 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastLargeGreen 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 0, 1, 0 }; };
ItemData FastSmallWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 5; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastMedWhite 		{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 10; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
ItemData FastLargeWhite 	{ description = ""; shapeFile = "breath"; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 15; lightTime = 0.07; lightColor = { 1, 1, 1 }; };
//==============================================================================FireBolt
StaticShapeData ExFire
{
ShapeFile = "PlasmaBolt";
maxDamage = 10000.0;
description = "Fire";
disableCollision = false;
isTranslucent = true;
};

function ExFire::onDamage(){}

function ExFire::onCollision(%this, %object)
{
%client = player::getclient(%object);
%level = gamebase::Getdamagelevel(%object);
Player::setDamageFlash(%client, 0.6);
if(%level <= 0.2)
	player::blowup(%object);
gamebase::setDamageLevel(%object, %level+0.2);
}
//==============================================================================¿Twiggy?
StaticShapeData ExTwiggy
{
shapeFile = "mrtwig";
maxDamage = 10000.0;
description = "Twig";
};

function ExTwiggy::onDamage(){}
//==============================================================================Invincible Small Antenna
StaticShapeData ExSuperSmallAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   	description = "Small Antenna";
};

//==============================================================================Invincible Medium Antenna
StaticShapeData ExSuperMediumAntenna
{
	shapeFile = "anten_med";
	debrisId = flashDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
  	description = "Medium Antenna";
};

//==============================================================================Invincible Large Antenna
StaticShapeData ExSuperLargeAntenna
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   	description = "Large Antenna";
};


function ExSuperSmallAntenna::onDamage()
{
}

function ExSuperMediumAntenna::onDamage()
{
}

function ExSuperLargeAntenna::onDamage()
{
}

//=======================================================4x4 platform
StaticShapeData Explatform_4x4 {
shapeFile = "elevator_4x4";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};

function Explatform_4x4::onDamage()
{
}
//=======================================================4x5 platform
StaticShapeData Explatform_4x5 {
shapeFile = "elevator_4x5";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_4x5::onDamage()
{
}
//=======================================================5x5 platform
StaticShapeData Explatform_5x5 {
shapeFile = "elevator_5x5";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_5x5::onDamage()
{
}
//=======================================================6x4 platform
StaticShapeData Explatform_6x4 {
shapeFile = "elevator6x4";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x4::onDamage()
{
}
//=======================================================4x5 thin platform
StaticShapeData Explatform_6x4thin {
shapeFile = "elevator6x4thin";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x4thin::onDamage()
{
}
//=======================================================6x5 platform
StaticShapeData Explatform_6x5 {
shapeFile = "elevator_6x5";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x5::onDamage()
{
}
//=======================================================6x6 thin platform
StaticShapeData Explatform_6x6thin {
shapeFile = "elevator6x6thin";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x6thin::onDamage()
{
}
//=======================================================6x6 platform
StaticShapeData Explatform_6x6 {
shapeFile = "elevator_6x6";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x6::onDamage()
{
}
//=======================================================6x6 octagon platform
StaticShapeData Explatform_6x6octa {
shapeFile = "elevator_6x6_octagon";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_6x6_octagon::onDamage()
{
}
//=======================================================8x4 platform
StaticShapeData Explatform_8x4 {
shapeFile = "elevator_8x4";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_8x4::onDamage()
{
}
//=======================================================8x6 platform
StaticShapeData Explatform_8x6 {
shapeFile = "elevator_8x6";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_8x6::onDamage()
{
}

//=======================================================8x8 platform
StaticShapeData Explatform_8x8 {
shapeFile = "elevator_8x8";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_8x8::onDamage()
{
}

//=======================================================9x9 platform
StaticShapeData Explatform_9x9 {
shapeFile = "elevator_9x9";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_9x9::onDamage()
{
}
//=======================================================16x16 platform
StaticShapeData Explatform_16x16Octa {
shapeFile = "elevator16x16_octo";
maxDamage = 10000.0;
description = "Platform";
disableCollision = false;
isTranslucent = False;
};
function Explatform_16x16octa::onDamage()
{
}

//=======================================================Shockwave
StaticShapeData ExShockwaveM {
shapeFile = "shockwave_large";
maxDamage = 10000.0;
description = "Shockwave";
disableCollision = false;
isTranslucent = False;
};
function ExShockwaveM::onDamage()
{
}

//======================================================LittleCraft
StaticShapeData ExScout
{
ShapeFile = "flyer";
maxDamage = 10000.0;
description = "Scout";
};
function ExScout::onDamage(){}
//======================================================LPC
StaticShapeData ExLPC
{
ShapeFile = "hover_apc_sml";
maxDamage = 10000.0;
description = "Scout";
};
function ExLPC::onDamage(){}
//======================================================HPC
StaticShapeData ExHPC
{
ShapeFile = "hover_apc";
maxDamage = 10000.0;
description = "Scout";
};
function ExHPC::onDamage(){}
//===============================Something that should of been added by dynamix along time ago
function MagCargo::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function LiquidCyl::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);	
}

function PlantOne::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function PlantTwo::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function Cactus1::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function Cactus2::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function Cactus3::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}
//checks for updated file for specific maps with thier own declorations
//all files with updates have to begin with ExtremeUpdate
//Ex: ExtremeUpdate_Mymap.cs

function checkregupdates()
{
%file = File::FindFirst("*.cs");
while(%file != "")
{
      
	%file = File::FindNext("*.cs");
	if(string::getsubstr(%file, 0, 13) == "ExtremeUpdate")
	{
		echo("Executing map register update file");
		exec(%file);
	
	}
}

}
//PORT-OFF: checkregupdates();   (ran every ExtremeUpdate*.cs found anywhere on the search path)

ItemData ExPlasma
{
description = "";
shapeFile = "plasmabolt";
showInventory = false;
shadowDetailMask = 4;
lightType = 2;
lightRadius = 10;
lightTime = 0.05;
lightColor = { 1, 0.5, 0 };
};

function ExPlasma::onCollision(%this, %object)
{
echo(%this @ " " @ %object);
}