//----------------------------------------------------------------------------
// Ultra Warfare -- 1.50 port glue. Exec'd from createServer (Ultra_Warfare.cs)
// after every data block script and before preloadServerDataBlocks().
// Nothing in here changes how the 2003 release played, except SpringPad.
//----------------------------------------------------------------------------

// JumpZone (44 pads) and SkyHigh (4 pads) place a StaticShape "SpringPad" that no
// Ultra Warfare script ever declared, so both maps loaded without their pads.
// Same block the game's own staticshape.cs carries for those maps; the bounce
// sound is one this mod declares (the stock one, SoundFireMortar, is not).
StaticShapeData SpringPad
{
	description = "Spring Pad";
	shapeFile = "elevator_4x4";
	className = "Misc";
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	maxDamage = 10000.0;
	visibleToSensor = "false";
};

function SpringPad::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
}

function SpringPad::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
		return;
	GameBase::playSound(%this, debrisLargeExplosion, 0);
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj), 50, 475);
	Player::applyImpulse(%obj, %jumpDir);
}

// The four names below are called by the mod's scripts but were never defined in
// the release (code carried over from Shifter). Each call printed
// "Unknown command" and did nothing. They stay doing nothing here: the mod never
// had sniper flag drops or ammo explosions, and adding them now would change it.
function DoTheFlagDrop(%player, %shooterClient)
{
}

function itemfuncs::ammoboom(%this)
{
}

function gwVerifyMap()
{
}

// Turret::jump sends every remote-controlled turret except the Rocket and Laser
// turrets here. Stock Tribes hands control back to the player on jump; do that.
function Turret::changeControl(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
		checkControlUnmount(%cl);
}
