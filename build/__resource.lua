resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'

version '1.2'

server_scripts {
	'mc_accounts_server.net.dll',
	'versionCheck.lua'
}

exports {
	'createAccount',
	'findAccount',
	'getPassword',
	'updatePassword',
	'deleteAccount'
}