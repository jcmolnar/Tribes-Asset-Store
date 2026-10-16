	
//-----------------------------------------Trig Functions---------------------------------------------

$Pi = 3.14159;

function Calc::unifyPi(%num)
{
	if(Calc::abs(%num) > $Pi) {
		%num = Calc::mod(%num,$Pi);
		if(%num > 0)
			%num = -$Pi+%num;
		else if(%num < 0)
			%num = $Pi+%num;
		if(%num > -0.0001 && %num < 0.0001)
			%num = 0;
	}
	return %num;
}

function Calc::Cos(%angle)
{
	%cos = getWord(Vector::getFromRot("0 0 "@%angle),1);
	return(%cos);
}

function Calc::Sin(%angle)
{
	%sin = getWord(Vector::getFromRot(%angle@" 0 0"),2);
	return(%sin);
}

function Calc::Tan(%angle)
{
	%cos = Calc::Cos(%angle);
	%sin = Calc::Sin(%angle);
	if(%cos < 0.0003 && %cos > -0.0003)
		return false;
	return(%sin/%cos);
}

function Calc::Abs(%x)
{
	return(sqrt(pow(%x,2)));
}

function Calc::Rads(%deg)
{
	%rat = %deg/180;
	return %rat*$Pi;
}

function Calc::Degs(%rad)
{
	%rat = %rad/$Pi;
	return %rat*180;
}

function Calc::Mod(%x,%y,%fix) //- failed attempt to solve the infinite negative result with large numbers
{
	//echo("X: "@%x@", Y: "@%y);
	%div = floor(%x / %y);
	%sub = %x - %div*%y;
	if(%fix && %sub < -10) {
		%x2 = floor(%x/1000);
		%y2 = floor(%y/1000);
		echo(%x2@" and "@%y2);
		%div = floor(%x2 / %y2);
		%sub = %x2 - %div*%y2;
		%sub *= 1000;
	}
	return %sub;
}

//-----------------------------------------Group Stuff---------------------------------------------

function Group::areClass(%set,%class,%exclude,%exType)
{
	%count = Group::objectCount(%set);
	for(%i = 0; %i < %count; %i++) {
		%that = Group::getObject(%set,%i);
		if(GameBase::getDataName(%that).className != %class && %that != %exclude && GameBase::getDataName(%that).className != %exType)
			return false;
	}
	return true;
}

//-----------------------------------------Player Stuff---------------------------------------------

function Player::getLookRot(%player,%a)
{
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%proj = projectile::spawnProjectile("look"@%a,%trans,%player,"0 0 0");
	%pVel = Item::getVelocity(%proj);
	%pRot = Vector::add(Vector::getRotation(%pVel),$Pi/2@" 0 0");
	return %pRot;
}

function Look::onAdd(%this)
{
	
}

function nullPos(%this)
{
	%pos = GameBase::getPosition(%this);
	return Vector::compare(%pos,"0 0 0",0.01);
}

function New::getMuzzleTransform(%this,%pow,%offRot,%offZ)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%pos = Vector::add(%pos,Vector::getFromRot(Vector::add(%rot,$Pi/2@" 0 0"),%offZ));
	%rot = Vector::add(%rot,%offRot);
	%trans = %rot@" "@Vector::getFromRot(%rot,%pow)@" "@%rot@" "@%pos;
	if(String::findSubStr(%trans,"NAN") != -1)
		%trans = %rot@" "@Vector::getFromRot($Pi@" 0 0",1)@" "@%rot@" "@%pos;
	return %trans;
}

function GameBase::applyImpulse(%this,%imp)
{
	if(%this == -1 || %this == "")
		return;
	%type = getObjectType(%this);
	if(%type == "Player") {
		%imp = Vector::mult(%imp,"2 2 2");
		Player::applyImpulse(%this,%imp);
		schedule("Player::applyImpulse("@%this@",\""@-%imp@"\");",0.2,%this);
		return;
	}
	else if((%type == "StaticShape" || %type == "InteriorShape")) {
		if(%this.locked)
			return;
		%pos = GameBase::getPosition(%this);
		%oldPos = $lastPos[%this];
		if(%oldPos == "")
			%oldPos = $lastPos[%this] = %pos;
		%add = Vector::div(%imp,"300 300 50");
		%newPos = Vector::add(%oldPos,%add);
		GameBase::setPosition(%this,%newPos);
		schedule("GameBase::setPosition("@%this@",\""@%oldPos@"\");",0.2,%this);
		return;
	}
	%vel = Item::getVelocity(%this);
	%add = Vector::add(%vel,%imp);
	%sub = Vector::mult(Vector::sub(%vel,%imp),"0.25 0.25 0.0");
	Item::setVelocity(%this,%add);
	schedule("Item::setVelocity("@%this@",\""@%sub@"\");",0.1,%this);
}

//-----------------------------------------Vector Stuff---------------------------------------------
//_Rotation: Pitch, Roll, Yaw
//_
//

function Vector::Speed(%this,%opt)
{
	%vel = Item::getVelocity(%this); 
	if(%opt)
		%vel = %this;
	%velX = getword(%vel,0);
	%velY = getword(%vel,1);
	%velZ = getword(%vel,2);
	%speed = sqrt(pow(%velX,2) + pow(%velY,2) + pow(%velZ,2));
	return %speed;
}

function Vector::dif(%vec1,%vec2)
{
	return Vector::speed(Vector::sub(%vec1,%vec2),true);
}

function GetOffSetRot(%offset,%rot,%pos)
{
	%x = getWord(%offset,0);
	%y = getWord(%offset,1);
	%z = getWord(%offset,2);
	%posA = Vector::add(%pos,Vector::getFromRot(Vector::Add(%rot,"0 0 -1.570796327"),%x));
	%posB = Vector::add(%posA,Vector::getFromRot(%rot,%y));
	%posC = Vector::add(%posB,Vector::getFromRot(Vector::Add(%rot,"1.570796327 0 0"),%z));
	return %posC;
}

function Vector::getRotAim(%pos1,%pos2,%neg)
{
	%vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
	if(%neg)
		%vec = Vector::normalize(Vector::sub(%pos1,%pos2));
	%rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
	return %rot;
}

function Vector::make(%a1,%a2,%a3,%a4,%a5,%a6,%a7,%a8,%a9,%a10,%a11,%a12)
{
	%vec = "";
	for(%i = 1; %a[%i] != ""; %i++)
		%vec = %vec@%a[%i]@" ";
	return AeonStr::trim(%vec);
}

function Vector::splice(%vec1,%vec2,%vec3)
{
	%x = getWord(%vec1,0);
	%y = getWord(%vec2,1);
	%z = getWord(%vec3,2);
	%vec = %x@" "@%y@" "@%z;
	return %vec;
}

function Vector::sharpen(%vec)
{
	%end = "";
	for(%i = 0; getWord(%vec,%i) != -1; %i++) {
		%word[%i] = getWord(%vec,%i);
		%tac = "00000999";
		if(%word[%i] == 0)
			%tac = "";
		else if(%word[%i] > 0 && String::findSubStr(%vec,".") == -1) {
			%word[%i]--;
			%tac = ".999999999";
		}
		else if(String::findSubStr(%vec,".") == -1) {
			%word[%i]++;
			%tac = ".999999999";
		}
		%end = %end@" "@%word[%i]@%tac;
	}
	return AeonStr::trim(%end);
}

function Vector::round(%vec,%val)
{
	if(!%val)
		%val = 10;
	%x = floor(getWord(%vec,0)*%val)/%val;
	%y = floor(getWord(%vec,1)*%val)/%val;
	%z = floor(getWord(%vec,2)*%val)/%val;
	return %x@" "@%y@" "@%z;
}

function Vector::mult(%vec1,%vec2)
{
	%x = getWord(%vec1,0)*getWord(%vec2,0);
	%y = getWord(%vec1,1)*getWord(%vec2,1);
	%z = getWord(%vec1,2)*getWord(%vec2,2);
	return %x@" "@%y@" "@%z;
}

function Vector::div(%vec1,%vec2)
{
	%x = getWord(%vec1,0)/getWord(%vec2,0);
	%y = getWord(%vec1,1)/getWord(%vec2,1);
	%z = getWord(%vec1,2)/getWord(%vec2,2);
	return %x@" "@%y@" "@%z;
}

function Vector::compare(%vec1,%vec2,%acc)
{
	if(!%acc || %acc < 0)
		%acc = 0;
	%dist = Vector::getDistance(%vec1,%vec2);
	if(Calc::abs(%dist) <= %acc)
		return true;
	return false;
}

function RGB::conv(%input)
{
	if(AeonStr::getWordCount(%input) < 2)
		return %input/255;
	if(AeonStr::getWordCount(%input) < 3)
		return false;
	%new = Vector::div(%input,"255 255 255");
	return %new;
}

//-----------------------------------------String Functions---------------------------------------------

//-These are needed for dedicated servers: ***DO NOT MODIFY THE FOLLOWING STRING***
$AsciiStr = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
function String::ascii(%c)
{
	%n = String::indexOf($AsciiStr,%c)+32;
	return %n;
}

function AeonStr::char(%n)
{
	%c = String::getSubStr($AsciiStr,%n-32,1);
	return %c;
}

function AeonStr::ends(%str,%bit)
{
	%end = AeonStr::right(%str,AeonStr::len(%bit));
	if(String::ICompare(%end,%bit) == 0)
		return true;
	return false;
}

function String::getSubStr2(%s,%x,%y)
{
	%len = %y;
	%chunks = floor(%len / 255) + 1;
	%q = %len;
	%nx = %x;
	%final = "";
	for(%i = 1; %i <= %chunks; %i++) {
		%q = %q - 255;
		if(%q <= 0)
			%chunkLen = %q+255;
		else
			%chunkLen = 255;
		%final = %final@String::getSubStr(%s,%nx,%chunkLen);
		%nx = %nx + %chunkLen;
	}
	return %final;
}

function String::getChar(%str,%x)
{
	String::getSubStr(%str,%x,1);
}

function AeonStr::getWordCount(%str)
{
	%c = 0;
	for(%i = 0; getWord(%str,%i) != -1; %i++)
		%c++;
	return %c;
}

function String::dispRot(%clientId,%pos,%dur)
{
	%mult = 180.0;
	%x1 = getWord(GameBase::getRotation(%clientId),2);
	%x2 = getWord(Vector::getRotAim(GameBase::getPosition(%clientId),%pos),2);
	%ratio = (%x2-%x1)/$Pi;
	%max = %ratio*%mult;
	%color = "<f3>";
	%str = "^";
	if(%max > 0 && %max < 90) {
		if(%max > 45)
			%str = "<";
		for(%i = 0; %i < %max; %i++) {
			%str = %str@" ";
		}
	}
	else if(%max > 0) {
		%color = "<f1>";
		if(%max > 135)
			%str = "v";
		else
			%str = "<";
		for(%i = 0; %i < 180-%max; %i++) {
			%str = %str@" ";
		}
	}
	else if(%max < 0 && %max > -90) {
		if(%max < -45)
			%str = ">";
		for(%i = 0; %i > %max; %i--) {
			%str = " "@%str;
		}		
	}
	else {
		%color = "<f1>";
		if(%max < -135)
			%str = "v";
		else if(%max < -90)
			%str = ">";
		for(%i = 0; %i < 180+%max; %i++) {
			%str = " "@%str;
		}		
	}
	if(Calc::abs(%max) < 5)
		%color = "<f2>";
	%str = escapeString("<jc>"@%color@%str);
	bottomPrint(%clientId,%str,0.3);
	if(%dur != "repeat") {
		for(%i = 0; %i < %dur; %i+=0.2)
			schedule("String::dispRot("@%clientId@",\""@%pos@"\",\"repeat\");",%i,%clientId);
	}
}

function String::containBadChars(%message)
{
	if(String::findSubStr(%message,"~") == 0 ||
		String::findSubStr(%message,"\t") != -1 ||
		String::findSubStr(%message,"\n") != -1 ||
		String::findSubStr(%message,"\x01") != -1 ||
		String::findSubStr(%message,"\x02") != -1 ||
		String::findSubStr(%message,"\x03") != -1 ||
		String::findSubStr(%message,"\x04") != -1 ||
		String::findSubStr(%message,"\x05") != -1 ||
		String::findSubStr(%message,"\x06") != -1 ||
		String::findSubStr(%message,"\x07") != -1 ||
		String::findSubStr(%message,"\x08") != -1 ||
		String::findSubStr(%message,"\x09") != -1 ||
		String::findSubStr(%message,"\x10") != -1 ||
		String::findSubStr(%message,"\x11") != -1 ||
		String::findSubStr(%message,"\x12") != -1 ||
		String::findSubStr(%message,"\x13") != -1 ||
		String::findSubStr(%message,"\x14") != -1 ||
		String::findSubStr(%message,"\x15") != -1 ||
		String::findSubStr(%message,"\x16") != -1 ||
		String::findSubStr(%message,"\x17") != -1 ||
		String::findSubStr(%message,"\x18") != -1 ||
		String::findSubStr(%message,"\x19") != -1 )
		return true;
	return false;
}

//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\||
//                                              ||
// KingTomato's Crash Protection (Best There Is)||
//						||
// MODIFIED BY WORSTAIM				||
////////////////////////////////////////////////||
function String::containsCrash(%clientId, %message, %function)
{
	if(%clientId.isCrasher)
		return true;
	%count[Hex] = 0;
	%count[Tab] = 0;
	%count[Cr]  = 0;
	for (%a = 0; (%letter = String::GetSubStr(%message, %a, 1)) != ""; %a++) {
		if(%letter == "\t")
			%count[Tab]++;
		else if(%letter == "\n")
			%count[Cr]++;
		else if(String::findSubStr(escapeString(%letter),"\\x") == 0)
			%count[Hex]++;
	}
	if(%count[Tab] + %count[Hex] + %count[Cr] >= 80 || AeonStr::len(%message) >= 1000) {
		%clientId.gag = true;
		%clientId.isCrasher = true;
		bottomprintall("<jc><f2>"@client::getName(%clientId)@" <f1>Tried To Crash The Server And Has Been <f0>PERMANENTLY BANNED", 6);
		Log::Exploit(%clientId,"Server-Crash", %function, %message);
		ban(%clientId,"Permanent",-1);
		return true;
	}
	return false;
}

function String::time(%secs,%bool)
{
	%mins = %secs/60;
	%hours = floor(%mins/60);
	if(%bool)
		%hours -= 6;
	if(%hours < 0 && %bool)
		%hours = 24+%hours;
	if(%hours < 1 && %bool)
		%hours = 24;
	%mins = floor(%mins%60);
	if(%mins < 10)
		%mins = "0"@%mins;	
	%time = %hours@":"@%mins@"";
	return %time;
}

function String::cashComma(%str)
{
	%count = 0;
	%str = floor(%str);
	for(%i = AeonStr::len(%str)-1; %i > 0; %i--) {
		if(%count++ % 3 == 0 && %count != 0)
			%str = String::insert(%str,",",%i);
	}
	return %str;
}

//-Failed Attempt, only way to get it to work would be to chop the number into seperate strings, and recombine it for display
function String::sciNotFix(%str)
{
	if(String::indexOf(%str,"e") != -1) {
		%x = String::indexOf(%str,"e");
		%dec = String::getSubStr(%str,0,%x);
		%pow = String::getSubStr(%str,%x+1,3);
		%len = AeonStr::len(String::getSubStr(%dec,2,10));
		%dec = AeonStr::replace(%dec,".","");
		%zero = "";
		for(%i = 0; %i < %pow-%len; %i++)
			%zero = %zero@"0";
		%str = %dec@%zero;
	}
	return %str;
}

function String::indexOf(%str,%sel,%s)
{
	%z = -1;
	%p = 0;
	if(!%s)
		%s = 0;
	for(%i = %s; %i < AeonStr::len(%str); %i++) {
		%chunk = String::getSubStr(%str,%i,AeonStr::len(%sel));
		if(%chunk != %sel || String::ICompare(%sel,%chunk) != 0)
			%p++;
		else {
			%z = %p+%s;
			break;
		}
	}
	return %z;
}

function String::insert(%str,%a,%x)
{
	%len = AeonStr::len(%str);
	%part1 = String::getSubStr(%str,0,%x);
	%part2 = String::getSubStr(%str,%x,%len-%x);
	%str = %part1@%a@%part2;
	return %str;
}

function String::alphaInsert(%str,%in)
{
	%p = "";
	for(%i = 0; getWord(%str,%i) != -1; %i++) {
		%asc1 = String::ascii(getWord(%str,%i));
		%asc2 = String::ascii(AeonStr::trim(%in));
		if(%asc2 > %asc1)
			%p = %i;
	}
	return String::insert(%str,%in,%p);
}

function AeonStr::len(%str)
{
	for(%i = 0; String::getSubStr(%str,%i,1) != ""; %i++) {}
	return %i;
}

function String::len2(%str)
{
	%inc = 10;
	%len = 0;
	for(%i = 0; String::getSubStr(%str,%i,1) != ""; %i += %inc)
		%len += %inc;
	%len -= %inc;
	%nst = String::getSubStr(%str,%len,900);
	for(%k = 0; String::getSubStr(%nst,%k,1) != ""; %k++)
		%len++;
	if(%len == -%inc)
		%len = 0;
	return %len;
}

function AeonStr::replace(%str,%a,%b)
{
	%pos = String::findSubStr(%str,%a);
	for(%pos; %pos != -1; %i++) {
		%strLen = AeonStr::len(%str);
		%oldLen = AeonStr::len(%a);
		%part1 = String::getSubStr(%str,0,%pos);
		%part2 = String::getSubStr(%str,%pos+%oldLen,%strLen-%pos-%oldLen);
		%str = %part1@%b@%part2;
		%pos = String::findSubStr(%str,%a);
	}
	return %str;
}

function AeonStr::right(%str,%x)
{
	%len = AeonStr::len(%str);
	%s = String::getSubStr(%str,%len-%x,%x);
	return %s;
}

function AeonStr::trim(%str)
{
	%len = AeonStr::len(%str);
	for(%i = 0; %i < %len; %i++) {
		if(String::getSubStr(%str,%i,1) == " ")
			%x++;
		else
			break;
	}
	%z = String::getSubStr(%str,%x,%len-%x);
	while(String::getSubStr(%z,AeonStr::len(%z)-1,1) == " ")
		%z = String::getSubStr(%z,0,AeonStr::len(%z)-1);
	return %z;
}

function String::plural(%word,%num)
{
	if(%num != 1)
		return %word@"s";
	return %word;
}

function String::wordRat(%msg)
{
	%len = AeonStr::Len(%msg);
	%avg = String::avgWordLen(%msg);
	%rat = 100/(%len / %avg);
	return %rat;
}

function String::avgWordLen(%msg)
{
	%length = AeonStr::Len(%msg);
	%wrdCnt = AeonStr::getWordCount(%msg);
	//-   OK, since each word is defined by having a space separating it from other characters
	//- then we can assume that there is at least one space for every word, minus the last one
	//- so to find the length of all the words without the spaces we do this:
	%wrdLen = (%length-(%wrdCnt-1));
	%avgLen = %wrdLen / %wrdCnt;
	return %avgLen;
}

//-----------------------------------------Other Stuff---------------------------------------------

function randomItems(%num,%v1,%v2,%v3,%v4,%v5,%v6,%v7,%v8,%v9,%v10,%v11,%v12,%v13,%v14,%v15,%v16,%v17,%v18,%v19,%v20)
{
	%num = floor(getRandom()*(%num-0.01))+1;
	return %v[%num];
}

function Test::fire(%pos)
{
	Projectile::spawnProjectile("rockProj2","0 0 1 0 0 0 0 0 1 "@%pos,2048,"0 0 0");
}

function GetInfo()
{
	%found = 0;
	for(%i = 0; %i < 9000; %i++) {
		%type = getObjectType(%i);
		if(%type != False) {
			%found++;
			$DataInfo[%found] = %i;
			$DataInfoMax = %found;
		}
	}
	for(%i = 1; %i <= $DataInfoMax; %i++) {
		%obj = $DataInfo[%i];
		%type = getObjectType(%obj);
		echo(%i@": "@%obj@", "@%type);
	}
}

$SuperLasTimeDef = 1.0;

function GiveSupLas(%player)
{
	if(%player < 8000)
		%player = Client::getControlObject(%player);
	//%client = Player::getClient(%player);
	Player::mountItem(%player,SuperLasGun,$WeaponSlot);
}

function SuperLasGunImage::onFire(%player,%slot)
{
	if(%player.firing != 1) {
		%client = Player::getClient(%player);

		%player.firing = 1;
		SuperLaser(%player);
		if(!$SuperLasTime[%client])
			$SuperLasTime[%client] = $SuperLasTimeDef;
		schedule(%player@".firing = 0;",$SuperLasTime[%client],%player);
	}
}

$SuperLaserNum = 50;
$SuperLasSizeDef = 1;

function SuperLaser(%player)
{
	if(%player < 8000)
		%player = Client::getControlObject(%player);
	playSound(SoundBeam,GameBase::getPosition(%player));
	for(%i = 0; %i <= (2*$Pi)-0.001; %i += ((2*$Pi)/$SuperLaserNum)) {
		%pRot = Player::getLookRot(%player);
		%rot = Vector::add(%pRot,"0 "@%i@" 0");
		%client = Player::getClient(%player);
		if(!$SuperLaserSize[%client])
			$SuperLaserSize[%client] = $SuperLasSizeDef;
		%LasPos = Vector::add(getBoxCenter(%player),Vector::getFromRot(%rot,0.5,$SuperLaserSize[%client]));
		%vec = Vector::getFromRot(%pRot,0.05);
		%trans = %rot@" "@%vec@" "@%rot@" "@%LasPos;
		%Bullet = Projectile::spawnProjectile("temp",%trans,%player,"0 0 0");
		SuperLaserEmit(%Bullet);
	}
}

function SuperLaser::size(%player,%size)
{
	if(%player < 8000)
		%player = Client::getControlObject(%player);
	%client = Player::getClient(%player);
	$SuperLaserSize[%client] = %size;
}

function SuperLaserEmit(%this)
{	
	%vel = Item::getVelocity(%this);
	%rot = Vector::getRotation(%vel);
	%rot = Vector::add(%rot,$Pi/2@" 0 0");
	%pos = Vector::add(GameBase::getPosition(%this),Vector::getFromRot(%rot,0.75));
	%vec = Vector::getFromRot(%rot,1);
	%trans = %rot@" "@%vec@" "@%rot@" "@%pos;
	%las = projectile::spawnProjectile("SuperLaser",%trans,2048,"0 0 0");
}

function Item::GroundStick(%this,%float)
{
	if(GameBase::getLOSInfo(%this,2000,$Pi/-2@" 0 0")) {
		%groundRot = $los::normal;
		%groundPos = $los::position;
		%rot0 = GameBase::getRotation(%this);
		%pos0 = GameBase::getPosition(%this);
		%ZDist = getWord(%pos0,2)-getWord(%groundPos,2);
		%UpVec = Vector::getFromRot(Vector::add(%rot0,"-1.570796327 0 0"),2);
		%NewPos = getWord(%pos0,0)@" "@getWord(%pos0,1)@" "@getWord(%groundPos,2)+%float;
		GameBase::setPosition(%this,%newPos);
	}
}

$GVUpdateRate = 0.05;
$GVposRate = 0.05;
$GVrotRate = 0.08;

function GroundVehicle(%this,%height)
{
	if(%this) {
		if(!%height)
			%height = 2.1;
		GV::loop(%this,%height);
	}
}

function GV::loop(%this,%height)
{
	schedule("GV::pos("@%this@","@%height@");",$GVposRate,%this);
	schedule("GV::rot("@%this@");",$GVrotRate,%this);
	schedule("GV::loop("@%this@","@%height@");",$GVUpdateRate,%this);
}

function GV::pos(%this,%height)
{
	if(GameBase::getLOSInfo(%this,2000,$Pi/-2@" 0 0")) {
		%pos = GameBase::getPosition(%this);
		%NewPos = getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord($los::position,2)+%height;
		GameBase::setPosition(%this,%newPos);
	}
}

function GV::rot(%this)
{
	if(GameBase::getLOSInfo(%this,2000,$Pi/-2@" 0 0")) {
		%rot = Vector::getRotation($los::normal);
		GameBase::setPosition(%this,%rot);
	}
}

function Weapon::onFire2(%player,%special,%Eat,%speed)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%player);
	%armor = Player::getArmor(%player);
	%weap = Player::getMountedItem(%player,$WeaponSlot);
	%ammo = $WeaponAmmo[%weap];
	if(%ammo != "") {
		if(Player::getItemCount(%player,%ammo) < 1)
			return;
	}
	GameBase::getLOSInfo(%player,3000);
	%rot = GameBase::getRotation(%player);
	%targetPos = $los::position;
	%trans = GameBase::getMuzzleTransform(%player);
	%vec0 = getWord(%trans,0);
	%vec1 = getWord(%trans,1);
	%vec2 = getWord(%trans,2);
	%vec3 = getWord(%trans,6);
	%vec4 = getWord(%trans,7);
	%vec5 = getWord(%trans,8);
	%vec6 = getWord(%trans,9);
	%vec7 = getWord(%trans,10);
	%vec8 = getWord(%trans,11);
	%vecX = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
	%rot1 = %vec0@" "@%vec1@" "@%vec2;
	%rot2 = %vec3@" "@%vec4@" "@%vec5;
	%pos1 = %vec6@" "@%vec7@" "@%vec8;
	%rot0 = Vector::getRotAim(%Pos1,%targetPos);
	if(%speed == "")
		%speed = 1;
	%vec = Vector::getFromRot(%rot0,%speed);
	if(%targetPos)
		%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot0@" "@%pos1;
	%type = $WeapProjectile[%weap];
	if(%special != "" && %special != "0")
		%type = %special;
	%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);
	if(getObjectType(%proj) == LaserProjectile && $los::object) {
		%dmgType = $LaserDamageType;
		%value = %type.damageConversion;
		if(GameBase::getEnergy(%player) > %weap.imageType.minEnergy)
			%value *= %weap.imageType.maxEnergy;
		%pos = GameBase::getPosition($los::object);
		%vecI = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
		%mom = "0 0 0";
		GameBase::applyDamage($los::object,%dmgType,%value,%pos,%vecI,%mom,%client);
	}
	if(%ammo != "" && %Eat != False)
		Player::DecItemCount(%player,%ammo);
	else if(%weap.imageType.maxEnergy != "")
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-%weap.imageType.maxEnergy);
	if($FifthElementGuns != 1)
		$los::position = "";
	$los::object = "";
	return %proj;
}
