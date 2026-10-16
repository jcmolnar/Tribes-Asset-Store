function Player::onKilled(%this)
{
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	if($KamikazeIsActive[%this]) { //RSP Kami Pack Reset
		Client::sendMessage(%cl,0,"Kamikaze run failed!");
		$KamikazeIsActive[%this] = "false";
	}

	if($MPCIsActive[%this] || $MPCUsed[%this]) { //RSP MPC Pack reset
		$MPCIsActive[%this] = false;
		$MPCUsed[%this] = false;
	}

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1 && $ServerMissionType == "Deathmatch")	
	{
		GameBase::setDamageLevel(%this, 100);
		Player::setAnimation(%this, $PlayerAnim::DieChest);
		Client::onKilled(%cl,%cl, 0);
	}
	
	Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
      schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
      schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}