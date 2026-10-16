//============================= Standard Invo Station
StaticShapeData InventoryStation
{
   	description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread))
		InventoryStation::onResupply(%this,"InvList");
}

function InventoryStation::onResupply(%this,%InvShopList)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%player.Station = %this;
				%client.ListType = %InvShopList;

				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;

				if ($Wasteland::ItemLimit)
				{
					%client.invo = %this;
					%client.ListType = %InvShopList;
				}

            		if(!%client.noEnterInventory)
   					Client::setGuiMode(%client,$GuiModeInventory);

				Client::sendMessage(%client,0,"Station Access On");
				%player.ResupplyFlag = 1;
				%shooterClient = %this.tc;
				if (%shooterClient) //==== is sabotaged
				{
					%shape = (GameBase::getDataName(%this)).shapeFile;
					if(%shape == "inventory_sta")
					{
						%rnd = floor(getRandom() * 100);
						if(%rnd > 70)
						{
							Player::setArmor(%client, jarmor);
						}
						else if( (%rnd > 50) && (%rnd <70) )
						{
							Player::setArmor(%client, afemale);
						}
						else if( (%rnd > 30) && (%rnd <50) )
						{
							Player::setArmor(%client, spyarmor);
						}
						else if( (%rnd > 10) && (%rnd <30) )
						{
							Player::setArmor(%client, mfemale);
						}
						else
						{
							Player::setArmor(%client, harmor);
						}
						%rnd = floor(getRandom() * 6);
						if (%rnd <2) %rnd = 6;
						GameBase::setTeam (%player,%rnd);
						%forceDir = Vector::getFromRot(GameBase::getRotation(%this),-300,0); 
						Player::applyImpulse(%player,%forceDir);
						Client::sendMessage(%client,1,"You feel kinda funny. Do you think that station might have been sabotaged?~wturretoff1.wav");
					}
					else
					{
						%chanpos = "0 0 100";
						%npos = Vector::add(gamebase::getposition(%player), %chanpos);
						GameBase::setPosition(%player,%npos);
						%forceDir = Vector::getFromRot(GameBase::getRotation(%this),0,1000); 
						Player::applyImpulse(%player,%forceDir);
						Client::sendMessage(%client,1,"Do you think that station might have been sabotaged?~wBXplo1.wav");
					}
					MessageAllExcept(%client, 0, Client::getName(%client) @ " is a victim of " @ Client::getName(%shooterClient) @ "'s sabotage!");
					%shooterClient.score = %shooterClient.score +5;
  					Bottomprint(%shooterClient, "<jc>Sabotage Success! Score +5 = " @ %shooterClient.score ,3);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);

			if(%player.ResupplyFlag)
				%player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation)
		{
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
			%player.Station = "";
			%this.target = "";
		}
	}
	%this.enterTime="";
}