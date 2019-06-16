CXX=c++

libSteamworksNative.so: SteamworksNative.cpp
	$(CXX) -fPIC -c -I. -o SteamworksNative.o SteamworksNative.cpp
	$(CXX) -shared -o libSteamworksNative.so SteamworksNative.o 

.PHONY: clean

clean:
	rm -f *.o *.so
