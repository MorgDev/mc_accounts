Citizen.CreateThread(function()
        local path = '/MorgDev/mc_accounts'
        local resource = 'mc_accounts (' .. GetCurrentResourceName() .. ')'

        function verCheck(err, response, headers)
            local curVersion
            string.gsub(LoadResourceFile(GetCurrentResourceName(), "__resource.lua"), "'%d.%d'", function(answer) curVersion = answer end)
            string.gsub(response, "'%d.%d'", function(result)
                curVersion = string.sub(curVersion, 2, -2)
                result = string.sub(result, 2, -2)
                if curVersion ~= result and tonumber(curVerion) < tonumber(result) then
                    print("\n#####################")
                    print("\n" .. resource .. " is outdated, should be: \n" .. result .. "is:\n" .. curVersion .. "\nPlease update it from https://github.com"..updatePath)
                    print("\n#####################")
                elseif tonumber(curVersion) > tonumber(result) then
                    print("You somehow skipped a few versions of " .. resource .. " or the git was offline, if it's still online I suggest you reload the latest github version.")
                else
                    print("\n" .. resource .. " is up to date, have fun!")
                end
            end)             
        end

        PerformHttpRequest('https://raw.githubusercontent.com' .. path .. '/master/build/__resource.lua', verCheck, 'GET')
end)