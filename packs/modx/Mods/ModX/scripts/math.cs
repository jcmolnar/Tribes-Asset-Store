// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
// Math and Vector Functions

$Math::PI = "3.14159265358979323";

function Math::rad2deg(%radians)
{
    return %radians * (180 / $Math::PI);
}

function Math::deg2rad(%degrees)
{
    return %degrees * ($Math::PI / 180);
}

function Math::roundDown(%delta)
{
    return floor(%delta - 0.01);
}

function Math::roundUp(%delta)
{
    return ceil(%delta + 0.01);
}

function Math::randomInt(%max)
{
    return floor(getRandom() * (%max - 0.01));
}

function Vector::multiply(%vec1, %vec2)
{
    %vec1X = getWord(%vec1, 0);
    %vec1Y = getWord(%vec1, 1);
    %vec1Z = getWord(%vec1, 2);

    %vec2X = getWord(%vec2, 0);
    %vec2Y = getWord(%vec2, 1);
    %vec2Z = getWord(%vec2, 2);

    %vec3X = %vec1X * %vec2X;
    %vec3Y = %vec1Y * %vec2Y;
    %vec3Z = %vec1Z * %vec2Z;

    return %vec3X @ " " @ %vec3Y @ " " @ %vec3Z;
}

function Vector::divide(%vec1, %vec2)
{
    %vec1X = getWord(%vec1, 0);
    %vec1Y = getWord(%vec1, 1);
    %vec1Z = getWord(%vec1, 2);

    %vec2X = getWord(%vec2, 0);
    %vec2Y = getWord(%vec2, 1);
    %vec2Z = getWord(%vec2, 2);

    %vec3X = %vec1X / %vec2X;
    %vec3Y = %vec1Y / %vec2Y;
    %vec3Z = %vec1Z / %vec2Z;

    return %vec3X @ " " @ %vec3Y @ " " @ %vec3Z;
}

function GameBase::getMuzzlePosition(%player)
{
        %trans = GameBase::getMuzzleTransform(%player);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        return %vec6@" "@%vec7@" "@%vec8;
}

function GameBase::getTransPosition(%trans)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        return %vec6@" "@%vec7@" "@%vec8;
}

function GameBase::getTransRotation(%trans)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        return getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
}

function GameBase::AddPosToTrans(%trans, %pos)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        %pos0 = getWord(%pos, 0);
        %pos1 = getWord(%pos, 1);
        %pos2 = getWord(%pos, 2);
        %newtrans = %vec0@" "@%vec1@" "@%vec2@" "@ getWord(%trans,3) @" "@ getWord(%trans,4) @" "@ getWord(%trans,5) @" "@%vec3@" "@%vec4@" "@%vec5@" "@%vec6+%pos0@" "@%vec7+%pos1@" "@%vec8+%pos2;
        return %newtrans;
}

function GameBase::AddRotToTrans(%trans, %rot)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        %rot0 = getWord(%rot, 0);
        %rot1 = getWord(%rot, 1);
        %rot2 = getWord(%rot, 2);
        %newtrans = %vec0@" "@%vec1@" "@%vec2@" "@ getWord(%trans,3)+%rot0 @" "@ getWord(%trans,4)+%rot1 @" "@ getWord(%trans,5)+%rot2 @" "@%vec3@" "@%vec4@" "@%vec5@" "@%vec6@" "@%vec7@" "@%vec8;
        return %newtrans;
}

function GameBase::ReplacePosInTrans(%trans, %pos)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        %pos0 = getWord(%pos, 0);
        %pos1 = getWord(%pos, 1);
        %pos2 = getWord(%pos, 2);
        %newtrans = %vec0@" "@%vec1@" "@%vec2@" "@ getWord(%trans,3) @" "@ getWord(%trans,4) @" "@ getWord(%trans,5) @" "@%vec3@" "@%vec4@" "@%vec5@" "@%pos0@" "@%pos1@" "@%pos2;
        return %newtrans;
}

function GameBase::ReplaceRotInTrans(%trans, %rot)
{
        %vec0 = getWord(%trans,0);
        %vec1 = getWord(%trans,1);
        %vec2 = getWord(%trans,2);
        %vec3 = getWord(%trans,6);
        %vec4 = getWord(%trans,7);
        %vec5 = getWord(%trans,8);
        %vec6 = getWord(%trans,9);
        %vec7 = getWord(%trans,10);
        %vec8 = getWord(%trans,11);
        %rot0 = getWord(%rot, 0);
        %rot1 = getWord(%rot, 1);
        %rot2 = getWord(%rot, 2);
        %newtrans = %vec0@" "@%vec1@" "@%vec2@" "@ %rot0 @" "@ %rot1 @" "@ %rot2 @" "@%vec3@" "@%vec4@" "@%vec5@" "@%vec6@" "@%vec7@" "@%vec8;
        return %newtrans;
}

function GameBase::getRotFromPoints(%pos, %pos2)
{
    return Vector::Normalize(Vector::Sub(%pos, %pos2));
}

function Vector::getRotAim(%pos1,%pos2)
{
        %vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
        %rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
        return %rot;
}

function getPerfectTrans(%player)
{
        GameBase::getLOSInfo(%player,3000);
        %rot = GameBase::getRotation(%player);
        %targetPos = $los::position;
        $los::position = "";
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
        %rot1 = %vec3@" "@%vec4@" "@%vec5;
        %pos1 = %vec6@" "@%vec7@" "@%vec8;
        %rot0 = Vector::getRotAim(%Pos1,%targetPos);
        %vec = Vector::getFromRot(%rot0,1);
        if(%targetPos)
                %trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot1@" "@%pos1;

        return %trans;
}

// Plasmatic's rotateVector
function rotateVector(%vec,%rot)
{
	%pi = $Math::PI;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;

	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);

	%ray = %vec1;

	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
}

function Sin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function Cos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

function Tan(%theta)
{
    return Sin(%theta) / Cos(%theta);
}

function abs(%delta)
{
    return sqrt(pow(%delta,2));
}
