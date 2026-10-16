//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$InvList[JailGun] = 1;
addWeapon(JailGun);

$ItemMax[larmor, JailGun] = 1;	//Seraph
$ItemMax[lfemale, JailGun] = 1;	//Seraph
$ItemMax[earmor, JailGun] = 1;	//Slave
$ItemMax[efemale, JailGun] = 1;	//Slave
$ItemMax[marmor, JailGun] = 1;	//Pawn
$ItemMax[aarmor, JailGun] = 1;	//Navigator
$ItemMax[darmor, JailGun] = 1;	//Atomizer
$ItemMax[barmor, JailGun] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

LightningData JailBolt
{	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 10.0;
	coneAngle = 10.0;
	damagePerSec = 0.01;
	energyDrainPerSec = 10.0;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%aclient = Player::getClient(%target);
if(getObjectType(%target) != "Player")
      {
       return;
      }


if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
        {
        return;
        }


    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%target);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%shooterId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%target);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%target,GameBase::GetPosition(%o));
                        Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
                        schedule("jLargeForceField::jailSesame("@%target@");",20);
                    }
                    }

}

ItemImageData JailGunImage
{
          shapeFile = "shotgun";
           mountPoint = 0;

           weaponType = 2;
           projectileType = jailbolt;


           minEnergy = 5;
           maxEnergy = 10;
           reloadTime = 1.0;

          lightType = 3;
          lightRadius = 2;
          lightTime = 1;
          lightColor = { 0.25, 0.25, 0.85 };

          sfxActivate = SoundPickUpWeapon;
          sfxFire     = SoundELFIdle;
};
ItemData JailGun
{
        heading = "lJail Equipment";
        description = "Jailers Gun";
        className = "tool";
        shapeFile  = "repairgun";
        hudIcon = "energyRifle";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 77;
        showWeaponBar = true;
};

function Jailgun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Jailers Gun");

//	Player::mountItem(%player,Mortar2,$MortarSlotA); 
//	Player::mountItem(%player,Mortar3,$MortarSlotB);
//	Player::mountItem(%player,Mortar4,$MortarSlotC);
}
