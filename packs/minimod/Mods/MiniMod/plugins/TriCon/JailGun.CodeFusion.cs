///-----------------------------------------------
/// description = "JailGun";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

MiniMod::MonitorFile(start, "JailGun.CodeFusion.cs", "Jail Gun Plugin");
MiniMod::Turbo::Class(JailCapPack, 4);

LightningData jailbolt
{
  bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 4.0;
   coneAngle        = 1.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 60.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
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

MiniMod::WeaponCycle(Blaster, JailGun, PlasmaGun);
$AutoUse[JailGun] = True;



ItemImageData JailGunImage
{
          shapeFile = "shotgun";
           mountPoint = 0;

           weaponType = 2;
           projectileType = jailbolt;


           minEnergy = 5;
           maxEnergy = 80;
           reloadTime = 4.0;

          lightType = 3;
          lightRadius = 2;
          lightTime = 1;
          lightColor = { 0.25, 0.25, 0.85 };

          sfxActivate = SoundPickUpWeapon;
          sfxFire     = SoundELFIdle;
};
ItemData JailGun
{
   heading = "bWeapons";
        description = "Jailers Gun";
        className = "Weapon";
        shapeFile  = "repairgun";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};

$InvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

