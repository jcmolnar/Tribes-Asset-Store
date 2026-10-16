MineData AntipersonelMine
{
        className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
        explosionRadius = 10.0;
        damageValue = 0.65;
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
        GameBase::SetTeam(%this);
}

function AntipersonelMine::onCollision(%this,%object) { 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) { 
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object)) { 
			GameBase::setDamageLevel(%this, 2); 
			if($hh::FriendlyMines == FALSE) GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 10, 0.25, 100, Client::getOwnedObject(%this));
		} else if($hh::FriendlyMines == FALSE) {
			GameBase::setDamageLevel(%this, 2);
		}
	} 
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
        explosionRadius = 10.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 16);",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData SmallGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Small Handgrenade";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
        explosionRadius = 5.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function SmallGrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 7);",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData ShockGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
        explosionRadius = 10.0;
        damageValue = 0.5;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function ShockGrenade::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",1.9,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ShockZap(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//----------------------------------------------------------------------------

MineData C4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
        explosionRadius = 25.0;
        damageValue = 15;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 14.999;
};

function C4::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}

MineData C4Quick
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
        explosionRadius = 25.0;
        damageValue = 2.5;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 5;
};

function C4Quick::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",1.99,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ShockZap(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

//from here on: added by werewolf edited by Bhall


MineData NBase
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = flashExpLarge;
        explosionRadius = 0.0;
        damageValue = 0.0;
        damageType = $MineDamageType;
        kickBackStrength = 450;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};


MineData NRing1
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 35.0;
        damageValue = 2.1;
        damageType = $MineDamageType;
        kickBackStrength = 450;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NRing2
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.75;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NRing3
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.65;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NRing4
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 100.0;
        damageValue = 0.55;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NRing5
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NCloud1
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 100.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
MineData NCloud2
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
MineData NCloud3
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;


       explosionId = mortarExp;
        explosionRadius = 100.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
MineData NCloud4
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NCloud5
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};

MineData NCloud6
{
        className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 0.25;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};


function NBase::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}
function NRing1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}
function NRing2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
function NRing3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.7,%this);
}
function NRing4::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.9,%this);
}
function NRing5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}
function NCloud1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud4::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.1,%this);
}
function NCloud5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.2,%this);
}

function NCloud6::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.3,%this);
}

MineData TNT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Blast Pack";
   shapeFile = "magcargo";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 50;
        damageValue = 30;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 29.999;
};

function TNT::onAdd(%this)
{
      schedule("TNTExplosion(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function TNTExplosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

//==================================================================================================== Suicide Pack 2 On Deploy

MineData BombX
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "generator_p";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 50;
        damageValue = 10;
        damageType = $FlierBombDamageType;
        kickBackStrength = 1000;
        triggerRadius = 0.5;
        maxDamage = 20.0;
};

function BombX::onAdd(%this)
{
      schedule("NukeExplosion(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function NukeExplosion(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== Suicide Pack 2 On Deploy

MineData BombZ
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "generator";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 100;
        damageValue = 25;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 50.0;
};

function BombZ::onAdd(%this)
{
      schedule("NukeExplosion2(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function NukeExplosion2(%this)
{
                %obj = newObject("","Mine","NBase");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing1");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 10.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 20.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 30.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NRing5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud1");
                addToSet("MissionCleanup", %obj);
                %padd = "15.0 0 80.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud2");
                addToSet("MissionCleanup", %obj);
                %padd = "-15.0 0 80.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 15.0 80.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud4");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -15.0 80.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

                %obj = newObject("","Mine","NCloud5");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 100.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData Shockadd
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Shockadd2
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Shockadd3
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData MinePlayer1
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "larmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};

function MinePlayer1::onAdd(%this)
{
                schedule("MinePlayer1Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer1::onCollision(%this,%obj)
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


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MinePlayer1Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

MineData MinePlayer2
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "marmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};


function MinePlayer2::onAdd(%this)
{
                schedule("MinePlayer2Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer2::onCollision(%this,%obj)
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


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);

        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MinePlayer2Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);

               %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

MineData MinePlayer3
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "harmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};

function MinePlayer3::onAdd(%this)
{
                schedule("MinePlayer3Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer3::onCollision(%this,%obj)
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


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MinePlayer3Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

MineData Bomba
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = GrenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData Bombe
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 25.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}

//=-=-=-=-
MineData Cluster1
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 50;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Cluster2
{
           mass = 4.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15;
        damageValue = 0.8;
        damageType = $PlasmaDamageType;
        kickBackStrength = 150;
        triggerRadius = 0.8;
        maxDamage = 2.5;
};

function Cluster2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Cluster3
{
          mass = 8.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.55;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 1.0;
        damageType = $PlasmaDamageType;
        kickBackStrength = 250;
        triggerRadius = 1.5;
        maxDamage = 2.5;
};

function Cluster3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

MineData Cluster4
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.28;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 40;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster4::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.75,%this);
}

MineData Cluster5
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 10;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.75,%this);
}



//----------------------------------------------------------------------------

MineData PocketNuke1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 1";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = FDExp;
        explosionRadius = 10.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function PocketNuke1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 32);",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

//----------------------------------------------------------------------------

MineData PocketNuke2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 2";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function PocketNuke2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData HavocBlast
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 2";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 20.0;
        damageValue = 5;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function HavocBlast::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData BSPulla
{
   mass = 0;
   drag = 1.0;
   density = 2.0;
        elasticity = 0;
        friction = 0;
        className = "Singularity";
   description = "Singularity";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 75.0;
        damageValue = 101;
        damageType = $VulcanDamageType;
        kickBackStrength = -1024;
        triggerRadius = 0.5;
        maxDamage = 100;
};

function BSPulla::onAdd(%this)
{
      schedule("BShaRMSUCK(" @ %this @ ");",2.9,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this  @ ");",3,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function BSHarmSuck(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

MineData BSpull1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData BSpull2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData BSpull3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData BSpull4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}

MineData BSpull5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.25,%this);
}

MineData BSpull6
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull6::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

MineData BSpull7
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull7::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.75,%this);
}

MineData BSpull8
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull8::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData BSpull9
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull9::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;

        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}


MineData MEHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MEHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}

//----------------------------------------------------------------------------

MineData Shrapnel
{
   mass = 0.3;
   drag = 1.0;

  density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Shrapnel";
   description = "Shrapnel";
   shapeFile = "staff";
   shadowDetailMask = 4;
   explosionId = bulletExp0;
	explosionRadius = 1.0;
	damageValue = 0.07;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Shrapnel::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

function DeployShrapnel(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,20,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,20,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-25,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-25,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this, 25,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this, 25,true);
		%count -= 1;
		schedule("DeployShrapnel(" @ %this @ ", " @ %count @ ");",0.5,%this);
	}
}
