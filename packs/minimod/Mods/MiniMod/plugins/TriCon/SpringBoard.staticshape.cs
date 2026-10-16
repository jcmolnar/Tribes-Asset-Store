///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData Springboard
{
        shapeFile = "flagstand";
        debrisId = defaultDebrisSmall;
        maxDamage = 2.00;
        visibleToSensor = false;
        isTranslucent = true;
        description = "Deployable Spring";
        visibleToSensor = true;
};

function Springboard::onDestroyed(%this)
{
        StaticShape::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "Springboard"]--;
}

function Springboard::onCollision(%this,%obj)
{
        %c = Player::getClient(%obj);
        %vecVelocity = Item::getVelocity(%obj);
        %rnd = floor(getRandom() * 55);
       if (%rnd == 1)
        {
                GameBase::playSound(%this, debrisLargeExplosion, 0);
                %HMult = 50;
                %ZMax = 200;

                %rnd = floor(getRandom() * 3);

        }
        else if (%rnd > 45)
                {
                GameBase::playSound(%this, debrisLargeExplosion, 0);

                %HMult = 2;
                %ZMax = 150;
        }
        else
        {
                GameBase::playSound(%this, SoundFireMortar, 0);

                %HMult = 2;
                %ZMax = 45;
        }
        %vecNewVelocity = GetWord(%vecVelocity, 0) * %HMult @ " " @
                          GetWord(%vecVelocity, 1) * %HMult @ " " @
                          %ZMax;
        Item::setVelocity(%obj, %vecNewVelocity);
}