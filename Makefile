PREFIX ?=	/usr/local

all: Steamworks.NET/bin/Steamworks.NET.dll native

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

install: Steamworks.NET/bin/Steamworks.NET.dll native/libSteamworksNative.so.*
	install -d $(DESTDIR)$(PREFIX)/lib/steamworks-nosteam/
	install Steamworks.NET/bin/Steamworks.NET.dll \
		$(DESTDIR)$(PREFIX)/lib/steamworks-nosteam/
	install native/libSteamworksNative.so.* \
		$(DESTDIR)$(PREFIX)/lib/steamworks-nosteam/

.PHONY: clean uninstall native
native:
	$(MAKE) -C native

clean:
	@rm -rf Steamworks.NET/{bin,obj}
	@$(MAKE) -C native clean

uninstall:
	rm -f $(PREFIX)/lib/steamworks-nosteam/{Steamworks.NET.dll,libSteamworksNative.so.*}
	rmdir $(PREFIX)/lib/steamworks-nosteam/
