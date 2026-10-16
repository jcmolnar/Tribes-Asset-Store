///-----------------------------------------------
/// description = "Suicide DetPack";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

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
//------------
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
                                                        Client::sendMessage(%c,1,"You disarm the DetPack.");
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