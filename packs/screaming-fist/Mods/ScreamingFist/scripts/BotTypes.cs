echo("Loading Screaming Fist Version");
// Bot Type Functions by Wicked69 (Paul@Lathope.demon.co.uk) Started 6/11/1999.
// This code need changing to new bot format - You wanted this job!


$vcheerList[0] = "cheer1";   	// YEAH			//This sets up a list of voice comments
$vcheerList[1] = "cheer2";   	// WOO-HOO
$vcheerList[2] = "cheer3";   	// ALL RIGHT
$vcheerList[3] = "taunt1";   	// Yooo-Hooo!
$vcheerList[4] = "taunt10";    // Howd that feel?
$vcheerList[5] = "tautn11";    // I've Had worse
$vcheerList[6] = "taunt2";   	// Missed me!
$vcheerList[7] = "taunt3";   	// Dance!
$vcheerList[8] = "taunt4";   	// Come Get some
$vcheerList[9] = "taunt4";   	// Come Get some

$cheerList[0] = "Yeah, that's the ticket!~wcheer1";   	// YEAH			//This sets up a list of voice comments
$cheerList[1] = "Woo-hoo!! That gotta hurt!~wcheer2";   	// WOO-HOO
$cheerList[2] = "All right!!~wcheer3";   	// ALL RIGHT
$cheerList[3] = "Yooo-Hooo!~wtaunt1";   	// Yooo-Hooo!
$cheerList[4] = "How did that feel?~wtaunt10";    // Howd that feel?
$cheerList[5] = "I've had worse~wtautn11";    // I've Had worse
$cheerList[6] = "Missed me, sucker!~wtaunt2";   	// Missed me!
$cheerList[7] = "Dance!~wtaunt3";   	// Dance!
$cheerList[8] = "Come get some.~wtaunt4";   	// Come Get some
$cheerList[9] = "Come get some.~wtaunt4";   	// Come Get some


$vsuckList[0] = "color3";   	// Hmmm
$vsuckList[1] = "color6";   	// Dammit!
$vsuckList[2] = "color7";   	// Ahhh Crap!
$vsuckList[3] = "dsgst1";   	// Duh!
$vsuckList[4] = "dsgst2";   	// You Idiot!
$vsuckList[5] = "dsgst4";   	// AWWWWWUUUUHHH!!
$vsuckList[6] = "dsgst5";   	// <SIGH resignation of>
$vsuckList[7] = "oops1";   	// DOH! 
$vsuckList[8] = "oops2";   	// Ooops!
$vsuckList[9] = "oops2";   	// Ooops!

$suckList[0] = "Hmmm.~wcolor3";   	// Hmmm
$suckList[1] = "Damnit!~wcolor6";   	// Dammit!
$suckList[2] = "Ahhh crap!~wcolor7";   	// Ahhh Crap!
$suckList[3] = "Duh!~wdsgst1";   	// Duh!
$suckList[4] = "You Idiot!~wdsgst2";   	// You Idiot!
$suckList[5] = "AWWWWUUUUHHH!!~wdsgst4";   	// AWWWWWUUUUHHH!!
$suckList[6] = "What should I say?~wdsgst5";   	// <SIGH resignation of>
$suckList[7] = "Doh!~woops1";   	// DOH! 
$suckList[8] = "Ooops!~woops2";   	// Ooops!
$suckList[9] = "Ooops!~woops2";   	// Ooops!

$friendlyFireList[0] = "Watch where you're shooting, pal!~wwshoot3";   // Watch where you're shooting






function BotTypes::IsRoam(%aiName)         //Checks if %aiName is a roaming bot
{
    if(String::findSubStr(%aiName, "Roam") >= 0)
		return 1;

	return 0;
}


function BotTypes::IsGuard(%aiName)         //Checks if %aiName is a Guard Bot
{

    if(String::findSubStr(%aiName, "Guard") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsDemo(%aiName)         //Checks if %aiName is a Demo Bot
{

    if(String::findSubStr(%aiName, "Demo") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsPainter(%aiName)         //Checks if %aiName is a Painting bot
{

    if(String::findSubStr(%aiName, "Painter") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsSniper(%aiName)         //Checks if %aiName is a Sniper bot
{

    if(String::findSubStr(%aiName, "Sniper") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsMedic(%aiName)         //Checks if %aiName is a Medic bot
{

    if(String::findSubStr(%aiName, "Medic") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsMiner(%aiName)         //Checks if %aiName is a Mining bot
{

    if(String::findSubStr(%aiName, "Miner") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsRecorder(%aiName)         //Checks if %aiName is a TreePoint Recorder - Testing
{

    if(String::findSubStr(%aiName, "Record") >= 0)
		return 1;

	return 0;
}

