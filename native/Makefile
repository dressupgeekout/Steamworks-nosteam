CXX ?=		c++
CXXFLAGS ?=	-O2 -g

libSteamworksNative.so: SteamworksNative.cpp SteamworksNative.h
	$(CXX) $(CXXFLAGS) -fPIC -c -I. -o SteamworksNative.o SteamworksNative.cpp
	$(CXX) $(CXXFLAGS) -shared -o libSteamworksNative.so SteamworksNative.o 

.PHONY: clean
clean:
	@rm -f *.o *.so
