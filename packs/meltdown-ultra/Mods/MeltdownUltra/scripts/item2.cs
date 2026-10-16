function remoteSell4SlotWeapons(%client)
{
    Client::sendMessage(%client,0,"Bought God Hammer Cannon - Auto Selling any 2 or 4 Slot Weapons");
    Player::setItemCount(%client, MMinigun,0);
    Player::setItemCount(%client, MMinigunAmmo,0);
    //
    Player::setItemCount(%client, Minigun,0);
    Player::setItemCount(%client, MinigunAmmo,0);
    //
    Player::setItemCount(%client, TwinFusor,0);
    Player::setItemCount(%client, TwinFusorAmmo,0);
    //
    Player::setItemCount(%client, IonCannon,0);
    //
    Player::setItemCount(%client, MECHRocketLauncher,0);
    Player::setItemCount(%client, MissileAmmo,0);
    //
    Player::setItemCount(%client, MrpgLauncher,0);
    Player::setItemCount(%client, MrpgAmmo,0);
    //
    Player::setItemCount(%client, rifle,0);
    Player::setItemCount(%client, Shells,0);
    //
    Player::setItemCount(%client, DefendersRunGun,0);
    //
    Player::setItemCount(%client, Charger,0);
    //
    Player::unMountItem(%client,4);
    Player::unMountItem(%client,5);
}

function remoteSellGodHammer(%client)
{
    //Client::sendMessage(%client,0,"Bought 2 or 4 Slot Weapons- Auto Selling God Hammer Cannon");
    Player::setItemCount(%client, Hammer1Pack,0);
    Player::setItemCount(%client, Hammer2Pack,0);
    Player::setItemCount(%client, HammerAmmo,0);
    Player::unMountItem(%client,4);
    Player::unMountItem(%client,5);
}

