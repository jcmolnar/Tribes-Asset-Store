//M-Key setup-------------------------------------
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "force";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	validateShape = true;
   validateMaterials = true;
	className = "HandAmmo";
	showinventory = false;
   showweaponbar = false;
};

function MineAmmo::onUse(%player,%item)
{
player::setitemcount(%player, mineammo, 1);
Mkey::onActivate(%player);	
}

//----------------------------------------------------------------------------
//B-key setup--------------------------------------
ItemData Beacon
{
   description = "Beacon";
   shapeFile = "force";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
   showinventory = false;
   showweaponbar = false;
};

function Beacon::onUse(%player,%item)
{
if(%player < 1) return;
player::setitemcount(%player, beacon, 1);
Bkey::onActivate(%player);
}

//------------------------------------------------------------------------------
//H-key setup---------------------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
   showinventory = false;
   showweaponbar = false;
};

function RepairKit::onUse(%player,%item)
{
if(%player < 1) return;
%clientId = Player::GetClient(%player);
if(player::isAicontrolled(%player)) %clientId = ai::getobject($Ai::IdToName[%clientId]);
if(!%clientId.isreloading) {
%playersweapon = Player::GetMountedItem(%player, $weaponslot);
if(%playerswepaon == xgrifle) return;
if(player::getitemcount(%player, $clip[%playersweapon]) > 0 && player::getitemcount(%player, $ammo[%playersweapon]) < $Clipsize[%playersweapon])
	{
	player::setitemcount(%player, $ammo[%playersweapon], 0);
	%clientId.isreloading = true;
	Player::useitem(%player, $Clip[%playersweapon]);
	}
	
}
}
//----------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//----------------------------------------------------------------------

function Bkey::onActivate(%player)
{

if(player::getmounteditem(%player, $weaponslot) == "Binoculars") Airstrike::onCall(%player);

else if(player::getmounteditem(%player, $weaponslot) == "exppack") {
	player::unmountitem(%player, $weaponslot);
	player::mountitem(%player, detonator, $weaponslot);
	}
else if(player::getmounteditem(%player, $weaponslot) == "detonator")
	{
	player::unmountitem(%player, $weaponslot);
	player::mountitem(%player, exppack, $weaponslot);
	}
}

//-----------------------------------

function Mkey::onActivate(%player)
{
%cl = player::getclient(%player);
if(client::getcontrolobject(%cl) != client::getownedobject(%cl))
	{
	%this = client::getcontrolobject(%cl);
	if(gamebase::getdataname(%this) == "ShermanTank")
		{
		ShermanTank::Aim(%this, -1);
		}
	}

//if(getobjecttype(player::getmountobject(%player)) == "Vehicle") eval(gamebase::getdataname(gamebase::getmountedobject(%player)) @ "::Mkey(" @ %player @ ");");
if(player::getmounteditem(%player, $weaponslot) == "Binoculars") Artillery::setTarget(%player); 
}

//-----------------------------------
function IKey::onUse(%cl)
{
if(client::getcontrolobject(%cl) != client::getownedobject(%cl))
	{
	%this = client::getcontrolobject(%cl);
	if(gamebase::getdataname(%this) == "ShermanTank")
		{
		ShermanTank::Aim(%this, 1);
		}
	}
%pl = client::getownedobject(%cl);
if(!player::isdead(%pl) && %pl > 8000)
	{
	%Set = newObject("set",SimSet);
	%Pos = getboxcenter(%pl);
	%num = containerBoxFillSet(%Set, -1, %Pos, 4.5, 4.5, 4.5,0); 
	if(!(%num > 0)) return;
	for(%x = 0; %x < group::objectcount(%set); %x++)
		{
		%curplayer = group::getobject(%set, %x);
		if(%curplayer != %pl && getobjecttype(%curplayer) == "Player" && player::isdead(%curplayer)) { WWII::StripSoldier(%pl, %curplayer); break; }
		}
	deleteobject(%set);
	}
}





//------------------------------------
//Client Script Functions -Roma

function remoteAdvCMD(%cl, %cmd, %var)
{
if($loadingmission) return;
if(%cmd == UseSlot)
	{
	%spawnclass = %cl.spawnclass;
	%team = GameBase::getteam(%cl);
	%country = $country[%team];
	%player = Client::getownedobject(%cl);
	if(%player.equipment == "") { } else %spawnclass = %player.equipment;
	if(%player.parachute) return;
	if(%spawnclass == "" || %player == -1) return;
		if(%var == 3) { if(player::getitemcount(%player, $weapon[%spawnclass, %country]) > 0) player::mountitem(%player, $weapon[%spawnclass, %country], $weaponslot); else player::mountitem(%player, $weapon[%spawnclass, $country[!%team]], $weaponslot); } 
	else    if(%var == 2) 
			{
			if(player::getitemcount(%player, ypistol)) Player::mountitem(%player, ypistol, $weaponslot); 
			else if(player::getitemcount(%player, xpistol)) player::mountitem(%player, xpistol, $weaponslot);
			}
	else    if(%var == 4) 
			{
			if(%spawnclass != "engineer" && player::getitemcount(%player, nadeammo)) player::mountitem(%player, nade, $weaponslot); 
			else if(%spawnclass == "engineer" && player::getitemcount(%player, exppackammo) >= 0) player::mountitem(%player, exppack, $weaponslot);
			}
	else	if(%var == 5)
			{
			if(%spawnclass == "engineer" && player::getitemcount(%player, deploymineammo)) player::mountitem(%player, deploymine,0); 
			if(%spawnclass == "scout") player::mountitem(%player, binoculars,0);
			else if(%spawnclass == "medic") player::mountitem(%player, medicalkit,0);
			} 
	else	if(%var == 6)
			{
			if(%spawnclass == "scout" && player::getitemcount(%player, nadeammo)) player::mountitem(%player, xgrifle, $weaponslot);
			if(%spawnclass == "engineer" && player::getitemcount(%player, deployboxammo)) player::mountitem(%player, DeployBox, $weaponslot);
			
			}
	}
}