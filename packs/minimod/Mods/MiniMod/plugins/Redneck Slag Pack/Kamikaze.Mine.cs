//----------------------------
// Kamikaze Bomb
//----------------------------
MineData KamikazeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Kamikaze Bomb";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = KamikazeExp;
	explosionRadius = 15.0;
    damageValue = 5.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}