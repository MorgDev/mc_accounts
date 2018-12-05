resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'

version '1.0'

server_script 'mc_accounts_server.net.dll'

exports {
	'createAccount',
	'findAccount',
	'getPassword',
	'updatePassword',
	'deleteAccount'
}