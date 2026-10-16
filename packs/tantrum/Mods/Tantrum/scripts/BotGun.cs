//%%%%%%%%%%%%%%% start helper function call -Floater 
$t1firstbot = "";
$t1secondbot = "";
$t1thirdbot = "";
$t1fourthbot = "";
$t1botmaster = "";

$t2firstbot = "";
$t2secondbot = "";
$t2thirdbot = "";
$t2fourthbot = "";
$t2botmaster = "";

%cactive = false;
%tactive = false;

%firstcheck = false;
%secondcheck = false;
%thirdcheck = false;
%almost = false;

$t1botty = "none";
$t2botty = "none";

function AI::bhelper(%aiName, %armorType, %player, %client, %team, %role)//%aiName, %armorType, %player, %team, %role) 
{ 
   %spawnMarker = GameBase::getPosition(%player); 

   %xPos = getWord(%spawnMarker, 0) + floor(getRandom());// * 15); 
   %yPos = getword(%spawnMarker, 1) + floor(getRandom());// * 10); 
   %zPos = getWord(%spawnMarker, 2);// + 2; 
   %rPos = GameBase::getRotation(%player); 

	%tawn = Client::getTeam(%client);
//			Client::sendMessage(%client,0, %tawn);
   %aiSpawnPos = %xPos @ " " @ %yPos @ " " @ %zPos; 
   %newName = %aiName;
if ($t1firstbot != %aiName && $t2firstbot != %ainame){
	%firstcheck = true;
}
if ($t1secondbot != %aiName && $t2secondbot != %ainame){
	%secondcheck = true;
}
if ($t1thirdbot != %aiName && $t2thirdbot != %ainame){
	%thirdcheck = true;
}
if (%firstcheck == true && %secondcheck == true){
	%almost = true;
}
if (%almost == true && %thirdcheck == true){
	bottomprint(%client, "<jc><f2>:<f1> You created <f2>" @ %ainame @ "<f1> :", 3);
}
else if (%almost != true || %thirdcheck != true){
	bottomprint(%client, "<jc><f2>" @ %ainame @ "<f1> has been reformatted since no other droids were available", 4);
}
if (%tawn == 0){
	$cnumAI++;
	%cactive = true;
	%tactive = false;
}
else if (%tawn == 1){
	$tnumAI++;
	%tactive = true;
	%cactive = false;
}
   $numAI++;
   if ($cnumAI == 1 && %cactive == true) {
	$t1firstbot = %aiName;
	$t1botmaster = %player;
   }
   if ($tnumAI == 1 && %tactive == true) {
	$t2firstbot = %aiName;
	$t2botmaster = %player;

   }
   if ($cnumAI == 2 && %cactive == true) {
	$t1secondbot = %aiName;
	$t1botmaster = %player;
   }
   if ($tnumAI == 2 && %tactive == true) {
	$t2secondbot = %aiName;
	$t2botmaster = %player;
   }
   if ($cnumAI == 3 && %cactive == true) {
	$t1thirdbot = %aiName;
	$t1botmaster = %player;
   }
   if ($tnumAI == 3 && %tactive == true) {
	$t2thirdbot = %aiName;
	$t2botmaster = %player;
   }
   if ($cnumAI == 4 && %cactive == true) {
	$t1fourthbot = %aiName;
	$t1botmaster = %player;
   }
   if ($tnumAI == 4 && %tactive == true) {
	$t2fourthbot = %aiName;
	$t2botmaster = %player;
   }
//	if ($numAI >= 5)
//	{
//		return;
//	}
//	else {
   Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos); 

    %ai = AI::getId(%newName); 
//   %client = Player::getClient(%player); 
    %barmor = Player::getArmor(%ai); 
//   %slave = Player::getClient(%ai); 
    %botterIQ = floor(getRandom() * 125) + 100;
	if (%botterIQ <= 200) {
		%newVari = 200 - %botterIQ;
		%botterIQ = %botterIQ + %newVari;
	}

   GameBase::setTeam(%ai, %team); 

   if($debug) 
    echo(%client @ " Created a droid."); 


   //%%weapon usage 
      if(%barmor == "marmor") 
         { 
         Player::setItemCount(%ai,chaingun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,shotgun,1);//%slave,Blaster,1); 
         Player::setItemCount(%ai,ShieldPack,1);//%slave,Blaster,1);
         Player::setItemCount(%ai,repairkit,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,disclauncher,0);//%slave,DiscLauncher,0); 
            AI::behavior(%client, %ai, %role, %newName, tarmor, %botterIQ); 
         } 
      else if(%barmor == "light") 
         { 
         Player::setItemCount(%ai,shotgun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,rocketlauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,chaingun,1);//%slave,Blaster,1);
         Player::setItemCount(%ai,EnergyPack,1);//%slave,Blaster,1);
         Player::setItemCount(%ai,repairkit,1);//%slave,Blaster,1);
         Player::mountItem(%ai,chaingun,0);//%slave,DiscLauncher,0); 
            AI::behavior(%client, %ai, %role, %newName, tarmor, %botterIQ); 
         } 
      else if(%barmor == "heavy") 
         { 
         Player::setItemCount(%ai,grenadelauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,poly,1);//%slave,Blaster,1); 
         Player::setItemCount(%ai,Energypack,1);//%slave,Blaster,1);
         Player::setItemCount(%ai,repairkit,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,poly,0);//%slave,DiscLauncher,0); 
            AI::behavior(%client, %ai, %role, %newName, tarmor, %botterIQ); 
         } 
      else if(%barmor == "tarmor") 
         {
         Player::setItemCount(%ai,shotgun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,chaingun,1);//%slave,Blaster,1); 
         Player::setItemCount(%ai,EnergyPack,1);//%slave,Blaster,1);
         Player::setItemCount(%ai,repairkit,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,disclauncher,0);//%slave,DiscLauncher,0); 
            AI::behavior(%client, %ai, %role, %newName, tarmor, %botterIQ); 
         } 
      else if(%barmor == "spyfemale") 
         { 
//--------------- 
            if(%role == 11) 
                 { 
         Player::setItemCount(%ai,chaingun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,shotgun,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,disclauncher,0);//%slave,DiscLauncher,0); 

                    %command = 0; 

                    AI::defender(%client, %ai, %newName, %command); 

                    $BotMaster[%ai] = %client; 
                    if($debug) 
                      echo($BotMaster[%ai]); 
                 } 
            else 
                 { 
         Player::setItemCount(%ai,chaingun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,shotgun,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,disclauncher,0);//%slave,DiscLauncher,0); 
                    //Player::mountItem(%ai,Mortar,0);//%slave,Mortar,0); 
                    AI::behavior(%client, %ai, %role, %newName, larmor, %botterIQ); 

                    //export($BotInfo[%ai],"botData.cs",true); 

                 } 
//--------------- 
        }
      else 
         { 
         Player::setItemCount(%ai,chaingun,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,disclauncher,1);//%slave,DiscLauncher,1); 
         Player::setItemCount(%ai,shtogun,1);//%slave,Blaster,1); 
         Player::mountItem(%ai,disclauncher,0);//%slave,DiscLauncher,0); 
            AI::behavior(%client, %ai, %role, %newName, larmor, %botterIQ); 
         } 
    return ( %newName ); 
 } 
//%%%%%%%%%%%%%%% end helper function call -Floater

//%%%%%%%%%%%%AI::behavior(); function! very sexy! I made this when i was high! -Floater 

function AI::behavior(%client, %ai, %role, %newName, %barmor, %botterIQ) 
{ 
         if(%role == 0)//light 
            { 
   if($debug) 
echo("//--------------------Role AI::behavior(" @ %role @ "), master ID: " @ %client @ ", armor: " @ %barmor @ "..."); 
                  AI::setVar(%newName, iq, %botterIQ ); 
            AI::DirectiveFollow(%newName, %client); 
            AI::SetAutomaticTargets(%newName); 
            } 
         else if(%role == 1)//medium 
            { 
   if($debug) 
echo("//--------------------Role AI::behavior(" @ %role @ "), master ID: " @ %client @ ", armor: " @ %barmor @ "..."); 
                  AI::setVar(%newName, iq, %botterIQ ); 
            AI::DirectiveFollow(%newName, %client); 
            AI::SetAutomaticTargets(%newName); 
            } 
         else if(%role == 2)//medium 
            { 
   if($debug) 
echo("//--------------------Role AI::behavior(" @ %role @ "), master ID: " @ %client @ ", armor: " @ %barmor @ "..."); 
                  AI::setVar(%newName, iq, %botterIQ ); 
            AI::DirectiveFollow(%newName, %client); 
            AI::SetAutomaticTargets(%newName); 
            } 
         else if(%role == 3)//heavy 
            { 
   if($debug) 
echo("//--------------------Role AI::behavior(" @ %role @ "), master ID: " @ %client @ ", armor: " @ %barmor @ "..."); 
                  AI::setVar(%newName, iq, %botterIQ ); 
            AI::DirectiveFollow(%newName, %client); 
            AI::SetAutomaticTargets(%newName); 
            } 
         else 
            { 
   if($debug) 
echo("//--------------------Role AI::behavior(" @ %role @ "), master ID: " @ %client @ ", armor: " @ %barmor @ "..."); 
                  AI::setVar(%newName, iq, %botterIQ ); 
            AI::DirectiveFollow(%newName, %client); 
            AI::SetAutomaticTargets(%newName); 

            } 
    ai::callbackPeriodic(%NewName, 5, ai::periodicWeaponChange);
//	}
} 

function AI::defender(%client, %ai, %newName, %command) 
{ 
     AI::setVar(%newName,iq,225); 

     if(%command == 0) 
     {
     AI::directiveTargetLaser(%newName,%client); 
     AI::SetVar( %newName, triggerPct, 100 );
     }
     else if(%command == 1) 
     { 
     AI::DirectiveFollow(%newName,%client); 
     AI::SetAutomaticTargets(%newName); 
     } 
}