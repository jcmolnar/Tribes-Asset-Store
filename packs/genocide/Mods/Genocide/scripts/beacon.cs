StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";
   description = "BaBeacon";
	shapeFile = "discb";
	maxDamage = 0.1;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = beaconexp;
	debrisId = beaconflash;
};
			
function Beacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
	//GameBase::setRechargeRate(%this,5);
	//GameBase::setActive(%this,true);

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 10, 10, 10,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%name = (GameBase::getDataName(%obj)).description;
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this ||    %name == "BaBeacon")
		{
			//don't cloak enemies or the beacon itself
		}
		else
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
		if (GameBase::getDamageLevel(%obj) != 0) {
			%dlevel = GameBase::getDamageLevel(%obj) - 0.1;
			GameBase::setDamageLevel(%obj,%dlevel);
			}
		}
	}

	%this.set = %Set;

	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.1, %this);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
	//Turret::onDisabled(%this);

	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;

	}
	deleteObject(%this.set);
}

function Beacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
	Turret::onDestroyed(%this);

}

//=============================
// new crap here..

function beacon::onAdd(%this)
{
	//schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
	//GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Cloak Node");
	}
}


//=================================

function ArbitorBox::checkArbitorBox(%this)
{

	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, things, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 10, 10, 10,0);
	%num = Group::objectCount(%Set);
for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%name = (GameBase::getDataName(%obj)).description;
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this  ||    %name == "BaBeacon")
		{
			//don't cloak enemies or the box itself
		}
		else
		{
			GameBase::startFadeOut(%obj);
		if (GameBase::getDamageLevel(%obj) != 0) {
			%dlevel = GameBase::getDamageLevel(%obj) - 0.1;
			GameBase::setDamageLevel(%obj,%dlevel);
			}


			%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}


	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		%name = (GameBase::getDataName(%obj)).description;
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this) ||    %name == "BaBeacon")
		{
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%obj.cloaked = 0;
			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) {GameBase::startFadeIn(%obj); //then decloak it


}
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
}






