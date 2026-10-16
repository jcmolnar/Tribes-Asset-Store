$Aeon::LightsDef["Light_Red",red] = RGB::conv(255);
$Aeon::LightsDef["Light_Red",grn] = RGB::conv(0);
$Aeon::LightsDef["Light_Red",blu] = RGB::conv(0);
$Aeon::LightsDef["Light_Red",siz] = 5.0;
$Aeon::LightsDef["Light_Red",dst] = 1.0;
$Aeon::LightsDef["Light_Green",red] = RGB::conv(0);
$Aeon::LightsDef["Light_Green",grn] = RGB::conv(255);
$Aeon::LightsDef["Light_Green",blu] = RGB::conv(0);
$Aeon::LightsDef["Light_Green",siz] = 5.0;
$Aeon::LightsDef["Light_Green",dst] = 1.0;
$Aeon::LightsDef["Light_Blue",red] = RGB::conv(0);
$Aeon::LightsDef["Light_Blue",grn] = RGB::conv(0);
$Aeon::LightsDef["Light_Blue",blu] = RGB::conv(255);
$Aeon::LightsDef["Light_Blue",siz] = 5.0;
$Aeon::LightsDef["Light_Blue",dst] = 1.0;
$Aeon::LightsDef["Light_White",red] = RGB::conv(255);
$Aeon::LightsDef["Light_White",grn] = RGB::conv(255);
$Aeon::LightsDef["Light_White",blu] = RGB::conv(255);
$Aeon::LightsDef["Light_White",siz] = 5.0;
$Aeon::LightsDef["Light_White",dst] = 1.0;
$Aeon::LightsDef["Light_Black",red] = RGB::conv(0);
$Aeon::LightsDef["Light_Black",blu] = RGB::conv(0);
$Aeon::LightsDef["Light_Black",grn] = RGB::conv(0);
$Aeon::LightsDef["Light_Black",siz] = 5.0;
$Aeon::LightsDef["Light_Black",dst] = 1.0;

function Lights::onAdd(%this)
{
	Shakeable::addToNetwork(%this);
	schedule("Lights::turnOn("@%this@");",1.0,%this);
}

function Lights::turnOn(%this)
{
	%data = GameBase::getDataName(%this);
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%red = $Aeon::LightsDef[%data,red];
	%grn = $Aeon::LightsDef[%data,grn];
	%blu = $Aeon::LightsDef[%data,blu];
	%size = $Aeon::LightsDef[%data,siz];
	%dist = $Aeon::LightsDef[%data,dst];
	if(%this.lightRad)
		%size = %this.lightRad;
	if(%this.lightEmit)
		%dist = %this.lightEmit;
	%add = $Pi/2@" 0 0";
	if(Vector::dot(%rot,"0 -1 0") > 0.5)
		%add = $Pi/-2@" 0 0";
	%rot2 = Vector::Add(%rot,%add);
	%vec = Vector::getFromRot(%rot2,%dist);
	%pos = Vector::add(%pos,%vec);
	%light = newObject("pointlight","SimLight",Point,%size,%red,%grn,%blu,getword(%pos,0),getword(%pos,1),getword(%pos,2));
	addToSet("MissionCleanup\\Lights",%light);
	GameBase::setRotation(%light,%rot2);
	%this.bindLight = %light;
	%this.lightRad = %size;
	%this.lightEmit = %dist;
}

function Lights::turnOff(%this)
{
	if(!%this.bindLight)
		return;
	deleteObject(%this.bindLight);
	%this.bindLight = "";
}

function Lights::onCollision(%this,%object)
{
	
}

function Lights::getExportString(%light)
{
	
}

function Lights::onDamage(%this) {}

function Aeon::inLight(%this)
{
	if(!%this)
		return;
	%pos = GameBase::getPosition(%this);
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,10,10,20,-10);
	if(%num) {
		%count = Group::objectCount(%set);
		for(%i = 0; %i < %count; %i++) {
			%object = Group::getObject(%set,%i);
			if(GameBase::getDataName(%object).className == "Lights") {
				%oPos = GameBase::getPosition(%object);
				%oRot = GameBase::getRotation(%object);
				%rad = %object.lightRad;
				%emit = %object.lightEmit;
				%add = $Pi/2@" 0 0";
				if(Vector::dot(%oRot,"0 -1 0") > 0.5)
					%add = $Pi/-2@" 0 0";
				%vec = Vector::getFromRot(Vector::Add(%oRot,%add),%emit+1);
				%ePos = Vector::add(%oPos,%vec);
				%dist = Vector::getDistance(%pos,%ePos);
				if(%dist < %rad) {
					deleteObject(%set);
					return true;
				}
			}
		}
		deleteObject(%set);
		return false;
	}
	deleteObject(%set);
	return false;
}
