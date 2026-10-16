ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}

echo('>> Loading Tools');
exec(tool_energyconduit);
exec(tool_programslot);
exec(tool_ram);
exec(tool_resist);
echo('>> Finished Loading Tools');
