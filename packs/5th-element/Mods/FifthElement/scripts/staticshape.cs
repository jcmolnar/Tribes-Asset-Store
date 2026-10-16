


function StaticShape::onPower(%this,%power,%generator) {
 if (%power) GameBase::playSequence(%this,0,"power");
 else GameBase::stopSequence(%this,0);
 }
 function StaticShape::onEnabled(%this) {
 if (GameBase::isPowered(%this)) GameBase::playSequence(%this,0,"power");
 }
 function StaticShape::onDisabled(%this) {
 GameBase::stopSequence(%this,0);
 }
 function StaticShape::onDestroyed(%this) {
 GameBase::stopSequence(%this,0);
 StaticShape::objectiveDestroyed(%this);
 calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
 }
function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
  %client = Player::getClient(%object);
  %name = GameBase::getDataName(%this);
  %damageLevel = GameBase::getDamageLevel(%this); 
  %dValue = %damageLevel + %value; %this.lastDamageObject = %object; 
  %this.lastDamageTeam = GameBase::getTeam(%object); 
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{
  		%name = GameBase::getDataName(%this); 
			if(%name.className == Generator || %name.className == Station) 
			{
    				%TDS = $Server::TeamDamageScale; %dValue = %damageLevel + %value * %TDS; 
 				%disable = GameBase::getDisabledDamage(%this); 
   					if(!$Server::TourneyMode && %dValue > %disable - 0.05) 
					{
     					if(%damageLevel > %disable - 0.05) return; 
     					else %dValue = %disable - 0.05; 
   					}
 			}

	}
	if(GameBase::getDamageState(%this) == "Destroyed" || GameBase::getTeam(%client) == GameBase::getTeam(%this))
	{ 
		%Check = 1;
	}
	GameBase::setDamageLevel(%this,%dValue); 
	if(%Check != 1 && GameBase::getDamageState(%this) == "Destroyed") 
	{
	echo("GAME: " @ Client::getName(%client) @ " Destroyed ", %name.className);
		if(%name.classname == "Turret" || %name.classname == "Generator")
 		{
   		Client::sendMessage(%client,3,"You have just recieved 1 point for destroying a "@ %name.className);
		echo("GAME: ", %client, " Destroyed ", %name.className);
		%client.score++;
		Game::refreshClientScore(%client);
		}
	}
}
 function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object) {
 %damageLevel = GameBase::getDamageLevel(%this);
 %this.lastDamageObject = %object;
 %this.lastDamageTeam = GameBase::getTeam(%object);
 if (%this.shieldStrength) {
 %energy = GameBase::getEnergy(%this);
 %strength = %this.shieldStrength;
 if (%type == $ShrapnelDamageType) %strength *= 0.5;
 else if (%type == $MortarDamageType) %strength *= 0.25;
 else if (%type == $BlasterDamageType) %strength *= 2.0;
 %absorb = %energy * %strength;
 if (%value < %absorb) {
 if(%type == $RailDamageType) { 
 GameBase::setEnergy(%this,(%energy * 0.27));
 playSound(SoundEMPDrain,GameBase::getPosition(%this)); 
 } else {
 GameBase::setEnergy(%this,%energy - (%value / %strength));
 }
 %centerPos = getBoxCenter(%this);
 %sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
 %centerPosX = getWord(%centerPos,0);
 %centerPosY = getWord(%centerPos,1);
 %centerPosZ = getWord(%centerPos,2);
 %pointX = getWord(%pos,0);
 %pointY = getWord(%pos,1);
 %pointZ = getWord(%pos,2);
 %newVecX = %centerPosX - %pointX;
 %newVecY = %centerPosY - %pointY;
 %newVecZ = %centerPosZ - %pointZ;
 %norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
 %zOffset = 0;
 if(GameBase::getDataName(%this) == PulseSensor) %zOffset = (%pointZ-%centerPosZ) * 0.5;
 GameBase::activateShield(%this,%sphereVec,%zOffset);
 if(%type == $FlashDamageType || %type == $EMPWarheadDamageType) {
 GameBase::setEnergy(%this,0);
 playSound(SoundEMPDrain,GameBase::getPosition(%this));
 }
 }
 else {
 GameBase::setEnergy(%this,0);
 StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
 }
 }
 else {
 StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
 }
 }
 StaticShapeData FlagStand {
 description = "Flag Stand";
 shapeFile = "flagstand";
 visibleToSensor = false;
 }
;
 function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio, %rMax,%rMin,%dMax,%dMin,%fMax,%fMin) {
 %radius = GameBase::getRadius(%this);
 if(%radius) {
 %radius *= %radiusRatio;
 %damageValue = %radius * %damageRatio;
 %force = %radius * %forceRatio;
 if(%radius > %rMax) %radius = %rMax;
 else if(%radius < %rMin) %radius = %rMin;
 if(%damageValue > %dMax) %damageValue = %dMax;
 else if(%damageValue < %dMin) %damageValue = %dMin;
 if(%force > %fMax) %force = %fMax;
 else if(%force < %fMin) %force = %fMin;
 GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius, %damageValue,%force,%this);
 }
 }
 function FlagStand::onDamage() {
 }
 function Generator::onEnabled(%this) {
 GameBase::setActive(%this,true);
 }
 function Generator::onDisabled(%this) {
 GameBase::stopSequence(%this,0);
 GameBase::generatePower(%this, false);
 }
 function Generator::onDestroyed(%this) {
 Generator::onDisabled(%this);
 StaticShape::objectiveDestroyed(%this);
 calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
 }
 function Generator::onActivate(%this) {
 GameBase::playSequence(%this,0,"power");
 GameBase::generatePower(%this, true);
 }
 function Generator::onDeactivate(%this) {
 GameBase::stopSequence(%this,0);
 GameBase::generatePower(%this, false);
 }
 StaticShapeData TowerSwitch {
 description = "Tower Control Switch";
 className = "towerSwitch";
 shapeFile = "tower";
 showInventory = "false";
 visibleToSensor = true;
 mapFilter = 4;
 mapIcon = "M_generator";
 }
;
 StaticShapeData Generator {
 description = "Generator";
 shapeFile = "generator";
 className = "Generator";
 sfxAmbient = SoundGeneratorPower;
 debrisId = flashDebrisLarge;
 explosionId = flashExpLarge;
 maxDamage = 2.0;
 visibleToSensor = true;
 mapFilter = 4;
 mapIcon = "M_generator";
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 }
;
 StaticShapeData SolarPanel {
 description = "Solar Panel";
 shapeFile = "solar_med";
 className = "Generator";
 debrisId = flashDebrisMedium;
 maxDamage = 1.0;
 visibleToSensor = true;
 mapFilter = 4;
 mapIcon = "M_generator";
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpLarge;
 }
;
 StaticShapeData PortGenerator {
 description = "Portable Generator";
 shapeFile = "generator_p";
 className = "Generator";
 debrisId = flashDebrisSmall;
 sfxAmbient = SoundGeneratorPower;
 maxDamage = 1.6;
 mapIcon = "M_generator";
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpMedium;
 visibleToSensor = true;
 mapFilter = 4;
 }
;
 StaticShapeData SmallAntenna {
 shapeFile = "anten_small";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.0;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpMedium;
 description = "Small Antenna";
 }
;
 StaticShapeData MediumAntenna {
 shapeFile = "anten_med";
 debrisId = flashDebrisSmall;
 maxDamage = 1.5;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpMedium;
 description = "Medium Antenna";
 }
;
 StaticShapeData LargeAntenna {
 shapeFile = "anten_lrg";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.5;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = debrisExpMedium;
 description = "Large Antenna";
 }
;
 StaticShapeData ArrayAntenna {
 shapeFile = "anten_lava";
 debrisId = flashDebrisSmall;
 maxDamage = 1.5;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpMedium;
 description = "Array Antenna";
 }
;
 StaticShapeData RodAntenna {
 shapeFile = "anten_rod";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.5;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = debrisExpMedium;
 description = "Rod Antenna";
 }
;
 StaticShapeData ForceBeacon {
 shapeFile = "force";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = debrisExpMedium;
 description = "Force Beacon";
 }
;
 StaticShapeData CargoCrate {
 shapeFile = "magcargo";
 debrisId = flashDebrisSmall;
 maxDamage = 1.0;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = flashExpMedium;
 description = "Cargo Crate";
 }
;
 StaticShapeData CargoBarrel {
 shapeFile = "liqcyl";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.0;
 damageSkinData = "objectDamageSkins";
 shadowDetailMask = 16;
 explosionId = debrisExpMedium;
 description = "Cargo Barrel";
 }
;
 StaticShapeData SquarePanel {
 shapeFile = "teleport_square";
 debrisId = flashDebrisSmall;
 maxDamage = 0.3;
 damageSkinData = "objectDamageSkins";
 explosionId = flashExpMedium;
 description = "Panel";
 }
;
 StaticShapeData VerticalPanel {
 shapeFile = "teleport_vertical";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData BluePanel {
 shapeFile = "panel_blue";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData YellowPanel {
 shapeFile = "panel_yellow";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData SetPanel {
 shapeFile = "panel_set";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData VerticalPanelB {
 shapeFile = "panel_vertical";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData DisplayPanelOne {
 shapeFile = "display_one";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData DisplayPanelTwo {
 shapeFile = "display_two";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData DisplayPanelThree {
 shapeFile = "display_three";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData HOnePanel {
 shapeFile = "dsply_h1";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData HTwoPanel {
 shapeFile = "dsply_h2";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData SOnePanel {
 shapeFile = "dsply_s1";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData STwoPanel {
 shapeFile = "dsply_s2";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData VOnePanel {
 shapeFile = "dsply_v1";
 debrisId = defaultDebrisSmall;
 explosionId = debrisExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData VTwoPanel {
 shapeFile = "dsply_v2";
 debrisId = flashDebrisSmall;
 explosionId = flashExpMedium;
 maxDamage = 0.5;
 damageSkinData = "objectDamageSkins";
 description = "Panel";
 }
;
 StaticShapeData ForceField {
 shapeFile = "forcefield";
 debrisId = defaultDebrisSmall;
 maxDamage = 10000.0;
 isTranslucent = true;
 description = "Force Field";
 }
;
 StaticShapeData ElectricalBeam {
 shapeFile = "zap";
 maxDamage = 10000.0;
 isTranslucent = true;
 description = "Electrical Beam";
 disableCollision = true;
 }
;
 StaticShapeData ElectricalBeamBig {
 shapeFile = "zap_5";
 maxDamage = 10000.0;
 isTranslucent = true;
 description = "Electrical Beam";
 disableCollision = true;
 }
;
 StaticShapeData PoweredElectricalBeam {
 shapeFile = "zap";
 maxDamage = 10000.0;
 isTranslucent = true;
 description = "Electrical Beam";
 disableCollision = true;
 }
;
 function PoweredElectricalBeam::onPower(%this, %power, %generator) {
 if(%power) GameBase::startFadeIn(%this);
 else GameBase::startFadeOut(%this);
 }
 StaticShapeData Cactus1 {
 shapeFile = "cactus1";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.4;
 description = "Cactus";
 }
;
 StaticShapeData Cactus2 {
 shapeFile = "cactus2";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.4;
 description = "Cactus";
 }
;
 StaticShapeData Cactus3 {
 shapeFile = "cactus3";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.4;
 description = "Cactus";
 }
;
 StaticShapeData SteamOnGrass {
 shapeFile = "steamvent_grass";
 maxDamage = 999.0;
 isTranslucent = "True";
 description = "Steam Vent";
 }
;
 StaticShapeData SteamOnMud {
 shapeFile = "steamvent_mud";
 maxDamage = 999.0;
 isTranslucent = "True";
 description = "Steam Vent";
 }
;
 StaticShapeData TreeShape {
 shapeFile = "tree1";
 maxDamage = 10.0;
 isTranslucent = "True";
 description = "Tree";
 }
;
 StaticShapeData TreeShapeTwo {
 shapeFile = "tree2";
 maxDamage = 10.0;
 isTranslucent = "True";
 description = "Tree";
 }
;
 StaticShapeData SteamOnGrass2 {
 shapeFile = "steamvent2_grass";
 maxDamage = 999.0;
 isTranslucent = "True";
 }
;
 StaticShapeData SteamOnMud2 {
 shapeFile = "steamvent2_mud";
 maxDamage = 999.0;
 isTranslucent = "True";
 description = "Steam Vent";
 }
;
 StaticShapeData PlantOne {
 shapeFile = "plant1";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.4;
 description = "Plant";
 }
;
 StaticShapeData PlantTwo {
 shapeFile = "plant2";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.4;
 description = "Plant";
 }
;
 StaticShapeData DeployableForceField {
 shapeFile = "forcefield_5x5";
 //debrisId = defaultDebrisSmall;
 maxDamage = 4.50;
 visibleToSensor = true;
 isTranslucent = true;
 description = "Force Field";
 };

 function DeployableForceField::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
 }

function DeployableForceField::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",ForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Deployable Force Field");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}
 StaticShapeData LargeForceField {
 shapeFile = "forcefield";
 debrisId = defaultDebrisLarge;
 maxDamage = 5.00;
 visibleToSensor = true;
 isTranslucent = true;
 description = "Force Field";
 };

 function LargeForceField::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;
 }
function LargeForceField::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",LargeForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Deployable Force Field");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}

 StaticShapeData BlastWall {
 shapeFile = "newdoor5";
 maxDamage = 5.00;
 debrisId = defaultDebrisLarge;
 explosionId = debrisExpLarge;
 }
;
 function BlastWall::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--;
 }

function Blastwall::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",TripwirePack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Blastwall");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}
 StaticShapeData DeployablePlatform {
 shapeFile = "elevator6x6thin";
 debrisId = flashDebrisMedium;
 maxDamage = 3.25;
 visibleToSensor = false;
 isTranslucent = true;
 description = "Deployable Platform";
 }
;
 function DeployablePlatform::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
 }
function DeployablePlatform::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",PlatformPack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Deployable Platform");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}

 StaticShapeData Hologram1 {
 shapeFile = "larmor";
 debrisId = defaultDebrisSmall;
 maxDamage = 0.75;
 description = "Hologram";
 }
;
 function Hologram1::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
 }
 StaticShapeData Hologram2 {
 shapeFile = "marmor";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.10;
 description = "Hologram";
 }
;
 function Hologram2::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
 }
 StaticShapeData Hologram3 {
 shapeFile = "harmor";
 debrisId = defaultDebrisSmall;
 maxDamage = 1.5;
 description = "Hologram";
 }
;
 function Hologram1::onDestroyed(%this) {
 StaticShape::onDestroyed(%this);
 $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
 }

 StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 1.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    	explosionId = mortarExp;
    	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};
				
function RemoveBeam(%b)
{
	deleteObject(%b);
}				
														 
function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);
	//schedule("RemoveBeam("@%this.pad1@");",1);

	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

	%teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
        	GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableTeleport::onCollision(%this,%obj)
{
	// %this - Is Telepad
	// %obj  - Is Player (or other object)

	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	
	if(%teleTeam != %playerTeam)
	{
		if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
			Client::SendMessage(%c,0,"Phased through enemy teleporter");
		else
		{ 
			Client::SendMessage(%c,0,"Wrong Team"); 
			return;
		}
	}

	
	if(%this.disabled == true)
	{
	        Client::SendMessage(%c,0,"Teleport Pad is recharging");
	        return;
	}

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if ($Debug) echo ("Group Set Teleporter = " @ Group::getObject(%teleset, %i));

		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{

			if (Player::getArmor(%obj) == "harmor")
			{
			        Client::SendMessage(%c,0,"Cannot teleport in this armor type");
				return;
			}
			else
			{
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;
			}
		}
		else if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
		{
			if(GameBase::getTeam(%o) != %playerteam && %o != %this)
			{
				Client::SendMessage(%c,0,"Transporting To Enemy Telepad!");
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;								
			}		
		}
	}
	Client::SendMessage(%c,0,"No other pad to teleport to.");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
} 

StaticShapeData DeployableSpring 
{
 	shapeFile = "flagstand";
 	debrisId = defaultDebrisSmall;
 	maxDamage = 1.50;
 	visibleToSensor = false;
 	isTranslucent = true;
 	description = "Deployable Spring";
};

function DeployableSpring::onDestroyed(%this) 
{
 	StaticShape::onDestroyed(%this);
 	$TeamItemCount[GameBase::getTeam(%this) @ "SpringPack"]--;
}

function DeployableSpring::onCollision(%this,%obj) 
{
 	%c = Player::getClient(%obj);
 	GameBase::playSound(%this, SoundFireMortar, 0);
 	Client::SendMessage(%c, 0, "SPROING!");
 	%velocity = 200;
 	%zVec = 700;
 	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
 	Player::applyImpulse(%obj,%jumpDir);
}

StaticShapeData LargeForceFieldDoor 
{
 	shapeFile = "forcefield";
 	debrisId = defaultDebrisLarge;
 	maxDamage = 5.00;
 	visibleToSensor = true;
 	isTranslucent = true;
 	description = "Force Field Door";
};


function LargeForceFieldDoor::onDestroyed(%this)
{
	LargeForceFieldDoor::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldDoor"]--;
}

function LargeForceFieldDoor::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		return;
	}

	LargeForceFieldDoor::openDoor(%this);
	return;
}

function LargeForceFieldDoor::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("LargeForceFieldDoor::closeDoor("@%this@");",4);
}

function LargeForceFieldDoor::closeDoor(%this) 
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function LargeForceFieldDoor::openDoor(%this) 
{

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("LargeForceFieldDoor::closeDoor("@%this@");",4);
}

function LargeForceFieldDoor::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",LargeForceFieldDoorPack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Deployable Force Field");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}

StaticShapeData DeployableForceFieldDoor 
{
 	shapeFile = "forcefield_5x5";
 	//debrisId = defaultDebrisSmall;
 	maxDamage = 4.50;
 	visibleToSensor = true;
 	isTranslucent = true;
 	description = "Force Field";
};


function DeployableForceFieldDoor::onDestroyed(%this)
{
	DeployableForceFieldDoor::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceFieldDoor"]--;
}

function DeployableForceFieldDoor::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{
		return;
	}

	DeployableForceFieldDoor::openDoor(%this);
	return;
}

function DeployableForceFieldDoor::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DeployableForceFieldDoor::closeDoor("@%this@");",4);
}

function DeployableForceFieldDoor::closeDoor(%this) 
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function DeployableForceFieldDoor::openDoor(%this) 
{

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("DeployableForceFieldDoor::closeDoor("@%this@");",4);
}

function DeployableForceFieldDoor::packUp(%this, %pos, %client, %player) 
{
	%ownerName = ixGetOwnerName(%this);
	if(%ownerName != "") 
	{
	%name = Client::getName(%client);
		if(%ownerName == %name) 
		{
			if(!GameBase::getDamageLevel(%this)) 
			{
			%player.isDeploying = true;
			GameBase::setSequenceDirection(%this,1,0);
			%player.deployPosition = %pos;
			schedule("deleteObject(" @ %this @ ");",1.9,%this);
			schedule("ixGivePack(" @ %player @ ",ForceFieldDoorPack," @ Client::getTeam(%client) @ ");",2.0,%player);
			echo("MSG: ",%client," Packed up a Deployable Force Field");
			}
		else Client::sendMessage(%client, 0,"This Deployable is damaged, it wont pack up.~werror_message.wav");
		}
		else Client::sendMessage(%client, 0, %ownerName @ " is the only one that can pack up this Item.~werror_message.wav");
	}
}