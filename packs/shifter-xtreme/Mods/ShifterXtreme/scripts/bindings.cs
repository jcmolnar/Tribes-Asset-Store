//==== Shifter Key Bindings
//
// The client can add the folling commands to thier autoexec.cs file
// This will allow them to make varrious Weapon Opts 
//
// bindCommand(keyboard, make, i, to, "remoteEval(2048, weapon_plastic_plas2);");
//
//==== Contains Options For
//
//	Plastique
//	Eng Mines
//	Eng Beacons
//	Mortar
//	Rocket
//	Plasma
//	Grav Gun
//
//==== Here are the actual weapon options them selves, duplicated here from the admin.cs file.


//=================================================================================================== Save Info4
function remotesaveinfo(%clientId)
{
	SaveCharacter(%clientId);
	return;
}

//=================================================================================================== Plastique
function remoteweapon_plastic_plas2(%clientId)
{
	%clientId.Plastic = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 2 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas5(%clientId)
{
	%clientId.Plastic = 5;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 5 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas10(%clientId)
{
	%clientId.Plastic = 10;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 10 Sec.\", 3);", 0);
	return;
}
function remoteweapon_plastic_plas15(%clientId)
{
	%clientId.Plastic = 15;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Plastique Delay Set To 15 Sec.\", 3);", 0);
	return;
}
//=================================================================================================== Eng Mines 
function remoteweapon_engmine_proxy(%clientId)
{
	%clientId.EngMine = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0);
	return;
}

function remoteweapon_engmine_cloak(%clientId)
{
	%clientId.EngMine = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_laser(%clientId)
{
	%clientId.EngMine = "2";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_stand(%clientId)
{
	%clientId.EngMine = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0);
	return;
}
function remoteweapon_engmine_replica(%clientId)
{
	%clientId.EngMine = "4";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0);
	return;
}

//==================================================================================== Engineer Beacons
function remoteweapon_engbeacon_standard(%clientId)
{
	%clientId.EngBeacon = "0";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0);
	return;
}
function remoteweapon_engbeacon_camera(%clientId)
{
	%clientId.EngBeacon = "1";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0);
	return;
}
function remoteweapon_engbeacon_antimissile(%clientId)
{
	%clientId.EngBeacon = "2";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0);
	return;
}
function remoteweapon_engbeacon_medikit(%clientId)
{
	%clientId.EngBeacon = "3";
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0);
	return;
}
//======================================================================== Mortar Options
function remoteweapon_mortar_regular(%clientId)
{
	%clientId.Mortar = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0);
	return;
}
function remoteweapon_mortar_emp(%clientId)
{
	%clientId.Mortar = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0);
	return;
}
function remoteweapon_mortar_frag(%clientId)
{
	%clientId.Mortar = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0);
	return;
}	
function remoteweapon_mortar_mdm(%clientId)
{
	%clientId.Mortar = 3;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0);
	return;
}	

//================================================================ Rocket Options
function remoteweapon_rocket1(%clientId)
{
	%clientId.rocket = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Renegades Rocket Initiated.\", 3);", 0);
	return;
}
function remoteweapon_rocket2(%clientId)
{
	%clientId.rocket = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0);
	return;
}
function remoteweapon_rocket3(%clientId)
{
	%clientId.rocket = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Lock Jaw Initiated.\", 3);", 0);
	return;
}
//========================================================================= Plasma Options
function remoteweapon_plasma_regular(%clientId)
{
	%clientId.Plasma = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0);
	return;
}
function remoteweapon_plasma_rapid(%clientId)
{
	%clientId.Plasma = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0);
	return;
}
function remoteweapon_plasma_multi(%clientId)
{
	%clientId.Plasma = 2;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
	return;
}

//======================================================================= Grav Gun Options
function remoteweapon_gravgun_tract(%clientId)
{
	%clientId.gravbolt = 0;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
	return;
}
function remoteweapon_gravgun_repulse(%clientId)
{
	%clientId.gravbolt = 1;
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
	return;
}

//====================================================================================== Eng-Gun Options
function remoteweapon_eng_repair(%clientId)
{
	if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 0;		
		Player::setItemCount(%clientId, Fixit , 1);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::mountItem(%clientId, Fixit, $WeaponSlot);		
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0);
	}
	else
	{		
		if (Player::getItemCount(%clientId, FixIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
	}

	return;
}

function remoteweapon_eng_hack(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::setItemCount(%clientId, Hackit, 1);
		Player::mountItem(%clientId, HackIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0);
	}
	else
	{		
		if (Player::getItemCount(%clientId, HackIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
	}

	return;
}

function remoteweapon_eng_disa(%clientId)
{
	if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, HackIt))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 1);
		Player::mountItem(%clientId, DisIt, $WeaponSlot);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0);
	}
	else
	{		
		if (Player::getItemCount(%clientId, DisIt))
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0);
		else			
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
	}

	return;
}

function remoteclear_telepoint(%clientId)
{
	%player = client::getownedobject(%clientId);
	%obj = newObject("","Mine","EMPBlast");
	Client::setOwnedObject(%clientId, %obj);
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 1.5";
	%pos = Vector::add(GameBase::getPosition(%clientId.telepoint), %padd);
	GameBase::setPosition(%obj, %pos);
	Client::setOwnedObject(%clientId, %player);
	%clientId.telepoint = "false";
	return;
}