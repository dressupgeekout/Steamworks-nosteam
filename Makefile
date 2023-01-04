PREFIX ?=	/usr/local

all: native wrapper cestub

Steamworks.NET/bin/Steamworks.NET.dll:	Steamworks.NET/*.cs \
				Steamworks.NET/*.csproj \
				Steamworks.NET/*.sln \
				Steamworks.NET/*.config \
				Steamworks.NET/autogen/*.cs \
				Steamworks.NET/types/MatchmakingTypes/*.cs \
				Steamworks.NET/types/SteamClient/*.cs \
				Steamworks.NET/types/SteamClientPublic/*.cs \
				Steamworks.NET/types/SteamController/*.cs \
				Steamworks.NET/types/SteamFriends/*.cs \
				Steamworks.NET/types/SteamHTMLSurface/*.cs \
				Steamworks.NET/types/SteamHTTP/*.cs \
				Steamworks.NET/types/SteamInput/*.cs \
				Steamworks.NET/types/SteamInventory/*.cs \
				Steamworks.NET/types/SteamMatchmaking/*.cs \
				Steamworks.NET/types/SteamNetworking/*.cs \
				Steamworks.NET/types/SteamRemoteStorage/*.cs \
				Steamworks.NET/types/SteamScreenshots/*.cs \
				Steamworks.NET/types/SteamTypes/*.cs \
				Steamworks.NET/types/SteamUGC/*.cs \
				Steamworks.NET/types/SteamUnifiedMessages/*.cs \
				Steamworks.NET/types/SteamUserStats/*.cs \
				Steamworks.NET/types/Steam_api_common/*.cs
	@cd Steamworks.NET && xbuild Steamworks.NET.sln

install: all
	install -d $(PREFIX)/lib/steamworks-nosteam/
	install Steamworks.NET/bin/Steamworks.NET.dll \
		$(PREFIX)/lib/steamworks-nosteam/
	install native/libSteamworksNative.so.* \
		$(PREFIX)/lib/steamworks-nosteam/
	install wrapper/libsteamwrapper.so.* \
		$(PREFIX)/lib/steamworks-nosteam/
	install cestub/libcestub.so.* \
		$(PREFIX)/lib/steamworks-nosteam/

.PHONY: clean uninstall native wrapper cestub hlsteam

native:
	$(MAKE) -C native

wrapper:
	$(MAKE) -C wrapper

cestub:
	$(MAKE) -C cestub

hlsteam:
	$(MAKE) -C hlsteam

clean:
	@rm -rf Steamworks.NET/{bin,obj}
	@$(MAKE) -C native clean
	@$(MAKE) -C wrapper clean
	@$(MAKE) -C cestub clean
	@$(MAKE) -C hlsteam clean

uninstall:
	rm -f $(PREFIX)/lib/steamworks-nosteam/Steamworks.NET.dll
	rm -f $(PREFIX)/lib/steamworks-nosteam/libSteamworksNative.so.*
	rm -f $(PREFIX)/lib/steamworks-nosteam/libsteamwrapper.so.*
	rm -f $(PREFIX)/lib/steamworks-nosteam/libcestub.so.*
	rm -f $(PREFIX)/lib/steamworks-nosteam/steam.hdll
	rmdir $(PREFIX)/lib/steamworks-nosteam/
