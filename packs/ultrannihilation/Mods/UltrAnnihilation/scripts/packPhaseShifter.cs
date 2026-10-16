$InvList[PhaseShifterPack] = 1;
$MobileInvList[PhaseShifterPack] = 1;
$RemoteInvList[PhaseShifterPack] = 1;

$WarpTime = 1.5;
$WarpRange = 1400;
$WarpChance = 1;
$DropFlagChance = 0.5;

ItemImageData PhaseShifterPackImage
{	
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 3.14, 0, 0 };
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = false;
};

ItemData PhaseShifterPack
{	
	description = "Phase Shifter";
	shapeFile = "shield";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = PhaseShifterPackImage;
	price = 15;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PhaseShifterPackImage::onActivate(%player,%imageSlot)
{	
	%client = Player::getClient(%player);
	%player = Client::getOwnedObject(%client);
	
	if (!GameBase::getLOSInfo(%player,$WarpRange))
	{
		Bottomprint(%client, "<jc>Phase Shift position out of range");
		PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
		return;
	}
	
	%object = getObjectType($los::object);
	if (%object="Player" || %object ="Flier" || %object ="") 
	{
		Bottomprint(%client, "<jc>Cannot Phase Shift there");
		Client::sendMessage(%client,0,"~wError_Message.wav");
		PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
		return;
	}
	
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$ItemObjectType,$los::position,30,30,30,0); //60,60,50,0
	%num2 = CountObjects(%set,"flag",%num);
	%totalnum = Group::objectCount(%set);
	%enemyflag=0;
	for(%i = 0; %i < %totalnum; %i++)
	{
		%obj = Group::getObject(%set, %i);
		%name = Item::getItemData(%obj);
		if(%name == "flag" && (GameBase::getTeam(%obj) != Gamebase::getTeam(%player)))
		{
			echo(Client::getName(GameBase::getOwnerClient(%player))@" "@Player::getClient(%player)@" "@%player@" Trying to Jump near flag...");
			Client::sendMessage(%client,0,"~wError_Message.wav");
			Bottomprint(%client, "<jc>Cannot Phase Shift near enemy flags");
			PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
			return;
		}
	}
	deleteObject(%set);
	
	if(%player.hasPhaseShifted)
	{	
		Bottomprint(%client, "<jc>Phase Shift pack not ready");
		Client::sendMessage(%client,0,"~wError_Message.wav");
		PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
		return;
	}
	
	//--------------------
	// hack so players dont 
	// end up in walls
	%obj = getObjectType($los::object);
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	%xpos = getWord($los::position,0);
	%ypos = getWord($los::position,1);
	%zpos = getWord($los::position,2);

	//echo($los::normal);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	{
		%zpos += 0.5;//floor
	}
	else 
	{
		if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
		{
			%zpos -= 2;//ceiling
		}
		else if (Vector::dot($los::normal,"0 0 -1") >= -0.1 || Vector::dot($los::normal,"0 0 -1") <= 0.1 ) 
		{
			//wall
			%xopos = getWord($los::normal,0);
			%yopos = getWord($los::normal,1);
			//%xpos = %xpos + %xopos + %xopos;
			%xpos = %xpos + %xopos;
			//%ypos = %ypos + %yopos + %yopos;
			%ypos = %ypos + %yopos;
		}
		else 
		{
			%rot = Vector::getRotation($los::normal);//other
		}
	}

	if(Player::getMountedItem(%player, 2) == "flag")
	{
		if(floor(getrandom() * 100) < $DropFlagChance)
		{
			Player::dropItem(%player,Player::getMountedItem(%player, 2));
			Client::sendMessage(Player::getClient(%player),1,"You dropped the flag while jumping... NICE JOB.~wError_Message.wav");
		}
	}

	%dest = %xpos@" "@%ypos@" "@%zpos;

       	if(floor(getrandom() * 100) < $WarpChance)
	{
		Client::sendMessage(Player::getClient(%player),1,"Phase Shifter Malfunction: You were ripped apart.~wError_Message.wav");
		Player::kill(%client);
		Client::onKilled(%client,%client);
	}
	else
	{
		schedule("phaseShiftProcess(" @ %player @ ", " @ %xpos @ ", " @ %ypos @ ", " @ %zpos @ ");", 0.25, %player);
		%player.hasPhaseShifted = true;
	}
	
	PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
}


function PhaseShifterPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
}

function PhaseShifterPack::onMount(%player,%item)
{	
	%client = Player::getClient(%player);
	Bottomprint(%client, "<f1>Phase Shifter:<f0> Allows short range teleportation via the users HUD crosshair - but can badly misfunction. ");
}

function phaseShiftProcess(%player, %xpos, %ypos, %zpos)
{
	GameBase::setPosition(%player, "247 247 -1564");
	schedule("phaseShiftComplete(" @ %player @ ", " @ %xpos @ ", " @ %ypos @ ", " @ %zpos @ ");", 1.50, %player);
}

function phaseShiftComplete(%player, %xpos, %ypos, %zpos)
{
	Item::setVelocity(%player, 0);
	GameBase::setPosition(%player, %xpos@" "@%ypos@" "@%zpos);
	schedule("phaseShiftRecharge(" @ %player @ ");", $WarpTime, %player);
}

function phaseShiftRecharge(%player)
{
	%player.hasPhaseShifted = false;
	%client = GameBase::getOwnerClient(%player);
	Bottomprint(%client, "<jc>Phase Shift pack ready");
}

//function checkSafeWarp(%client,%player)
//{	
//	if ($WarpTime[%client] > 0)
//	{	
//		$WarpTime[%client] -= 1;
//		schedule("checkSafeWarp(" @ %client @ "," @ %player @ ");",1,%player);
//	}
//	else
//	{	
//		$WarpTime[%client] = 0;
//		Bottomprint(%client, "<jc><f1>Phase Shifter field stabilized");
//	}
//}
//
//function WarpWrap(%client,%player,%dest)
//{	
//	if ($WarpWrapTime[%client] > 0)
//	{	
//		$WarpWrapTime[%client] -= 0.6;
//		schedule("WarpWrap(" @ %client @ "," @ %player @ ",\"" @ %dest @ "\");",1,%player);
//	}
//	else
//	{	
//		$WarpWrapTime[%client] = 0;
//		GameBase::setPosition(%client,%dest);
//		if ($WarpStable[%client] == 2)
//		{	
//			Bottomprint(%client, "<jc><f1>Phase Shift Successful!\n<jc><f0>Phase Shift field restabilizing");
//		}
//		else
//		{	if ($WarpStable[%client] == 1)
//			{	
//				Bottomprint(%client, "<jc><f1>Phase Shift Successful!\n<jc><f0>Phase Shift field still unstable");
//			}
//			else
//			{	
//				Bottomprint(%client, "<jc><f1>Phase Shift Unsuccessful!\n<jc><f0>The Phase Shift tears you to apart");
//			}
//		}
//	}
//}
