//----------------------------------------------------------------------------
// turret sound

SoundData SoundMount
{
   wavFileName = "Mount.wav";
   profile = Profile3dNear;
};
SoundData SoundDismount
{
   wavFileName = "dismount.wav";
   profile = Profile3dNear;
};
//==================================
SoundData SoundFusionTurretOn
{
   wavFileName = "tur_fusion_on.wav";
   profile = Profile3dMedium;
};
SoundData SoundFusionTurretOff
{
   wavFileName = "tur_fusion_off.wav";
   profile = Profile3dMedium;
};
SoundData SoundFusionTurretTurn
{
   wavFileName = "tur_fusion_Turn.wav";
   profile = Profile3dMed;
};

SoundData SoundPlasmaTurretOn
{
   wavFileName = "turretOn4.wav";
   profile = Profile3dNear;
};

SoundData SoundPlasmaTurretOff
{
   wavFileName = "turretOff4.wav";
   profile = Profile3dNear;
};

SoundData SoundPlasmaTurretFire
{
   wavFileName = "tur_fusion.wav";
   profile = Profile3dMedium;
};

SoundData SoundPlasmaTurretTurn
{
   wavFileName = "turretTurn4.wav";
   profile = Profile3dNear;
};


//
SoundData SoundChainTurretOn
{
   wavFileName = "turretOn1.wav";
   profile = Profile3dNear;
};

SoundData SoundChainTurretOff
{
   wavFileName = "turretOff1.wav";
   profile = Profile3dNear;
};

SoundData SoundChainTurretTurn
{
   wavFileName = "turretTurn1.wav";
   profile = Profile3dNear;
};

SoundData SoundChainTurretFire
{
   wavFileName = "machinegun.wav";
   profile = Profile3dMedium;
};

//
SoundData SoundMissileTurretOn
{
   wavFileName = "turretOn1.wav";
   profile = Profile3dNear;
};

SoundData SoundMissileTurretOff
{
   wavFileName = "turretOff1.wav";
   profile = Profile3dNear;
};

SoundData SoundMissileTurretTurn
{
   wavFileName = "turretTurn1.wav";
   profile = Profile3dNear;
};

SoundData SoundMissileTurretFire
{
   wavFileName = "Turret_missile.wav";
   profile = Profile3dMedium;
};

//
SoundData SoundMortarTurretOn
{
   wavFileName = "turretOn2.wav";
   profile = Profile3dNear;
};

SoundData SoundMortarTurretOff
{
   wavFileName = "turretOff2.wav";
   profile = Profile3dNear;
};

SoundData SoundMortarTurretTurn
{
   wavFileName = "turretTurn2.wav";
   profile = Profile3dNear;
};

SoundData SoundMortarTurretFire
{
   wavFileName = "turret_mortar.wav";
   profile = Profile3dMedium;
};

//
SoundData SoundEnergyTurretOn
{
   wavFileName = "turretOn4.wav";
   profile = Profile3dNear;
};

SoundData SoundEnergyTurretOff
{
   wavFileName = "turretOff4.wav";
   profile = Profile3dNear;
};

SoundData SoundEnergyTurretTurn
{
   wavFileName = "turretTurn4.wav";
   profile = Profile3dNear;
};

SoundData SoundEnergyTurretFire
{
   wavFileName = "turret_indoor.wav";
   profile = Profile3dMedium;
};

//
SoundData SoundRemoteTurretOn
{
   wavFileName = "turretOn2.wav";
   profile = Profile3dNear;
};

SoundData SoundRemoteTurretOff
{
   wavFileName = "turretOff2.wav";
   profile = Profile3dNear;
};

SoundData SoundRemoteTurretTurn
{
   wavFileName = "turretTurn2.wav";
   profile = Profile3dNear;
};

SoundData SoundRemoteTurretFire
{
   wavFileName = "turret_remote.wav";
   profile = Profile3dMedium;
};
//================================================================================


//----------------------------------------------------------------------------
exec(tur_sonic);
exec(tur_Laser);
exec(tur_mortar);
exec(tur_rocket);
exec(tur_missile);
exec(tur_fusion);
exec(tur_elf);
exec(tur_indoor);
//======================
exec(deptur_raptor);
exec(deptur_slayer);
exec(deptur_sentry);
exec(deptur_Laser);
//---------------------------------------------------

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Turret");
	}
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);

}

function Turret::checkOperator(%this)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}
/////////////////////////////////////////////////////////////////////////////////////////////////
			// controlable turrets
/////////////////////////////////////////////////////////////////////////////////////////////////

function Turret::jump(%this,%mom)
{
	if(GameBase::getDataName(%this) == "RocketTurret" || GameBase::getDataName(%this) == "LaserTurret")
		Turret::dismount(%this, %mom);
	else
		Turret::changeControl(%this);
}

function Turret::dismount(%this,%mom)
{
	//echo("Dismount called");
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		%armor = Player::getArmor(%pl);
		if(%armor == "larmor" || %armor == "lfemale" || %armor == "marmor" || %armor == "marmor" || %armor == "harmor") {
			%height = 1;
			%velocity = 1;
			%zVec = 1;
		}
		
		%pos = GameBase::getPosition(%pl);
		%posX = getWord(%pos,0);
		%posY	= getWord(%pos,1);
		%posZ	= getWord(%pos,2);
		
		if(GameBase::testPosition(%pl,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
		{	
			%pl.lastMount = %this;
			%pl.newMountTime = getSimTime() + 3.0;
			//Player::setMountObject(%pl, -1,0);
			%rotZ = getWord(GameBase::getRotation(%pl),2);
			GameBase::setRotation(%pl, "0 0 " @ %rotZ);
			GameBase::setPosition(%pl,%posX @ " " @ %posY @ " " @ (%posZ + %height));
			
			Client::setControlObject(%cl, %pl);
			$turretControlled[%this] = FALSE;
			playSound(soundFlyerDismount, GameBase::getPosition(%pl));
			if(%pl.lastWeapon != "") 
			{
				Player::useItem(%pl,%pl.lastWeapon);		 	
				%pl.lastWeapon = "";
				//unfocus(%object, %this);
			}
			%pl.driver = "";
			%pl.turret = "";
			
			%jumpDir = Vector::getFromRot(GameBase::getRotation(%pl),%velocity,%zVec);
			Player::applyImpulse(%pl,%jumpDir);
		}
		else
			Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wmsg_error.wav");
	}
}

function Turret::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage)
	{
		if(GameBase::getDataName(%this) == "RocketTurret" || GameBase::getDataName(%this) == "LaserTurret")
		{
			%client = Player::getClient(%object);
			if( GameBase::getDamageState(%this) == "Enabled" )
			{
				if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || $NoneTeamAccess[%this] == TRUE)
				{
					if( !$turretControlled[%this] == TRUE)
					{
						if(getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
						{
							if( Player::isAiControlled(%object))
								return;
							
							%armor = Player::getArmor(%object);
							
							%weapon = Player::getMountedItem(%object,$WeaponSlot);
							if(%weapon != -1)
							{
								%object.lastWeapon = %weapon;
								Player::unMountItem(%object,$WeaponSlot);
							}
							//Player::setMountObject(%object, %this, 0);
							%pos = GameBase::getPosition(%this);
							%rot = GameBase::getRotation(%this);
							if( GameBase::getDataName(%this) == "RocketTurret" )
							{
								%playerpos = Vector::getFromRot(%rot, -8);
							}
							else if( GameBase::getDataName(%this) == "LaserTurret" )
							{
								%playerpos = Vector::getFromRot(%rot, -7.5);
							}
							%playerpos = Vector::add(%playerpos , %pos);
							GameBase::setPosition(%object, %playerpos);
							GameBase::setRotation(%object, %rot);
							
							Client::setControlObject(%client, %this);	
							$turretControlled[%this] = TRUE;
							playSound(soundFlyerMount, GameBase::getPosition(%this));
							%object.driver= 1;
							%object.vehicle = %this;
							%this.clLastMount = %client;

							//Recursive check for when people leave by not jumping
							schedule("Turret::AmIControlled("@%this@");", 6.0, %this);
						}
					}
				}
				else
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~wmsg_error.wav");
			}
			else
				Client::sendMessage(%client,0,"Unit is disabled");
		}
	}
}

function Turret::AmIControlled(%this)
{
	if( $turretControlled[%this] == TRUE )
	{
		if( GameBase::getControlClient(%this) == -1 )
			$turretControlled[%this] = FALSE;
		else
			schedule("Turret::AmIControlled("@%this@");", 6.0, %this);
	}
}
