// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------

$MovementMode::[0] = "Free Move";
$MovementMode::[1] = "Rotate X";
$MovementMode::[2] = "Rotate -X";
$MovementMode::[3] = "Rotate Y";
$MovementMode::[4] = "Rotate -Y";
$MovementMode::[5] = "Rotate Z";
$MovementMode::[6] = "Rotate -Z";
$MovementMode::[7] = "Move Forward";
$MovementMode::[8] = "Move Backward";
$MovementMode::[9] = "Move Left";
$MovementMode::[10] = "Move Right";
$MovementMode::[11] = "Move Up";
$MovementMode::[12] = "Move Down";
$MovementMode::[13] = "Flip X";
$MovementMode::[14] = "Flip Y";
$MovementMode::[15] = "Flip Z";
$MovementMode::[16] = "Radius Rotate X";
$MovementMode::[17] = "Radius Rotate -X";
$MovementMode::[18] = "Radius Rotate Y";
$MovementMode::[19] = "Radius Rotate -Y";
$MovementMode::[20] = "Radius Rotate Z";
$MovementMode::[21] = "Radius Rotate -Z";
$MovementMode::[22] = "Radius Move Forward";
$MovementMode::[23] = "Radius Move Backward";
$MovementMode::[24] = "Radius Move Left";
$MovementMode::[25] = "Radius Move Right";
$MovementMode::[26] = "Radius Move Up";
$MovementMode::[27] = "Radius Move Down";
$MovementMode::[28] = "Radius Flip X";
$MovementMode::[29] = "Radius Flip Y";
$MovementMode::[30] = "Radius Flip Z";

RepairEffectData GrabBolt
{
	bitmapName = "paintglow.bmp";//"lightningNew.bmp"; //"antgrv04.bmp"; //"chainflash1.bmp"; //"lightningNewSub.bmp"; //"grn_blink4.bmp";//lightningNewSub.bmp";//lightningTemp.bmp";//fx_lensflare_5.bmp";//cphoenix.flag.bmp";	//grn_blink4.bmp";	//mort0000.bmp";	//repairadd.bmp";
	boltLength = 15.5;

	segmentDivisions = 0;
	beamWidth = 0.015;
	updateTime = 450;	//how fast beam oscilates
	skipPercent = 0.0001;	//0.6
	displaceBias = 0.15;	//0.15 //displaced side to side
    lightRange = 3.0;
    lightColor  = { 0.25, 1, 0.25 };
};



ItemImageData GrabblerImage
{
	shapeFile = "paintgun"; //"mortargun";
	mountPoint		= 0;
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.75, 0};
    weaponType = 1;
	//projectileType = Invalid;

    spinUpTime = 0.0;
    spinDownTime = 0.0;
    fireTime = 0.1;
    accuFire = true;

    minEnergy = 0;
	maxEnergy = 0; //Energy used/sec for sustained weapons
	reloadTime = 0.0;
	//lightType = 3; //Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 0.25, 0.25, 0.85 };
    sfxFire     = SoundSensorPower;
    sfxActivate		= SoundPickUpWeapon;
};

ItemData Grabbler
{
	description   = "Object Manipulator";
	className     = "Tool";
	shapeFile     = "paintgun";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType     = GrabblerImage;
	price         = 50;
	showWeaponBar = false;
};

function GrabblerImage::onFire(%player)
{
	%clientId = Player::getClient(%player);

    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }

    if(%clientid.MovementType == "Free Move")
        Grabbler::ModXMover(%player, %clientId.ToolRadius);
    else
        Grabbler::ModXGrab(%player, %clientId.ToolRadius);
}

function Grabbler::ModXGrab(%player, %radius)
{
   %ClientId = player::getclient(%player);

   if(getWord(%clientId.MovementType, 0) != "Radius")
   {
   if(GameBase::getLOSInfo(%player,100))
   {
      %TempObj = $los::object;
      if(isObject(%TempObj) == false || %TempObj == "")
          return;

    if(WorkingLayer::isInLayerScope(%clientId, %TempObj) == false)
    {
        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object in non-active layer");
        return;
    }
                  
      %type = getObjectType(%TempObj);

      if (%type == "SimTerrain" || %type == "Player" || %type == "Flier")
      {
         bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
         if(!Player::isAiControlled(%TempObj))
            return;
      }

        if (%type != %ClientId.mvtype && %ClientId.mvtype != "all")
        {
            bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
            return;
        }

      if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
      {
         if (%TempObj.Owner != "" || BuildGroup::IsInGroup(%clientId, %TempObj.Owner.buildgroup)) // If its not a mission obj or in same group, it's someone elses
            return;
      }
      
    if(%TempObj.weld)
    {
        if(%TempObj.weld == true)
        {
            bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object welded into place");
            return;
        }
    }
    
    if(%TempObj.DontMove)
    {
        return;
    }
    
      %TempObj.DontWeld = true;
      %TempObj.DontDel = true;

      %TempObj.Move = true;
      GameBase::setActive(%TempObj, false);

      %TempObjRot = GameBase::getRotation(%TempObj);
      %TempObjPos = GameBase::getPosition(%TempObj);

      %plrot = GameBase::getRotation(%player);

      %rotX = getword(%tempObjRot,0);
      %rotY = getword(%tempObjRot,1);
      %rotZ = getword(%tempObjRot,2);

      %posX = getword(%tempObjPos,0);
      %posY = getword(%tempObjPos,1);
      %posZ = getword(%tempObjPos,2);

      if(%clientid.MovementType == "Rotate X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX + 0.023984375;
      }
      else if(%clientid.MovementType == "Rotate -X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX - 0.023984375;
      }
      else if(%clientid.MovementType == "Rotate Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY + 0.023984375;
      }
      else if(%clientid.MovementType == "Rotate -Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY - 0.023984375;
      }
      else if(%clientid.MovementType == "Rotate Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ + 0.023984375;
      }
      else if(%clientid.MovementType == "Rotate -Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ - 0.023984375;
      }
      else if(%clientid.MovementType == "Move Right")
      {
         //%posX = %posX + 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(rotatevector("0.2 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Left")
      {
         //%posX = %posX - 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(rotatevector("-0.2 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Forward")
      {
         //%posY = %posY + 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(rotatevector("0 0.2 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Backward")
      {
         //%posY = %posY - 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(rotatevector("0 -0.2 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Up")
      {
         %posZ = %posZ + 0.2;
      }
      else if(%clientid.MovementType == "Move Down")
      {
         %posZ = %posZ - 0.2;
      }
      else if(%clientid.MovementType == "Flip X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX + 3.14;
      }
      else if(%clientid.MovementType == "Flip Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY + 3.14;
      }
      else if(%clientid.MovementType == "Flip Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ + 3.14;
      }

      if(!%TempObj.DontRot)
         GameBase::SetRotation(%TempObj, %rotX @ " " @ %rotY @ " " @ %rotZ);
      GameBase::SetPosition(%TempObj, %posX @ " " @ %posY @ " " @ %posZ);
      //bottomprint(%clientid,"Targetted: " @ %TempObj @ "\nType: " @ getObjectType(%TempObj) @ "\nRotation: " @ %TempObjRot @ "\nLocation: " @ %TempObjPos @ "\nMovement type: " @ %clientId.MovementType);
      GameBase::setActive(%TempObj, true);
      %TempObj.Move = false;
      %TempObj.DontWeld = false;
      %TempObj.DontDel = false;
      %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
      %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
      return;
   }
   bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
   }
   else
   {
        if(GameBase::getLOSInfo(%player,100))
        {
            %set = newObject("set",SimSet);
            %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, $los::position, %radius, %radius, %radius, 0);
            bottomprint(%clientid,"<jc>Object Manipulator: <f1>Radius:<f2> " @ %radius @ "m <f1># Objects:<f2> " @ %numItems);
            for(%i = %numItems - 1 ; %i>=0; %i--)
            {
                  %TempObj = Group::getObject(%set, %i);

                  //if(%TempObj == -1)
                  //  return;
                    
                  %type = getObjectType(%TempObj);

                  %name = %TempObj.desc;

                    if (%type != %ClientId.mvtype && %ClientId.mvtype != "all")
                    {
                        continue;
                    }

                  if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
                  {
                     if (%TempObj.Owner != "") // If its not a mission obj, it's someone elses
                        continue;
                  }

                if(WorkingLayer::isInLayerScope(%clientId, %TempObj) == false)
                {
                    bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object '"@%name@"' in non-active layer");
                    continue;
                }

                if(%TempObj.weld)
                {
                    if(%TempObj.weld == true)
                    {
                        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object '"@%name@"' welded into place");
                        continue;
                    }
                }

                if(%TempObj.DontMove)
                {
                    continue;
                }

                %TempObj.Move = true;
                %TempObj.DontWeld = true;
                %TempObj.DontDel = true;
                GameBase::setActive(%TempObj, false);

                  %TempObjRot = GameBase::getRotation(%TempObj);
                  %TempObjPos = GameBase::getPosition(%TempObj);

                  %rotX = getword(%tempObjRot,0);
                  %rotY = getword(%tempObjRot,1);
                  %rotZ = getword(%tempObjRot,2);

                  %posX = getword(%tempObjPos,0);
                  %posY = getword(%tempObjPos,1);
                  %posZ = getword(%tempObjPos,2);

                  %plrot = GameBase::getRotation(%player);

                  if(%clientid.MovementType == "Radius Rotate X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX + 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX - 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Rotate Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY + 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY - 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Rotate Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ + 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ - 0.023984375;
                  }
                  else if(%clientid.MovementType == "Radius Flip X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Flip Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Flip Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Move Right")
                  {
                     //%posX = %posX + 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(rotatevector("0.2 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Left")
                  {
                     //%posX = %posX - 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(rotatevector("-0.2 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Forward")
                  {
                     //%posY = %posY + 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(rotatevector("0 0.2 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Backward")
                  {
                     //%posY = %posY - 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(rotatevector("0 -0.2 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Up")
                  {
                     %posZ = %posZ + 0.2;
                  }
                  else if(%clientid.MovementType == "Radius Move Down")
                  {
                     %posZ = %posZ - 0.2;
                  }
                  
                  if(!%TempObj.DontRot)
                     GameBase::SetRotation(%TempObj, %rotX @ " " @ %rotY @ " " @ %rotZ);
                  GameBase::SetPosition(%TempObj, %posX @ " " @ %posY @ " " @ %posZ);
                  //bottomprint(%clientid,"Targetted: " @ %TempObj @ "\nType: " @ getObjectType(%TempObj) @ "\nRotation: " @ %TempObjRot @ "\nLocation: " @ %TempObjPos @ "\nMovement type: " @ %clientId.MovementType);


                GameBase::setActive(%TempObj, true);
                %TempObj.Move = false;
                %TempObj.DontWeld = false;
                %TempObj.DontDel = false;
                %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
                %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
			}
            return;
        }
        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
   }
}

function Grabbler::ModXMover(%player, %radius)
{
        %clientId = Player::getClient(%player);
       if(GameBase::getLOSInfo(%player,100))
       {
        %TempObj = $los::object;
        if (isObject(%TempObj) == false || %TempObj == "")
           return;

        %target = %TempObj;
        %type = getObjectType(%target);

    if(WorkingLayer::isInLayerScope(%clientId, %TempObj) == false)
    {
        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object in non-active layer");
        return;
    }

        if (%type == "SimTerrain" || %type == "Player" || %type == "Flier")
        {
           bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
           if(!Player::isAiControlled(%TempObj))
              return;
        }

        if (%type != %ClientId.mvtype && %ClientId.mvtype != "all")
        {
            bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
            return;
        }

          if (%target.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
          {
             if (%target.Owner != "") // If its not a mission obj, it's someone elses
                return;
          }

        if(%target.weld)
        {
            if(%target.weld == true)
            {
                bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object welded into place");
                return;
            }
        }
        if(%TempObj.DontMove)
        {
            return;
        }
        %TempObj.Move = true;
        %TempObj.DontWeld = true;
        %TempObj.DontDel = true;
        GameBase::setActive(%target, false);

        %player.GrabObject = "";
    	%player.Grabdist = "";
    	%player.GrabRoty = "";
    	%player.GrabOffsetVec = "";

    	%player.GrabObject = %target;

    	if(%target == %player)
    	{
    		return;
    	}
    	else
    	{
            GameBase::setActive(%target, false);
    		%client = Player::getClient(%player);
    		%player.GrabObject = %target;
    		%dataName = GameBase::getDataName(%target);
    		%shape = %dataName.shapeFile;

    		%trans = GameBase::getMuzzleTransform(%player);	//position of tip
    			%posX = getWord(%trans,9);		//x
    			%posY = getWord(%trans,10);		//y
    			%posZ = getWord(%trans,11); 		//z
    		%GunTipPos = %posX@" "@%posY@" "@%posZ;

    		//figure out general relativity, Einstein..
    			%d1= getWord(%trans,3);
    			%d2= getWord(%trans,4);
    			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas

    			%TargetPos = GameBase::getPosition(%target);

    		//simplified for these -player and flier pos is at at bottom center -plasmatic
    		if(%type == "Player" || %type == "Flier")// || %type == "Mine")
    		{
    			%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);
    			%player.GrabOffsetVec = "";
    			%player.GrabRoty = "";
    			%target.forker = %player;	// for release code, plasmatic 2.3
    		}

    		else
    		{
    		// This works ok for now. When beam attach point changes
    		// while rotating, movement is still funky...
    		// hack to move static objects correctly -plasmatic
    			GameBase::getLOSInfo(%player,1000);
    				// GetLOSInfo sets the following globals:
    				// 	los::position
    				// 	los::normal
    				// 	los::object

    			%RealDist = vector::getdistance($los::position,%GunTipPos);
    			%player.Grabdist = %RealDist;

    			%TargetRot = GameBase::getRotation(%target);
    			%playerRot = GameBase::getRotation(%player);
    			%targetRelative = vector::add(%TargetRot ,vector::multiply("0 0 -1",%playerRot));// hacking for screwy spawn pts -players only rotate around z -plas

    			%player.GrabRoty = %targetRelative;

    		//%GunExtPos is like the end of a broom handle shoved down gun barrel.
    			%GunExtPos = %posX + %d1 * %RealDist@" "@%posY + %d2 * %RealDist@" "@%posZ + %d3 * %RealDist;

    		// offsetvec is vec from where we're grabbing to the actual obj position 'handle'
    		// position on object we're grabbing may change, but this works good. -plasmatic
    			%OffsetVec = vector::add(vector::multiply("-1 -1 -1",%GunExtPos),%TargetPos);	//dist from gun tip to where beam is hitting, more or less...
    	//		%Nrot = vector::add(vector::multiply("-1 -1 -1",%targetRot),%playerRot);
    	//		%OffsetVecNew = RotateVector(%OffsetVec,%Nrot);	//normalizing vector relative to player
    			%player.GrabOffsetVec = %OffsetVec;


    		}
          Grabler::move(%player,%target);
        }
       }
        %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
        %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
    	//%target.forker = "";
        GameBase::setActive(%target, true);
        %TempObj.Move = false;
        %TempObj.DontWeld = false;
        %TempObj.DontDel = false;
}

function Grabler::move(%player,%target)
{
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(Player::isTriggered(%player,$WeaponSlot) && %weapon == Grabbler)
	{
		if(%player.GrabObject != %target || %player.GrabObject == "")
		{
			%player.GrabObject = "";
			%player.Grabdist = "";
			%player.GrabRoty = "";
			%player.GrabOffsetVec = "";
			return;
		}
		%type = getObjectType(%target);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		//position of tip
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z
			%GunTipPos = %posX@" "@%posY@" "@%posZ;
		//direction gun is pointed foo.
		%d1= getWord(%trans,3);
			%d2= getWord(%trans,4);
			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas
			%GunRotVec = %d1 @" " @ %d2 @" " @ %d3;

		%dist = %player.Grabdist;

		if(%type == "Player" || %type == "Flier")
		{
			Item::setVelocity(%target, 0);
			%position = %posX + %d1 * %dist@" "@%posY + %d2 * %dist@" "@%posZ + %d3 * %dist;
			if(GameBase::testPosition(%target, %position))
			{
				GameBase::setPosition(%target,%position);
			}
			else
			{
				%TargetPos = GameBase::getPosition(%target);
				%oldheight = getword(%TargetPos,2);
				%newHeight = getword(%position,2);

				//player aiming down, pushing player through ground?
				if(%newHeight < %oldheight)		//%d3 < -0.5)
				{
					//Player::trigger(%player,$WeaponSlot,false);
					GameBase::setPosition(%target,vector::add(%TargetPos,"0 0 0.2"));
					return;
				}
				else
				{

					%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);
				}

			}
			schedule("Grabler::move("@%player@","@%target@");",0.037);
		}
		else
		{
			%targetRelative = %player.GrabRoty;
			%playerRot = GameBase::getRotation(%player);
			%newrot = vector::add(%playerRot,%targetRelative);
			%GunExtPos = vector::add(vector::multiply(%GunRotVec,%dist@" "@%dist@" "@%dist),%GunTipPos);

			%OffsetVec = %player.GrabOffsetVec;
	//	bottomprint(Player::getClient(%player),%OffsetVec@" "@%playerRot);
	//		%OffsetVecNew = RotateVector(%OffsetVec,%targetRot);	//%newrot);	//ah the joys of rotation...
			%position = vector::add(%GunExtPos,%OffsetVec);	//%OffsetVecNew
			GameBase::setPosition(%target,%position);
            if(!%target.DontRot)
                GameBase::setRotation(%target,%newrot);
                
			schedule("Grabler::move("@%player@","@%target@");",0.025);
		}


	}

}

$Use[Grabbler] = true;
$AutoUse[Grabbler] = true;
$WeaponAmmo[Grabbler] = "";

$ItemMax[larmor, Grabbler] = 1;
$ItemMax[lfemale, Grabbler] = 1;

AddToInv(Grabbler);
AddWeapon(Grabbler);
