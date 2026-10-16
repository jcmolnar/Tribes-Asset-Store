//============================================ 
//=    MuzzleTransform with Aim correction   =
//= Copyright (c) 2000 Harold "LabRat" Brown =
//=         DO NOT ALTER THIS CODE.          =
//============================================

//=====================================
//=   Distance / Correction Tables    =
//=      DO NOT CHANGE VALUES         =
//=====================================
$LRGMT::distance[1]=1.5625;
$LRGMT::distance[2]=3.125;
$LRGMT::distance[3]=6.25;
$LRGMT::distance[4]=12.5;
$LRGMT::distance[5]=25;
$LRGMT::distance[6]=50;
$LRGMT::distance[7]=100;
$LRGMT::distance[8]=200;
$LRGMT::distance[9]=400;
$LRGMT::distance[10]=800;

$LRGMT::correction[1]=0.288;
$LRGMT::correction[2]=0.144;
$LRGMT::correction[3]=0.072;
$LRGMT::correction[4]=0.036;
$LRGMT::correction[5]=0.018;
$LRGMT::correction[6]=0.009;
$LRGMT::correction[7]=0.0045;
$LRGMT::correction[8]=0.00225;
$LRGMT::correction[9]=0.001125;
$LRGMT::correction[10]=0.0005625;

//==========================================
//=  Replacement MuzzleTransform function  =
//=  Usage:                                =
//=        Use as a replacement for        =
//=        GameBase::GetMuzzleTransform(); =
//==========================================

function LabRat::getMuzzleTransform(%player) {
	%trans = GameBase::getMuzzleTransform(%player);
	
	if(GameBase::getLOSInfo(%player,800)){
  	 %lospos = GameBase::getPosition($los::object);
  	 %PlayerPos = GameBase::getPosition(%player);
	 %distance = Vector::getDistance(%PlayerPos, $los::position);
  	 for(%i=1;%i<=9;%i=%i+1){
			if((%distance >= $LRGMT::distance[%i]) && (%distance < $LRGMT::distance[%i+1])){
				%correction =$LRGMT::correction[%i] - ((((%distance-$LRGMT::distance[%i])/$LRGMT::distance[%i])*100)*($LRGMT::correction[%i+1]/100));
			}
		}
  	 } 
  	 %check = getword(gamebase::getrotation(%player),2);
  	 if(((%check <= 3.14) && (%check > 1.57)) ||((%check >= -3.14) && (%check < -1.57))) {
  	 	%correction1 = getWord(%trans,3) + %correction;
  	 	%correction2 = getWord(%trans,4) + %correction;
  	 }
  	 else {
  		 %correction1 = getWord(%trans,3) - %correction;
  		 %correction2 = getWord(%trans,4) - %correction;
  	 }
	%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ %correction1 @ " " @ %correction2 @ " " @ (getWord(%trans,5)+(%correction/2)) @ " " @ (getWord(%trans,6) + $trans1) @ " " @ (getWord(%trans,7)+$trans2) @ " " @ getWord(%trans,8) @ " "@getWord(%trans,9) @ " " @getWord(%trans,10) @ " " @getWord(%trans,11);
return %trans;
}

echo("LabRat::GetMuzzleTransform(); Activated");