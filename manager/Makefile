CXX ?=		c++
CXXFLAGS ?=	-O2 -pipe
LD ?=		ld
NATIVE_MAJOR ?=	0
NATIVE_MINOR ?=	0

libSteamworksNative.so: SteamManager.cpp
	$(CXX) $(CXXFLAGS) -fPIC -c -I. -o SteamManager.o SteamManager.cpp
	$(LD) $(LDFLAGS) -shared -o \
		libSteamManager.so.$(NATIVE_MAJOR).$(NATIVE_MINOR) \
		SteamManager.o 

.PHONY: clean
clean:
	@rm -f *.o *.so.$(NATIVE_MAJOR).$(NATIVE_MINOR)
