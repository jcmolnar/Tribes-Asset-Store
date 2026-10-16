
function getMuzzleTransFromRot(%rot) {
   %ai = AI::getId("DaJackalMan");
   if (!%ai) {
      Ai::spawn("DaJackalMan", "larmorholo", "10000 10000 10000", "0 0 0");
      %ai = AI::getId("DaJackalMan");
   }
   GameBase::setRotation(%ai, %rot);
   %aiTrans = GameBase::getMuzzleTransform(%ai);
   for(%i=0; %i<=8; %i++)
   	%trans = %trans @ getWord( %aiTrans, %i ) @ " ";
   return %trans;
}

function getMuzzleRot(%player) {
   %trans = GameBase::getMuzzleTransform(%player);
   %vel = Item::getVelocity(%player);
   %tempProj = Projectile::spawnProjectile("NullGuy", %trans, %player, %vel, %player);
   %rot = GameBase::getRotation(%tempProj);
   deleteObject(%tempProj);
   return %rot;
}

function getMuzzlePos(%player) {
   %trans = GameBase::getMuzzleTransform(%player);
   %pos = getWord( %trans, 9 ) @ " ";
   %pos = %pos @ getWord( %trans, 10 ) @ " ";
   %pos = %pos @ getWord( %trans, 11 );
   return %pos;
}

function throwNewGren(%player, %grenType, %str) {
   if (%str < 0.45 ) {
      %grenType = %grenType @ "1";
      %up = 0.13;
   } else if (%str < 0.9 ) {
      %grenType = %grenType @ "2";
      %up = 0.3;
   } else {
      %grenType = %grenType @ "3";
      %up = 0.3;
   }
   %rot = getMuzzleRot(%player);
   %rot = (getWord(%rot, 0) + %up) @ " " @ getWord(%rot, 1) @ " " @ getWord(%rot, 2);
   %trans = getMuzzleTransFromRot(%rot) @ getMuzzlePos(%player);
   %vel = Item::getVelocity(%player);
   return Projectile::spawnProjectile(%grenType, %trans, %player, %vel, %player);
}

function Grenade::onUse(%player,%item) { 
   if(%player.inStation) return;
   %client = Player::getClient(%player);
   if(%client.possessed || %client.possessing) return;
   
   if(%client.poisonTime > 0) {
   	Client::sendMessage(%client,1,"Unable to use grenades while poisoned~waccess_denied.wav"); 	
   	return;
   }
   
   if($matchStarted) { 
   	if(%player.throwTime < getSimTime() ) { 
         %str = %client.throwStrength;
   		%armor = Player::getArmor(%player); 
         %grenType = "";
         %obj = "";
   		if (%armor == "larmor" || %armor == "lfemale") {
            %prot = GameBase::getRotation(%player);
            if ( %str < 0.8 )
               %rot = getWord(%prot, 0) @ " " @ getWord(%prot, 1) @ " " @ (getWord(%prot, 2) * -1);
            if ( GameBase::getLOSInfo(%player, 3, %rot) ) {
   				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
   				return;
            }
   			%HologramName = Client::getName(%client) @ " ";   
   			if($Hologram[%HologramName] != "") {
   				%HologramName = %HologramName @ " ";	
   				if($Hologram[%HologramName] != "") {
   					%HologramName = $killh[%player];
   					%hID = AI::getId(%HologramName);   
                  if ( %hID ) {
                     playNextAnim(%hID);
      					Player::kill(%hID); 
                  }
   					Player::decItemCount(%player,%item); 
   					schedule("makem(" @ %client @ ", " @ %player @ ", \"" @ escapeString(%HologramName) @ "\", " @ %str @ ");", 0.1);
   					%player.throwTime = getSimTime() + 0.4; 
   					return;
   				}
   			}
   			if($TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"] >= $TeamItemMax["HoloPack"]) {
   				Client::sendMessage(%client,0,"Team deployable item limit reached for Decoys");			
   				return;
   			}
   			makem(%client, %player, %HologramName, %str);
   			Player::decItemCount(%player,%item); 
   			$TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"]++; 
   			return;
   		} else if(%armor == "earmor" || %armor == "efemale")
            throwNewGren(%player, "EMPgren", %str);
   		else if (%armor == "sarmor" || %armor == "sfemale") 
            throwNewGren(%player, "ConcussionGren", %str);
         else if (%armor == "iarmor" || %armor == "ifarmor") {
   	   	%proj = throwNewGren(%player, "PuffGren", %str);
            %proj.team = GameBase::getTeam(%client);
   		} else if (%armor == "spyarmor" || %armor == "spyfemale") { 
   			Client::sendMessage(%client, 1, "Plastique Explosive will explode in 15 seconds~wmine_act.wav");
   			%obj = newObject("","Mine","Nukebomb");
            schedule("aboutToExplode("@%client@","@%client.ScoreDeaths@");", 14.1, %obj);
   		} else if (%armor == "marmor" || %armor == "mfemale" || %armor == "dmarmor" || %armor == "dmfemale") {
   	   	throwNewGren(%player, "NewGren", %str);
   			//%obj = newObject("","Mine","Handgrenade"); 
   		} else if (%armor == "harmor") {
   			%state = Player::getItemState(%player, 5);
   			if (%state != "Fire" && %state != "Reload") {
               if( GameBase::getLOSinfo(%player, 23) ) {
						Client::sendMessage(%client,0, "Unable to fire - Object in way");
						return;
					} else {
						Player::trigger(%player,4,true);
	   				Player::trigger(%player,5,true);
	   				Player::trigger(%player,4,false);
	   				Player::trigger(%player,5,false);
	   				ixApplyKickback(%player, 220, 30);
	   				schedule("playSound(SoundFlyerDismount, GameBase::getPosition("@%client@"));", 1.5, %player);
	   				GameBase::applyDamage(%player,-5,0.2,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
					}
   			} else {
   				Client::sendMessage(%client,0, "Unable to fire - Missiles are reloading"); 				
					return;
   			}				
   		} else if (%armor == "barmor" || %armor == "bfemale") {
   	   	%proj = throwNewGren(%player, "FireGren", %str);
            %proj.player = %player;
   	   } else if (%armor == "darmor")
         	throwNewGren(%player, "MortarBomb", %str);

   		Player::decItemCount(%player,%item); 

         if (%obj != "") {
      		addToSet("MissionCleanup", %obj); 
      		GameBase::throw(%obj,%player,15 * %str,false); 
         }

     		if (%armor == "darmor") 
   			%player.throwTime = getSimTime() + 1.6; 
   		else	
   			%player.throwTime = getSimTime() + 0.5; 
   	} 
   } 
} 


function MineAmmo::onUse(%player, %item) { 
	%client = Player::getClient(%player);
	if(%client.possessed || %client.possessing) return;
	if($matchStarted) { 
		if(%player.throwTime < getSimTime() ) { 
         if ( %client.throwStrength < 0.6 && GameBase::getLOSInfo(%player, 3) &&
            (getObjectType($los::object) == "SimTerrain" || getObjectType($los::object) == "InteriorShape") ) {

            %set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set, $SimPlayerObjectType, $los::position, 1, 1, 1, 0);

				if ( %num == 1 && Player::getClient( Group::getObject(%set,0) ) == %client ) { 
					Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
   				deleteObject(%set);
					return;
				} else if (%num > 1) {
	         	Player::decItemCount(%player,%item); 
  					%armor = Player::getArmor(%player); 
					if (%armor == "dmarmor" || %armor == "dmfemale") 
						%obj = newObject("","Mine","DMMine"); 
					else { 
						if ( %armor == barmor || %armor == bfemale )
							%obj = newObject("","Mine","FireMine");
						else
							%obj = newObject("","Mine","antipersonelMine"); 
						GameBase::setTeam(%obj, GameBase::getTeam (%client)); 
					} 
					addToSet("MissionCleanup", %obj); 
					GameBase::throw(%obj, %player, 15 * %client.throwStrength, false); 
					%player.throwTime = getSimTime() + 0.5; 
   				deleteObject(%set);
					return;
   			}
				deleteObject(%set);

   			Player::decItemCount(%player,%item); 

				%rot = Vector::getRotation($los::normal);
				%armor = Player::getArmor(%player); 
				if ( %armor == barmor || %armor == bfemale )
					%obj = newObject("", "StaticShape", StickFireMine, true); 
				else
					%obj = newObject("", "StaticShape", StickMine, true); 
				addToSet("MissionCleanup", %obj);
				GameBase::setTeam(%obj, GameBase::getTeam(%client)); 
   			%obj.ownerClient = %client; 
				GameBase::setRotation(%obj, %rot);
				%rot = (getWord(%rot, 0) + 1.57) @ " " @ getWord(%rot, 1) @ " " @ getWord(%rot, 2);
				%move = Vector::getFromRot(%rot, 0.08);
				GameBase::setPosition(%obj, Vector::add($los::position, %move));
				%obj.isReady = false;
				schedule( "readyStickMine(" @ %obj @ ");", 2.5, %obj );
				playSound(SoundPickupBackpack, $los::position);
				%player.throwTime = getSimTime() + 0.55;
			} else {
	   		Player::decItemCount(%player,%item); 
				%armor = Player::getArmor(%player); 
				if (%armor == "dmarmor" || %armor == "dmfemale") 
					%obj = newObject("","Mine","DMMine"); 
				else { 
					if ( %armor == barmor || %armor == bfemale )
						%obj = newObject("","Mine","FireMine");
					else
						%obj = newObject("","Mine","antipersonelMine"); 
					GameBase::setTeam(%obj, GameBase::getTeam (%client)); 
				} 
				addToSet("MissionCleanup", %obj); 
				GameBase::throw(%obj, %player, 15 * %client.throwStrength, false); 
				%player.throwTime = getSimTime() + 0.5; 
			}
		} 
	} 
} 
