//This is a MiniMod Plugin...
//This is the Teleport Pad from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

StaticShapeData DeployableTeleport
{
    className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "flagstand";
	maxDamage = 0.75;
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
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}				

function DeployableTeleport::Destruct(%this)
{
    //CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableTeleport::onDestroyed(%this)
{
      schedule("RemoveBeam("@%this.beam1@");",1);
      

   // CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);

    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
//        echo("Applying damage to mate");
        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableTeleport::onCollision(%this,%obj)
{
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
        Client::SendMessage(%c,0,"Wrong team");
        return;
	}

    if(%this.disabled == true)
	{
        Client::SendMessage(%c,0,"Teleport Pad is recharging");

        return;
	}

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	  if(GameBase::getTeam(%o) == %playerteam && %o != %this)
        {
		if((Player::getArmor(%obj) == "harmor") || (Player::getArmor(%obj) == "darmor"))
		{
            Client::SendMessage(%c,0,"Cannot teleport in this character class");
			return;
		}
		else
		{
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
            	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
	            %o.Disabled = true;
      	      %this.Disabled = true;
		//	GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 55) == 0)
			{
                    Client::SendMessage(%c,0,"Teleport phased your molecular structure wrong");
		        GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			}
			else
			{
		            schedule("DeployableTeleport::Reenable("@%o@");",5);
      		      schedule("DeployableTeleport::Reenable("@%this@");",5);
			}
			return;
		}
        }
    }
    Client::SendMessage(%c,0,"No other pad to teleport to");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}



