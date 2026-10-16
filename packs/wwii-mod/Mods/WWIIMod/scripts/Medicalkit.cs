

$AutoUse[medicalkit] = true;
$WeaponAmmo[Medicalkit] = medicalkitammo;


ItemData MedicalkitAmmo
{
	description = "medical kit contents";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MedicalKitImage
{
	shapeFile = "armorpack";
	mountPoint = 0;

	weaponType = 3;
	reloadTime = 0;
	Mountoffset = { -0.2, -0.1, 0.0 };
	fireTime = 0.05;

	ammoType = MedicalkitAmmo;
	
	accuFire = true;

	
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpHealth;
	
};

ItemData MedicalKit
{
	description = "Medical Kit";
	className = "Weapon";
	shapeFile = "armorpack";
   validateShape = true;
	hudIcon = "weapon";
   heading = "cmedic";
	shadowDetailMask = 4;
	imageType = medicalkitImage;
	price = 200;
	showWeaponBar = true;
};


function MedicalkitImage::onFire(%player, %slot)
{
	if(Player::isDead(%player)) return;
	
	%playerhealth = GameBase::getDamageLevel(%player);
	%rate = %playerhealth-0.02;
	GameBase::setDamageLevel(%player, %rate);
	if(Gamebase::getLOSinfo(%player, 2.1)) %object = $los::object; else %object = 8;
	if(gamebase::getdamagelevel(%object) > 0 || gamebase::getdamagelevel(%player) > 0) Player::decItemCount(%player, medicalkitammo);
	%x = getObjectType(%object);  
	if(%x == "Player") 
	{
	if(gamebase::getdamagelevel(%object) == 0) return;
	Stats::Heal(player::getclient(%player));
	GameBase::setDamageLevel(%object, GameBase::getDamageLevel(%object) - 0.05);
	if(player::isAIcontrolled(%object) && gamebase::getdamagelevel(%object) == 0) $AI::Int[$Ai::IdToName[player::getclient(%object)]] = "I was healed by: " @ player::getclient(%player); 
	}
}
