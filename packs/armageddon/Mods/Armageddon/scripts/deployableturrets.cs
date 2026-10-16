
exec("airstrike.cs");

//----------------------------------------------------------------------------
// Ion Turret
//----------------------------------------------------------------------------

ItemImageData DisruptorTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData DisruptorTurretPack
{
        description = "Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = DisruptorTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 2000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DisruptorTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DisruptorTurretPack::onDeploy(%player,%item,%pos)
{
        if (DisruptorTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function DisruptorTurretPack::deployShape(%player,%item)
{        //        Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
        DeployStuff(%player,%item,PlasmaTurret,1,8,1,1,true,false,0);
}



//************************************
//         Mini-Laser Turret
//************************************


ItemImageData AODMiniImage
{        shapeFile        = "CAMERA";
        mountPoint        = 2;
        mass                = 2.0;
        firstPerson = false;
};

ItemData AODMini
{        description                        = "Mini-Laser Turret";
        shapeFile                        = "CAMERA";
        classname                        = "Backpack";
        heading                         = "pTurrets";
        imageType                        = AODMiniImage;
        shadowDetailMask        = 4;
        mass                                = 3.0;
        elasticity                        = 0.2;
        price                                = 325;
        hudIcon                                = "deployable";
        showWeaponBar                = true;
        hiliteOnActive                = true;
};

TurretData MiniTurret
{       classname                        = "Turret";
        shapeFile                        = "CAMERA";

        projectileType                = minilaserbolt;
        maxDamage                        = 0.75;
        maxEnergy                        = 100;
        minGunEnergy                = 7;
        maxGunEnergy                = 7;
        sequenceSound[0]        = {"deploy", SoundActivateMotionSensor};
        reloadDelay                        = 1;
        speed                                = 4.5;
        speedModifier                = 1.5;
        range                                = 200;
        visibleToSensor                = true;
        shadowDetailMask        = 4;
        dopplerVelocity                = 0;
        castLOS                                = true;
        supression                        = false;
        mapFilter                        = 2;
        mapIcon                                = "M_turret";
        debrisId                        = flashDebrisSmall;
        shieldShapeName                = "shield";

       fireSound                        = SoundFireDefender;
        activationSound                = SoundRemoteTurretOn;
        deactivateSound                = SoundRemoteTurretOff;
        explosionId                        = flashExpMedium;
        description                        = "Mini-Laser Turret";
        damageSkinData                = "objectDamageSkins";
        pinger                                = false;
        lightColor                        = { 0.75, 0.75, 0.85 };
};


function AODMini::onUse(%player,%item)
{        %client = Player::getClient(%player);
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);
		
}
        else
        {        Player::deployItem(%player,%item); }
}

function AODMini::onDeploy(%player,%item,%pos)
{        if (AODMini::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);
}
}

function AODMini::deployShape(%player,%item)
{        
		
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",MiniTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"Mini-Laser Turret");
						    GameBase::startFadeIn(%turret);
                                        Client::sendMessage(%client,0,"Mini-Laser Turret deployed");
					Client::setOwnedObject(%client, %turret);
                                        Client::setOwnedObject(%client, %player);
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "AODMini"]++;
                                        echo("MSG: ",%client," deployed a Mini-Laser Turret");
                                        %client.hasDeployed = true;	
						    return true;

}
                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

			 }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


function MiniTurret::onAdd(%this)
{

	schedule("MiniTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,0.0);
	%this.shieldStrength = 0.05;
		if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Mini-Laser Turret");
        }

}

function MiniTurret::onCollision(%this,%object)
{

	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MiniTurret::deploy(%this)
{
	schedule("MiniTurret::deploy(" @ %this @ ");",1,%this);
	schedule("RemoveDLM(" @ %this @ ", " @ data.maxDamage @ ");",30.0,%this);

	GameBase::playSequence(%this,1,"deploy");
}

function RemoveDLM(%this, %damage)
{

	if ($Debug) echo("Removing Laser-Mine");
		GameBase::setDamageLevel(%this, 5.0);

}

function MiniTurret::onEndSequence(%this,%thread)
{

	GameBase::setActive(%this,true);
}

function MiniTurret::onDestroyed(%this)
{

	GameBase::setDamageLevel(%this, %data.maxDamage);
	Turret::onDestroyed(%this);

}

function MiniTurret::onPower(%this,%power,%generator) {
}
function MiniTurret::onEnabled(%this) 
{

	GameBase::setRechargeRate(%this,3);
	GameBase::setActive(%this,true);
}	

//************************************
//         AODDefender Backpack Script
//         (Defender Defense Turret)
//************************************


ItemImageData AODDefenderImage
{        shapeFile        = "CAMERA";
        mountPoint        = 2;
        mass                = 2.0;
        firstPerson = false;
};

ItemData AODDefender
{        description                        = "Defender Designator";
        shapeFile                        = "CAMERA";
        classname                        = "Backpack";
        heading                         = "pTurrets";
        imageType                        = AODDefenderImage;
        shadowDetailMask        = 4;
        mass                                = 3.0;
        elasticity                        = 0.2;
        price                                = 325;
        hudIcon                                = "deployable";
        showWeaponBar                = true;
        hiliteOnActive                = true;
};

TurretData DefenderTurret
{        classname                        = "SensorNet";
        shapeFile                        = "CAMERA";

        projectileType                = designatorX;
        maxDamage                        = 0.75;
        maxEnergy                        = 100;
        minGunEnergy                = 0.1;
        maxGunEnergy                = 1;
        sequenceSound[0]        = {"deploy", SoundActivateMotionSensor};
        reloadDelay                        = 1;
        speed                                = 4.5;
        speedModifier                = 1.5;
        range                                = 200;
        visibleToSensor                = true;
        shadowDetailMask        = 4;
        dopplerVelocity                = 0;
        castLOS                                = true;
        supression                        = false;
        mapFilter                        = 2;
        mapIcon                                = "M_turret";
        debrisId                        = flashDebrisSmall;
        shieldShapeName                = "shield";

       fireSound                        = SoundFireDefender;
        activationSound                = SoundRemoteTurretOn;
        deactivateSound                = SoundRemoteTurretOff;
        explosionId                        = flashExpMedium;
        description                        = "Defender Turret";
        damageSkinData                = "objectDamageSkins";
        pinger                                = false;
        lightColor                        = { 0.75, 0.75, 0.85 };
};


function AODDefender::onUse(%player,%item)
{        %client = Player::getClient(%player);
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);}
        else
        {        Player::deployItem(%player,%item); }
}

function AODDefender::onDeploy(%player,%item,%pos)
{        if (AODDefender::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODDefender::DeployShape(%player, %item)
{
	
	%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",DefenderTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
						GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"Defender Designator");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Defender Designator deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "AODDefender"]++;
                                        echo("MSG: ",%client," deployed a Defender Designator");
                                        %client.hasDeployed = true;	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }
			 }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


        
      


function DefenderTurret::onAdd(%this)
{        schedule("DefenderTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.025;
        if (GameBase::getMapName(%this) == "")
        {        GameBase::setMapName (%this, "Defender Turret");}
}

function DefenderTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function DefenderTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}

function DefenderTurret::onDestroyed(%this)
{        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODDefender"]--;
}

function DefenderTurret::onPower(%this,%power,%generator)
{}

function DefenderTurret::onEnabled(%this)
{        GameBase::setRechargeRate(%this,10);
        GameBase::setActive(%this,true);
}


//----------------------------------------------------------------------------
// Disc Turret
//----------------------------------------------------------------------------

ItemImageData DiscPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData DiscTurretPack
{
       description = "Seeking - Disc Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = DiscPackImage;
        shadowDetailMask = 4;
       mass = 0.5;
        elasticity = 0.2;
        price = 700;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DiscTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DiscTurretPack::onDeploy(%player,%item,%pos)
{
        if (DiscTurretPack::deployShape(%player,%item)) {

               Player::decItemCount(%player,%item);
        }
}

function DiscTurretPack::deployShape(%player,%item)
{        
		
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",DiscTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
							GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"Seeking-Disc Turret");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Seeking-Disc Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "DiscTurretPack"]++;
                                        echo("MSG: ",%client," deployed a Seeking-Disc Turret");
                                        %client.hasDeployed = true;
						    %target = GameBase::getPosition(%turret);
						     return true;

}
                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }
		 }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


TurretData DiscTurret
{
        maxDamage = 4.0;
        maxEnergy = 200;
        minGunEnergy = 50;
        maxGunEnergy = 60;
        reloadDelay = 1.0;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireFlamer;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 150;
        dopplerVelocity = 2;
        castLOS = true;
        supression = false;
	supressable = false;
	pinger = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "chainturret";
        shieldShapeName = "shield_medium";
        speed = 5.0;
        speedModifier = 2.0;
        projectileType = DiscShellTracker;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Seeking-Disc Turret";
};

function DiscTurret::onAdd(%this)
{
        schedule("DiscTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,24);
        %this.shieldStrength = 0.03;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Seeking-Disc Turret");
        }
}

function DiscTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DiscTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DiscTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DiscTurretPack"]--;
}

// Override base class just in case.
function DiscTurret::onPower(%this,%power,%generator) {}
function DiscTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,8);
        GameBase::setActive(%this,true);
}

function DiscTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}



//----------------------------------------------------------------------------
// Seeking-Plasma Turret
//----------------------------------------------------------------------------

ItemImageData SPlasmaImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData SPlasmaPack
{
       description = "Seeking - Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = DiscPackImage;
        shadowDetailMask = 4;
       mass = 0.5;
        elasticity = 0.2;
        price = 700;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function SPlasmaPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function SPlasmaPack::onDeploy(%player,%item,%pos)
{
        if (SPlasmaPack::deployShape(%player,%item)) {

               Player::decItemCount(%player,%item);
        }
}

function SPlasmaPack::deployShape(%player,%item)
{        
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",SPlasmaTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
						GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"Seeking-Plasma Turret");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Seeking-Plasma Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "SPlasmaPack"]++;
                                        echo("MSG: ",%client," deployed a Seeking-Plasma Turret");
                                        %client.hasDeployed = true;
						    %target = GameBase::getPosition(%turret);
						  	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }
			 }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


        
      





TurretData SPlasmaTurret
{
        maxDamage = 4.0;
        maxEnergy = 200;
        minGunEnergy = 50;
        maxGunEnergy = 60;
        reloadDelay = 1.0;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireFlamer;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 200;
        dopplerVelocity = 2;
        castLOS = true;
        supression = false;
	supressable = false;
	pinger = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "chainturret";
        shieldShapeName = "shield_medium";
        speed = 5.0;
        speedModifier = 2.0;
        projectileType = PlasmaShellTracker;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Seeking-Plasma Turret";
};

function SPlasmaTurret::onAdd(%this)
{
        schedule("DiscTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,24);
        %this.shieldStrength = 0.03;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Seeking-Plasma Turret");
        }
}

function SPlasmaTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function SPlasmaTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function SPlasmaTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "SPlasmaPack"]--;
}

// Override base class just in case.
function SPlasmaTurret::onPower(%this,%power,%generator) {}
function SPlasmaTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,8);
        GameBase::setActive(%this,true);
}

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}





//================================
//       Laser Turret
//================================

$InvList[TurretPack]                        = 1;
$RemoteInvList[TurretPack]                = 1;
$TeamItemMax[TurretPack]                = 3;

$ItemMax[larmor, TurretPack]        = 0;
$ItemMax[lfemale, TurretPack]        = 0;
$ItemMax[marmor, TurretPack]        = 1;
$ItemMax[mfemale, TurretPack]        = 1;
$ItemMax[harmor, TurretPack]        = 1;

ItemImageData TurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TurretPack
{
        description = "Laser Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

TurretData LaserTurret
{         classname                = "Turret";
        shapeFile                = "remoteturret";
        projectileType        = sniperlaser;
        maxDamage                = 4.15;
        maxEnergy                = 20;
        minGunEnergy        = 10;
        maxGunEnergy        = 10;
        sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.05;
        speed                        = 6.0;
        speedModifier        = 5.5;
        range                        = 140;
        visibleToSensor = true;
        shadowDetailMask= 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound                = SoundGrogFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = flashExpMedium;
        description                = "Laser Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};
function TurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}


function TurretPack::onDeploy(%player,%item,%pos)
{        if (TurretPack::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function CountObjects(%set,%name,%num)
{
        %count = 0;
        for(%i=0;%i<%num;%i++) {
                %obj=Group::getObject(%set,%i);
                if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
                        %count++;
        }
        return %count;
}



function TurretPack::deployShape(%player,%item)
{        
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",LaserTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"Laser Turret");
							GameBase::startFadeIn(%turret);
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Laser Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "TurretPack"]++;
                                        echo("MSG: ",%client," deployed a Laser Turret");
                                        %client.hasDeployed = true;
						    Player::decItemCount(%player,%item);	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }
			 }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


        
     

function LaserTurret::onAdd(%this)
{        schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.025;
        if (GameBase::getMapName(%this) == "")
        {        GameBase::setMapName (%this, "Laser Turret");}
}

function LaserTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function LaserTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}


//===========================
//    Tractor Turret
//===========================


ItemImageData TractorTurretI 
{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TTurretPack 
{ 
	description = "Tractor Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "pTurrets"; 
	imageType = TractorTurretI; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 400; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
};

function TTurretPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} 
	else 
	{ 
		Player::deployItem(%player,%item); 
	} 
} 

function TTurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (DeployTheShape(%player, %item, "DeployableTTurret", "", 2, false, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "Tractor")) 
	{
		Player::decItemCount(%player,%item); 
	} 
} 

ExplosionData turret1Exp
{
   shapeName = "breath.dts";
   soundId   = SoundFireFlierRocket;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.0,  1.0,  0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

RocketData IonEEBolt { bulletShapeName = "breath.dts"; explosionTag = turret1Exp; collisionRadius = 0.0; mass = 2.0; damageClass = 1; damageValue = 0.07; damageType = $TractorDamageType; explosionRadius = 4; kickBackStrength = -300.0; muzzleVelocity = 200.0; terminalVelocity = 200.0; acceleration = 5.0; totalTime = 10.0; liveTime = 11.0; lightRange = 5.0; lightColor = { 0.2, 1.0, 0.2 }; inheritedVelocityScale = 0.5; trailType = 1; trailLength = 130; trailWidth = 0.5; soundId = SoundJetHeavy; }; 

TurretData DeployableTTurret { className = "Turret"; shapeFile = "remoteturret"; projectileType = IonEEBolt; maxDamage = 2.5; maxEnergy = 75; minGunEnergy = 6; maxGunEnergy = 5; sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; reloadDelay = 0.9; speed = 2.5; speedModifier = 1.5; range = 45; gunrange = 65; visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; debrisId = flashDebrisMedium; shieldShapeName = "shield"; activationSound = SoundRemoteTurretOn; deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; description = "Tractor Turret"; damageSkinData = "objectDamageSkins"; }; function DeployableTTurret::onAdd(%this) { schedule("DeployableTTurret::deploy(" @ %this @ ");",1,%this); GameBase::setRechargeRate(%this,5); %this.shieldStrength = 0.001; if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Tractor Turret"); } } 

function DeployableTTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } function DeployableTTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } function DeployableTTurret::onDestroyed(%this) { Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TTurretPack"]--; } function DeployableTTurret::onPower(%this,%power,%generator) {} function DeployableTTurret::onEnabled(%this) { GameBase::setRechargeRate(%this,5); GameBase::setActive(%this,true); } 


//****************************************************
// AAOD Mod Deployable Kit
//************************************
//         AODGrogPack Backpack Script
//        GROGTurret Script
//         (Deployable Chaingun Turret)
//         GrogShot


BulletData GrogShot
{        bulletShapeName = "bullet.DTS";
        explosionTag = bulletExp0;
        expRandCycle        = 3;
        mass = 1;
        collisionRadius = 0.0;
        bulletHoleIndex = 0;
        ExplosionRadius = 0;
        damageClass = 0;
        damageValue = 0.12;
        damageType = $BulletDamageType;
//        damageType = $ChaingunDamageType;
        aimDeflection = 0.005;
        muzzleVelocity = 500.0;
        totalTime = 0.5;

        inheritedVelocityScale = 0.5;
        liveTime = 2.0;
        isVisible = False;
        tracerPercentage = 0.0;
        tracerLength = 0;
        detachFromShooter = false;
        rotationPeriod = 0;
        lightRange = 0.0;
        lightColor = {1.0, 0.25,0.25};
};

ItemImageData AODGrogPackImage
{        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData AODGrogPack
{        description                = "Chaingun Turret";
        shapeFile                = "remoteturret";
        classname                = "Backpack";
        heading                        = "pTurrets";
        imageType                = AODGrogPackImage;
        shadowDetailMask = 4;
        mass                        = 3.0;
        elasticity                = 0.2;
        price                        = 650;
        hudIcon                        = "deployable";
        showWeaponBar        = true;

       hiliteOnActive        = true;
};

TurretData GROGTurret
{         classname                = "Turret";
        shapeFile                = "remoteturret";
        projectileType        = GrogShot;
        maxDamage                = 4.15;
        maxEnergy                = 50;
        minGunEnergy        = 5;
        maxGunEnergy        = 5;
        sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.05;
        speed                        = 6.0;
        speedModifier        = 5.5;
        range                        = 140;
        visibleToSensor = true;
        shadowDetailMask= 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = flashDebrisMedium;
        shieldShapeName = "shield";
        fireSound                = SoundGrogFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = flashExpMedium;
        description                = "Chaingun Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};

function AODGrogPack::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);        }
        else
        {        Player::deployItem(%player,%item); }
}

function AODGrogPack::onDeploy(%player,%item,%pos)
{        if (AODGrogPack::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODGrogPack::deployShape(%player,%item)
{        
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",GROGTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
							GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"Chaingun Turret");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Chaingun Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "AODGrogPack"]++;
                                        echo("MSG: ",%client," deployed a Chaingun Turret");
                                        %client.hasDeployed = true;	
						    return true;

}
                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


      



function GROGTurret::onAdd(%this)
{        schedule("GROGTurret::deploy(" @ %this @ ");",1,%this);
		if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Chaingun Turret");
        }

}

function GROGTurret::deploy(%this)
{        GameBase::playSequence(%this,1,"deploy");
}

function GROGTurret::onEndSequence(%this,%thread)
{        GameBase::setActive(%this,true);
}

function GROGTurret::onDestroyed(%this)
{        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODGrogPack"]--;
}

function GROGTurret::onPower(%this,%power,%generator)
{
}

function GROGTurret::onEnabled(%this)
{        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
        %this.shieldStrength = 0.0085;
}



//----------------------------------------------------------------------------
// Flux Turret
//----------------------------------------------------------------------------

ItemImageData FluxPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData FluxPack
{
        description = "EMP Blast Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = FluxPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 1000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function FluxPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function FluxPack::onDeploy(%player,%item,%pos)
{
        if (FluxPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function FluxPack::deployShape(%player,%item)
{        
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",FluxTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
						GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"EMP Blast Turret");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"EMP Blast Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "FluxPack"]++;
                                        echo("MSG: ",%client," deployed a EMP Blast Turret");
                                        %client.hasDeployed = true;	
						    return true;

}
                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


TurretData Fluxturret
{
        maxDamage = 3.75;
        maxEnergy = 60;
        minGunEnergy = 15;
        maxGunEnergy = 15;
        range = 100;
        gunRange = 150;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisLarge;
        className = "Turret";
        shapeFile = "remoteturret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = SeekingRPEMP;
        reloadDelay = 3;
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
   targetableFovRatio = 0.5;
        explosionId = LargeShockwave;
        description = "EMP Blast Turret";
};

function FluxTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function Fluxturret::onAdd(%this)
{
        schedule("Fluxturret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.01;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "EMP Blast Turret");
        }
}

function Fluxturret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function Fluxturret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function Fluxturret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "FluxPack"]--;
}

// Override base class just in case.
function Fluxturret::onPower(%this,%power,%generator) {}
function Fluxturret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,5);
        GameBase::setActive(%this,true);
}


//----------------------------------------------------------------------------
// Fusion Turret
//----------------------------------------------------------------------------

ItemImageData Turret4PackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1.5;
        firstPerson = false;
};

ItemData Turret4Pack
{
        description = "Fusion Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = Turret4PackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 3500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function Turret4Pack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }

       else {
                Player::deployItem(%player,%item);
        }

}

function Turret4Pack::onDeploy(%player,%item,%pos)
{
        if (Turret4Pack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function Turret4Pack::deployShape(%player,%item)
{          
		%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",FusionTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"Fusion Turret");
							GameBase::startFadeIn(%turret);
                                        Client::sendMessage(%client,0,"Fusion Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "FusionTurret"]++;
                                        echo("MSG: ",%client," deployed a Fusion Turret");
                                        %client.hasDeployed = true;	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
TurretData FusionTurret
{
        maxDamage = 4.0;
        maxEnergy = 100;
        minGunEnergy = 75;
        maxGunEnergy = 15;
        reloadDelay = 0.25;
        fireSound = SoundPlasmaTurretFire;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 250;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "hellfiregun";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = ChargedFusionBolt;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Fusion Turret";
};

function FusionTurret::onAdd(%this)
{
        schedule("FusionTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,25);
        %this.shieldStrength = 0.006;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Fusion Turret");
        }
}

function FusionTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function FusionTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function FusionTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "Turret4Pack"]--;
}

// Override base class just in case.
function FusionTurret::onPower(%this,%power,%generator) {}
function FusionTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,25);
        GameBase::setActive(%this,true);
}


//----------------------------------------------------------------------------
// HP Turret
//----------------------------------------------------------------------------

ItemImageData HPTurretPackImage
{

       shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData HPTurretPack
{
        description = "HP Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = HPTurretPackImage;
        shadowDetailMask = 4;
        mass = 0.5;
        elasticity = 0.2;
        price = 950;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HPTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function HPTurretPack::onDeploy(%player,%item,%pos)
{
        if (HPTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function HPTurretPack::deployShape(%player,%item)
{        %client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",HPTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"HP Turret");
							GameBase::startFadeIn(%turret);
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"HP Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "HPTurretPack"]++;
                                        echo("MSG: ",%client," deployed a HP Turret");
                                        %client.hasDeployed = true;	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


TurretData HPTurret
{
        maxDamage = 3.0;
        maxEnergy = 150;
        minGunEnergy = 15;
        maxGunEnergy = 5;
        reloadDelay = 1.25;
        fireSound = SoundFireSeeking;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 200;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "mortar_turret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = sniperXTurret;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "HP Turret";
};

function HPTurret::onAdd(%this)
{
        schedule("HPTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "HP Turret");
        }
}

function HPTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function HPTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function HPTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function HPTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "HPTurretPack"]--;
}

// Override base class just in case.
function HPTurret::onPower(%this,%power,%generator) {}
function HPTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
}


//----------------------------------------------------------------------------
// Team Chat Tapper
//----------------------------------------------------------------------------

ItemImageData ChatTapperPackImage
{
        shapeFile = "sensor_jammer";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData ChatTapperPack
{
        description = "Team Chat Tapper";
        shapeFile = "sensor_jammer";
        className = "Backpack";
   heading = "lDeployables";
        imageType = ChatTapperPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 2000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function ChatTapperPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function ChatTapperPack::onDeploy(%player,%item,%pos)
{
        if (ChatTapperPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function ChatTapperPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastFloorShape") {
                                %prot = GameBase::getRotation(%player);
                                %zRot = getWord(%prot,2);
                                if (Vector::dot($los::normal,"0 0 1") > 0.6) {
                                        %rot = "0 0 " @ %zRot;
                                }
                                else {
                                        if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
                                                %rot = "3.14159 0 " @ %zRot;
                                        }
                                        else {
                                                %rot = Vector::getRotation($los::normal);
                                        }
                                }
                                if(checkDeployArea(%client,$los::position)) {
                                        %mSensor = newObject("","Sensor",DeployableBug,true);
                         addToSet("MissionCleanup", %mSensor);
                                        GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
                                        GameBase::setRotation(%mSensor,%rot);
                                        GameBase::setPosition(%mSensor,$los::position);
						GameBase::startFadeIn(%mSensor);
                                        Gamebase::setMapName(%mSensor,"Team Chat Tapper");
						    schedule("GameBase::startFadeOut("@%msensor@");",10.0, $los::object);
                                        Client::sendMessage(%client,0,"Team Chat Tapper deployed");
                                        playSound(SoundPickupBackpack,$los::position);
						    $TeamItemCount[GameBase::getTeam(%msensor) @ "ChatTapperPack"]++;
                                        echo("MSG: ",%client," deployed a Team Chat Tapper");
                                        return true;
                                }
                        }
                        else {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

function DeployableBug::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "ChatTapperPack"]--;
}


//----------------------------------------------------------------------------
// Mitzi Blast Turret
//----------------------------------------------------------------------------

ItemImageData IonTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData IonTurretPack
{
        description = "Mitzi Blast Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = IonTurretPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.2;
        price = 3000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function IonTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function IonTurretPack::onDeploy(%player,%item,%pos)
{
        if (IonTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function IonTurretPack::deployShape(%player,%item)
{        %client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",IonTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
							GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"Mitzi Blast Turret");		
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Mitzi Blast Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "IonTurretPack"]++;
                                        echo("MSG: ",%client," deployed a Mitzi Blast Turret");
                                        %client.hasDeployed = true;	
						    return true;
				}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData IonTurret
{
        maxDamage = 4.0;
        maxEnergy = 300;
        minGunEnergy = 25;
        maxGunEnergy = 25;
        reloadDelay = 2;
        fireSound = capturedTower;
        activationSound = SoundMortarTurretOn;
        deactivateSound = SoundMortarTurretOff;
        whirSound = SoundMortarTurretTurn;
        range = 300;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "mortar_turret";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = IonShock3;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "Mitzi Blast Turret";
};

function IonTurret::onAdd(%this)
{
        schedule("IonTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0.006;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Mitzi Blast Turret");
        }
}

function IonTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function IonTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function IonTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "IonTurretPack"]--;
}

// Override base class just in case.
function IonTurret::onPower(%this,%power,%generator) {}
function IonTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
}


//----------------------------------------------------------------------------
// Pulse Turret
//----------------------------------------------------------------------------

ItemImageData PulseTurretPackImage
{

       shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData PulseTurretPack
{
        description = "AA Battery";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = PulseTurretPackImage;
        shadowDetailMask = 4;
        mass = 0.5;
        elasticity = 0.2;
        price = 950;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PulseTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function PulseTurretPack::onDeploy(%player,%item,%pos)
{
        if (PulseTurretPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function PulseTurretPack::deployShape(%player,%item)
{        %client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",PulseTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"AF Turret");
					Client::setOwnedObject(%client, %turret);
						GameBase::startFadeIn(%turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"AF Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "PulseTurretPack"]++;
                                        echo("MSG: ",%client," deployed an AF Turret");
                                        %client.hasDeployed = true;	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


      




TurretData PulseTurret
{
        maxDamage = 3.0;
//        maxDamage = 1.0;
        maxEnergy = 150;
        minGunEnergy = 15;
        maxGunEnergy = 5;
        reloadDelay = 0.125;
        fireSound = SoundFireSeeking;
        activationSound = SoundPlasmaTurretOn;
        deactivateSound = SoundPlasmaTurretOff;
        whirSound = SoundPlasmaTurretTurn;
        range = 400;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        visibleToSensor = true;
        debrisId = defaultDebrisMedium;
        className = "Turret";
        shapeFile = "hellfiregun";
        shieldShapeName = "shield_medium";
        speed = 2.0;
        speedModifier = 2.0;
        projectileType = AFBolt;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
        explosionId = LargeShockwave;
        description = "AF Turret";
};

function PulseTurret::onAdd(%this)
{
        schedule("PulseTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,15);
        %this.shieldStrength = 0.005;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "AF Turret");
        }
}

function PulseTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function PulseTurret::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function PulseTurret::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function PulseTurret::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "PulseTurretPack"]--;
}

// Override base class just in case.
function PulseTurret::onPower(%this,%power,%generator) {}
function PulseTurret::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,15);
        GameBase::setActive(%this,true);
}


//==================================
//     Rocket Turret
//==================================

ItemImageData RocketPackImage
{
        shapeFile = "missileturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData RocketPack
{
        description = "Rocket Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "pTurrets";
        imageType = RocketPackImage;
        shadowDetailMask = 4;
        mass = 3.0;
        elasticity = 0.2;
        price = 1200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};



function RocketPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function RocketPack::onDeploy(%player,%item,%pos)
{
        if (RocketPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function RocketPack::deployShape(%player,%item)
{        %client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("missileturret","Turret",DeployableRocket,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"Rocket Turret");
							GameBase::startFadeIn(%turret);
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"Rocket Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "RocketPack"]++;
                                        echo("MSG: ",%client," deployed a Rocket Turret");
                                        %client.hasDeployed = true;	
						    return true;
}

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

TurretData DeployableRocket
{
        maxDamage = 3.75;
        maxEnergy = 100;
        minGunEnergy = 60;
        maxGunEnergy = 60;
        range = 150;
        gunRange = 300;
        visibleToSensor = true;
        dopplerVelocity = 0;
        castLOS = true;
        supression = false;
        mapFilter = 2;
        mapIcon = "M_turret";
        debrisId = defaultDebrisLarge;
        className = "Turret";
        shapeFile = "missileturret";
        shieldShapeName = "shield_medium";
        speed = 5.0;
        speedModifier = 2.0;
        projectileType = TurretMissile;
        fireSound = SoundMissileTurretFire;
        activationSound = SoundMissileTurretOn;
        deactivateSound = SoundMissileTurretOff;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 8;
   targetableFovRatio = 0.5;
        explosionId = LargeShockwave;
        description = "Rocket Turret";
};

function DeployableRocket::onAdd(%this)
{
        schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,5);
        %this.shieldStrength = 0.03;
        if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Rocket Turret");
        }
}

function DeployableRocket::deploy(%this)
{
        GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
        GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
        Turret::onDestroyed(%this);
          $TeamItemCount[GameBase::getTeam(%this) @ "DeployableRocket"]--;
}

// Override base class just in case.
function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this)
{
        GameBase::setRechargeRate(%this,14);
        GameBase::setActive(%this,true);
}

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

//---------------------------------
//         AODArtilleryPack Backpack Script
//---------------------------------
ItemImageData AODArtilleryPackImage
{        shapeFile                = "magcargo";
        mountPoint                = 2;
        mountOffset                = { 0, -0.65, -0.4 };
        mountRotation        = { 0, 0, 0 };
        mass                                = 3.0;
        firstPerson                = false;
};

ItemData AODArtilleryPack
{        description                = "SHB Turret";
        shapeFile                = "Mortar_Turret";
        classname                = "Backpack";
        heading                        = "pTurrets";
        imageType                = AODArtilleryPackImage;
        shadowDetailMask = 4;
        mass                        = 3.0;
        elasticity                = 0.2;
        price                        = 9500;
        hudIcon                        = "deployable";
        showWeaponBar        = true;
        hiliteOnActive = true;
};


TurretData ArtilleryTurret
{        classname                = "Turret";
        shapeFile                = "Mortar_Turret";
        projectileType        = SuperBlaster2;
        maxDamage                = 4.5;
        maxEnergy                = 100;
        minGunEnergy        = 15;
        maxGunEnergy        = 10;
        sequenceSound[0]= {"deploy", SoundActivateMotionSensor};
        reloadDelay                = 0.05;
        speed                        = 6.0;
        speedModifier        = 1.5;
        range                        = 150;
        visibleToSensor = true;
        shadowDetailMask= 4;
        dopplerVelocity = 0;
        castLOS                        = true;
        supression                = false;
        mapFilter                = 2;
        mapIcon                        = "M_turret";
        debrisId                = FlierDebris;
        shieldShapeName = "shield";
        fireSound                = SoundPlasmaTurretFire;
        activationSound = SoundRemoteTurretOn;
        deactivateSound = SoundRemoteTurretOff;
        explosionId                = LargeShockwave;
        description                = "Super Hyper Blaster Turret";
        damageSkinData        = "objectDamageSkins";
        pinger                        = false;
};


function AODArtilleryPack::onUse(%player,%item)
{        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {        Player::mountItem(%player,%item,$BackpackSlot);}
        else
        {        Player::deployItem(%player,%item);}
}

function AODArtilleryPack::onDeploy(%player,%item,%pos)
{        if (AODArtilleryPack::deployShape(%player,%item))
        {        Player::decItemCount(%player,%item);}
}

function AODArtilleryPack::deployShape(%player,%item)
{        
%client = Player::getClient(%player);
		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("","Turret",ArtilleryTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
                                        Gamebase::setMapName(%turret,"SHB Turret");
							GameBase::startFadeIn(%turret);
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"SHB Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "AODArtilleryPack"]++;
                                        echo("MSG: ",%client," deployed a SHB Turret");
                                        %client.hasDeployed = true;	
						    return true;
                                 }

                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }

         }
        else 
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
	}




function ArtilleryTurret::onDestroyed(%this)
{        ArtilleryTurret::onDisabled(%this);
        Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "AODArtilleryPack"]--;
}

function ArtilleryTurret::onEnabled(%this)
{                
			GameBase::setRechargeRate(%this,24);
                %this.shieldStrength = 0.005;
                GameBase::setActive(%this,true);
        }

function ArtilleryTurret::onDisabled(%this)
{        GameBase::setRechargeRate(%this,0);
        %this.shieldStrength = 0.0;
        GameBase::setActive(%this,false);
}


//----------------------------------------------------------------------------
// PBW Turret
//----------------------------------------------------------------------------

ItemImageData ElectroTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData ElectroTurretPack
{
	description = "PBW Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "pTurrets";
	imageType = ElectroTurretPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 400000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectroTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ElectroTurretPack::onDeploy(%player,%item,%pos)
{
	if (ElectroTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ElectroTurretPack::deployShape(%player,%item)
{        
%client = Player::getClient(%player);

		if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		if (GameBase::getLOSInfo(%player,6)) 
		{
			%playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) < 100)
                          {
                        %client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "<jc><f1>You have been rewarded for defending your flag!!! <f2>Score + " @ $Score::FlagDef @ " Flag Defence = <f1>" @ %client.score @ " Total Score. <f0> WELL DONE!!!" ,3);
				Game::refreshClientScore(%client);	
				Player::decItemCount(%player,%item); 

                          }

			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
				
			if (Vector::dot($los::normal,"0 0 1") > 0.2)
			{
				%rot = "0 0 " @ %zRot;
			}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.2) {
						%rot = "3.14159 0 " @ %zRot;
				}

				else 
				{
						%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position))
			{
				
                                        %turret = newObject("remoteturret","Turret",AntiTurret,true);
                                        addToSet("MissionCleanup", %turret);
                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                        GameBase::setRotation(%turret,%rot);
                                        GameBase::setPosition(%turret,$los::position);
							GameBase::startFadeIn(%turret);
                                        Gamebase::setMapName(%turret,"PBW Turret");
					Client::setOwnedObject(%client, %turret);
                                Client::setOwnedObject(%client, %player);
                                        Client::sendMessage(%client,0,"PBW Turret deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%turret) @ "ElectroTurretPack"]++;
                                        echo("MSG: ",%client," deployed a PBW Turret");
                                        %client.hasDeployed = true;
						   Player::decItemCount(%player,%item);
						    return true;
					}
                        }
                       else {
                                Client::sendMessage(%client,1,"Deploy position out of range.");
                        }
         }
        else 
                 Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
     }

TurretData AntiTurret
{
	maxDamage = 0.2;
	maxEnergy = 320;
	minGunEnergy = 160;
	maxGunEnergy = 160;
	reloadDelay = 2.5;
	fireSound = SoundPBWBreakSoundBarrier;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 200;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = ParticleBeam;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "PBW Turret";
};

function AntiTurret::onAdd(%this)
{
	schedule("AntiTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "PBW Turret");
	}
}

function AntiTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function AntiTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function AntiTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ElectroTurretPack"]--;
}

// Override base class just in case.
function AntiTurret::onPower(%this,%power,%generator) {}
function AntiTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,25);
	GameBase::setActive(%this,true);
}

exec("itemlist.cs");
