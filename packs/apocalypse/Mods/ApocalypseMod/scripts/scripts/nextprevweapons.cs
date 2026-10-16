$NWeapons=0;

//      Add Weapon Function.. Designed to Allow the AAODX Weapon Kits to Dump Weapons into this file
//      and basically just insert themselves into the next weapon Prev Weapon Stack

function AddWeapon(%WeaponName)
{       // Create a New Weapon Index
        $Weap[$NWeapons]=%WeaponName;
        %PrevWeapon=$NWeapons-1;
        if(%PrevWeapon<0) %PrevWeapon=0;
        $NextWeapon[$Weap[%PrevWeapon]]=%WeaponName;    // Set the Prev Weapon to The New Weapon
        $NextWeapon[%WeaponName]=$Weap[0];                                  // Set the Next Weapon to the First Weapon
        $PrevWeapon[$Weap[0]]=%WeaponName;
        $PrevWeapon[%WeaponName]=$Weap[%PrevWeapon];
        $NWeapons++;
}

