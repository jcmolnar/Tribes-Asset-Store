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








$friendlyFireList[0] = "Watch where you're shooting, pal!~wwshoot3";   // Watch where you're shooting






function BotTypes::IsCMD(%aiName)         //Checks if %aiName is a roaming bot
{
    if(String::findSubStr(%aiName, "CMD") >= 0)
		return 1;

	return 0;
}

function BotTypes::IsRoam(%aiName)         //Checks if %aiName is a roaming bot
{
    if(String::findSubStr(%aiName, "CMD") == 0)
		return 1;

	return 0;
}


function BotTypes::IsGuard(%aiName)         //Checks if %aiName is a Guard Bot
{

    if(String::findSubStr(%aiName, "Guard") >= 0)
		return 1;

	return 0;
}


function BotTypes::IsMortar(%aiName)         //Checks if %aiName is a Mortar Bot
{

    if(String::findSubStr(%aiName, "Mortar") >= 0)
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

