$Aeon::weldEnable = true;
$Aeon::weldUpdate = 0.05;

function Weld::toggle()
{
	if($Aeon::weldActive != true) {
		$Aeon::weldEnable = true;
		Weld::loop();
	}
	else
		$Aeon::weldEnable = false;
}

function Weld::loop()
{
	%update = $Aeon::weldUpdate/10;
	for(%i = 0; $Aeon::Weld[%i] != ""; %i++)
		%link[%i] = $Aeon::Weld[%i];
	for(%i = 0; %link[%i] != ""; %i++) {
		%link = %link[%i];
		%child = getWord(%link,0);
		%parent = getWord(%link,1);
		%parPos = GameBase::getPosition(%parent);
		if(%parent && Vector::compare(%parPos,"0 0 0",0.1) != true) {
			%offDst = getWord(%link,2);
			%offRot = getWord(%link,3)@" "@getWord(%link,4)@" "@getWord(%link,5);
			%parRot = GameBase::getRotation(%parent);
			%bigDif = Vector::sub(%parRot,%child.lastParRot);
			%child.lastParRot = %parRot;
			%tmpRot = Vector::add(%child.lastAimRot,%bigDif);
			%offDif = Vector::getFromRot(%tmpRot,%offDst);
			%newPos = Vector::add(%parPos,%offDif);
			%newRot = Weld::adaptAxis(%offRot,%parRot);
			GameBase::setPosition(%child,%newPos);
			GameBase::setRotation(%child,%newRot);
			%newAim = Vector::getRotAim(%parPos,%newPos);
			if(Vector::compare(%newAim,%child.lastAimRot,0.09))
				%newAim = %child.lastAimRot;
			%child.lastAimRot = %newAim;
		}
		else
			Weld::removeFromNetwork(%child);
		%update = $Aeon::weldUpdate;
	}
	if($Aeon::weldEnable) {
		$Aeon::weldActive = true;
		schedule("Weld::loop();",%update);
	}
	else
		$Aeon::weldActive = false;
}

//------------------------------------------------------------
//-Rotational Axis Manipulation Equivilants (P = $Pi)
// 0   0   0,	P   P   P,	
// P   0   0,	0   P   P,	
// 0   P   0,	P   0   P,	
// 0   0   P,	P   P   0,	
// 
// 
// 
//------------------------------------------------------------
function Weld::adaptAxis(%rot,%conform)
{
	%X = getWord(%rot,0);
	%Y = getWord(%rot,1);
	%Z = getWord(%rot,2);
	%newRot = Vector::sub(%conform,%rot);
	%part = "";
	if(Calc::abs(%X) > $Pi/4)
		%part = %part@"X";
	if(Calc::abs(%Y) > $Pi/4)
		%part = %part@"Y";
	if(Calc::abs(%Z) > $Pi/4)
		%part = %part@"Z";
	%conZ = Calc::abs(getWord(%conform,2));
	%X = getWord(%newRot,0);
	%Y = getWord(%newRot,1);
	%Z = getWord(%newRot,2);
	%X2 = %X;
	%Y2 = %Y;
	%Z2 = %Z;
	if(%part == "XYZ") {
		if(%conZ < 3*$Pi/4 && %conZ > $Pi/4) {
		}
		%X2 = %X;
		%Y2 = %Y;
		%Z2 = %Z;
	}
	else if(%part == "XZ") {
		if(%conZ < 3*$Pi/4 && %conZ > $Pi/4) {
			%X2 = %X;
			%Y2 = %Y;
			%Z2 = %Z;				
		}
		else {
			%X2 = %X;
			%Y2 = %Y;
			%Z2 = %Z;
		}
	}
	else if(%part == "X") {
		//if(%conZ >= 3*$Pi/4 || %conZ <= $Pi/4) {
		//	%X2 = %X;		//	%Y2 = %Y;
		//	%Z2 = %X+$Pi/-2;
		//}
	}
	else if(%part == "Z") {
		if(%conZ < 3*$Pi/4 && %conZ > $Pi/4) {
			%X2 = %Y;
			%Y2 = -%X;
			%Z2 = %Z;				
		}
		else {
			%X2 = %Y;
			%Y2 = %X;
			%Z2 = %Z;
		}
	}
	if(getSimTime() > $lastCheckTime+2.0) {
		//echo("Part: "@%part@", "@%conZ);
		$lastCheckTime = getSimTime();
	}
	%rot = %X2@" "@%Y2@" "@%Z2;
	return %rot;
}

function Weld::getString(%child,%parent)
{
	%pos1 = GameBase::getPosition(%child);
	%pos2 = GameBase::getPosition(%parent);
	%rot1 = GameBase::getRotation(%child);
	%rot2 = GameBase::getRotation(%parent);
	%offDif = Vector::getRotAim(%pos2,%pos1);
	%offDst = Vector::getDistance(%pos2,%pos1);
	%offRot = Vector::sub(%rot2,%rot1);
	%weld = %child@" "@%parent@" "@%offDst@" "@%offRot;
	%child.lastParRot = %rot2;
	%child.lastAimRot = %offDif;
	return %weld;
}

function Weld::getAddr(%this)
{
	for(%i = 0; $Aeon::Weld[%i] != ""; %i++) {
		if(Weld::compare($Aeon::Weld[%i],%this))
			return %i;
	}
	return %i;
}

function Weld::addToNetwork(%this,%object)
{
	if(!%this || !%object)
		return;
	%weld = Weld::getString(%this,%object);
	%num = Weld::getAddr(%weld);
	$Aeon::Weld[%num] = %weld;
}

function Weld::removeFromNetwork(%this)
{
	if(!%this)
		return;
	%found = false;
	for(%i = 0; $Aeon::Weld[%i] != ""; %i++) {
		if(Weld::compare($Aeon::Weld[%i],%this))
			%found = true;
		if(%found == true)
			$Aeon::Weld[%i] = $Aeon::Weld[%i+1];
	}
	$Aeon::Seismic[%i] = "";
}

function Weld::compare(%this,%that)
{
	%child1 = getWord(%this,0);
	%child2 = getWord(%that,0);
	if(%child1 == %child2)
		return true;
	return false;
}

function Weld::strNetwork()
{
	%str = "";
	for(%i = 0; $Aeon::Weld[%i] != ""; %i++)
		%str = %str@$Aeon::Weld[%i]@", ";
	return %str;
}