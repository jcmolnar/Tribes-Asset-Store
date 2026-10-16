

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if(%type == 999) {
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object)) return;
		%damageLevel = GameBase::getDamageLevel(%this);
		%dValue = %damageLevel - %value;		
		if(%dValue < 0) %dValue = 0;
		GameBase::setDamageLevel(%this,%dValue);
		return;
	}

	%name = GameBase::getDataName(%this);
	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   %this.lastDamageObject = %object;
   %this.lastDamageTT = %type;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if(%name.className == Generator || (%name.className == Station && %name != "DeployableComStation")) { 
      %team = GameBase::getTeam(%this);
      %tempNumPlayers = getNumClients();
      %numPlayers = 0;
      for(%i = 0; %i < %tempNumPlayers; %i++) {
         %cl = getClientByIndex(%i);
         if( Client::getTeam(%cl) == %team && !Observer::isObserver(%cl) )
            %numPlayers++;
      }
		if ( $HaVoC::MinPlayersForBaseRape > 4 ) $HaVoC::MinPlayersForBaseRape = 4;
      if ( (%numPlayers <= $HaVoC::MinPlayersForBaseRape && %numPlayers > 0) || %team == %this.lastDamageTeam ) {
   		%TDS = $Server::TeamDamageScale;
   		%dValue = %damageLevel + %value * %TDS;
   		%disable = GameBase::getDisabledDamage(%this);
   		if ( (%numPlayers <= 2 || !$Server::TourneyMode) && %dValue > %disable - 0.05) {
            if(%damageLevel > %disable - 0.05) {
               return;
      	   } else {
					if( %team != %this.lastDamageTeam && $lastBaseRapeMessageTime < getSimTime() ) {
						$lastBaseRapeMessageTime = getSimTime() + 2; 
						Client::sendMessage(%object, 1, "You cannot destroy enemy equipment until they have more than " @ $HaVoC::MinPlayersForBaseRape @ " players." );
					}
               %dValue = %disable - 0.05;
   			}
   		}
      }
	}
	GameBase::setDamageLevel(%this,%dValue);
}


