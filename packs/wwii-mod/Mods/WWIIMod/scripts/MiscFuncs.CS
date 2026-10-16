function getmaterial()
{
for(%x = 8000; %x < 10000; %x++)
	if(isobject(%x) && getobjecttype(%x) == "SimVolume")
		{
		if(object::getname(%x) == "lushdml" || object::getname(%x) == "lushDML" || object::getname(%x) == "LushDML") return "lush";
	else	if(object::getname(%x) == "desertdml" || object::getname(%x) == "desertDML" || object::getname(%x) == "DesertDML") return "desert";
 	else	if(object::getname(%x) == "icedml" || object::getname(%x) == "iceDML" || object::getname(%x) == "IceDML") return "ice";
	else	if(object::getname(%x) == "aliendml" || object::getname(%x) == "alienDML" || object::getname(%x) == "AlienDML") return "alien";
		
		}
}

function vector::Multiply(%vec1, %vec2)
{
%vec1a = getword(%vec1, 0);
%vec1b = getword(%vec1, 1);
%vec1c = getword(%vec1, 2);

%vec2a = getword(%vec2, 0);
%vec2b = getword(%vec2, 1);
%vec2c = getword(%vec2, 2);

return %vec1a * %vec2a @ " " @ %vec1b * %vec2b @ " " @ %vec1c * %vec2c;
}

function vector::getrandom()
{
%a = getrandom()*400 - 200;
%b = getrandom()*400 - 200;
%c = getrandom()*400 - 200;
%vec = vector::normalize(%a @ " " @ %b @ " " @ %c);
return %vec;
}

function sin(%angle, %m) 
{ 
if(%m == d && (%angle/180-floor(%angle/180))*(%angle/180-floor(%angle/180)) < 0.000001 ) return 0; 
if(%m == d) %angle /= 180 / 3.14159;
else if(%m == g) %angle /= 200 / 3.14159;
if(%angle*%angle < 0.01) return 0;
%ans = -getWord(Vector::getFromRot("0 0 " @ %angle), 0) + 0.00001; 
%return =  string::getsubstr(%ans, 0, 6);
return %return;
}

function cos(%angle, %m)
{
if(%m == d) %a = 90;
else if(%m == g) %a = 100;
else %a = 1.57079;
return sin(%a-%angle, %m);
}

function tan(%angle, %m)
{
return string::getsubstr(sin(%angle, %m)/cos(%angle, %m) + 0.0001, 0, 6);

}

function sins(%sin, %m)
{
%ans = getword(vector::add(vector::getrotation(-%sin @ " " @ sqrt(1-%sin*%sin) @ " 0"), "1.57079 0 0"), 2)+0.00001;
if(%m == g) %ans *= 200/3.14159;
else if(%m == d) %ans *= 180/3.14159;
return %ans;
}

function coss(%cos, %m)
{
if(%m == d) %a = 180/3.14159;
else if(%m == g) %a = 200/3.14159;
else %a = 1;
return 1.57079*%a - sins(%cos, %m) + 0.001;
}

function tans(%val, %m)
{
%val = %val*1;
%a = %val*%val;
%sinx = %a/(1+%a);
%sinx = sqrt(%sinx);
%ans = sins(%sinx);
if(%val == 0) return 0;
if(%m == g) %e = 200/3.14159;
else if(%m == d) %e = 180/3.14159;
else %e = 1;
return %ans*%e;
}

function getanglebetweenvectors(%vec1,%vec2)
{
%dist = vector::getdistance(%vec1,%vec2);
%alpha = coss((2-%dist*%dist)/2,d);
return %alpha;
}

function getnumwords(%str) { for(%x = 0; 1; %x++) if(getword(%str, %x) == -1 && getword(%str, %x+1) == -1) return %x; }

function RocketDumb::onAdd(%this)
{
$WWII::NumOfProjectiles++;
schedule("WWII::PRJ(" @ %this @ ");", 0.1);
}
function RocketDumb::onRemove(%this) { $WWII::NumOfProjectiles--; }

function Bullet::onAdd(%this)
{
$WWII::NumOfProjectiles++;
schedule("WWII::PRJ(" @ %this @ ");", 0.1);
}
function Bullet::onRemove(%this) { $WWII::NumOfProjectiles--; }

function Bolt::onAdd(%this)
{
$WWII::NumOfProjectiles++;
schedule("WWII::PRJ(" @ %this @ ");", 0.1);
}

function SeekingMissile::onAdd(%this)
{
$WWII::NumOfProjectiles++;
schedule("Projectile::Obtainshooterid(" @ %this @ ");", 0.1);
schedule("WWII::PRJ(" @ %this @ ");", 0.1);
}
function SeekingMissile::onRemove(%this) { $WWII::NumOfProjectiles--; }

function Projectile::Obtainshooterid(%this)
{
if(%this.explosive == "") return;
%Set = newObject("set",SimSet);
%Pos = gamebase::getposition(%this);
%num = containerBoxFillSet(%Set, $vehicleObjectType | $Simplayerobjecttype, %Pos, 10,10,10,0); 
if(%num == 1) %this.shooter = group::getobject(%set, 0);
}

function Grenade::onAdd(%this)
{
$WWII::NumOfProjectiles++;
schedule("Projectile::Obtainshooterid(" @ %this @ ");", 0.1);
schedule("WWII::PRJ(" @ %this @ ");", 0.1);
}
function Grenade::onRemove(%this) { $WWII::NumOfProjectiles--; }
$WWII::NumOfProjectiles = 0;

function WWII::PRJ(%this, %lastpos)
{
if($WWII::NumOfProjectiles >= 150) return;

%curpos = getboxcenter(%this);
if(%curpos == %lastpos) { Projectile::onHit(%this); return; }
schedule("WWII::PRJ(" @ %this @ ",\"" @ %curpos @ "\");", 0.15, %this);
}

//function Projectile::onHit(%x) { }

function findobject(%str)
{
for(%x = 8000; %x < 10000; %x++) 
	if(isobject(%x)) 
		if(string::findsubstr(gamebase::getdataname(%x), %str) != -1) %answer = %answer @ %x @ " ";
return %answer;
}
function randomitems(%list, %max)
{
%ran = floor(getrandom() * %max);
return getWord(%list, %ran);
}

function Muzzle::getAim(%this)
{
%trans = gamebase::getmuzzletransform(%this);
%aimvec = getword(%trans, 3) @ " " @ getword(%trans, 4) @ " " @ getword(%trans, 5);
return %aimvec;
}

function String::GetLength(%string) { return String::GetLenth(%string); }
function Strlen(%string) { return String::GetLenth(%string); }

function String::GetLenth(%string)
{
for(%x = 0; true; %x++)
	{
	if(string::getsubstr(%string, %x, (%x + 40)) == "")
		{
		%lenth = %x;
		break;
		}
	}
return %lenth;
}

function ceiling(%num) 
{
if(%num == floor(%num)) return %num;
else return (1+floor(%num));
}

function string::findchar(%str, %c)
{
for(%x = 0; %x < strlen(%str); %x++) if(string::getsubstr(%str, %x, 1) == %c) return %x;
return -1;
}

function countspaces(%str)
{
for(%x = 0; %x < strlen(%str); %x++)
	{
	%char = string::getsubstr(%str, %x, 1); //4 groups
	if(%char == " ") %spaces++;
	else if(string::findchar("i1l!|`.,", %char) != -1) %spaces += 0.6;
	else if(string::findchar("fjt)(*^-][}{)(;I", %char) != -1) %spaces += 1;
	else if(string::findchar("@ABCDEFGHJKLMNOPQRSTUVWXYZ", %char) != -1) %spaces += 2.7;
	else %spaces += 1;
	}
return %spaces;
}

function String::HasInvalidChars(%string)
{
if(string::findsubstr(%string, "\t")) return true;  //tab check
if(string::findsubstr(%string, "\n")) return true;  //newline check
}


function getnumbots()
{
%clients = 0;
for(%x = 2049; %x < 2222; %x++)
	if(client::getname(%x) != "") %clients++;
%bots = %clients - getnumclients();
return %bots;
}