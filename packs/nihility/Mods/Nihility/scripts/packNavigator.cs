//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[Slipstream] = 1;

$ItemMax[larmor, Slipstream] = 0;	//Seraph
$ItemMax[lfemale, Slipstream] = 0;	//Seraph
$ItemMax[earmor, Slipstream] = 0;	//Slave
$ItemMax[efemale, Slipstream] = 0;	//Slave
$ItemMax[marmor, Slipstream] = 0;	//Pawn
$ItemMax[aarmor, Slipstream] = 1;	//Navigator
$ItemMax[darmor, Slipstream] = 0;	//Atomizer
$ItemMax[barmor, Slipstream] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//by Outlaw

ItemImageData SlipPackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	
	sfxFire = ForceFieldOpen;
};

ItemData Slipstream
{
	description = "Navigator Pack";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "energypack";//compass
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SlipPackImage;
	price = 333;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Slipstream::onMount(%player,%item)
{
	%client = Player::getClient(%player);
      Bottomprint(%client, "<f1>Navigator Pack: <f0>Use waypoints to set desinations. <f1>|| By Outlaw", $displaytime);
}

function SlipPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%waypoint= $point[%client];
	if (%waypoint== " 0 0" || !%waypoint)
	{
		Client::sendMessage(%client,1,"The Navigator CPU has no destination waypoint or it is set into a solid object.~wfailpack.wav");
		Player::trigger(%player,$BackpackSlot,false);
	}
	else
	{
		%teamspot = WaypointToWorld(%waypoint);
		%vertical = "0 0 400";
 		%teamspot = Vector::add(%teamspot,%vertical);
 		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$ItemObjectType,%teamspot,32,32,1024,0);
		%num2 = CountObjects(%set,"flag",%num);
		%totalnum = Group::objectCount(%set);
		%enemyflag=0;
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%name = Item::getItemData(%obj);
			if(%name == "flag")
			{
				if(GameBase::getTeam(%obj) != Gamebase::getTeam(%player)) %enemyflag = %enemyflag+1;
			}
		}
		deleteObject(%set);
		if (%enemyflag == 0)
		{
			if(!$TeleUsed[%player]) 
			{
				GameBase::playSound(%player,ForceFieldOpen,0);
				Client::sendMessage(Player::getClient(%player),3,"30 seconds until teleporter ready.");
				%client = Player::getClient(%player);
				%object = Client::getOwnedObject(%client);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimPlayerObjectType,GameBase::getPosition(%player),5,5,5,0);
				%totalnum = Group::objectCount(%set);
				%destinationspot[%player]=%teamspot;
				%mass=0;
				$point[%client]=" 0 0";
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%mass=%mass+getmass(%obj);
				 		if (%obj != %player)
				 		{
				 			%posobj = GameBase::getPosition(%obj);
				 			%posplayer = GameBase::getPosition(%player);
				 			%resultant = Vector::sub(%posplayer, %posobj);
				 			%destinationspot[%obj]=Vector::add(%teamspot,%resultant);
				 		}
				 	}
				}
				%rnd = floor(getRandom() * 55);
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%hasflag = Player::getMountedItem(%obj, 2);
				 		%armor = player::GetArmor(%obj);
				 		%PackClient = Player::getClient(%player);
				 		if(%hasflag!=-1 && %hasflag!="DeadWeight")
						{
							Player::dropItem(%obj, %hasflag);
							Client::sendMessage(Player::getClient(%obj),1,"Flag is made of material that cannot be teleported.");
						}
						if (%armor != harmor)
						{
			 				TeleportPlayer(%obj,%destinationspot[%obj]);
			 				Client::sendMessage(Player::getClient(%obj),3,"You have jumped to your destination.");
			 				GameBase::playSound(%obj,ForceFieldOpen,0);
			 			}
				 		else
				 		{
				 			TeleportPlayer(%obj,%destinationspot[%obj]);
				 			%damagedClient = Player::getClient(%obj);
				 			Client::sendMessage(Player::getClient(%obj),1,"Due to the mass and size of your armor, parts of you have been left behind...!~werror_message.wav");
				 			GameBase::applyDamage(%obj,$DebrisDamageType,40,%destinationspot[%obj],"0 0 0","0 0 0",%damagedClient);
				 			if(%damagedClient.lastDamage < getSimTime()) 
							{
								%sound = radnomItems(3,injure1,injure2,injure3);
								playVoice(%damagedClient,%sound);
								%damagedClient.lastdamage = getSimTime() + 1.5;
							}
				 			Player::blowUp(%obj);
				 		}
					}
				}
				deleteObject(%set);
				setCommandStatus(%client, 0, "Deleting set waypoint...");
				Player::trigger(%player,$BackpackSlot,false);
				$TeleUsed[%player] = true;
			        %time = 30; 
				schedule("TelePackCooling(" @ %time @ ", " @ %player @ ");", 1, %player);
			}
			else 
			{
				Client::sendMessage(Player::getClient(%player),1,"Navigator CPU is still charging.~wfailpack.wav");
				Player::trigger(%player,$BackpackSlot,false);
			}
	
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Cannot teleport yourself and others near enemy flags!~werror_message.wav");
			Player::trigger(%player,$BackpackSlot,false);
		}
	}
	
}

//XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX 		       		XX
//XX LightArmor  =	Seraph 		larmor	lfemale XX
//XX EngArmor    =	Slave 		earmor	efemale	XX
//XX MediumArmor =	Pawn		marmor		XX
//XX AlArmor     =	Navigator	aarmor		XX
//XX DragArmor   =	Atomizer	darmor		XX
//XX BursterArmor=	Paladin		barmor       	XX
//XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX

function getmass(%obj)
{
	%mass = 30;
	%armor = player::GetArmor(%obj);
	if(%armor==larmor) %mass = 0;
	if(%armor==lfemale) %mass = 0;
	if(%armor==earmor) %mass = 5;
	if(%armor==efemale) %mass = 5;
	if(%armor==marmor) %mass = 4;
	if(%armor==aarmor) %mass = 0;
	if(%armor==barmor) %mass = 8;
	if(%armor==darmor) %mass = 14;
	return %mass;
}

function TeleportPlayer(%player,%tportspot)
{
	Player::setDamageFlash(%player, 0.4);
	GameBase::startFadein(%player);
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,%tportspot);
	GameBase::getLOSInfo(%camera,600,"-1.5708 0 0");
	DeleteObject(%camera);
	GameBase::setPosition(%player, $los::position);
}

function TelePackCooling(%time, %player)
{
	if(%time > 0)
	{
		schedule("TelePackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
	}
	else if(%time == 0)
	{
		TeleReset(%player);
	}
}

function TeleReset(%player)
{
	$TeleUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),3,"Navigator Pack fully charged...Ready for teleport~wmine_act.wav.");
}