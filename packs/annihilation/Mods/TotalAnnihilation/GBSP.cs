//-----------------------------------------
//GroupTrigger::onEnter()
//-----------------------------------------
function SquarePanel::onCollision(%this,%obj)
{
if(%this.num == "1")
{
	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 275; %zVec = 275;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0)
		{ 
		} 
		else if (%rnd == 1) 
		{
		} 
		else if (%rnd == 2) 
		{ 
		}
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 275; %zVec = 275;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 275;
		%zVec = 275;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}
} 