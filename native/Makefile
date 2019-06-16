CXX ?=		c++
CXXFLAGS ?=	-O2 -pipe
LD ?=		ld
NATIVE_MAJOR ?=	0
NATIVE_MINOR ?=	0

libSteamworksNative.so: SteamworksNative.cpp SteamworksNative.h
	$(CXX) $(CXXFLAGS) -fPIC -c -I. -o SteamworksNative.o SteamworksNative.cpp
	$(LD) $(LDFLAGS) -shared -o \
		libSteamworksNative.so.$(NATIVE_MAJOR).$(NATIVE_MINOR) \
		SteamworksNative.o 

.PHONY: clean
clean:
	@rm -f *.o *.so.$(NATIVE_MAJOR).$(NATIVE_MINOR)
