function Nappy::Builder::Station(%clientId)
{
	Client::clearItemShopping(%clientId);
	%armor = Player::getArmor(%clientId);
	%max = getNumItems();

	for(%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		if($InvList[%item] != "" && $InvList[%item] && $ItemMax[%armor, %item] != 0) 
			Client::setItemShopping(%clientId, %item);
		else if(%item.className == Armor)  
			Client::setItemShopping(%clientId, %item);
	}
	updateBuyingList(%clientId);
	if(%clientId.usingBuilderStation)
		schedule("Nappy::Builder::Station(" @ %clientId @ ");",0.5);
}





function remoteAdjust(%clientId, %amount)
{
	if($BuilderMode)
		%clientId.adjustAmount = %amount;
}



function remoteMoveObject(%clientId, %direction)
{
	if($BuilderMode)
		Nappy::Builder::CheckCommand(%clientId, %direction, "*move");
}




function remoteRotateObject(%clientId, %direction)
{
	if($BuilderMode)
		Nappy::Builder::CheckCommand(%clientId, %direction, "*rotate");
}


function remoteCopyObject(%clientId)
{
	if($BuilderMode)
		Nappy::Builder::CheckCommand(%clientId, 0, "*copy");
}


//)))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))


function Nappy::Builder::CheckForCommand(%clientId,%message)
{
	%Nappy::Builder::Command = GetWord(%message,0);
	%info = GetWord(%message,1);

	if(Nappy::Builder::CheckCommand(%clientId,%info,%Nappy::Builder::Command,1))
		return 1;
	else
		return 0;
}








function Nappy::Builder::CheckCommand(%clientId,%info,%Nappy::Builder::Command,%return)
{
	if(%Nappy::Builder::Command == "*move"){
		Nappy::Builder::MoveObject(%clientId, %info, "move");
		if(%return)
			return 1;
	}
	else if(%Nappy::Builder::Command == "*rotate"){
		Nappy::Builder::MoveObject(%clientId, %info, "rot");
		if(%return)
			return 1;
	}
	else if(%Nappy::Builder::Command == "*amount"){
		%amount = %info;
		%clientId.adjustAmount = %amount;
		if(%return)
			return 1;
	}
	else if(%Nappy::Builder::Command == "*copy"){
		Nappy::Builder::CopyObject(%clientId);
		if(%return)
			return 1;
	}
	else if(%return)
		return 0;
}



function Nappy::Builder::MoveOwnedObject(%object, %info, %type, %amount, %return)
{
	if(%type == "move"){
		%position = GameBase::getPosition(%object.beam1);
		%objPosX = GetWord(%position,0);
		%objPosY = GetWord(%position,1);
		%objPosZ = GetWord(%position,2);

		%direction = %info;//GetWord(%info,1);

		if(%direction == "east"){
			%objPosX = %objPosX + %amount;
		}
		else if(%direction == "west"){
			%objPosX = %objPosX - %amount;
		}
		else if(%direction == "north"){
			%objPosY = %objPosY + %amount;
		}
		else if(%direction == "south"){
			%objPosY = %objPosY - %amount;
		}
		else if(%direction == "up"){
			%objPosZ = %objPosZ + %amount;
		}
		else if(%direction == "down"){
				%objPosZ = %objPosZ - %amount;
		}
		GameBase::setPosition(%object.beam1, %objPosX @ " " @ %objPosY @ " " @ %objPosZ);
	}
	else if(%type == "rot"){
		%rotation = GameBase::getRotation(%object.beam1);
		%objRotX = GetWord(%rotation,0);
		%objRotY = GetWord(%rotation,1);
		%objRotZ = GetWord(%rotation,2);

		%direction = %info;


		if(%direction == "xp"){
			%objRotX = %objRotX + %amount;
		}
		else if(%direction == "xm"){
			%objRotX = %objRotX - %amount;
		}
		else if(%direction == "yp"){
			%objRotY = %objRotY + %amount;
		}
		else if(%direction == "ym"){
			%objRotY = %objRotY - %amount;
		}
		else if(%direction == "zp"){
			%objRotZ = %objRotZ + %amount;
		}
		else if(%direction == "zm"){
			%objRotZ = %objRotZ - %amount;
		}
		GameBase::setRotation(%object.beam1, %objRotX @ " " @ %objRotY @ " " @ %objRotZ);
	}



}


function Nappy::Builder::MoveObject(%clientId, %info, %type)
{

	%distance = 700;
	%player = Client::getOwnedObject(%clientId);

	if(GameBase::getLOSInfo(%player,%distance)){
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object

		%amount = %clientId.adjustAmount;

		if(%type == "move" && %type != "rot"){
			%position = GameBase::getPosition($los::object);
			%objPosX = GetWord(%position,0);
			%objPosY = GetWord(%position,1);
			%objPosZ = GetWord(%position,2);

			%direction = %info;//GetWord(%info,1);

			if(%direction == "east"){
				%objPosX = %objPosX + %amount;
			}
			else if(%direction == "west"){
				%objPosX = %objPosX - %amount;
			}
			else if(%direction == "north"){
				%objPosY = %objPosY + %amount;
			}
			else if(%direction == "south"){
				%objPosY = %objPosY - %amount;
			}
			else if(%direction == "up"){
				%objPosZ = %objPosZ + %amount;
			}
			else if(%direction == "down"){
				%objPosZ = %objPosZ - %amount;
			}
			GameBase::setPosition($los::object, %objPosX @ " " @ %objPosY @ " " @ %objPosZ);
		}
		else if(%type == "rot"){
			%rotation = GameBase::getRotation($los::object);
			%objRotX = GetWord(%rotation,0);
			%objRotY = GetWord(%rotation,1);
			%objRotZ = GetWord(%rotation,2);

			%direction = %info;

			if(%direction == "xp"){
				%objRotX = %objRotX + %amount;
			}
			else if(%direction == "xm"){
				%objRotX = %objRotX - %amount;
			}
			else if(%direction == "yp"){
				%objRotY = %objRotY + %amount;
			}
			else if(%direction == "ym"){
				%objRotY = %objRotY - %amount;
			}
			else if(%direction == "zp"){
				%objRotZ = %objRotZ + %amount;
			}
			else if(%direction == "zm"){
				%objRotZ = %objRotZ - %amount;
			}
			GameBase::setRotation($los::object, %objRotX @ " " @ %objRotY @ " " @ %objRotZ);
		}
		%name = GameBase::getDataName($los::object);
		if(%name == "DeployableTeleport"){
			messageall(1,"sending to beam move");
			Nappy::Builder::MoveOwnedObject($los::object, %info, %type, %amount);
		}
	}
}


function Nappy::Builder::CopyObject(%clientId)
{
	%distance = 700;
	%player = Client::getOwnedObject(%clientId);

	if(GameBase::getLOSInfo(%player,%distance)){
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%object = $los::object;
		%objectType = getObjectType(%object);
		if(%objectType != "InteriorShape"){
			%position = GameBase::getPosition(%object);

			%rotation = GameBase::getRotation(%object);

			%shape = GameBase::getDataName(%object);
			%copy = newObject("",%objectType,%shape,true);
			GameBase::setPosition(%copy,%position);
			GameBase::setRotation(%copy, %rotation);
		}
	}
}













