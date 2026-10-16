
//----------------------------------------------------------------------------
//|||||Cool RepairBolt bitmaps:
//*bitmap_name**********description******************************[prefered_Beam_Width]
//-trailadd2.bmp:       nice dark clear blue
//-wes01.bmp:           nice light clear blue
//-zap04.bmp:           really nice thin white (note: make beam thicker if using) [0.2]
//-plasmabolt.bmp:      nice clear glowy thin orange, segmented looking           [0.1]
//-bar15.bmp:           about the same as the above                               [0.1]
//-forcefield.bmp:      really nice light clear blue with light breaks            [Any]
//-fx_lensflare_1.bmp:  cool looking blue disc (gets ugly at large widths)
//-fx_lensflare_3.bmp:  cool looking larger yellow/gold disc
//-fx_lensflare_5.bmp:  cool looking larger white disc
//-leaves.bmp:          cool dark green partially transparent
//-lightningnewsub.bmp: wicked dark red/brown rusty blood looking color           [Any]
//-rsmoke17.bmp:        invisible bitmap... could be useful                       [Any]
//

RepairEffectData RepairBolt
{
	//bitmapName       = "repairadd.bmp";
	bitmapName       = "forcefield.bmp";
	boltLength       = 30.0; //- Duh, the longer the bolt the more divisions needed to keep it round
	segmentDivisions = 5; //- curvaciousness, from 0 to 8 is safe, 0 being a single straight line
	//beamWidth        = 0.125;
	beamWidth        = 0.02; //- Duh, width of each segment

	//updateTime   = 450;
	updateTime   = 100; //- the lower the faster it moves
	//skipPercent  = 0.6;
	skipPercent  = 0.1; //- the lower the more sporadic it moves
	//displaceBias = 0.15;
	displaceBias = 1.0; //- spread distance on bolts

	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Tool";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = true;
	showWeaponBar = true;
	heading	= "cTools";
	hudIcon = "repairpack";
	price = $TerminalCost[RepairGun];
	validateShape = true;
};

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};