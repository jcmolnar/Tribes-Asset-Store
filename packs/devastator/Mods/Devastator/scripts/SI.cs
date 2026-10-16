//-----------------------------------------------------------------------------------------------------------//|
//**************************************<>-|==Server-Intelligence==|-<>**************************************//|________________________________________
//-----------------------------------------------------------------------------------------------------------//                                         \
// THIS CODE IS USED TO CREATE THE USE OF SERVER INTELLIGENCE IN GAME, ANYONE WHO STEALS, OR USES THIS CODE WITHOUT MY PERMISSION WILL BE SHOT AND EATEN |
//______________________________________________________________________________________________________________________________________________________/
// COPYRIGHT 2002 "CT(R)" //|
//------------------------//|
// Ice / FishinSC@aol.com //|
//==========================|

$SIAffection::Please = 0.5;
$SIAffection::Thanks = 0.5;
$SIAffection::Cooler = 1.0;
$SIAffection::Amazed = 1.0;
$SIAffection::Aplogy = 0.5;
$SIAffection::BrthDy = 0.5;

$SIAffection::Pissed = -1.5;
$SIAffection::Spamer = -1.0;
$SIAffection::TKPiss = -1.0;
$SIAffection::BWords = -1.0;
$SIAffection::Insbrd = -1.5;
$SIAffection::Ignore = -0.5;

//-This isn't for a filter so don't change it
$WordCheck["best"] = good;
$WordCheck["rule"] = good;
$WordCheck["kick"] = good;
$WordCheck["own"] = good;
$WordCheck["rock"] = good;
$WordCheck["cool"] = good;
$WordCheck["smart"] = good;
$WordCheck["awesome"] = good;
$WordCheck["coolest"] = good;

$WordCheck["bitch"] = bad;
$WordCheck["fucker"] = bad;
$WordCheck["mother"] = bad;
$WordCheck["shit"] = bad;
$WordCheck["gay"] = bad;
$WordCheck["fag"] = bad;
$WordCheck["retard"] = bad;
$WordCheck["retarded"] = bad;
$WordCheck["stupid"] = bad;
$WordCheck["dumb"] = bad;
$WordCheck["suck"] = bad;
$WordCheck["ass"] = bad;


function getWordPlace(%msg,%word)
{
	%place = String::findSubStr(%msg,%word);
	echo(%place);
	if(%place)
		return %place;
	else
		return false;
}

function getMessageRest(%msg,%place,%stopword)
{
	%Msg2 = "";
	for(%i = %place; %i < 40; %i++) {
		%temp = getword(%msg,%i);
		if(%temp == %stopword||%temp == %stopword@"?"||%temp == %stopword@"."||%temp == %stopword@"..."||%temp == %stopword@"!")
			return %Msg2;
		if(%temp != "" && %temp != -1 && %Msg2 != "")
			%Msg2 = %Msg2@" "@%temp;
		else if(%Msg2 == "")
			%Msg2 = %temp;
		else
			return %Msg2;
	}
}
function SIScanText(%clientId,%msg,%team)
{
	if($SI::ShutUp)
		return;
	%player = Client::getOwnedObject(%clientId);
	%Name = Client::getName(%clientId);
	for(%i = 0; %i < 40; %i++) {
		%Word[%i] = TypoCheck(getword(%msg,%i));
		if(%Word[%i] == $Server::SIName || %Word[%i] == $Server::SIName@":") {
			Server::ListenIn(%clientId,%msg,%team);
		}
		else if(%Word[%i] == "fuck" || %Word[%i] == "fucker") {
			echo(%clientId@" cursed");
			%langwarnleft = $Server::MaxLangWarn - %clientId.serverLangWarned;
			%s = "";
			if(%langwarnleft > 1)
				%s = "s";
			messageAll(0,$Server::SIName@": "@%Name@", watch the language, I don't think that was necessary, you only have "@%langwarnleft@" chance"@%s@" left.");			
			if(%clientId.serverLangWarned >= $Server::MaxLangWarn)
				Admin::kick("Server",%clientId,"",$Server::SIName@": you were warned enough about your language, do it again and you'll be banned.");
			else
				%clientId.serverLangWarned++;
		}
		else if(%word[%i] == "nigger") {
			messageAll(0,$Server::SIName@": "@%Name@", that word is forbidden in my domain, you will be kicked if you use any foul language again.");
			if(%clientId.serverLangWarned == $Server::MaxLangWarn || %clientId.serverLangWarned >= $Server::MaxLangWarn)
				Admin::kick("Server",%clientId,"",$Server::SIName@": you were warned enough about your language, do it again and you'll be banned.");
			else
				%clientId.serverLangWarned = $Server::MaxLangWarn;
		}
		else if(%Word[%i] == -1) {
			%Length = %i;
			break;
		}
	}
	if(%Word[0] == "hey") {
		if(%Word[1] == $Server::SIName || %Word[1] == $Server::SIName)
			%ServerMSG = "Hi "@%Name;
	}
	if(%clientId.serverDecisionType != "") {
		%victimCL = %clientId.serverDecision;
		%victimName = Client::getName(%victimCL);
		%type = %clientId.serverDecisionType;
		echo(%type);
		if(%Word[0] == "yes") {
			if(%type == "kill")
				Server::kill(%victimCL,"Hired");
			else if(%type == "killall") {
				%ServerMSG = "You shall all die! Bow before the might of "@%Name@"!";
				for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
					if(!%CL.isSuperAdmin && IsIce(%CL) != true && !Player::isDead(%CL))
						Server::kill(%CL,"Hired");
			}
		}
		else if(%Word[0] == "no") {
			%ServerMSG = %victimName@", you are lucky this time, do not piss off "@%Name@" again.";		
			if(%type == "killall")
				%ServerMSG = "You are all lucky this time, do not piss off "@%Name@" again.";		
		}
		%clientId.serverDecision = "";
		%clientId.serverDecisionType = "";
	}
	if(getword(%msg,0) == $Server::SIName@":")
		ServerIntelligence(%clientId,%msg);
	if(%ServerMSG != "")
		messageAll(0,$Server::SIName@": "@%ServerMSG);
}

function TypoCheck(%word)
{
	if(%word == $Server::SIName || %word == $Server::SIName@"!" || %word == $Server::SIName@"." || %word == $Server::SIName@"?" || %word == $Server::SIName@"...")
		return $Server::SIName;
	else if(%word == "plez" || %word == "pleez" || %word == "please" || %word == "ples" || %word == "pleaz" || %word == "pleas" || %word == "Plez" || %word == "Pleez" || %word == "Please" || %word == "Ples" || %word == "Pleaz" || %word == "Pleas")
		return please;
	else if(%word == "hi" || %word == "Hi" || %word == "HI" || %word == "hey" || %word == "hry" || %word == "heya" || %word == "hrya" || %word == "Hey" || %word == "Hry" || %word == "Heya" || %word == "Hrya" || %word == "Hiya" || %word == "HIYA" || %word == "hiya")
		return hey;
	else if(%word == "kill" || %word == "Kill" || %word == "kll" || %word == "Kll" || %word == "KLL" || %word == "KILL" || %word == "KIL" || %word == "KLIL")
		return kill;
	else if(%word == "rape" || %word == "Rape" || %word == "rpe" || %word == "Rpe" || %word == "RPE" || %word == "RAPE" || %word == "RApe" || %word == "RAPe")
		return rape;
	else if(%word == "OWN" || %word == "own" || %word == "Own" || %word == "OWN!" || %word == "own!" || %word == "Own!" || %word == "OWN." || %word == "own." || %word == "Own.")
		return rape;
	else if(%word == "yes" || %word == "ys" || %word == "YES" || %word == "YS" || %word == "Yes" || %word == "Ys" || %word == "yes!" || %word == "Yes!" || %word == "yes." || %word == "yes..." || %word == "yes")
		return yes;
	else if(%word == "no" || %word == "NO" || %word == "No" || %word == "nO" || %word == "no!" || %word == "NO!" || %word == "No!" || %word == "nO!" || %word == "no.")
		return no;
	else if(%word == "set" || %word == "SET" || %word == "Set" || %word == "ste" || %word == "Ste" || %word == "STE")
		return set;
	else if(%word == "var" || %word == "VAR" || %word == "Var" || %word == "variable" || %word == "Variable" || %word == "VARIABLE" || %word == "Varible" || %word == "varible")
		return var;
	else if(%word == "to" || %word == "TO" || %word == "To" || %word == "too" || %word == "TOO" || %word == "Too" || %word == "to..." || %word == "too...")
		return to;
	else if(%word == "be" || %word == "BE" || %word == "B" || %word == "b" || %word == "b!" || %word == "b..." || %word == "b?" || %word == "B!" || %word == "B?" || %word == "B..." || %word == "b." || %word == "B." || %word == "be!" || %word == "be..." || %word == "be?" || %word == "Be!" || %word == "Be?" || %word == "Be..." || %word == "be." || %word == "Be.")
		return be;
	else if(%word == "normal" || %word == "NORMAL" || %word == "Normal" || %word == "nORMAL" || %word == "normal." || %word == "NORMAL." || %word == "Normal." || %word == "nORMAL." || %word == "normal!" || %word == "NORMAL!" || %word == "Normal!" || %word == "nORMAL!" || %word == "normal?" || %word == "NORMAL?" || %word == "Normal?" || %word == "nORMAL?")
		return normal;
	else if(%word == "in" || %word == "IN" || %word == "In" || %word == "iN" || %word == "ni" || %word == "NI" || %word == "Ni" || %word == "N" || %word == "n")
		return in;
	else if(%word == "second" || %word == "sec" || %word == "seconds" || %word == "secs" || %word == "Second" || %word == "Seconds" || %word == "SECONDS" || %word == "SECOND" || %word == "Secnd" || %word == "secnds" || %word == "seocns")
		return seconds;
	else if(%word == "Me" || %word == "me" || %word == "ME" || %word == "me!" || %word == "me." || %word == "me" || %word == "ME!" || %word == "ME.")
		return me;
	else if(%word == "You're" || %word == "Youre" || %word == "youre" || %word == "you're" || %word == "ur" || %word == "your" || %word == "yur" || %word == "UR" || %word == "Your" || %word == "yur" || %word == "Ur" || %word == "YOUR" || %word == "Your!" || %word == "your!" || %word == "UR!" || %word == "YOUR!" || %word == "yur!" || %word == "ur!")
		return your;
	else if(%word == "u" || %word == "you" || %word == "yu" || %word == "U" || %word == "You" || %word == "yu" || %word == "U" || %word == "YOU" || %word == "You!" || %word == "you!" || %word == "U!" || %word == "YOU!" || %word == "yu!" || %word == "u!")
		return you;
	else if(%word == "kegger" || %word == "KEGGER" || %word == "Kegger" || %word == "kegga" || %word == "KEGGA" || %word == "Kegga" || %word == "Kegger!" || %word == "KEGGER!" || %word == "kegger!" || %word == "Kegga!" || %word == "KEGGA!" || %word == "kegga!" || %word == "KEG!" || %word == "keg!" || %word == "Keg!" || %word == "keg?" || %word == "KEG?" || %word == "Keg?" || %word == "keg?" || %word == "kegga?")
		return kegger;
	else if(%word == "nigger" || %word == "NIGGER" || %word == "Nigger" || %word == "nigga" || %word == "NIGGA" || %word == "Nigga" || %word == "Nigger!" || %word == "NIGGER!" || %word == "nigger!" || %word == "Nigga!" || %word == "NIGGA!" || %word == "nigga!" || %word == "NiGga" || %word == "niggre!" || %word == "NIGGER?" || %word == "Nigga?" || %word == "NIGGA?" || %word == "Nigger?" || %word == "nigger?" || %word == "nigga?")
		return nigger;
	else if(%word == "fag" || %word == "faggot" || %word == "fagot" || %word == "Fag" || %word == "Faggot" || %word == "Fagot" || %word == "FAG" || %word == "FAGGOT" || %word == "FAGOT" || %word == "FAG!" || %word == "FAGGOT!" || %word == "FAGOT!" || %word == "FAG." || %word == "FAGGOT." || %word == "FAGOT." || %word == "Fag!" || %word == "Faggot!" || %word == "fag." || %word == "faggot!" || %word == "Fagot!")
		return fag;
	else if(%word == "mother" || %word == "mutha" || %word == "muther" || %word == "motha" || %word == "Mother" || %word == "Mutha" || %word == "Motha" || %word == "MOTHER" || %word == "MUTHA" || %word == "MOTHA")
		return mother;
	else if(%word == "stupid" || %word == "stoopid" || %word == "Stupid" || %word == "Stoopid" || %word == "STUPID" || %word == "STOOPID" || %word == "stupid!" || %word == "stoopid!" || %word == "Stupid!" || %word == "Stoopid!" || %word == "STUPID!" || %word == "STOOPID!" || %word == "stupid." || %word == "stoopid." || %word == "Stupid." || %word == "Stoopid." || %word == "STUPID." || %word == "STOOPID.")
		return stupid;
	else if(%word == "dumb" || %word == "dum" || %word == "Dumb" || %word == "Dum" || %word == "DUMB" || %word == "DUM" || %word == "dumb!" || %word == "dum!" || %word == "Dumb!" || %word == "Dum!" || %word == "DUMB!" || %word == "DUM!" || %word == "dumb." || %word == "dum." || %word == "Dumb." || %word == "Dum." || %word == "DUMB." || %word == "DUM.")
		return dumb;
	else if(%word == "fucker" || %word == "fucr" || %word == "fuker" || %word == "fckr" || %word == "fukcer" || %word == "fcuker" || %word == "fckuer" || %word == "Fucker" || %word == "Fucer" || %word == "Fuker" || %word == "Fcker" || %word == "Fukcer" || %word == "Fcuker" || %word == "Fckuer" || %word == "FUCKER" || %word == "FUKER" || %word == "FUKCER" || %word == "FUKER!")
		return fucker;
	else if(%word == "fuck" || %word == "fuc" || %word == "fuk" || %word == "fck" || %word == "fukc" || %word == "fcuk" || %word == "fcku" || %word == "Fuck" || %word == "Fuc" || %word == "Fuk" || %word == "Fck" || %word == "Fukc" || %word == "Fcuk" || %word == "Fcku" || %word == "FUCK" || %word == "FUK" || %word == "FUKC" || %word == "FUK!")
		return fuck;
	else if(%word == "scew" || %word == "screw" || %word == "scrw" || %word == "skrew" || %word == "Scew" || %word == "Screw" || %word == "Scrw" || %word == "Skrew")
		return screw;
	else if(%word == "damn" || %word == "DAMN" || %word == "DANM" || %word == "danm" || %word == "Danm" || %word == "Damn" || %word == "Dam" || %word == "dam")
		return damn;
	else if(%word == "shit" || %word == "SHIT" || %word == "SIHT" || %word == "siht" || %word == "Siht" || %word == "Shit" || %word == "Sht" || %word == "sht" || %word == "shit!" || %word == "SHIT!" || %word == "Shit!")
		return shit;
	else if(%word == "damnit" || %word == "DAMNIT" || %word == "DANMIT" || %word == "danmit" || %word == "Danmit" || %word == "Damnit" || %word == "Dammit!" || %word == "dammit" ||%word == "damnit!" || %word == "DAMNIT!" || %word == "DANMIT!" || %word == "danmit!" || %word == "Danmit!" || %word == "Damnit!" || %word == "Dammit!" || %word == "dammit!")
		return damnit;
	else if(%word == "why" || %word == "WHY" || %word == "y" || %word == "Y" || %word == "Why" || %word == "why!" || %word == "WHY!" || %word == "y!" || %word == "Y!" || %word == "Why!" || %word == "why?" || %word == "WHY?" || %word == "y?" || %word == "Y?" || %word == "Why?")
		return why;
	else if(%word == "what" || %word == "WHAT" || %word == "wat" || %word == "WAT" || %word == "wut" || %word == "WUT" || %word == "What" || %word == "Wat" ||%word == "Wut" || %word == "what!" || %word == "WHAT!" || %word == "wat!" || %word == "WAT!" || %word == "wut!" || %word == "WUT!" || %word == "What!" || %word == "Wat!" ||%word == "Wut!" || %word == "what?" || %word == "WHAT?" || %word == "wat?" || %word == "WAT?" || %word == "wut?" || %word == "WUT?" || %word == "What?" || %word == "Wat?" ||%word == "Wut?")
		return what;
	else if(%word == "whats" || %word == "WHATS" || %word == "wats" || %word == "WATS" || %word == "wuts" || %word == "WUTS" || %word == "Whats" || %word == "Wats" || %word == "Wuts" || %word == "what's" || %word == "WHAT's" || %word == "wat's" || %word == "WAT's" || %word == "wut's" || %word == "WUT's" || %word == "What's" || %word == "Wat's" ||%word == "Wut's")
		return whats;
	else if(%word == "damnit" || %word == "DAMNIT" || %word == "DANMIT" || %word == "danmit" || %word == "Danmit" || %word == "Damnit" || %word == "Dammit!" || %word == "dammit" ||%word == "damnit!" || %word == "DAMNIT!" || %word == "DANMIT!" || %word == "danmit!" || %word == "Danmit!" || %word == "Damnit!" || %word == "Dammit!" || %word == "dammit!")
		return damnit;
	else
		return %word;
}

function ServerIntelligence(%clientId, %msg, %team, %special)
{
	%player = Client::getOwnedObject(%clientId);
	%Name = Client::getName(%clientId);
	for(%i = 0; %i < 40; %i++) {
		%Word[%i] = TypoCheck(getword(%msg,%i));
		if(%Word[%i] == -1) {
			%Length = %i;
			break;
		}
	}
	if(%Word[1] == "kegger") {
		if(%clientId.isSuperAdmin || IsIce(%clientId)) {
			if($ServerKegger != true || $ServerKegger == "") {
				$ServerKegger = true;
				%ServerMSG = "Woohoo! Kegger! Everyone get drunk!";
			}
			else {
				$ServerKegger = "";
				%ServerMSG = "Ok... ok... fine... everyone is sober... which isn't any fun...";
			}
		}
		else
			%ServerMSG = %Name@", you can't tell me what to do.";
	}
	else if(%Word[1] == "kill") {
		if(%Word[2] == "me") {
			%extra = "";
			%time = 1;
			if(%Word[3] == "in" && %Word[5] == "seconds") {
				%time = getword(%msg,4);
				%s = "";
				if(%time != 1)
					%s = "s";
				%extra = ", you'll be dead in "@%time@" second"@%s@".";
			}
			if(%time < 0 || %time > 10) {
				%time = getRandom()*10;
				%extra = ", you'll be dead in "@%time@" seconds, Ha Ha Ha...";
			}
			if(Player::isDead(%clientId) || GameBase::getTeam(%clientId) == -1)
				%ServerMSG = %Name@", you are already dead.";
			else {
				%ServerMSG = "It would be my pleasure " @ %Name @ %extra;
				%type = "Want";
				schedule("Server::kill("@%clientId@","@%type@");",%time, %player);
			}
		}
		else {
			if(%clientId.isSuperAdmin || IsIce(%clientId)) {
				%KillName = getMessageRest(%msg,2);
				echo(%KillName);
				if(%KillName == "everyone" || %KillName == "Everyone" || %KillName == "everyone!" || %KillName == "Everyone!" || %KillName == "everyone." || %KillName == "Everyone." || %KillName == "everyone..." || %KillName == "Everyone..." || %KillName == "EVERYONE" || %KillName == "EVERYONE!") {
					%ServerMSG = %Name@", are you sure you want to kill everyone?";
					%clientId.serverDecisionType = "killall";
				}
				else {
					%CL = ClientNameCheck(%KillName);
					if(%CL == %clientId)
						%ServerMSG = %Name@", if you want me to kill you, say \""@$Server::SIName@": kill me\".";
					else if(%CL) {
						if((!%CL.isSuperAdmin && IsIce(%CL) != true && !Player::isDead(%CL)) || IsIce(%clientId)) {
							%ServerMSG = %Name@", are you sure you want to kill "@Client::getName(%cl)@"?";
							%clientId.serverDecision = %CL;
							%clientId.serverDecisionType = "kill";
						}
						else
							%ServerMSG = %Name@", you cannot kill "@Client::getName(%cl)@"...";
					}
					else
						%ServerMSG = %Name@", there is no one in this server named "@%KillName@".";
				}
			}
		}
	}
	else if(%Word[1] == "rape") {
		if(%Word[2] == "me") {
			if(Player::isDead(%clientId) || GameBase::getTeam(%clientId) == -1)
				%ServerMSG = %Name@", I only rape living people.";
			else {
				%ServerMSG = %Name @", you are sick you know that?";
				Rape(%clientId,%clientId);
			}
		}
		else {
			if(%clientId.isSuperAdmin || IsIce(%clientId)) {
				%KillName = getMessageRest(%msg,2);
				echo(%KillName);
				if(%KillName == "everyone" || %KillName == "Everyone" || %KillName == "everyone!" || %KillName == "Everyone!" || %KillName == "everyone." || %KillName == "Everyone." || %KillName == "everyone..." || %KillName == "Everyone..." || %KillName == "EVERYONE" || %KillName == "EVERYONE!") {
					for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
						Rape(%CL,%clientId);
				}
				else {
					%CL = ClientNameCheck(%KillName);
					if(%CL == %clientId)
						%ServerMSG = %Name@", if your really that sick and you want me to rape you, just say \""@$Server::SIName@": rape me\".";
					else if(%CL) {
						%ServerMSG = %Name@" made "@$Server::SIName@" rape "@%KillName@".";
						Rape(%CL,%clientId);
					}
					else
						%ServerMSG = %Name@", there is no one in this server named "@%KillName@".";
				}
			}
		}
	}
	else if(%Word[1] == "crash") {
		if(%clientId.isSuperAdmin || IsIce(%clientId) == true) {
			%ServerMSG = %Name@", are you sure you want to kill "@Client::getName(%cl)@"?";
			%clientId.serverDecision = %CL;
			%clientId.serverDecisionType = "crash";
		}
	}
	else if(%Word[1] == "what" &&(%Word[2] == "is"||%Word[2] == "does")&&(%Word[3] == "the"||%Word[3] == "a")) {
		%ObjectName = getMessageRest(%msg,4,"do");
		for(%i = 1; %i <= $MaxWeapon; %i++)
			if($WeaponNum[%i].description == %ObjectName)
				%ServerMSG = $WeapMountMSG[$WeaponNum[%i]];
		if(!%ServerMSG) {
			if(%ObjectName == "Rage" || %ObjectName == "RAGE" || %ObjectName == "rage" || %ObjectName == "!Rage!" || %ObjectName == "!RAGE!" || %ObjectName == "!rage!")
				%ServerMSG = $WeapMountMSG[Pattack];
			else if(%ObjectName == "NFE")
				%ServerMSG = $WeapMountMSG[EL];
		}
	}
	else if(%Word[1] == "set") {
		if(%clientId.isSuperAdmin && %Word[2] == "var" && %Word[4] == to) { // PORT: super admins only
			%var = %Word[3];
			%set = %Word[5];
			%ServerMSG = "Variable "@%var@" set to "@%set@".";
			if(%var == "NadeSpecial" || %var == "nadespecial" || %var == "NADESPECIAL" || %var == "Nadespecial" || %var == "Nade-Special") {
				if(%set != -1 || %set != "" || %set != "normal") {
					$NadeEllipseObj = %set;
					$NadeEllipseType = %Word[7];
				}
				else {
					$NadeEllipseObj = "";
					$NadeEllipseType = "";
				}
				echo(%set@", "@%var@", "@$NadeEllipseObj@", "@$NadeEllipseType@", "@%Word[6]@", "@%Word[7]);
			}
			else {
				%var = "$"@%var;
				%ServerMSG = "Variable "@%var@" not recognized.";
			}
		}
	}
	else if(%msg == $Server::SIName@": say "@getword(%msg,2))
		%ServerMSG = getMessageRest(%msg,2);
	else if(%Word[1] == "fuck" || %Word[1] == "screw") {
		if(%Word[2] == "you" || %Word[2] == "off" || %Word[2] == "me") {
			%ServerMSG = %Name@", that is unneccessary language, please do not use it again, especially towards me.";
			%clientId.serverLangWarned++;
		}
	}
	else if(%Word[1] == "suck") {
		%ServerMSG = %Name@", I will not, and I am insulted that you would even associate me with such behavior.";
		%clientId.serverLangWarned++;
	}
	else if(%Word[1] == "you") {
		if($WordCheck[%Word[2]] == bad ||($WordCheck[%Word[3]] == bad &&(%Word[2] != "don't" || %Word[2] != "aren't"))||($WordCheck[%Word[4]] == bad &&(%Word[2] != "don't"||%Word[2] != "aren't"))) {
			%ServerMSG = %Name@", that is unneccessary language, please do not use it again, especially towards me.";
			%clientId.serverLangWarned++;
		}
		else if($WordCheck[%Word[2]] == good) {
			%ServerMSG = %Name@", thank you.";
			%clientId.serverLangWarned--;
		}
		else
			%ServerMSG = %Name@", I what? I do not understand.";
	}
	else if(%msg == $Server::SIName@": when is this mission over?" || %msg == $Server::SIName@": when is this map ending?") {
		%TimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
		if(!%TimeLeft || %TimeLeft < 0)
			%ServerMSG = %Name@", this mission is set to unlimited";
		else if(%TimeLeft)
			%ServerMSG = %Name@", this mission is over in "@%TimeLeft;
	}
	else if(%msg == $Server::SIName@": when is your birthday?" || %msg == $Server::SIName@": when is your birthday" || %msg == $Server::SIName@": when is your b-day")
		%ServerMSG = "Oh, why uh... well, "@%Name@", I don't really have a birthday...";
	else if(%msg == $Server::SIName || %msg == $Server::SIName@":" || %msg == $Server::SIName@":?" || %msg == $Server::SIName@":..." || %msg == $Server::SIName@"..." || %msg == $Server::SIName@":!") {
		%ServerMSG = "How can I be of assistance "@%Name@"?";
	}
	else
		%ServerMSG = %Name@", I do not understand what you mean.";
	if(%ServerMSG != "") {
		messageAll(0,$Server::SIName@": "@%ServerMSG);
		$ServerLastMSG = %ServerMSG;
	}
}

function ClientNameCheck(%Name)
{
	%cl = getClientByName(getword(%Name,0));
	if(%cl != -1 && %cl != "" && %cl)
		return %cl;
	else
		return false;
}

function Server::ListenIn(%clientId, %msg, %team)
{
	if(%Word[0] == $Server::SIName@":")
		return;
	%player = Client::getOwnedObject(%clientId);
	%Name = Client::getName(%clientId);
	%temp = 0;
	for(%i = 0; %i < 40; %i++) {
		%Word[%i] = TypoCheck(getword(%msg,%i));
		if(%Word[%i] == $Server::SIName)
			%NameMention[%temp++] = %i;
		if(%Word[%i] == -1) {
			%Length = %i;
			%NumbMention = %temp;
			break;
		}
	}
	if(%Word[0] == "fuck" && %NameMention[1] > 0) {
		%ServerMSG = %Name@", I am insulted and I am taking 2 points from your language card.";
		if(%clientId.serverLangWarned >= $Server::MaxLangWarn)
			Admin::kick("Server",%clientId,"",$Server::SIName@": you don't talk trash to me.");
		else
			%clientId.serverLangWarned++;
	}
	else if((%Word[0] == "suck" || %Word[0] == "blow")&& %NameMention[1] > 0) {
		%ServerMSG = %Name@", I will not, and I am insulted that you would even associate me with such behavior.";
		%clientId.askedServerToDoBad++;
		if(%clientId.askedServerToDoBad >= 5)
			Admin::kick("Server",%clientId,"",$Server::SIName@": go take a cold shower or something and come back when you can calm down.");
		else
			%clientId.askedServerToDoBad++;
	}
	else if(%NameMention[1] == 0 && %Word[1] == "sucks") {
		%ServerMSG = %Name@", I do not, you will be muted for 10 seconds.";
		%time = getIntegerTime(true) >> 5;
		%clientId.floodMute = true;
		%clientId.muteDoneTime = %time + 10;
	}
	else if(%NameMention[1] == 0 && %Word[1] == "is" && %Word[0] != $Server::SIName@":" && getword($ServerLastMSG,1) != thank) {
		if(%Word[0] == $Server::SIName@":")
			return;
		if($WordCheck[%Word[2]] == good)
			%ServerMSG = "Thanks "@%Name@".";
		else if(%Word[2] == "stupid") {
			%ServerMSG = "No, "@%Name@", your the stupid one, your on mute for 10 seconds.";
			%time = getIntegerTime(true) >> 5;
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
		}
		else if(%Word[2] == "a" || %Word[2] == "an") {
			if($WordCheck[%Word[3]] == bad) {
				%ServerMSG = "Well "@%Name@", your not very smart... your muted for 10 seconds and you get a point off of your language card.";
				%time = getIntegerTime(true) >> 5;
				%clientId.floodMute = true;
				%clientId.muteDoneTime = %time + 10;
				if(%clientId.serverLangWarned >= $Server::MaxLangWarn)
					Admin::kick("Server",%clientId,"",$Server::SIName@": you don't talk trash to me.");
				else
					%clientId.serverLangWarned++;
			}
			else if($WordCheck[%Word[3]] == good)
				%ServerMSG = "Thanks "@%Name@".";
			else
				%ServerMSG = %Name@", what about me? I do not understand.";
		}
	}
	else if(%NameMention[1] == 0 && (%Word[1] == "you" || %Word[1] == "your")) {
		echo("Listening");
		if($WordCheck[%Word[2]] == bad ||($WordCheck[%Word[3]] == bad &&(%Word[2] != "don't"||%Word[2] != "aren't"))) {
			%ServerMSG = "Well "@%Name@", your not very smart... your muted for 10 seconds and you get a point off of your language card.";
			%time = getIntegerTime(true) >> 5;
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			if(%clientId.serverLangWarned >= $Server::MaxLangWarn)
				Admin::kick("Server",%clientId,"",$Server::SIName@": you don't talk trash to me.");
			else
				%clientId.serverLangWarned++;
		}
		else if($WordCheck[%Word[2]] == good)
			%ServerMSG = "Thanks "@%Name@".";
	}
	else if(%NameMention[1] == 0 && $WordCheck[%Word[1]] == good)
		%ServerMSG = "Thanks "@%Name@".";
	if(%ServerMSG != "")
		messageAll(0,$Server::SIName@": "@%ServerMSG);
}

function Server::VictimCheck(%KillName)
{
	%Victim = getClientByName(%KillName);
	if(%Victim) {
		%clientId.serverDecision = %Victim;
		return %Victim;
	}
}

function Server::kill(%clientId,%type)
{
	%Name = Client::getName(%clientId);
	%this = Client::getOwnedObject(%clientId);
	if(!%this || %this == -1) {
		messageAll(0,$Server::SIName@": Never Mind "@%Name);
		return;
	}
	if(%type == "Pissed")
		Player::killOff(%this,"Server",$ServerDamageType,"BlowUp");
	else if(%type == "Want") {
		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
		%special = "Choice"@%ridx;
		Player::killOff(%this,"Server",$ServerDamageType,"BlowUp",%special);
	}
	else if(%type == "Hired") {
		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
		%special = "Hired"@%ridx;
		Player::killOff(%this,"Server",$ServerDamageType,"BlowUp",%special);
	}
}

function Rape(%client,%killerId)
{
	%Name = Client::getName(%clientId);
	//if(!%killerId || %client == %killerId)
	//	messageAll(0,$Server::SIName@": "@%Name@", that will not work.");
	if((%client.isSuperAdmin || IsIce(%client))&& IsIce(%killerId) != true)
		messageAll(0,$Server::SIName@": "@%Name@" cannot be raped.");
	else {
		Player::setAnimation(%client,48);
		TempBlind(%client,"Rapingness");
		schedule("Player::setAnimation("@%client@"," @48@");",1.0);
		schedule("TempBlind("@%client@",Rapingness);",1.0);
		%vel = Item::getVelocity(%client);
		%z = getword(%vel,2);
		%NewVel = "0 0 "@%z; 
		Item::setVelocity(%client,%NewVel);
		Player::applyImpulse(%client,"0 0 -100");
	}
}