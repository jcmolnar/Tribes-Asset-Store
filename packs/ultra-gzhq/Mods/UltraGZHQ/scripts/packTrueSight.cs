$InvList[SightPack] = 1;
$MobileInvList[SightPack] = 1;
$RemoteInvList[SightPack] = 1;
AddItem(SightPack);


ItemImageData SightPackImage
{	
	shapeFile = "sensor_small";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	mountOffset = { 0, -0.1, 0.2 };
	mountRotation = { 1.0, -3.14, 0};
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = false;

//	sfxReload = SoundSightOff;
//	sfxActivate = SoundMortarIdle;	//SoundPickUpWeapon;
//	sfxReady = SoundMortarIdle;
	sfxFire = SoundLaserIdle;
};

ItemData SightPack
{	
	description = "Spy Scanner Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SightPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SightPackImage::onActivate(%player,%imageSlot)
{	
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Spy Scanner On.  :::Scanning:::");
	schedule("CheckSight("@%player@");",1);

}


function SightPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Spy Scanner Off.");
}

function SightPack::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Spy Scanner:<f2> Able to see players using Spy Pack powers. ");
}

function CheckSight(%player)
{
	%client = Player::getClient(%player);
	%player = Client::getOwnedObject(%client);
	if(Player::isTriggered(%player,$BackpackSlot) && (Player::getMountedItem(%player,$BackpackSlot) == "SightPack")) 
	{	
		if (GameBase::getLOSInfo(%player,3000))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%set = newObject("set",SimSet);
			%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; 
			%num = containerBoxFillSet(%set,%Mask,$los::position,30,30,30,0);
			%totalnum = Group::objectCount(%set);
			%enemyflag=0;
			for(%i = 0; %i < %totalnum; %i++)
			{
				%obj = Group::getObject(%set, %i);
				//%name = Item::getItemData(%obj);
				//client::sendMessage(Player::getClient(%player),1,"Itemdata: "@ %i @ " " @ %name);
				%dist = Vector::getDistance($los::position, GameBase::getPosition(%obj));
				// uncloak in a sphere, not a box..
				if(%obj.cloaked && %dist < 10)
				{     
					GameBase::startFadeIn(%obj);
					%obj.cloaked = "";	
				}
			}
			deleteObject(%set);	
		}
		schedule("CheckSight("@%player@");",1);
	}

}
