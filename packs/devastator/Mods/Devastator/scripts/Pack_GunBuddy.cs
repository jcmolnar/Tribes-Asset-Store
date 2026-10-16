$InvList[GunBuddyPack] = 1;
$RemoteInvList[GunBuddyPack] = 1;
$TeamItemMax[GunBuddyPack] = 5;

$ItemMax[larmor, GunBuddyPack] = 0;
$ItemMax[marmor, GunBuddyPack] = 0;
$ItemMax[harmor, GunBuddyPack] = 0;
$ItemMax[qarmor, GunBuddyPack] = 0;
$ItemMax[tarmor, GunBuddyPack] = 0;
$ItemMax[sarmor, GunBuddyPack] = 0;
$ItemMax[srarmor, GunBuddyPack] = 1;
$ItemMax[parmor, GunBuddyPack] = 0;
$ItemMax[psarmor, GunBuddyPack] = 0;
$ItemMax[IceMor, GunBuddyPack] = 1;
$ItemMax[lfemale, GunBuddyPack] = 0;
$ItemMax[mfemale, GunBuddyPack] = 0;
$ItemMax[qarmor, GunBuddyPack] = 0;
$ItemMax[sarmor, GunBuddyPack] = 0;
$ItemMax[srarmor, GunBuddyPack] = 1;
$ItemMax[parmor, GunBuddyPack] = 0;
//----------------------------------------------------------------------------
																			
ItemImageData GunBuddyPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData GunBuddyPack
{
	description = "Gun-Buddy";
	shapeFile = "larmor";
	className = "Backpack";
	heading = "fDeployables";
	imageType = GunBuddyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData TriggerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 0;  
	minEnergy  = 0;
	maxEnergy = 0;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundDryFire;
};

ItemData Trigger
{
	description = "Gun-Buddy Trigger";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = TriggerImage;
	showInventory = false;
	price = 125;
};

function TriggerImage::onFire(%player,%slot)
{
	%AIid = %player.Owns;
	if(!%AIid)
		return;
	%CurWeap = Player::getMountedItem(%AIid,$WeaponSlot);
	%Ammo = $WeaponAmmo[%CurWeap];
	%Rot = GameBase::getRotation(%player);
	%AmmoCount = Player::getItemCount(%AIid,%ammo);
	Gamebase::setRotation(%AIid,%rot);
	echo(%AIid@" told to fire...");
	echo(%Ammo@" "@%AmmoCount);
	Player::trigger(%AIid,$WeaponSlot,true);
	Player::trigger(%AIid,$WeaponSlot,false);
}

function Trigger::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Trigger::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

function GunBuddyPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else if(!%player.Owns)
		Player::deployItem(%player,%item);
	else
		Player::mountItem(%player,Trigger,$WeaponSlot);
}

function GunBuddyPack::onDeploy(%player,%item,%pos)
{
	if(GunBuddyPack::deployShape(%player,%item))
		Player::mountItem(%player,Trigger,$WeaponSlot);
}

function GunBuddyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && $Friends != 1) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%Data = GameBase::getDataName($los::object);
			echo(%obj@", type: "@%Data);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				%LOS = $los::object;
				%num = $TeamItemCount[GameBase::getTeam(%player)@"GunBuddyPack"];
				%AIName = %Name@" ";
				if(Ai::spawn(%AIName,player::getarmor(%player),$los::position,"0 0 0") != "false") {
					%AIid = AI::getId(%AIName);
					%AIid.Owner = %player;
					%player.Owns = %AIid;
					GameBase::setRotation(%AIid,GameBase::getRotation(%client));
					GameBase::setTeam(%AIid,GameBase::getTeam(%player));
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ "GunBuddyPack"]++;
					%CurWeap = Player::getMountedItem(%player,$WeaponSlot);
					Player::setItemCount(%AIid,1,%CurWeap);
					%CurAmmo = $WeaponAmmo[%CurWeap];
					Player::setItemCount(%AIid,500,%CurAmmo);
					Player::mountItem(%AIid,%CurWeap, 4);
					if($Friends)
						return true;
					GameBase::startFadeOut(%player);
					Client::sendMessage(%client,0,"Your Gun-Buddy only has a 20 sec lifespan!");
					%anim = "BlowUp";
					schedule("Player::killOff("@%AIid@","@%AIid@",$Unknown,"@%anim@");",20);
					schedule("GameBase::startFadeIn("@%player@");",20);
					return true;
				}
				else
					Client::sendMessage(%client,0,"Could Not add Gun-Buddy, possibly because you already have one");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on buildings or terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function GunBuddyPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Deploy your Gun-Buddy to confuse enemies when sniping!");
}
