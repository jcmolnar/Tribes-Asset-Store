ItemData Clip
{
	description = "Clip";
	showInventory = false;
};

function Clip::onDrop(%player,%item)
{
}

function Clip::onUse(%player,%item)
{
	%client = Player::getclient(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	%clip = $Clip[%weapon];
	if(%weapon != "") {
		if(Player::getItemCount(%player,%weapon) != 0) {
			if(%Clip != "") {
				if(Player::getItemCount(%player, %Clip) > 0)
					schedule("Reload("@%player@","@%weapon@",$ClipTime["@%weapon@"] - " @ %player.stimpack+0 @ ");",0.2,%player);
				else
					bottomprint(%client,"<jc><f0>Out of Clips!!!", 2,CLIP);
			}
		}
	}
}



function Reload(%player,%weapon,%RDPer)
{
	%client = Player::getclient(%player);
	%client.isreloading = true;
	
	//schedule("GameBase::playSound("@%player@",SoundPickupItem,"@0@");",%RDPer*2/3,%player);
	//schedule("GameBase::playSound("@%player@",SoundMGLoad,"@0@");",%RDPer*1/3,%player);
	//schedule("Player::setItemCount("@%player@"," @%weapon.imageType.ammoType@"," @$ClipSize[%weapon]@");",%RDPer);
	if(%weapon == yDP) 
		{
		player::unmountitem(%player, 4);
		//schedule("if(!player::isdead(" @ %player @ ")) player::mountitem(" @ %player @ ",yDP5,4);", %RDper);
		}
	else if(%weapon == yPPSh) 
		{
		player::unmountitem(%player, 6);
		//schedule("if(!player::isdead(" @ %player @ ")) player::mountitem(" @ %player @ ",yppsh3,6);", %RDper);
		}
	else if(%weapon == yLanchester) 
		{
		player::unmountitem(%player, 5);
		player::unmountitem(%player, 6);
		//schedule("if(!player::isdead(" @ %player @ ")) player::mountitem(" @ %player @ ",ylanchester3,5);", %RDper);
		//schedule("if(!player::isdead(" @ %player @ ")) player::mountitem(" @ %player @ ",ylanchester4,6);", %RDper);
		}
	ReloadProgress(%client,0, %rdper, %weapon);
	
	
}

function ReloadProgress(%client,%time, %orgtime,%weapon)
{
	%player = client::getownedobject(%client);
	if(player::getmounteditem(%client, 0) != %weapon) { bottomprint(%client, "<jc><f2>Reload canceled! ",0.5,CLIP); return; }
	if(player::isdead(%client)) { %client.isreloading = false; return; }
	if(%time < %orgtime) {
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%"@floor((%time/%orgtime)*100),0.5,CLIP);
		schedule("ReloadProgress("@%client@","@%time+0.1@","@%orgtime@"," @ %weapon @ ");",0.1);
	}
	else {
		bottomprint(%client,"<jc><f0>Reloading... <jc><f2>%100",1,CLIP);
		player::setitemcount(%client, %weapon.imageType.ammotype, $clipsize[%weapon]);
	if(%weapon == yDP) 
		{
		
		player::mountitem(%player,yDP5,4);
		}
	else if(%weapon == yPPSh) 
		{
		
		player::mountitem(%player,yppsh3,6);
		}
	else if(%weapon == yLanchester) 
		{
		
		player::mountitem(%player,ylanchester3,5);
		player::mountitem(%player,ylanchester4,6);
		}
		%client.isreloading = false;  
		Player::decItemCount(%client, $Clip[%weapon]);
		}
}



ItemData PriWeapClip
{
        description = "Weapon clips";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "yClips";
        shadowdetailmask = 4;
        price = 30;
};

ItemData SecWeapClip
{
        description = "Pistol clips";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "yClips";
        shadowdetailmask = 4;
        price = 30;
};

$Clip[ybazooka] = PriWeapClip;
$ClipSize[ybazooka] = 1;
$ClipTime[ybazooka] = 3;


$Clip[yppsh] = PriWeapClip;
$ClipSize[yppsh] = 71;
$ClipTime[yppsh] = 2.1;



$Clip[ysniperrifle] = PriWeapClip;
$ClipSize[ysniperrifle] = 1;
$ClipTime[ysniperrifle] = 1.8;



$Clip[xSTG] = PriWeapClip;
$ClipSize[xSTG] = 30;
$ClipTime[xSTG] = 2.1;


$Clip[xar] = PriWeapClip;
$ClipSize[xar] = 31;
$ClipTime[xar] = 2;



$Clip[xPanzergun] = PriWeapClip;
$ClipSize[xpanzergun] = 1;
$ClipTime[xpanzergun] = 2.8;



$Clip[ysubmgun] = PriWeapClip;
$ClipSize[ysubmgun] = 31;
$ClipTime[ysubmgun] = 2;


$Clip[xMp40] = PriWeapClip;
$ClipSize[xMP40] = 31;
$ClipTime[xMP40] = 1.8;


$Clip[ybren] = PriWeapClip;
$ClipSize[ybren] = 30;
$ClipTime[ybren] = 2.3;



$Clip[xrifle] = PriWeapClip;
$ClipSize[xrifle] = 1;
$ClipTime[xrifle] = 1.5;


$Clip[ybar] = PriWeapClip;
$ClipSize[ybar] = 20;
$ClipTime[ybar] = 1.85;


$Clip[ythompson] = PriWeapClip;
$ClipSize[ythompson] = 30;
$ClipTime[ythompson] = 2.15;


$Clip[ycarbine] = PriWeapClip;
$ClipSize[ycarbine] = 15;
$ClipTime[ycarbine] = 1.4;



$Clip[ymosinnagant] = PriWeapClip;
$ClipSize[ymosinnagant] = 1;
$ClipTime[ymosinnagant] = 1;



$Clip[ySten] = PriWeapClip;
$ClipSize[ysten] = 32;
$ClipTime[ysten] = 1.8;



$Clip[ygarand] = PriWeapClip;
$ClipSize[ygarand] = 9;
$ClipTime[ygarand] = 1.3;



$Clip[yDP] = PriWeapClip;
$ClipSize[yDP] = 47;
$ClipTime[yDP] = 3;



$Clip[yM3] = PriWeapClip;
$ClipSize[yM3] = 30;
$ClipTime[yM3] = 2.5;

$Clip[xShotgun] = PriWeapClip;
$ClipSize[xShotgun] = 5;
$ClipTime[xShotgun] = 2.5;


$Clip[ylanchester] = PriWeapClip;
$ClipSize[ylanchester] = 50;
$ClipTime[ylanchester] = 3.4;



$Clip[yPTRD] = PriWeapClip;
$ClipSize[yPTRD] = 1;
$ClipTime[yPTRD] = 2.5;



$Clip[yPIAT] = PriWeapClip;
$ClipSize[yPIAT] = 1;
$ClipTime[yPIAT] = 3;


$Clip[ypistol] = SecWeapClip;
$ClipSize[ypistol] = 12;
$ClipTime[ypistol] = 1;


$Clip[xpistol] = SecWeapClip;
$ClipSize[xpistol] = 9;
$ClipTime[xpistol] = 1.1;
$numclips[ypistol] = 3;
$numclips[xpistol] = 3;




$Clip[xNambu] = secWeapClip;
$ClipSize[xNambu] = 8;
$ClipTime[xNambu] = 1.0;

$numclips[xNambu] = 3;






$Clip[xRocket] = PriWeapClip;
$ClipSize[xRocket] = 1;
$ClipTime[xRocket] = 3;


$Clip[xType100] = PriWeapClip;
$ClipSize[xType100] = 31;
$ClipTime[xType100] = 2.3;



$Clip[xType96] = PriWeapClip;
$ClipSize[xType96] = 31;
$ClipTime[xType96] = 2.1;


$Clip[xType97] = PriWeapClip;
$ClipSize[xType97] = 5;
$ClipTime[xType97] = 4.3;

$Clip[xType96] = PriWeapClip;
$ClipSize[xType96] = 31;
$ClipTime[xType96] = 2.1;


$Clip[xRifleJ] = PriWeapClip;
$ClipSize[xRifleJ] = 1;
$ClipTime[xRifleJ] = 1.0;




$Clip[xRifleJe] = PriWeapClip;
$ClipSize[xRifleJe] = 5;
$ClipTime[xRifleJe] = 1.8;

//------------------------------------------------------------
function WWII::PlayerResupply(%pl)
{
if(Player::isDead(%pl)) return;
%cl = Player::GetClient(%pl);
%team = gamebase::getteam(%pl);
//if(!%cl.spawnclass || %cl.spawnclass == "") %cl.spawnclass = "assault";
%DL = gamebase::getdamagelevel(%pl);
if(%DL < 0.1) Gamebase::setDamagelevel(%pl, 0);
else Gamebase::setDamageLevel(%pl, %DL-0.15);
if(%pl.equipment == "" && %cl.spawnclass == "") return;
%equipment = %pl.equipment;
if(%equipment == "") %equipment = %cl.spawnclass;
%primaryweap = $weapon[%equipment, $country[%team]];
if(%primaryweap != "") 
	{
	%count = Player::GetItemCount(%pl, $Clip[%primaryweap]);
	if(%count < $numClips[%primaryweap]) Player::IncItemCount(%pl, $Clip[%primaryweap]);
	}
if(%equipment == "medic") player::setitemcount(%pl, medicalkitammo, 120);
if(%team == 0 && Player::GetItemCount(%pl, $clip[ypistol]) < $NumClips[ypistol]) Player::IncItemCount(%pl, $clip[ypistol]); 
else if(%team == 1 && Player::GetItemCount(%pl, $clip[xpistol]) < $NumClips[xpistol]) Player::IncItemCount(%pl, $clip[xpistol]);
if(%equipment != "engineer" && Player::GetItemCount(%pl, nadeammo) < 3) Player::IncItemCount(%pl, nadeammo);
else if(player::getitemcount(%pl, exppackammo) < 4) player::incitemcount(%pl, exppackammo);
if(%equipment == "engineer") if(Player::GetItemCount(%pl, deploymineammo) < 5) Player::IncItemCount(%pl, deploymineammo);
	
}	