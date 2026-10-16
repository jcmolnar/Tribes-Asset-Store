//----------------------------------------------------------------------------
// IMPORTANT: 3d voice profile must go first (if voices are allowed)
SoundProfileData Profile3dVoice
{
   baseVolume = 0;
   minDistance = 10.0;
   maxDistance = 70.0;
   flags = SFX_IS_HARDWARE_3D;
};
//----------------------------------------------------------------------------

SoundProfileData Profile2d
{
   baseVolume = 0.0;
};

SoundProfileData Profile2dLoop
{
   baseVolume = 0.0;
   flags = SFX_IS_LOOPING;
};

SoundProfileData Profile3dNear
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 40.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dMedium
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 100.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dMed
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 250.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dFar
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 500.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dLudicrouslyFar
{
   baseVolume = 0;
   minDistance = 2.0;
   maxDistance = 700.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dNearLoop
{
   baseVolume = 0;
   minDistance = 2.0;
   maxDistance = 40.0;
   flags = { SFX_IS_HARDWARE_3D, SFX_IS_LOOPING };
};

SoundProfileData Profile3dCloseLoop
{
   baseVolume = 0;
   minDistance = 2.0;
   maxDistance = 20.0;
   flags = { SFX_IS_HARDWARE_3D, SFX_IS_LOOPING };
};


SoundProfileData Profile3dMediumLoop
{
   baseVolume = 0;
   minDistance = 2.0;
   maxDistance = 100.0;
   flags = { SFX_IS_HARDWARE_3D, SFX_IS_LOOPING };
};

SoundProfileData Profile3dFoot
{
   baseVolume = 0;
   minDistance = 2.0;
   maxDistance = 30.0;
   flags = SFX_IS_HARDWARE_3D;
};


//----------------------------------------------------------------------------
// sound data

SoundData SoundLandOnGround
{
   wavFileName = "landhurt.wav";
   profile = Profile3dNear;
};

//SoundData SoundPlayerDeath
//{
//   wavFileName = "player_death.wav";
//   profile = Profile3dMedium;
//};

SoundData SoundJetLight
{
   wavFileName = "thrust.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundJetHeavy
{
   wavFileName = "heavy_thrust.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundRain
{
   wavFileName = "rain.wav";
   profile = Profile2dLoop;
};

SoundData SoundSnow
{
   wavFileName = "snow.wav";
   profile = Profile2dLoop;
};



SoundData SoundDoorOpen
{
   wavFileName = "door1.wav";
   profile = Profile3dNear;
};

SoundData SoundDoorClose
{
   wavFileName = "door2.wav";
   profile = Profile3dNear;
};

SoundData SoundElevatorRun
{
   wavFileName = "generator.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundElevatorBlocked
{
   wavFileName = "turret_whir.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundElevatorStart
{
   wavFileName = "elevator1.wav";
   profile = Profile3dNear;
};

SoundData SoundElevatorStop
{
   wavFileName = "elevator2.wav";
   profile = Profile3dNear;
};


//===================================
SoundData SoundMineActivate
{
   wavFileName = "mine_activate.wav";
   profile = Profile3dNear;
};

SoundData SoundFloatMineTarget
{
   wavFileName = "float_target.wav";
   profile = Profile3dNear;
};

//----------------------------------------------------------------------------
// Inventory sounds

SoundData SoundPickupItem
{
   wavFileName = "Pku_item.wav";
   profile = Profile3dNear;
};

SoundData SoundPickupHealth
{
   wavFileName = "Pku_patch.wav";
   profile = Profile3dNear;
};

SoundData SoundPickupBackpack
{
   wavFileName = "pku_pack.wav";
   profile = Profile3dNear;
};

SoundData SoundPickupWeapon
{
   wavFileName = "Pku_weapon.wav";
   profile = Profile3dNear;
};

SoundData SoundPickupAmmo
{
   wavFileName = "Pku_ammo.wav";
   profile = Profile3dNear;
};

SoundData SoundActivatePDA
{
   wavFileName = "pda_on.wav";
   profile = Profile3dNear;
};

SoundData SoundPDAButtonHard
{
   wavFileName = "button_hard.wav";
   profile = Profile3dNear;
};

SoundData SoundPDAButtonSoft
{
   wavFileName = "button_soft.wav";
   profile = Profile3dNear;
};


//----------------------------------------------------------------------------
// Inventory equipment

SoundData SoundActivateAmmoStation
{
   wavFileName = "ammo_activate.wav";
   profile = Profile3dNear;
};

SoundData SoundUseAmmoStation
{
   wavFileName = "ammo_use.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundAmmoStationPower
{
   wavFileName = "ammo_power.wav";
   profile = Profile3dNear;
};

SoundData SoundActivateInventoryStation
{
   wavFileName = "inv_activate.wav";
   profile = Profile3dNear;
};

SoundData SoundUseInventoryStation
{
   wavFileName = "inv_use.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundInventoryStationPower
{
   wavFileName = "inv_power.wav";
   profile = Profile3dNear;
};

SoundData SoundActivateCommandStation
{
   wavFileName = "ent_com_act.wav";
   profile = Profile3dNear;
};

SoundData SoundUseCommandStation
{
   wavFileName = "ent_com_use.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundCommandStationPower
{
   wavFileName = "ent_com_power.wav";
   profile = Profile3dNear;
};

//----------------------------------------------------------------------------
// Item sounds

SoundData SoundGeneratorPower
{
   wavFileName = "ent_gen_idle.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundActivateMotionSensor
{
   wavFileName = "motion_activate.wav";
   profile = Profile3dNear;
};

SoundData SoundSensorPower
{
   wavFileName = "ent_sensor_power.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundTeleportPower
{
   wavFileName = "activateTele.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundBeaconActive
{
   wavFileName = "activateBeacon.wav";
   profile = Profile3dNearLoop;
};

SoundData SoundBeaconUse
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

SoundData SoundPackUse
{
   wavFileName = "usepack.wav";
   profile = Profile3dNear;
};

SoundData SoundPackFail
{
   wavFileName = "failpack.wav";
   profile = Profile3dNear;
};

SoundData SoundThrowItem
{
   wavFileName = "throw_item.wav";
   profile = Profile3dNear;
};


SoundData SoundFlagCaptured
{
   wavFileName = "flag_captured.wav";
   profile = Profile3dMedium;
};

SoundData SoundFlagReturned
{
   wavFileName = "flag_return.wav";
   profile = Profile3dMedium;
};

SoundData SoundFlagPickup
{
   wavFileName = "flag_pickup.wav";
   profile = Profile3dMedium;
};

SoundData SoundFlagFlap
{
   wavFileName = "flagflap.wav";
   profile = Profile3dNear;
};

SoundData SoundDeploySensor
{
   wavFileName = "sensor_deploy.wav";
   profile = Profile3dNear;
};

SoundData SoundActiveSensor
{
   wavFileName = "sensor_active.wav";
   profile = Profile3dNear;
};

SoundData SoundTurretDeploy
{
   wavFileName = "rmt_turret.wav";
   profile = Profile3dNear;
};

SoundData SoundRadarDeploy
{
   wavFileName = "rmt_radar.wav";
   profile = Profile3dNear;
};

SoundData SoundCameraDeploy
{
   wavFileName = "rmt_camera.wav";
   profile = Profile3dNear;
};

//----------------------------------------------------------------------------
// Explosion Sounds

SoundData bigExplosion1
{
   wavFileName = "bxplo1.wav";
   profile     = Profile3dFar;
};

SoundData bigExplosion2
{
   wavFileName = "bxplo2.wav";
   profile     = Profile3dFar;
};

SoundData bigExplosion3
{
   wavFileName = "bxplo3.wav";
   profile     = Profile3dFar;
};

SoundData bigExplosion4
{
   wavFileName = "bxplo4.wav";
   profile     = Profile3dFar;
};

SoundData explosion3
{
   wavFileName = "explo3.wav";
   profile     = Profile3dFar;
};

SoundData explosion4
{
   wavFileName = "explo4.wav";
   profile     = Profile3dFar;
};

//============================================
SoundData SoundDryFire
{
   wavFileName = "Dryfire1.wav";
   profile = Profile3dNear;
};

//===========================================

SoundData boostExplosion
{
   wavFileName = "exp_flash.wav";
   profile     = Profile3dFar;
};

SoundData turretExplosion
{
   wavFileName = "turretexp.wav";
   profile     = Profile3dMedium;
};

SoundData shockExplosion
{
   wavFileName = "exp_shock.wav";
   profile     = Profile3dFar;
};

SoundData floatMineExplosion
{
   wavFileName = "float_explode.wav";
   profile     = Profile3dFar;
};

SoundData debrisSmallExplosion
{
   wavFileName = "debris_small.wav";
   profile     = Profile3dNear;
};

SoundData debrisMediumExplosion
{
   wavFileName = "debris_medium.wav";
   profile     = Profile3dMedium;
};

SoundData debrisLargeExplosion
{
   wavFileName = "debris_large.wav";
   profile     = Profile3dFar;
};

//----------------------------------------------------------------------------
// Vehicle Sounds

SoundData SoundFlyerMount
{
   wavFileName = "flyer_mount.wav";
   profile = Profile3dNear;
};

SoundData SoundFlyerDismount
{
   wavFileName = "flyer_dismount.wav";
   profile = Profile3dNear;
};

SoundData SoundFlyerActive
{
   wavFileName = "flyer_fly.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundFlyerIdle
{
   wavFileName = "flyer_idle.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundFlierCrash
{
   wavFileName = "crash.wav";
   profile = Profile3dMedium;
};

SoundData SoundTankMount
{
   wavFileName = "flyer_mount.wav";
   profile = Profile3dNear;
};

SoundData SoundTankDismount
{
   wavFileName = "flyer_dismount.wav";
   profile = Profile3dNear;
};

SoundData SoundTankActive
{
   wavFileName = "flyer_fly.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundTankIdle
{
   wavFileName = "flyer_idle.wav";
   profile = Profile3dMediumLoop;
};

SoundData SoundTankCrash
{
   wavFileName = "crash.wav";
   profile = Profile3dMedium;
};

SoundData SoundNoSound
{
   wavFileName = "no_sound.wav";
   profile = Profile3dNear;
};
SoundData SoundNoDebris
{
   wavFileName = "no_sound.wav";
   profile = Profile3dNear;
};