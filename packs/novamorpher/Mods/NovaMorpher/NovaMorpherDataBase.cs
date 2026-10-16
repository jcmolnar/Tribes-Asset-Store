// NovaMorpher user login database -- EMPTY in the 1.50 port.
//
// The 0.821 release shipped two working SuperAdmin accounts here (the author's and a friend's,
// with their passwords). They are not in the port.
//
// A player logs in with the chat line   #login <user> <password>   (or the stock admin
// password box, typed as   <user> <password>). A login needs all three lines below and the
// player's address must match the ip line. The user name is ONE word. Everything is case
// sensitive. Status is SuperAdmin or Admin. "*" in the ip is a wild card.
//
// $NovaMorpher::UserDB[SomeUser, password] = "a long password";
// $NovaMorpher::UserDB[SomeUser, ip] = "IP:192.168.0.*";
// $NovaMorpher::UserDB[SomeUser, status] = "Admin";
