//for some reason, the weapon list got totally messed up.
//so, I'm manually recreating it.
$firstweapon = soulsucker;
$lastweapon = vulcan;
$nextweapon[vulcan] = soulsucker;
$prevweapon[soulsucker] = vulcan;

$nextweapon[soulsucker] = deathray;
$nextweapon[deathray] = pulsecannon;
$nextweapon[pulsecannon] = railgun;
$nextweapon[railgun] = plasmagun;
$nextweapon[plasmagun] = grenadelauncher;
$nextweapon[grenadelauncher] = rubbermortar;
$nextweapon[rubbermortar] = angelfire;
$nextweapon[angelfire] = flamestrike;
$nextweapon[flamestrike] = ShockingGrasp;
$nextweapon[shockinggrasp] = stasis;
$nextweapon[stasis] = spellflamethrower;
$nextweapon[spellflamethrower] = heavensfury;
$nextweapon[heavensfury] = sniperrifle;
$nextweapon[sniperrifle] = Tblastcannon;
$nextweapon[Tblastcannon] = Shockwavegun;
$nextweapon[shockwavegun] = rocketlauncher;
$nextweapon[rocketlauncher] = flamethrower;
$nextweapon[flamethrower] = disclauncher;
$nextweapon[disclauncher] = mortar;
$nextweapon[mortar] = hdisclauncher;
$nextweapon[hdisclauncher] = disarmerspell;
$nextweapon[disarmerspell] = babynukemortar;
$nextweapon[babynukemortar] = phasedisrupter;
$nextweapon[phasedisrupter] = stinger;
$nextweapon[stinger] = OSLauncher;
$nextweapon[OSLauncher] = JailGun;
$nextweapon[JailGun] = TankRPGLauncher;
$nextweapon[TankRPGLauncher] = shotgun;
$nextweapon[shotgun] = TankShredder;
$nextweapon[TankShredder] = TRocketLauncher;
$nextweapon[TRocketLauncher] = vulcan;

$prevweapon[deathray] = soulsucker;
$prevweapon[pulsecannon] = deathray;
$prevweapon[railgun] = pulsecannon;
$prevweapon[plasmagun] = railgun;
$prevweapon[grenadelauncher] = plasmagun;
$prevweapon[rubbermortar] = grenadelauncher;
$prevweapon[angelfire] = rubbermortar;
$prevweapon[flamestrike] = angelfire;
$prevweapon[ShockingGrasp] = flamestrike;
$prevweapon[stasis] = shockinggrasp;
$prevweapon[spellflamethrower] = stasis;
$prevweapon[heavensfury] = spellflamethrower;
$prevweapon[sniperrifle] = heavensfury;
$prevweapon[Tblastcannon] = sniperrifle;
$prevweapon[Shockwavegun] = Tblastcannon;
$prevweapon[rocketlauncher] = shockwavegun;
$prevweapon[flamethrower] = rocketlauncher;
$prevweapon[disclauncher] = flamethrower;
$prevweapon[mortar] = disclauncher;
$prevweapon[hdisclauncher] = mortar;
$prevweapon[disarmerspell] = hdisclauncher;
$prevweapon[babynukemortar] = disarmerspell;
$prevweapon[phasedisrupter] = babynukemortar;
$prevweapon[stinger] = phasedisrupter;
$prevweapon[OSLauncher] = stinger;
$prevweapon[JailGun] = OSLauncher;
$prevweapon[TankRPGLauncher] = JailGun;
$prevweapon[shotgun] = TankRPGLauncher;
$prevweapon[TankShredder] = shotgun;
$prevweapon[TRocketLauncher] = TankShredder;
$prevweapon[vulcan] = TRocketLauncher;

//can't think of any better place to put this..
function DisplayURL()
{
centerprintall("Apteryx's website:    users.adelphia.net/~mworhatch/Apteryx.html", 10);
}