$InvList[PoisonGasGrenade] = 1;
$RemoteInvList[PoisonGasGrenade] = 1;
$AutoUse[PoisonGasGrenade] = 0;
$CoreType[PoisonGasGrenade] = "Grenade";
$Core[Grenade, $GrenadeInitCounter++] = PoisonGasGrenade;

$SellAmmo[PoisonGasGrenade] = 12;

// Who can use this grenade and how much they can carry
$ItemMax[reconarmor, PoisonGasGrenade] = 0;
$ItemMax[reconfemalearmor, PoisonGasGrenade] = 0;
$ItemMax[espionagearmor, PoisonGasGrenade] = 0;
$ItemMax[espionagefemalearmor, PoisonGasGrenade] = 0;
$ItemMax[engineerarmor, PoisonGasGrenade] = 0;
$ItemMax[engineerfemalearmor, PoisonGasGrenade] = 0;
$ItemMax[infantryarmor, PoisonGasGrenade] = 0;
$ItemMax[infantryfemalearmor, PoisonGasGrenade] = 0;
$ItemMax[falloutarmor, PoisonGasGrenade] = 6;
$ItemMax[falloutfemalearmor, PoisonGasGrenade] = 6;
$ItemMax[demolitionsarmor, PoisonGasGrenade] = 0;
$ItemMax[assaultarmor, PoisonGasGrenade] = 0;
$ItemMax[artilleryarmor, PoisonGasGrenade] = 0;
$ItemMax[commanderarmor, PoisonGasGrenade] = 0;

ItemData PoisonGasGrenade
{
	description = "- Poison Gas Core";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 15;
	className = "HandAmmo";
};

function PoisonGasGrenade::onUse(%player, %item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			// Let's make sure they have a grenade to put this core into
			if (Player::incItemCount(%player, Grenade, 0) > 0) {

				// Get some valuable info
				%client = Player::getClient(%player);
	
				// Get the next available poison gas cloud index
				%next = PoisonGasCloud::getNextIndex();
	
				// If maximum number of gas clouds is not exceeded
				if (%next != -1) {
					Player::decItemCount(%player, Grenade);	
					Player::decItemCount(%player,%item);
					%obj = newObject("","Mine","mPoisonGasGrenade");
		 	 	 	addToSet("MissionCleanup", %obj);
	
					// Set the poison gas cloud data
					$PoisonGasCloudOwner[%next] = %player;
					$PoisonGasCloudIndex[%obj] = %next;
					$PoisonGasCloudObject[%next] = %obj;
					$PoisonGasCloudTTG[%next] = 5.0;
	
					GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
					%player.throwTime = getSimTime() + 0.5;
				}
				else {
	
					// We tell the user that there are too many gas clouds
					Client::sendMessage(%client, 1, "Gas Cloud Limit reached!");
				}
			}
			else {
				Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a grenade.");
			}
		}
	}
}

ExplosionData PoisonGasGrenadeExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0.0;

   timeScale = 10.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 1.0, 0.0 };
   colors[1]  = { 0.0, 1.0, 0.0 };
   colors[2]  = { 0.0, 1.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };
};

MineData mPoisonGasGrenade { 
 	mass = 0.3;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.15;
 	friction = 1.0;
 	className = "Handgrenade";
 	description = "Handgrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = PoisonGasGrenadeExp;
 	explosionRadius = 10.0;
 	damageValue = 0.01;
 	damageType = $PoisonGasDamageType;
 	kickBackStrength = 0;
 	triggerRadius = 1.0;
 	maxDamage = 0.01;
};

function mPoisonGasGrenade::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 3.0, %this);
}

function mPoisonGasGrenade::onDestroyed(%this) { 

	%radius = 10.0;
	%type = $PoisonGasDamageType;
	// %dur = 5.0;

	// Create a Gas Canister Mine
	%canister = newObject("", "Mine", "GasCanisterMine");

	addToSet("MissionCleanup", %canister);
	GameBase::setPosition(%canister, GameBase::getPosition(%this));

	// Let's set it to a different team so gas will hurt everyone
	GameBase::setTeam(%canister, GameBase::getTeam(%this));
	// GameBase::setTeam(%canister, 7);

	Gamebase::setMapName(%canister, "Poison Gas Canister");

	// Get gas cloud index
	%index = $PoisonGasCloudIndex[%this];

	// Set new gas cloud data
	$PoisonGasCloudPosition[%index] = GameBase::getPosition(%this);
	// $PoisonGasCloudTTG[%index] = %dur;

	$PoisonGasCloudObject[%index] = %canister;
	$PoisonGasCloudIndex[%canister] = %index;

	// Increment total gas clouds
	$PoisonGasCloudTotal ++;


	// If this is our first gas cloud
	if ($PoisonGasCloudTotal == 1) {

		// Make the clock start ticking
		schedule("PoisonGasCloud::updateAll(false);", 1.0);
	}
}

