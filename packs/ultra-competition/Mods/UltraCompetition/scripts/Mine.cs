//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
		) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0;
};


//----------------------------------------------------------------------------
MineData Boost
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $BoostDamageType;
	kickBackStrength = 0; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function VelocityCheck(%player,%var)
{
	%armor = Player::getArmor(%player);
	%this = $SpeedMax[%armor];
	if (%var < 0)
	{
	%var *= -1;
	}
	else
	{
	%var *= 1;
	}
	%num = (%this - %var);
	$VelRatio = %num/%this;
	return $VelRatio;
}

function Beacon::onUse(%player,%item)
{
if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
			if(getword(Item::getVelocity(%player),2)>500) return;
                        Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","Boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
				%dir = Item::getVelocity(%player);
				%armor = Player::getArmor(%player);
				%X = getWord(%dir,0);
				VelocityCheck(%player,%X);
				%Y = getWord(%dir,1);
				%Z = getWord(%dir,2);
				%this = ($BoostSpeed[%armor]*$VelRatio);
				%Xset = %X * %this;
				%Yset = %Y * %this;
				%Zset = %Z * %this;
				%force = "" @ %Xset @ " " @ %Yset @ " " @ %Zset @ "";
				Item::setVelocity(%player, %force); 
                        Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster.");
                }
        }
}



MineData BoostBrake
{
	className = "Mine";
   description = "";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 0; //500//-450
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData DaBomB
{
	className = "Mine";
   description = "Da BomB";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 280;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 0;
	maxDamage = 100;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function DaBomB::onAdd(%this)
{
	%this.damage = 0;
	DaBomB::deployCheck(%this);
}

function DaBomB::onCollision(%this,%object)
{

}

function DaBomB::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		//GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		//%set = newObject("set",SimSet);
		//if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
		//	%data = GameBase::getDataName(%this);
		//	GameBase::setDamageLevel(%this, %data.maxDamage);
		//}
		//deleteObject(%set);
	}
	else 
		schedule("DaBomB::deployCheck(" @ %this @ ");", 3, %this);
}	

function DaBomB::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "DaBomBPack"]--;
}

function DaBomB::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}