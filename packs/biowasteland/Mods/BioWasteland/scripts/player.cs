$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
	schedule("LavaCheck(" @ %this @ ");",2.0);
}

function Player::onRemove(%this)
{
	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1)
		{
			%item = newObject("","Item",%type,1,false);
         		schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
         		addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	if($debug) echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if ((%this.vehicle).module == "6" && (%type == $ImpactDamageType || %type == $DebrisDamageType) ) return;
	%damagedClient = Player::getClient(%this);
	if (getObjectType(%this) == "Player" && %damagedClient.curse == true) return;
	%damagedName = Client::getName(%damagedClient);
	%damagedTeam = Client::getTeam(%damagedClient);
	%armor = Player::getArmor(%this);

	%shooterClient = %object;
	if (getObjectType(%object) == "Player") %shooterClient = Player::getClient(%object);
	%shooterTeam = Client::getTeam(%shooterClient);
	%shooterName = Client::getName(%shooterClient);

	if (Player::isDead(%this))
		return;

	if (%shooterClient)
		%damagedClient.lastdamager = %shooterClient;
	if ($Game::missionType == "Duel")
	{
		if($DuelLineup[%object] != %damagedClient && %damagedClient != %object)
		{
			centerprint(%shooterClient, "<jc><f2>Wrong Target!",2);
			return;                                         
		}
	}
	if ($Wasteland::JustSpawned[%damagedClient])
	{
		centerprint(%shooterClient, "<jc><f2>"@%damagedName @" Just Spawned!",2);
		centerprint(%damagedClient, "<jc><f2>Spawn Guard: No Damage",1);
		return;
	}
	if (Player::isExposed(%this))
	{
		Player::applyImpulse(%this,%mom);
		//============================ Determin Team Damage
		if($teamplay && %damagedClient != %shooterClient && %damagedTeam == %shooterTeam && $Game::missionType != "Duel" )
		{
			if (%shooterClient)
			{
				%curTime = getSimTime();

			   if ((%curTime - %this.DamageTime > 1.5 || %this.LastHarm != %shooterClient) && (%type != $GravDamageType) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0)
			   {
					if(%type != $MineDamageType)
					{
						systemMessage(%shooterClient,0,"You just harmed Teammate " @ %damagedName @ "!");
						systemMessage(%damagedClient,0,"You took Friendly Fire from " @ %shooterName @ "!");
						if($TestMissionType != "SMR")
						{
			            		%shooterClient.score = (%shooterClient.score -1);
							bottomprint(%shooterClient, "<jc>You harmed your team mate... Score -1 = " @ %shooterClient.score ,3);
						}
					}
					else
					{
						systemMessage(%shooterClient,0,"You just harmed Teammate " @ %damagedName @ " with your mine!");
						systemMessage(%damagedClient,0,"You just stepped on Teamate " @ %shooterName @ "'s mine!");

					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == %damagedTeam)
			%friendFire = $Server::TeamDamageScale;
		else
			%friendFire = 1.0;

		//====================== Reaction Damage
		if ($Wasteland::Reactions)
		{
			if(%vertPos == "torso")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%this,%kick, (%kick/2));
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%this, -%kick, (%kick/2));
					if (%kick > 45)
					{
						%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
						Player::dropItem(%damagedClient,%item);
					}
				}
			}
			else if (%vertPos == "legs")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%this,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 200);
					ixApplyKickback(%this, -%kick, -%kick);
				}
			}
			else if (%vertPos == "head")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 50);
					ixApplyKickback(%this,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%this, -%kick, -%kick);
				}
			}
		}

		//=================== More Damage To Head Shots
		if (!Player::isDead(%this))
		{
			%armor = Player::getArmor(%this);

			if(%vertPos == "head")
			{
				if (%type == $LaserDamageType || %type == $SniperDamageType || %type == PunchType)
				{
					%value += %value;
				}
				else
				{
					if(%armor == "harmor")
					{
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						{
							%value += (%value * 0.2);
						}
					}
					else
					{
						%value += (%value * 0.5);
					}
				}
			}

			//================ Juggernaught Shield
			if ((%armor == "jarmor") && (!%this.shieldStrength))
				Renegades_startShield(%damagedClient, %this);

			//=============== Shield On
			if (%type != -1 && %this.shieldStrength && %type != $BlasterDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;

				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if (%type == $ElectricityDamageType)
					%strength *= 0.0;

				%absorb = %energy * %strength;

				if (%value < %absorb)
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
//================================Crouching protection
			if( Player::isCrouching(%this) && %type != -1 && %type != $BlasterDamageType)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = 0.012;

				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if (%type == $ElectricityDamageType)
					%strength *= 0.0;

				%absorb = %energy * %strength;

				if (%value < %absorb)
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
  					Bottomprint(%damagedClient, "<jc>Crouching saved your arse on that hit.");
				}
				else
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
			//========= Flash Damage Does EMP Effect
			if( ((%type == $FlashDamageType) || (%type == $NukeDamageType)) )
			{
				if(%armor != "aarmor" && %armor != "afemale")
				{
					Insomniax_startEMP(%damagedClient, %this, 14);
					%emptime = (%value * 10);
					if ($debug) echo ("Emp Time = " @ %emptime);
				}
				else systemMessage(%damagedClient,0, "Stealth Armor is immune to EMP effects.");
			}
//========== PlasmaWallDam
			if (%type == $PlasmaWallDam)
			{
				if (%damagedTeam != %shooterTeam)
				{
					%weaponType = Player::getMountedItem(%this,$WeaponSlot);
					Player::dropItem(%this,%weaponType);
					%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
					Player::dropItem(%this, %FlagDrop) ;
					%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
					Player::dropItem(%damagedClient,%item);
					%shooterClient.score = (%shooterClient.score +1);
					systemMessage(%shooterClient,0, %damagedName @ " is disarmed: 1 point = " @ %shooterClient.score);
				}
			}
//========== Booby-Trap Dam
			if (%type == $TrapDam4)
			{
				%chanpos = "0 0 -0.15";
				%npos = Vector::add(gamebase::getposition(%this), %chanpos);
				GameBase::setPosition(%this,%npos);
				
				Client::sendMessage(%damagedClient,1, %shooterName @ "'s Quick-Sand Trap!~wrain.wav");
				%rnd = floor(getRandom() * 100);
				if(%rnd > 85)
				{
					MessageAllExcept(Player::getClient(%damagedClient), 0, %damagedName @ " sinks in " @ %shooterName @ "'s quicksand!");
					%shooterClient.score = %shooterClient.score +1;
  					Bottomprint(%shooterClient, "<jc>Sand Trap Success! Score +1 = " @ %shooterClient.score ,3);
				}
			}
			if (%type == $TrapDam3)
			{
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				Player::dropItem(%this,%weaponType);
				%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
				Player::dropItem(%this, %FlagDrop) ;
				%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
				Player::dropItem(%damagedClient,%item);
				centerprint(%damagedClient, "                                    <Bskull_big.bmp> BOO! <Bskull_big.bmp>");
				MessageAllExcept(Player::getClient(%damagedClient), 0, %damagedName @ " gets the bajeebees scared outta 'em by " @ %shooterName @ "!");
				Client::sendMessage(%damagedClient,1, %shooterName @ "'s Scary Trap! You dropped your load!~wfemale4.wdeath.wav");
				%shooterClient.score = (%shooterClient.score +1);
  				Bottomprint(%shooterClient, "<jc>Scary Trap Success! Score +2 = " @ %shooterClient.score ,3);
			}
			if (%type == $TrapDam1)
			{
				systemMessage(%damagedClient,0,"Phasing Thru Portal!~wdiscspin.wav");
				%portrot = GameBase::getRotation(%object);
				%vec_x = getWord(%portrot,0);
				%vec_y = getWord(%portrot,1);
				%vec_z = getWord(%portrot,2);
				%fixx = ((%vec_x) + 1.57);
				%newrot = %fixx @ " " @ %vec_y @ " " @ %vec_z;
				if (%vec_x == 0)
				{
					%chanpos = "0 0 -4";
					%npos = Vector::add(gamebase::getposition(%this), %chanpos);
					//Client::sendMessage(%damagedClient,3,"floor");
					GameBase::setPosition(%this,%npos);
				}
				else if (%vec_y != 0)
				{
					%chanpos = "0 0 4";
					%npos = Vector::add(gamebase::getposition(%this), %chanpos);
					//Client::sendMessage(%damagedClient,3,"ceiling");
					GameBase::setPosition(%this,%npos);
				}
				else
				{
					%basevec = "0 -4 0";
					%npos = Vector::add(Gamebase::getPosition(%this), EmplacementPack::rotVector( %basevec, %newrot ) );
					GameBase::setPosition(%this,%npos);
					//Client::sendMessage(%damagedClient,3,"wall");
				}
			}
			if (%type == $GrounderType)
			{
				systemMessage(%damagedClient,1,"You've been grounded by " @ %shooterName @ "!~wturretoff2.wav");
				if (%this.driver == 1 || %this.vehicle !="")
				{
					Vehicle::passengerJump(0,%damagedClient,0);
					Client::setControlObject(%damagedClient, %this);
					%this.driver = "";
					%damagedClient.driver = "";
					%this.vehicle = "";
				}
				else if (GameBase::virtual(%this, "getMountObject") >= 1)
				{
					%passenger = gamebase::getcontrolclient(%this);
					%passangerplayer = Client::getOwnedObject(%passenger);
					Vehicle::passengerJump(%this,%passenger,0);
					Client::setControlObject(%passenger, %passangerplayer);
				}
				else
				{
					Player::setItemCount (%damagedClient, StunWt,1);
					schedule ("Player::mountItem( " @ %damagedClient @ ", StunWt,5);",0.3);
				}
				systemMessage(%shooterClient,0,"You've grounded " @ %damagedName @ "! 1 point.~wturretoff2.wav");
				%shooterClient.score = (%shooterClient.score +1);
				Player::trigger(%this,$BackpackSlot,false);
			}
			if (%type == $PunchType)
			{
				Player::setAnimation(%this,16);
			}
			//======================= Merc Booster Pop
			%clientId = %damagedClient;
			if (%armor == "marmor" || %armor == "mfemale")
			{
				if (%clientId.boostercool)
				{
					%rnd = (getRandom());
					if( (%type == $LaserDamageType || %type == $SniperDamageType || %type == $BulletDamageType) && (%quadrant == "back_right" || %quadrant == "back_left" || %quadrant == "middle_back" || %quadrant == "middle_middle") && ( %damagedTeam != %shooterTeam ) )
					{
						if (%rnd > 0.5)
						{
							%value = %value * 10;
							bottomprint(%clientId, "<jc>Your booster popped!");
							DeployFrags(%this, 10, %clientId);
							GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient);
							GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						}
					}
					if ( (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType) && ( %damagedTeam != %shooterTeam ) )
					{
						if (%rnd > 0.6)
						{
							%value = %value * 10;
							bottomprint(%clientId, "<jc>Your booster popped!");
							DeployFrags(%this, 10, %clientId);
							GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.02, 2, %shooterClient);
							GameBase::applyDamage(%player, $PlasmaDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %shooterClient);
						}
					}
				}
			}
			//=========================== Cloaking Blast
			if (%type == $CloakDamageType)
			{
		        	GameBase::startFadeOut(%this);
		        	schedule("GameBase::startFadeIn(" @ %this @ ");", 90);
			}

			//====================== Poison

			if (%type == $EnergyDamageType && ((%damagedTeam != %shooterTeam && $Game::missionType != "Duel") || $Game::missionType == "Duel" && %damagedTeam == %shooterTeam))
			{
				if(%armor != "larmor" && %armor != "lfemale")
				{
					%shooterClient.score = (%shooterClient.score +1);
					bottomprint(%shooterClient, "<jc>You poison "  @ %damagedName @ "!  1 point. Total Score = " @ %shooterClient.score,3);
					systemMessage(%shooterClient,1,"~wfailpack.wav");
					Renegades_startBlind(%damagedClient, %this, %shooterClient);
				}
				else systemMessage(%damagedClient,0, "Assassin is immune to poison.");
			}


			//======================================================= Grav Damage
			if (%type == $GravDamageType){return;}

			//============ Plasma Damage Catches Player On Fire
			if (((%type == $PlasmaDamageType) || (%type == $NukeDamageType)) && (%damagedTeam != %shooterTeam))
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7)
				{
					%armor = Player::getArmor(%this);
					if ( (%armor != "barmor") && (%armor != "bfemale"))
						Renegades_startBurn(%damagedClient, %this);
				}
			}
			//============== Body Area Damage Effects

  			if (%value)
			{
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				%hittolerance = 0.25;
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);

				//============================================ Suicide Pack Explodes
				if((Player::getMountedItem(%this,$BackpackSlot) == FgcPack))
				{
					if( (%type == $LaserDamageType || %type == $SniperDamageType || %type == $BulletDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")  && %damagedTeam != %shooterTeam)
					{
						MessageAllExcept(Player::getClient(%damagedClient), 0, %shooterName @ " sniped the huge bomb on " @ %damagedName @ "'s back!");
						Client::sendMessage(Player::getClient(%damagedClient), 0, "Your Nuclear Pack explodes!");
						Player::unmountItem(%this,$BackpackSlot);
						%obj = newObject("","Mine","Suicidebomb");
						%obj.deployer = %shooterClient;
		 				addToSet("MissionCleanup", %obj);
						%client = Player::getClient(%this);
						GameBase::throw(%obj,%this,9 * %client.throwStrength,false);
					}
				}
				//====================== Weapons Drop On Sniper Shot

				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun"))
				{
					Player::dropItem(%this,%weaponType);
					%dlevel = GameBase::getDamageLevel(%this) + 0.05;
					systemMessage(%shooterClient,0, "You shot the " @ %weaponType @ " out of "  @ %damagedName @ "'s hand!");
				}
				else
				{
					%value = $DamageScale[%armor, %type] * %value * %friendFire;
					%dlevel = GameBase::getDamageLevel(%this) + %value;
				}

            			%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;

				if (%flash > 0.75)
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);

				if(!Player::isDead(%this))
				{
					//=== Check for flag kick on sniper shot - *IX*Savage1
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $LaserDamageType || %type = $SniperDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (%damagedTeam != %shooterTeam))
						DoTheFlagDrop(%this, %shooterClient);

					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = injure1;
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else
				{
					if ($Game::missionType == "Duel")
					{
						%foeId = $DuelLineup[%damagedClient];
						GameBase::PlaySound(%this, DuelFatality, 0);
						GameBase::PlaySound(Client::GetOwnedObject(%foeId), DuelFatality, 0);
					}
					if(%spillOver > 0.5)
					{
						if ($Wasteland::AmmoBoom != "False" && %damagedClient != %shooterClient)
						{
							itemfuncs::ammoboom(%this);
						}
						if (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $ElectricityDamageType || %type == $NukeDamageType)
						{
							Player::trigger(%this, $WeaponSlot, false);
							%weaponType = Player::getMountedItem(%this,$WeaponSlot);
							if(%weaponType != -1)
								Player::dropItem(%this,%weaponType);
							if (%type == $ElectricityDamageType)
								playSound(ShockExplosion,GameBase::getPosition(%this));
						}
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType || %type == $NukeDamageType )) || (Player::getLastContactCount(%this) > 6) )
						{
							if(%quadrant == "front_left" || %quadrant == "front_right")
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) )
							%curDie = $PlayerAnim::Crouching;

						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right")
								%curDie = DieHead;//randomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
							else
								%curDie = DieHead;//randomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso")
						{
							if(%quadrant == "front_left" )
								%curDie = DieLeftSide;//randomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right")
								%curDie = DieChest;//randomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" )
								%curDie = DieLeftSide;//randomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right")
								%curDie = DieGrabBack;//randomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left")
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right")
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}

					if(%type == $ImpactDamageType && %object.clLastMount != "")
						%shooterClient = %object.clLastMount;

					Client::onKilled(%damagedClient,%shooterClient, %type, %vertPos, %quadrant);
				}
			}
		}
	}
}

//==================================================
//==== Collisions With Players 
//==================================================

function Player::onCollision(%this,%object)
{
	%clientId = Player::getClient(%object);
	%objectTeam = GameBase::getTeam(%object);
	%thisId = Player::getClient(%this);
	%thisTeam = GameBase::getTeam(%this);
	if (getObjectType(%object) == "Player") %armor = Player::getArmor(%object);
	if (getObjectType(%this) == "Player") %tarmor = Player::getArmor(%this);
	if (Player::isDead(%this))
	{
		if (getObjectType(%object) == "Player")
		{
			%sound = false;
			%max = getNumItems();

			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				%itemname = getItemData(%i);

				if (%itemname == "Grenade" && %armor != %tarmor)
				{
					%itemname = "";
				}

				if (%itemname == "Beacon" && %armor == "jarmor")
				{
					%itemname = "";
				}

				if (%itemname == "mineammo")
				{
					if (%armor == "earmor" || %armor == "efemale" || %tarmor == "earmor" || %tarmor == "efemale")
					{
					}
					else if (%armor != %tarmor)
					{
						%itemname = "";
					}
				}

				if (%count && %itemname != "")
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0)
					{
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}

			if (%sound) playSound(SoundPickupItem,GameBase::getPosition(%this));
			if (%this.plague ==1 && %object.plague !=1 )
			{
				centerprint(%clientId, "<jc>You've contracted the plague from a diseased corpse.",3);
				startPlague(%clientId, %object);
			}
			if (%thisTeam != %objectTeam)
			{
				if (%tarmor == "lfemale" || %tarmor == "larmor")
				{
					if (%armor == "lfemale" || %armor == "larmor" || $poisonTime[%clientId] > 0)
					{
					}
					else
					{
						centerprint(%clientId, "<jc>You are poisoned by the assassin's items.",3);
						Renegades_startBlind(%clientId, %object, %thisId);
					}
				}
				if (%tarmor == "spyfemale" || %tarmor == "spyarmor")
				{
					if (%armor == "spyfemale" || %armor == "spyarmor")
					{
					}
					else
					{
						centerprint(%clientId, "<jc>That corpse was booby-trapped!",3);
						%obj = newObject("","Mine","Frag3");
						GameBase::throw(%obj,%this,0,false);
						addToSet("MissionCleanup", %obj);
					}
				}
			}
		}
	}

//=============================
//	Bot Collision
//=============================

	if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "false" && (%object != "Flier") && (!Player::isDead(%this) || !Player::isDead(%object)))
	{
		%aiName = Client::GetName(%thisId);
		%aiTeam = Client::GetTeam(%this);
		%objTeam = Client::GetTeam(%object);
		echo("BOT: Collision <" @ %aiName @ " - " @ %thisId @ ">");

//======================== Class Specific

		if (%aiTeam == %objTeam) //===== Make Sure Bot Doesnt Repair Other Teams Stuff
		{
		}

//======================= Attempt Object Move Around

		if((GameBase::testPosition(%thisId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
		{
			%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
			%aiLoc = GameBase::getPosition(Client::getOwnedObject(%thisId));
			%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%thisId));


		   	if (getRandom() > 0.5)
		   		%aiRotation = (%aiRotation + 60);
			else
				%aiRotation = (%aiRotation - 60);

			%Length = 225;
			%Zvalue = $aiRotation;

			%aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue);
			%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%thisId)),2);
			%rotZ = (%rotZ + 90);

			%velocity = 75;

			GameBase::setRotation(Client::getOwnedObject(%thisId), "0 0 " @ %rotZ);

			%jumpDir = Vector::getFromRot(GameBase::getRotation(%thisId),%velocity,%Zvalue);
			Vehicle::passengerJump(0,%thisId,0);		 								 		//Crude way to make players avoid obstacles
			Player::applyImpulse(%thisId, %jumpDir);
		}
		else
        	{
			echo ( %thisId @ " Can not avoid...");
		}

	}
//===================== End AI Collision

//===================== special Armor damages
	if (getObjectType(%object) == "Player" && !Player::isDead(%object) && getObjectType(%this) == "Player" && !Player::isDead(%this) && (($Game::missionType != "Duel" && %objectTeam != %thisTeam) || ($Game::missionType == "Duel" && %objectTeam == %thisTeam ) ) )
	{
//===================== Scout Steal Items
		if (%armor == "sarmor" || %armor == "sfemale" || %armor == "rarmor")
		{
			// Transfer all our items to the player and drop players pack...
			%DropPack = (Player::getMountedItem(%this, $BackPackSlot));
			Player::dropItem(%this, %DropPack) ;

			%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
			Player::dropItem(%this, %FlagDrop) ;

			Player::setDamageFlash(%this,0.75);
			%sound = false;
			%max = getNumItems();

			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				if (%count)
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0)
					{
						Player::decItemCount(%this,%i,%delta);
						if (Player::getMountedItem(%this,$WeaponSlot) == "Fists") {}
						else Player::unmountItem(%this,$WeaponSlot);
						%sound = true;
					}
				}
			}
		}
//===================== arbitor Stealth damage touch
		if ((%armor == "aarmor" || %armor == "afemale") && (%tarmor != "aarmor" && %tarmor != "afemale"))
		{
			GameBase::applyDamage(%this,$FlashDamageType,0.10,GameBase::getPosition(%this),"0 0 0","0 0 0",%clientId);
			if(GameBase::getDamageLevel(%object))
			{
				GameBase::repairDamage(%object,0.30);
			}
			GameBase::playSound(%this,ForceFieldOpen,0);
			systemMessage(%clientId,1, "You drain "  @ Client::getName(%thisId) @ "'s energy...");
		}
//===================== Assassin Poison Touch
		if (%armor == "larmor" || %armor == "lfemale")
		{
			GameBase::applyDamage(%this,$EnergyDamageType,0.25,GameBase::getPosition(%this),"0 0 0","0 0 0",%clientId);
			GameBase::playSound(%this,ForceFieldOpen,0);
			systemMessage(%clientId,1,"You death touch "  @ Client::getName(%thisId) @ ".");
		}
//===================== Spy Skin Steal
		if (%armor == "spyarmor" || %armor == "spyfemale")
		{
			%grabskin = Client::getSkinBase(%thisId);
			Client::setSkin(%clientId,(%grabskin));
			GameBase::playSound(%this,ForceFieldOpen,0);
			systemMessage(%clientId,1,"You go undercover disguised as "  @ Client::getName(%thisId) @ "!" );
		}
//===================== Jugger's Solid Armor
		if ((%armor == "jarmor") && (%tarmor != "jarmor" && %tarmor != "harmor"))
		{
			ixApplyKickback(%this, 500, 70);
			systemMessage(%clientId,1, Client::getName(%thisId) @ " collided off your armor.");
		}
	}
//===================== End Special Armor Damages
//===================== Special Armor Benefits
	if (getObjectType(%this) == "Player" && !Player::isDead(%this) && %objectTeam == %thisTeam)
	{
//============ Eng Touch Heals All
		if (%tarmor == "earmor" || %tarmor == "efemale" && $Wasteland::EngHealAll)
		{
			if (getObjectType(%object) == "Player" && Player::isDead(%object) ) return;
			if(GameBase::getDamageLevel(%object))
			{
				GameBase::repairDamage(%object,0.10);
				bottomprint(%thisId, "<jc><f2>Engineer's Healing Touch",2);
				GameBase::playSound(%object,ForceFieldOpen,0);
			}
		}
//============ Stealth Power Touch
		%obj = GameBase::getDataName(%object);
		if ((%tarmor == "aarmor" || %tarmor == "afemale") && !GameBase::isPowered(%object) && (%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation" || getObjectType(%object) == "Turret") )
		{
			if(%this.powertime > 0 && %this.powerTarget)
			{
				%this.powertime--;
				bottomprint(%thisId,"<jc><f2>Stealth's Touch Powering " @ %obj.description,2);
				GameBase::playSound(%object,ForceFieldOpen,0);
				return;
			}
			else if (%this.powertime < 0 || %this.powertime == 0)
			{
				if (%this.powerTarget)
				{
					%this.powerTarget = "";
					GameBase::playSequence(%object,0,"power");
					GameBase::playSequence(%object,1);
					%object.poweron = "True";
					schedule ("" @ %object @ ".poweron = false;",15);
					schedule ("GameBase::stopSequence(" @ %object @ ",0);",15);
					schedule ("GameBase::pauseSequence(" @ %object @ ",1);",15);
					schedule ("GameBase::pauseSequence(" @ %object @ ",2);",15);
					schedule ("Station::checkTarget(" @ %object @ ");",15);
				}
				else
				{
					%this.powerTarget = "True";
					%this.powertime = 6;
				}
			}
		}
//==================Load SMML
		%c = Player::getMountedItem(%thisId, $BackpackSlot);
		%w = Player::getMountedItem(%clientId,$WeaponSlot);
		if (%c.heading == "uGuided Missiles" && getObjectType(%object) == "Player" && !Player::isDead(%object) && %w == SMML && (%object.load == "" || !%object.load) )
		{
			%vm = $vm[%c];
			if (%vm == "BallProj") systemMessage(%thisId,0,"You cannot load yourself into a SMML tube.~wmale5.wdsgst1.wav");
			else if (%vm == "BooProj")
			{
				systemMessage(%thisId,0,"SMML tubes cannot safely hold a nuclear missile!~wAccess_Denied.wav");
				systemMessage(%clientId,0,Client::getName(%thisId) @ " tried to load your SMML with a nuclear missile!~wAccess_Denied.wav");
				Player::setItemCount(%this, %c, 0);
				$TeamItemCount[%thisTeam @ %c]++;
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%object,0,true);
			}
			else
			{
				systemMessage(%thisId,0,Client::getName(%clientId) @ " is loaded with a " @ %vm.description @ ".");
				playSound(SoundMortaReload,GameBase::getPosition(%object));
				systemMessage(%clientId,0,Client::getName(%thisId) @ " loaded you with a " @ %vm.description @ ".");
				Player::setItemCount(%this, %c, 0);
				$TeamItemCount[%thisTeam @ %c]++;
				%object.load = %vm;
			}
		}
	}
//==================Plague
	if (getObjectType(%object) == "Player" && !Player::isDead(%object) && getObjectType(%this) == "Player" && !Player::isDead(%this) && %object.plague ==1 && %this.plague !=2)
	{
		%object.plague=2;
		schedule ("" @ %object @ ".plague = 0;",2);
		systemMessage(%clientId,1,"You pass the plague on to "  @ Client::getName(%thisId) @ "." );
		%this.plague=1;
		bottomprint(%thisId, "<jc>You've contracted the plague from " @ Client::getName(%clientId)@"!",3);
		startPlague(%thisId, %this);
	}
//==================Titan Crush
	if (getObjectType(%this) == "Player" && !Player::isDead(%this) && %tarmor == "tarmor" && getObjectType(%object) != "Player" )
	{
		%name = GameBase::getMapName(%object);
		if(%name == "") %name = (GameBase::getDataName(%object)).description;
		bottomprint(%thisId, "<jc>Crushing " @ %name @"!",2);
		GameBase::applyDamage(%object, $CrushDamageType, 5, GameBase::getPosition(%object), "0 0 0", "0 0 0", %thisId);
	}
}

//=========================== Get Heat Factor
function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);

	if (Client::getControlObject(%client) != %this)
		return 1.0;

	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if ((%lastTime + 1.5) < %time)
	{
		return 0.0;
	}
	else
	{
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

//=========================================== Jump To Mount Point

function Player::jump(%this,%mom)
{

   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
	%vehicle = Player::getMountObject (%this);
	%this.lastMount = %vehicle;
	%this.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%this, %vehicle, 0);
	Player::setMountObject(%this, -1, 0);
	Player::applyImpulse(%pl,%mom);
	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
   }
}

//============== Outside Mission Area Damage

function Player::leaveMissionArea(%player)
{
	if (Player::isDead(%player)) return;
	%cl = Player::getClient(%player);
	if(%cl != -1) %clname = Client::getName(%cl);
	MessageAllExcept(%cl, 0, %clname @ " has left the mission area.");
	Client::sendMessage(%cl,1,"You have left the mission area.");
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	if (%pack == "PowerGeneratorPack" || %pack == "BunkerPack" || %pack == "AirBase" || %pack == "SkyEyePack" || %pack == "AntennaPack" || %pack == "ReconPack" || %pack == "JailPack" || %pack == "FgcPackImage")
	{
		if (%pack == "FgcPackImage") %pack = "Nuclear Pack";
		%obj = newObject("","Mine","EMPBlast");
		GameBase::throw(%obj,%player,0,true);
	   	GameBase::applyDamage(%player,$FlashDamageType, 5.0,GameBase::getPosition(%this),"0 0 0","0 0 0",%cl);
		%cl.score = %cl.score - 25;
		bottomprint(%cl, "You were carrying a strategic deployable, naughty naughty.",3);
		MessageAllExcept(%cl, 0, %clname @ " was trying to cheat buy taking a " @ %pack @ " outside the mission area, and has been terminated.~wfemale2.wcolor3.wav");
		Client::sendMessage(%cl,1,"You were carrying a " @ %pack @ ", naughty naughty.");
		Game::refreshClientScore(%cl);
		return;
	}
  	if($Wasteland::NoOutside)
  	{
		systemMessage(%cl,1,"In 10 seconds, you will start to die!");
		%player.outArea=1;
		alertPlayer(%player, 5);
		%oldpack = %cl.oldpack;
		if (%oldpack == "PowerGeneratorPack" || %oldpack == "BunkerPack" || %oldpack == "airbase" || %oldpack == "SkyEyePack" || %oldpack == "AntennaPack" || %oldpack == "ReconPack" || %oldpack == "JailPack") %cl.oldpack = "";
  	}
}

function alertPlayer(%player, %count)
{
	%clientId = Player::getClient(%player);
	if(%player.outArea == 1)
	{
	  	systemMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count == 4)
		{
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  		GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
			schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		}
		else if(%count > 1)
		   	schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		else
		   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
	else
	{
		MessageAllExcept(%clientId, 0, Client::getName(%clientId) @ " has returned to the mission area.");
		Client::sendMessage(%clientId,1,"You have returned to the mission area.~wbuysellsound.wav");
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1)
	{
		if(!Player::isDead(%player))
		{
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
   			schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else
			playNextAnim(%client);
	}
}



//==============================================
function playNextAnim(%client)
{
	if($animNumber > 36)
		$animNumber = 25;
	Player::setAnimation(%client,$animNumber++);
}

function Client::takeControl(%clientId, %objectId)
{
	if(%objectId == -1){return;}

	// If mounted to a vehicle then can't mount any other objects
	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}

        %player = Client::getOwnedObject(%clientId);
        %name = GameBase::getDataName(%objectId);
        %armor = Player::getArmor(%clientId);

        if(Player::getMountedItem(%player,$BackpackSlot) != Laptop && (%armor != "sarmor" || %armor != "sfemale" ))
        {
                if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableMini && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats)
                {
                        Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
                        return;
                }
        }

   	if(GameBase::getDamageState(%objectId) == "Enabled")
   	{
   		Client::setControlObject(%clientId, %objectId);
   		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
   	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}

//=================================== EMP Effects

function Insomniax_startEMP(%clientId, %player, %time)
{

	systemMessage(%clientId,1,"You were hit with EMP!");
	Player::unmountItem(%player,$WeaponSlot);
	%armor = player::getarmor(%player);

	if($empTime[%clientId] == 0)
	{
		if (%armor == earmor || %armor == efemale)
		{
			GameBase::setEnergy(%player,45);
			GameBase::setRechargeRate(%player,2);
			$empTime[%clientId] = 8;
			checkPlayerEMP(%clientId, %player);
		}
		else
		{
			GameBase::setEnergy(%player,0);
			GameBase::setRechargeRate(%player,0);
			$empTime[%clientId] = 12;
			checkPlayerEMP(%clientId, %player);
		}
	}
	else
	{
		if (%time)
			$empTime[%clientId] = %time;
		else
			$empTime[%clientId] = 14;
	}
}

function checkPlayerEMP(%clientId, %player)
{

	if($empTime[%clientId] > 0)
	{
		$empTime[%clientId] -= 2;
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
	else if(!Player::isDead(%player))
	{
		systemMessage(%clientId,1,"EMP Effects have dissapated.");
		GameBase::setRechargeRate(%player,8);
	}
}

//========================== Poisoning

function Renegades_startBlind(%clientId, %player, %shooterClient)
{
	if (%player.tc == true)
	{
		systemMessage(%clientId,3,"You are immune to poison!~wfailpack.wav");
		return;
	}
	else systemMessage(%clientId,1,"You are poisoned!~wfailpack.wav");
	if($poisonTime[%clientId] != 0) $poisonTime[%clientId] = 15;
	else
	{
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 15;
		checkPlayerBlind(%clientId, %player, %shooterClient);
	}
}
function checkPlayerBlind(%clientId, %player, %shooterClient)
{
	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.07;
		if  (!Player::isDead(%player))
		{
			GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.75);
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " died from a strange disease.");
				%player.plague=1;
				%shooterClient.score = %shooterClient.score +3;
				%shooterClient.scoreKills = %shooterClient.scoreKills +1;
  				Bottomprint(%shooterClient, "<jc>Poison Success! Score +3 = " @ %shooterClient.score ,3);
				%clientId.scoreDeaths++;
				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$poisonTime[%clientId] = 0;
			}
		}
		else $poisonTime[%clientId] = 0;
		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ", " @ %shooterClient @ ");",5,%player);
      }
	else
	{
		if  (!Player::isDead(%player))
		{
			systemMessage(%clientId,1,"The effects of the poison wear off.");
			if ($poisonTime[%clientId] <0)
			{
				%player.tc = true;
				systemMessage(%clientId,3,"You survived the poison and are now immunized!");
			}
			$poisonTime[%clientId] = 0;
		}
		else %player.plague=1;
	}
}

//=================== Plague
function startPlague(%clientId, %player)
{
	systemMessage(%clientId,1,"You've got the Plague!~wammo_power.wav");
	Player::setDamageFlash(%player,0.75);
	%player.plague=1;
	checkPlayerPlague(%clientId, %player);
}

function checkPlayerPlague(%clientId, %player)
{
	if(%player.plague==1)
	{
		%drrate = GameBase::getDamageLevel(%player) + 0.07;
		if  (!Player::isDead(%player))
		{
			GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.1);
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " succumbed to the plague.");
				Game::refreshClientScore(%clientId);
				%clientId.scoreDeaths++;
				%clientId.score--;
			}
			schedule("checkPlayerPlague(" @ %clientId @ ", " @ %player @ ");",5,%player);
		}
      }
}

//========================== Flamer Burn

function Renegades_startBurn(%clientId, %player)
{

	systemMessage(%clientId,1,"You are on fire!");

	if($burnTime[%clientId] == 0)
	{
		Player::setDamageFlash(%player,0.50);
		$burnTime[%clientId] = 5;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 7;
}

function checkPlayerBurn(%clientId, %player)
{

	if($burnTime[%clientId] > 0)
	{
		$burnTime[%clientId] -= 1;
		%drrate = GameBase::getDamageLevel(%player) + 0.01;
		if  (!Player::isDead(%player))
		{
			GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.50);
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " was incinerated.");
				%clientId.scoreDeaths++;
      			%clientId.score--;
				Game::refreshClientScore(%clientId);
				$burnTime[%clientId] = 0;
			}
		}
		else
		{
			$burnTime[%clientId] = 0;
		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",1,%player);
     	}
	else if(!Player::isDead(%player))
	{
		systemMessage(%clientId,1,"You stopped burning.");
	}
}

//============================================================================= Flag Shot Off
function DoTheFlagDrop(%player, %shooterId)
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	%shooterName = Client::getName(%shooterId);

	if (%shooterid)
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!");
			TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
		}
	}
	else
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %dropClientName @ " has butter fingers and dropped the flag.");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %dropClientName @ " has butter fingers and dropped the flag.");
		}
	}
	GameBase::throw(%flag, %player, -15, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}