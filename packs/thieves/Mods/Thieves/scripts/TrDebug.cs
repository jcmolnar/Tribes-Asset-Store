function TrDebug() {
%DebugClient=2049;
%DebugObject=Client::getOwnedObject(2049);
echo("Player Data:");
echo("Client: 2049");
echo("Player Object:"@%DebugObject);
echo("Shields: "@%DebugObject.shieldStrength);
} 
function cto(%name,%shapefile) {
if(gamebase::getlosinfo(client::getownedobject(2049),50) == True) { 
%pos=Vector::add($los::position,"0 0 50");
instant InteriorShape %name {
filename=%shapefile;
iscontainer="1";
position=%pos;
rotation="0 0 0";
lightparams="0";
locked="0";
};
} 
}
function info() {
if(gamebase::getlosinfo(client::getownedobject(2049),5000)) {
echo("LOS Object: "@$los::object);
echo("LOS Position: "@$los::position);
echo("Object Data Name: "@GameBase::getDataName($los::object));
echo("Object Map Name: "@GameBase::getMapName($los::object));
echo("Object Position: "@GameBase::getPosition($los::object));
}
}
function purg(%clientid) {
gamebase::setposition(%clientid,DRifter::getRandomPos());
}
function tx(%clientid) {
%player=Client::getownedobject(%clientid);
%tx=GameBase::getMuzzleTransform(%player); 
for(%c=0;(%w[%c]=getword(%tx,%c))!=-1;%c++) {}
%c--;
echo("TX:  "@%c+1@" parameters.");
%ntx="";
for(%cc=0;%cc<%c;%cc+=3) {
echo("TX:      P"@%cc@": "@%w[%cc]@"   P"@%cc+1@": "@%w[%cc+1]@"   P"@%cc+2@": "@%w[%cc+2]);
if(%cc!=0 && %cc!=6) %ntx=%ntx@%w[%cc]@" "@%w[%cc+1]@" "@%w[%cc+2]@" ";
else %ntx=%ntx@"0 0 0 ";
}
echo("TXNew: "@%ntx);
Projectile::spawnProjectile("FusionBolt",%ntx,%player,0);
}
function tf() {
if(gamebase::getlosinfo(client::getownedobject(2049),5000)) {
%pos=GameBase::getPosition($los::object);
%tx=GameBase::getMuzzleTransform($los::object); 
%ws[0]="";
%ws[1]="";
%ws[2]="";
%ws[3]="";
for(%c=0;(%w[%c]=getword(%tx,%c))!=-1;%c++) {
if(%c>=0 && %c<=2) {
%ws[0]=%ws[0]@%w[%c]@" ";
}
if(%c>=3 && %c<=5) {
%ws[1]=%ws[1]@%w[%c]@" ";
}
if(%c>=6 && %c<=8) {
%ws[2]=%ws[2]@%w[%c]@" ";
}
if(%c>=9 && %c<=11) {
%ws[3]=%ws[3]@%w[%c]@" ";
}
}
%pos=Vector::add(%pos,"0 1 1");
%tran="0 0 0 "@%ws[3]@"0 0 0 "@%pos;
Projectile::spawnProjectile("FusionBolt",%tran,$los::object,0);
echo("TRAN: "@%tran);
}
}
