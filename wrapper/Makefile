CXX ?=		c++
CXXFLAGS ?=	-O2 -pipe
LD ?=		ld
NATIVE_MAJOR ?=	0
NATIVE_MINOR ?=	0

libsteamwrapper.so: steam_wrapper.cpp steam_wrapper.h
	$(CXX) $(CXXFLAGS) -fPIC -c -I. -o steamwrapper.o steam_wrapper.cpp
	$(LD) $(LDFLAGS) -shared -o \
		libsteamwrapper.so.$(NATIVE_MAJOR).$(NATIVE_MINOR) \
		steamwrapper.o 

.PHONY: clean
clean:
	@rm -f *.o *.so.$(NATIVE_MAJOR).$(NATIVE_MINOR)
