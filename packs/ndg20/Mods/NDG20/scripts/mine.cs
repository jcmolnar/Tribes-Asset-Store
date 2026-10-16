MineData AntipersonelMine
{
        className = "Mine";
        description = "Antipersonel Mine";
        shapeFile = "Mine";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 10.0;
        damageValue = 0.75;
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
        if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}
function AntipersonelMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}
function AntipersonelMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}
function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}

MineData HoloMine
{
        className = "Mine";
        description = "Hologram";
        shapeFile = "larmor";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.75;
        damageType = $MineDamageType;
        kickBackStrength = 350;
        triggerRadius = 2.5;
        maxDamage = 2.00;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function HoloMine::onAdd(%this)
{
        %this.damage = 0;
        HoloMine::deployCheck(%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}
function HoloMine::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}
function HoloMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}
function HoloMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}
function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}


// ----======This is the beginning of a new Hologram Mine======------


MineData PlasHoloMine
{
        className = "Mine";
        description = "PlasmaHologram";
        shapeFile = "hellfiregun";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.75;
        damageType = $MineDamageType;
        kickBackStrength = 350;
        triggerRadius = 2.5;
        maxDamage = 2.00;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function PlasHoloMine::onAdd(%this)
{
        %this.damage = 0;
        PlasHoloMine::deployCheck(%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}
function PlasHoloMine::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if ((%type == "Player" || %data == PlasHoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}
function PlasHoloMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("PlasHoloMine::deployCheck(" @ %this @ ");", 3, %this);
}
function PlasHoloMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "PlasmaHologram"]--;
}
function PlasHoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}
//  this is the end of the new Hologram Mine


MineData Booster
{
        className = "Mine";
        description = "Speed Booster";
        shapeFile = "mine";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 8.0;
        damageValue = 0.0;
        damageType = $MineDamageType;
        kickBackStrength = 300;
        triggerRadius = 250;
        maxDamage = 0.0;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function Booster::onAdd(%this)
{
        %this.damage = 0;
        Booster::deployCheck(%this);
}
function Booster::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage);
}
function Booster::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
        }
        else schedule("Booster::deployCheck(" @ %this @ ");", 3, %this);
}
function Booster::onDestroyed(%this)
{
}
function Booster::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}
MineData Hologram
{
        className = "Mine";
        description = "Antipersonel Mine";
        shapeFile = "flag";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 5.0;
        damageValue = 0.75;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 0.0;
        maxDamage = 3.00;
        shadowDetailMask = 0;
        destroyDamage = 2.0;
        damageLevel = {1.0, 1.0};
        lightType = 2;
        lightRadius = 4;
        lightTime = 1.5;
        lightColor = { 1, 1, 1 };
};
function Hologram::onAdd(%this)
{
        %this.damage = 0;
        Hologram::deployCheck(%this);	// PORT: was Boost::deployCheck -- no such function; the hologram never armed
}
function Hologram::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if ((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage);
}
function Hologram::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}
function Hologram::onDestroyed(%this)
{
}
function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $ShrapnelDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}
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
        kickBackStrength = 200;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Handgrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Tranqgrenade
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
        explosionId = Shockwave;
        explosionRadius = 10.0;
        damageValue = 0.15;
        damageType = $EnergyDamageType;
        kickBackStrength = 0;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Tranqgrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Shockgrenade
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
        explosionId = Shockwave;
        explosionRadius = 20.0;
        damageValue = 0.5;
        damageType = $FlashDamageType;
        kickBackStrength = 50;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Shockgrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Concussion
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
        explosionRadius = 15.0;
        damageValue = 0.50;
        damageType = $PlasmaDamageType;
        kickBackStrength = 0;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Concussion::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Nukebomb
{
        mass = 0.3;
        drag = 1.0;
        density = 2.0;
        elasticity = 0.0;
        friction = 99.0;
        className = "Handgrenade";
        description = "Plastique";
        shapeFile = "sensor_small";
        shadowDetailMask = 4;
        explosionId = rocketExp;
        explosionRadius = 10.0;
        damageValue = 2.0;
        damageType = $MortarDamageType;
        kickBackStrength = 300;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Nukebomb::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}
function Nukebomb::onCollision(%this,%obj)
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
        if (%armor == "fearmor" || %armor == "fefemale" || %armor == "harmor")
        {
                %rnd = floor(getRandom() * 10);
                if(%rnd > 8)
                {
                        Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                        Mine::Detonate(" @ %this @ ");
                        return;
                }
                else
                {
                        deleteObject(%this);
                        Client::sendMessage(%c,1,"You disarm the Plastique Explosive.");
                }
        }
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Suicidebomb
{
        mass = 0.3;
        drag = 1.0;
        density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Handgrenade";
        shapeFile = "magcargo";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 50.0;
        damageValue = 4.0;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 300;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Suicidebomb::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Suicidebomb2
{
        mass = 0.3;
        drag = 1.0;
        density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Handgrenade";
        shapeFile = "magcargo";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 70.0;
        damageValue = 4.0;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 300;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Suicidebomb2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",20,%this);
}
function Suicidebomb2::onCollision(%this,%obj)
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
        if (%armor == "fearmor" || %armor == "fefemale" || %armor == "harmor")
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
                        Client::sendMessage(%c,1,"You disarm the DetPack.");
                }
        }
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Mortarbomb
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
        explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1.0;
        damageType = $MortarDamageType;
        kickBackStrength = 250;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Mortarbomb::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData Firebomb
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
        explosionId = flashExpLarge;
        explosionRadius = 30.0;
        damageValue = 0.1;
        damageType = $ElectricityDamageType;
        kickBackStrength = 650;
        triggerRadius = 0.5;
        maxDamage = 2.0;
};
function Firebomb::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}
function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

//*************************************** Added for NDG Renegades *************************************
MineData EMPMine
{
        className = "Mine";
        description = "Antipersonel Mine";
        shapeFile = "Mine";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 30.0;
        damageValue = 0.15;
        damageType = $FlashDamageType;
        kickBackStrength = 150;
        triggerRadius = 3.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function EMPMine::onAdd(%this)
{
        %this.damage = 0;
        EMPMine::deployCheck(%this);
}
function EMPMine::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if (  ( %type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable" ) &&
           GameBase::isActive(%this) && GameBase::getTeam(%this)!=GameBase::getTeam(%object) )
                GameBase::setDamageLevel(%this, %data.maxDamage);
}
function EMPMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("EMPMine::deployCheck(" @ %this @ ");", 3, %this);
}
function EMPMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}
function EMPMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}

//********************* Base Defense Mine ***********************************

MineData BaseDMine
{
        className = "Mine";
        description = "Antipersonel Mine";
        shapeFile = "sensor_jammer";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 30.0;
        damageValue = 0.15;
        damageType = $MineDamageType;
        kickBackStrength = 950;
        triggerRadius = 10.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function BaseDMine::onAdd(%this)
{
        %this.damage = 0;
        BaseDMine::deployCheck(%this);
}
function BaseDMine::onCollision(%this,%object)
{
        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if (  ( %type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable" ) &&
           GameBase::isActive(%this) && GameBase::getTeam(%this)!=GameBase::getTeam(%object) )
                GameBase::setDamageLevel(%this, %data.maxDamage);
}
function BaseDMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("BaseDMine::deployCheck(" @ %this @ ");", 3, %this);
}
function BaseDMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}
function BaseDMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}




//================================= Teleport Mine ==========================================
MineData TeleMine
{
        className = "Mine";
        description = "Antipersonel Mine";
        shapeFile = "Mine";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 10.0;
        damageValue = 0.05;
        damageType = $MineDamageType;
        kickBackStrength = 150;
        triggerRadius = 2.5;
        maxDamage = 0.5;
        shadowDetailMask = 0;
        destroyDamage = 1.0;
        damageLevel = {1.0, 1.0};
};
function TeleMine::onAdd(%this)
{
        %this.damage = 0;
        TeleMine::deployCheck(%this);
}
function TeleMine::onCollision(%this,%object,%player)
{

        %type = getObjectType(%object);
        %data = GameBase::getDataName(%this);
        if ((%type == "Player" || %data == TeleMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
        %sPos = GameBase::getPosition(%player);
        %posX = GetWord(%sPos,0);
        %posY = GetWord(%sPos,1);
        %posZ = GetWord(%sPos,3);
        %newPosZ = %posZ + 100;
        GameBase:setPosition(%player,%posX @ " " @ %posY @ " " @ %newPosZ);
}
function TeleMine::deployCheck(%this)
{
        if (GameBase::isAtRest(%this))
        {
                GameBase::playSequence(%this,1,"deploy");
                GameBase::setActive(%this,true);
                %set = newObject("set",SimSet);
                if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
                {
                        %data = GameBase::getDataName(%this);
                        GameBase::setDamageLevel(%this, %data.maxDamage);
                }
                deleteObject(%set);
        }
        else schedule("TeleMine::deployCheck(" @ %this @ ");", 3, %this);
}
function TeleMine::onDestroyed(%this)
{
        $TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}
function TeleMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
        if (%type == $MineDamageType) %value = %value * 0.25;
        %data = GameBase::getDataName(%this);
        if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
        else %this.damage += %value;
}