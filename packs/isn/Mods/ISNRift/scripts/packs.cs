//=========================================================================================================================================
// Packs.cs
//=========================================================================================================================================

$InvList[FlightPack] = 1;
$InvList[ScoutPack] = 1;
$InvList[Cloak] = 1;
$InvList[Warppack] = 1;

$RemoteInvList[FlightPack] = 1;
$RemoteInvList[ScoutPack] = 1;
$RemoteInvList[Cloak] = 1;
$RemoteInvList[Warppack] = 1;

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Psionic Cloak
//
//  
//  Created by <[DC]>Paladin edited by (TF)Ryath
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

ItemImageData CloakImage 
{
  shapeFile = "sensor_small";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = -1;
  maxEnergy = -2;
  sfxFire = SoundJammerOn;
  mountOffset = { 0, -0.05, 0 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData Cloak 
{
  description = "Conceal";
  shapeFile = "sensorjampack";
  className = "Backpack";
  heading = cBackpacks;
  shadowDetailMask = 4;
  imageType = CloakImage;
  price = 15;
  hudIcon = "sensorjamerpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function CloakImage::onActivate(%player,%imageSlot) 
{
  GameBase::startFadeout(%player);
  Client::sendMessage(Player::getClient(%player),0,"Chameleon Skin Forming");
  %rate = Player::getSensorSupression(%player) + 5;
  Player::setSensorSupression(%player,%rate);
  %player.guiLock = true;
  %c = Player::getClient(%player);
  %c.guiLock = true;
  %clientId.ghostDoneFlag = true;
  startGhosting(%cl);
}

function CloakImage::onDeactivate(%player,%imageSlot) 
{
  GameBase::startFadein(%player);
  Client::sendMessage(Player::getClient(%player),0,"Chameleon Skin Deforming");
  %rate = Player::getSensorSupression(%player) - 5;
  Player::setSensorSupression(%player,%rate);
  Player::trigger(%player,$BackpackSlot,false);
  %player.guiLock = "";
  %c = Player::getClient(%player);
  %c.guiLock = "";
}

function Cloak::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "This power is used like a backpack, but is far superior to other forms of \"cloaking\", due to the length it lasts.");
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Warp Pack
//
//  
//  Created by (TF)SlayerMonk
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$ItemPopTime = 30;
$WarpSafeTime = 8;
$WarpRange = 350;
$WarpChance = 65;

ItemImageData WarpxpackImage
{
        shapeFile = "shield";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 10;
        maxEnergy = 10;
        mountOffset = { 0, -0.05, 0 };
        mountRotation = { 3.14, 0, 0 };
        lightType = 3;
        lightRadius = 10;
        lightTime = 10;
        lightColor = { 0.3, 0.1, 0.6 };
        firstPerson = false;
};

ItemData Warppack
{
        description = "Warp Pack";
        shapeFile = "shield";
        className = "Backpack";
 heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = WarpxpackImage;
        price = 15;
        hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function WarpxpackImage::onActivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        %player = Client::getOwnedObject(%client);
        if (GameBase::getLOSInfo(%player,$WarpRange))
        {
                %dest = $los::position;
                if($WarpTime[%client] > 0)
                {
                        Bottomprint(%client, "<jc><f1>Warning!\n<jc><f0>Warp field not stabilized");
                        if(floor(getrandom() * 100) > $WarpChance)
                        {
                                GameBase::setPosition(%client,"0 0 10000");
                                $WarpWrapTime[%client] = 0.6;
                                $WarpStable[%client] = 0;
                                WarpWrap(%client,%player,%dest);
                                GameBase::setEnergy(%client,0);
                                Player::kill(%client);
                                Client::onKilled(%client,%client);
                                $WarpTime[%client] = 0;
                                WarpxpackImage::onDeactivate(%client,%imageSlot);
                        }
                        else
                        {
                                GameBase::setPosition(%client,"0 0 10000");
                                $WarpWrapTime[%client] = 0.6;
                                $WarpStable[%client] = 1;
                                WarpWrap(%client,%player,%dest);
                                GameBase::setEnergy(%client,0);
                                WarpxpackImage::onDeactivate(%client,%imageSlot);
                        }
                }
                else
                {
                        GameBase::setPosition(%client,"0 0 10000");
                        $WarpWrapTime[%client] = 0.6;
                        $WarpStable[%client] = 2;
                        WarpWrap(%client,%player,%dest);
                        GameBase::setEnergy(%client,0);
                        WarpxpackImage::onDeactivate(%client,%imageSlot);
                        $WarpTime[%client] = $WarpSafeTime;
                        checkSafeWarp(%client,%player);
                }
        }
        else
        {
                Bottomprint(%client, "<jc>Warp position out of range");
                WarpxpackImage::onDeactivate(%client,%imageSlot);
        }
}

function WarpxpackImage::onDeactivate(%player,%imageSlot)
{
        Player::trigger(%player,$BackpackSlot,false);
}

function Warpxpack::onMount(%player,%item)
{
        %client = Player::getClient(%player);
        Bottomprint(%client, "<f1>Warp Pack:<f0> Allows short range teleportation via the users HUD crosshair - but can badly misfunction. ");
}

function checkSafeWarp(%client,%player)
{
        if ($WarpTime[%client] > 0)
        {
                $WarpTime[%client] -= 1;
                schedule("checkSafeWarp(" @ %client @ "," @ %player @ ");",1,%player);
        }
        else
        {
                $WarpTime[%client] = 0;
                Bottomprint(%client, "<jc><f1>Warp field stabilized");
        }
}

function WarpWrap(%client,%player,%dest)
{
        if ($WarpWrapTime[%client] > 0)
        {
                $WarpWrapTime[%client] -= 0.6;
                schedule("WarpWrap(" @ %client @ "," @ %player @ ",\"" @ %dest @ "\");",1,%player);
        }
        else
        {
                $WarpWrapTime[%client] = 0;
                GameBase::setPosition(%client,%dest);
                if ($WarpStable[%client] == 2)
                {
                        Bottomprint(%client, "<jc><f1>Warp Successful!\n<jc><f0>Warp field restabilizing");
                }
                else
                {
                        if ($WarpStable[%client] == 1)
                        {
                                Bottomprint(%client, "<jc><f1>Warp Successful!\n<jc><f0>Warp field still unstable");
                        }
                        else
                        {
                                Bottomprint(%client, "<jc><f1>Warp Unsuccessful!\n<jc><f0>The warp tears you to apart");
                        }
                }
        }
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Scout Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData ScoutPackImage
{
	shapeFile = "mortargun";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0.25 };
	mountRotation = { -1.8, 0, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
//	sfxFire = SoundFireFlierRocket;
};

ItemData ScoutPack
{
	description = "Scout Pack";
	shapeFile = "mortargun";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ScoutPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ScoutPackImage::onActivate(%player,%imageSlot)
{
	if(GameBase::isAtRest(%player) != True) {
		if (GameBase::getEnergy(%player) > 30) {
			ScoutPackImage::Boost(%player);
			GameBase::setEnergy(%player,GameBase::getEnergy(%player)-30);
		}
		else {
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy for afterburners.");
			GameBase::setEnergy(%player,GameBase::getEnergy(%player)/1.5);
		}
}
if(Player::isTriggered(%player,$BackpackSlot))
	 Player::trigger(%player,$BackpackSlot,false);
}


function ScoutPackImage::Boost(%player)
{
	%playerVector=Item::getVelocity(%player);
	%rndCheck=Floor(getRandom()*100);
	if (%rndCheck <=2)
		{ %boostAmount=0.5; %message="They said they fixed it! I trusted them! It's not my fault!"; }
	else if (%rndCheck > 2 && %rndCheck <=5)
		{ %boostAmount=1.0; %message="Damn piece of junk!"; }
	else if (%rndCheck > 10 && %rndCheck < 90)
		{ %boostAmount=2.5; %message="Afterburners!"; }
	else if (%rndCheck >=90 && %rndCheck < 95)
		{ %boostAmount=3; %message="Gawd damn!"; }
	else if (%rndCheck >=95)
		{ %boostAmount=5; %message="You must have a ramjet in your pants!"; }
	else
		{ %boostAmount=2; %message="Boosted."; }
	%boostVector=getWord(%playerVector, 0)*%boostAmount @ " " @ getWord(%playerVector, 1)*%boostAmount @ " " @ getWord(%playerVector, 2)*%boostAmount @ " ";
	Item::setVelocity(%player, %boostVector);
	if(%boostAmount<2) {
		playVoice(Player::getClient(%player),0,"LeftMissionArea");
		playVoice(Player::getClient(%player),"dsgst4");
	}
	else {
		GameBase::playSound(%player, SoundFireFlierRocket,0);
		playVoice(Player::getClient(%player),"cheer2");
	}
	Client::sendMessage(Player::getClient(%player),0,%message);
}

function ScoutPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) + 3.5);
}

function ScoutPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 3.5);
}

//======================================================================== Flight Pack

ItemImageData FlightPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -2;
 	maxEnergy = -6;
	firstPerson = false;
};

ItemData FlightPack
{
	description = "Flight Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FlightPackImage;
	price = 350;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlightPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FlightPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FlightPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}


//======================================================================== 