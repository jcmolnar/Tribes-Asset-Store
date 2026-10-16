
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Deployable Ion Turret (IonTurret)
//  By Mephisto? modified by Alazane, see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//  Depends on:
//    Turret.cs
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$ItemMax[dmfemale, IonTurretPack] = 0;
$ItemMax[dmarmor, IonTurretPack] = 0;
$ItemMax[armormSniper, IonTurretPack] = 0; 
$ItemMax[armormMercenary, IonTurretPack] = 0; 
$ItemMax[harmor, IonTurretPack] = 0; 
$ItemMax[armorfSniper, IonTurretPack] = 0;
$ItemMax[armorfMercenary, IonTurretPack] = 0; 
$ItemMax[armormScout, IonTurretPack] = 0; 
$ItemMax[armormBurster, IonTurretPack] = 0; 
$ItemMax[armorCyborg, IonTurretPack] = 0; 
$ItemMax[armorfScout, IonTurretPack] = 0; 
$ItemMax[armorfBurster, IonTurretPack] = 0; 
$ItemMax[armormSpy, IonTurretPack] = 0; 
$ItemMax[armorfSpy, IonTurretPack] = 0; 
$ItemMax[armormEngineer, IonTurretPack] = 0;
$ItemMax[armorfEngineer, IonTurretPack] = 0;
$ItemMax[armormAlien, IonTurretPack] = 0; 
$ItemMax[armorfAlien, IonTurretPack] = 0;
$ItemMax[armormLoader, IonTurretPack] = 1;
$ItemMax[armorfLoader, IonTurretPack] = 1;
$ItemMax[armormSprint, IonTurretPack] = 0;
$ItemMax[armorfSprint, IonTurretPack] = 0;


$TeamItemMax[IonTurretPack] = 5;
$InvList[IonTurretPack] = 1;
$RemoteInvList[IonTurretPack] = 1;

$CanAlwaysTeamDestroy[DeployableIonTurret] = 1;

 //-=-=-=-

function deployIonTurret::Initialize()
{
  $TeamItemCount[0 @ IonTurretPack] = 0;
  $TeamItemCount[1 @ IonTurretPack] = 0;
  $TeamItemCount[2 @ IonTurretPack] = 0;
  $TeamItemCount[3 @ IonTurretPack] = 0;
  $TeamItemCount[4 @ IonTurretPack] = 0;
  $TeamItemCount[5 @ IonTurretPack] = 0;
  $TeamItemCount[6 @ IonTurretPack] = 0;
  $TeamItemCount[7 @ IonTurretPack] = 0;
}

 //-=-=-=-

ItemImageData IonTurretPackImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.12, -0.1 };
  mountRotation = { 0, 0, 0 };
  mass = 2.5;
  firstPerson = false;
};

ItemData IonTurretPack
{
  description = "Ion Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = $InvHead[ihDWe];
  imageType = IonTurretPackImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 350;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function IonTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function IonTurretPack::onDeploy(%player,%item,%pos)
{
	if (IonTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function IonTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
					%camera = newObject("camera","Turret",DeployableIonTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Ion Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Ion Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "IonTurretPack"]++;
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

 //-=-=-=-

TurretData DeployableIonTurret
{
  className = "Turret";
  shapeFile = "remoteturret";
  projectileType = IonBolt;
  maxDamage = 0.65;
  maxEnergy = 60;
  minGunEnergy = 6;
  maxGunEnergy = 5;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 0.4;
  speed = 4.0;
  speedModifier = 1.5;
  range = 55;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundRemoteTurretFire;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Remote Ion Turret";
  damageSkinData = "objectDamageSkins";
};

function DeployableIonTurret::onAdd(%this)
{
  schedule("DeployableIonTurret::deploy(" @ %this @ ");",1,%this);
  GameBase::setRechargeRate(%this,5);
  %this.shieldStrength = 0.005;
  if (GameBase::getMapName(%this) == "") 
    GameBase::setMapName (%this, "Remote Turret");
}

function DeployableIonTurret::deploy(%this) 
{
  GameBase::playSequence(%this,1,"deploy");
}

function DeployableIonTurret::onEndSequence(%this,%thread) 
{
  GameBase::setActive(%this,true);
}

function DeployableIonTurret::onDestroyed(%this) 
{
  Turret::onDestroyed(%this);
  $TeamItemCount[GameBase::getTeam(%this) @ "IonTurretPack"]--;
}

function DeployableIonTurret::onPower(%this,%power,%generator) 
{
}

function DeployableIonTurret::onEnabled(%this)
{
  GameBase::setRechargeRate(%this,5);
  GameBase::setActive(%this,true);
}

