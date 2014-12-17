all:
	mcs *.cs -out:test.exe
	mono test.exe
