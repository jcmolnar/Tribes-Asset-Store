EditActionMap("playMap.sae");
bindCommand(keyboard0, make, "0", TO, "remoteEval(2048,UseSpecial);");
bindCommand(keyboard0, make, "f11", TO, "remoteEval(2048,WeaponModeNext);");
bindCommand(keyboard0, make, "f12", TO, "remoteEval(2048,WeaponModePrev);");
bindCommand(keyboard0, make, "c", TO, "remoteEval(2048,PlayerKneel);");
bindCommand(keyboard0, break, "c", TO, "remoteEval(2048,PlayerStand);");
